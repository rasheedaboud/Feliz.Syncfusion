namespace Syncfusion


module SfAppBar =
    
    open Fable.React
    open Feliz
    open Fable.Core
    open Fable.Core.JsInterop

    let appbar: obj =
        import "AppBarComponent " "@syncfusion/ej2-react-navigations"
    /// <summary>
    /// Specifies the height mode of the AppBar component which defines the height of the AppBar.
    ///
    /// * <c>Regular</c> - Specifies default height for the AppBar.
    /// * <c>Prominent</c> - Specifies longer height for the AppBar to show the longer titles and images, or to provide a stronger presence.
    /// * <c>Dense</c> - Specifies compressed (short) height for the AppBar to accommodate all the app bar content in a denser layout.
    /// </summary>
    type [<StringEnum>] [<RequireQualifiedAccess>] AppBarMode =
    | [<CompiledName("Regular")>] Regular
    | [<CompiledName("Prominent")>] Prominent
    | [<CompiledName("Dense")>] Dense

    /// <summary>
    /// Specifies the position of the AppBar.
    ///
    /// * <c>Top</c> - Position the AppBar at the top.
    /// * <c>Bottom</c> - Position the AppBar at the bottom.
    /// </summary>
    type [<StringEnum>] [<RequireQualifiedAccess>] AppBarPosition =
    | [<CompiledName("Top")>] Top
    | [<CompiledName("Bottom")>] Bottom

    /// <summary>
    /// Specifies the color of the AppBar component.
    ///
    /// * <c>Light</c> - Specifies the AppBar in light color.
    /// * <c>Dark</c> - Specifies the AppBar in dark color.
    /// * <c>Primary</c> - Specifies the AppBar in a primary color.
    /// * <c>Inherit</c> - Inherit color from parent for AppBar. AppBar background and colors are inherited from its parent element.
    /// </summary>
    type [<StringEnum>] [<RequireQualifiedAccess>] AppBarColor =
    | [<CompiledName("Light")>] Light
    | [<CompiledName("Dark")>] Dark
    | [<CompiledName("Primary")>] Primary
    | [<CompiledName("Inherit")>] Inherit


    [<Erase>]
    type Spacer =
        static member inline create xs = Feliz.Interop.createElement "div" [prop.className "e-appbar-spacer"]
        static member inline cssClass (value: string list) = Feliz.Interop.mkAttr "cssClass" [(["e-appbar-spacer"] @value |> Feliz.prop.classes)]

    [<Erase>]
    type Separator =
        static member inline create xs = Feliz.Interop.createElement "div" [prop.className "e-appbar-separator"]
        static member inline cssClass (value: string list) = Feliz.Interop.mkAttr "cssClass" [(["e-appbar-separator"] @value |> Feliz.prop.classes)]


    [<Erase>]
    type SfAppBar  =

        static member inline children(children) =
            Feliz.Interop.mkAttr "children" children
        /// <summary>
        /// Specifies the mode of the AppBar that defines the AppBar height. The possible values for this property are as follows:
        /// * Regular
        /// * Prominent
        /// * Dense
        /// </summary>
        /// <default>'Regular'</default>
        static member inline mode(mode: AppBarMode) = Feliz.Interop.mkAttr "mode" mode
        /// <summary>
        /// Specifies the position of the AppBar. The possible values for this property are as follows:
        /// * Top
        /// * Bottom
        /// </summary>
        /// <default>'Top'</default>
        static member inline position(position: AppBarPosition) = Feliz.Interop.mkAttr (nameof position) position
        /// <summary>Accepts single/multiple CSS classes (separated by a space) to be used for AppBar customization.</summary>
        /// <default>null</default>
        static member inline cssClass(cssClass: string option) = Feliz.Interop.mkAttr (nameof cssClass) cssClass
        /// <summary>
        /// Defines whether the AppBar position is fixed or not while scrolling the page.
        /// When set to <c>true</c>, the AppBar will be sticky while scrolling.
        /// </summary>
        /// <default>false</default>
        static member inline isSticky(isSticky: bool option) = Feliz.Interop.mkAttr (nameof isSticky) isSticky
        /// <summary>Accepts HTML attributes/custom attributes that will be applied to the AppBar element.</summary>
        /// <default>null</default>
        static member inline colorMode(colorMode: AppBarColor option) = Feliz.Interop.mkAttr (nameof colorMode) colorMode
        static member inline create(props: Feliz.IReactProperty list) =
            Feliz.Interop.reactApi.createElement (appbar, createObj !!props)

