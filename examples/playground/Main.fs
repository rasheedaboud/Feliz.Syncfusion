module Playground

open System
open Browser.Dom
open Browser.Types
open Fable.Core
open Feliz

module AppBar = Syncfusion.SfAppBar
module SideBar = Syncfusion.SfSideBar
module Ddl = Syncfusion.Typed.DropDownList
module ListBox = Syncfusion.Typed.ListBox
module Tree = Syncfusion.Typed.DropDownTree
module Mention = Syncfusion.Typed.Mention
module MultiColumn = Syncfusion.Typed.MultiColumnComboBox
module Calendar = Syncfusion.Typed.Calendar
module DateRange = Syncfusion.Typed.DateRangePicker
module Time = Syncfusion.Typed.TimePicker
module TextArea = Syncfusion.Typed.TextArea
module Masked = Syncfusion.Typed.MaskedTextBox
module Radio = Syncfusion.Typed.RadioButton
module Switch = Syncfusion.Typed.Switch
module Slider = Syncfusion.Typed.Slider

type Choice = { id: string; label: string }
type Demo = { slug: string; title: string; group: string; hint: string }
type IRoot = abstract render: ReactElement -> unit

[<Import("createRoot", "react-dom/client")>]
let createRoot (element: HTMLElement) : IRoot = jsNative
[<Emit("new URLSearchParams(window.location.search).get('demo')")>]
let requestedDemo () : string = jsNative
[<Emit("window.matchMedia('(max-width: 700px)').matches")>]
let isNarrowScreen () : bool = jsNative
[<Import("renderLegacy", "../../examples/playground/legacy-demos.js")>]
let renderLegacy (slug: string) : ReactElement = jsNative

let choices = [| { id = "alpha"; label = "Alpha" }; { id = "beta"; label = "Beta" }; { id = "gamma"; label = "Gamma" } |]

let demos = [
    { slug = "dropdown-list"; title = "DropDownList"; group = "Dropdowns"; hint = "Select an item with the pointer or arrow keys." }
    { slug = "list-box"; title = "ListBox"; group = "Dropdowns"; hint = "Choose an item from the list." }
    { slug = "dropdown-tree"; title = "DropDownTree"; group = "Dropdowns"; hint = "Open the tree and choose an item." }
    { slug = "mention"; title = "Mention"; group = "Dropdowns"; hint = "Type @ in the input to see suggestions." }
    { slug = "multi-column"; title = "MultiColumnComboBox"; group = "Dropdowns"; hint = "Open the picker to browse its rows." }
    { slug = "calendar"; title = "Calendar"; group = "Calendars"; hint = "Pick a date from the calendar." }
    { slug = "date-range"; title = "DateRangePicker"; group = "Calendars"; hint = "Choose a start and end date." }
    { slug = "time"; title = "TimePicker"; group = "Calendars"; hint = "Choose a time in 30-minute steps." }
    { slug = "text-area"; title = "TextArea"; group = "Inputs"; hint = "Edit the note below." }
    { slug = "masked-text"; title = "MaskedTextBox"; group = "Inputs"; hint = "Enter a six-digit code." }
    { slug = "radio"; title = "RadioButton"; group = "Inputs"; hint = "Pick one of two options." }
    { slug = "switch"; title = "Switch"; group = "Inputs"; hint = "Toggle the switch." }
    { slug = "slider"; title = "Slider"; group = "Inputs"; hint = "Drag the slider to change its value." }
    { slug = "appbar"; title = "AppBar"; group = "Layout"; hint = "The header above is a Syncfusion AppBar." }
    { slug = "sidebar"; title = "Sidebar"; group = "Layout"; hint = "The navigation at left is a Syncfusion Sidebar. Use Menu to toggle it." }
    { slug = "list-view"; title = "ListView"; group = "Navigation"; hint = "A list of selectable items." }
    { slug = "menu-bar"; title = "Menu Bar"; group = "Navigation"; hint = "Open a menu to see its commands." }
    { slug = "button"; title = "Button"; group = "Buttons"; hint = "A basic Syncfusion action button." }
    { slug = "progress-button"; title = "Progress Button"; group = "Buttons"; hint = "Click to see an action in progress." }
    { slug = "split-button"; title = "SplitButton"; group = "Buttons"; hint = "Open the split menu for more actions." }
    { slug = "chips"; title = "Chips"; group = "Buttons"; hint = "A compact set of labeled choices." }
    { slug = "combo-box"; title = "ComboBox"; group = "Dropdowns"; hint = "Choose an item or enter your own." }
    { slug = "multi-select"; title = "MultiSelect"; group = "Dropdowns"; hint = "Select more than one item." }
    { slug = "auto-complete"; title = "AutoComplete"; group = "Dropdowns"; hint = "Type to find a suggestion." }
    { slug = "date-picker"; title = "DatePicker"; group = "Calendars"; hint = "Choose a single date." }
    { slug = "date-time-picker"; title = "DateTimePicker"; group = "Calendars"; hint = "Choose a date and time." }
    { slug = "text-box"; title = "TextBox"; group = "Inputs"; hint = "Enter a short text value." }
    { slug = "numeric-text-box"; title = "NumericTextBox"; group = "Inputs"; hint = "Enter or step through a number." }
    { slug = "check-box"; title = "CheckBox"; group = "Inputs"; hint = "Toggle a checkable option." }
    { slug = "file-uploader"; title = "FileUploader"; group = "Inputs"; hint = "Select a file; automatic upload is disabled." }
    { slug = "grid"; title = "Grid"; group = "Data"; hint = "A small tabular data set." }
    { slug = "kanban"; title = "Kanban"; group = "Data"; hint = "Cards arranged by workflow state." }
    { slug = "modal"; title = "Dialog"; group = "Popups"; hint = "A nonmodal dialog example." }
    { slug = "tooltip"; title = "Tooltip"; group = "Popups"; hint = "Hover over the target to see its tooltip." }
]

let routeFromUrl () =
    let slug = requestedDemo ()
    if String.IsNullOrWhiteSpace slug then "dropdown-list" else slug

let feedbackText (value: string option) = value |> Option.defaultValue "None"

let control slug (report: string -> unit) : ReactElement =
    match slug with
    | "dropdown-list" -> Ddl.create<Choice, string> [
        Ddl.prop.dataSource choices
        Ddl.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
        Ddl.prop.value "alpha"
        Ddl.prop.placeholder "Choose an item"
        Ddl.prop.change (fun args -> report (feedbackText args.value))
      ]
    | "list-box" -> ListBox.create<Choice, string> [
        ListBox.prop.dataSource choices
        ListBox.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
        ListBox.prop.value [| "alpha" |]
        ListBox.prop.change (fun args -> report (args.items |> Option.bind Array.tryHead |> Option.map (fun item -> item.label) |> feedbackText))
      ]
    | "dropdown-tree" -> Tree.create<Choice, string> [
        Tree.prop.fields { dataSource = choices; text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id); child = None }
        Tree.prop.value [| "alpha" |]
        Tree.prop.placeholder "Choose an item"
        Tree.prop.change (fun args -> report (args.value |> Option.map (String.concat ", ") |> feedbackText))
      ]
    | "mention" -> Html.div [ prop.children [
        Html.input [ prop.id "mention-target"; prop.placeholder "Type @ to mention an item" ]
        Mention.create<Choice> [
            Mention.prop.dataSource choices
            Mention.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
            Mention.prop.target "#mention-target"
            Mention.prop.select (fun args -> report (args.itemData |> Option.map (fun item -> item.label) |> feedbackText))
        ]
      ] ]
    | "multi-column" -> MultiColumn.create<Choice, string> [
        MultiColumn.prop.dataSource choices
        MultiColumn.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
        MultiColumn.prop.value "alpha"
        MultiColumn.prop.placeholder "Choose an item"
        MultiColumn.prop.change (fun args -> report (feedbackText args.value))
      ]
    | "calendar" -> Calendar.create [
        Calendar.prop.value (DateTime(2026, 9, 24))
        Calendar.prop.change (fun args -> report (args.value |> Option.map (fun date -> date.ToString("yyyy-MM-dd")) |> feedbackText))
      ]
    | "date-range" -> DateRange.create [
        DateRange.prop.startDate (DateTime(2026, 9, 24))
        DateRange.prop.endDate (DateTime(2026, 9, 27))
        DateRange.prop.format "yyyy-MM-dd"
        DateRange.prop.change (fun args -> report (feedbackText args.text))
      ]
    | "time" -> Time.create [
        Time.prop.value (DateTime(2026, 9, 24, 9, 30, 0))
        Time.prop.format "HH:mm"
        Time.prop.step 30
        Time.prop.change (fun args -> report (feedbackText args.text))
      ]
    | "text-area" -> TextArea.create [
        TextArea.prop.value "Initial note"
        TextArea.prop.rows 4
        TextArea.prop.placeholder "Write a note"
        TextArea.prop.input (fun args -> report (feedbackText args.value))
      ]
    | "masked-text" -> Masked.create [
        Masked.prop.mask "000-000"
        Masked.prop.placeholder "123-456"
        Masked.prop.change (fun args -> report (feedbackText args.value))
      ]
    | "radio" -> Html.div [ prop.className "radio-options"; prop.children [
        Radio.create [ Radio.prop.name "playground-choice"; Radio.prop.value "alpha"; Radio.prop.label "Alpha"; Radio.prop.change (fun args -> report (feedbackText args.value)) ]
        Radio.create [ Radio.prop.name "playground-choice"; Radio.prop.value "beta"; Radio.prop.label "Beta"; Radio.prop.change (fun args -> report (feedbackText args.value)) ]
      ] ]
    | "switch" -> Switch.create [
        Switch.prop.onLabel "On"
        Switch.prop.offLabel "Off"
        Switch.prop.change (fun args -> report (args.``checked`` |> Option.map string |> feedbackText))
      ]
    | "slider" -> Slider.create [
        Slider.prop.min 0.0
        Slider.prop.max 100.0
        Slider.prop.value 40.0
        Slider.prop.showButtons true
        Slider.prop.change (fun args -> report (string args.value))
      ]
    | "appbar" -> Html.p "The AppBar stays above the gallery while you change routes."
    | "sidebar" -> Html.p "The Sidebar holds every route in the gallery and can be toggled from the AppBar."
    | _ -> renderLegacy slug

[<ReactComponent>]
let App () =
    let route = routeFromUrl ()
    let feedback, setFeedback = React.useState "Interact with the control to see an event here."
    let narrowScreen = isNarrowScreen ()
    let sidebarOpen, setSidebarOpen = React.useState (not narrowScreen)
    let active = demos |> List.tryFind (fun demo -> demo.slug = route)
    let title = active |> Option.map (fun demo -> demo.title) |> Option.defaultValue "Components"
    let hint = active |> Option.map (fun demo -> demo.hint) |> Option.defaultValue "Choose a component from the sidebar."
    let navLinks =
        demos
        |> List.groupBy (fun demo -> demo.group)
        |> List.collect (fun (group, items) ->
            Html.h2 [ prop.key $"heading-{group}"; prop.className "nav-heading"; prop.text group ] ::
            (items |> List.map (fun demo -> Html.a [
                prop.key demo.slug
                prop.href $"/?demo={demo.slug}"
                prop.className (if route = demo.slug then "nav-link active" else "nav-link")
                prop.text demo.title
            ])))
    Html.div [ prop.className "app-shell"; prop.children [
        AppBar.SfAppBar.create [
            AppBar.SfAppBar.mode AppBar.AppBarMode.Regular
            AppBar.SfAppBar.children [
                Html.button [ prop.key "menu"; prop.className "menu-button"; prop.onClick (fun _ -> setSidebarOpen (not sidebarOpen)); prop.text "Menu" ]
                Html.strong [ prop.key "title"; prop.className "app-title"; prop.text "Feliz.Syncfusion playground" ]
                Html.span [ prop.key "count"; prop.className "app-count"; prop.text $"{demos.Length} demos" ]
            ]
        ]
        Html.div [ prop.className "workspace"; prop.children [
            SideBar.SfSideBar.create [
                SideBar.SfSideBar.isOpen sidebarOpen
                SideBar.SfSideBar.sidebarType (if narrowScreen then SideBar.SidebarType.Over else SideBar.SidebarType.Push)
                SideBar.SfSideBar.width "250px"
                SideBar.SfSideBar.animate false
                prop.children [ Html.nav [ prop.key "navigation"; prop.ariaLabel "Components"; prop.children navLinks ] ]
            ]
            Html.main [ prop.className "content"; prop.children [
                Html.div [ prop.className "demo-card"; prop.children [
                    Html.p [ prop.className "eyebrow"; prop.text (active |> Option.map (fun demo -> demo.group) |> Option.defaultValue "Gallery") ]
                    Html.h1 title
                    Html.p [ prop.className "hint"; prop.text hint ]
                    Html.div [ prop.className "control-stage"; prop.children [ control route setFeedback ] ]
                    Html.p [ prop.className "feedback"; prop.children [ Html.strong "Event: "; Html.span [ prop.id "event-output"; prop.text feedback ] ] ]
                ] ] ] ]
        ] ]
    ] ]

let host = document.getElementById "app"
createRoot host |> fun root -> root.render (App())
