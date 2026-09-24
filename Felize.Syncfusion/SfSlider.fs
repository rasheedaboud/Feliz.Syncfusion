namespace Syncfusion.Typed

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ISliderProperty = interface end

module Slider =
    let private SliderComponent: ReactElement = import "SliderComponent" "@syncfusion/ej2-react-inputs"

    [<StringEnum; RequireQualifiedAccess>]
    type SliderType =
        | [<CompiledName "Default">] Default
        | [<CompiledName "MinRange">] MinRange
        | [<CompiledName "Range">] Range

    [<StringEnum; RequireQualifiedAccess>]
    type Orientation =
        | [<CompiledName "Horizontal">] Horizontal
        | [<CompiledName "Vertical">] Vertical

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: U2<float, float array>
        abstract previousValue: U2<float, float array>
        abstract isInteracted: bool
        abstract action: string

    [<Erase>]
    type prop =
        static member inline value(value: float) : ISliderProperty = unbox ("value", value)
        static member inline rangeValue(value: float array) : ISliderProperty = unbox ("value", value)
        static member inline sliderType(value: SliderType) : ISliderProperty = unbox ("type", value)
        static member inline orientation(value: Orientation) : ISliderProperty = unbox ("orientation", value)
        static member inline min(value: float) : ISliderProperty = unbox ("min", value)
        static member inline max(value: float) : ISliderProperty = unbox ("max", value)
        static member inline step(value: float) : ISliderProperty = unbox ("step", value)
        static member inline enabled(value: bool) : ISliderProperty = unbox ("enabled", value)
        static member inline readOnly(value: bool) : ISliderProperty = unbox ("readonly", value)
        static member inline showButtons(value: bool) : ISliderProperty = unbox ("showButtons", value)
        static member inline width(value: string) : ISliderProperty = unbox ("width", value)
        static member inline cssClass(value: string) : ISliderProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : ISliderProperty = unbox ("change", callback)
        static member inline changed(callback: ChangeEventArgs -> unit) : ISliderProperty = unbox ("changed", callback)

    let create (props: ISliderProperty list) : ReactElement =
        ReactLegacy.createElement(SliderComponent, createObj !!props)
