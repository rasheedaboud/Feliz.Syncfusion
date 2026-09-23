namespace Syncfusion

open System
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

type ISfDateTimePickerProperty = interface end

module SfDateTimePicker =
    let private syncfusionComponent: obj = import "DateTimePickerComponent" "@syncfusion/ej2-react-calendars"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: DateTime option
        abstract element: HTMLInputElement option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline value(value: DateTime) : ISfDateTimePickerProperty = unbox ("value", value)
        static member inline format(value: string) : ISfDateTimePickerProperty = unbox ("format", value)
        static member inline placeholder(value: string) : ISfDateTimePickerProperty = unbox ("placeholder", value)
        static member inline readonly(value: bool) : ISfDateTimePickerProperty = unbox ("readonly", value)
        static member inline enabled(value: bool) : ISfDateTimePickerProperty = unbox ("enabled", value)
        static member inline step(value: int) : ISfDateTimePickerProperty = unbox ("step", value)
        static member inline cssClass(value: string) : ISfDateTimePickerProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ISfDateTimePickerProperty = unbox ("change", callback)

    let create (props: ISfDateTimePickerProperty list) : ReactElement =
        ReactLegacy.createElement(unbox<ReactElement> syncfusionComponent, createObj !!props)
