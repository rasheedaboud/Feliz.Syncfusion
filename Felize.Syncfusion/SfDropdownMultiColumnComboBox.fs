namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IMultiColumnComboBoxProperty<'Item, 'Value> = interface end

module MultiColumnComboBox =
    let private controlComponent: ReactElement = import "MultiColumnComboBoxComponent" "@syncfusion/ej2-react-multicolumn-combobox"

    type Fields<'Item> = { text: string; value: string }

    [<AllowNullLiteral>]
    type ChangeEventArgs<'Item, 'Value> =
        abstract value: 'Value option
        abstract itemData: 'Item option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline dataSource<'Item, 'Value>(items: 'Item array) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("dataSource", items)
        static member inline fields<'Item, 'Value>(fields: Fields<'Item>) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("fields", fields)
        static member inline value<'Item, 'Value>(value: 'Value) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("value", value)
        static member inline placeholder<'Item, 'Value>(value: string) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("placeholder", value)
        static member inline allowFiltering<'Item, 'Value>(value: bool) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("allowFiltering", value)
        static member inline change<'Item, 'Value>(callback: ChangeEventArgs<'Item, 'Value> -> unit) : IMultiColumnComboBoxProperty<'Item, 'Value> = unbox ("change", callback)

    let create<'Item, 'Value> (props: IMultiColumnComboBoxProperty<'Item, 'Value> list) : ReactElement =
        ReactLegacy.createElement(controlComponent, createObj !!props)
