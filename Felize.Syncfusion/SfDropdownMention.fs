namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IMentionProperty<'Item> = interface end

module Mention =
    let private controlComponent: ReactElement = import "MentionComponent" "@syncfusion/ej2-react-dropdowns"

    type Fields<'Item> = { text: string; value: string }

    [<AllowNullLiteral>]
    type SelectEventArgs<'Item> =
        abstract itemData: 'Item option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline dataSource<'Item>(items: 'Item array) : IMentionProperty<'Item> = unbox ("dataSource", items)
        static member inline fields<'Item>(fields: Fields<'Item>) : IMentionProperty<'Item> = unbox ("fields", fields)
        static member inline target<'Item>(selector: string) : IMentionProperty<'Item> = unbox ("target", selector)
        static member inline mentionChar<'Item>(value: char) : IMentionProperty<'Item> = unbox ("mentionChar", string value)
        static member inline minLength<'Item>(value: int) : IMentionProperty<'Item> = unbox ("minLength", value)
        static member inline select<'Item>(callback: SelectEventArgs<'Item> -> unit) : IMentionProperty<'Item> = unbox ("select", callback)

    let create<'Item> (props: IMentionProperty<'Item> list) : ReactElement =
        ReactLegacy.createElement(controlComponent, createObj !!props)
