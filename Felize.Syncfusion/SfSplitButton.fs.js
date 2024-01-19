import { SplitButtonComponent } from "@syncfusion/ej2-react-splitbuttons";
import { Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { class_type, record_type, bool_type, option_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";

export const sfSplitButton = SplitButtonComponent;

export class ItemModel extends Record {
    "constructor"(iconCss, id, separator, text, url, disabled) {
        super();
        this.iconCss = iconCss;
        this.id = id;
        this.separator = separator;
        this.text = text;
        this.url = url;
        this.disabled = disabled;
    }
}

export function ItemModel$reflection() {
    return record_type("Syncfusion.SfSplitButton.ItemModel", [], ItemModel, () => [["iconCss", option_type(string_type)], ["id", option_type(string_type)], ["separator", option_type(bool_type)], ["text", option_type(string_type)], ["url", option_type(string_type)], ["disabled", option_type(bool_type)]]);
}

export class SfSplitButton {
    "constructor"() {
    }
}

export function SfSplitButton$reflection() {
    return class_type("Syncfusion.SfSplitButton.SfSplitButton", void 0, SfSplitButton);
}

