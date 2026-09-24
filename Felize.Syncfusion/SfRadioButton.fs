namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IRadioButtonProperty = interface end

module RadioButton =
    let private RadioButtonComponent: ReactElement = import "RadioButtonComponent" "@syncfusion/ej2-react-buttons"

    [<StringEnum; RequireQualifiedAccess>]
    type LabelPosition =
        | [<CompiledName "Before">] Before
        | [<CompiledName "After">] After

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: string option

    [<Erase>]
    type prop =
        static member inline value(value: string) : IRadioButtonProperty = unbox ("value", value)
        static member inline name(value: string) : IRadioButtonProperty = unbox ("name", value)
        static member inline label(value: string) : IRadioButtonProperty = unbox ("label", value)
        static member inline labelPosition(value: LabelPosition) : IRadioButtonProperty = unbox ("labelPosition", value)
        static member inline ``checked``(value: bool) : IRadioButtonProperty = unbox ("checked", value)
        static member inline disabled(value: bool) : IRadioButtonProperty = unbox ("disabled", value)
        static member inline cssClass(value: string) : IRadioButtonProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : IRadioButtonProperty = unbox ("change", callback)

    let create (props: IRadioButtonProperty list) : ReactElement =
        ReactLegacy.createElement(RadioButtonComponent, createObj !!props)
