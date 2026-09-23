namespace Syncfusion.Typed

open System
open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IDatePickerProperty = interface end
type IFileUploaderProperty = interface end
type ISplitButtonProperty = interface end
type IGridProperty = interface end

module DatePicker =
    let private pickerComponent: ReactElement = import "DatePickerComponent" "@syncfusion/ej2-react-calendars"

    [<AllowNullLiteral>]
    type ChangeEventArgs =
        abstract value: DateTime option
        abstract element: HTMLInputElement option
        abstract isInteracted: bool option

    [<Erase>]
    type prop =
        static member inline value(value: DateTime) : IDatePickerProperty = unbox ("value", value)
        static member inline format(value: string) : IDatePickerProperty = unbox ("format", value)
        static member inline placeholder(value: string) : IDatePickerProperty = unbox ("placeholder", value)
        static member inline readonly(value: bool) : IDatePickerProperty = unbox ("readonly", value)
        static member inline enabled(value: bool) : IDatePickerProperty = unbox ("enabled", value)
        static member inline min(value: DateTime) : IDatePickerProperty = unbox ("min", value)
        static member inline max(value: DateTime) : IDatePickerProperty = unbox ("max", value)
        static member inline cssClass(value: string) : IDatePickerProperty = unbox ("cssClass", value)
        static member inline change(callback: ChangeEventArgs -> unit) : IDatePickerProperty = unbox ("change", callback)

    let create (props: IDatePickerProperty list) : ReactElement =
        ReactLegacy.createElement(pickerComponent, createObj !!props)

module FileUploader =
    let private uploaderComponent: ReactElement = import "UploaderComponent" "@syncfusion/ej2-react-inputs"

    [<AllowNullLiteral>]
    type FileInfo =
        abstract name: string
        abstract size: float
        abstract ``type``: string
        abstract rawFile: File option

    [<AllowNullLiteral>]
    type SelectedEventArgs =
        abstract filesData: ResizeArray<FileInfo>
        abstract cancel: bool with get, set

    [<Erase>]
    type prop =
        static member inline allowedExtensions(value: string) : IFileUploaderProperty = unbox ("allowedExtensions", value)
        static member inline maxFileSize(value: float) : IFileUploaderProperty = unbox ("maxFileSize", value)
        static member inline multiple(value: bool) : IFileUploaderProperty = unbox ("multiple", value)
        static member inline autoUpload(value: bool) : IFileUploaderProperty = unbox ("autoUpload", value)
        static member inline cssClass(value: string) : IFileUploaderProperty = unbox ("cssClass", value)
        static member inline selected(callback: SelectedEventArgs -> unit) : IFileUploaderProperty = unbox ("selected", callback)

    let create (props: IFileUploaderProperty list) : ReactElement =
        ReactLegacy.createElement(uploaderComponent, createObj !!props)

module SplitButton =
    let private splitButtonComponent: ReactElement = import "SplitButtonComponent" "@syncfusion/ej2-react-splitbuttons"

    type Item = {
        id: string
        text: string
        iconCss: string option
        disabled: bool option
    }

    [<AllowNullLiteral>]
    type MenuEventArgs =
        abstract item: Item

    [<Erase>]
    type prop =
        static member inline content(value: string) : ISplitButtonProperty = unbox ("content", value)
        static member inline iconCss(value: string) : ISplitButtonProperty = unbox ("iconCss", value)
        static member inline cssClass(value: string) : ISplitButtonProperty = unbox ("cssClass", value)
        static member inline disabled(value: bool) : ISplitButtonProperty = unbox ("disabled", value)
        static member inline items(value: Item array) : ISplitButtonProperty = unbox ("items", value)
        static member inline click(callback: MouseEvent -> unit) : ISplitButtonProperty = unbox ("click", callback)
        static member inline select(callback: MenuEventArgs -> unit) : ISplitButtonProperty = unbox ("select", callback)

    let create (props: ISplitButtonProperty list) : ReactElement =
        ReactLegacy.createElement(splitButtonComponent, createObj !!props)

module Grid =
    let private gridComponentTyped: ReactElement = import "GridComponent" "@syncfusion/ej2-react-grids"
    let private injectComponent: ReactElement = import "Inject" "@syncfusion/ej2-react-grids"

    type Column<'T> = {
        field: string
        headerText: string
        width: float option
        visible: bool option
        isPrimaryKey: bool option
        ``type``: string option
        format: string option
    }

    [<StringEnum; RequireQualifiedAccess>]
    type SortDirection = Ascending | Descending

    [<StringEnum; RequireQualifiedAccess>]
    type FilterType = FilterBar | Menu | Excel | CheckBox

    [<StringEnum; RequireQualifiedAccess>]
    type SelectionType = Single | Multiple

    [<StringEnum; RequireQualifiedAccess>]
    type SelectionMode = Row | Cell | Both

    type GroupSettings = { columns: string array }
    type SortColumn = { field: string; direction: SortDirection }
    type SortSettings = { columns: SortColumn array }
    type FilterValue = U4<string, float, bool, DateTime>
    type FilterColumn = { field: string; operatorName: string; value: FilterValue }
    type FilterSettings = { ``type``: FilterType option; columns: FilterColumn array option }
    type SelectionSettings = { ``type``: SelectionType option; mode: SelectionMode option }

    [<AllowNullLiteral>]
    type RowSelectEventArgs<'T> =
        abstract data: 'T
        abstract rowIndex: float option

    [<AllowNullLiteral>]
    type RecordDoubleClickEventArgs<'T> =
        abstract rowData: 'T
        abstract rowIndex: float option

    [<AllowNullLiteral>]
    type RowDataBoundEventArgs<'T> =
        abstract data: 'T
        abstract row: HTMLElement

    [<AllowNullLiteral>]
    type DetailDataBoundEventArgs<'T> =
        abstract data: 'T
        abstract detailElement: HTMLElement

    [<AllowNullLiteral>]
    type ContextMenuItem =
        abstract id: string option
        abstract text: string option

    [<AllowNullLiteral>]
    type RowInfo<'T> =
        abstract rowData: 'T option

    [<AllowNullLiteral>]
    type ContextMenuClickEventArgs<'T> =
        abstract item: ContextMenuItem
        abstract rowInfo: RowInfo<'T> option

    type IGridService = interface end

    [<Erase>]
    type prop =
        static member inline dataSource(value: 'T array) : IGridProperty = unbox ("dataSource", value)
        static member inline columns(value: Column<'T> array) : IGridProperty = unbox ("columns", value)
        static member inline query(value: Data.Query) : IGridProperty = unbox ("query", value)
        static member inline allowPaging(value: bool) : IGridProperty = unbox ("allowPaging", value)
        static member inline allowSorting(value: bool) : IGridProperty = unbox ("allowSorting", value)
        static member inline allowFiltering(value: bool) : IGridProperty = unbox ("allowFiltering", value)
        static member inline allowGrouping(value: bool) : IGridProperty = unbox ("allowGrouping", value)
        static member inline allowExcelExport(value: bool) : IGridProperty = unbox ("allowExcelExport", value)
        static member inline allowResizing(value: bool) : IGridProperty = unbox ("allowResizing", value)
        static member inline allowReordering(value: bool) : IGridProperty = unbox ("allowReordering", value)
        static member inline allowSelection(value: bool) : IGridProperty = unbox ("allowSelection", value)
        static member inline enableImmutableMode(value: bool) : IGridProperty = unbox ("enableImmutableMode", value)
        static member inline showColumnChooser(value: bool) : IGridProperty = unbox ("showColumnChooser", value)
        static member inline showColumnMenu(value: bool) : IGridProperty = unbox ("showColumnMenu", value)
        static member inline groupSettings(value: GroupSettings) : IGridProperty = unbox ("groupSettings", value)
        static member inline sortSettings(value: SortSettings) : IGridProperty = unbox ("sortSettings", value)
        static member inline filterSettings(value: FilterSettings) : IGridProperty = unbox ("filterSettings", value)
        static member inline selectionSettings(value: SelectionSettings) : IGridProperty = unbox ("selectionSettings", value)
        static member inline height(value: string) : IGridProperty = unbox ("height", value)
        static member inline width(value: string) : IGridProperty = unbox ("width", value)
        static member inline rowSelected(callback: RowSelectEventArgs<'T> -> unit) : IGridProperty = unbox ("rowSelected", callback)
        static member inline recordDoubleClick(callback: RecordDoubleClickEventArgs<'T> -> unit) : IGridProperty = unbox ("recordDoubleClick", callback)
        static member inline rowDataBound(callback: RowDataBoundEventArgs<'T> -> unit) : IGridProperty = unbox ("rowDataBound", callback)
        static member inline detailDataBound(callback: DetailDataBoundEventArgs<'T> -> unit) : IGridProperty = unbox ("detailDataBound", callback)
        static member inline contextMenuClick(callback: ContextMenuClickEventArgs<'T> -> unit) : IGridProperty = unbox ("contextMenuClick", callback)
        static member inline children(value: ReactElement list) : IGridProperty = unbox ("children", value)

    [<RequireQualifiedAccess>]
    module service =
        let Page: IGridService = import "Page" "@syncfusion/ej2-react-grids"
        let Pager: IGridService = import "Pager" "@syncfusion/ej2-grids"
        let Filter: IGridService = import "Filter" "@syncfusion/ej2-react-grids"
        let Sort: IGridService = import "Sort" "@syncfusion/ej2-react-grids"
        let Group: IGridService = import "Group" "@syncfusion/ej2-react-grids"
        let Selection: IGridService = import "Selection" "@syncfusion/ej2-react-grids"
        let ExcelExport: IGridService = import "ExcelExport" "@syncfusion/ej2-react-grids"
        let Resize: IGridService = import "Resize" "@syncfusion/ej2-react-grids"
        let Reorder: IGridService = import "Reorder" "@syncfusion/ej2-react-grids"
        let DetailRow: IGridService = import "DetailRow" "@syncfusion/ej2-react-grids"
        let ColumnChooser: IGridService = import "ColumnChooser" "@syncfusion/ej2-react-grids"
        let ColumnMenu: IGridService = import "ColumnMenu" "@syncfusion/ej2-react-grids"
        let ContextMenu: IGridService = import "ContextMenu" "@syncfusion/ej2-react-grids"

    let injectServices (services: IGridService list) : ReactElement =
        ReactLegacy.createElement(injectComponent, createObj [ "services" ==> services ])

    let create (props: IGridProperty list) : ReactElement =
        ReactLegacy.createElement(gridComponentTyped, createObj !!props)
