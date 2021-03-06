﻿import * as React from 'react'
import { Route } from 'react-router'
import { Dic, classes } from '../../../Framework/Signum.React/Scripts/Globals';
import { Button, OverlayTrigger, Tooltip, MenuItem } from "react-bootstrap"
import { ajaxPost, ajaxPostRaw, ajaxGet, saveFile } from '../../../Framework/Signum.React/Scripts/Services';
import { EntitySettings, ViewPromise } from '../../../Framework/Signum.React/Scripts/Navigator'
import * as Navigator from '../../../Framework/Signum.React/Scripts/Navigator'
import * as Finder from '../../../Framework/Signum.React/Scripts/Finder'
import { QueryRequest } from '../../../Framework/Signum.React/Scripts/FindOptions'
import { Lite, Entity, EntityPack, ExecuteSymbol, DeleteSymbol, ConstructSymbol_From, registerToString, JavascriptMessage, toLite } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import { EntityOperationSettings } from '../../../Framework/Signum.React/Scripts/Operations'
import { PseudoType, QueryKey, GraphExplorer, OperationType, Type, getTypeName  } from '../../../Framework/Signum.React/Scripts/Reflection'
import * as Operations from '../../../Framework/Signum.React/Scripts/Operations'
import * as ContextualOperations from '../../../Framework/Signum.React/Scripts/Operations/ContextualOperations'
import { ExcelReportEntity, ExcelMessage } from './Signum.Entities.Excel'
import * as OmniboxClient from '../Omnibox/OmniboxClient'
import * as AuthClient from '../Authorization/AuthClient'
import * as ChartClient from '../Chart/ChartClient'
import { ChartPermission } from '../Chart/Signum.Entities.Chart'
import * as QuickLinks from '../../../Framework/Signum.React/Scripts/QuickLinks'
import { ChartRequest  } from '../../../Extensions/Signum.React.Extensions/Chart/Signum.Entities.Chart'
import ExcelMenu from './ExcelMenu'

export function start(options: { routes: JSX.Element[], plainExcel: boolean, excelReport: boolean }) {
    
    if (options.excelReport) {
        Navigator.addSettings(new EntitySettings(ExcelReportEntity, e => new ViewPromise(resolve => require(['./Templates/ExcelReport'], resolve))));
    }

    Finder.ButtonBarQuery.onButtonBarElements.push(ctx => {

        if (!ctx.searchControl.props.showBarExtension)
            return undefined;

        return <ExcelMenu searchControl={ctx.searchControl} plainExcel={options.plainExcel} excelReport={options.excelReport} />;
    }); 

    if (options.plainExcel) {
        ChartClient.ButtonBarChart.onButtonBarElements.push(ctx => {
            if (!AuthClient.isPermissionAuthorized(ChartPermission.ViewCharting))
                return undefined;

            return (
                <button
                    className="sf-query-button sf-chart-script-edit btn btn-default"
                    onClick={() => { API.generateChartExcel(ChartClient.API.cleanedChartRequest(ctx.chartRequest)); } }>
                    {ExcelMessage.ExcelReport.niceToString()}
                </button>
            );
        });
    }
}

export namespace API {

    export function generatePlanExcel(request: QueryRequest): void {
        ajaxPostRaw({ url: "~/api/excel/plain" }, request)
            .then(response => saveFile(response))
            .done();
    }

    export function forQuery(queryKey: string): Promise<Lite<ExcelReportEntity>[]> {
        return ajaxGet<Lite<ExcelReportEntity>[]>({ url: "~/api/excel/reportsFor/" + queryKey });
    }


    export function generateExcelReport(queryRequest: QueryRequest, excelReport: Lite<ExcelReportEntity>): void{
        ajaxPostRaw({ url: "~/api/excel/excelReport" }, { queryRequest, excelReport })
            .then(response => saveFile(response))
            .done();
    }

    export function generateChartExcel(request: ChartRequest): void {
        ajaxPostRaw({ url: "~/api/excel/plainChart" }, request)
            .then(response => saveFile(response))
            .done();
    }
}