namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ITextAreaProperty = interface end

module TextArea =
    let private TextAreaComponent: ReactElement = import "TextAreaComponent" "@syncfusion/ej2-react-inputs"

    [<StringEnum; RequireQualifiedAccess>]
    type ResizeMode =
        | [<CompiledName "Vertical">] Vertical
        | [<CompiledName "Horizontal">] Horizontal
        | [<CompiledName "Both">] Both
        | [<CompiledName "None">] None

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: string option
        abstract previousValue: string option
        abstract isInteracted: bool option

    [<AllowNullLiteral>]
    type InputEventArgs =
        abstract value: string option
        abstract previousValue: string option

    [<Erase>]
    type prop =
        static member inline value(value: string) : ITextAreaProperty = unbox ("value", value)
        static member inline placeholder(value: string) : ITextAreaProperty = unbox ("placeholder", value)
        static member inline enabled(value: bool) : ITextAreaProperty = unbox ("enabled", value)
        static member inline readOnly(value: bool) : ITextAreaProperty = unbox ("readonly", value)
        static member inline showClearButton(value: bool) : ITextAreaProperty = unbox ("showClearButton", value)
        static member inline rows(value: int) : ITextAreaProperty = unbox ("rows", value)
        static member inline cols(value: int) : ITextAreaProperty = unbox ("cols", value)
        static member inline maxLength(value: int) : ITextAreaProperty = unbox ("maxLength", value)
        static member inline width(value: string) : ITextAreaProperty = unbox ("width", value)
        static member inline resizeMode(value: ResizeMode) : ITextAreaProperty = unbox ("resizeMode", value)
        static member inline cssClass(value: string) : ITextAreaProperty = unbox ("cssClass", value)
        static member inline input(callback: InputEventArgs -> unit) : ITextAreaProperty = unbox ("input", callback)
        static member inline change(callback: ChangeEventArgs -> unit) : ITextAreaProperty = unbox ("change", callback)

    let create (props: ITextAreaProperty list) : ReactElement =
        ReactLegacy.createElement(TextAreaComponent, createObj !!props)
