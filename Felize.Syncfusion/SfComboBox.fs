namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

type ISfComboBoxProperty = interface end

module SfComboBox =
    let private component: obj = import "ComboBoxComponent" "@syncfusion/ej2-react-dropdowns"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: obj option
        abstract element: HTMLInputElement option
        abstract isInteracted: bool option

    [<AllowNullLiteral>]
    type SelectEventArgs =
        abstract item: HTMLElement
        abstract itemData: obj

    [<Erase>]
    type prop =
        static member inline dataSource(value: 'T array) : ISfComboBoxProperty = unbox ("dataSource", value)
        static member inline value(value: string) : ISfComboBoxProperty = unbox ("value", value)
        static member inline placeholder(value: string) : ISfComboBoxProperty = unbox ("placeholder", value)
        static member inline enabled(value: bool) : ISfComboBoxProperty = unbox ("enabled", value)
        static member inline readonly(value: bool) : ISfComboBoxProperty = unbox ("readonly", value)
        static member inline allowCustom(value: bool) : ISfComboBoxProperty = unbox ("allowCustom", value)
        static member inline allowFiltering(value: bool) : ISfComboBoxProperty = unbox ("allowFiltering", value)
        static member inline cssClass(value: string) : ISfComboBoxProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ISfComboBoxProperty = unbox ("change", callback)
        static member inline select(callback: SelectEventArgs -> unit) : ISfComboBoxProperty = unbox ("select", callback)

    let inline create (props: ISfComboBoxProperty list) : ReactElement =
        ReactLegacy.createElement(unbox component, createObj !!props)
