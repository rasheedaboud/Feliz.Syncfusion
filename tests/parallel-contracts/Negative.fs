module ParallelContracts.Negative

module DatePicker = Syncfusion.Typed.DatePicker
module FileUploader = Syncfusion.Typed.FileUploader
module DropDownList = Syncfusion.Typed.DropDownList

type Choice = { id: int; label: string }
type Other = { code: string }

let choices = [| { id = 1; label = "One" } |]
let otherRows: Other array = [| { code = "A" } |]

// EXPECT FS0001: a row source of Other cannot enter a Choice list.
let wrongRow =
    DropDownList.create<Choice, int> [DropDownList.prop.dataSource otherRows]

// EXPECT FS0001: a string selected value cannot enter an int-valued list.
let wrongSelectedValue =
    DropDownList.create<Choice, int> [DropDownList.prop.value "1"]

// EXPECT FS0193: the callback value is int option, not string.
let wrongSelectedEvent =
    DropDownList.create<Choice, int> [DropDownList.prop.change (fun args -> printfn "%s" args.value)]

// EXPECT FS0193: a FileUploader property cannot enter a DatePicker property list.
let wrongControlProperty =
    DatePicker.create [FileUploader.prop.multiple false]

// EXPECT FS0193: event callbacks cannot treat an optional DateTime as a string.
let wrongEventValue =
    DatePicker.create [DatePicker.prop.change (fun args -> printfn "%s" args.value)]
