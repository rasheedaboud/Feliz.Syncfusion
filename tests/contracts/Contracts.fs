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

type Row = { id: int; status: string; title: string }

type IRoot =
    abstract render: ReactElement -> unit
    abstract unmount: unit -> unit

[<Import("createRoot","react-dom/client")>]
let createRoot(element: HTMLElement): IRoot = jsNative

let private roots = Dictionary<string, IRoot>()

let private render id element =
    let host = document.getElementById id :?> HTMLElement
    let root =
        match roots.TryGetValue id with
        | true, value -> value
        | _ ->
            let value = createRoot host
            roots[id] <- value
            value
    root.render element

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
        Tooltip.prop.opensOn Tooltip.OpensOn.Hover
        Tooltip.prop.showTipPointer true
        Tooltip.prop.children [ Html.button [ prop.text "Hover target" ] ]
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

let dataQueryCount () =
    let query =
        Data.Query()
        |> Data.whereString "status" Data.FilterOperator.Equal "OPEN" true
        |> fun q -> q.requiresCount()
    let manager =
        Data.DataManager<Row>({ json = initialRows; adaptor = Data.JsonAdaptor() })
    manager.executeLocal(query).Count
