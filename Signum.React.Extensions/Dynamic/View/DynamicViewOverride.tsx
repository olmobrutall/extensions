﻿import * as React from 'react'
import { MenuItem } from 'react-bootstrap'
import { classes } from '../../../../Framework/Signum.React/Scripts/Globals'
import * as Constructor from '../../../../Framework/Signum.React/Scripts/Constructor'
import { DynamicViewOverrideEntity, DynamicViewMessage } from '../Signum.Entities.Dynamic'
import { EntityLine, TypeContext, ValueLineType } from '../../../../Framework/Signum.React/Scripts/Lines'
import { Entity, JavascriptMessage, NormalWindowMessage, is } from '../../../../Framework/Signum.React/Scripts/Signum.Entities'
import { getTypeInfo, Binding, PropertyRoute, ReadonlyBinding, getTypeInfos } from '../../../../Framework/Signum.React/Scripts/Reflection'
import JavascriptCodeMirror from '../../Codemirror/JavascriptCodeMirror'
import * as DynamicViewClient from '../DynamicViewClient'
import * as DynamicClient from '../DynamicClient'
import * as Navigator from '../../../../Framework/Signum.React/Scripts/Navigator'
import { ViewReplacer } from '../../../../Framework/Signum.React/Scripts/Frames/ReactVisitor';
import TypeHelpComponent from '../Help/TypeHelpComponent'
import { AuthInfo } from './AuthInfo'
import ValueLineModal from '../../../../Framework/Signum.React/Scripts/ValueLineModal'
import ModalMessage from '../../../../Framework/Signum.React/Scripts/Modals/ModalMessage'
import * as Nodes from '../../../../Extensions/Signum.React.Extensions/Dynamic/View/Nodes';


interface DynamicViewOverrideComponentProps {
    ctx: TypeContext<DynamicViewOverrideEntity>;
}

interface DynamicViewOverrideComponentState {
    exampleEntity?: Entity;
    componentClass?: React.ComponentClass<{ ctx: TypeContext<Entity> }> | null;
    syntaxError?: string;
    viewOverride?: (e: ViewReplacer<Entity>, authInfo: AuthInfo) => void;
    scriptChanged?: boolean;
    viewNames?: string[];
    typeHelp?: DynamicClient.TypeHelp;
}

export default class DynamicViewOverrideComponent extends React.Component<DynamicViewOverrideComponentProps, DynamicViewOverrideComponentState> {

    constructor(props: DynamicViewOverrideComponentProps) {
        super(props);

        this.state = {};
    }


    componentWillMount() {
        this.updateViewNames(this.props);
        this.updateTypeHelp(this.props);
    }

    componentWillReceiveProps(newProps: DynamicViewOverrideComponentProps) {
        if (newProps.ctx.value.entityType && this.props.ctx.value.entityType && !is(this.props.ctx.value.entityType, newProps.ctx.value.entityType)) {
            this.updateViewNames(newProps);
            this.updateTypeHelp(newProps);
        }
    }

    updateViewNames(props: DynamicViewOverrideComponentProps) {
        this.setState({ viewNames: undefined });
        if (props.ctx.value.entityType)
            DynamicViewClient.API.getDynamicViewNames(props.ctx.value.entityType!.cleanName)
                .then(viewNames => this.setState({ viewNames: viewNames }))
                .done();
    }

    updateTypeHelp(props: DynamicViewOverrideComponentProps) {
        this.setState({ typeHelp: undefined });
        if (props.ctx.value.entityType)
            DynamicClient.API.typeHelp(props.ctx.value.entityType!.cleanName, "CSharp")
                .then(th => this.setState({ typeHelp: th }))
                .done();
    }

    handleTypeChange = () => {
        this.updateViewNames(this.props);
        this.updateTypeHelp(this.props);
    }

    handleTypeRemove = () => {
        if (this.state.scriptChanged == true)
            return ModalMessage.show({
                title: NormalWindowMessage.ThereAreChanges.niceToString(),
                message: JavascriptMessage.loseCurrentChanges.niceToString(),
                buttons: "yes_no",
                icon: "warning",
                defaultStyle: "warning"
            }).then(result => { return result == "yes" });

        return Promise.resolve(true);
    }

    handleRemoveClick = (lambda: string) => {
        setTimeout(() => this.showPropmt("Remove", `vr.remove(${lambda})`), 0);
    }

    handleInsertBeforeClick = (lambda: string) => {
        setTimeout(() => this.showPropmt("InsertBefore", `vr.insertBefore(${lambda}))}, yourElement);`), 0);
    }

    handleInsertAfterClick = (lambda: string) => {
        setTimeout(() => this.showPropmt("InsertAfter", `vr.insertAfter(${lambda}, yourElement);`), 0);
    }

    handleRenderContextualMenu = (pr: PropertyRoute) => {
        const lambda = "e => " + TypeHelpComponent.getExpression("e", pr, "Typescript");
        return (
            <MenuItem>
                <MenuItem header>{pr.propertyPath()}</MenuItem>
                <MenuItem divider />
                <MenuItem onClick={() => this.handleRemoveClick(lambda)}><i className="fa fa-trash" aria-hidden="true" />&nbsp; Remove</MenuItem>
                <MenuItem onClick={() => this.handleInsertBeforeClick(lambda)}><i className="glyphicon glyphicon-menu-left" aria-hidden="true" />&nbsp; Insert Before</MenuItem>
                <MenuItem onClick={() => this.handleInsertAfterClick(lambda)}><i className="glyphicon glyphicon-menu-right" aria-hidden="true" />&nbsp; Insert After</MenuItem>
            </MenuItem>
        );
    }

    handleTypeHelpClick = (pr: PropertyRoute | undefined) => {
        if (!pr || !pr.member || !pr.parent || pr.parent.propertyRouteType != "Mixin")
            return;

        var node = Nodes.NodeConstructor.appropiateComponent(pr.member, pr.propertyPath());
        if (!node)
            return;

        const expression = TypeHelpComponent.getExpression("o", pr, "Typescript");
        const text = `React.createElement(${node.kind}, { ctx: vr.ctx.subCtx(o => ${expression}) })`;

        ValueLineModal.show({
            type: { name: "string" },
            initialValue: text,
            valueLineType: "TextArea",
            title: "Mixin Template",
            message: "Copy to clipboard: Ctrl+C, ESC",
            initiallyFocused: true,
        }).done();
    }

    render() {
        const ctx = this.props.ctx;

        return (
            <div>
                <EntityLine ctx={ctx.subCtx(a => a.entityType)} onChange={this.handleTypeChange} onRemove={this.handleTypeRemove} />

                {ctx.value.entityType &&
                    <div>
                        <br />
                        <div className="row">
                            <div className="col-sm-7">
                                {this.renderExampleEntity(ctx.value.entityType!.cleanName)}
                                {this.renderEditor()}
                            </div>
                            <div className="col-sm-5">
                            <TypeHelpComponent
                                initialType={ctx.value.entityType.cleanName}
                                mode="Typescript"
                                renderContextMenu={this.handleRenderContextualMenu}
                                onMemberClick={this.handleTypeHelpClick} />
                                <br />
                            </div>
                        </div>
                        <hr />
                        {this.renderTest()}
                    </div>
                }
            </div>
        );
    }

    renderTest() {
        const ctx = this.props.ctx;
        return (
            <div>
                {this.state.exampleEntity && this.state.componentClass &&
                    <RenderWithReplacements entity={this.state.exampleEntity}
                        componentClass={this.state.componentClass}
                        viewOverride={this.state.viewOverride} />}
            </div>
        );
    }

    renderExampleEntity(typeName: string) {
        const exampleCtx = new TypeContext<Entity | undefined>(undefined, undefined, PropertyRoute.root(typeName), Binding.create(this.state, s => s.exampleEntity));

        return (
            <div className="form-vertical code-container">
                <EntityLine ctx={exampleCtx} create={true} find={true} remove={true} view={true} onView={this.handleOnView} onChange={this.handleEntityChange} formGroupStyle="Basic"
                    type={{ name: typeName }} labelText={DynamicViewMessage.ExampleEntity.niceToString()} />
            </div>
        );
    }

    handleOnView = (exampleEntity: Entity) => {
        return Navigator.view(exampleEntity, { requiresSaveOperation: false });
    }

    handleCodeChange = (newCode: string) => {
        var dvo = this.props.ctx.value;

        if (dvo.script != newCode) {
            dvo.script = newCode;
            dvo.modified = true;
            this.setState({ scriptChanged: true });
            this.compileFunction();
        };
    }

    handleEntityChange = () => {

        if (!this.state.exampleEntity)
            this.setState({ componentClass: undefined });
        else {

            const entity = this.state.exampleEntity;
            const settings = Navigator.getSettings(entity.Type);

            if (!settings || !settings.getViewPromise)
                this.setState({ componentClass: null });

            else
                settings.getViewPromise(entity).applyViewOverrides(settings).promise.then(func => {
                    var tempCtx = new TypeContext(undefined, undefined, PropertyRoute.root(entity.Type), new ReadonlyBinding(entity, "example"));
                    var re = func(tempCtx);
                    this.setState({ componentClass: re.type as React.ComponentClass<{ ctx: TypeContext<Entity> }> });
                    this.compileFunction();
                });
        }
    }

    compileFunction() {

        this.setState({
            syntaxError: undefined,
            viewOverride: undefined,
        });

        const dvo = this.props.ctx.value;
        let func: (rep: ViewReplacer<Entity>, auth: AuthInfo) => void;
        try {
            func = DynamicViewClient.asOverrideFunction(dvo);
            this.setState({
                viewOverride : func
            });
        } catch (e) {
            this.setState({
                syntaxError : (e as Error).message
            });
            return;
        }
    }

    renderEditor() {

        const ctx = this.props.ctx;
        return (
            <div className="code-container">
                {this.allViewNames().length > 0 && this.renderViewNameButtons()}
                {this.allExpressions().length > 0 && <br />}
                {this.allExpressions().length > 0 && this.renderExpressionsButtons()}
                <pre style={{ border: "0px", margin: "0px" }}>{`(vr: ViewReplacer<${ctx.value.entityType!.className}>, auth: AuthInfo) =>`}</pre>
                <JavascriptCodeMirror code={ctx.value.script || ""} onChange={this.handleCodeChange} />
                {this.state.syntaxError && <div className="alert alert-danger">{this.state.syntaxError}</div>}
            </div>
        );
    }

    allViewNames() {
        return this.state.viewNames || [];
    }

    handleViewNameClick = (viewName: string) => {
        this.showPropmt("View", `React.createElement(DynamicViewPart, {ctx: vr.ctx, viewName:"${viewName}"})`);
    }

    renderViewNameButtons() {
        return (
            <div className="btn-group" style={{ marginBottom: "3px" }}>
                {this.allViewNames().map((vn, i) =>
                    <input key={i} type="button" className="btn btn-success btn-xs sf-button" value={vn} onClick={() => this.handleViewNameClick(vn)} />)}
            </div>);
    }

    allExpressions() {
        var typeHelp = this.state.typeHelp;
        if (!typeHelp)
            return [];

        return typeHelp.members.filter(m => m.name && m.isExpression == true);
    }

    handleExpressionClick = (member: DynamicClient.TypeMemberHelp) => {
        var paramValue = member.cleanTypeName ? `queryName : "${member.cleanTypeName}Entity"` : `valueToken: "Entity.${member.name}"`;
        this.showPropmt("Expression", `React.createElement(ValueSearchControlLine, {ctx: vr.ctx, ${paramValue}})`);
    }
       
    renderExpressionsButtons() {
        return (<div className="btn-group" style={{ marginBottom: "3px" }}>
            {this.allExpressions().map((m, i) =>
                <input key={i} type="button" className="btn btn-warning btn-xs sf-button" value={m.name} onClick={() => this.handleExpressionClick(m)} />)}
        </div>);
    }

    showPropmt(title: string, text: string) {

        ValueLineModal.show({
            type: { name: "string" },
            initialValue: text,
            valueLineType: "TextArea",
            title: title,
            message: "Copy to clipboard: Ctrl+C, ESC",
            initiallyFocused: true,
        }).done();
    }
}


interface RenderWithReplacementsProps {
    entity: Entity;
    componentClass: React.ComponentClass<{ ctx: TypeContext<Entity> }>;
    viewOverride?: (e: ViewReplacer<Entity>, authInfo: AuthInfo) => void;
}

export class RenderWithReplacements extends React.Component<RenderWithReplacementsProps, void> {


    originalRender: any;
    componentWillMount() {

        this.originalRender = this.props.componentClass.prototype.render;

        DynamicViewClient.unPatchComponent(this.props.componentClass);

        if (this.props.viewOverride)
            DynamicViewClient.patchComponent(this.props.componentClass, this.props.viewOverride);
    }

    componentWillReceiveProps(newProps: RenderWithReplacementsProps) {
        if (newProps.componentClass != this.props.componentClass)
            throw new Error("not implemented");

        if (newProps.viewOverride != this.props.viewOverride) {
            DynamicViewClient.unPatchComponent(this.props.componentClass);
            if (newProps.viewOverride)
                DynamicViewClient.patchComponent(this.props.componentClass, newProps.viewOverride);
        }
    }

    componentWillUnmount() {
        this.props.componentClass.prototype.render = this.originalRender;
    }

    render() {

        var ctx = new TypeContext(undefined, undefined, PropertyRoute.root(this.props.entity.Type), new ReadonlyBinding(this.props.entity, "example"));

        return React.createElement(this.props.componentClass, { ctx: ctx });
    }
}

