﻿
import * as React from 'react'
import { DropdownButton, MenuItem, } from 'react-bootstrap'
import { Dic, classes } from '../../../Framework/Signum.React/Scripts/Globals'
import * as Finder from '../../../Framework/Signum.React/Scripts/Finder'
import { Lite, toLite } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import { ResultTable, FindOptions, FilterOption, QueryDescription } from '../../../Framework/Signum.React/Scripts/FindOptions'
import { SearchMessage, JavascriptMessage, parseLite, is } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import * as Reflection from '../../../Framework/Signum.React/Scripts/Reflection'
import * as Navigator from '../../../Framework/Signum.React/Scripts/Navigator'
import { default as SearchControl, ExternalFullScreenButton} from '../../../Framework/Signum.React/Scripts/SearchControl/SearchControl'
import { UserQueryEntity_Type, UserQueryEntity, UserQueryMessage  } from './Signum.Entities.UserQueries'
import * as UserQueryClient from './UserQueryClient'

export interface UserQueryMenuProps {
    searchControl: SearchControl;
}

export default class UserQueryMenu extends React.Component<UserQueryMenuProps, { currentUserQuery?: Lite<UserQueryEntity>, userQueries?: Lite<UserQueryEntity>[] }> {

    constructor(props) {
        super(props);
        this.state = { };
    }

    handleSelectedToggle = (isOpen: boolean) => {

        if (isOpen && this.state.userQueries == null)
            this.reloadList().done();
    }

    reloadList(): Promise<void> {
        return UserQueryClient.API.forQuery(this.props.searchControl.props.findOptions.queryName)
            .then(list => this.setState({ userQueries: list }));
    }


    handleSelect = (uq: Lite<UserQueryEntity>) => {

        Navigator.API.fetchAndForget(uq).then(userQuery => {
            var oldFindOptions = this.props.searchControl.props.findOptions;
            var newFindOptions = UserQueryClient.Converter.applyUserQuery(newFindOptions, userQuery, null);
            this.props.searchControl.resetFindOptions(newFindOptions);
        });
    }

    handleEdit = () => {
        Navigator.API.fetchAndForget(this.state.currentUserQuery)
            .then(userQuery => Navigator.navigate(userQuery))
            .then(() => this.reloadList())
            .done();
    }


    handleCreate = () => {

        UserQueryClient.API.fromQueryRequest({
            queryRequest: this.props.searchControl.getQueryRequest(),
            defaultPagination: this.props.searchControl.defaultPagination()
        }).then(userQuery => Navigator.view(userQuery))
            .then(uq => {
                if (uq.id) {
                    this.reloadList()
                        .then(() => this.setState({ currentUserQuery: toLite(uq) }))
                        .done();
                }
            }).done();
    }

    render() {
        const label = UserQueryMessage.UserQueries_UserQueries.niceToString();
        
        return (
            <DropdownButton title={label} label={label}
                onToggle={this.handleSelectedToggle}>
                {
                    this.state.userQueries && this.state.userQueries.map((uq, i) =>
                        <MenuItem
                            className={classes("sf-userquery", is(uq, this.state.currentUserQuery) && "sf-userquery-selected") }
                            onSelect={() => this.handleSelect(uq) }>
                            { uq.toStr }
                        </MenuItem>)
                }
                <MenuItem divider/>
                { this.state.currentUserQuery && <MenuItem onSelect={this.handleEdit} >{UserQueryMessage.UserQueries_Edit.niceToString() }</MenuItem> }
                <MenuItem onSelect={this.handleCreate}>{UserQueryMessage.UserQueries_CreateNew.niceToString() }</MenuItem>
            </DropdownButton>
        );
    }
 
}


