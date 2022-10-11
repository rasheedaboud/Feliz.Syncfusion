namespace Feliz.Syncfusion


[<AutoOpen>]
module fSideBars =

    open Fable.Core.JsInterop
    open Fable.Core
    open Feliz
    

    open Browser.Types
    let sidebar: obj = import "SidebarComponent  " "@syncfusion/ej2-react-navigations"
    /// Specifies the Sidebar types.
    type [<StringEnum>] [<RequireQualifiedAccess>] SidebarType =
        | [<CompiledName("Slide")>] Slide
        | [<CompiledName("Over")>] Over
        | [<CompiledName("Push")>] Push
        | [<CompiledName("Auto")>] Auto

    /// Specifies the Sidebar positions.
    type [<StringEnum>] [<RequireQualifiedAccess>] SidebarPosition =
        | [<CompiledName("Left")>] Left
        | [<CompiledName("Right")>] Right

    /// <summary>Defines the event arguments for the event.</summary>
    /// <returns>void</returns>
    type [<AllowNullLiteral>] ChangeEventArgs =
        /// Returns event name
        abstract name: string with get, set
        /// Defines the element.
        abstract element: HTMLElement with get, set

    type [<AllowNullLiteral>] TransitionEvent =
        inherit Event
        /// Returns event name
        abstract propertyName: string with get, set

    type [<AllowNullLiteral>] EventArgs =
        /// Illustrates whether the current action needs to be prevented or not.
        abstract cancel: bool option with get, set
        /// Defines the Sidebar model.
        //abstract model: Sidebar option with get, set
        /// Defines the element.
        abstract element: HTMLElement with get, set
        /// Defines the boolean that returns true when the Sidebar is closed by user interaction, otherwise returns false.
        abstract isInteracted: bool option with get, set
        /// Defines the original event arguments.
        abstract ``event``: U2<MouseEvent, Event> option with get, set
    /// Interface for a class Sidebar
    type [<AllowNullLiteral>] ISidebar =

        abstract tabIndex: string with get, set
        /// <summary>
        /// Specifies the size of the Sidebar in dock state.
        /// &gt; For more details about dockSize refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/docking-sidebar/"><c>Dock</c></see> documentation.
        /// </summary>
        /// <default>'auto'</default>
        abstract dockSize: U2<string, float> with get, set
        /// <summary>
        /// Specifies the docking state of the component.
        /// &gt; For more details about enableDock refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/docking-sidebar/"><c>Dock</c></see> documentation.
        /// </summary>
        /// <default>false</default>
        abstract enableDock: bool with get, set
        /// <summary>
        /// Enables the expand or collapse while swiping in touch devices.
        /// This is not a sidebar property.
        /// </summary>
        /// <default>'en-US'</default>
        abstract locale: string with get, set
        /// <summary>
        /// Enable or disable persisting component's state between page reloads. If enabled, following list of states will be persisted.
        /// 1. Position
        /// 2. Type
        /// </summary>
        /// <default>false</default>
        abstract enablePersistence: bool with get, set
        /// <summary>Enables the expand or collapse while swiping in touch devices.</summary>
        /// <default>true</default>
        abstract enableGestures: bool with get, set
        /// <summary>
        /// Gets or sets the Sidebar component is open or close.
        /// &gt; When the Sidebar type is set to <c>Auto</c>,
        /// the component will be expanded in the desktop and collapsed in the mobile mode regardless of the isOpen property.
        /// </summary>
        /// <default>false</default>
        abstract isOpen: bool with get, set
        /// <summary>Specifies the Sidebar in RTL mode that displays the content in the right-to-left direction.</summary>
        /// <default>false</default>
        abstract enableRtl: bool with get, set
        /// <summary>Enable or disable the animation transitions on expanding or collapsing the Sidebar.</summary>
        /// <default>true</default>
        abstract animate: bool with get, set
        /// <summary>Specifies the height of the Sidebar.</summary>
        /// <default>'auto'</default>
        abstract height: U2<string, float> with get, set
        /// <summary>Specifies whether the Sidebar need to be closed or not when document area is clicked.</summary>
        /// <default>false</default>
        abstract closeOnDocumentClick: bool with get, set
        /// <summary>
        /// Specifies the position of the Sidebar (Left/Right) corresponding to the main content.
        /// &gt; For more details about SidebarPosition refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/getting-started/#position"><c>position</c></see> documentation.
        /// </summary>
        /// <default>'Left'</default>
        abstract position: SidebarPosition with get, set
        /// <summary>
        /// Allows to place the sidebar inside the target element.
        /// &gt; For more details about target refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/custom-context/"><c>Custom Context</c></see> documentation.
        /// </summary>
        /// <default>null</default>
        abstract target: string with get, set
        /// <summary>
        /// Specifies the whether to apply overlay options to main content when the Sidebar is in an open state.
        /// &gt; For more details about showBackdrop refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/getting-started/#enable-backdrop"><c>Backdrop</c></see> documentation.
        /// </summary>
        /// <default>false</default>
        abstract showBackdrop: bool with get, set
        /// <summary>
        /// Specifies the expanding types of the Sidebar.
        /// * <c>Over</c> - The sidebar floats over the main content area.
        /// * <c>Push</c> - The sidebar pushes the main content area to appear side-by-side, and shrinks the main content within the screen width.
        /// * <c>Slide</c> - The sidebar translates the x and y positions of main content area based on the sidebar width.
        /// The main content area will not be adjusted within the screen width.
        /// * <c>Auto</c> - Sidebar with <c>Over</c> type in mobile resolution and <c>Push</c> type in other higher resolutions.
        /// &gt; For more details about SidebarType refer to
        /// <see cref="../../sidebar/variations/"><c>SidebarType</c></see> documentation.
        /// </summary>
        /// <default>'Auto'</default>
        abstract ``type``: SidebarType with get, set
        /// <summary>
        /// Specifies the width of the Sidebar. By default, the width of the Sidebar sets based on the size of its content.
        /// Width can also be set in pixel values.
        /// </summary>
        /// <default>'auto'</default>
        abstract width: U2<string, float> with get, set
        /// <summary>Specifies the z-index of the Sidebar. It is applicable only when sidebar act as overlay type.</summary>
        /// <default>1000</default>
        abstract zIndex: U2<string, float> with get, set
        /// <summary>Triggers when component is created.</summary>
        abstract created: obj with get, set
        /// <summary>Triggers when component is closed.</summary>
        abstract close: EventArgs with get, set
        /// <summary>Triggers when component is opened.</summary>
        abstract ``open``: EventArgs with get, set
        /// <summary>Triggers when the state(expand/collapse) of the component is changed.</summary>
        abstract change: ChangeEventArgs with get, set
        /// <summary>Triggers when component gets destroyed.</summary>
        abstract destroyed: obj with get, set
        abstract preRender: unit -> unit
        abstract render: unit -> unit
        abstract initialize: unit -> unit
        /// <summary>Hide the Sidebar component, if it is in an open state.</summary>
        /// <returns />
        abstract hide: ?e: Event -> unit
        /// <summary>Shows the Sidebar component, if it is in closed state.</summary>
        /// <returns />
        abstract show: ?e: Event -> unit
        abstract getPersistData: unit -> string
        /// <summary>Returns the current module name.</summary>
        /// <returns>- returns module name.</returns>
        abstract getModuleName: unit -> string
        /// <summary>Shows or hides the Sidebar based on the current state.</summary>
        /// <returns />
        abstract toggle: unit -> unit
        abstract getState: unit -> bool
        abstract resize: unit -> unit
        /// <summary>Called internally if any of the property value changed.</summary>
        /// <param name="newProp">specifies newProp value.</param>
        /// <param name="oldProp">specifies oldProp value.</param>
        /// <returns />
        abstract onPropertyChanged: newProp: ISidebar * oldProp: ISidebar -> unit
        abstract setType: ?``type``: string -> unit
        /// <summary>Removes the control from the DOM and detaches all its related event handlers. Also it removes the attributes and classes.</summary>
        /// <returns />
        abstract destroy: unit -> unit

    type SfSideBar =
        /// <summary>
        /// Specifies the size of the Sidebar in dock state.
        /// &gt; For more details about dockSize refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/docking-sidebar/"><c>Dock</c></see> documentation.
        /// </summary>
        /// <default>'auto'</default>
        static member inline dockSize (dockSize: U2<string, float>) = Interop.mkAttr (nameof dockSize) dockSize
        /// <summary>
        /// Specifies the media query string for resolution, which when met opens the Sidebar.
        /// <code lang="typescript">
        ///    let defaultSidebar: Sidebar = new Sidebar({
        ///        mediaQuery:'(min-width: 600px)'
        ///    });
        /// </code>
        /// &gt; For more details about mediaQuery refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/auto-close/"><c>Auto Close</c></see> documentation.
        /// </summary>
        /// <default>null</default>
        static member inline mediaQuery  (mediaQuery: string) = Interop.mkAttr (nameof mediaQuery) mediaQuery
        /// <summary>
        /// Specifies the docking state of the component.
        /// &gt; For more details about enableDock refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/docking-sidebar/"><c>Dock</c></see> documentation.
        /// </summary>
        /// <default>false</default>
        static member inline enableDock  (enableDock: bool) = Interop.mkAttr (nameof enableDock) enableDock
        /// <summary>
        /// Enables the expand or collapse while swiping in touch devices.
        /// This is not a sidebar property.
        /// </summary>
        /// <default>'en-US'</default>
        static member inline locale  (locale: string) = Interop.mkAttr (nameof locale) locale
        /// <summary>
        /// Enable or disable persisting component's state between page reloads. If enabled, following list of states will be persisted.
        /// 1. Position
        /// 2. Type
        /// </summary>
        /// <default>false</default>
        static member inline enablePersistence  (enablePersistence: bool) = Interop.mkAttr (nameof enablePersistence) enablePersistence
        /// <summary>Enables the expand or collapse while swiping in touch devices.</summary>
        /// <default>true</default>
        static member inline enableGestures (enableGestures: bool) = Interop.mkAttr (nameof enableGestures) enableGestures
        /// <summary>
        /// Gets or sets the Sidebar component is open or close.
        /// &gt; When the Sidebar type is set to <c>Auto</c>,
        /// the component will be expanded in the desktop and collapsed in the mobile mode regardless of the isOpen property.
        /// </summary>
        /// <default>false</default>
        static member inline isOpen  (isOpen: bool) = Interop.mkAttr (nameof isOpen) isOpen
        /// <summary>Specifies the Sidebar in RTL mode that displays the content in the right-to-left direction.</summary>
        /// <default>false</default>
        static member inline enableRtl (enableRtl: bool) = Interop.mkAttr (nameof enableRtl) enableRtl
        /// <summary>Enable or disable the animation transitions on expanding or collapsing the Sidebar.</summary>
        /// <default>true</default>
        static member inline animate (animate: bool) = Interop.mkAttr (nameof animate) animate
        /// <summary>Specifies the height of the Sidebar.</summary>
        /// <default>'auto'</default>
        static member inline height (height: U2<string, float>) = Interop.mkAttr (nameof height) height
        /// <summary>Specifies whether the Sidebar need to be closed or not when document area is clicked.</summary>
        /// <default>false</default>
        static member inline closeOnDocumentClick (closeOnDocumentClick: bool) = Interop.mkAttr (nameof closeOnDocumentClick) closeOnDocumentClick
        /// <summary>
        /// Specifies the position of the Sidebar (Left/Right) corresponding to the main content.
        /// &gt; For more details about SidebarPosition refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/getting-started/#position"><c>position</c></see> documentation.
        /// </summary>
        /// <default>'Left'</default>
        static member inline position (position: SidebarPosition) = Interop.mkAttr (nameof position) position
        /// <summary>
        /// Allows to place the sidebar inside the target element.
        /// &gt; For more details about target refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/custom-context/"><c>Custom Context</c></see> documentation.
        /// </summary>
        /// <default>null</default>
        static member inline target (target: string) = Interop.mkAttr (nameof target) target
        /// <summary>
        /// Specifies the whether to apply overlay options to main content when the Sidebar is in an open state.
        /// &gt; For more details about showBackdrop refer to
        /// <see href="https://ej2.syncfusion.com/documentation/sidebar/getting-started/#enable-backdrop"><c>Backdrop</c></see> documentation.
        /// </summary>
        /// <default>false</default>
        static member inline showBackdrop (showBackdrop: bool) = Interop.mkAttr (nameof showBackdrop) showBackdrop
        /// <summary>
        /// Specifies the expanding types of the Sidebar.
        /// * <c>Over</c> - The sidebar floats over the main content area.
        /// * <c>Push</c> - The sidebar pushes the main content area to appear side-by-side, and shrinks the main content within the screen width.
        /// * <c>Slide</c> - The sidebar translates the x and y positions of main content area based on the sidebar width.
        /// The main content area will not be adjusted within the screen width.
        /// * <c>Auto</c> - Sidebar with <c>Over</c> type in mobile resolution and <c>Push</c> type in other higher resolutions.
        /// &gt; For more details about SidebarType refer to
        /// <see cref="../../sidebar/variations/"><c>SidebarType</c></see> documentation.
        /// </summary>
        /// <default>'Auto'</default>
        static member inline sidebarType (sidebarType: SidebarType) = Interop.mkAttr "type" sidebarType
        /// <summary>
        /// Specifies the width of the Sidebar. By default, the width of the Sidebar sets based on the size of its content.
        /// Width can also be set in pixel values.
        /// </summary>
        /// <default>'auto'</default>
        static member inline width (width: string) = Interop.mkAttr (nameof width) width
        /// <summary>Specifies the z-index of the Sidebar. It is applicable only when sidebar act as overlay type.</summary>
        /// <default>1000</default>
        static member inline zIndex (zIndex: string) = Interop.mkAttr (nameof zIndex) zIndex
        static member inline create(props: IReactProperty list) = Interop.reactApi.createElement (sidebar, createObj !!props)
