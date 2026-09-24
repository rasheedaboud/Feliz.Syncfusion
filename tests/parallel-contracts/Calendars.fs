module ParallelContracts.Calendars

open System
open Feliz

module Calendar = Syncfusion.Typed.Calendar
module DateRangePicker = Syncfusion.Typed.DateRangePicker
module TimePicker = Syncfusion.Typed.TimePicker

let initialDate = DateTime(2026, 9, 24)
let updatedDate = DateTime(2026, 9, 25)

let calendar (date: DateTime) (onChange: DateTime option -> unit) : ReactElement =
    Calendar.create [
        Calendar.prop.value date
        Calendar.prop.min (DateTime(2026, 1, 1))
        Calendar.prop.max (DateTime(2026, 12, 31))
        Calendar.prop.change (fun args -> onChange args.value)
    ]

let rangePicker (startDate: DateTime) (endDate: DateTime) (onChange: DateTime option -> DateTime option -> unit) : ReactElement =
    DateRangePicker.create [
        DateRangePicker.prop.startDate startDate
        DateRangePicker.prop.endDate endDate
        DateRangePicker.prop.format "yyyy-MM-dd"
        DateRangePicker.prop.showClearButton true
        DateRangePicker.prop.change (fun args -> onChange args.startDate args.endDate)
    ]

let timePicker (date: DateTime) (onChange: DateTime option -> unit) : ReactElement =
    TimePicker.create [
        TimePicker.prop.value date
        TimePicker.prop.format "HH:mm"
        TimePicker.prop.step 30
        TimePicker.prop.change (fun args -> onChange args.value)
    ]
