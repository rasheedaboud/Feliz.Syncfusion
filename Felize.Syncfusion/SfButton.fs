namespace Syncfusion

module SfButton =

    open Feliz
    open Fable.Core
    open Fable.Core.JsInterop


    let sfButton:obj = import "ButtonComponent  " "@syncfusion/ej2-react-buttons"


    /// Defines the icon position of button.
    type [<StringEnum>] [<RequireQualifiedAccess>] IconPosition =
        | [<CompiledName "Left">] Left
        | [<CompiledName "Right">] Right
        | [<CompiledName "Top">] Top
        | [<CompiledName "Bottom">] Bottom



    /// The Button is a graphical user interface element that triggers an event on its click action. It can contain a text, an image, or both.
    /// <code lang="html">
    /// <button id="button">Button</button>
    /// </code>
    /// <code lang="typescript">
    /// <script>
    /// var btnObj = new Button();
    /// btnObj.appendTo("#button");
    /// </script>
    /// </code>
    type SfButton  =
        /// <summary>
        /// Positions the icon before/after the text content in the Button.
        /// The possible values are:
        /// * Left: The icon will be positioned to the left of the text content.
        /// * Right: The icon will be positioned to the right of the text content.
        /// </summary>
        /// <default>"left"</default>
        static member inline iconPosition (iconPosition: IconPosition) = Feliz.Interop.mkAttr (nameof iconPosition) iconPosition
        /// <summary>
        /// Defines class/multiple classes separated by a space for the Button that is used to include an icon.
        /// Buttons can also include font icon and sprite image.
        /// </summary>
        /// <default>""</default>
        static member inline iconCss (iconCss: string) = Feliz.Interop.mkAttr (nameof iconCss) iconCss
        /// <summary>Specifies a value that indicates whether the Button is <c>disabled</c> or not.</summary>
        /// <default>false.</default>
        static member inline disabled(disabled: bool) = Feliz.Interop.mkAttr (nameof disabled) disabled
        /// <summary>Allows the appearance of the Button to be enhanced and visually appealing when set to <c>true</c>.</summary>
        /// <default>false</default>
        static member inline isPrimary (isPrimary: bool) = Feliz.Interop.mkAttr (nameof isPrimary) isPrimary
        /// <summary>
        /// Defines class/multiple classes separated by a space in the Button element. The Button types, styles, and
        /// size can be defined by using
        /// <see href="http://ej2.syncfusion.com/documentation/button/howto.html?lang=typescript#create-a-block-button"><c>this</c></see>.
        /// {% codeBlock src='button/cssClass/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        static member inline cssClass(cssClass: string) = Feliz.Interop.mkAttr (nameof cssClass) cssClass
        /// <summary>
        /// Defines the text <c>content</c> of the Button element.
        /// {% codeBlock src='button/content/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        static member inline content(content: string) = Feliz.Interop.mkAttr (nameof content) content
        /// <summary>Makes the Button toggle, when set to <c>true</c>. When you click it, the state changes from normal to active.</summary>
        /// <default>false</default>
        static member inline isToggle (isToggle: bool) = Feliz.Interop.mkAttr (nameof isToggle) isToggle
        /// <summary>Overrides the global culture and localization value for this component. Default global culture is 'en-US'.</summary>
        static member inline locale (locale: string) = Feliz.Interop.mkAttr (nameof locale) locale
        /// <summary>Defines whether to allow the cross-scripting site or not.</summary>
        /// <default>false</default>
        static member inline enableHtmlSanitizer(enableHtmlSanitizer: bool) = Feliz.Interop.mkAttr (nameof enableHtmlSanitizer) enableHtmlSanitizer

        static member inline preRender(preRender: unit -> unit) = Feliz.Interop.mkAttr (nameof preRender) preRender
        /// <summary>Initialize the control rendering</summary>
        /// <returns />
        static member inline render (render: unit -> unit) = Feliz.Interop.mkAttr (nameof render) render
        static member inline wireEvents(wireEvents: unit -> unit) = Feliz.Interop.mkAttr (nameof wireEvents) wireEvents
        static member inline unWireEvents(unWireEvents: unit -> unit) = Feliz.Interop.mkAttr (nameof unWireEvents) unWireEvents
        /// <summary>Destroys the widget.</summary>
        /// <returns />
        static member inline destroy(destroy: unit -> unit) = Feliz.Interop.mkAttr (nameof destroy) destroy
        /// <summary>Get component name.</summary>
        /// <returns>- Module name</returns>
        static member inline getModuleName(getModuleName: unit -> string) = Feliz.Interop.mkAttr (nameof getModuleName) getModuleName
        /// <summary>Get the properties to be maintained in the persisted state.</summary>
        /// <returns>- Persist Data</returns>
        static member inline getPersistData(getPersistData: unit -> string) = Feliz.Interop.mkAttr (nameof getPersistData) getPersistData
        /// <summary>
        /// Click the button element
        /// its native method
        /// </summary>
        /// <returns />
        static member inline click(click: unit -> unit) = Feliz.Interop.mkAttr (nameof click) click
        /// <summary>
        /// Sets the focus to Button
        /// its native method
        /// </summary>
        /// <returns />
        static member inline focusIn (focusIn: unit -> unit) = Feliz.Interop.mkAttr (nameof focusIn) focusIn
        static member inline create (props:Feliz.IReactProperty list) = Feliz.Interop.reactApi.createElement (sfButton , createObj !!props)


