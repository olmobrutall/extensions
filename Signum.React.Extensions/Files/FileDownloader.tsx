﻿import * as React from 'react'
import { Link } from 'react-router'
import { classes, Dic } from '../../../Framework/Signum.React/Scripts/Globals'
import * as Services from '../../../Framework/Signum.React/Scripts/Services'
import * as Navigator from '../../../Framework/Signum.React/Scripts/Navigator'
import * as Constructor from '../../../Framework/Signum.React/Scripts/Constructor'
import * as Finder from '../../../Framework/Signum.React/Scripts/Finder'
import { FindOptions } from '../../../Framework/Signum.React/Scripts/FindOptions'
import { TypeContext, StyleContext, StyleOptions, FormGroupStyle } from '../../../Framework/Signum.React/Scripts/TypeContext'
import { PropertyRoute, PropertyRouteType, MemberInfo, getTypeInfo, getTypeInfos, TypeInfo, IsByAll, basicConstruct, getTypeName } from '../../../Framework/Signum.React/Scripts/Reflection'
import { LineBase, LineBaseProps, FormGroup, FormControlStatic, runTasks } from '../../../Framework/Signum.React/Scripts/Lines/LineBase'
import { ModifiableEntity, Lite, Entity, EntityControlMessage, JavascriptMessage, toLite, is, liteKey, getToString } from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import { IFile, IFilePath, FileMessage, FileTypeSymbol, FileEntity, FilePathEntity, EmbeddedFileEntity, EmbeddedFilePathEntity } from './Signum.Entities.Files'
import Typeahead from '../../../Framework/Signum.React/Scripts/Lines/Typeahead'
import { EntityBase, EntityBaseProps} from '../../../Framework/Signum.React/Scripts/Lines/EntityBase'

require("./Files.css");


export type DownloadBehaviour = "SaveAs" | "View" | "None";

export interface FileDownloaderProps {
    entityOrLite: ModifiableEntity & IFile | Lite<IFile & Entity>;
    download?: DownloadBehaviour;
    configuration?: FileDownloaderConfiguration<IFile>;
    htmlProps: React.HTMLAttributes<HTMLSpanElement | HTMLAnchorElement>
}

export default class FileDownloader extends React.Component<FileDownloaderProps, void> {

    static configurtions: { [typeName: string]: FileDownloaderConfiguration<IFile> } = {};


    static defaultProps = {
        download: "SaveAs",
    }

    componentWillMount() {
        const entityOrLite = this.props.entityOrLite;
        if (entityOrLite && (entityOrLite as Lite<IFile & Entity>).EntityType)
            Navigator.API.fetchAndRemember(entityOrLite as Lite<IFile & Entity>)
                .then(() => this.forceUpdate())
                .done();
    }

   

    render() {

        const entityOrLite = this.props.entityOrLite;

        const entity = (entityOrLite as Lite<IFile & Entity>).EntityType ?
            (entityOrLite as Lite<IFile & Entity>).entity :
            (entityOrLite as IFile & Entity);

        if (!entity)
            return <span {...this.props.htmlProps}>{JavascriptMessage.loading.niceToString()}</span>;


        const configuration = this.props.configuration || FileDownloader.configurtions[entity.Type];
        if (!configuration)
            throw new Error("No configuration registered in FileDownloader.configurations for "); 

        return (
            <a
                href=""
                onClick={e => entity.binaryFile ? downloadBase64(e, entity.binaryFile, entity.fileName!) : configuration.downloadClick(e, entity)}
                download={this.props.download == "View" ? undefined : entity.fileName }
                title={entity.fileName || undefined}
                target="_blank"
                {...this.props.htmlProps}>
                {entity.fileName}
            </a>
        );

    }
}


export interface FileDownloaderConfiguration<T extends IFile> {
    downloadClick: (event: React.MouseEvent<any>, file: T) => void;
}

FileDownloader.configurtions[FileEntity.typeName] = {
    downloadClick: (event, file) => downloadUrl(event, Navigator.currentHistory.createHref("~/api/files/downloadFile/" + file.id.toString()))
} as FileDownloaderConfiguration<FileEntity>;

FileDownloader.configurtions[FilePathEntity.typeName] = {
    downloadClick: (event, file) => downloadUrl(event, Navigator.currentHistory.createHref("~/api/files/downloadFilePath/" + file.id.toString()))
} as FileDownloaderConfiguration<FilePathEntity>;

FileDownloader.configurtions[EmbeddedFileEntity.typeName] = {
    downloadClick: (event, file) => downloadBase64(event, file.binaryFile!, file.fileName!)
} as FileDownloaderConfiguration<EmbeddedFileEntity>;

FileDownloader.configurtions[EmbeddedFilePathEntity.typeName] = {
    downloadClick: (event, file) => downloadUrl(event,
        Navigator.currentHistory.createHref({
            pathname: "~/api/files/downloadEmbeddedFilePath/" + file.fileType!.key,
            query: { suffix: file.suffix, fileName: file.fileName }
        }))
} as FileDownloaderConfiguration<EmbeddedFilePathEntity>;


function downloadUrl(e: React.MouseEvent<any>, url: string) {
    
    e.preventDefault();
    Services.ajaxGetRaw({ url: url })
        .then(resp => Services.saveFile(resp))
        .done();
};

function downloadBase64(e: React.MouseEvent<any>, binaryFile: string, fileName: string) {
    e.preventDefault();

    var blob = Services.b64toBlob(binaryFile);

    Services.saveFileBlob(blob, fileName);
};

