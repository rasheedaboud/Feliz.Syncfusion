module Playground

open Browser.Dom
open Browser.Types
open Fable.Core
open Feliz

module DropDown = Syncfusion.Typed.DropDownList

type Choice = { id: string; label: string }

type IRoot =
    abstract render: ReactElement -> unit

[<Import("createRoot", "react-dom/client")>]
let createRoot (element: HTMLElement) : IRoot = jsNative

let choices = [|
    { id = "alpha"; label = "Alpha" }
    { id = "beta"; label = "Beta" }
    { id = "gamma"; label = "Gamma" }
|]

[<ReactComponent>]
let App () =
        let selected, setSelected = React.useState "alpha"
        Html.div [
            prop.className "card"
            prop.children [
                Html.h1 "Feliz.Syncfusion playground"
                Html.p "Choose an item to see the typed change event."
                DropDown.create<Choice, string> [
                    DropDown.prop.dataSource choices
                    DropDown.prop.fields { text = nameof (Unchecked.defaultof<Choice>.label); value = nameof (Unchecked.defaultof<Choice>.id) }
                    DropDown.prop.value selected
                    DropDown.prop.placeholder "Choose an item"
                    DropDown.prop.change (fun args -> args.value |> Option.iter setSelected)
                ]
                Html.p [ prop.id "selected-value"; prop.text $"Selected: {selected}" ]
            ]
        ]

let host = document.getElementById "app"
createRoot host |> fun root -> root.render (App())
