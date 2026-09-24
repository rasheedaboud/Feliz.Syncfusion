namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IListBoxProperty<'Item, 'Value> = interface end

module ListBox =
    let private controlComponent: ReactElement = import "ListBoxComponent" "@syncfusion/ej2-react-dropdowns"

    type Fields<'Item> = { text: string; value: string }

    [<AllowNullLiteral>]
    type ChangeEventArgs<'Item> =
        abstract elements: Browser.Types.HTMLElement array option
        abstract items: 'Item array option

    [<Erase>]
    type prop =
        static member inline dataSource<'Item, 'Value>(items: 'Item array) : IListBoxProperty<'Item, 'Value> = unbox ("dataSource", items)
        static member inline fields<'Item, 'Value>(fields: Fields<'Item>) : IListBoxProperty<'Item, 'Value> = unbox ("fields", fields)
        static member inline value<'Item, 'Value>(value: 'Value array) : IListBoxProperty<'Item, 'Value> = unbox ("value", value)
        static member inline allowFiltering<'Item, 'Value>(value: bool) : IListBoxProperty<'Item, 'Value> = unbox ("allowFiltering", value)
        static member inline enabled<'Item, 'Value>(value: bool) : IListBoxProperty<'Item, 'Value> = unbox ("enabled", value)
        static member inline change<'Item, 'Value>(callback: ChangeEventArgs<'Item> -> unit) : IListBoxProperty<'Item, 'Value> = unbox ("change", callback)

    let create<'Item, 'Value> (props: IListBoxProperty<'Item, 'Value> list) : ReactElement =
        ReactLegacy.createElement(controlComponent, createObj !!props)
