namespace Syncfusion.Typed

open System
open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ICalendarProperty = interface end

module Calendar =
    let private calendarComponent: ReactElement = import "CalendarComponent" "@syncfusion/ej2-react-calendars"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: DateTime option
        abstract values: DateTime array option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline value(value: DateTime) : ICalendarProperty = unbox ("value", value)
        static member inline min(value: DateTime) : ICalendarProperty = unbox ("min", value)
        static member inline max(value: DateTime) : ICalendarProperty = unbox ("max", value)
        static member inline enabled(value: bool) : ICalendarProperty = unbox ("enabled", value)
        static member inline cssClass(value: string) : ICalendarProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ICalendarProperty = unbox ("change", callback)

    let create (props: ICalendarProperty list) : ReactElement =
        ReactLegacy.createElement(calendarComponent, createObj !!props)
