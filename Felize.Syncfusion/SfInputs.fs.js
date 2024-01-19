import { TextBoxComponent, NumericTextBoxComponent, UploaderComponent } from "@syncfusion/ej2-react-inputs";
import { Union, Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { obj_type, array_type, bool_type, union_type, int32_type, class_type, record_type, option_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";
import { DatePickerComponent } from "@syncfusion/ej2-react-calendars";
import { AutoCompleteComponent } from "@syncfusion/ej2-react-dropdowns";
import { ProgressButtonComponent } from "@syncfusion/ej2-react-splitbuttons";
import { some } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Option.js";
import { ChipListComponent, CheckBoxComponent } from "@syncfusion/ej2-react-buttons";

export const SfFileUploader_uploader = UploaderComponent;

export class SfFileUploader_ValidationMessages extends Record {
    "constructor"(minSize, maxSize) {
        super();
        this.minSize = minSize;
        this.maxSize = maxSize;
    }
}

export function SfFileUploader_ValidationMessages$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.ValidationMessages", [], SfFileUploader_ValidationMessages, () => [["minSize", option_type(string_type)], ["maxSize", option_type(string_type)]]);
}

export class SfFileUploader_FileInfo extends Record {
    "constructor"(name, rawFile, size, status, type, validationMessages, statusCode, fileSource, list, input, id) {
        super();
        this.name = name;
        this.rawFile = rawFile;
        this.size = (size | 0);
        this.status = status;
        this.type = type;
        this.validationMessages = validationMessages;
        this.statusCode = statusCode;
        this.fileSource = fileSource;
        this.list = list;
        this.input = input;
        this.id = id;
    }
}

export function SfFileUploader_FileInfo$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.FileInfo", [], SfFileUploader_FileInfo, () => [["name", string_type], ["rawFile", class_type("Browser.Types.Blob")], ["size", int32_type], ["status", string_type], ["type", string_type], ["validationMessages", SfFileUploader_ValidationMessages$reflection()], ["statusCode", string_type], ["fileSource", option_type(string_type)], ["list", option_type(class_type("Browser.Types.HTMLElement"))], ["input", option_type(class_type("Browser.Types.HTMLInputElement"))], ["id", option_type(string_type)]]);
}

export class SfFileUploader_Events extends Union {
    "constructor"(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["MouseEvent", "TouchEvent", "DragEvent", "ClipboardEvent"];
    }
}

export function SfFileUploader_Events$reflection() {
    return union_type("Syncfusion.SfInputs.SfFileUploader.Events", [], SfFileUploader_Events, () => [[], [], [], []]);
}

export class SfFileUploader_SelectedEventArgs extends Record {
    "constructor"(event, cancel, filesData, isModified, modifiedFilesData, progressInterval, isCanceled, currentRequest, customFormData) {
        super();
        this.event = event;
        this.cancel = cancel;
        this.filesData = filesData;
        this.isModified = isModified;
        this.modifiedFilesData = modifiedFilesData;
        this.progressInterval = progressInterval;
        this.isCanceled = isCanceled;
        this.currentRequest = currentRequest;
        this.customFormData = customFormData;
    }
}

export function SfFileUploader_SelectedEventArgs$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.SelectedEventArgs", [], SfFileUploader_SelectedEventArgs, () => [["event", SfFileUploader_Events$reflection()], ["cancel", bool_type], ["filesData", array_type(SfFileUploader_FileInfo$reflection())], ["isModified", bool_type], ["modifiedFilesData", array_type(SfFileUploader_FileInfo$reflection())], ["progressInterval", string_type], ["isCanceled", option_type(bool_type)], ["currentRequest", option_type(class_type("System.Collections.Generic.Dictionary`2", [string_type, string_type]))], ["customFormData", option_type(class_type("System.Collections.Generic.Dictionary`2", [string_type, obj_type]))]]);
}

export class SfFileUploader_FilesProp extends Record {
    "constructor"(name, size, type) {
        super();
        this.name = name;
        this.size = (size | 0);
        this.type = type;
    }
}

export function SfFileUploader_FilesProp$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.FilesProp", [], SfFileUploader_FilesProp, () => [["name", string_type], ["size", int32_type], ["type", string_type]]);
}

export class SfFileUploader_Buttons extends Record {
    "constructor"(browse, clear, upload) {
        super();
        this.browse = browse;
        this.clear = clear;
        this.upload = upload;
    }
}

export function SfFileUploader_Buttons$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.Buttons", [], SfFileUploader_Buttons, () => [["browse", option_type(string_type)], ["clear", option_type(string_type)], ["upload", option_type(string_type)]]);
}

export function SfFileUploader_Buttons_Default() {
    return new SfFileUploader_Buttons("", "", "");
}

export class SfFileUploader_AsyncSettings extends Record {
    "constructor"(saveUrl, removeUrl, chunkSize, retryCount, retryAfterDelay) {
        super();
        this.saveUrl = saveUrl;
        this.removeUrl = removeUrl;
        this.chunkSize = (chunkSize | 0);
        this.retryCount = (retryCount | 0);
        this.retryAfterDelay = (retryAfterDelay | 0);
    }
}

export function SfFileUploader_AsyncSettings$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.AsyncSettings", [], SfFileUploader_AsyncSettings, () => [["saveUrl", string_type], ["removeUrl", string_type], ["chunkSize", int32_type], ["retryCount", int32_type], ["retryAfterDelay", int32_type]]);
}

export class SfFileUploader_MetaData extends Record {
    "constructor"(chunkIndex, blob, file, start, end, retryCount) {
        super();
        this.chunkIndex = (chunkIndex | 0);
        this.blob = blob;
        this.file = file;
        this.start = (start | 0);
        this.end = (end | 0);
        this.retryCount = (retryCount | 0);
    }
}

export function SfFileUploader_MetaData$reflection() {
    return record_type("Syncfusion.SfInputs.SfFileUploader.MetaData", [], SfFileUploader_MetaData, () => [["chunkIndex", int32_type], ["blob", string_type], ["file", SfFileUploader_FileInfo$reflection()], ["start", int32_type], ["end", int32_type], ["retryCount", int32_type]]);
}

export const SfDatePicker_datePickerComponent = DatePickerComponent;

export class SfDatePicker_changedArgs$1 extends Record {
    "constructor"(value) {
        super();
        this.value = value;
    }
}

export function SfDatePicker_changedArgs$1$reflection(gen0) {
    return record_type("Syncfusion.SfInputs.SfDatePicker.changedArgs`1", [gen0], SfDatePicker_changedArgs$1, () => [["value", gen0]]);
}

export class SfDatePicker_BlurEventModelBase$1 extends Record {
    "constructor"(changedArgs) {
        super();
        this.changedArgs = changedArgs;
    }
}

export function SfDatePicker_BlurEventModelBase$1$reflection(gen0) {
    return record_type("Syncfusion.SfInputs.SfDatePicker.BlurEventModelBase`1", [gen0], SfDatePicker_BlurEventModelBase$1, () => [["changedArgs", SfDatePicker_changedArgs$1$reflection(gen0)]]);
}

export const SfAutoComplete_autoComplete = AutoCompleteComponent;

export class SfAutoComplete_FieldSettingsModel extends Record {
    "constructor"(text, value) {
        super();
        this.text = text;
        this.value = value;
    }
}

export function SfAutoComplete_FieldSettingsModel$reflection() {
    return record_type("Syncfusion.SfInputs.SfAutoComplete.FieldSettingsModel", [], SfAutoComplete_FieldSettingsModel, () => [["text", string_type], ["value", string_type]]);
}

export class SfAutoComplete_SfAutoComplete {
    "constructor"() {
    }
}

export function SfAutoComplete_SfAutoComplete$reflection() {
    return class_type("Syncfusion.SfInputs.SfAutoComplete.SfAutoComplete", void 0, SfAutoComplete_SfAutoComplete);
}

export const SfNumericTextBox_numericTextBoxComponent = NumericTextBoxComponent;

export class SfNumericTextBox_ChangeEventArgs$1 extends Record {
    "constructor"(value) {
        super();
        this.value = value;
    }
}

export function SfNumericTextBox_ChangeEventArgs$1$reflection(gen0) {
    return record_type("Syncfusion.SfInputs.SfNumericTextBox.ChangeEventArgs`1", [gen0], SfNumericTextBox_ChangeEventArgs$1, () => [["value", gen0]]);
}

export class SfNumericTextBox_SfNumericTextBox {
    "constructor"() {
    }
}

export function SfNumericTextBox_SfNumericTextBox$reflection() {
    return class_type("Syncfusion.SfInputs.SfNumericTextBox.SfNumericTextBox", void 0, SfNumericTextBox_SfNumericTextBox);
}

export const ProgressButton_progressButtonComponent = ProgressButtonComponent;

export class ProgressButton_AnimationSettingsModel extends Record {
    "constructor"(duration, easing, effect) {
        super();
        this.duration = (duration | 0);
        this.easing = easing;
        this.effect = effect;
    }
}

export function ProgressButton_AnimationSettingsModel$reflection() {
    return record_type("Syncfusion.SfInputs.ProgressButton.AnimationSettingsModel", [], ProgressButton_AnimationSettingsModel, () => [["duration", int32_type], ["easing", string_type], ["effect", string_type]]);
}

export class ProgressButton_SpinSettingsModel extends Record {
    "constructor"(width, position) {
        super();
        this.width = width;
        this.position = position;
    }
}

export function ProgressButton_SpinSettingsModel$reflection() {
    return record_type("Syncfusion.SfInputs.ProgressButton.SpinSettingsModel", [], ProgressButton_SpinSettingsModel, () => [["width", option_type(obj_type)], ["position", string_type]]);
}

export function ProgressButton_SpinSettingsModel_get_Default() {
    return new ProgressButton_SpinSettingsModel(some(16), "Left");
}

export const SfTextBox_textBox = TextBoxComponent;

export class SfTextBox_ChangedEventArgs extends Record {
    "constructor"(value) {
        super();
        this.value = value;
    }
}

export function SfTextBox_ChangedEventArgs$reflection() {
    return record_type("Syncfusion.SfInputs.SfTextBox.ChangedEventArgs", [], SfTextBox_ChangedEventArgs, () => [["value", string_type]]);
}

export class SfTextBox_FocusOutEventArgs extends Record {
    "constructor"(value) {
        super();
        this.value = value;
    }
}

export function SfTextBox_FocusOutEventArgs$reflection() {
    return record_type("Syncfusion.SfInputs.SfTextBox.FocusOutEventArgs", [], SfTextBox_FocusOutEventArgs, () => [["value", string_type]]);
}

export const SfCheckBox_checkBox = CheckBoxComponent;

export const SfChip_chip = ChipListComponent;

export class SfChip_ChipModel extends Record {
    "constructor"(text, value, avatarText, avatarIconCss, leadingIconCss, trailingIconCss, cssClass, enabled, leadingIconUrl, trailingIconUrl) {
        super();
        this.text = text;
        this.value = value;
        this.avatarText = avatarText;
        this.avatarIconCss = avatarIconCss;
        this.leadingIconCss = leadingIconCss;
        this.trailingIconCss = trailingIconCss;
        this.cssClass = cssClass;
        this.enabled = enabled;
        this.leadingIconUrl = leadingIconUrl;
        this.trailingIconUrl = trailingIconUrl;
    }
}

export function SfChip_ChipModel$reflection() {
    return record_type("Syncfusion.SfInputs.SfChip.ChipModel", [], SfChip_ChipModel, () => [["text", option_type(string_type)], ["value", option_type(obj_type)], ["avatarText", option_type(string_type)], ["avatarIconCss", option_type(string_type)], ["leadingIconCss", option_type(string_type)], ["trailingIconCss", option_type(string_type)], ["cssClass", option_type(string_type)], ["enabled", option_type(bool_type)], ["leadingIconUrl", option_type(string_type)], ["trailingIconUrl", option_type(string_type)]]);
}

export class SfChip_SfChip {
    "constructor"() {
    }
}

export function SfChip_SfChip$reflection() {
    return class_type("Syncfusion.SfInputs.SfChip.SfChip", void 0, SfChip_SfChip);
}

