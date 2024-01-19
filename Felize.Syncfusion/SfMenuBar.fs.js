import { MenuComponent } from "@syncfusion/ej2-react-navigations";
import { Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { class_type, array_type, bool_type, float64_type, record_type, option_type, list_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";

export const menuBar = MenuComponent;

export class FieldSettingsModel extends Record {
    "constructor"(itemId, parentId, text, iconCss, url, separator, children) {
        super();
        this.itemId = itemId;
        this.parentId = parentId;
        this.text = text;
        this.iconCss = iconCss;
        this.url = url;
        this.separator = separator;
        this.children = children;
    }
}

export function FieldSettingsModel$reflection() {
    return record_type("Syncfusion.SfMenuBar.FieldSettingsModel", [], FieldSettingsModel, () => [["itemId", option_type(list_type(string_type))], ["parentId", option_type(list_type(string_type))], ["text", option_type(list_type(string_type))], ["iconCss", option_type(list_type(string_type))], ["url", option_type(list_type(string_type))], ["separator", option_type(list_type(string_type))], ["children", option_type(list_type(string_type))]]);
}

export class MenuAnimationSettingsModel extends Record {
    "constructor"(effect, duration, easing) {
        super();
        this.effect = effect;
        this.duration = duration;
        this.easing = easing;
    }
}

export function MenuAnimationSettingsModel$reflection() {
    return record_type("Syncfusion.SfMenuBar.MenuAnimationSettingsModel", [], MenuAnimationSettingsModel, () => [["effect", option_type(string_type)], ["duration", option_type(float64_type)], ["easing", option_type(string_type)]]);
}

export class MenuItem extends Record {
    "constructor"(iconCss, id, separator, items, text, url) {
        super();
        this.iconCss = iconCss;
        this.id = id;
        this.separator = separator;
        this.items = items;
        this.text = text;
        this.url = url;
    }
}

export function MenuItem$reflection() {
    return record_type("Syncfusion.SfMenuBar.MenuItem", [], MenuItem, () => [["iconCss", option_type(string_type)], ["id", option_type(string_type)], ["separator", bool_type], ["items", option_type(array_type(MenuItem$reflection()))], ["text", option_type(string_type)], ["url", option_type(string_type)]]);
}

export class SfMenuBar {
    "constructor"() {
    }
}

export function SfMenuBar$reflection() {
    return class_type("Syncfusion.SfMenuBar.SfMenuBar", void 0, SfMenuBar);
}

