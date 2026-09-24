module ParallelContracts.Inputs

open Feliz

module TextArea = Syncfusion.Typed.TextArea
module MaskedTextBox = Syncfusion.Typed.MaskedTextBox
module RadioButton = Syncfusion.Typed.RadioButton
module Switch = Syncfusion.Typed.Switch
module Slider = Syncfusion.Typed.Slider

let textArea (onInput: string option -> unit) : ReactElement =
    TextArea.create [
        TextArea.prop.value "Initial note"
        TextArea.prop.rows 3
        TextArea.prop.resizeMode TextArea.ResizeMode.Vertical
        TextArea.prop.input (fun args -> onInput args.value)
    ]

let maskedTextBox (onChange: string option -> unit) : ReactElement =
    MaskedTextBox.create [
        MaskedTextBox.prop.mask "000-000"
        MaskedTextBox.prop.value "123456"
        MaskedTextBox.prop.change (fun args -> onChange args.value)
    ]

let radioButton (onChange: string option -> unit) : ReactElement =
    RadioButton.create [
        RadioButton.prop.name "choice"
        RadioButton.prop.value "one"
        RadioButton.prop.label "One"
        RadioButton.prop.change (fun args -> onChange args.value)
    ]

let switch (onChange: bool option -> unit) : ReactElement =
    Switch.create [
        Switch.prop.onLabel "On"
        Switch.prop.offLabel "Off"
        Switch.prop.beforeChange (fun args -> args.cancel <- Some false)
        Switch.prop.change (fun args -> onChange args.``checked``)
    ]

let slider (onChange: Slider.ChangeEventArgs -> unit) : ReactElement =
    Slider.create [
        Slider.prop.min 0.0
        Slider.prop.max 10.0
        Slider.prop.value 4.0
        Slider.prop.sliderType Slider.SliderType.MinRange
        Slider.prop.change onChange
    ]
