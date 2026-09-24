namespace Syncfusion.Typed

open System
open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ITimePickerProperty = interface end

module TimePicker =
    let private timeComponent: ReactElement = import "TimePickerComponent" "@syncfusion/ej2-react-calendars"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: DateTime option
        abstract text: string option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline value(value: DateTime) : ITimePickerProperty = unbox ("value", value)
        static member inline min(value: DateTime) : ITimePickerProperty = unbox ("min", value)
        static member inline max(value: DateTime) : ITimePickerProperty = unbox ("max", value)
        static member inline format(value: string) : ITimePickerProperty = unbox ("format", value)
        static member inline placeholder(value: string) : ITimePickerProperty = unbox ("placeholder", value)
        static member inline step(value: int) : ITimePickerProperty = unbox ("step", value)
        static member inline enabled(value: bool) : ITimePickerProperty = unbox ("enabled", value)
        static member inline readonly(value: bool) : ITimePickerProperty = unbox ("readonly", value)
        static member inline strictMode(value: bool) : ITimePickerProperty = unbox ("strictMode", value)
        static member inline showClearButton(value: bool) : ITimePickerProperty = unbox ("showClearButton", value)
        static member inline cssClass(value: string) : ITimePickerProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ITimePickerProperty = unbox ("change", callback)

    let create (props: ITimePickerProperty list) : ReactElement =
        ReactLegacy.createElement(timeComponent, createObj !!props)
