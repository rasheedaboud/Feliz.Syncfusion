namespace Feliz.Syncfusion


[<AutoOpen>]
module SfListView =

    open Feliz
    open Fable.Core
    open SfInputs
    open Fable.Core.JsInterop

    
    let listViewComponent   :obj = import "ListViewComponent "    "@syncfusion/ej2-react-lists"

    type [<AllowNullLiteral>] ListViewModelHtmlAttributes =
        [<EmitIndexer>] abstract Item: key: string -> string with get, set

    /// An enum type that denotes the position of checkbox of the ListView. Available options are as follows Left and Right;
    type [<StringEnum>] [<RequireQualifiedAccess>] CheckBoxPosition =
    | [<CompiledName("Left")>] Left
    | [<CompiledName("Right")>] Right

    type [<AllowNullLiteral>] SelectedItemData =
        [<EmitIndexer>] abstract Item: key: string -> obj with get, set

    type [<AllowNullLiteral>] SelectedItem =
        /// It denotes the selected item text.
        abstract text: string with get, set
        /// <summary>It denotes the selected item dataSource JSON object.</summary>
        abstract data: U3<SelectedItemData, ResizeArray<string>, ResizeArray<float>> with get, set

    [<Erase>]
    type SelectEvent =
        | MouseEvent of Browser.Types.MouseEvent
        | KeyboardEvent of Browser.Types.KeyboardEvent

    /// An interface that holds selected event arguments
    type [<AllowNullLiteral>] SelectEventArgs =
        inherit BaseEventArgs
        inherit SelectedItem
        /// Specifies that event has triggered by user interaction.
        abstract isInteracted: bool with get, set
        /// Specifies that event argument when event raised by other event.
        abstract ``event``: SelectEvent with get, set
        /// It is used to denote the index of the selected element.
        abstract index: float with get, set
        /// It is used to check whether the element is checked or not.
        abstract isChecked: bool option with get, set
        /// Cancels the item selection if the value is true
        abstract cancel: bool with get, set


    type [<AllowNullLiteral>] ListViewModelDataSource =
        [<EmitIndexer>] abstract Item: key: string -> obj with get, set


    /// Sorting Order
    type [<StringEnum>] [<RequireQualifiedAccess>] SortOrder =
        | [<CompiledName("None")>] None
        | [<CompiledName("Ascending")>] Ascending
        | [<CompiledName("Descending")>] Descending

    /// An enum type that denotes the effects of the ListView. Available options are as follows None, SlideLeft, SlideDown, Zoom, Fade;
    type [<StringEnum>] [<RequireQualifiedAccess>] ListViewEffect =
        | [<CompiledName("None")>] None
        | [<CompiledName("SlideLeft")>] SlideLeft
        | [<CompiledName("SlideDown")>] SlideDown
        | [<CompiledName("Zoom")>] Zoom
        | [<CompiledName("Fade")>] Fade

    /// An interface that holds animation settings.
    type [<AllowNullLiteral>] AnimationSettings =
        /// It is used to specify the effect which is shown in sub list transform.
        abstract effect: ListViewEffect option with get, set
        /// It is used to specify the time duration of transform object.
        abstract duration: float option with get, set
        /// It is used to specify the easing effect applied while transform
        abstract easing: string option with get, set


    /// Interface for a class FieldSettings
    type FieldSettingsModel = {
        /// Specifies the id field mapped in dataSource.
        id: string option
        /// <summary>The <c>text</c> property is used to map the text value from the data source for each list item.</summary>
        text: string option
        /// <summary>The <c>isChecked</c> property is used to check whether the list items are in checked state or not.</summary>
        isChecked: string option
        /// <summary>The <c>isVisible</c> property is used to check whether the list items are in visible state or not.</summary>
        isVisible: string option
        /// Specifies the enabled state of the ListView component.
        /// And, we can disable the component using this property by setting its value as false.
        enabled: string option
        /// <summary>
        /// The <c>iconCss</c> is used to customize the icon to the list items dynamically.
        ///   We can add a specific image to the icons using <c>iconCss</c> property.
        /// </summary>
        iconCss: string option
        /// <summary>The <c>child</c> property is used for nested navigation of listed items.</summary>
        child: string option
        /// <summary>The <c>tooltip</c> is used to display the information about the target element while hovering on list items.</summary>
        tooltip: string option
        /// <summary>The <c>groupBy</c> property is used to wraps the ListView elements into a group.</summary>
        groupBy: string option
        /// <summary>The <c>sortBy</c> property used to enable the sorting of list items to be ascending or descending order.</summary>
        sortBy: string option
        /// <summary>
        /// The <c>htmlAttributes</c> allows additional attributes such as id, class, etc., and
        ///   accepts n number of attributes in a key-value pair format.
        /// </summary>
        htmlAttributes: string option
        /// <summary>Specifies the <c>tableName</c> used to fetch data from a specific table in the server.</summary>
        tableName: string option
    }
        with static member create (id:string,text:string,child:string) =

                let idisnull = System.String.IsNullOrEmpty(id)
                let nameisnull  = System.String.IsNullOrEmpty(text)
                let childisnull  = System.String.IsNullOrEmpty(child)
                let id,text ,child=
                    match (idisnull,nameisnull,childisnull) with
                    | false,false,false -> (Some id, Some text,Some child)
                    | true,false,false  -> (None, Some text,Some child)
                    | false,true,false  -> (Some id, None,Some child)
                    | false,false,true  -> (Some id, Some text,None)
                    | true,true,false   ->  (None, None,Some child)
                    | false,true,true   ->  (Some id, None,None)
                    | true,true,true    ->  (None, None,None)
                    | _,_,true  ->  (Some id, None,None)
                {
                    id= id
                    text= text
                    isChecked= None
                    isVisible= None
                    enabled= None
                    iconCss= None
                    child= child
                    tooltip= None
                    groupBy= None
                    sortBy= None
                    htmlAttributes= None
                    tableName= None
                }


    [<Erase>]
    type Width =
        | String of string
        | Float of float

    [<Erase>]
    type Height =
        | String of string
        | Float of float


    /// Interface for a class ListView
    type [<AllowNullLiteral>] IListViewModel =
        /// <summary>
        /// The <c>cssClass</c> property is used to add a user-preferred class name in the root element of the ListView,
        ///   using which we can customize the component (both CSS and functionality customization)
        ///
        /// {% codeBlock src='listview/cssClass/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        abstract cssClass: string option with get, set
        /// <summary>
        /// If <c>enableVirtualization</c> set to true, which will increase the ListView performance, while loading a large amount of data.
        ///
        /// {% codeBlock src='listview/enableVirtualization/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract enableVirtualization: bool option with get, set
        /// <summary>
        /// The <c>htmlAttributes</c> allows additional attributes such as id, class, etc., and
        ///   accepts n number of attributes in a key-value pair format.
        ///
        /// {% codeBlock src='listview/htmlAttributes/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{}</default>
        abstract htmlAttributes: ListViewModelHtmlAttributes option with get, set
        /// <summary>
        /// If <c>enable</c> set to true, the list items are enabled.
        /// And, we can disable the component using this property by setting its value as false.
        ///
        /// {% codeBlock src='listview/enable/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>true</default>
        abstract enable: bool option with get, set
        /// <summary>The <c>dataSource</c> provides the data to render the ListView component which is mapped with the fields of ListView.</summary>
        /// <default>[]</default>
        abstract dataSource: 'a[] option with get, set
        /// <summary>
        /// The <c>fields</c> is used to map keys from the dataSource which extracts the appropriate data from the dataSource
        ///   with specified mapped with the column fields to render the ListView.
        ///
        /// {% codeBlock src='listview/fields/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>defaultMappedFields</default>
        abstract fields: FieldSettingsModel option with get, set
        /// <summary>
        /// The <c>animation</c> property provides an option to apply the different
        ///   animations on the ListView component.
        ///
        /// {% codeBlock src='listview/animation/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{ effect: 'SlideLeft', duration: 400, easing: 'ease' }</default>
        abstract animation: AnimationSettings option with get, set
        /// <summary>
        /// The <c>sortOrder</c> is used to sort the data source. The available type of sort orders are,
        /// * <c>None</c> - The data source is not sorting.
        /// * <c>Ascending</c> - The data source is sorting with ascending order.
        /// * <c>Descending</c> - The data source is sorting with descending order.
        ///
        /// {% codeBlock src='listview/sortOrder/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'None'</default>
        abstract sortOrder: SortOrder option with get, set
        /// <summary>
        /// If <c>showIcon</c> set to true, which will show or hide the icon of the list item.
        ///
        /// {% codeBlock src='listview/showIcon/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract showIcon: bool option with get, set
        /// <summary>
        /// If <c>showCheckBox</c> set to true, which will show or hide the checkbox.
        ///
        /// {% codeBlock src='listview/showCheckBox/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract showCheckBox: bool option with get, set
        /// <summary>
        /// The <c>checkBoxPosition</c> is used to set the position of check box in a list item.
        /// By default, the <c>checkBoxPosition</c> is Left, which will appear before the text content in a list item.
        ///
        /// {% codeBlock src='listview/checkBoxPosition/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'Left'</default>
        abstract checkBoxPosition: CheckBoxPosition option with get, set
        /// <summary>
        /// The <c>headerTitle</c> is used to set the title of the ListView component.
        ///
        /// {% codeBlock src='listview/headerTitle/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        abstract headerTitle: string option with get, set
        /// <summary>
        /// If <c>showHeader</c> set to true, which will show or hide the header of the ListView component.
        ///
        /// {% codeBlock src='listview/showHeader/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract showHeader: bool option with get, set
        /// <summary>
        /// If <c>enableHtmlSanitizer</c> set to true, allows the cross-scripting site.
        ///
        /// {% codeBlock src='listview/enableHtmlSanitizer/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract enableHtmlSanitizer: bool option with get, set
        /// <summary>
        /// Defines the height of the ListView component which accepts both string and number values.
        ///
        /// {% codeBlock src='listview/height/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        abstract height: Height with get, set
        /// <summary>
        /// Defines the width of the ListView component which accepts both string and number values.
        ///
        /// {% codeBlock src='listview/width/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        abstract width: Width option with get, set
        /// <summary>
        /// The ListView component supports to customize the content of each list items with the help of <c>template</c> property.
        ///
        /// {% codeBlock src='listview/template/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        abstract template: string option with get, set
        /// <summary>
        /// The ListView has an option to custom design the ListView header title with the help of <c>headerTemplate</c> property.
        ///
        /// {% codeBlock src="listview/headerTemplate/index.md" %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        abstract headerTemplate: string option with get, set
        /// <summary>
        /// The ListView has an option to custom design the group header title with the help of <c>groupTemplate</c> property.
        ///
        /// {% codeBlock src="listview/groupTemplate/index.md" %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        abstract groupTemplate: string option with get, set
        /// <summary>Triggers when we select the list item in the component.</summary>
        abstract select: (unit -> SelectEventArgs option) with get, set
        /// <summary>Triggers when every ListView action starts.</summary>
        abstract actionBegin: (unit -> obj) option with get, set
        /// <summary>Triggers when every ListView actions completed.</summary>
        abstract actionComplete: (unit -> Browser.Types.MouseEvent) option with get, set
        /// <summary>Triggers, when the data fetch request from the remote server, fails.</summary>
        abstract actionFailure: (unit -> Browser.Types.MouseEvent) option with get, set


    type SfListView =
        /// <summary>
        /// The <c>cssClass</c> property is used to add a user-preferred class name in the root element of the ListView,
        ///   using which we can customize the component (both CSS and functionality customization)
        ///
        /// {% codeBlock src='listview/cssClass/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        static member inline  cssClass (cssClass: string) = Interop.mkAttr (nameof cssClass) cssClass
        /// <summary>
        /// If <c>enableVirtualization</c> set to true, which will increase the ListView performance, while loading a large amount of data.
        ///
        /// {% codeBlock src='listview/enableVirtualization/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        static member inline  enableVirtualization(enableVirtualization: bool) = Interop.mkAttr (nameof enableVirtualization) enableVirtualization
        /// <summary>
        /// The <c>htmlAttributes</c> allows additional attributes such as id, class, etc., and
        ///   accepts n number of attributes in a key-value pair format.
        ///
        /// {% codeBlock src='listview/htmlAttributes/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{}</default>
        static member inline  htmlAttributes(htmlAttributes: ListViewModelHtmlAttributes) = Interop.mkAttr (nameof htmlAttributes) htmlAttributes
        /// <summary>
        /// If <c>enable</c> set to true, the list items are enabled.
        /// And, we can disable the component using this property by setting its value as false.
        ///
        /// {% codeBlock src='listview/enable/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>true</default>
        static member inline  enable(enable: bool) = Interop.mkAttr (nameof enable) enable
        /// <summary>The <c>dataSource</c> provides the data to render the ListView component which is mapped with the fields of ListView.</summary>
        /// <default>[]</default>
        static member inline  dataSource<'a>(dataSource: 'a[] )= Interop.mkAttr (nameof dataSource) dataSource
        /// <summary>
        /// The <c>fields</c> is used to map keys from the dataSource which extracts the appropriate data from the dataSource
        ///   with specified mapped with the column fields to render the ListView.
        ///
        /// {% codeBlock src='listview/fields/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>defaultMappedFields</default>
        static member inline  fields(fields: FieldSettingsModel) = Interop.mkAttr (nameof fields) fields
        /// <summary>
        /// The <c>animation</c> property provides an option to apply the different
        ///   animations on the ListView component.
        ///
        /// {% codeBlock src='listview/animation/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{ effect: 'SlideLeft', duration: 400, easing: 'ease' }</default>
        static member inline  animation(animation: AnimationSettings) = Interop.mkAttr (nameof animation) animation
        /// <summary>
        /// The <c>sortOrder</c> is used to sort the data source. The available type of sort orders are,
        /// * <c>None</c> - The data source is not sorting.
        /// * <c>Ascending</c> - The data source is sorting with ascending order.
        /// * <c>Descending</c> - The data source is sorting with descending order.
        ///
        /// {% codeBlock src='listview/sortOrder/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'None'</default>
        static member inline  sortOrder(sortOrder: SortOrder) = Interop.mkAttr (nameof sortOrder) sortOrder
        /// <summary>
        /// If <c>showIcon</c> set to true, which will show or hide the icon of the list item.
        ///
        /// {% codeBlock src='listview/showIcon/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        static member inline  showIcon(showIcon: bool) = Interop.mkAttr (nameof showIcon) showIcon
        /// <summary>
        /// If <c>showCheckBox</c> set to true, which will show or hide the checkbox.
        ///
        /// {% codeBlock src='listview/showCheckBox/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        static member inline  showCheckBox(showCheckBox: bool) = Interop.mkAttr (nameof showCheckBox) showCheckBox
        /// <summary>
        /// The <c>checkBoxPosition</c> is used to set the position of check box in a list item.
        /// By default, the <c>checkBoxPosition</c> is Left, which will appear before the text content in a list item.
        ///
        /// {% codeBlock src='listview/checkBoxPosition/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'Left'</default>
        static member inline  checkBoxPosition(checkBoxPosition: CheckBoxPosition) = Interop.mkAttr (nameof checkBoxPosition) checkBoxPosition
        /// <summary>
        /// The <c>headerTitle</c> is used to set the title of the ListView component.
        ///
        /// {% codeBlock src='listview/headerTitle/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>""</default>
        static member inline  headerTitle(headerTitle: string) = Interop.mkAttr (nameof headerTitle) headerTitle
        /// <summary>
        /// If <c>showHeader</c> set to true, which will show or hide the header of the ListView component.
        ///
        /// {% codeBlock src='listview/showHeader/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        static member inline  showHeader(showHeader: bool) = Interop.mkAttr (nameof showHeader) showHeader
        /// <summary>
        /// If <c>enableHtmlSanitizer</c> set to true, allows the cross-scripting site.
        ///
        /// {% codeBlock src='listview/enableHtmlSanitizer/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        static member inline  enableHtmlSanitizer(enableHtmlSanitizer: bool) = Interop.mkAttr (nameof enableHtmlSanitizer) enableHtmlSanitizer
        /// <summary>
        /// Defines the height of the ListView component which accepts both string and number values.
        ///
        /// {% codeBlock src='listview/height/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        static member inline  height(height:Height) = Interop.mkAttr (nameof height) height
        /// <summary>
        /// Defines the width of the ListView component which accepts both string and number values.
        ///
        /// {% codeBlock src='listview/width/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>''</default>
        static member inline  width(width: Width) = Interop.mkAttr (nameof width) width
        /// <summary>
        /// The ListView component supports to customize the content of each list items with the help of <c>template</c> property.
        ///
        /// {% codeBlock src='listview/template/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        static member inline  template(template: string) = Interop.mkAttr (nameof template) template
        /// <summary>
        /// The ListView has an option to custom design the ListView header title with the help of <c>headerTemplate</c> property.
        ///
        /// {% codeBlock src="listview/headerTemplate/index.md" %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        static member inline  headerTemplate(headerTemplate: string) = Interop.mkAttr (nameof headerTemplate) headerTemplate
        /// <summary>
        /// The ListView has an option to custom design the group header title with the help of <c>groupTemplate</c> property.
        ///
        /// {% codeBlock src="listview/groupTemplate/index.md" %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        static member inline  groupTemplate (groupTemplate: string) = Interop.mkAttr (nameof groupTemplate) groupTemplate
        /// <summary>Triggers when we select the list item in the component.</summary>
        static member inline  select (select: (SelectEventArgs option->unit))= Interop.mkAttr (nameof select) select
        /// <summary>Triggers when every ListView action starts.</summary>
        static member inline  actionBegin (actionBegin: obj ->unit)= Interop.mkAttr (nameof actionBegin) actionBegin
        /// <summary>Triggers when every ListView actions completed.</summary>
        static member inline  actionComplete(actionComplete: (Browser.Types.MouseEvent->unit)) = Interop.mkAttr (nameof actionComplete) actionComplete
        /// <summary>Triggers, when the data fetch request from the remote server, fails.</summary>
        static member inline  actionFailure(actionFailure: Browser.Types.MouseEvent->unit) = Interop.mkAttr "actionFailure" actionFailure
        static member inline create (props:IReactProperty list) = Interop.reactApi.createElement (listViewComponent, createObj !!props)


