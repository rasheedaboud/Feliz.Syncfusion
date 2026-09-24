module ParallelContracts.Positive

open System
open Feliz

module DatePicker = Syncfusion.Typed.DatePicker
module DropDownList = Syncfusion.Typed.DropDownList

type Choice = { id: int; label: string }

let choices = [| { id = 1; label = "One" }; { id = 2; label = "Two" } |]

let dropDownList (onChange: int option -> Choice option -> unit) : ReactElement =
    DropDownList.create<Choice, int> [
        DropDownList.prop.dataSource choices
        DropDownList.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
        DropDownList.prop.value 1
        DropDownList.prop.placeholder "Select a choice"
        DropDownList.prop.change (fun args -> onChange args.value args.itemData)
    ]

// A real consumer expression: the props, value, and event handler must type-check.
let datePicker (onChange: DateTime option -> unit) : ReactElement =
    DatePicker.create [
        DatePicker.prop.value (DateTime(2026, 9, 24))
        DatePicker.prop.format "yyyy-MM-dd"
        DatePicker.prop.change (fun args -> onChange args.value)
    ]
