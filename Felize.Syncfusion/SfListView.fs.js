import { ListViewComponent } from "@syncfusion/ej2-react-lists";
import { Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { class_type, record_type, option_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";
import { isNullOrEmpty } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/String.js";

export const listViewComponent = ListViewComponent;

export class FieldSettingsModel extends Record {
    "constructor"(id, text, isChecked, isVisible, enabled, iconCss, child, tooltip, groupBy, sortBy, htmlAttributes, tableName) {
        super();
        this.id = id;
        this.text = text;
        this.isChecked = isChecked;
        this.isVisible = isVisible;
        this.enabled = enabled;
        this.iconCss = iconCss;
        this.child = child;
        this.tooltip = tooltip;
        this.groupBy = groupBy;
        this.sortBy = sortBy;
        this.htmlAttributes = htmlAttributes;
        this.tableName = tableName;
    }
}

export function FieldSettingsModel$reflection() {
    return record_type("Syncfusion.SfListView.FieldSettingsModel", [], FieldSettingsModel, () => [["id", option_type(string_type)], ["text", option_type(string_type)], ["isChecked", option_type(string_type)], ["isVisible", option_type(string_type)], ["enabled", option_type(string_type)], ["iconCss", option_type(string_type)], ["child", option_type(string_type)], ["tooltip", option_type(string_type)], ["groupBy", option_type(string_type)], ["sortBy", option_type(string_type)], ["htmlAttributes", option_type(string_type)], ["tableName", option_type(string_type)]]);
}

export function FieldSettingsModel_create_30230F9B(id, text, child) {
    const idisnull = isNullOrEmpty(id);
    const nameisnull = isNullOrEmpty(text);
    const childisnull = isNullOrEmpty(child);
    const patternInput = idisnull ? (nameisnull ? (childisnull ? [void 0, void 0, void 0] : [void 0, void 0, child]) : (childisnull ? [id, void 0, void 0] : [void 0, text, child])) : (nameisnull ? (childisnull ? [id, void 0, void 0] : [id, void 0, child]) : (childisnull ? [id, text, void 0] : [id, text, child]));
    const text_1 = patternInput[1];
    const id_1 = patternInput[0];
    const child_1 = patternInput[2];
    return new FieldSettingsModel(id_1, text_1, void 0, void 0, void 0, void 0, child_1, void 0, void 0, void 0, void 0, void 0);
}

export class SfListView {
    "constructor"() {
    }
}

export function SfListView$reflection() {
    return class_type("Syncfusion.SfListView.SfListView", void 0, SfListView);
}

