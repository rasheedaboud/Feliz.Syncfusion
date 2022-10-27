namespace Syncfusion

module SfSplitButton = 

    open Feliz
    open Fable.Core
    open Fable.Core.JsInterop
    open Browser.Types

    let sfSplitButton:obj = import "SplitButtonComponent" "@syncfusion/ej2-react-splitbuttons"

    /// <summary>Common Event argument for all base Essential JavaScript 2 Events.</summary>
    type [<AllowNullLiteral>] BaseEventArgs =
        /// Specifies name of the event.
        abstract name: string option with get, set

    /// Defines the icon position of Split Button.
    type [<StringEnum>] [<RequireQualifiedAccess>] SplitButtonIconPosition =
        | [<CompiledName "Left">] Left
        | [<CompiledName "Top">] Top

    /// Interface for a class Item
    type ItemModel ={
        /// <summary>
        /// Defines class/multiple classes separated by a space for the item that is used to include an icon.
        /// Action item can include font icon and sprite image.
        /// </summary>
        /// <default>''</default>
        iconCss: string option 
        /// <summary>Specifies the id for item.</summary>
        /// <default>''</default>
        id: string option 
        /// <summary>Specifies separator between the items. Separator are horizontal lines used to group action items.</summary>
        /// <default>false</default>
        separator: bool option
        /// <summary>Specifies text for item.</summary>
        /// <default>''</default>
        text: string option 
        /// <summary>Specifies url for item that creates the anchor link to navigate to the url provided.</summary>
        /// <default>''</default>
        url: string option 
        /// <summary>Used to enable or disable the item.</summary>
        /// <default>false</default>
        disabled: bool option}

    /// Interface for before item render / select event.
    type [<AllowNullLiteral>] MenuEventArgs =
        inherit BaseEventArgs
        abstract element: HTMLElement with get, set
        abstract item: ItemModel with get, set

    /// Interface for before open / close event.
    type [<AllowNullLiteral>] BeforeOpenCloseMenuEventArgs =
        inherit BaseEventArgs
        abstract element: HTMLElement with get, set
        abstract items: ResizeArray<ItemModel> with get, set
        abstract ``event``: Event with get, set
        abstract cancel: bool option with get, set
    
    /// Interface for open/close event.
    type [<AllowNullLiteral>] OpenCloseMenuEventArgs =
        inherit BaseEventArgs
        abstract element: HTMLElement with get, set
        abstract items: ResizeArray<ItemModel> with get, set
        abstract parentItem: ItemModel option with get, set

    type SfSplitButton =

        /// <summary>Defines the content of the SplitButton primary action button can either be a text or HTML elements.</summary>
        /// <default>""</default>
        static member inline content(content: string) = Feliz.Interop.mkAttr "content" content
        /// <summary>
        /// Defines class/multiple classes separated by a space in the SplitButton element. The SplitButton
        /// size and styles can be customized by using this.
        /// </summary>
        /// <default>""</default>
        static member inline cssClass(cssClass: string) = Feliz.Interop.mkAttr "cssClass" cssClass
        /// <summary>Specifies a value that indicates whether the SplitButton is disabled or not.</summary>
        /// <default>false.</default>
        static member inline disabled(disabled: bool) = Feliz.Interop.mkAttr "disabled" disabled
        /// <summary>
        /// Defines class/multiple classes separated by a space for the SplitButton that is used to include an
        /// icon. SplitButton can also include font icon and sprite image.
        /// </summary>
        /// <default>""</default>
        static member inline iconCss(iconCss: string) = Feliz.Interop.mkAttr "iconCss" iconCss
        /// <summary>
        /// Positions the icon before/top of the text content in the SplitButton. The possible values are
        /// * Left: The icon will be positioned to the left of the text content.
        /// * Top: The icon will be positioned to the top of the text content.
        /// </summary>
        /// <default>"Left"</default>
        static member inline iconPosition(iconPosition: SplitButtonIconPosition) = Feliz.Interop.mkAttr "iconPosition" iconPosition
        /// <summary>Specifies the popup element creation on open.</summary>
        /// <default>false</default>
        static member inline createPopupOnClick(createPopupOnClick: bool) = Feliz.Interop.mkAttr "createPopupOnClick" createPopupOnClick
        /// <summary>Specifies action items with its properties which will be rendered as SplitButton secondary button popup.</summary>
        /// <default>[]</default>
        static member inline items(items: ResizeArray<ItemModel> )= Feliz.Interop.mkAttr "items" items
        /// <summary>Allows to specify the SplitButton popup item element.</summary>
        /// <default>""</default>
        static member inline target(target: string )= Feliz.Interop.mkAttr "target" target
        /// <summary>Triggers while rendering each Popup item of SplitButton.</summary>
        static member inline beforeItemRender(callback: (MenuEventArgs -> unit))= Feliz.Interop.mkAttr "beforeItemRender" callback
        /// <summary>Triggers before opening the SplitButton popup.</summary>
        static member inline beforeOpen(callback: (BeforeOpenCloseMenuEventArgs->unit))= Feliz.Interop.mkAttr "beforeOpen" callback
        /// <summary>Triggers before closing the SplitButton popup.</summary>
        static member inline beforeClose(callback: (BeforeOpenCloseMenuEventArgs->unit))= Feliz.Interop.mkAttr "beforeClose" callback
        /// <summary>Triggers when the primary button of SplitButton has been clicked.</summary>
        static member inline click(callback:(MouseEvent -> unit))=Feliz.Interop.mkAttr "click" callback
        /// <summary>Triggers while closing the SplitButton popup.</summary>
        static member inline close(callback: (OpenCloseMenuEventArgs-> unit))= Feliz.Interop.mkAttr "close" callback
        /// <summary>Triggers while opening the SplitButton popup.</summary>
        static member inline ``open``(callback: (OpenCloseMenuEventArgs-> unit))= Feliz.Interop.mkAttr "open" callback
        /// <summary>Triggers while selecting action item of SplitButton popup.</summary>
        static member inline select(callback: (MenuEventArgs-> unit))= Feliz.Interop.mkAttr "select" callback

        
        static member inline create (props:Feliz.IReactProperty list) = Feliz.Interop.reactApi.createElement (sfSplitButton , createObj !!props)



