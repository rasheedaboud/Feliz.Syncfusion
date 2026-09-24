namespace Syncfusion.Typed

open System
open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IDateRangePickerProperty = interface end

module DateRangePicker =
    let private rangeComponent: ReactElement = import "DateRangePickerComponent" "@syncfusion/ej2-react-calendars"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract startDate: DateTime option
        abstract endDate: DateTime option
        abstract text: string option
        abstract daySpan: int option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline startDate(value: DateTime) : IDateRangePickerProperty = unbox ("startDate", value)
        static member inline endDate(value: DateTime) : IDateRangePickerProperty = unbox ("endDate", value)
        static member inline min(value: DateTime) : IDateRangePickerProperty = unbox ("min", value)
        static member inline max(value: DateTime) : IDateRangePickerProperty = unbox ("max", value)
        static member inline format(value: string) : IDateRangePickerProperty = unbox ("format", value)
        static member inline placeholder(value: string) : IDateRangePickerProperty = unbox ("placeholder", value)
        static member inline enabled(value: bool) : IDateRangePickerProperty = unbox ("enabled", value)
        static member inline readonly(value: bool) : IDateRangePickerProperty = unbox ("readonly", value)
        static member inline strictMode(value: bool) : IDateRangePickerProperty = unbox ("strictMode", value)
        static member inline showClearButton(value: bool) : IDateRangePickerProperty = unbox ("showClearButton", value)
        static member inline cssClass(value: string) : IDateRangePickerProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : IDateRangePickerProperty = unbox ("change", callback)

    let create (props: IDateRangePickerProperty list) : ReactElement =
        ReactLegacy.createElement(rangeComponent, createObj !!props)
