//////////////////////////////////
//Auto-generated. Do NOT modify!//
//////////////////////////////////
import { MessageKey, QueryKey, Type, EnumType, registerSymbol } from '../../../Framework/Signum.React/Scripts/Reflection' 

import * as Entities from '../../../Framework/Signum.React/Scripts/Signum.Entities' 

import * as Basics from '../Basics/Signum.Entities.Basics' 

import * as Authorization from '../Authorization/Signum.Entities.Authorization' 

export enum TranslatedCultureAction {
    Translate = "Translate" as any,
    Read = "Read" as any,
}
export const TranslatedCultureAction_Type = new EnumType<TranslatedCultureAction>("TranslatedCultureAction", TranslatedCultureAction);

export const TranslatedInstanceEntity_Type = new Type<TranslatedInstanceEntity>("TranslatedInstance");
export interface TranslatedInstanceEntity extends Entities.Entity {
    culture?: Basics.CultureInfoEntity;
    instance?: Entities.Lite<Entities.Entity>;
    propertyRoute?: Entities.Basics.PropertyRouteEntity;
    rowId?: string;
    translatedText?: string;
    originalText?: string;
}

export module TranslationJavascriptMessage {
    export const WrongTranslationToSubstitute = new MessageKey("TranslationJavascriptMessage", "WrongTranslationToSubstitute");
    export const RightTranslation = new MessageKey("TranslationJavascriptMessage", "RightTranslation");
    export const RememberChange = new MessageKey("TranslationJavascriptMessage", "RememberChange");
}

export module TranslationMessage {
    export const RepeatedCultures0 = new MessageKey("TranslationMessage", "RepeatedCultures0");
    export const CodeTranslations = new MessageKey("TranslationMessage", "CodeTranslations");
    export const InstanceTranslations = new MessageKey("TranslationMessage", "InstanceTranslations");
    export const Synchronize0In1 = new MessageKey("TranslationMessage", "Synchronize0In1");
    export const View0In1 = new MessageKey("TranslationMessage", "View0In1");
    export const AllLanguages = new MessageKey("TranslationMessage", "AllLanguages");
    export const _0AlreadySynchronized = new MessageKey("TranslationMessage", "_0AlreadySynchronized");
    export const NothingToTranslate = new MessageKey("TranslationMessage", "NothingToTranslate");
    export const All = new MessageKey("TranslationMessage", "All");
    export const NothingToTranslateIn0 = new MessageKey("TranslationMessage", "NothingToTranslateIn0");
    export const Sync = new MessageKey("TranslationMessage", "Sync");
    export const View = new MessageKey("TranslationMessage", "View");
    export const None = new MessageKey("TranslationMessage", "None");
    export const Edit = new MessageKey("TranslationMessage", "Edit");
    export const Member = new MessageKey("TranslationMessage", "Member");
    export const Type = new MessageKey("TranslationMessage", "Type");
    export const Instance = new MessageKey("TranslationMessage", "Instance");
    export const Property = new MessageKey("TranslationMessage", "Property");
    export const Save = new MessageKey("TranslationMessage", "Save");
    export const Search = new MessageKey("TranslationMessage", "Search");
    export const PressSearchForResults = new MessageKey("TranslationMessage", "PressSearchForResults");
    export const NoResultsFound = new MessageKey("TranslationMessage", "NoResultsFound");
}

export module TranslationPermission {
    export const TranslateCode : Authorization.PermissionSymbol = registerSymbol({ Type: "Permission", key: "TranslationPermission.TranslateCode" });
    export const TranslateInstances : Authorization.PermissionSymbol = registerSymbol({ Type: "Permission", key: "TranslationPermission.TranslateInstances" });
}

export const TranslationReplacementEntity_Type = new Type<TranslationReplacementEntity>("TranslationReplacement");
export interface TranslationReplacementEntity extends Entities.Entity {
    cultureInfo?: Basics.CultureInfoEntity;
    wrongTranslation?: string;
    rightTranslation?: string;
}

export module TranslationReplacementOperation {
    export const Save : Entities.ExecuteSymbol<TranslationReplacementEntity> = registerSymbol({ Type: "Operation", key: "TranslationReplacementOperation.Save" });
    export const Delete : Entities.DeleteSymbol<TranslationReplacementEntity> = registerSymbol({ Type: "Operation", key: "TranslationReplacementOperation.Delete" });
}

export const TranslatorUserCultureEntity_Type = new Type<TranslatorUserCultureEntity>("TranslatorUserCultureEntity");
export interface TranslatorUserCultureEntity extends Entities.EmbeddedEntity {
    culture?: Basics.CultureInfoEntity;
    action?: TranslatedCultureAction;
}

export const TranslatorUserEntity_Type = new Type<TranslatorUserEntity>("TranslatorUser");
export interface TranslatorUserEntity extends Entities.Entity {
    user?: Entities.Lite<Entities.Basics.IUserEntity>;
    cultures?: Entities.MList<TranslatorUserCultureEntity>;
}

export module TranslatorUserOperation {
    export const Save : Entities.ExecuteSymbol<TranslatorUserEntity> = registerSymbol({ Type: "Operation", key: "TranslatorUserOperation.Save" });
    export const Delete : Entities.DeleteSymbol<TranslatorUserEntity> = registerSymbol({ Type: "Operation", key: "TranslatorUserOperation.Delete" });
}

