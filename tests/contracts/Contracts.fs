module Contracts

open System
open System.Collections.Generic
open Browser.Dom
open Browser.Types
open Fable.Core
open Feliz

module Combo = Syncfusion.SfComboBox
module Multi = Syncfusion.SfMultiSelect
module DateTimePicker = Syncfusion.SfDateTimePicker
module Tooltip = Syncfusion.SfTooltip
module Kanban = Syncfusion.SfKanban
module TDate = Syncfusion.Typed.DatePicker
module Upload = Syncfusion.Typed.FileUploader
module Split = Syncfusion.Typed.SplitButton
module Grid = Syncfusion.Typed.Grid
module Data = Syncfusion.Typed.Data
module Ddl = Syncfusion.Typed.DropDownList
module Calendar = Syncfusion.Typed.Calendar
module Range = Syncfusion.Typed.DateRangePicker
module Time = Syncfusion.Typed.TimePicker
module TextArea = Syncfusion.Typed.TextArea
module Masked = Syncfusion.Typed.MaskedTextBox
module Radio = Syncfusion.Typed.RadioButton
module Switch = Syncfusion.Typed.Switch
module Slider = Syncfusion.Typed.Slider

type Row = { id: int; status: string; title: string }

type IRoot =
    abstract render: ReactElement -> unit
    abstract unmount: unit -> unit

[<Import("createRoot","react-dom/client")>]
let createRoot(element: HTMLElement): IRoot = jsNative

let private roots = Dictionary<string, IRoot>()

let private render id element =
    let host = document.getElementById id
    let root =
        match roots.TryGetValue id with
        | true, value -> value
        | _ ->
            let value = createRoot host
            roots[id] <- value
            value
    root.render element

let unmountComponent name =
    let id =
        match name with
        | "DropDownList" -> "typed-dropdownlist"
        | "ListBox" -> "typed-listbox"
        | "DropDownTree" -> "typed-dropdowntree"
        | "Mention" -> "typed-mention"
        | "MultiColumnComboBox" -> "typed-multicolumn"
        | "Calendar" -> "typed-calendar"
        | "DateRangePicker" -> "typed-range"
        | "TimePicker" -> "typed-time"
        | "TextArea" -> "typed-textarea"
        | "MaskedTextBox" -> "typed-maskedtextbox"
        | "RadioButton" -> "typed-radiobutton"
        | "Switch" -> "typed-switch"
        | "Slider" -> "typed-slider"
        | _ -> failwith $"Unknown component {name}"
    match roots.TryGetValue id with
    | true, root -> root.unmount(); roots.Remove id |> ignore
    | _ -> ()

[<Emit("window.__calendarChange = { value: $0 }")>]
let private recordCalendarChange (value: DateTime option) : unit = jsNative

let private setOutput id value =
    document.getElementById(id).textContent <- value

let private renderNew name updated =
    let date = DateTime(2026, 9, if updated then 25 else 24)
    match name with
    | "DropDownList" ->
        render "typed-dropdownlist" (Ddl.create<ParallelContracts.Positive.Choice, int> [
            Ddl.prop.dataSource ParallelContracts.Positive.choices
            Ddl.prop.fields { text = nameof (Unchecked.defaultof<ParallelContracts.Positive.Choice>.label); value = nameof (Unchecked.defaultof<ParallelContracts.Positive.Choice>.id) }
            Ddl.prop.value (if updated then 2 else 1)
            Ddl.prop.change (fun args -> args.value |> Option.iter (string >> setOutput "typed-dropdownlist-output"))
        ])
    | "ListBox" -> render "typed-listbox" (ParallelDropdownContracts.listBox ignore)
    | "DropDownTree" -> render "typed-dropdowntree" (ParallelDropdownContracts.tree ignore)
    | "Mention" -> render "typed-mention" (ParallelDropdownContracts.mention ignore)
    | "MultiColumnComboBox" -> render "typed-multicolumn" (ParallelDropdownContracts.multiColumn ignore)
    | "Calendar" -> render "typed-calendar" (ParallelContracts.Calendars.calendar date recordCalendarChange)
    | "DateRangePicker" -> render "typed-range" (ParallelContracts.Calendars.rangePicker date (date.AddDays(2.)) (fun _ _ -> ()))
    | "TimePicker" -> render "typed-time" (ParallelContracts.Calendars.timePicker date ignore)
    | "TextArea" -> render "typed-textarea" (TextArea.create [
        TextArea.prop.value (if updated then "Updated note" else "Initial note")
        TextArea.prop.input (fun args -> args.value |> Option.iter (setOutput "typed-textarea-output"))
    ])
    | "MaskedTextBox" -> render "typed-maskedtextbox" (ParallelContracts.Inputs.maskedTextBox ignore)
    | "RadioButton" -> render "typed-radiobutton" (ParallelContracts.Inputs.radioButton ignore)
    | "Switch" -> render "typed-switch" (ParallelContracts.Inputs.switch (fun value -> value |> Option.iter (string >> setOutput "typed-switch-output")))
    | "Slider" -> render "typed-slider" (ParallelContracts.Inputs.slider ignore)
    | _ -> failwith $"Unknown component {name}"

let private initialRows = [| { id = 1; status = "OPEN"; title = "Initial" } |]
let private updatedRows = [| { id = 2; status = "DONE"; title = "Updated" } |]

let private renderCombo value =
    Combo.create [
        Combo.prop.dataSource [| "Alpha"; "Beta"; "Gamma" |]
        Combo.prop.value value
        Combo.prop.placeholder "Choose"
        Combo.prop.allowFiltering true
        Combo.prop.allowCustom false
        Combo.prop.enabled true
    ]

let private renderMulti values =
    Multi.create [
        Multi.prop.dataSource [| "One"; "Two"; "Three" |]
        Multi.prop.value values
        Multi.prop.mode Multi.Mode.Box
        Multi.prop.allowCustomValue true
        Multi.prop.placeholder "Choose"
    ]

let private renderDateTime value =
    DateTimePicker.create [
        DateTimePicker.prop.value value
        DateTimePicker.prop.format "yyyy-MM-dd HH:mm"
        DateTimePicker.prop.step 30
    ]

let private renderTooltip (content: string) =
    Tooltip.create [
        Tooltip.prop.content content
        Tooltip.prop.position Tooltip.Position.TopCenter
        Tooltip.prop.opensOn Tooltip.OpensOn.Click
        Tooltip.prop.showTipPointer true
        Tooltip.prop.children [ Html.button [ prop.id "typed-tooltip-target"; prop.text "Hover target" ] ]
    ]

let private renderKanban rows =
    Kanban.create [
        Kanban.prop.keyField "status"
        Kanban.prop.dataSource rows
        Kanban.prop.cardSettings { headerField = "id"; contentField = "title" }
        Kanban.prop.allowDragAndDrop true
        Kanban.prop.children [
            Kanban.columns [
                Kanban.column { headerText = "Open"; keyField = "OPEN" }
                Kanban.column { headerText = "Done"; keyField = "DONE" }
            ]
        ]
    ]

let private renderDate value =
    TDate.create [
        TDate.prop.value value
        TDate.prop.format "yyyy-MM-dd"
    ]

let private renderUpload cssClass =
    Upload.create [
        Upload.prop.allowedExtensions ".pdf"
        Upload.prop.maxFileSize 10000000.
        Upload.prop.multiple false
        Upload.prop.autoUpload false
        Upload.prop.cssClass cssClass
    ]

let private renderSplit content =
    Split.create [
        Split.prop.content content
        Split.prop.cssClass "contract-split"
        Split.prop.items [| { id = "one"; text = "One"; iconCss = None; disabled = None } |]
    ]

let private renderGrid rows =
    Grid.create [
        Grid.prop.dataSource rows
        Grid.prop.columns [|
            { field = "id"; headerText = "ID"; width = Some 80.; visible = Some true; isPrimaryKey = Some true; ``type`` = Some "number"; format = None }
            { field = "title"; headerText = "Title"; width = Some 180.; visible = Some true; isPrimaryKey = Some false; ``type`` = Some "string"; format = None }
        |]
        Grid.prop.allowPaging true
        Grid.prop.allowSorting true
        Grid.prop.allowFiltering true
        Grid.prop.allowGrouping true
        Grid.prop.children [
            Grid.injectServices [
                Grid.service.Page
                Grid.service.Filter
                Grid.service.Sort
                Grid.service.Group
                Grid.service.Selection
            ]
        ]
    ]

let mountAll () =
    render "typed-combo" (renderCombo "Alpha")
    render "typed-multi" (renderMulti [| "One" |])
    render "typed-datetime" (renderDateTime (DateTime(2026, 9, 23, 10, 0, 0)))
    render "typed-tooltip" (renderTooltip "Tooltip initial")
    render "typed-kanban" (renderKanban initialRows)
    render "typed-date" (renderDate (DateTime(2026, 9, 23)))
    render "typed-upload" (renderUpload "upload-initial")
    render "typed-split" (renderSplit "Export initial")
    render "typed-grid" (renderGrid initialRows)

let updateAll () =
    render "typed-combo" (renderCombo "Beta")
    render "typed-multi" (renderMulti [| "Two" |])
    render "typed-datetime" (renderDateTime (DateTime(2026, 9, 24, 11, 30, 0)))
    render "typed-tooltip" (renderTooltip "Tooltip updated")
    render "typed-kanban" (renderKanban updatedRows)
    render "typed-date" (renderDate (DateTime(2026, 9, 24)))
    render "typed-upload" (renderUpload "upload-updated")
    render "typed-split" (renderSplit "Export updated")
    render "typed-grid" (renderGrid updatedRows)

let updateComponent name =
    match name with
    | "ComboBox" -> render "typed-combo" (renderCombo "Beta")
    | "MultiSelect" -> render "typed-multi" (renderMulti [| "Two" |])
    | "DateTimePicker" -> render "typed-datetime" (renderDateTime (DateTime(2026, 9, 24, 11, 30, 0)))
    | "Tooltip" -> render "typed-tooltip" (renderTooltip "Tooltip updated")
    | "Kanban" -> render "typed-kanban" (renderKanban updatedRows)
    | "DatePicker" -> render "typed-date" (renderDate (DateTime(2026, 9, 24)))
    | "FileUploader" -> render "typed-upload" (renderUpload "upload-updated")
    | "SplitButton" -> render "typed-split" (renderSplit "Export updated")
    | "Grid" -> render "typed-grid" (renderGrid updatedRows)
    | "DropDownList" | "ListBox" | "DropDownTree" | "Mention" | "MultiColumnComboBox"
    | "Calendar" | "DateRangePicker" | "TimePicker" | "TextArea" | "MaskedTextBox"
    | "RadioButton" | "Switch" | "Slider" -> renderNew name true
    | _ -> failwith $"Unknown component {name}"

let dataQueryDiagnostics () =
    let manager = Data.createLocal initialRows
    let allQuery = Data.Query()
    let filterQuery =
        Data.Query()
        |> Data.whereString "status" Data.FilterOperator.Equal "OPEN" true
    let countedQuery = filterQuery.clone().requiresCount()
    let counted = manager.executeLocalCounted(countedQuery)
    {| allCount = manager.executeLocal(allQuery).Count
       filteredCount = manager.executeLocal(filterQuery).Count
       countRequired = countedQuery.isCountRequired
       countedCount = counted.count |> Option.defaultValue 0. |}

let dataQueryCount () =
    let manager = Data.createLocal initialRows
    let query =
        Data.Query()
        |> Data.whereString "status" Data.FilterOperator.Equal "OPEN" true
    manager.executeLocal(query).Count


let mountComponent name =
    match name with
    | "ComboBox" -> render "typed-combo" (renderCombo "Alpha")
    | "MultiSelect" -> render "typed-multi" (renderMulti [| "One" |])
    | "DateTimePicker" -> render "typed-datetime" (renderDateTime (DateTime(2026, 9, 23, 10, 0, 0)))
    | "Tooltip" -> render "typed-tooltip" (renderTooltip "Tooltip initial")
    | "Kanban" -> render "typed-kanban" (renderKanban initialRows)
    | "DatePicker" -> render "typed-date" (renderDate (DateTime(2026, 9, 23)))
    | "FileUploader" -> render "typed-upload" (renderUpload "upload-initial")
    | "SplitButton" -> render "typed-split" (renderSplit "Export initial")
    | "Grid" -> render "typed-grid" (renderGrid initialRows)
    | "DropDownList" | "ListBox" | "DropDownTree" | "Mention" | "MultiColumnComboBox"
    | "Calendar" | "DateRangePicker" | "TimePicker" | "TextArea" | "MaskedTextBox"
    | "RadioButton" | "Switch" | "Slider" -> renderNew name false
    | _ -> failwith $"Unknown component {name}"
