module SfInputs

[<AutoOpen>]
module Common = 

  open Browser.Types
  open Fable.Core


  type [<AllowNullLiteral>] BaseEventArgs =
    /// Specifies name of the event.
    abstract name: string option with get, set

  type [<AllowNullLiteral>] ChangedEventArgs<'a> =
    abstract  itemData: 'a option with get, set

    /// <summary>Defines the selected date of the Calendar.</summary>
    abstract value: 'a option with get, set
    /// Defines the multiple selected date of the Calendar.
    abstract values: ResizeArray<'a> option with get, set
    /// Specifies the original event arguments.
    abstract ``event``: U3<KeyboardEvent, MouseEvent, Event> option with get, set
    /// Defines the element.
    abstract element: U2<HTMLElement, HTMLInputElement> option with get, set
    /// If the event is triggered by interaction, it returns true. Otherwise, it returns false.
    abstract isInteracted: bool option with get, set
  ///Specifies whether to display the floating label above the input element. Possible values are: 
  ///Never: The label will never float in the input when the placeholder is available.
  ///Always: The floating label will always float above the input.
  ///Auto: The floating label will float above the input after focusing or entering a value in the input.
  ///Defaults to Syncfusion.EJ2.Inputs.FloatLabelType.Never
  type [<StringEnum>] [<RequireQualifiedAccess>] FloatLabelType =
    | [<CompiledName "Never">] Never
    | [<CompiledName "Always">] Always
    | [<CompiledName "Auto">] Auto

module FileUploader = 
    open System.Collections.Generic
    open Browser.Types
    open Fable.Core
    open Feliz
    open Fable.Core.JsInterop

    let uploader:obj= import "UploaderComponent " "@syncfusion/ej2-react-inputs" 

    type ValidationMessages = {
      minSize: string option;
      maxSize: string option;
    }

    type FileInfo = {
      name: string;
      rawFile: Blob
      size: int;
      status: string;
      ``type``: string;
      validationMessages: ValidationMessages;
      statusCode: string;
      fileSource: string option;
      list: HTMLElement option;
      input: HTMLInputElement option;
      id: string option;
    }


    type Events =
      | MouseEvent
      | TouchEvent
      | DragEvent
      | ClipboardEvent


    type SelectedEventArgs  = {

      event: Events
      cancel: bool;
      filesData: FileInfo[];
      isModified: bool;
      modifiedFilesData: FileInfo[];
      progressInterval: string;
      isCanceled: bool option;
      currentRequest: Dictionary<string,string> option
      customFormData: Dictionary<string,obj> option
    }


    type  FilesProp = {
      name: string;
      size: int;
      ``type``: string;
    }

    type Buttons = {
      browse:string option
      clear:string option
      upload:string option
    } with
      static member Default() = {
        browse= Some ""
        clear = Some ""
        upload = Some "" }

    type AsyncSettings = {
      saveUrl: string;
      removeUrl: string;
      chunkSize: int;
      retryCount: int;
      retryAfterDelay: int;
    }

    type MetaData = {
      chunkIndex: int;
      blob: string //| Blob  ;
      file: FileInfo;
      start: int;
      ``end``: int;
      retryCount: int;
      //request: Ajax;
    }


    [<Erase>]
    type FileUploader=
        static member inline fileUploader (children: #seq<ReactElement>) = Interop.reactElementWithChildren "UploaderComponent" children
        static member inline cssClass (cssClass: string) = Interop.mkAttr "cssClass" cssClass
        static member inline allowedExtensions (allowedExtensions: string) = Interop.mkAttr "allowedExtensions" allowedExtensions
        static member inline autoUpload (autoUpload: bool) = Interop.mkAttr "autoUpload" autoUpload
        static member inline maxFileSize (maxFileSize: int) = Interop.mkAttr "maxFileSize" maxFileSize
        static member inline multiple (multiple: bool) = Interop.mkAttr "multiple" multiple
        static member inline selected (selected: (SelectedEventArgs -> unit)) = Interop.mkAttr "selected" selected
        static member inline buttons (buttons: Buttons) = Interop.mkAttr "buttons" buttons
        static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (uploader, createObj !!props)

module SfDatePicker = 

  open Feliz
  open Fable.Core.JsInterop
  open Fable.Core
  open Fable.React
  open System


  let datePickerComponent    :obj = import "DatePickerComponent "    "@syncfusion/ej2-react-calendars"





  type changedArgs<'a> = {
    value:'a
  }

  type BlurEventModelBase<'a> = {
    changedArgs: changedArgs<'a>
  }

  type [<AllowNullLiteral>] BlurEventArgs<'a> =
    abstract model: BlurEventModelBase<'a> with get, set




  [<Erase>]
  type SfDatePicker=
      static member inline picker (children: #seq<ReactElement>) = Interop.reactElementWithChildren "DatePickerComponent " children
      static member inline placeholder (placeholder: string) = Interop.mkAttr "placeholder" placeholder
      static member inline cssClass (cssClass: string) = Interop.mkAttr "cssClass" cssClass
      static member inline format (format: string) = Interop.mkAttr "format" format
      static member inline readonly (readonly: bool) = Interop.mkAttr "readonly" readonly
      static member inline showClearButton (showClearButton: bool) = Interop.mkAttr "showClearButton" showClearButton
      static member inline strictMode (strictMode: bool) = Interop.mkAttr "strictMode" strictMode
      static member inline min (min: DateTime) = Interop.mkAttr "min" min
      static member inline max (max: DateTime) = Interop.mkAttr "max" max
      static member inline floatLabelType (floatLabelType: FloatLabelType) = Interop.mkAttr "floatLabelType" floatLabelType
      static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (datePickerComponent, createObj !!props)
      static member inline value (value: DateTime) = Interop.mkAttr "value" value
      static member inline change<'a> (callback: ChangedEventArgs<'a>-> unit) =Interop.mkAttr "change" callback 
      static member inline blur<'a> (callback: BlurEventArgs<'a>-> unit) = Interop.mkAttr "blur" callback 

module SfAutoComplete =

  open Feliz
  open Fable.Core.JsInterop

  importAll "@syncfusion/ej2-base/styles/bootstrap4.css";
  importAll "@syncfusion/ej2-react-inputs/styles/bootstrap4.css";
  importAll "@syncfusion/ej2-react-dropdowns/styles/bootstrap4.css";

  let autoComplete:obj= import "AutoCompleteComponent" "@syncfusion/ej2-react-dropdowns"

  
  
  
  type FieldSettingsModel ={
    /// <summary>Maps the text column from data table for each list item</summary>
    /// <default>null</default>
    text: string 
    /// <summary>Maps the value column from data table for each list item</summary>
    /// <default>null</default>
    value: string 
  }


  type SfAutoComplete =
    static member inline autoComplete (children: #seq<ReactElement>) = Interop.reactElementWithChildren "AutoCompleteComponent" children
    static member inline dataSource(data:'a[]) = Interop.mkAttr "dataSource" data
    static member inline enabled(enabled:bool) = Interop.mkAttr "enabled" enabled
    static member inline classes(classes:string list) = Interop.mkAttr "cssClass" (classes |> List.fold(fun x y -> $"{x} {y}") "")
    static member inline fields(fields:FieldSettingsModel) = Interop.mkAttr "fields" fields
    static member inline ignoreCase(ignoreCase:bool) = Interop.mkAttr "ignoreCase" ignoreCase
    static member inline floatLabelType(floatLabelType:FloatLabelType) = Interop.mkAttr "floatLabelType" floatLabelType
    static member inline placeholder(placeholder:string) = Interop.mkAttr "placeholder" placeholder
    static member inline allowCustom(allowCustom:bool) = Interop.mkAttr "allowCustom" allowCustom
    static member inline change<'a> (callback: ChangedEventArgs<'a> option -> unit) =Interop.mkAttr "change" callback 

    static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (autoComplete, createObj !!props)

module SfNumericTextBox =

  open System
  open Browser.Types
  open Fable.Core
  open Feliz
  open Fable.Core.JsInterop



  let numericTextBoxComponent :obj= import "NumericTextBoxComponent" "@syncfusion/ej2-react-inputs"

  [<StringEnum()>]
  [<RequireQualifiedAccess>]
  type CurrencyCode = 
    | AFN
    | EUR
    | ALL
    | DZD
    | USD
    | AOA
    | XCD
    | ARS
    | AMD
    | AWG
    | AUD
    | AZN
    | BSD
    | BHD
    | BDT
    | BBD
    | BYN
    | BZD
    | XOF
    | BMD
    | INR
    | BTN
    | BOB
    | BOV
    | BAM
    | BWP
    | NOK
    | BRL
    | BND
    | BGN
    | BIF
    | CVE
    | KHR
    | XAF
    | CAD
    | KYD
    | CLP
    | CLF
    | CNY
    | COP
    | COU
    | KMF
    | CDF
    | NZD
    | CRC
    | HRK
    | CUP
    | CUC
    | ANG
    | CZK
    | DKK
    | DJF
    | DOP
    | EGP
    | SVC
    | ERN
    | SZL
    | ETB
    | FKP
    | FJD
    | XPF
    | GMD
    | GEL
    | GHS
    | GIP
    | GTQ
    | GBP
    | GNF
    | GYD
    | HTG
    | HNL
    | HKD
    | HUF
    | ISK
    | IDR
    | XDR
    | IRR
    | IQD
    | ILS
    | JMD
    | JPY
    | JOD
    | KZT
    | KES
    | KPW
    | KRW
    | KWD
    | KGS
    | LAK
    | LBP
    | LSL
    | ZAR
    | LRD
    | LYD
    | CHF
    | MOP
    | MKD
    | MGA
    | MWK
    | MYR
    | MVR
    | MRU
    | MUR
    | XUA
    | MXN
    | MXV
    | MDL
    | MNT
    | MAD
    | MZN
    | MMK
    | NAD
    | NPR
    | NIO
    | NGN
    | OMR
    | PKR
    | PAB
    | PGK
    | PYG
    | PEN
    | PHP
    | PLN
    | QAR
    | RON
    | RUB
    | RWF
    | SHP
    | WST
    | STN
    | SAR
    | RSD
    | SCR
    | SLL
    | SGD
    | XSU
    | SBD
    | SOS
    | SSP
    | LKR
    | SDG
    | SRD
    | SEK
    | CHE
    | CHW
    | SYP
    | TWD
    | TJS
    | TZS
    | THB
    | TOP
    | TTD
    | TND
    | TRY
    | TMT
    | UGX
    | UAH
    | AED
    | USN
    | UYU
    | UYI
    | UYW
    | UZS
    | VUV
    | VES
    | VED
    | VND
    | YER
    | ZMW
    | ZWL
    | XBA
    | XBB
    | XBC
    | XBD
    | XTS
    | XXX
    | XAU
    | XPD
    | XPT
    | XAG

  [<RequireQualifiedAccess>]
  [<Erase>]
  type Values =
    | Double of double
    | Int32 of int32
    | Int64 of int64
    | Decimal of decimal
    | Float of float
     
  type [<AllowNullLiteral>] NumericBlurEventArgs =
    inherit BaseEventArgs
    /// Returns the original event arguments.
    abstract ``event``: U4<MouseEvent, FocusEvent, TouchEvent, KeyboardEvent> option with get, set
    /// <summary>Returns the value of the NumericTextBox.</summary>
    abstract value: Double with get, set
    /// Returns the NumericTextBox container element
    abstract container: HTMLElement option with get, set



  type ChangeEventArgs<'a> = {
    value:'a
  }

  type SfNumericTextBox =
    //static member inline numericTextBox (children: #seq<ReactElement>) = Interop.reactElementWithChildren "NumericTextBoxComponent" children
    ///Specifies the number precision applied to the textbox value when the NumericTextBox is focused. For more information on decimals, refer to decimals.
    static member inline decimals(decimals:int) = Interop.mkAttr "decimals" decimals
    ///Sets a value that enables or disables the NumericTextBox control.
    static member inline enabled(enabled:bool) = Interop.mkAttr "enabled" enabled
    ///Specifies the currency code to use in currency formatting. Possible values are the ISO 4217 currency codes, such as ‘USD’ for the US dollar,‘EUR’ for the euro.
    static member inline currency(currency:CurrencyCode) = Interop.mkAttr "currency" currency
    ///<summary>The placeholder acts as a label and floats above the NumericTextBox based on the below values. Possible values are:
    ///
    ///Never - Never floats the label in the NumericTextBox when the placeholder is available.
    ///Always - The floating label always floats above the NumericTextBox.
    ///Auto - The floating label floats above the NumericTextBox after focusing it or when enters the value in it.
    ///Defaults to Never</summary>
    ///<typeparam  name="FloatLabelType">description</typeparam >
    static member inline floatLabelType(floatLabelType:FloatLabelType) = Interop.mkAttr "floatLabelType" floatLabelType
    static member inline placeholder(placeholder:string) = Interop.mkAttr "placeholder" placeholder
    ///Specifies the number format that indicates the display format for the value of the NumericTextBox. For more information on formats, refer to formats.
    ///
    ///Defaults to ‘n2’
    static member inline format(format:string) = Interop.mkAttr "format" format
    ///<summary>Specifies a maximum value that is allowed a user can enter. For more information on max, refer to max.
    ///
    ///Defaults to null</summary>
    static member inline max(max:double) = Interop.mkAttr "max" max
    ///Specifies a minimum value that is allowed a user can enter. For more information on min, refer to min.
    ///
    ///Defaults to null
    static member inline min(min:double) = Interop.mkAttr "min" min
    ///<summary>
    ///Gets or Sets the CSS classes to root element of the NumericTextBox which helps to customize the complete UI styles for the NumericTextBox component.
    ///
    ///Defaults to null
    ///</summary>
    static member inline classes(classes:string list) = Interop.mkAttr "cssClass" (classes |> List.fold(fun x y -> $"{x} {y}") "")
    ///<summary>
    ///Sets a value that enables or disables the readonly state on the NumericTextBox. If it is true, NumericTextBox will not allow your input.
    ///
    ///Defaults to false
    ///</summary>
    static member inline readonly(readonly:bool) = Interop.mkAttr "readonly" readonly
    ///<summary>
    ///Specifies the incremental or decremental step size for the NumericTextBox. For more information on step, refer to step.  
    ///Defaults to 1
    ///</summary>
    static member inline step(step:double) = Interop.mkAttr "readonly" step
    ///<summary>
    ///Specifies a value that indicates whether the NumericTextBox control allows the value for the specified range.
    ///If it is true, the input value will be restricted between the min and max range. The typed value gets modified to fit the range on focused out state.
    ///Else, it allows any value even out of range value, At that time of wrong value entered, the error class will be added to the component to highlight the error.
    ///Defaults to true
    ///</summary>
    static member inline strictMode(strictMode:bool) = Interop.mkAttr "strictMode" strictMode
    ///<summary>
    ///Specifies whether the up and down spin buttons should be displayed in NumericTextBox.  
    ///Defaults to true
    ///</summary>
    static member inline showSpinButton(showSpinButton:bool) = Interop.mkAttr "showSpinButton" showSpinButton
    ///<summary>
    ///Sets the value of the NumericTextBox.
    ///
    ///Defaults to null
    ///</summary>
    static member inline value(value:Values) = Interop.mkAttr "value" value
    static member inline change<'a> (callback: ChangeEventArgs<'a>-> unit) =Interop.mkAttr "change" callback 
    static member inline blur<'a> (callback: NumericBlurEventArgs -> unit) = Interop.mkAttr "blur" callback
    static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (numericTextBoxComponent, createObj !!props)


module ProgressButton=

  open Fable.Core
  open Feliz
  open Fable.Core.JsInterop

  let progressButtonComponent:obj= import "ProgressButtonComponent" "@syncfusion/ej2-react-splitbuttons"

  /// Defines the spin position of progress button.
  type [<StringEnum>] [<RequireQualifiedAccess>] SpinPosition =
      | [<CompiledName "Left">] Left
      | [<CompiledName "Right">] Right
      | [<CompiledName "Top">] Top
      | [<CompiledName "Bottom">] Bottom
      | [<CompiledName "Center">] Center
  
  /// Defines the animation effect of progress button.
  type [<StringEnum>] [<RequireQualifiedAccess>] AnimationEffect =
      | [<CompiledName "None">] None
      | [<CompiledName "SlideLeft">] SlideLeft
      | [<CompiledName "SlideRight">] SlideRight
      | [<CompiledName "SlideUp">] SlideUp
      | [<CompiledName "SlideDown">] SlideDown
      | [<CompiledName "ZoomIn">] ZoomIn
      | [<CompiledName "ZoomOut">] ZoomOut

  type AnimationSettingsModel = {
    ///Specifies the duration taken to animate in ms.
    duration:int        
    ///Specifies the animation timing function. Defaults to 'ease'
    easing:string       
    ///Specifies the effect of animation.
    effect:AnimationEffect
  }

  [<Erase>]
  [<RequireQualifiedAccess>]
  type SpinWidth =
    | String of string
    | Double of double

  type SpinSettingsModel ={
    /// <summary>Sets the width of a spinner.</summary>
    /// <default>'16'</default>
    width: SpinWidth option 
    /// <summary>
    /// Specifies the position of a spinner in the progress button. The possible values are:
    /// * Left: The spinner will be positioned to the left of the text content.
    /// * Right: The spinner will be positioned to the right of the text content.
    /// * Top: The spinner will be positioned at the top of the text content.
    /// * Bottom: The spinner will be positioned at the bottom of the text content.
    /// * Center: The spinner will be positioned at the center of the progress button.
    /// </summary>
    /// <default>'Left'</default>
    position: SpinPosition 
  } with
    static member Default =
      {
        width=  SpinWidth.Double 16. |> Some
        position= SpinPosition.Left
      }

  type [<StringEnum>] [<RequireQualifiedAccess>] IconPosition =
    | [<CompiledName "Left">] Left
    | [<CompiledName "Right">] Right
    | [<CompiledName "Top">] Top
    | [<CompiledName "Bottom">] Bottom


  type [<AllowNullLiteral>] ProgressButtonComponent =
        /// <summary>Enables or disables the background filler UI in the progress button.</summary>
      /// <default>false</default>
      abstract enableProgress: bool with get, set
      /// <summary>Specifies the duration of progression in the progress button.</summary>
      /// <default>2000</default>
      abstract duration: float with get, set
      /// <summary>
      /// Positions an icon in the progress button. The possible values are:
      /// * Left: The icon will be positioned to the left of the text content.
      /// * Right: The icon will be positioned to the right of the text content.
      /// * Top: The icon will be positioned at the top of the text content.
      /// * Bottom: The icon will be positioned at the bottom of the text content.
      /// </summary>
      /// <default>"Left"</default>
      abstract iconPosition: IconPosition with get, set
      /// <summary>
      /// Defines class/multiple classes separated by a space for the progress button that is used to include an icon.
      /// Progress button can also include font icon and sprite image.
      /// </summary>
      /// <default>""</default>
      abstract iconCss: string with get, set
      /// <summary>Enables or disables the progress button.</summary>
      /// <default>false.</default>
      abstract disabled: bool with get, set
      /// <summary>Allows the appearance of the progress button to be enhanced and visually appealing when set to <c>true</c>.</summary>
      /// <default>false</default>
      abstract isPrimary: bool with get, set
      /// <summary>
      /// Specifies the root CSS class of the progress button that allows customization of component’s appearance.
      /// The progress button types, styles, and size can be achieved by using this property.
      /// </summary>
      /// <default>""</default>
      abstract cssClass: string with get, set
      /// <summary>Defines the text <c>content</c> of the progress button element.</summary>
      /// <default>""</default>
      abstract content: string with get, set
      /// <summary>Makes the progress button toggle, when set to <c>true</c>. When you click it, the state changes from normal to active.</summary>
      /// <default>false</default>
      abstract isToggle: bool with get, set
      /// <summary>Defines whether to allow the cross-scripting site or not.</summary>
      /// <default>false</default>
      abstract enableHtmlSanitizer: bool with get, set
      /// Specifies a spinner and its related properties.
      abstract spinSettings: SpinSettingsModel with get, set
      /// Specifies the animation settings.
      abstract animationSettings: AnimationSettingsModel with get, set
      abstract preRender: unit -> unit
      /// <summary>Initialize the Component rendering</summary>
      /// <returns />
      abstract render: unit -> unit
      /// <summary>Starts the button progress at the specified percent.</summary>
      /// <param name="percent">Starts the button progress at this percent.</param>
      /// <returns />
      abstract start: ?percent: float -> unit
      /// <summary>Stops the button progress.</summary>
      /// <returns />
      abstract stop: unit -> unit
      /// <summary>Complete the button progress.</summary>
      /// <returns />
      abstract progressComplete: unit -> unit
      /// <summary>Get component name.</summary>
      /// <returns>- Module Name</returns>
      abstract getModuleName: unit -> string
      /// <summary>Destroys the widget.</summary>
      /// <returns />
      abstract destroy: unit -> unit
      abstract wireEvents: unit -> unit
      abstract unWireEvents: unit -> unit
      /// <summary>
      /// Sets the focus to ProgressButton
      /// its native method
      /// </summary>
      /// <returns />
      abstract focusIn: unit -> unit


  /// <summary>
  ///   ProgressButton.create [
  ///     ProgressButton.animationSettings { duration=500;easing="ease" effect=AnimationEffect.SlideLeft } 
  /// 
  ///     ProgressButton.content "Click Me!"
  ///
  ///     prop.onClick (fun x -> Browser.Dom.console.log "I've been clicked ")
  ///
  ///   ]
  /// </summary>
  type ProgressButton =
     ///
     ///Defines the text `content` of the progress button element.
     ///
     ///defaults to  ""
     ///
    static member inline content (content: string) = Interop.mkAttr "content" content

    ///Specifies the animation settings.
    static member inline animationSettings (animationSettings: AnimationSettingsModel) = Interop.mkAttr "animationSettings" animationSettings
    ///Specifies the animation settings.
    static member inline spinSettings (spinSettings: SpinSettingsModel) = Interop.mkAttr "spinSettings" spinSettings

    static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (progressButtonComponent, createObj !!props)




module SfTextBox =

  open Fable.Core
  open Feliz
  open Fable.Core.JsInterop

  let textBox:obj= import "TextBoxComponent" "@syncfusion/ej2-react-inputs"

  [<StringEnum>]
  type AutoComplete =
    | On
    | Off
  
  type ChangedEventArgs = {
    value:string
  }

  type FocusOutEventArgs  = {
    value:string
  }

  type SfTextBox =
      /// <summary>Specifies the behavior of the TextBox such as text, password, email, etc.</summary>
      /// <default>'text'</default>
      static member inline ``type``(``type``: string)  = Interop.mkAttr "type" ``type``
      /// <summary>Specifies the boolean value whether the TextBox allows user to change the text.</summary>
      /// <default>false</default>
      static member inline readonly (readonly: bool) = Interop.mkAttr "readonly" readonly
      /// <summary>Sets the content of the TextBox.</summary>
      /// <default>null</default>
      static member inline value(value: string) = Interop.mkAttr "value" value
      /// <summary>
      /// Specifies the floating label behavior of the TextBox that the placeholder text floats above the TextBox based on the below values.
      /// Possible values are:
      /// * <c>Never</c> - The placeholder text should not be float ever.
      /// * <c>Always</c> - The placeholder text floats above the TextBox always.
      /// * <c>Auto</c> - The placeholder text floats above the TextBox while focusing or enter a value in Textbox.
      /// </summary>
      /// <default>Never</default>
      static member inline floatLabelType(floatLabelType: FloatLabelType)= Interop.mkAttr "floatLabelType" floatLabelType
      ///<summary>
      ///Gets or Sets the CSS classes to root element of the NumericTextBox which helps to customize the complete UI styles for the NumericTextBox component.
      ///
      ///Defaults to null
      ///</summary>
      static member inline cssClass(cssClass:string) = Interop.mkAttr "cssClass" cssClass//(classes |> List.fold(fun x y -> $"{x} {y}") "")
      /// <summary>
      /// Specifies the text that is shown as a hint/placeholder until the user focus or enter a value in Textbox.
      /// The property is depending on the floatLabelType property.
      /// </summary>
      /// <default>null</default>
      static member inline placeholder(placeholder: string)= Interop.mkAttr "placeholder" placeholder
      /// <summary>
      /// Specifies whether the browser is allow to automatically enter or select a value for the textbox.
      /// By default, autocomplete is enabled for textbox.
      /// Possible values are:
      /// <c>on</c> - Specifies that autocomplete is enabled.
      /// <c>off</c> - Specifies that autocomplete is disabled.
      /// </summary>
      /// <default>'on'</default>
      static member inline autocomplete(autocomplete: AutoComplete)  = Interop.mkAttr "autocomplete" autocomplete
      /// <summary>
      /// Specifies a boolean value that enable or disable the multiline on the TextBox.
      /// The TextBox changes from single line to multiline when enable this multiline mode.
      /// </summary>
      /// <default>false</default>
      static member inline multiline(multiline: bool) = Interop.mkAttr "multiline" multiline
      /// <summary>Specifies a Boolean value that indicates whether the TextBox allow user to interact with it.</summary>
      /// <default>true</default>
      static member inline enabled(enabled: bool) = Interop.mkAttr "enabled" enabled
      /// <summary>Specifies a Boolean value that indicates whether the clear button is displayed in Textbox.</summary>
      /// <default>false</default>
      static member inline showClearButton(showClearButton: bool)= Interop.mkAttr "showClearButton" showClearButton
      /// <summary>Enable or disable persisting TextBox state between page reloads. If enabled, the <c>value</c> state will be persisted.</summary>
      /// <default>false</default>
      static member inline enablePersistence(enablePersistence: bool)= Interop.mkAttr "enablePersistence" enablePersistence
      /// <summary>Specifies the width of the Textbox component.</summary>
      /// <default>null</default>
      static member inline width(width: U2<float, string>)= Interop.mkAttr "width" width
      /// <summary>Triggers when the content of TextBox has changed and gets focus-out.</summary>
      static member inline change(callback: ChangedEventArgs -> unit)  = Interop.mkAttr "change" callback
      /// <summary>Triggers when the TextBox has focus-out.</summary>
      static member inline blur(callback:FocusOutEventArgs-> unit)  = Interop.mkAttr "blur" callback

      static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (textBox, createObj !!props)
     

    