﻿import * as React from 'react'
import { Tabs, Tab } from 'react-bootstrap'
import { FormGroup, FormControlStatic, ValueLine, ValueLineType, EntityLine, EntityCombo, EntityList, EntityRepeater, EntityTabRepeater, EntityTable,  EntityCheckboxList, EnumCheckboxList, EntityDetail, EntityStrip } from '../../../../Framework/Signum.React/Scripts/Lines'
import { ModifiableEntity } from '../../../../Framework/Signum.React/Scripts/Signum.Entities'
import { classes, Dic } from '../../../../Framework/Signum.React/Scripts/Globals'
import * as Finder from '../../../../Framework/Signum.React/Scripts/Finder'
import { ColumnOptionsMode, FilterOperation, OrderType, PaginationMode, FindOptions, FilterOption, OrderOption, ColumnOption, Pagination, QueryToken } from '../../../../Framework/Signum.React/Scripts/FindOptions'
import { SearchControl, ValueSearchControl } from '../../../../Framework/Signum.React/Scripts/Search'
import { getQueryNiceName, TypeInfo, MemberInfo, getTypeInfo, EntityData, EntityKind, getTypeInfos, KindOfType, PropertyRoute, PropertyRouteType, LambdaMemberType, isTypeEntity } from '../../../../Framework/Signum.React/Scripts/Reflection'
import * as Navigator from '../../../../Framework/Signum.React/Scripts/Navigator'
import { TypeContext, FormGroupStyle, FormGroupSize, StyleOptions, BsColumns } from '../../../../Framework/Signum.React/Scripts/TypeContext'
import { EntityBase, EntityBaseProps } from '../../../../Framework/Signum.React/Scripts/Lines/EntityBase'
import { EntityTableColumn } from '../../../../Framework/Signum.React/Scripts/Lines/EntityTable'
import { DynamicViewValidationMessage } from '../Signum.Entities.Dynamic'
import { ExpressionOrValueComponent, FieldComponent } from './Designer'
import { ExpressionOrValue } from './NodeUtils'
import * as NodeUtils from './NodeUtils'

export interface StyleOptionsExpression {
    formGroupStyle?: ExpressionOrValue<FormGroupStyle>;
    formGroupSize?: ExpressionOrValue<FormGroupSize>;
    placeholderLabels?: ExpressionOrValue<boolean>;
    formControlClassReadonly?: ExpressionOrValue<string>;
    labelColumns?: ExpressionOrValue<number>;
    valueColumns?: ExpressionOrValue<number>;
    readOnly?: ExpressionOrValue<boolean>;
}

export const formGroupSize: FormGroupSize[] = ["Normal", "Small", "ExtraSmall"];
export const formGroupStyle: FormGroupStyle[] = ["None", "Basic", "BasicDown", "SrOnly", "LabelColumns"];

export function subCtx(ctx: TypeContext<ModifiableEntity>, field: string | undefined, soe: StyleOptionsExpression | undefined) {

    if (field == undefined && soe == undefined)
            return ctx;

    if (field == undefined)
        return ctx.subCtx(toStyleOptions(ctx, soe)!);

    return ctx.subCtx(NodeUtils.asFieldFunction(field), toStyleOptions(ctx, soe));
}

export function toStyleOptions(ctx: TypeContext<ModifiableEntity>, soe: StyleOptionsExpression | undefined): StyleOptions | undefined {

    if (soe == undefined)
        return undefined;
    
    return {
        formGroupStyle: NodeUtils.evaluateAndValidate(ctx, soe, s => s.formGroupStyle, val => NodeUtils.isInListOrNull(val, formGroupStyle)),
        formGroupSize: NodeUtils.evaluateAndValidate(ctx, soe, s => s.formGroupSize, val => NodeUtils.isInListOrNull(val, formGroupSize)),
        placeholderLabels: NodeUtils.evaluateAndValidate(ctx, soe, s => s.placeholderLabels, NodeUtils.isBooleanOrNull),
        formControlClassReadonly: NodeUtils.evaluateAndValidate(ctx, soe, s => s.formControlClassReadonly, NodeUtils.isStringOrNull),
        labelColumns: NodeUtils.evaluateAndValidate(ctx, soe, s => s.labelColumns, NodeUtils.isNumberOrNull),
        valueColumns: NodeUtils.evaluateAndValidate(ctx, soe, s => s.valueColumns, NodeUtils.isNumberOrNull),
        readOnly: NodeUtils.evaluateAndValidate(ctx, soe, s => s.readOnly, NodeUtils.isBooleanOrNull),
    };
}
