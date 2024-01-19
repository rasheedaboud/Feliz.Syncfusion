import { DialogComponent as DialogComponent_1 } from "@syncfusion/ej2-react-popups";
import { Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { int32_type, lambda_type, unit_type, array_type, class_type, obj_type, bool_type, record_type, float64_type, option_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";

export const DialogComponent = DialogComponent_1;

export class AnimationSettingsModel extends Record {
    "constructor"(effect, duration, delay) {
        super();
        this.effect = effect;
        this.duration = duration;
        this.delay = delay;
    }
}

export function AnimationSettingsModel$reflection() {
    return record_type("Syncfusion.SfModal.AnimationSettingsModel", [], AnimationSettingsModel, () => [["effect", option_type(string_type)], ["duration", option_type(float64_type)], ["delay", option_type(float64_type)]]);
}

export class ButtonModel extends Record {
    "constructor"(iconPosition, iconCss, disabled, isPrimary, cssClass, content, isToggle) {
        super();
        this.iconPosition = iconPosition;
        this.iconCss = iconCss;
        this.disabled = disabled;
        this.isPrimary = isPrimary;
        this.cssClass = cssClass;
        this.content = content;
        this.isToggle = isToggle;
    }
}

export function ButtonModel$reflection() {
    return record_type("Syncfusion.SfModal.ButtonModel", [], ButtonModel, () => [["iconPosition", string_type], ["iconCss", string_type], ["disabled", bool_type], ["isPrimary", bool_type], ["cssClass", string_type], ["content", string_type], ["isToggle", bool_type]]);
}

export class ButtonPropsModel extends Record {
    "constructor"(isFlat, buttonModel, type, click) {
        super();
        this.isFlat = isFlat;
        this.buttonModel = buttonModel;
        this.type = type;
        this.click = click;
    }
}

export function ButtonPropsModel$reflection() {
    return record_type("Syncfusion.SfModal.ButtonPropsModel", [], ButtonPropsModel, () => [["isFlat", bool_type], ["buttonModel", ButtonModel$reflection()], ["type", string_type], ["click", obj_type]]);
}

export class ComponentModel extends Record {
    "constructor"(content, showCloseIcon, isModal, header, visible, enableResize, height, minHeight, width, cssClass, target, footerTemplate, allowDragging, buttons, closeOnEscape, animationSettings) {
        super();
        this.content = content;
        this.showCloseIcon = showCloseIcon;
        this.isModal = isModal;
        this.header = header;
        this.visible = visible;
        this.enableResize = enableResize;
        this.height = height;
        this.minHeight = minHeight;
        this.width = width;
        this.cssClass = cssClass;
        this.target = target;
        this.footerTemplate = footerTemplate;
        this.allowDragging = allowDragging;
        this.buttons = buttons;
        this.closeOnEscape = closeOnEscape;
        this.animationSettings = animationSettings;
    }
}

export function ComponentModel$reflection() {
    return record_type("Syncfusion.SfModal.ComponentModel", [], ComponentModel, () => [["content", option_type(class_type("Fable.React.ReactElement"))], ["showCloseIcon", bool_type], ["isModal", bool_type], ["header", option_type(class_type("Fable.React.ReactElement"))], ["visible", bool_type], ["enableResize", bool_type], ["height", class_type("Feliz.Styles.ICssUnit")], ["minHeight", class_type("Feliz.Styles.ICssUnit")], ["width", class_type("Feliz.Styles.ICssUnit")], ["cssClass", string_type], ["target", class_type("Browser.Types.HTMLElement")], ["footerTemplate", option_type(class_type("Browser.Types.HTMLElement"))], ["allowDragging", bool_type], ["buttons", array_type(ButtonPropsModel$reflection())], ["closeOnEscape", bool_type], ["animationSettings", AnimationSettingsModel$reflection()]]);
}

export class ButtonArgs extends Record {
    "constructor"(click) {
        super();
        this.click = click;
    }
}

export function ButtonArgs$reflection() {
    return record_type("Syncfusion.SfModal.ButtonArgs", [], ButtonArgs, () => [["click", option_type(lambda_type(class_type("Browser.Types.Event"), unit_type))]]);
}

export function ButtonArgs_Default_7DDE0344(callback) {
    return new ButtonArgs(callback);
}

export class PositionDataModel extends Record {
    "constructor"(X, Y) {
        super();
        this.X = X;
        this.Y = Y;
    }
}

export function PositionDataModel$reflection() {
    return record_type("Syncfusion.SfModal.PositionDataModel", [], PositionDataModel, () => [["X", obj_type], ["Y", obj_type]]);
}

export class AlertDialogArgs extends Record {
    "constructor"(title, content, isModal, isDraggable, showCloseIcon, closeOnEscape, okButton, position, animationSettings, cssClass, zIndex, open, close) {
        super();
        this.title = title;
        this.content = content;
        this.isModal = isModal;
        this.isDraggable = isDraggable;
        this.showCloseIcon = showCloseIcon;
        this.closeOnEscape = closeOnEscape;
        this.okButton = okButton;
        this.position = position;
        this.animationSettings = animationSettings;
        this.cssClass = cssClass;
        this.zIndex = (zIndex | 0);
        this.open = open;
        this.close = close;
    }
}

export function AlertDialogArgs$reflection() {
    return record_type("Syncfusion.SfModal.AlertDialogArgs", [], AlertDialogArgs, () => [["title", option_type(string_type)], ["content", obj_type], ["isModal", bool_type], ["isDraggable", bool_type], ["showCloseIcon", bool_type], ["closeOnEscape", bool_type], ["okButton", ButtonArgs$reflection()], ["position", PositionDataModel$reflection()], ["animationSettings", AnimationSettingsModel$reflection()], ["cssClass", string_type], ["zIndex", int32_type], ["open", option_type(lambda_type(class_type("Browser.Types.Event"), unit_type))], ["close", option_type(lambda_type(class_type("Browser.Types.Event"), unit_type))]]);
}

export function AlertDialogArgs_Default_Z26232F5B(title, content, ok) {
    return new AlertDialogArgs(title, content, true, true, false, false, ok, new PositionDataModel(0, 100), new AnimationSettingsModel("Fade", 1, 1), "", 1000, void 0, void 0);
}

export class ConfirmDialogArgs extends Record {
    "constructor"(title, content, isModal, isDraggable, showCloseIcon, closeOnEscape, okButton, cancelButton, position, animationSettings, cssClass, zIndex, open, close) {
        super();
        this.title = title;
        this.content = content;
        this.isModal = isModal;
        this.isDraggable = isDraggable;
        this.showCloseIcon = showCloseIcon;
        this.closeOnEscape = closeOnEscape;
        this.okButton = okButton;
        this.cancelButton = cancelButton;
        this.position = position;
        this.animationSettings = animationSettings;
        this.cssClass = cssClass;
        this.zIndex = (zIndex | 0);
        this.open = open;
        this.close = close;
    }
}

export function ConfirmDialogArgs$reflection() {
    return record_type("Syncfusion.SfModal.ConfirmDialogArgs", [], ConfirmDialogArgs, () => [["title", option_type(string_type)], ["content", obj_type], ["isModal", bool_type], ["isDraggable", bool_type], ["showCloseIcon", bool_type], ["closeOnEscape", bool_type], ["okButton", ButtonArgs$reflection()], ["cancelButton", ButtonArgs$reflection()], ["position", PositionDataModel$reflection()], ["animationSettings", AnimationSettingsModel$reflection()], ["cssClass", string_type], ["zIndex", int32_type], ["open", option_type(lambda_type(obj_type, unit_type))], ["close", option_type(lambda_type(obj_type, unit_type))]]);
}

export function ConfirmDialogArgs_Default_716A4640(title, content, ok, cancel) {
    return new ConfirmDialogArgs(title, content, true, true, false, false, ok, cancel, new PositionDataModel(0, 100), new AnimationSettingsModel("Fade", 1, 1), "", 1000, void 0, void 0);
}

