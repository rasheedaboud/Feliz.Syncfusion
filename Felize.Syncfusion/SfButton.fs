namespace Feliz.Syncfusion

module SfButton = 

    open Browser.Types
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


    type SfButton =
        /// <summary>
        /// Positions the icon before/after the text content in the Button.
        /// The possible values are:
        /// * Left: The icon will be positioned to the left of the text content.
        /// * Right: The icon will be positioned to the right of the text content.
        /// </summary>
        /// <default>"left"</default>
        static member inline iconPosition(iconPosition: IconPosition) = Interop.mkAttr "iconPosition" iconPosition
        /// <summary>
        /// Defines class/multiple classes separated by a space for the Button that is used to include an icon.
        /// Buttons can also include font icon and sprite image.
        /// </summary>
        /// <default>""</default>
        static member inline iconCss(iconCss: string)= Interop.mkAttr "iconCss" iconCss
        /// <summary>Specifies a value that indicates whether the Button is <c>disabled</c> or not.</summary>
        /// <default>false.</default>
        static member inline disabled(disabled: bool option )= Interop.mkAttr "disabled" disabled
        /// <summary>Allows the appearance of the Button to be enhanced and visually appealing when set to <c>true</c>.</summary>
        /// <default>false</default>
        static member inline isPrimary(isPrimary: bool option )= Interop.mkAttr "isPrimary" isPrimary
        /// <summary>
        /// Defines class/multiple classes separated by a space in the Button element. The Button types, styles, and
        /// size can be defined by using
        /// <see href="http://ej2.syncfusion.com/documentation/button/howto.html?lang=typescript#create-a-block-button"><c>this</c></see>.
        /// {% codeBlock src='button/cssClass/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        static member inline cssClass(cssClass: string)= Interop.mkAttr "cssClass" cssClass
        /// <summary>
        /// Defines the text <c>content</c> of the Button element.
        /// {% codeBlock src='button/content/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        static member inline content(content: string option )= Interop.mkAttr "content" content
        /// <summary>Makes the Button toggle, when set to <c>true</c>. When you click it, the state changes from normal to active.</summary>
        /// <default>false</default>
        static member inline isToggle(isToggle: bool option )= Interop.mkAttr "isToggle" isToggle
        /// <summary>Overrides the global culture and localization value for this component. Default global culture is 'en-US'.</summary>
        static member inline locale(locale: string option )= Interop.mkAttr "locale" locale
        /// <summary>Defines whether to allow the cross-scripting site or not.</summary>
        /// <default>false</default>
        static member inline enableHtmlSanitizer(enableHtmlSanitizer: bool option )= Interop.mkAttr "enableHtmlSanitizer" enableHtmlSanitizer

        ///
        ///Click the button element
        ///its native method
        ///
        ///@public
        ///@returns {void}
        ///
        static member inline close (callback: MouseEvent -> unit) = Interop.mkAttr "close" callback
         
        ///
        ///Sets the focus to Button
        ///its native method
        ///
        ///@public
        ///@returns {void}
        ///
        static member inline focusIn (callback: FocusEvent -> unit) = Interop.mkAttr "focusIn" callback


        static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (sfButton , createObj !!props)
