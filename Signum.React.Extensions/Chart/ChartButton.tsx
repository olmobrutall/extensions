﻿
import * as React from 'react'
import { Button, MenuItem, } from 'react-bootstrap'
import { Dic, classes } from '../../../Framework/Signum.React/Scripts/Globals'
import { getQueryKey } from '../../../Framework/Signum.React/Scripts/Reflection'
import * as Finder from '../../../Framework/Signum.React/Scripts/Finder'
import { Lite, toLite } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import { ResultTable, FindOptions, FilterOption, QueryDescription } from '../../../Framework/Signum.React/Scripts/FindOptions'
import { SearchMessage, JavascriptMessage, parseLite, is } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import * as Navigator from '../../../Framework/Signum.React/Scripts/Navigator'
import { default as SearchControlLoaded } from '../../../Framework/Signum.React/Scripts/SearchControl/SearchControlLoaded'
import { ChartMessage, ChartRequest } from './Signum.Entities.Chart'
import * as ChartClient from './ChartClient'

export interface ChartButtonProps {
    searchControl: SearchControlLoaded;
}

export default class ChartButton extends React.Component<ChartButtonProps, void> {

    handleClick = (e: React.MouseEvent<any>) => {

        const fo = this.props.searchControl.props.findOptions;

        const path = ChartClient.Encoder.chartRequestPath(ChartRequest.New({
            queryKey : fo.queryKey,
            orderOptions : [],
            filterOptions : fo.filterOptions
        }));

        if (e.ctrlKey || e.button == 1)
            window.open(path);
        else
            Navigator.currentHistory.push(path);

    }
    
    render() {
        return (
            <Button onClick={this.handleClick}>{ ChartMessage.Chart.niceToString() }</Button>
        );
    }
 
}



