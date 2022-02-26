namespace Feliz.Syncfusion


module SfMenuBar = 

    open Feliz
    open Fable.Core
    open Fable.Core.JsInterop


    let menuBar:obj = import "MenuComponent " "@syncfusion/ej2-react-navigations"

    /// Interface for a class FieldSettings
    type FieldSettingsModel ={
        /// <summary>Specifies the itemId field for Menu item.</summary>
        /// <default>'id'</default>
        itemId: string list option  
        /// <summary>Specifies the parentId field for Menu item.</summary>
        /// <default>'parentId'</default>
        parentId: string list option 
        /// <summary>Specifies the text field for Menu item.</summary>
        /// <default>'text'</default>
        text: string list option 
        /// <summary>Specifies the css icon field for Menu item.</summary>
        /// <default>'iconCss'</default>
        iconCss: string list option 
        /// <summary>Specifies the Url field for Menu item.</summary>
        /// <default>'url'</default>
        url: string list option 
        /// <summary>Specifies the separator field for Menu item.</summary>
        /// <default>'separator'</default>
        separator: string list option 
        /// <summary>Specifies the children field for Menu item.</summary>
        /// <default>'items'</default>
        children: string list option }

    /// Menu animation effects
    type [<StringEnum>] [<RequireQualifiedAccess>] MenuEffect =
        | [<CompiledName "None">] None
        | [<CompiledName "SlideDown">] SlideDown
        | [<CompiledName "ZoomIn">] ZoomIn
        | [<CompiledName "FadeIn">] FadeIn

    type [<StringEnum>] [<RequireQualifiedAccess>] Orientation =
        | [<CompiledName "Horizontal">] Horizontal
        | [<CompiledName "Vertical">] Vertical

    /// Interface for a MenuAnimationSettings
    type MenuAnimationSettingsModel ={
        /// <summary>
        /// Specifies the effect that shown in the sub menu transform.
        /// The possible effects are:
        /// * None: Specifies the sub menu transform with no animation effect.
        /// * SlideDown: Specifies the sub menu transform with slide down effect.
        /// * ZoomIn: Specifies the sub menu transform with zoom in effect.
        /// * FadeIn: Specifies the sub menu transform with fade in effect.
        /// </summary>
        /// <default>'SlideDown'</default>
        effect: MenuEffect option 
        /// <summary>Specifies the time duration to transform object.</summary>
        /// <default>400</default>
        duration: float option 
        /// <summary>Specifies the easing effect applied while transform.</summary>
        /// <default>'ease'</default>
        easing: string option }

    /// Specifies menu items.
    type MenuItem ={
        /// <summary>
        /// Defines class/multiple classes separated by a space for the menu Item that is used to include an icon.
        /// Menu Item can include font icon and sprite image.
        /// </summary>
        /// <default>null</default>
        iconCss: string option
        /// <summary>Specifies the id for menu item.</summary>
        /// <default>''</default>
        id: string option
        /// <summary>Specifies separator between the menu items. Separator are either horizontal or vertical lines used to group menu items.</summary>
        /// <default>false</default>
        separator: bool 
        /// <summary>Specifies the sub menu items that is the array of MenuItem model.</summary>
        /// <default>[]</default>
        items: ResizeArray<MenuItem> option
        /// <summary>Specifies text for menu item.</summary>
        /// <default>''</default>
        text: string option
        /// <summary>Specifies url for menu item that creates the anchor link to navigate to the url provided.</summary>
        /// <default>''</default>
        url: string option }
        
    /// <summary>Base class for Menu and ContextMenu components.</summary>
    type [<AllowNullLiteral>] IMenuBar =
        /// <summary>This method is used to get the index of the menu item in the Menu based on the argument.</summary>
        /// <param name="item">item be passed to get the index | id to be passed to get the item index.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract getItemIndex: item: U2<MenuItem, string> * ?isUniqueId: bool -> ResizeArray<float>
        /// <summary>This method is used to set the menu item in the Menu based on the argument.</summary>
        /// <param name="item">item need to be updated.</param>
        /// <param name="id">id / text to be passed to update the item.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract setItem: item: MenuItem * ?id: string * ?isUniqueId: bool -> unit
        /// <summary>This method is used to enable or disable the menu items in the Menu based on the items and enable argument.</summary>
        /// <param name="items">Text items that needs to be enabled/disabled.</param>
        /// <param name="enable">Set <c>true</c>/<c>false</c> to enable/disable the list items.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract enableItems: items: string[] * ?enable: bool * ?isUniqueId: bool -> unit
        /// <summary>This method is used to show the menu items in the Menu based on the items text.</summary>
        /// <param name="items">Text items that needs to be shown.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract showItems: items: string[] * ?isUniqueId: bool -> unit
        /// <summary>This method is used to hide the menu items in the Menu based on the items text.</summary>
        /// <param name="items">Text items that needs to be hidden.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract hideItems: items: string[] * ?isUniqueId: bool -> unit
        /// <summary>It is used to remove the menu items from the Menu based on the items text.</summary>
        /// <param name="items">Text items that needs to be removed.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract removeItems: items: string[] * ?isUniqueId: bool -> unit
        /// <summary>It is used to insert the menu items after the specified menu item text.</summary>
        /// <param name="items">Items that needs to be inserted.</param>
        /// <param name="text">Text item after that the element to be inserted.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract insertAfter: items: MenuItem[] * text: string * ?isUniqueId: bool -> unit
        /// <summary>It is used to insert the menu items before the specified menu item text.</summary>
        /// <param name="items">Items that needs to be inserted.</param>
        /// <param name="text">Text item before that the element to be inserted.</param>
        /// <param name="isUniqueId">Set <c>true</c> if it is a unique id.</param>
        /// <returns />
        abstract insertBefore: items: MenuItem[] * text: string * ?isUniqueId: bool -> unit

    ///Requires use of @ref= 
    /// 
    ///Cast to type IMenuBar to control behaviour of the component
    ///
    /// 
    type SfMenuBar =
        ///Specifies the animation settings for the sub menu open.
        static member inline animationSettings(animationSettings:string) = Interop.mkAttr "animationSettings" animationSettings
        ///Defines whether to allow the cross-scripting site or not.
        static member inline enableHtmlSanitizer(enableHtmlSanitizer:bool) = Interop.mkAttr "enableHtmlSanitizer" enableHtmlSanitizer
        ///Defines class/multiple classes separated by a space in the Menu wrapper.
        static member inline cssClass(cssClass:string) = Interop.mkAttr "cssClass" cssClass
        static member inline enablePersistance(enablePersistance:bool) = Interop.mkAttr "enablePersistance" enablePersistance
        ///Enable or disable persisting component’s state between page reloads.
        static member inline enableScrolling(enableScrolling:bool) = Interop.mkAttr "enableScrolling" enableScrolling
        ///Specifies mapping fields from the dataSource.
        /// Defaults to { itemId: “id”, text: “text”, parentId: “parentId”, iconCss: “iconCss”, url: “url”, separator: “separator”,children: “items” }
        static member inline fields(fields:FieldSettingsModel) = Interop.mkAttr "fields" fields
        ///Specifies whether to enable / disable the hamburger mode in Menu.
        static member inline hamburgerMode(hamburgerMode:bool) = Interop.mkAttr "hamburgerMode" hamburgerMode
        ///Specifies menu items with its properties which will be rendered as Menu.
        static member inline items(items:MenuItem[]) = Interop.mkAttr "items" items
        ///Specified the orientation of Menu whether it can be horizontal or vertical.
        static member inline orientation(orientation:Orientation) = Interop.mkAttr "orientation" orientation
        ///Specifies the title text for hamburger mode in Menu.
        ///Defaults to ‘Menu’
        static member inline title(title:string) = Interop.mkAttr "title" title
    
        static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (menuBar , createObj !!props)

