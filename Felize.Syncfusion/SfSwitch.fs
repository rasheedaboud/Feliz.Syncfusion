namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ISwitchProperty = interface end

module Switch =
    let private SwitchComponent: ReactElement = import "SwitchComponent" "@syncfusion/ej2-react-buttons"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract ``checked``: bool option

    [<AllowNullLiteral>]
    type BeforeChangeEventArgs =
        abstract ``checked``: bool option
        abstract cancel: bool option with get, set

    [<Erase>]
    type prop =
        static member inline ``checked``(value: bool) : ISwitchProperty = unbox ("checked", value)
        static member inline value(value: string) : ISwitchProperty = unbox ("value", value)
        static member inline name(value: string) : ISwitchProperty = unbox ("name", value)
        static member inline onLabel(value: string) : ISwitchProperty = unbox ("onLabel", value)
        static member inline offLabel(value: string) : ISwitchProperty = unbox ("offLabel", value)
        static member inline disabled(value: bool) : ISwitchProperty = unbox ("disabled", value)
        static member inline cssClass(value: string) : ISwitchProperty = unbox ("cssClass", value)
        static member inline beforeChange(callback: BeforeChangeEventArgs -> unit) : ISwitchProperty = unbox ("beforeChange", callback)
        static member inline change(callback: ChangeEventArgs -> unit) : ISwitchProperty = unbox ("change", callback)

    let create (props: ISwitchProperty list) : ReactElement =
        ReactLegacy.createElement(SwitchComponent, createObj !!props)
