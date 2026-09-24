module ParallelDropdownContracts

open Feliz

type Item = { id: string; title: string }

let items = [| { id = "one"; title = "One" }; { id = "two"; title = "Two" } |]

let listBox (onChange: Item array option -> unit) : ReactElement =
    Syncfusion.Typed.ListBox.create<Item, string> [
        Syncfusion.Typed.ListBox.prop.dataSource items
        Syncfusion.Typed.ListBox.prop.fields { text = nameof (Unchecked.defaultof<Item>.title); value = nameof (Unchecked.defaultof<Item>.id) }
        Syncfusion.Typed.ListBox.prop.value [| "one" |]
        Syncfusion.Typed.ListBox.prop.change (fun args -> onChange args.items)
    ]

let tree (onChange: string array option -> unit) : ReactElement =
    Syncfusion.Typed.DropDownTree.create<Item, string> [
        Syncfusion.Typed.DropDownTree.prop.fields {
            dataSource = items
            text = nameof (Unchecked.defaultof<Item>.title)
            value = nameof (Unchecked.defaultof<Item>.id)
            child = None
        }
        Syncfusion.Typed.DropDownTree.prop.value [| "one" |]
        Syncfusion.Typed.DropDownTree.prop.placeholder "Choose"
        Syncfusion.Typed.DropDownTree.prop.change (fun args -> onChange args.value)
    ]

let mention (onSelect: Item option -> unit) : ReactElement =
    Syncfusion.Typed.Mention.create<Item> [
        Syncfusion.Typed.Mention.prop.dataSource items
        Syncfusion.Typed.Mention.prop.fields { text = nameof (Unchecked.defaultof<Item>.title); value = nameof (Unchecked.defaultof<Item>.id) }
        Syncfusion.Typed.Mention.prop.target "#typed-mention-target"
        Syncfusion.Typed.Mention.prop.select (fun args -> onSelect args.itemData)
    ]

let multiColumn (onChange: string option -> unit) : ReactElement =
    Syncfusion.Typed.MultiColumnComboBox.create<Item, string> [
        Syncfusion.Typed.MultiColumnComboBox.prop.dataSource items
        Syncfusion.Typed.MultiColumnComboBox.prop.fields { text = nameof (Unchecked.defaultof<Item>.title); value = nameof (Unchecked.defaultof<Item>.id) }
        Syncfusion.Typed.MultiColumnComboBox.prop.value "one"
        Syncfusion.Typed.MultiColumnComboBox.prop.change (fun args -> onChange args.value)
    ]
