module SfModal
open Feliz
open Fable.Core.JsInterop
open Fable.Core
open Fable.React
open Browser.Types
open Feliz.Styles



let DialogComponent:obj = import "DialogComponent" "@syncfusion/ej2-react-popups"

[<StringEnum>]
[<RequireQualifiedAccess>] 
type DialogEffect =
  | [<CompiledName "Fade">] Fade
  | [<CompiledName "FadeZoom">] FadeZoom
  | [<CompiledName "FlipLeftDown">] FlipLeftDown
  | [<CompiledName "FlipLeftUp">] FlipLeftUp
  | [<CompiledName "FlipRightDown">] FlipRightDown
  | [<CompiledName "FlipRightUp">] FlipRightUp
  | [<CompiledName "FlipXDown">] FlipXDown
  | [<CompiledName "FlipXUp">] FlipXUp
  | [<CompiledName "FlipYLeft">] FlipYLeft
  | [<CompiledName "FlipYRight">] FlipYRight
  | [<CompiledName "SlideBottom">] SlideBottom
  | [<CompiledName "SlideLeft">] SlideLeft
  | [<CompiledName "SlideRight">] SlideRight
  | [<CompiledName "SlideTop">] SlideTop
  | [<CompiledName "Zoom">] Zoom
  | [<CompiledName "None">] None

type AnimationSettingsModel ={
  effect: DialogEffect option
  duration: float option 
  delay: float option 
}



[<StringEnum(CaseRules.None)>]
[<RequireQualifiedAccess>] 
type ButtonType =
  |Button
  |Submit
  |Reset

[<StringEnum(CaseRules.None)>]
[<RequireQualifiedAccess>] 
type IconPosition =
  | Left
  | Right
  | Top
  | Bottom


type ButtonModel = {
    iconPosition: IconPosition;
    iconCss: string;
    disabled: bool;
    isPrimary: bool;
    cssClass: string;
    content: string;
    isToggle: bool;
}

type ButtonPropsModel = {
    isFlat: bool;
    buttonModel: ButtonModel;
    ``type``: ButtonType
    click: obj;
}


type  ComponentModel = {
    content: ReactElement option
    showCloseIcon: bool;
    isModal: bool;
    header: ReactElement option
    visible: bool;
    enableResize: bool;
    height: ICssUnit;
    minHeight: ICssUnit;
    width: ICssUnit;
    cssClass: string;
    target: HTMLElement 
    footerTemplate: HTMLElement option
    allowDragging: bool;
    buttons: ButtonPropsModel[];
    closeOnEscape: bool;
    animationSettings: AnimationSettingsModel;
    

}
type ButtonArgs = {
  click: (Event->unit) option;
}with
  static member Default callback = {
      click = Some callback;
  }
  //left, center, right
[<StringEnum(CaseRules.LowerFirst)>]
[<RequireQualifiedAccess>]
type Offset =
 | Left 
 | Center
 | Right

[<Erase>]
[<RequireQualifiedAccess>]
type Position =
 | Offset of Offset
 | Number of int

type PositionDataModel = {
    X: Position
    Y: Position
}

[<Erase>]
[<RequireQualifiedAccess>]
type Content =
 | String of string
 | Elelment of ReactElement

type  AlertDialogArgs = {
  title:string option
  content: Content;
  isModal: bool;
  isDraggable: bool;
  showCloseIcon: bool;
  closeOnEscape: bool;
  okButton: ButtonArgs;
  position: PositionDataModel;
  animationSettings: AnimationSettingsModel;
  cssClass: string;
  zIndex: int;
  ``open``: (Event->unit) option;
  close: (Event->unit) option;
}with
  static member Default(title, content, ok) = {
    title= Some title
    content= Content.String content;
    isModal= true;
    isDraggable= true;
    showCloseIcon= false;
    closeOnEscape= false;
    okButton= ok
    position= { X= Position.Number 0; Y=Position.Number 100 }
    animationSettings= {
            effect= DialogEffect.Fade |> Some
            duration= Some 1. 
            delay= Some 1. 
          }
    cssClass= "";
    zIndex= 1000;
    ``open``= None;
    close= None;
  }

type ConfirmDialogArgs = {
  title:string option
  content: Content;
  isModal: bool;
  isDraggable: bool;
  showCloseIcon: bool;
  closeOnEscape: bool;
  okButton: ButtonArgs
  cancelButton: ButtonArgs;
  position: PositionDataModel;
  animationSettings: AnimationSettingsModel;
  cssClass: string;
  zIndex: int;
  ``open``: (obj->unit) option;
  close: (obj->unit) option;
}with
  static member Default(title, content, ok,cancel) = {
    title= Some title
    content= Content.String content;
    isModal= true;
    isDraggable= true;
    showCloseIcon= false;
    closeOnEscape= false;
    okButton= ok
    cancelButton= cancel
    position= { X= Position.Number 0; Y=Position.Number 100 }
    animationSettings= {
            effect= DialogEffect.Fade |> Some
            duration= Some 1. 
            delay= Some 1. 
          }
    cssClass= "";
    zIndex= 1000;
    ``open``= None;
    close= None;
}

type [<AllowNullLiteral>] Dialog =
    /// <summary>
    /// Specifies the value that can be displayed in dialog's content area.
    /// It can be information, list, or other HTML elements.
    /// The content of dialog can be loaded with dynamic data such as database, AJAX content, and more.
    /// 
    /// {% codeBlock src="dialog/content-api/index.ts" %}{% endcodeBlock %}
    /// 
    /// {% codeBlock src="dialog/content-api/index.html" %}{% endcodeBlock %}
    /// </summary>
    /// <default>''</default>
    abstract content: U2<string, HTMLElement> with get, set
    /// <summary>Defines whether to allow the cross-scripting site or not.</summary>
    /// <default>true</default>
    abstract enableHtmlSanitizer: bool with get, set
    /// <summary>Specifies the value that represents whether the close icon is shown in the dialog component.</summary>
    /// <default>false</default>
    abstract showCloseIcon: bool with get, set
    /// <summary>
    /// Specifies the Boolean value whether the dialog can be displayed as modal or non-modal.
    /// * <c>Modal</c>: It creates overlay that disable interaction with the parent application and user should
    /// respond with modal before continuing with other applications.
    /// * <c>Modeless</c>: It does not prevent user interaction with parent application.
    /// </summary>
    /// <default>false</default>
    abstract isModal: bool with get, set
    /// <summary>
    /// Specifies the value that can be displayed in the dialog's title area that can be configured with plain text or HTML elements.
    /// This is optional property and the dialog can be displayed without header, if the header property is null.
    /// </summary>
    /// <default>''</default>
    abstract header: U2<string, HTMLElement> with get, set
    /// <summary>Specifies the value that represents whether the dialog component is visible.</summary>
    /// <default>true</default>
    abstract visible: bool with get, set
    /// <summary>
    /// Specifies the value whether the dialog component can be resized by the end-user.
    /// If enableResize is true, the dialog component creates grip to resize it diagonal direction.
    /// </summary>
    /// <default>false</default>
    abstract enableResize: bool with get, set

    /// <summary>Specifies the height of the dialog component.</summary>
    /// <default>'auto'</default>
    abstract height: U2<string, float> with get, set
    /// <summary>Specify the min-height of the dialog component.</summary>
    /// <default>''</default>
    abstract minHeight: U2<string, float> with get, set
    /// <summary>Specifies the width of the dialog.</summary>
    /// <default>'100%'</default>
    abstract width: U2<string, float> with get, set
    /// <summary>
    /// Specifies the CSS class name that can be appended with root element of the dialog.
    /// One or more custom CSS classes can be added to a dialog.
    /// </summary>
    /// <default>''</default>
    abstract cssClass: string with get, set
    /// <summary>Specifies the z-order for rendering that determines whether the dialog is displayed in front or behind of another component.</summary>
    /// <default>1000</default>
    abstract zIndex: float with get, set
    /// <summary>
    /// Specifies the target element in which to display the dialog.
    /// The default value is null, which refers the <c>document.body</c> element.
    /// </summary>
    /// <default>null</default>
    abstract target: U2<HTMLElement, string> with get, set
    /// <summary>
    /// Specifies the template value that can be displayed with dialog's footer area.
    /// This is optional property and can be used only when the footer is occupied with information or custom components.
    /// By default, the footer is configured with action <see cref="buttons">buttons</see>.
    /// If footer template is configured to dialog, the action buttons property will be disabled.
    /// 
    /// &gt; More information on the footer template configuration can be found on this <see cref="../../dialog/template/.footer">documentation</see> section.
    /// </summary>
    /// <default>''</default>
    abstract footerTemplate: U2<HTMLElement, string> with get, set
    /// <summary>
    /// Specifies the value whether the dialog component can be dragged by the end-user.
    /// The dialog allows to drag by selecting the header and dragging it for re-position the dialog.
    /// 
    /// &gt; More information on the draggable behavior can be found on this <see cref="../../dialog/getting-started/.draggable">documentation</see> section.
    /// 
    /// {% codeBlock src='dialog/allowDragging/index.md' %}{% endcodeBlock %}
    /// </summary>
    /// <default>false</default>
    abstract allowDragging: bool with get, set
    /// <summary>
    /// Configures the action <c>buttons</c> that contains button properties with primary attributes and click events.
    /// One or more action buttons can be configured to the dialog.
    /// 
    /// &gt; More information on the button configuration can be found on this
    /// <see cref="../../dialog/getting-started/.enable-footer">documentation</see> section.
    /// 
    /// {% codeBlock src="dialog/buttons-api/index.ts" %}{% endcodeBlock %}
    /// 
    /// {% codeBlock src="dialog/buttons-api/index.html" %}{% endcodeBlock %}
    /// 
    /// {% codeBlock src='dialog/buttons/index.md' %}{% endcodeBlock %}
    /// </summary>
    /// <default>[{}]</default>
    abstract buttons: ResizeArray<ButtonPropsModel> with get, set
    /// <summary>
    /// Specifies the boolean value whether the dialog can be closed with the escape key
    /// that is used to control the dialog's closing behavior.
    /// </summary>
    /// <default>true</default>
    abstract closeOnEscape: bool with get, set
    /// <summary>
    /// Specifies the animation settings of the dialog component.
    /// The animation effect can be applied on open and close the dialog with duration and delay.
    /// 
    /// &gt; More information on the animation settings in dialog can be found on this <see cref="../../dialog/animation/">documentation</see>  section.
    /// 
    /// {% codeBlock src="dialog/animation-api/index.ts" %}{% endcodeBlock %}
    /// 
    /// {% codeBlock src="dialog/animation-api/index.html" %}{% endcodeBlock %}
    /// 
    /// {% codeBlock src='dialog/animationSettings/index.md' %}{% endcodeBlock %}
    /// </summary>
    /// <default>{ effect: 'Fade', duration: 400, delay:0 }</default>
    abstract animationSettings: AnimationSettingsModel with get, set
    /// <summary>
    /// Specifies the value where the dialog can be positioned within the document or target.
    /// The position can be represented with pre-configured positions or specific X and Y values.
    /// * <c>X value</c>: left, center, right, or offset value.
    /// * <c>Y value</c>: top, center, bottom, or offset value.
    /// 
    /// &gt; More information on the positioning in dialog can be found on this <see cref="../../dialog/getting-started/.positioning">documentation</see>  section.
    /// 
    /// {% codeBlock src='dialog/position/index.md' %}{% endcodeBlock %}
    /// </summary>
    /// <default>{ X: 'center', Y: 'center' }</default>
    abstract position: PositionDataModel with get, set
    /// <summary>Event triggers when the dialog is created.</summary>
    abstract created: obj with get, set
    /// <summary>Event triggers when a dialog is opened.</summary>
    abstract ``open``: obj with get, set

    /// <summary>Event triggers after the dialog has been closed.</summary>
    abstract close: obj with get, set

    /// <summary>Initialize the control rendering</summary>
    /// <returns />
    abstract render: unit -> unit
    /// <summary>Initialize the event handler</summary>
    /// <returns />
    abstract preRender: unit -> unit
    abstract sanitizeHelper: value: string -> string
    /// <summary>Module required function</summary>
    /// <returns />
    abstract getModuleName: unit -> string

    /// <summary>Get the properties to be maintained in the persisted state.</summary>
    /// <returns />
    abstract getPersistData: unit -> string
    /// <summary>To destroy the widget</summary>
    /// <returns />
    abstract destroy: unit -> unit
    /// <summary>Refreshes the dialog's position when the user changes its header and footer height/width dynamically.</summary>
    /// <returns />
    abstract refreshPosition: unit -> unit

    /// <summary>
    /// Opens the dialog if it is in hidden state.
    /// To open the dialog with full screen width, set the parameter to true.
    /// </summary>
    /// <param name="isFullScreen">Enable the fullScreen Dialog.</param>
    /// <returns />
    abstract show: ?isFullScreen: bool -> unit
    /// <summary>Closes the dialog if it is in visible state.</summary>
    /// <param name="event">specifies the event</param>
    /// <returns />
    abstract hide: ?``event``: Event -> unit




/////REQUIRED TO USE MODAL METHODS
//let setModalRef =
//  (fun (element:Element) ->
//    if not (isNull element) then
//      modal.current <- Some element)
//
//let showModal =
//  fun () ->
//    SfModal.show(modal.current)
//
//let hideModal =
//  fun (event) ->
//    console.log event
//    SfModal.hide(modal.current)
//
//Html.button [
//  prop.text "Hide"
//  prop.onClick (fun x -> hideModal())
//]
//Html.button [
//  prop.text "Show"
//  prop.onClick (fun x -> showModal())
//]

//SfModal.create [
//  prop.ref setModalRef
//  SfModal.visible true
//  SfModal.isModal true
//  SfModal.header "This is a Header"
//  SfModal.width <| length.em 50
//  prop.children [Html.div[prop.text "This is come content"]]
//]


module SfModal =
  let inline hide(el:Element option) = if el.IsSome then el?hide()
  let inline show(el:Element option,isFullScreen:bool) = if el.IsSome then el?show(isFullScreen)

[<Erase>]
type SfModal =
    static member inline SfModal xs = Interop.createElement "DialogComponent" xs
    static member inline SfModal (children: #seq<ReactElement>) = Interop.reactElementWithChildren "DialogComponent" children
    static member inline showCloseIcon(showCloseIcon: bool)                           = Interop.mkAttr "showCloseIcon"  showCloseIcon
    static member inline isModal(isModal: bool)                                       = Interop.mkAttr "isModal"  isModal
    static member inline header(header: string)                                       = Interop.mkAttr "header"  header
    static member inline position(position: PositionDataModel)                        = Interop.mkAttr "position"  position
    static member inline visible(visible: bool)                                       = Interop.mkAttr "visible"  visible
    static member inline enableResize(enableResize: bool)                             = Interop.mkAttr "enableResize"  enableResize
    static member inline height(height: ICssUnit)                                     = Interop.mkAttr "height"  height
    static member inline minHeight( minHeight: ICssUnit)                              = Interop.mkAttr "minHeight"  minHeight
    static member inline width(width: ICssUnit)                                       = Interop.mkAttr "width"  width
    static member inline cssClass(cssClass: string)                                   = Interop.mkAttr "cssClass"  cssClass
    static member inline target(target: HTMLElement )                                 = Interop.mkAttr "target"  target
    static member inline footerTemplate(footerTemplate: HTMLElement option)           = Interop.mkAttr "footerTemplate"  footerTemplate
    static member inline allowDragging(allowDragging: bool)                           = Interop.mkAttr "allowDragging"  allowDragging
    static member inline buttons(buttons: ButtonPropsModel[])                         = Interop.mkAttr "buttons"  buttons
    static member inline closeOnEscape(closeOnEscape: bool)                           = Interop.mkAttr "closeOnEscape"  closeOnEscape
    static member inline animationSettings(animationSettings: AnimationSettingsModel) = Interop.mkAttr "animationSettings"  animationSettings
    static member inline close callback                                 = prop.custom("close",fun x -> x.close |> callback)
    

    static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (DialogComponent , createObj !!props)






//let modal = React.useRef(None)

//let hideModal =
//  fun (event) ->
//    DO SOMETHING VERY IMPORTANT HERE
//    console.log event
//    let modal:Dialog= modal2.current.Value
//    modal.hide()


//let showModal =
//  fun () ->
//    let opts = ConfirmDialogArgs.Default("Test","Some Content",{click=Some hideModal},{click=Some hideModal})
//    let dia = DialogUtility.confirm(opts)

//    modal.current <- Some dia

[<Import("DialogUtility ","@syncfusion/ej2-react-popups")>]
[<Erase>]
type DialogUtility =
  static member alert(args:AlertDialogArgs):Dialog = jsNative
  static member alert(args:string):Dialog = jsNative
  static member confirm(args:ConfirmDialogArgs):Dialog = jsNative
  static member confirm(args:string):Dialog = jsNative