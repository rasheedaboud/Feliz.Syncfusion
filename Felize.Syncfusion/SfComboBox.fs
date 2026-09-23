namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

type ISfComboBoxProperty = interface end

module SfComboBox =
    let private syncfusionComponent: ReactElement = import "ComboBoxComponent" "@syncfusion/ej2-react-dropdowns"

    [<AllowNullLiteral>]
    type ItemData =
        abstract text: string option
        abstract value: string option

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: string option
        abstract itemData: ItemData option
        abstract element: HTMLInputElement option
        abstract isInteracted: bool option

    [<AllowNullLiteral>]
    type SelectEventArgs =
        abstract item: HTMLElement
        abstract itemData: ItemData

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

    let create (props: ISfComboBoxProperty list) : ReactElement =
        ReactLegacy.createElement(syncfusionComponent, createObj !!props)
