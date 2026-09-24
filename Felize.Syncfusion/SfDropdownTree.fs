namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IDropDownTreeProperty<'Item, 'Value> = interface end

module DropDownTree =
    let private controlComponent: ReactElement = import "DropDownTreeComponent" "@syncfusion/ej2-react-dropdowns"

    type Fields<'Item> = { dataSource: 'Item array; text: string; value: string; child: string option }

    [<AllowNullLiteral>]
    type ChangeEventArgs<'Item, 'Value> =
        abstract value: 'Value array option
        abstract isInteracted: bool option
        abstract itemData: 'Item array option

    [<Erase>]
    type prop =
        static member inline fields<'Item, 'Value>(fields: Fields<'Item>) : IDropDownTreeProperty<'Item, 'Value> = unbox ("fields", fields)
        static member inline value<'Item, 'Value>(value: 'Value array) : IDropDownTreeProperty<'Item, 'Value> = unbox ("value", value)
        static member inline placeholder<'Item, 'Value>(value: string) : IDropDownTreeProperty<'Item, 'Value> = unbox ("placeholder", value)
        static member inline showCheckBox<'Item, 'Value>(value: bool) : IDropDownTreeProperty<'Item, 'Value> = unbox ("showCheckBox", value)
        static member inline allowMultiSelection<'Item, 'Value>(value: bool) : IDropDownTreeProperty<'Item, 'Value> = unbox ("allowMultiSelection", value)
        static member inline change<'Item, 'Value>(callback: ChangeEventArgs<'Item, 'Value> -> unit) : IDropDownTreeProperty<'Item, 'Value> = unbox ("change", callback)

    let create<'Item, 'Value> (props: IDropDownTreeProperty<'Item, 'Value> list) : ReactElement =
        ReactLegacy.createElement(controlComponent, createObj !!props)
