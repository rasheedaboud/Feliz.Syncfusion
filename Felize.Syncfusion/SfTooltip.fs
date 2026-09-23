namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

type ISfTooltipProperty = interface end

module SfTooltip =
    let private syncfusionComponent: obj = import "TooltipComponent" "@syncfusion/ej2-react-popups"

    [<StringEnum; RequireQualifiedAccess>]
    type Position = TopCenter | BottomCenter | LeftCenter | RightCenter | TopLeft | TopRight | BottomLeft | BottomRight

    [<StringEnum; RequireQualifiedAccess>]
    type OpensOn = Hover | Click | Focus | Auto

    [<AllowNullLiteral>]
    type OpenEventArgs =
        abstract element: HTMLElement option
        abstract target: HTMLElement option

    [<Erase>]
    type prop =
        static member inline content(value: string) : ISfTooltipProperty = unbox ("content", value)
        static member inline content(value: ReactElement) : ISfTooltipProperty = unbox ("content", value)
        static member inline position(value: Position) : ISfTooltipProperty = unbox ("position", value)
        static member inline opensOn(value: OpensOn) : ISfTooltipProperty = unbox ("opensOn", value)
        static member inline showTipPointer(value: bool) : ISfTooltipProperty = unbox ("showTipPointer", value)
        static member inline cssClass(value: string) : ISfTooltipProperty = unbox ("cssClass", value)
        static member inline target(value: string) : ISfTooltipProperty = unbox ("target", value)
        static member inline afterOpen(callback: OpenEventArgs -> unit) : ISfTooltipProperty = unbox ("afterOpen", callback)
        static member inline children(value: ReactElement list) : ISfTooltipProperty = unbox ("children", value)

    let create (props: ISfTooltipProperty list) : ReactElement =
        ReactLegacy.createElement(unbox<ReactElement> syncfusionComponent, createObj !!props)
