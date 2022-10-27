namespace Syncfusion

module SfGrid =

    open Fable.React
    open SfDataManager
    open Feliz
    open Fable.Core.JsInterop
    open Fable.Core
    open Fable.Import
    open Fable.Core.JS
    open Browser.Types


    let aggregatesDirective:obj = import "AggregatesDirective" "@syncfusion/ej2-react-grids"
    let aggregateDirective :obj = import "AggregateDirective"  "@syncfusion/ej2-react-grids"

    let aggregateColumnDirective:obj = import "AggregateColumnDirective" "@syncfusion/ej2-react-grids"
    let aggregateColumnsDirective :obj = import "AggregateColumnsDirective"  "@syncfusion/ej2-react-grids"

    let gridComponent   :obj = import "GridComponent"    "@syncfusion/ej2-react-grids"
    let columnsDirective:obj = import "ColumnsDirective" "@syncfusion/ej2-react-grids"
    let columnDirective :obj = import "ColumnDirective"  "@syncfusion/ej2-react-grids"
    let injectService   :obj = import "Inject"           "@syncfusion/ej2-react-grids"

    [<RequireQualifiedAccess>]
    module Services = 

      let Page            :obj = import "Page"          "@syncfusion/ej2-react-grids"
      let Sort            :obj = import "Sort"          "@syncfusion/ej2-react-grids"
      let Filter          :obj = import "Filter"        "@syncfusion/ej2-react-grids"
      let Group           :obj = import "Group"         "@syncfusion/ej2-react-grids"
      let Edit            :obj = import "Edit"          "@syncfusion/ej2-react-grids"
      let ToolBar         :obj = import "Toolbar"       "@syncfusion/ej2-react-grids"
      let Aggregate       :obj = import "Aggregate"     "@syncfusion/ej2-react-grids"
      let ColumnChooser   :obj = import "ColumnChooser" "@syncfusion/ej2-react-grids"
      let ColumnMenu      :obj = import "ColumnMenu"    "@syncfusion/ej2-react-grids"
      let CommandColumn   :obj = import "CommandColumn" "@syncfusion/ej2-react-grids"
      let ContextMenu     :obj = import "ContextMenu"   "@syncfusion/ej2-react-grids" 
      let DetailRow       :obj = import "DetailRow"     "@syncfusion/ej2-react-grids" 
      let ForeignKey      :obj = import "ForeignKey"    "@syncfusion/ej2-react-grids" 
      let Freeze          :obj = import "Freeze"        "@syncfusion/ej2-react-grids" 
      let Resize          :obj = import "Resize"        "@syncfusion/ej2-react-grids" 
      let Reorder         :obj = import "Reorder"       "@syncfusion/ej2-react-grids" 
      let RowDD           :obj = import "RowDD"         "@syncfusion/ej2-react-grids" 
      let Search          :obj = import "Search"        "@syncfusion/ej2-react-grids" 
      let Selection       :obj = import "Selection"     "@syncfusion/ej2-react-grids" 
      let Scroll          :obj = import "Scroll"        "@syncfusion/ej2-react-grids" 
      let Print           :obj = import "Print"         "@syncfusion/ej2-react-grids" 
      let VirtualScroll   :obj = import "VirtualScroll" "@syncfusion/ej2-react-grids"
      let ExcelExport     :obj = import "ExcelExport"   "@syncfusion/ej2-react-grids" 
      let PdfExport       :obj = import "PdfExport"     "@syncfusion/ej2-react-grids"


    module Actions = 

      [<StringEnum()>]
      [<RequireQualifiedAccess>]
      type Action = 
        | Paging
        | Refresh
        | Sorting
        | Selection
        | Filtering 
        | Searching
        | Rowdraganddrop
        | Reorder
        | Grouping
        | Ungrouping
        | Batchsave
        | Virtualscroll
        | Print
        | BeginEdit
        | Save
        | Delete
        | Cancel 
        | Add
        | FilterBeforeOpen
        | Filterchoicerequest
        | FilterAfterOpen
        | FilterSearchBegin
        | Columnstate
        | InfiniteScroll


    [<Erase>]
    type ``value`` =
      | String of string
      | Int of int
      | DateTime of System.DateTime
      | Bool of bool


    type PredicateModel = {
        field: string option; 
        operator: string option;
        value: ``value`` option;
        matchCase: bool;
        ignoreAccent: bool;
        predicate: string option;
        actualFilterValue: obj option;
        actualOperator: obj option;
        ``type``: string option;
        ejpredicate: obj option;
        uid: string option;
        isForeignKey:bool;
    }


    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type SortDirection = 
      | Ascending 
      | Descending

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type FilterType =
      |Excel
      |Menu


    type FilterSettingsModel = {
      ``type``:FilterType
      enableCaseSensitivity:bool
      ignoreAccent:bool
    } with static member Default = {
            ``type``=FilterType.Excel
            enableCaseSensitivity=true
            ignoreAccent=true
          }

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type EditMode = 
      |Normal
      |Dialog
      |Batch

    type EditSettingsModel = {
          allowEditing: bool 
          allowAdding: bool 
          allowDeleting: bool
          allowEditOnDblClick:bool
          showConfirmDialog:bool
          showDeleteConfirmDialog:bool
          template: ReactElement option
          headerTemplate: ReactElement option
          footerTemplate: ReactElement option
          mode:EditMode
    } with static member Default = {
            allowEditing=false
            allowAdding=false 
            allowDeleting=false
            allowEditOnDblClick=true
            showConfirmDialog=true
            showDeleteConfirmDialog=true
            template= None
            headerTemplate= None
            footerTemplate= None
            mode=EditMode.Dialog
          }

    [<Erase>]
    [<RequireQualifiedAccess>]
    type PageSizes =
      | Bool of bool
      | StringArray of string[]
      | Number of int[]

    type PageSettingsModel ={
           pageSize: int
           pageSizes: PageSizes 
      
    } with static member Default = {
            pageSize= 5
            pageSizes= PageSizes.Bool true

          }

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type CheckboxSelectionType = 
      | Default
      | ResetOnRowClick

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type SelectionType = 
      | Single
      | Multiple

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type CellSelectionMode = 
      | Flow
      | Box
      | BoxWithBorder

    [<StringEnum(CaseRules.None)>]
    [<RequireQualifiedAccess>]
    type SelectionMode = 
      | Cell
      | Row
      | Both

    type SelectionSettingsModel = {
       mode: SelectionMode option;
       cellSelectionMode: CellSelectionMode option;
       ``type``: SelectionType option;
       checkboxOnly: bool option;
       persistSelection: bool option;
       checkboxMode: CheckboxSelectionType option;
       enableSimpleMultiRowSelection: bool option;
       enableToggle: bool option;
       allowColumnSelection: bool option;
    } with static member Default = {
            mode= Some SelectionMode.Row 
            cellSelectionMode= None 
            ``type``= None
            checkboxOnly= None 
            persistSelection= Some false 
            checkboxMode= None 
            enableSimpleMultiRowSelection= None 
            enableToggle= Some true
            allowColumnSelection= Some false 
        } 


    module rec Pdf=

  
      type [<StringEnum>] [<RequireQualifiedAccess>] PageOrientation =
          | [<CompiledName "Landscape">] Landscape
          | [<CompiledName "Portrait">] Portrait

      type [<StringEnum>] [<RequireQualifiedAccess>] PdfPageSize =
        | [<CompiledName "Letter">] Letter
        | [<CompiledName "Note">] Note
        | [<CompiledName "Legal">] Legal
        | [<CompiledName "A0">] A0
        | [<CompiledName "A1">] A1
        | [<CompiledName "A2">] A2
        | [<CompiledName "A3">] A3
        | [<CompiledName "A4">] A4
        | [<CompiledName "A5">] A5
        | [<CompiledName "A6">] A6
        | [<CompiledName "A7">] A7
        | [<CompiledName "A8">] A8
        | [<CompiledName "A9">] A9
        | [<CompiledName "B0">] B0
        | [<CompiledName "B1">] B1
        | [<CompiledName "B2">] B2
        | [<CompiledName "B3">] B3
        | [<CompiledName "B4">] B4
        | [<CompiledName "B5">] B5
        | [<CompiledName "Archa">] Archa
        | [<CompiledName "Archb">] Archb
        | [<CompiledName "Archc">] Archc
        | [<CompiledName "Archd">] Archd
        | [<CompiledName "Arche">] Arche
        | [<CompiledName "Flsa">] Flsa
        | [<CompiledName "HalfLetter">] HalfLetter
        | [<CompiledName "Letter11x17">] Letter11x17
        | [<CompiledName "Ledger">] Ledger

      type [<AllowNullLiteral>] PdfPosition =
        /// Defines the x position
        abstract x: float with get, set
        /// Defines the y position
        abstract y: float with get, set

      type [<AllowNullLiteral>] PdfSize =
        /// Defines the height
        abstract height: float with get, set
        /// Defines the width
        abstract width: float with get, set

      type [<AllowNullLiteral>] PdfPoints =
        /// Defines the x1 position
        abstract x1: float with get, set
        /// Defines the y1 position
        abstract y1: float with get, set
        /// Defines the x2 position
        abstract x2: float with get, set
        /// Defines the y2 position
        abstract y2: float with get, set
      type [<StringEnum>] [<RequireQualifiedAccess>] PdfDashStyle =
          | [<CompiledName "Solid">] Solid
          | [<CompiledName "Dash">] Dash
          | [<CompiledName "Dot">] Dot
          | [<CompiledName "DashDot">] DashDot
          | [<CompiledName "DashDotDot">] DashDotDot

      type [<StringEnum>] [<RequireQualifiedAccess>] PdfHAlign =
          | [<CompiledName "Left">] Left
          | [<CompiledName "Right">] Right
          | [<CompiledName "Center">] Center
          | [<CompiledName "Justify">] Justify

      type [<StringEnum>] [<RequireQualifiedAccess>] PdfVAlign =
          | [<CompiledName "Top">] Top
          | [<CompiledName "Bottom">] Bottom
          | [<CompiledName "Middle">] Middle
      type [<AllowNullLiteral>] PdfContentStyle =
        /// Defines the pen color.
        abstract penColor: string option with get, set
        /// Defines the pen size.
        abstract penSize: float option with get, set
        /// Defines the dash style.
        abstract dashStyle: PdfDashStyle option with get, set
        /// Defines the text brush color.
        abstract textBrushColor: string option with get, set
        /// Defines the text pen color.
        abstract textPenColor: string option with get, set
        /// Defines the font size.
        abstract fontSize: float option with get, set
        /// Defines the horizontal alignment.
        abstract hAlign: PdfHAlign option with get, set
        /// Defines the vertical alignment.
        abstract vAlign: PdfVAlign option with get, set

      type [<AllowNullLiteral>] PdfFooter =
          /// Defines the footer content distance from bottom.
          abstract fromBottom: float option with get, set
          /// Defines the height of footer content.
          abstract height: float option with get, set
          /// Defines the footer contents
          abstract contents: ResizeArray<PdfHeaderFooterContent> option with get, set
      type [<StringEnum>] [<RequireQualifiedAccess>] ContentType =
          | [<CompiledName "Image">] Image
          | [<CompiledName "Line">] Line
          | [<CompiledName "PageNumber">] PageNumber
          | [<CompiledName "Text">] Text
      type [<StringEnum>] [<RequireQualifiedAccess>] PdfPageNumberType =
          | [<CompiledName "LowerLatin">] LowerLatin
          | [<CompiledName "LowerRoman">] LowerRoman
          | [<CompiledName "UpperLatin">] UpperLatin
          | [<CompiledName "UpperRoman">] UpperRoman
          | [<CompiledName "Numeric">] Numeric
          | [<CompiledName "Arabic">] Arabic
      type [<AllowNullLiteral>] PdfHeaderFooterContent =
          /// Defines the content type
          abstract ``type``: ContentType with get, set
          /// Defines the page number type
          abstract pageNumberType: PdfPageNumberType option with get, set
          /// Defines the style of content
          abstract style: PdfContentStyle option with get, set
          /// Defines the pdf points for drawing line
          abstract points: PdfPoints option with get, set
          /// Defines the format for customizing page number
          abstract format: string option with get, set
          /// Defines the position of the content
          abstract position: PdfPosition option with get, set
          /// Defines the size of content
          abstract size: PdfSize option with get, set
          /// Defines the base64 string for image content type
          abstract src: string option with get, set
          /// Defines the value for content
          abstract value: obj option with get, set
          /// Defines the font for the content

      type [<AllowNullLiteral>] PdfHeader =
          /// Defines the header content distance from top.
          abstract fromTop: float option with get, set
          /// Defines the height of header content.
          abstract height: float option with get, set
          /// Defines the header contents.
          abstract contents: ResizeArray<PdfHeaderFooterContent> option with get, set

      type [<AllowNullLiteral>] PdfBorder =
          /// Defines the border color
          abstract color: string option with get, set
          /// Defines the border width
          abstract width: float option with get, set
          /// Defines the border dash style
          abstract dashStyle: PdfDashStyle option with get, set
          /// Defines the line style of border
          abstract lineStyle: BorderLineStyle option with get, set
  
      type [<StringEnum>] [<RequireQualifiedAccess>] BorderLineStyle =
          | [<CompiledName "Thin">] Thin
          | [<CompiledName "Thick">] Thick

      type [<AllowNullLiteral>] PdfThemeStyle =
          /// Defines the font color of theme style.
          abstract fontColor: string option with get, set
          /// Defines the font name of theme style.
          abstract fontName: string option with get, set
          /// Defines the font size of theme style.
          abstract fontSize: float option with get, set
          /// Defines the bold of theme style.
          abstract bold: bool option with get, set
          /// Defines the borders of theme style.
          abstract border: PdfBorder option with get, set
          /// Defines the italic of theme style.
          abstract italic: bool option with get, set
          /// Defines the underline of theme style.
          abstract underline: bool option with get, set
          /// Defines the strikeout of theme style.
          abstract strikeout: bool option with get, set
      type [<AllowNullLiteral>] PdfTheme =
          /// Defines the style of header content.
          abstract header: PdfThemeStyle option with get, set
          /// Defines the theme style of record content.
          abstract record: PdfThemeStyle option with get, set
          /// Defines the theme style of caption content.
          abstract caption: PdfThemeStyle option with get, set


      type [<StringEnum>] [<RequireQualifiedAccess>] ExportType =
          | [<CompiledName "AllPages">] AllPages
          | [<CompiledName "CurrentPage">] CurrentPage
      type [<StringEnum>] [<RequireQualifiedAccess>] ExcelExportPropertiesHierarchyExportMode =
          | [<CompiledName "Expanded">] Expanded
          | [<CompiledName "All">] All
          | [<CompiledName "None">] None

      type PdfExportProperties<'a> = {
        /// Defines the Pdf orientation.
         pageOrientation: PageOrientation option 
        /// Defines the Pdf page size.
         pageSize: PdfPageSize option 
        /// Defines the Pdf header.
         header: PdfHeader option 
        /// Defines the Pdf footer.
         footer: PdfFooter option
        /// Indicates whether to show the hidden columns in exported Pdf
         includeHiddenColumn: bool option  
        /// Defines the data source dynamically before exporting
         dataSource: 'a[] option 
        /// Indicates to export current page or all page
         exportType: ExportType option 
        /// Defines the theme for exported data
         theme: PdfTheme option 
        /// Defines the file name for the exported file
         fileName: string option 
        /// Defines the hierarchy export mode for the pdf grid
         hierarchyExportMode: ExcelExportPropertiesHierarchyExportMode option 
        /// Defines the overflow of columns for the pdf grid
         allowHorizontalOverflow: bool option 
      }

    module Excel = 

  

      type [<StringEnum>] [<RequireQualifiedAccess>] PdfExportPropertiesHierarchyExportMode =
          | [<CompiledName "Expanded">] Expanded
          | [<CompiledName "All">] All
          | [<CompiledName "None">] None

        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        type ExportType =
          | AllPages
          | CurrentPage


        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        type ExcelHAlign =
          | Left
          | Right
          | Center
          | Fill

        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        type ExcelVAlign =
          | Center
          | Justify
          | Top
          | Bottom

        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        type BorderLineStyle =
          | Thin
          | Thick


         type Border  = {
          color: string;
          lineStyle: BorderLineStyle;
        }


        type ExcelStyle = {
          fontColor: string;
          fontName: string;
          fontSize: int;
          hAlign: ExcelHAlign;
          vAlign: ExcelVAlign;
          bold: bool;
          indent: int;
          italic: bool;
          underline: bool;
          backColor: string;
          wrapText: bool;
          borders: Border;
          numberFormat: string;
          ``type``: string;
        }

        type ExcelTheme  = {
          header: ExcelStyle;
          record: ExcelStyle;
          caption: ExcelStyle;
        }

        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        [<Erase>]
        type ExcellCellValue =
          | String of string
          | Bool of bool
          | Number of int
          | Date of System.DateTime

        type Hyperlink  = {
          target: string;
          displayText: string;
        }

        type ExcelCell = {
          index: int;
          colSpan: int;
          ``value``: ExcellCellValue;
          hyperlink: Hyperlink;
          style: ExcelStyle;
          rowSpan: int;
        }

        type  ExcelRow = {
          index: int;
          cells: ExcelCell[];
          grouping: obj;
        }
        type ExcelHeader  = {
          headerRows: int;
          rows: ExcelRow[];
        }
        type ExcelFooter = {
          footerRows: int;
          rows: ExcelRow[];
        }

        [<StringEnum(CaseRules.None)>]
        [<RequireQualifiedAccess>]
        type MultipleExportType =
          | NewSheet
          | AppendSheet

        type MultipleExport = {
          ``type``: MultipleExportType;
          blankRows: int;
        }

    open Excel

    type ExcelExportProperties<'a> = {
      //columns:Column[]
      dataSource:'a[] option //| DataManager
      enableFilter:bool option
      exportType:ExportType option
      fileName:string
      footer:ExcelFooter option
      header:ExcelHeader option
      includeHiddenColumn:bool option
      multipleExport:MultipleExport option
      //query:Query
      separator:string option
      theme:ExcelTheme option
    } with static member Default<'a>() = {
            dataSource= Some [||]
            enableFilter=None
            exportType=None
            fileName = (sprintf "%s.xlsx" <| System.DateTime.UtcNow.ToString("yyyy_mm_dd"))
            footer=None
            header=None
            includeHiddenColumn=None
            multipleExport=None
            separator=None
            theme=None
        }

    type ItemModelBase  = {
        id: string;
        text: string;
    }

    [<AutoOpen>]
    module ToolBar = 
      type ClickEventArgs = 
        abstract item: ItemModelBase with get, set
        abstract originalEvent: Event  with get, set
        abstract cancel: bool with get, set

      [<StringEnum(CaseRules.None)>]
      type ItemType =
        | Button
        | Separator
        | Input


      type ItemModel  = {
          id: string;
          text: string;
          disabled: bool;
          prefixIcon: string option;
          suffixIcon: string option;
          visible: bool;
          ``type``:ItemType option
          click : (ClickEventArgs->unit)
      }

      [<StringEnum(CaseRules.None)>]
      [<RequireQualifiedAccess>]
      type Item =
        | Add
        | Edit
        | Delete
        | Update
        | Cancel
        | Search
        | ColumnChooser
        | Print
        | PdfExport
        | ExcelExport
        | CsvExport
        | WordExport

      [<Erase>]
      type ToolbarItems =
        | ToolbarItem of Item
        | ItemModel of ItemModel
        | String of string




    module GridEvents = 
      type ClickEventArgs = 
        abstract item: ToolBar.ItemModel with get, set
        abstract originalEvent: Event with get, set
        abstract cancel: bool with get, set
      type RowSelectEventArgs<'a> = 
        abstract cancel:bool with get,set
        abstract data:'a with get,set

      type ActionEventArgs = 
        abstract requestType: Actions.Action with get, set
        abstract ``type``: string option with get, set
        abstract cancel: bool with get, set
        abstract columnName: string option with get, set
        abstract currentFilterObject: PredicateModel option with get, set
        abstract currentFilteringColumn: string option with get, set
        abstract columns: PredicateModel[] option with get, set
        abstract searchString: string option with get, set
        abstract direction: SortDirection with get, set
        abstract data: obj option with get, set
        abstract previousData: obj option with get, set
        abstract row: obj option with get, set
        abstract index: int option
        abstract rowData: obj option with get, set
        abstract selectedRow: int option with get, set
        abstract action: string option with get, set
        abstract foreignKeyData: obj option with get, set
        abstract primaryKeys: string[] option with get, set
        abstract primaryKeyValue: obj[] option with get, set
        abstract rowIndex: int option with get, set
        abstract filterChoiceCount: int with get, set
        abstract excelSearchOperator: string with get, set
  
  
      type [<AllowNullLiteral>] RowDataBoundEventArgs<'a> =
          /// <summary>Defines the current row data.</summary>
          abstract data: 'a with get, set
          /// <summary>Defines the row element.</summary>
          abstract row: Element option with get, set
          /// Defines the row height
          abstract rowHeight: float option with get, set

    type ParentDetails<'a> =
      abstract member parentID: string with get,set
      abstract member parentPrimaryKeys: string[] with get,set
      abstract member parentKeyField: string with get,set
      abstract member parentKeyFieldValue: string with get,set
      abstract member parentRowData: 'a;

    module Format =


      type DateFormatOptions  = {

        ///Specifies the type of date formatting either date, dateTime or time.
        ``type``: string;
        ///Specifies custom date formatting to be used.
        format: string;

      }

      type NumberFormatOptions  = {
        ///Specifies minimum fraction digits in formatted value.
        minimumFractionDigits: int;
        ///Specifies maximum fraction digits in formatted value.
        maximumFractionDigits: int;
        ///Specifies minimum significant digits in formatted value.
        minimumSignificantDigits: int;
        ///Specifies maximum significant digits in formatted value.
        maximumSignificantDigits: int;
        ///Specifies the currency code to be used for formatting.
        currency: string;
        ///Specifies minimum integer digits in formatted value.
        minimumIntegerDigits: int;
        ///Specifies custom number format for formatting.
        format: string;
      }with
        static member Currency ={
          minimumFractionDigits= 2;
          maximumFractionDigits= 2;
          minimumSignificantDigits= 2;
          maximumSignificantDigits= 2;
          currency= "C2";
          minimumIntegerDigits= 2;
          format= "C2";
        }

      [<Erase>]
      [<RequireQualifiedAccess>]
      type FormatOptions =
        | None
        | String of string
        | NumberFormatOptions of NumberFormatOptions
        | DateFormatOptions of DateFormatOptions

    [<StringEnum(CaseRules.LowerFirst)>]
    [<RequireQualifiedAccess>]
    type ColumnType =
      |None
      |String
      |Number
      |Boolean
      |Date
      |DateTime
      |CheckBox

    type ColumnModel<'a> = {
        field: string
        headerText: string
        format:Format.FormatOptions
        ``type``:ColumnType
        width: int
        visible: bool
        isIdentity:bool
        isPrimaryKey: bool
    }
   
    type Columns<'a> = ColumnModel<'a>[]


    type GridModel<'a> = {

      toolbarClick:(GridEvents.ClickEventArgs->unit)
      columns:Columns<'a>
      dataSource: 'a[] 
      queryString:string
      toolbar: ToolbarItems[]
      rowSelected:(GridEvents.RowSelectEventArgs<'a>->unit) option
      actionBegin:(GridEvents.ActionEventArgs->unit) option
    }

    type Workbook() = class end 

    type [<AllowNullLiteral>] Grid<'a> =
        abstract currentViewData: ResizeArray<'a> with get, set
        /// Gets the parent Grid details.
        abstract parentDetails: ParentDetails<'a> with get, set
        /// <summary>
        /// If <c>allowPaging</c> is set to true, the pager renders at the footer of the Grid. It is used to handle page navigation in the Grid.
        /// 
        /// &gt; Check the <see cref="../../grid/paging/"><c>Paging</c></see> to configure the grid pager.
        /// {% codeBlock src='grid/allowPaging/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowPaging: bool with get, set
        /// <summary>
        /// Configures the pager in the Grid.
        /// {% codeBlock src='grid/pageSettings/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{currentPage: 1, pageSize: 12, pageCount: 8, enableQueryString: false, pageSizes: false, template: null}</default>
        abstract pageSettings: PageSettingsModel with get, set
        /// <summary>
        /// If <c>enableVirtualization</c> set to true, then the Grid will render only the rows visible within the view-port
        /// and load subsequent rows on vertical scrolling. This helps to load large dataset in Grid.
        /// {% codeBlock src='grid/enableVirtualization/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract enableVirtualization: bool with get, set
        /// <summary>
        /// If <c>enableColumnVirtualization</c> set to true, then the Grid will render only the columns visible within the view-port
        /// and load subsequent columns on horizontal scrolling. This helps to load large dataset of columns in Grid.
        /// {% codeBlock src='grid/enableColumnVirtualization/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract enableColumnVirtualization: bool with get, set
        /// <summary>
        /// If <c>enableInfiniteScrolling</c> set to true, then the data will be loaded in Grid when the scrollbar reaches the end.
        /// This helps to load large dataset in Grid.
        /// {% codeBlock src='grid/enableInfiniteScrolling/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract enableInfiniteScrolling: bool with get, set
        /// <summary>
        /// If <c>allowSorting</c> is set to true, it allows sorting of grid records when column header is clicked.
        /// 
        /// &gt; Check the <see cref="../../grid/sorting/"><c>Sorting</c></see> to customize its default behavior.
        /// {% codeBlock src='grid/allowSorting/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowSorting: bool with get, set
        /// <summary>
        /// If <c>allowMultiSorting</c> set to true, then it will allow the user to sort multiple column in the grid.
        /// &gt; <c>allowSorting</c> should be true.
        /// {% codeBlock src='grid/allowMultiSorting/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowMultiSorting: bool with get, set
        /// <summary>
        /// If <c>allowExcelExport</c> set to true, then it will allow the user to export grid to Excel file.
        /// 
        /// &gt; Check the <see cref="../../grid/excel-exporting/"><c>ExcelExport</c></see> to configure exporting document.
        /// {% codeBlock src='grid/allowExcelExport/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowExcelExport: bool with get, set
        /// <summary>
        /// If <c>allowPdfExport</c> set to true, then it will allow the user to export grid to Pdf file.
        /// 
        /// &gt; Check the <see cref="../../grid/pdf-export/"><c>Pdfexport</c></see> to configure the exporting document.
        /// {% codeBlock src='grid/allowPdfExport/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowPdfExport: bool with get, set
        /// <summary>
        /// If <c>allowSelection</c> is set to true, it allows selection of (highlight row) Grid records by clicking it.
        /// {% codeBlock src='grid/allowSelection/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>true</default>
        abstract allowSelection: bool with get, set
        /// <summary>
        /// The <c>selectedRowIndex</c> allows you to select a row at initial rendering.
        /// You can also get the currently selected row index.
        /// {% codeBlock src='grid/selectedRowIndex/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>-1</default>
        abstract selectedRowIndex: float with get, set
        /// <summary>
        /// Configures the selection settings.
        /// {% codeBlock src='grid/selectionSettings/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{mode: 'Row', cellSelectionMode: 'Flow', type: 'Single'}</default>
        abstract selectionSettings: SelectionSettingsModel with get, set
        /// <summary>
        /// If <c>allowFiltering</c> set to true the filter bar will be displayed.
        /// If set to false the filter bar will not be displayed.
        /// Filter bar allows the user to filter grid records with required criteria.
        /// 
        /// &gt; Check the <see cref="../../grid/filtering/"><c>Filtering</c></see> to customize its default behavior.
        /// {% codeBlock src='grid/allowFiltering/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowFiltering: bool with get, set
        /// <summary>If <c>enableAdaptiveUI</c> set to true the grid filter, sort, and edit dialogs render adaptively.</summary>
        /// <default>false</default>
        abstract enableAdaptiveUI: bool with get, set
        /// <summary>
        /// If <c>allowReordering</c> is set to true, Grid columns can be reordered.
        /// Reordering can be done by drag and drop of a particular column from one index to another index.
        /// &gt; If Grid is rendered with stacked headers, reordering is allowed only at the same level as the column headers.
        /// {% codeBlock src='grid/allowReordering/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowReordering: bool with get, set
        /// <summary>
        /// If <c>allowResizing</c> is set to true, Grid columns can be resized.
        /// {% codeBlock src='grid/allowResizing/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowResizing: bool with get, set
        /// <summary>
        /// If <c>allowRowDragAndDrop</c> is set to true, you can drag and drop grid rows at another grid.
        /// {% codeBlock src='grid/allowRowDragAndDrop/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowRowDragAndDrop: bool with get, set
        /// <summary>
        /// Configures the filter settings of the Grid.
        /// {% codeBlock src='grid/filterSettings/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>{columns: [], type: 'FilterBar', mode: 'Immediate', showFilterBarStatus: true, immediateModeDelay: 1500 , operators: {}}</default>
        abstract filterSettings: FilterSettingsModel with get, set
        /// <summary>
        /// If <c>allowGrouping</c> set to true, then it will allow the user to dynamically group or ungroup columns.
        /// Grouping can be done by drag and drop columns from column header to group drop area.
        /// 
        /// &gt; Check the <see cref="../../grid/grouping/"><c>Grouping</c></see> to customize its default behavior.
        /// {% codeBlock src='grid/allowGrouping/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract allowGrouping: bool with get, set
        /// <summary>
        /// If <c>enableImmutableMode</c>  is set to true, the grid will reuse old rows if it exists in the new result instead of
        /// full refresh while performing the grid actions.
        /// </summary>
        /// <default>false</default>
        abstract enableImmutableMode: bool with get, set
        /// <summary>
        /// If <c>showColumnMenu</c> set to true, then it will enable the column menu options in each columns.
        /// 
        /// &gt; Check the <see cref="../../grid/columns/.column-menu/"><c>Column menu</c></see> for its configuration.
        /// {% codeBlock src='grid/showColumnMenu/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract showColumnMenu: bool with get, set
        /// <summary>
        /// Configures the edit settings.
        /// {% codeBlock src='grid/editSettings/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>
        /// { allowAdding: false, allowEditing: false, allowDeleting: false, mode:'Normal',
        /// allowEditOnDblClick: true, showConfirmDialog: true, showDeleteConfirmDialog: false }
        /// </default>
        abstract editSettings: EditSettingsModel with get, set
        /// <summary>
        /// If <c>showColumnChooser</c> is set to true, it allows you to dynamically show or hide columns.
        /// 
        /// &gt; Check the <see cref="../../grid/columns/.column-chooser/"><c>ColumnChooser</c></see> for its configuration.
        /// {% codeBlock src='grid/showColumnChooser/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>false</default>
        abstract showColumnChooser: bool with get, set
        /// <summary>If <c>enableHeaderFocus</c> set to true, then header element will be focused when focus moves to grid.</summary>
        /// <default>false</default>
        abstract enableHeaderFocus: bool with get, set
        /// <summary>
        /// Defines the scrollable height of the grid content.
        /// {% codeBlock src='grid/height/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'auto'</default>
        abstract height: U2<string, float> with get, set
        /// <summary>
        /// Defines the Grid width.
        /// {% codeBlock src='grid/width/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>'auto'</default>
        abstract width: U2<string, float> with get, set
        /// <summary>
        /// The row template that renders customized rows from the given template.
        /// By default, Grid renders a table row for every data source item.
        /// &gt; * It accepts either <see cref="../../common/template-engine/">template string</see> or HTML element ID.
        /// &gt; * The row template must be a table row.
        /// 
        /// &gt; Check the <see cref="../../grid/row/"><c>Row Template</c></see> customization.
        /// </summary>
        abstract rowTemplate: string with get, set
        /// <summary>
        /// The detail template allows you to show or hide additional information about a particular row.
        /// 
        /// &gt; It accepts either the <see cref="../../common/template-engine/">template string</see> or the HTML element ID.
        /// 
        /// {% codeBlock src="grid/detail-template-api/index.ts" %}{% endcodeBlock %}
        /// </summary>
        abstract detailTemplate: string with get, set
        /// <summary>
        /// Defines Grid options to render child Grid.
        /// It requires the <see cref="/.querystring"><c>queryString</c></see> for parent
        /// and child relationship.
        /// 
        /// &gt; Check the <see cref="../../grid/hierarchy-grid/"><c>Child Grid</c></see> for its configuration.
        /// </summary>
        abstract childGrid: GridModel<'a> with get, set
        /// Defines the relationship between parent and child datasource. It acts as the foreign key for parent datasource.
        abstract queryString: string with get, set
        /// <summary>
        /// It is used to render grid table rows.
        /// If the <c>dataSource</c> is an array of JavaScript objects,
        /// then Grid will create instance of <see href="https://ej2.syncfusion.com/documentation/api/data/dataManager/"><c>DataManager</c></see>
        /// from this <c>dataSource</c>.
        /// If the <c>dataSource</c> is an existing <see href="https://ej2.syncfusion.com/documentation/api/data/dataManager/"><c>DataManager</c></see>,
        ///   the Grid will not initialize a new one.
        /// 
        /// &gt; Check the available <see cref="../../data/adaptors/"><c>Adaptors</c></see> to customize the data operation.
        /// {% codeBlock src='grid/dataSource/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>[]</default>
        abstract dataSource: 'a[]
        /// <summary>
        /// Defines the height of Grid rows.
        /// {% codeBlock src='grid/rowHeight/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        abstract rowHeight: float with get, set
        /// <summary>
        /// <c>toolbar</c> defines the ToolBar items of the Grid.
        /// It contains built-in and custom toolbar items.
        /// If a string value is assigned to the <c>toolbar</c> option, it is considered as the template for the whole Grid ToolBar.
        /// If an array value is assigned, it is considered as the list of built-in and custom toolbar items in the Grid's Toolbar.
        /// &lt;br&gt;&lt;br&gt;
        /// The available built-in ToolBar items are:
        /// * Add: Adds a new record.
        /// * Edit: Edits the selected record.
        /// * Update: Updates the edited record.
        /// * Delete: Deletes the selected record.
        /// * Cancel: Cancels the edit state.
        /// * Search: Searches records by the given key.
        /// * Print: Prints the Grid.
        /// * ExcelExport - Export the Grid to Excel(excelExport() method manually to make export.)
        /// * PdfExport - Export the Grid to PDF(pdfExport() method manually to make export.)
        /// * CsvExport - Export the Grid to CSV(csvExport() method manually to make export.)&lt;br&gt;&lt;br&gt;
        /// The following code example implements the custom toolbar items.
        /// 
        ///   &gt; Check the <see cref="../../grid/tool-bar/.custom-toolbar-items/"><c>Toolbar</c></see> to customize its default items.
        /// 
        /// {% codeBlock src="grid/toolbar-api/index.ts" %}{% endcodeBlock %}
        /// {% codeBlock src='grid/toolbar/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        abstract toolbar: ToolbarItems with get, set


        /// <summary>It used to render toolbar template</summary>
        /// <default>null</default>
        abstract toolbarTemplate: string with get, set
        /// <summary>It used to render pager template</summary>
        /// <default>null</default>
        abstract pagerTemplate: string with get, set
        /// <summary>
        /// Gets or sets the number of frozen rows.
        /// {% codeBlock src='grid/frozenRows/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>0</default>
        abstract frozenRows: float with get, set
        /// <summary>
        /// Gets or sets the number of frozen columns.
        /// {% codeBlock src='grid/frozenColumns/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <default>0</default>
        abstract frozenColumns: float with get, set

        /// <summary>Get the properties to be maintained in the persisted state.</summary>
        /// <returns>returns the persist data</returns>
        abstract getPersistData: unit -> string

        /// <summary>For internal use only - Initialize the event handler;</summary>
        /// <returns />
        abstract preRender: unit -> unit
        /// <summary>For internal use only - To Initialize the component rendering.</summary>
        /// <returns />
        abstract render: unit -> unit
        /// <summary>By default, grid shows the spinner for all its actions. You can use this method to show spinner at your needed time.</summary>
        /// <returns />
        abstract showSpinner: unit -> unit
        /// <summary>By default, grid shows the spinner for all its actions. You can use this method to show spinner at your needed time.</summary>
        /// <returns />
        abstract hideSpinner: unit -> unit
        abstract getMediaColumns: unit -> unit
        /// <summary>For internal use only - Initialize the event handler</summary>
        /// <returns />
        abstract eventInitializer: unit -> unit
        /// <summary>Destroys the component (detaches/removes all event handlers, attributes, classes, and empties the component element).</summary>
        /// <returns />
        abstract destroy: unit -> unit
        /// <summary>For internal use only - Get the module name.</summary>
        /// <returns>returns the module name</returns>
        abstract getModuleName: unit -> string
        /// <returns />
        abstract setTablesCount: unit -> unit
        /// <returns>- Returns the tables count</returns>
        abstract getTablesCount: unit -> float
        /// <returns />
        abstract updateDefaultCursor: unit -> unit
        abstract getFrozenLeftCount: unit -> float
        abstract isFrozenGrid: unit -> bool
   
        /// <summary>Gets the header div of the Grid.</summary>
        /// <returns>- Returns the element</returns>
        abstract getHeaderContent: unit -> Element
        /// <summary>Sets the header div of the Grid to replace the old header.</summary>
        /// <param name="element">Specifies the Grid header.</param>
        /// <returns />
        abstract setGridHeaderContent: element: Element -> unit
        /// <summary>Gets the content table of the Grid.</summary>
        /// <returns>- Returns the element</returns>
        abstract getContentTable: unit -> Element
        /// <summary>Sets the content table of the Grid to replace the old content table.</summary>
        /// <param name="element">Specifies the Grid content table.</param>
        /// <returns />
        abstract setGridContentTable: element: Element -> unit
        /// <summary>Gets the content div of the Grid.</summary>
        /// <returns>Returns the element</returns>
        abstract getContent: unit -> Element
        /// <summary>Sets the content div of the Grid to replace the old Grid content.</summary>
        /// <param name="element">Specifies the Grid content.</param>
        /// <returns />
        abstract setGridContent: element: Element -> unit
        /// <summary>Gets the header table element of the Grid.</summary>
        /// <returns>returns the element</returns>
        abstract getHeaderTable: unit -> Element
        /// <summary>Sets the header table of the Grid to replace the old one.</summary>
        /// <param name="element">Specifies the Grid header table.</param>
        /// <returns />
        abstract setGridHeaderTable: element: Element -> unit
        /// <summary>Gets the footer div of the Grid.</summary>
        /// <returns>returns the element</returns>
        abstract getFooterContent: unit -> Element
        /// <summary>Gets the footer table element of the Grid.</summary>
        /// <returns>returns the element</returns>
        abstract getFooterContentTable: unit -> Element
        /// <summary>Gets the pager of the Grid.</summary>
        /// <returns>returns the element</returns>
        abstract getPager: unit -> Element
        /// <summary>Sets the pager of the Grid to replace the old pager.</summary>
        /// <param name="element">Specifies the Grid pager.</param>
        /// <returns />
        abstract setGridPager: element: Element -> unit
        /// <summary>Gets a row by index.</summary>
        /// <param name="index">Specifies the row index.</param>
        /// <returns>returns the element</returns>
        abstract getRowByIndex: index: float -> Element
        /// <summary>Gets a movable tables row by index.</summary>
        /// <param name="index">Specifies the row index.</param>
        /// <returns>returns the element</returns>
        abstract getMovableRowByIndex: index: float -> Element
        /// <summary>Gets a frozen tables row by index.</summary>
        /// <param name="index">Specifies the row index.</param>
        /// <returns>returns the element</returns>
        abstract getFrozenRowByIndex: index: float -> Element
        /// <summary>Gets all the data rows of the Grid.</summary>
        /// <returns>returns the element</returns>
        abstract getRows: unit -> ResizeArray<Element>
        /// <summary>Gets a frozen right tables row element by index.</summary>
        /// <param name="index">Specifies the row index.</param>
        /// <returns>returns the element</returns>
        abstract getFrozenRightRowByIndex: index: float -> Element
        /// <summary>Gets the Grid's movable content rows from frozen grid.</summary>
        /// <returns>returns the element</returns>
        abstract getMovableRows: unit -> ResizeArray<Element>
        /// <summary>Gets the Grid's frozen right content rows from frozen grid.</summary>
        /// <returns>returns the element</returns>
        abstract getFrozenRightRows: unit -> ResizeArray<Element>
        /// <summary>Gets all the Grid's data rows.</summary>
        /// <returns>returns the element</returns>
        abstract getDataRows: unit -> ResizeArray<Element>
        /// <param name="includeAdd">specifies includeAdd</param>
        /// <returns>returns the element</returns>
        abstract getAllDataRows: ?includeAdd: bool -> ResizeArray<Element>
        /// <param name="fRows">Defines the frozen Rows</param>
        /// <param name="mrows">Defines the movable Rows</param>
        /// <returns>Returns the element</returns>
        abstract addMovableRows: fRows: ResizeArray<HTMLElement> * mrows: ResizeArray<HTMLElement> -> ResizeArray<HTMLElement>
        /// <summary>Gets all the Grid's movable table data rows.</summary>
        /// <returns>Returns the element</returns>
        abstract getMovableDataRows: unit -> ResizeArray<Element>
        /// <param name="includeAdd">Defines the include add in boolean</param>
        /// <returns>Returns the element</returns>
        abstract getAllMovableDataRows: ?includeAdd: bool -> ResizeArray<Element>
        /// <summary>Gets all the Grid's frozen table data rows.</summary>
        /// <returns>returns the element</returns>
        abstract getFrozenDataRows: unit -> ResizeArray<Element>
        /// <param name="includeAdd">Defines the include add in boolean</param>
        /// <returns>Returns the element</returns>
        abstract getAllFrozenDataRows: ?includeAdd: bool -> ResizeArray<Element>
        /// <summary>Gets all the Grid's frozen right table data rows.</summary>
        /// <returns>Returns the Element</returns>
        abstract getFrozenRightDataRows: unit -> ResizeArray<Element>
        /// <param name="includeAdd">Defines the include add in boolean</param>
        /// <returns>Returns the element</returns>
        abstract getAllFrozenRightDataRows: ?includeAdd: bool -> ResizeArray<Element>
        /// <param name="columnUid">Defines column uid</param>
        /// <returns />
        abstract refreshReactColumnTemplateByUid: columnUid: string -> unit
        /// <param name="columnUid">Defines column uid</param>
        /// <returns />
        abstract refreshReactHeaderTemplateByUid: columnUid: string -> unit

        /// <summary>Gets a cell by row and column index.</summary>
        /// <param name="rowIndex">Specifies the row index.</param>
        /// <param name="columnIndex">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getCellFromIndex: rowIndex: float * columnIndex: float -> Element
        /// <summary>Gets a movable table cell by row and column index.</summary>
        /// <param name="rowIndex">Specifies the row index.</param>
        /// <param name="columnIndex">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getMovableCellFromIndex: rowIndex: float * columnIndex: float -> Element
        /// <summary>Gets a frozen right table cell by row and column index.</summary>
        /// <param name="rowIndex">Specifies the row index.</param>
        /// <param name="columnIndex">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getFrozenRightCellFromIndex: rowIndex: float * columnIndex: float -> Element
        /// <summary>Gets a column header by column index.</summary>
        /// <param name="index">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getColumnHeaderByIndex: index: float -> Element
        /// <summary>Gets a movable column header by column index.</summary>
        /// <param name="index">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getMovableColumnHeaderByIndex: index: float -> Element
        /// <summary>Gets a frozen right column header by column index.</summary>
        /// <param name="index">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getFrozenRightColumnHeaderByIndex: index: float -> Element
        /// <summary>Gets a frozen left column header by column index.</summary>
        /// <param name="index">Specifies the column index.</param>
        /// <returns>Returns the Element</returns>
        abstract getFrozenLeftColumnHeaderByIndex: index: float -> Element
        /// <summary>Gets a column header by column name.</summary>
        /// <param name="field">Specifies the column name.</param>
        /// <returns>- Returns the element</returns>
        abstract getColumnHeaderByField: field: string -> Element
        /// <summary>Gets a column header by UID.</summary>
        /// <param name="uid">Specifies the column uid.</param>
        /// <returns>- Returns the element</returns>
        abstract getColumnHeaderByUid: uid: string -> Element
        /// <param name="index">Defines the index</param>
        /// <returns>Returns the column</returns>
        /// <summary>Gets a column index by UID.</summary>
        /// <param name="uid">Specifies the column UID.</param>
        /// <returns>Returns the column by index</returns>
        abstract getColumnIndexByUid: uid: string -> float
        /// <summary>Gets UID by column name.</summary>
        /// <param name="field">Specifies the column name.</param>
        /// <returns>Returns the column by field</returns>
        abstract getUidByColumnField: field: string -> string
        /// <summary>Gets column index by column uid value.</summary>
        /// <param name="uid">Specifies the column uid.</param>
        /// <returns>Returns the column by field</returns>
        abstract getNormalizedColumnIndex: uid: string -> float
        /// <summary>Gets indent cell count.</summary>
        /// <returns>Returns the indent count</returns>
        abstract getIndentCount: unit -> float
        /// <summary>Gets the collection of column fields.</summary>
        /// <returns>Returns the Field names</returns>
        abstract getColumnFieldNames: unit -> ResizeArray<string>
           /// <summary>Get the names of the primary key columns of the Grid.</summary>
        /// <returns>Returns the field names</returns>
        abstract getPrimaryKeyFieldNames: unit -> ResizeArray<string>
        /// <summary>Refreshes the Grid header and content.</summary>
        /// <returns />
        abstract refresh: unit -> unit
        /// <summary>Refreshes the Grid header.</summary>
        /// <returns />
        abstract refreshHeader: unit -> unit
        /// <summary>Gets the collection of selected rows.</summary>
        /// <returns>Returns the element</returns>
        abstract getSelectedRows: unit -> ResizeArray<Element>
        /// <summary>Gets the collection of selected row indexes.</summary>
        /// <returns>Returns the Selected row indexes</returns>
        abstract getSelectedRowIndexes: unit -> ResizeArray<float>

        /// <summary>Gets the collection of selected records.</summary>
        /// <returns>Returns the selected records</returns>
        abstract getSelectedRecords: unit -> ResizeArray<'a>
        /// <summary>Gets the collection of selected columns uid.</summary>
        /// <returns>Returns the selected column uid</returns>
        abstract getSelectedColumnsUid: unit -> ResizeArray<string>
        /// <summary>Shows a column by its column name.</summary>
        /// <param name="keys">Defines a single or collection of column names.</param>
        /// <param name="showBy">Defines the column key either as field name or header text.</param>
        /// <returns />
        abstract showColumns: keys: U2<string, ResizeArray<string>> * ?showBy: string -> unit
        /// <summary>Hides a column by column name.</summary>
        /// <param name="keys">Defines a single or collection of column names.</param>
        /// <param name="hideBy">Defines the column key either as field name or header text.</param>
        /// <returns />
        abstract hideColumns: keys: U2<string, ResizeArray<string>> * ?hideBy: string -> unit
        /// <returns>Returns the Frozen column</returns>
        abstract getFrozenColumns: unit -> float
        /// <returns>Returns the Frozen Right column count</returns>
        abstract getFrozenRightColumnsCount: unit -> float
        /// <returns>Returns the Frozen Left column</returns>
        abstract getFrozenLeftColumnsCount: unit -> float
        /// <returns>Returns the movable column count</returns>
        abstract getMovableColumnsCount: unit -> float
        /// <returns />
        abstract setFrozenCount: unit -> unit
        /// <returns>Returns the visible Frozen left count</returns>
        abstract getVisibleFrozenLeftCount: unit -> float
        /// <returns>Returns the visible Frozen Right count</returns>
        abstract getVisibleFrozenRightCount: unit -> float
        /// <returns>Returns the visible movable count</returns>
        abstract getVisibleMovableCount: unit -> float

        /// <returns>Returns the visible frozen columns count</returns>
        abstract getVisibleFrozenColumns: unit -> float

        /// <summary>Navigates to the specified target page.</summary>
        /// <param name="pageNo">Defines the page number to navigate.</param>
        /// <returns />
        abstract goToPage: pageNo: float -> unit
        /// <summary>Defines the text of external message.</summary>
        /// <param name="message">Defines the message to update.</param>
        /// <returns />
        abstract updateExternalMessage: message: string -> unit
        /// <summary>Sorts a column with the given options.</summary>
        /// <param name="columnName">Defines the column name to be sorted.</param>
        /// <param name="direction">Defines the direction of sorting field.</param>
        /// <param name="isMultiSort">Specifies whether the previous sorted columns are to be maintained.</param>
        /// <returns />
        abstract sortColumn: columnName: string * direction: SortDirection * ?isMultiSort: bool -> unit
        /// <summary>Clears all the sorted columns of the Grid.</summary>
        /// <returns />
        abstract clearSorting: unit -> unit
        /// <summary>Remove sorted column by field name.</summary>
        /// <param name="field">Defines the column field name to remove sort.</param>
        /// <returns />
        abstract removeSortColumn: field: string -> unit
        /// <returns />
        abstract clearGridActions: unit -> unit
     /// <summary>Clears all the filtered rows of the Grid.</summary>
        /// <param name="fields">Defines the Fields</param>
        /// <returns />
        abstract clearFiltering: ?fields: ResizeArray<string> -> unit
        /// <summary>Removes filtered column by field name.</summary>
        /// <param name="field">Defines column field name to remove filter.</param>
        /// <param name="isClearFilterBar">Specifies whether the filter bar value needs to be cleared.</param>
        /// <returns />
        abstract removeFilteredColsByField: field: string * ?isClearFilterBar: bool -> unit
        /// <summary>Selects a row by given index.</summary>
        /// <param name="index">Defines the row index.</param>
        /// <param name="isToggle">If set to true, then it toggles the selection.</param>
        /// <returns />
        abstract selectRow: index: float * ?isToggle: bool -> unit
        /// <summary>Selects a collection of rows by indexes.</summary>
        /// <param name="rowIndexes">Specifies the row indexes.</param>
        /// <returns />
        abstract selectRows: rowIndexes: ResizeArray<float> -> unit
        /// <summary>Deselects the current selected rows and cells.</summary>
        /// <returns />
        abstract clearSelection: unit -> unit
        /// <summary>
        /// Searches Grid records using the given key.
        /// You can customize the default search option by using the
        /// <see cref="./.searchsettings/"><c>searchSettings</c></see>.
        /// </summary>
        /// <param name="searchString">Defines the key.</param>
        /// <returns />
        abstract search: searchString: string -> unit
        /// <summary>
        /// By default, prints all the pages of the Grid and hides the pager.
        /// &gt; You can customize print options using the
        /// <see cref="./.printmode"><c>printMode</c></see>.
        /// </summary>
        /// <returns />
        abstract print: unit -> unit
        /// <summary>
        /// Starts edit the selected row. At least one row must be selected before invoking this method.
        /// <c>editSettings.allowEditing</c> should be true.
        /// {% codeBlock src='grid/startEdit/index.md' %}{% endcodeBlock %}
        /// </summary>
        /// <returns />
        abstract startEdit: unit -> unit
        /// <summary>If Grid is in editable state, you can save a record by invoking endEdit.</summary>
        /// <returns />
        abstract endEdit: unit -> unit
        /// <summary>Cancels edited state.</summary>
        /// <returns />
        abstract closeEdit: unit -> unit
        /// <summary>Delete any visible row by TR element.</summary>
        /// <param name="tr">Defines the table row element.</param>
        /// <returns />
        abstract deleteRow: tr: HTMLTableRowElement -> unit
        /// <summary>Changes a particular cell into edited state based on the row index and field name provided in the <c>batch</c> mode.</summary>
        /// <param name="index">Defines row index to edit a particular cell.</param>
        /// <param name="field">Defines the field name of the column to perform batch edit.</param>
        /// <returns />
        abstract editCell: index: float * field: string -> unit
        /// <summary>Saves the cell that is currently edited. It does not save the value to the DataSource.</summary>
        /// <returns>{% codeBlock src='grid/saveCell/index.md' %}{% endcodeBlock %}</returns>
        abstract saveCell: unit -> unit
        /// <summary>Enables or disables ToolBar items.</summary>
        /// <param name="items">Defines the collection of itemID of ToolBar items.</param>
        /// <param name="isEnable">Defines the items to be enabled or disabled.</param>
        /// <returns />
        abstract enableToolbarItems: items: ResizeArray<string> * isEnable: bool -> unit
        /// <summary>Copy the selected rows or cells data into clipboard.</summary>
        /// <param name="withHeader">Specifies whether the column header text needs to be copied along with rows or cells.</param>
        /// <returns />
        abstract copy: ?withHeader: bool -> unit
        /// <returns />
        abstract recalcIndentWidth: unit -> unit
        /// <returns />
        abstract resetIndentWidth: unit -> unit
        /// <returns>Returns isRowDragable</returns>
        abstract isRowDragable: unit -> bool
        /// <summary>Changes the Grid column positions by field names.</summary>
        /// <param name="fromFName">Defines the origin field name.</param>
        /// <param name="toFName">Defines the destination field name.</param>
        /// <returns />
        abstract reorderColumns: fromFName: U2<string, ResizeArray<string>> * toFName: string -> unit
        /// <summary>
        /// Changes the Grid column positions by field index. If you invoke reorderColumnByIndex multiple times,
        /// then you won't get the same results every time.
        /// </summary>
        /// <param name="fromIndex">Defines the origin field index.</param>
        /// <param name="toIndex">Defines the destination field index.</param>
        /// <returns />
        abstract reorderColumnByIndex: fromIndex: float * toIndex: float -> unit
        /// <summary>
        /// Changes the Grid column positions by field index. If you invoke reorderColumnByTargetIndex multiple times,
        /// then you will get the same results every time.
        /// </summary>
        /// <param name="fieldName">Defines the field name.</param>
        /// <param name="toIndex">Defines the destination field index.</param>
        /// <returns />
        abstract reorderColumnByTargetIndex: fieldName: U2<string, ResizeArray<string>> * toIndex: float -> unit
        /// <summary>Changes the Grid Row position with given indexes.</summary>
        /// <param name="fromIndexes">Defines the origin Indexes.</param>
        /// <param name="toIndex">Defines the destination Index.</param>
        /// <returns />
        abstract reorderRows: fromIndexes: ResizeArray<float> * toIndex: float -> unit
        /// <param name="enable">Defines the enable</param>
        /// <returns />
        abstract disableRowDD: enable: bool -> unit
        abstract excelExport: ?exportProperties:ExcelExportProperties<'a> * ?isMultipleExport:bool * ?workbook:Workbook  *  ?isBlob:bool  -> unit
        abstract pdfExport: ?pdfExportProperties: Pdf.PdfExportProperties<'a> * ?isMultipleExport: bool option* ?pdfDoc: Object option * ?isBlob: bool option-> unit
        /// <summary>
        /// Changes the column width to automatically fit its content to ensure that the width shows the content without wrapping/hiding.
        /// &gt; * This method ignores the hidden columns.
        /// &gt; * Uses the <c>autoFitColumns</c> method in the <c>dataBound</c> event to resize at initial rendering.
        /// </summary>
        /// <param name="fieldNames">Defines the column names.</param>
        /// <returns>
        /// <code lang="typescript">
        /// &lt;div id="Grid"&gt;&lt;/div&gt;
        /// &lt;script&gt;
        /// let gridObj: Grid = new Grid({
        ///     dataSource: employeeData,
        ///     columns: [
        ///         { field: 'OrderID', headerText: 'Order ID', width:100 },
        ///         { field: 'EmployeeID', headerText: 'Employee ID' }],
        ///     dataBound: () =&gt; gridObj.autoFitColumns('EmployeeID')
        /// });
        /// gridObj.appendTo('#Grid');
        /// &lt;/script&gt;
        /// </code>
        /// </returns>
        abstract autoFitColumns: ?fieldNames: U2<string, ResizeArray<string>> -> unit
        /// <param name="x">Defines the number</param>
        /// <param name="y">Defines the number</param>
        /// <param name="target">Defines the Element</param>
        /// <returns />
        abstract createColumnchooser: x: float * y: float * target: Element -> unit
        abstract dataReady: unit -> unit
        /// <summary>The function is used to apply text wrap</summary>
        /// <returns />
        abstract applyTextWrap: unit -> unit
        /// <summary>The function is used to remove text wrap</summary>
        /// <returns />
        abstract removeTextWrap: unit -> unit
        /// <summary>The function is used to add Tooltip to the grid cell that has ellipsiswithtooltip clip mode.</summary>
        /// <returns />
        abstract createTooltip: unit -> unit
        /// <returns />
        abstract freezeRefresh: unit -> unit
        /// <param name="e">Defines the mouse event</param>
        /// <returns />
        abstract hoverFrozenRows: e: MouseEvent -> unit
        /// <summary>To create table for ellipsiswithtooltip</summary>
        /// <param name="table">Defines the table</param>
        /// <param name="tag">Defines the tag</param>
        /// <param name="type">Defines the type</param>
        /// <returns>Returns the HTML div ELement</returns>
        abstract createTable: table: Element * tag: string * ``type``: string -> HTMLDivElement
        /// <summary>Binding events to the element while component creation.</summary>
        /// <returns />
        abstract wireEvents: unit -> unit
        /// <summary>Unbinding events from the element while component destroy.</summary>
        /// <returns />
        abstract unwireEvents: unit -> unit
        /// <returns />
        abstract addListener: unit -> unit
        /// <returns />
        abstract removeListener: unit -> unit
        /// <summary>Get current visible data of grid.</summary>
        /// <returns>Returns the current view records</returns>
        abstract getCurrentViewRecords: unit -> ResizeArray<'a>
        /// <returns>Returns the isDetail</returns>
        abstract isDetail: unit -> bool
        /// <returns>Returns row height</returns>
        abstract getRowHeight: unit -> float
        /// <summary>Refreshes the Grid column changes.</summary>
        /// <returns />
        abstract refreshColumns: unit -> unit
        /// <summary>Groups a column by column name.</summary>
        /// <param name="columnName">Defines the column name to group.</param>
        /// <returns />
        abstract groupColumn: columnName: string -> unit
        /// <summary>Expands all the grouped rows of the Grid.</summary>
        /// <returns />
        abstract groupExpandAll: unit -> unit
        /// <summary>Collapses all the grouped rows of the Grid.</summary>
        /// <returns />
        abstract groupCollapseAll: unit -> unit
        /// <summary>Clears all the grouped columns of the Grid.</summary>
        /// <returns />
        abstract clearGrouping: unit -> unit
        /// <summary>Ungroups a column by column name.</summary>
        /// <param name="columnName">
        /// Defines the column name to ungroup.
        /// 
        /// {% codeBlock src='grid/ungroupColumn/index.md' %}{% endcodeBlock %}
        /// </param>
        /// <returns />
        abstract ungroupColumn: columnName: string -> unit
        /// <summary>Column chooser can be displayed on screen by given position(X and Y axis).</summary>
        /// <param name="x">Defines the X axis.</param>
        /// <param name="y">Defines the Y axis.</param>
        /// <returns />
        abstract openColumnChooser: ?x: float * ?y: float -> unit
        /// <summary>Collapses all the detail rows of the Grid.</summary>
        /// <returns />
        abstract detailCollapseAll: unit -> unit
        /// <summary>Expands all the detail rows of the Grid.</summary>
        /// <returns />
        abstract detailExpandAll: unit -> unit
        /// <summary>Deselects the currently selected cells.</summary>
        /// <returns />
        abstract clearCellSelection: unit -> unit
        /// <summary>Deselects the currently selected rows.</summary>
        /// <returns />
        abstract clearRowSelection: unit -> unit
        /// <summary>Selects a range of rows from start and end row indexes.</summary>
        /// <param name="startIndex">Specifies the start row index.</param>
        /// <param name="endIndex">Specifies the end row index.</param>
        /// <returns />
        abstract selectRowsByRange: startIndex: float * ?endIndex: float -> unit
        /// <returns>Returns whether context menu is open or not</returns>
        abstract isContextMenuOpen: unit -> bool
        /// <summary>Destroys the given template reference.</summary>
        /// <param name="propertyNames">Defines the collection of template name.</param>
        /// <param name="index">specifies the index</param>
        abstract destroyTemplate: ?propertyNames: ResizeArray<string> * ?index: obj -> unit
        /// <param name="element">Defines the element</param>
        /// <returns />
        abstract applyBiggerTheme: element: Element -> unit
        /// <summary>Hides the scrollbar placeholder of Grid content when grid content is not overflown.</summary>
        /// <returns />
        abstract hideScroll: unit -> unit
        /// <param name="prefix">specifies the prefix</param>
        /// <returns>returns the row uid</returns>
        abstract getRowUid: prefix: string -> string
        /// <returns>returns the element</returns>
        abstract getMovableVirtualContent: unit -> Element
        /// <returns>returns the element</returns>
        abstract getFrozenVirtualContent: unit -> Element
        /// <returns>returns the element</returns>
        abstract getMovableVirtualHeader: unit -> Element
        /// <returns>returns the element</returns>
        abstract getFrozenVirtualHeader: unit -> Element
        /// <param name="uid">specifies the uid</param>
        /// <returns>returns the element</returns>
        abstract getRowElementByUID: uid: string -> Element
        /// <summary>calculatePageSizeByParentHeight</summary>
        /// <param name="containerHeight">specifies the container height</param>
        /// <returns>returns the page size</returns>
        abstract calculatePageSizeByParentHeight: containerHeight: U2<float, string> -> float
        /// <summary>Sends a Post request to export Grid to Excel file in server side.</summary>
        /// <param name="url">Pass Url for server side excel export action.</param>
        /// <returns />
        abstract serverExcelExport: url: string -> unit
        /// <summary>Sends a Post request to export Grid to Pdf file in server side.</summary>
        /// <param name="url">Pass Url for server side pdf export action.</param>
        /// <returns />
        abstract serverPdfExport: url: string -> unit
        /// <summary>Sends a Post request to export Grid to CSV file in server side.</summary>
        /// <param name="url">Pass Url for server side pdf export action.</param>
        /// <returns />
        abstract serverCsvExport: url: string -> unit
        /// <param name="url">Defines exporting url</param>
        /// <returns />
        abstract exportGrid: url: string -> unit

        /// <returns>returns the isCollapseStateEnabled</returns>
        abstract isCollapseStateEnabled: unit -> bool

        /// <returns />
        abstract setForeignKeyData: unit -> unit
        /// <param name="field">specifies the field</param>
        /// <returns />
        abstract resetFilterDlgPosition: field: string -> unit
        /// <returns />
        abstract renderTemplates: unit -> unit
        /// <returns />
        abstract updateVisibleExpandCollapseRows: unit -> unit
        /// <param name="height">specifies the height</param>
        /// <returns>- specifies the height number</returns>
        abstract getHeight: height: U2<string, float> -> U2<float, string>
        /// <returns>- returns frozen right content</returns>
        abstract getFrozenRightContent: unit -> Element
        /// <returns>- returns frozen right header</returns>
        abstract getFrozenRightHeader: unit -> Element
        /// <returns>- returns movable header tbody</returns>
        abstract getMovableHeaderTbody: unit -> Element
        /// <returns>- returns movable content tbody</returns>
        abstract getMovableContentTbody: unit -> Element
        /// <returns>- returns frozen header tbody</returns>
        abstract getFrozenHeaderTbody: unit -> Element
        /// <returns>- returns frozen left content tbody</returns>
        abstract getFrozenLeftContentTbody: unit -> Element
        /// <returns>- returns frozen right header tbody</returns>
        abstract getFrozenRightHeaderTbody: unit -> Element
        /// <returns>returns frozen right content tbody</returns>
        abstract getFrozenRightContentTbody: unit -> Element
        /// <param name="isCustom">Defines custom filter dialog open</param>
        /// <returns />
        abstract showResponsiveCustomFilter: ?isCustom: bool -> unit
        /// <param name="isCustom">Defines custom sort dialog open</param>
        /// <returns />
        abstract showResponsiveCustomSort: ?isCustom: bool -> unit
        /// <summary>To manually show the vertical row mode filter dialog</summary>
        /// <returns />
        abstract showAdaptiveFilterDialog: unit -> unit
        /// <summary>To manually show the vertical row sort filter dialog</summary>
        /// <returns />
        abstract showAdaptiveSortDialog: unit -> unit



    [<RequireQualifiedAccess>]
    module Grid =
      ///Returns and array of selected elements
      ///Defaults to None no rows were selected.
      let getSelectedRecords(grid:Element):'a[] option =
          grid?getSelectedRecords()
      let excelExport(grid:Element,excelExportProperties:ExcelExportProperties<'a>,isBlob:bool ) : unit=
          grid?excelExport(excelExportProperties,Some false,None,Some false)

      let refresh(grid:Element):unit =
          grid?refresh()


    [<Erase>]
    type SfGrid =
        static member inline grid xs = Feliz.Interop.createElement "GridComponent " xs
        static member inline grid (children: #seq<ReactElement>) = Feliz.Interop.reactElementWithChildren "GridComponent" children
        static member inline enableAdaptiveUI (enableAdaptiveUI: bool) = Feliz.Interop.mkAttr "enableAdaptiveUI" enableAdaptiveUI  
        static member inline dataSource (dataSource: 'a[]) =Feliz.Interop.mkAttr "dataSource"  dataSource
        static member inline dataSource (dataSource: DataManager) =Feliz.Interop.mkAttr "dataSource"  dataSource
        static member inline childGrid<'a> (childGrid:GridModel<'a>) =Feliz.Interop.mkAttr "childGrid"  childGrid
        static member inline allowPaging (allowPaging: bool) =Feliz.Interop.mkAttr "allowPaging"  allowPaging
        static member inline allowSorting (allowSorting: bool) =Feliz.Interop.mkAttr "allowSorting"  allowSorting
        static member inline allowFiltering (allowFiltering: bool) =Feliz.Interop.mkAttr "allowFiltering"  allowFiltering
        static member inline allowGrouping (allowGrouping: bool) =Feliz.Interop.mkAttr "allowGrouping"  allowGrouping
        static member inline allowExcelExport (allowExcelExport: bool) =Feliz.Interop.mkAttr "allowExcelExport"  allowExcelExport
        static member inline showColumnChooser (showColumnChooser: bool) =Feliz.Interop.mkAttr "showColumnChooser"  showColumnChooser
        static member inline height (height: string) =Feliz.Interop.mkAttr "height"  height
        static member inline editSettings (editSettings: EditSettingsModel) =Feliz.Interop.mkAttr "editSettings"  editSettings
        static member inline pageSettings (pageSettings: PageSettingsModel) =Feliz.Interop.mkAttr "pageSettings"  pageSettings
        static member inline toolbar (toolbar: ToolbarItems[]) =Feliz.Interop.mkAttr "toolbar"  toolbar
        static member inline filterSettings(filterSettings:FilterSettingsModel) =Feliz.Interop.mkAttr "filterSettings" filterSettings
        static member inline selectionSettings(selectionSettings:SelectionSettingsModel) =Feliz.Interop.mkAttr "selectionSettings" selectionSettings
        static member inline actionBegin(actionBegin:(GridEvents.ActionEventArgs->unit)) =Feliz.Interop.mkAttr "actionBegin" actionBegin
        static member inline toolbarClick(toolbarClick:(GridEvents.ClickEventArgs->unit)) =Feliz.Interop.mkAttr "toolbarClick" toolbarClick
        static member inline rowSelected(rowSelected:(GridEvents.RowSelectEventArgs<'a>->unit)) =Feliz.Interop.mkAttr "rowSelected" rowSelected
        static member inline rowDataBound(callback:(GridEvents.RowDataBoundEventArgs<'a>->unit)) =Feliz.Interop.mkAttr "rowDataBound" callback
        static member inline create (props:Feliz.IReactProperty list) = Feliz.Interop.reactApi.createElement (gridComponent, createObj !!props)

    
    type columns =
        static member inline columns (children: #seq<ReactElement>) = Feliz.Interop.reactElementWithChildren "ColumnsDirective" children
        static member inline create props = Feliz.Interop.reactApi.createElement (columnsDirective, createObj !!props)

    [<StringEnum>]
    type ColumnFormat =
      | [<CompiledName("string")>]String
      | [<CompiledName("number")>]Number
      | [<CompiledName("boolean")>]Boolean
      | [<CompiledName("date")>]Date
      | [<CompiledName("datetime")>]Datetime

    type column =
        static member inline validationRules (validationRules:obj )  = "validationRules" ==> validationRules
        static member inline field (v:string) = Feliz.Interop.mkAttr "field" v
        static member inline field (v:'a -> string)  = Feliz.Interop.mkAttr "field" (v (unbox null))
        static member inline ``type``(``type``: ColumnFormat) = Feliz.Interop.mkAttr "type" ``type``
        static member inline format (format: string)  = Feliz.Interop.mkAttr "format" format
        static member inline headerText (headerText: string) =Feliz.Interop.mkAttr "headerText" headerText
        static member inline width (width: int) =Feliz.Interop.mkAttr "width"  width
        static member inline isVisible (visible: bool) =Feliz.Interop.mkAttr "visible"  visible
        static member inline isCommandColumn (isCommandColumn: bool) =Feliz.Interop.mkAttr "isCommandColumn"  isCommandColumn
        static member inline isKey (isPrimaryKey: bool) =Feliz.Interop.mkAttr "isPrimaryKey" isPrimaryKey
        static member inline isIdentity (isIdentity: bool) =Feliz.Interop.mkAttr "isIdentity" isIdentity
        static member inline template<'a>(footerTemplate:('a->ReactElement))  = Feliz.prop.custom("template",
          (fun x ->
            let x = footerTemplate x;
            x))
        static member inline create props = Feliz.Interop.reactApi.createElement (columnDirective, createObj !!props)

    type inject =
        static member inline services (services: obj) =Feliz.Interop.mkAttr "services" services
        static member inline create props = Feliz.Interop.reactApi.createElement (injectService, createObj !!props)



    type aggregateColumns =
      static member inline aggregateColumns (children: #seq<ReactElement>) = Feliz.Interop.reactElementWithChildren "AggregateColumnsDirective" children
      static member inline create props = Feliz.Interop.reactApi.createElement (aggregateColumnsDirective, createObj !!props)

    type [<StringEnum>] [<RequireQualifiedAccess>] AggregateType =
      | [<CompiledName "sum">] Sum
      | [<CompiledName "average">] Average
      | [<CompiledName "max">] Max
      | [<CompiledName "min">] Min
      | [<CompiledName "count">] Count
      | [<CompiledName "trueCount">] TrueCount
      | [<CompiledName "falseCount">] FalseCount
      | [<CompiledName "custom">] Custom

    type aggregateColumn =
        /// <summary>
        /// Defines the aggregate type of a particular column.
        /// To use multiple aggregates for single column, specify the <c>type</c> as array.
        /// Types of aggregate are,
        /// * sum
        /// * average
        /// * max
        /// * min
        /// * count
        /// * truecount
        /// * falsecount
        /// * custom
        /// &gt; Specify the <c>type</c> value as <c>custom</c> to use custom aggregation.
        /// </summary>
        /// <default>null</default>
        static member inline ``type`` (``type``: AggregateType) =Feliz.Interop.mkAttr "type"  ``type``
        /// <summary>Defines the column name to perform aggregation.</summary>
        /// <default>null</default>
        static member inline field(field: string) =Feliz.Interop.mkAttr "field"  field
        /// <summary>Defines the column name to perform aggregation.</summary>
        /// <default>null</default>
        static member inline field (v:'a -> string)  = Feliz.Interop.mkAttr "field" (v (unbox null))
        /// <summary>
        /// Defines the column name to display the aggregate value. If <c>columnName</c> is not defined,
        /// then <c>field</c> name value will be assigned to the <c>columnName</c> property.
        /// </summary>
        /// <default>null</default>
        static member inline columnName(columnName: string) =Feliz.Interop.mkAttr "columnName"  columnName
        /// <summary>
        /// Format is applied to a calculated value before it is displayed.
        /// Gets the format from the user, which can be standard or custom
        /// <see cref="../../common/internationalization/.number-formatting/"><c>number</c></see>
        /// and <see cref="../../common/internationalization/.number-formatting/"><c>date</c></see> formats.
        /// </summary>
        /// <default>null</default>
        static member inline format(format: Format.FormatOptions) =Feliz.Interop.mkAttr "format"  format
        /// <summary>
        /// Defines the footer cell template as a string for the sum aggregate column.
        ///
        /// Example:
        ///
        ///   aggregateColumn.``type`` AggregateType.Sum
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"Sum: {props}")
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateSum(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?sum;
            x))
        /// <summary>
        /// Defines the footer cell template as a string for the average aggregate column.
        ///
        /// Example:
        ///
        ///   aggregateColumn.``type`` AggregateType.Average
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"Average: {props}")
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateAverage(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?average;
            x))
        /// <summary>
        /// Defines the footer cell template as a string for the max aggregate column.
        ///
        /// Example:
        ///
        ///
        ///   aggregateColumn.``type`` AggregateType.Max
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"Max: {props}")
        ///
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateMax(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?max;
            x))
          /// <summary>
        /// Defines the footer cell template as a string for the min aggregate column.
        ///
        /// Example:
        ///
        ///
        ///   aggregateColumn.``type`` AggregateType.Min
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"Min: {props}")
        ///
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateMin(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?min;
            x))
        /// <summary>
        /// Defines the footer cell template as a string for the count aggregate column.
        ///
        /// Example:
        ///
        ///
        ///   aggregateColumn.``type`` AggregateType.Count
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"Count: {props}")
        ///
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateCount(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?count;
            x))
        /// <summary>
        /// Defines the footer cell template as a string for the true count aggregate column.
        ///
        /// Example:
        ///
        ///
        ///   aggregateColumn.``type`` AggregateType.TrueCount
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"TrueCount: {props}")
        ///
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateTrueCount(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->

            let x = footerTemplate x?trueCount;
            x))
        /// <summary>
        /// Defines the footer cell template as a string for the false count aggregate column.
        ///
        /// Example:
        ///
        ///
        ///   aggregateColumn.``type`` AggregateType.FalseCount
        ///
        ///   aggregateColumn.footerTemplate 
        ///      (fun props ->
        ///            $"FalseCount: {props}")
        ///
        ///
        /// Where `props` is the aggregate 
        /// </summary>
        static member inline footerTemplateFalseCount(footerTemplate:(obj->string))  = Feliz.prop.custom("footerTemplate",
          (fun x ->
            let x = footerTemplate x?falseCount;
            x))

        static member inline groupFooterTemplateSum(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->

              let x = groupFooterTemplate x?sum;
              x))
        static member inline groupFooterTemplateMin(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?min;
              x))
        static member inline groupFooterTemplateMax(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?max;
              x))
        static member inline groupFooterTemplateAverage(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?average;
              x))
        static member inline groupFooterTemplateCount(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?count;
              x))
        static member inline groupFooterTemplateTrueCount(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?trueCount;
              x))
        static member inline groupFooterTemplateFalseCount(groupFooterTemplate:(obj->string)) =Feliz.prop.custom("groupFooterTemplate",
            (fun x ->
              let x = groupFooterTemplate x?falseCount;
              x))
        /// <summary>
        /// Defines the group caption cell template as a string for the aggregate column.
        /// The <c>type</c> name should be used to access aggregate values inside the template.
        /// Additionally, the following fields can be accessed in the template.
        /// * **field**: The current grouped field name.
        /// * **key**: The current grouped field value.
        /// 
        /// {% codeBlock src="grid/group-caption-api/index.ts" %}{% endcodeBlock %}
        /// </summary>
        /// <default>null</default>
        static member inline groupCaptionTemplate(groupCaptionTemplate: string) =Feliz.Interop.mkAttr "groupCaptionTemplate"  groupCaptionTemplate
        /// <summary>
        /// Defines a function to calculate custom aggregate value. The <c>type</c> value should be set to <c>custom</c>.
        /// To use custom aggregate value in the template, use the key as <c>${custom}</c>.
        /// **Total aggregation**: The custom function will be called with the whole data and the current <c>AggregateColumn</c> object.
        /// **Group aggregation**: This will be called with the current group details and the <c>AggregateColumn</c> object.
        /// </summary>
        /// <default>null</default>
        static member inline customAggregate(customAggregate: string) =Feliz.Interop.mkAttr "customAggregate"  customAggregate
        static member inline create props = Feliz.Interop.reactApi.createElement (aggregateColumnDirective, createObj !!props)

    type aggregates =
      static member inline aggregates (children: #seq<ReactElement>) = Feliz.Interop.reactElementWithChildren "AggregatesDirective" children
      static member inline create props = Feliz.Interop.reactApi.createElement (aggregatesDirective, createObj !!props)

    type aggregate =
      static member inline aggregate (children: #seq<ReactElement>) = Feliz.Interop.reactElementWithChildren "AggregateDirective" children
      static member inline create props = Feliz.Interop.reactApi.createElement (aggregateDirective, createObj !!props)
