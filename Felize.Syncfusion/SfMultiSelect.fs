namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ISfMultiSelectProperty = interface end

module SfMultiSelect =
    let private syncfusionComponent: ReactElement = import "MultiSelectComponent" "@syncfusion/ej2-react-dropdowns"

    [<StringEnum; RequireQualifiedAccess>]
    type Mode = Box | Default | Delimiter | CheckBox

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: string array option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline dataSource(value: 'T array) : ISfMultiSelectProperty = unbox ("dataSource", value)
        static member inline value(value: string array) : ISfMultiSelectProperty = unbox ("value", value)
        static member inline placeholder(value: string) : ISfMultiSelectProperty = unbox ("placeholder", value)
        static member inline mode(value: Mode) : ISfMultiSelectProperty = unbox ("mode", value)
        static member inline readonly(value: bool) : ISfMultiSelectProperty = unbox ("readonly", value)
        static member inline enabled(value: bool) : ISfMultiSelectProperty = unbox ("enabled", value)
        static member inline allowCustomValue(value: bool) : ISfMultiSelectProperty = unbox ("allowCustomValue", value)
        static member inline cssClass(value: string) : ISfMultiSelectProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ISfMultiSelectProperty = unbox ("change", callback)

    let create (props: ISfMultiSelectProperty list) : ReactElement =
        ReactLegacy.createElement(syncfusionComponent, createObj !!props)
