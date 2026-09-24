namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IMaskedTextBoxProperty = interface end

module MaskedTextBox =
    let private MaskedTextBoxComponent: ReactElement = import "MaskedTextBoxComponent" "@syncfusion/ej2-react-inputs"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: string option
        abstract maskedValue: string option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline value(value: string) : IMaskedTextBoxProperty = unbox ("value", value)
        static member inline mask(value: string) : IMaskedTextBoxProperty = unbox ("mask", value)
        static member inline promptChar(value: string) : IMaskedTextBoxProperty = unbox ("promptChar", value)
        static member inline placeholder(value: string) : IMaskedTextBoxProperty = unbox ("placeholder", value)
        static member inline enabled(value: bool) : IMaskedTextBoxProperty = unbox ("enabled", value)
        static member inline readOnly(value: bool) : IMaskedTextBoxProperty = unbox ("readonly", value)
        static member inline showClearButton(value: bool) : IMaskedTextBoxProperty = unbox ("showClearButton", value)
        static member inline width(value: string) : IMaskedTextBoxProperty = unbox ("width", value)
        static member inline cssClass(value: string) : IMaskedTextBoxProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : IMaskedTextBoxProperty = unbox ("change", callback)

    let create (props: IMaskedTextBoxProperty list) : ReactElement =
        ReactLegacy.createElement(MaskedTextBoxComponent, createObj !!props)
