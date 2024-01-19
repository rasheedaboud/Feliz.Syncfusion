import { PdfExport, ExcelExport, VirtualScroll, Print, Scroll, Selection as Selection$, Search, RowDD, Reorder, Resize, Freeze, ForeignKey, DetailRow, ContextMenu, CommandColumn, ColumnMenu, ColumnChooser, Aggregate, Toolbar, Edit, Group, Filter, Sort, Page, Inject, ColumnDirective, ColumnsDirective, GridComponent, AggregateColumnsDirective, AggregateColumnDirective, AggregateDirective, AggregatesDirective } from "@syncfusion/ej2-react-grids";
import { Record } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Types.js";
import { lambda_type, unit_type, array_type, int32_type, class_type, record_type, bool_type, obj_type, option_type, string_type } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Reflection.js";
import { utcNow, toString } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/Date.js";
import { printf, toText } from "../../FelizTest/src/fable_modules/fable-library.4.0.1/String.js";

export const aggregatesDirective = AggregatesDirective;

export const aggregateDirective = AggregateDirective;

export const aggregateColumnDirective = AggregateColumnDirective;

export const aggregateColumnsDirective = AggregateColumnsDirective;

export const gridComponent = GridComponent;

export const columnsDirective = ColumnsDirective;

export const columnDirective = ColumnDirective;

export const injectService = Inject;

export const Services_Page = Page;

export const Services_Sort = Sort;

export const Services_Filter = Filter;

export const Services_Group = Group;

export const Services_Edit = Edit;

export const Services_ToolBar = Toolbar;

export const Services_Aggregate = Aggregate;

export const Services_ColumnChooser = ColumnChooser;

export const Services_ColumnMenu = ColumnMenu;

export const Services_CommandColumn = CommandColumn;

export const Services_ContextMenu = ContextMenu;

export const Services_DetailRow = DetailRow;

export const Services_ForeignKey = ForeignKey;

export const Services_Freeze = Freeze;

export const Services_Resize = Resize;

export const Services_Reorder = Reorder;

export const Services_RowDD = RowDD;

export const Services_Search = Search;

export const Services_Selection = Selection$;

export const Services_Scroll = Scroll;

export const Services_Print = Print;

export const Services_VirtualScroll = VirtualScroll;

export const Services_ExcelExport = ExcelExport;

export const Services_PdfExport = PdfExport;

export class PredicateModel extends Record {
    "constructor"(field, operator, value, matchCase, ignoreAccent, predicate, actualFilterValue, actualOperator, type, ejpredicate, uid, isForeignKey) {
        super();
        this.field = field;
        this.operator = operator;
        this.value = value;
        this.matchCase = matchCase;
        this.ignoreAccent = ignoreAccent;
        this.predicate = predicate;
        this.actualFilterValue = actualFilterValue;
        this.actualOperator = actualOperator;
        this.type = type;
        this.ejpredicate = ejpredicate;
        this.uid = uid;
        this.isForeignKey = isForeignKey;
    }
}

export function PredicateModel$reflection() {
    return record_type("Syncfusion.SfGrid.PredicateModel", [], PredicateModel, () => [["field", option_type(string_type)], ["operator", option_type(string_type)], ["value", option_type(obj_type)], ["matchCase", bool_type], ["ignoreAccent", bool_type], ["predicate", option_type(string_type)], ["actualFilterValue", option_type(obj_type)], ["actualOperator", option_type(obj_type)], ["type", option_type(string_type)], ["ejpredicate", option_type(obj_type)], ["uid", option_type(string_type)], ["isForeignKey", bool_type]]);
}

export class FilterSettingsModel extends Record {
    "constructor"(type, enableCaseSensitivity, ignoreAccent) {
        super();
        this.type = type;
        this.enableCaseSensitivity = enableCaseSensitivity;
        this.ignoreAccent = ignoreAccent;
    }
}

export function FilterSettingsModel$reflection() {
    return record_type("Syncfusion.SfGrid.FilterSettingsModel", [], FilterSettingsModel, () => [["type", string_type], ["enableCaseSensitivity", bool_type], ["ignoreAccent", bool_type]]);
}

export function FilterSettingsModel_get_Default() {
    return new FilterSettingsModel("Excel", true, true);
}

export class EditSettingsModel extends Record {
    "constructor"(allowEditing, allowAdding, allowDeleting, allowEditOnDblClick, showConfirmDialog, showDeleteConfirmDialog, template, headerTemplate, footerTemplate, mode) {
        super();
        this.allowEditing = allowEditing;
        this.allowAdding = allowAdding;
        this.allowDeleting = allowDeleting;
        this.allowEditOnDblClick = allowEditOnDblClick;
        this.showConfirmDialog = showConfirmDialog;
        this.showDeleteConfirmDialog = showDeleteConfirmDialog;
        this.template = template;
        this.headerTemplate = headerTemplate;
        this.footerTemplate = footerTemplate;
        this.mode = mode;
    }
}

export function EditSettingsModel$reflection() {
    return record_type("Syncfusion.SfGrid.EditSettingsModel", [], EditSettingsModel, () => [["allowEditing", bool_type], ["allowAdding", bool_type], ["allowDeleting", bool_type], ["allowEditOnDblClick", bool_type], ["showConfirmDialog", bool_type], ["showDeleteConfirmDialog", bool_type], ["template", option_type(class_type("Fable.React.ReactElement"))], ["headerTemplate", option_type(class_type("Fable.React.ReactElement"))], ["footerTemplate", option_type(class_type("Fable.React.ReactElement"))], ["mode", string_type]]);
}

export function EditSettingsModel_get_Default() {
    return new EditSettingsModel(false, false, false, true, true, true, void 0, void 0, void 0, "Dialog");
}

export class PageSettingsModel extends Record {
    "constructor"(pageSize, pageSizes) {
        super();
        this.pageSize = (pageSize | 0);
        this.pageSizes = pageSizes;
    }
}

export function PageSettingsModel$reflection() {
    return record_type("Syncfusion.SfGrid.PageSettingsModel", [], PageSettingsModel, () => [["pageSize", int32_type], ["pageSizes", obj_type]]);
}

export function PageSettingsModel_get_Default() {
    return new PageSettingsModel(5, true);
}

export class SelectionSettingsModel extends Record {
    "constructor"(mode, cellSelectionMode, type, checkboxOnly, persistSelection, checkboxMode, enableSimpleMultiRowSelection, enableToggle, allowColumnSelection) {
        super();
        this.mode = mode;
        this.cellSelectionMode = cellSelectionMode;
        this.type = type;
        this.checkboxOnly = checkboxOnly;
        this.persistSelection = persistSelection;
        this.checkboxMode = checkboxMode;
        this.enableSimpleMultiRowSelection = enableSimpleMultiRowSelection;
        this.enableToggle = enableToggle;
        this.allowColumnSelection = allowColumnSelection;
    }
}

export function SelectionSettingsModel$reflection() {
    return record_type("Syncfusion.SfGrid.SelectionSettingsModel", [], SelectionSettingsModel, () => [["mode", option_type(string_type)], ["cellSelectionMode", option_type(string_type)], ["type", option_type(string_type)], ["checkboxOnly", option_type(bool_type)], ["persistSelection", option_type(bool_type)], ["checkboxMode", option_type(string_type)], ["enableSimpleMultiRowSelection", option_type(bool_type)], ["enableToggle", option_type(bool_type)], ["allowColumnSelection", option_type(bool_type)]]);
}

export function SelectionSettingsModel_get_Default() {
    return new SelectionSettingsModel("Row", void 0, void 0, void 0, false, void 0, void 0, true, false);
}

export class Pdf_PdfExportProperties$1 extends Record {
    "constructor"(pageOrientation, pageSize, header, footer, includeHiddenColumn, dataSource, exportType, theme, fileName, hierarchyExportMode, allowHorizontalOverflow) {
        super();
        this.pageOrientation = pageOrientation;
        this.pageSize = pageSize;
        this.header = header;
        this.footer = footer;
        this.includeHiddenColumn = includeHiddenColumn;
        this.dataSource = dataSource;
        this.exportType = exportType;
        this.theme = theme;
        this.fileName = fileName;
        this.hierarchyExportMode = hierarchyExportMode;
        this.allowHorizontalOverflow = allowHorizontalOverflow;
    }
}

export function Pdf_PdfExportProperties$1$reflection(gen0) {
    return record_type("Syncfusion.SfGrid.Pdf.PdfExportProperties`1", [gen0], Pdf_PdfExportProperties$1, () => [["pageOrientation", option_type(string_type)], ["pageSize", option_type(string_type)], ["header", option_type(class_type("Syncfusion.SfGrid.Pdf.PdfHeader"))], ["footer", option_type(class_type("Syncfusion.SfGrid.Pdf.PdfFooter"))], ["includeHiddenColumn", option_type(bool_type)], ["dataSource", option_type(array_type(gen0))], ["exportType", option_type(string_type)], ["theme", option_type(class_type("Syncfusion.SfGrid.Pdf.PdfTheme"))], ["fileName", option_type(string_type)], ["hierarchyExportMode", option_type(string_type)], ["allowHorizontalOverflow", option_type(bool_type)]]);
}

export class Excel_Border extends Record {
    "constructor"(color, lineStyle) {
        super();
        this.color = color;
        this.lineStyle = lineStyle;
    }
}

export function Excel_Border$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.Border", [], Excel_Border, () => [["color", string_type], ["lineStyle", string_type]]);
}

export class Excel_ExcelStyle extends Record {
    "constructor"(fontColor, fontName, fontSize, hAlign, vAlign, bold, indent, italic, underline, backColor, wrapText, borders, numberFormat, type) {
        super();
        this.fontColor = fontColor;
        this.fontName = fontName;
        this.fontSize = (fontSize | 0);
        this.hAlign = hAlign;
        this.vAlign = vAlign;
        this.bold = bold;
        this.indent = (indent | 0);
        this.italic = italic;
        this.underline = underline;
        this.backColor = backColor;
        this.wrapText = wrapText;
        this.borders = borders;
        this.numberFormat = numberFormat;
        this.type = type;
    }
}

export function Excel_ExcelStyle$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelStyle", [], Excel_ExcelStyle, () => [["fontColor", string_type], ["fontName", string_type], ["fontSize", int32_type], ["hAlign", string_type], ["vAlign", string_type], ["bold", bool_type], ["indent", int32_type], ["italic", bool_type], ["underline", bool_type], ["backColor", string_type], ["wrapText", bool_type], ["borders", Excel_Border$reflection()], ["numberFormat", string_type], ["type", string_type]]);
}

export class Excel_ExcelTheme extends Record {
    "constructor"(header, record, caption) {
        super();
        this.header = header;
        this.record = record;
        this.caption = caption;
    }
}

export function Excel_ExcelTheme$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelTheme", [], Excel_ExcelTheme, () => [["header", Excel_ExcelStyle$reflection()], ["record", Excel_ExcelStyle$reflection()], ["caption", Excel_ExcelStyle$reflection()]]);
}

export class Excel_Hyperlink extends Record {
    "constructor"(target, displayText) {
        super();
        this.target = target;
        this.displayText = displayText;
    }
}

export function Excel_Hyperlink$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.Hyperlink", [], Excel_Hyperlink, () => [["target", string_type], ["displayText", string_type]]);
}

export class Excel_ExcelCell extends Record {
    "constructor"(index, colSpan, value, hyperlink, style, rowSpan) {
        super();
        this.index = (index | 0);
        this.colSpan = (colSpan | 0);
        this.value = value;
        this.hyperlink = hyperlink;
        this.style = style;
        this.rowSpan = (rowSpan | 0);
    }
}

export function Excel_ExcelCell$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelCell", [], Excel_ExcelCell, () => [["index", int32_type], ["colSpan", int32_type], ["value", string_type], ["hyperlink", Excel_Hyperlink$reflection()], ["style", Excel_ExcelStyle$reflection()], ["rowSpan", int32_type]]);
}

export class Excel_ExcelRow extends Record {
    "constructor"(index, cells, grouping) {
        super();
        this.index = (index | 0);
        this.cells = cells;
        this.grouping = grouping;
    }
}

export function Excel_ExcelRow$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelRow", [], Excel_ExcelRow, () => [["index", int32_type], ["cells", array_type(Excel_ExcelCell$reflection())], ["grouping", obj_type]]);
}

export class Excel_ExcelHeader extends Record {
    "constructor"(headerRows, rows) {
        super();
        this.headerRows = (headerRows | 0);
        this.rows = rows;
    }
}

export function Excel_ExcelHeader$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelHeader", [], Excel_ExcelHeader, () => [["headerRows", int32_type], ["rows", array_type(Excel_ExcelRow$reflection())]]);
}

export class Excel_ExcelFooter extends Record {
    "constructor"(footerRows, rows) {
        super();
        this.footerRows = (footerRows | 0);
        this.rows = rows;
    }
}

export function Excel_ExcelFooter$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.ExcelFooter", [], Excel_ExcelFooter, () => [["footerRows", int32_type], ["rows", array_type(Excel_ExcelRow$reflection())]]);
}

export class Excel_MultipleExport extends Record {
    "constructor"(type, blankRows) {
        super();
        this.type = type;
        this.blankRows = (blankRows | 0);
    }
}

export function Excel_MultipleExport$reflection() {
    return record_type("Syncfusion.SfGrid.Excel.MultipleExport", [], Excel_MultipleExport, () => [["type", string_type], ["blankRows", int32_type]]);
}

export class ExcelExportProperties$1 extends Record {
    "constructor"(dataSource, enableFilter, exportType, fileName, footer, header, includeHiddenColumn, multipleExport, separator, theme) {
        super();
        this.dataSource = dataSource;
        this.enableFilter = enableFilter;
        this.exportType = exportType;
        this.fileName = fileName;
        this.footer = footer;
        this.header = header;
        this.includeHiddenColumn = includeHiddenColumn;
        this.multipleExport = multipleExport;
        this.separator = separator;
        this.theme = theme;
    }
}

export function ExcelExportProperties$1$reflection(gen0) {
    return record_type("Syncfusion.SfGrid.ExcelExportProperties`1", [gen0], ExcelExportProperties$1, () => [["dataSource", option_type(array_type(gen0))], ["enableFilter", option_type(bool_type)], ["exportType", option_type(string_type)], ["fileName", string_type], ["footer", option_type(Excel_ExcelFooter$reflection())], ["header", option_type(Excel_ExcelHeader$reflection())], ["includeHiddenColumn", option_type(bool_type)], ["multipleExport", option_type(Excel_MultipleExport$reflection())], ["separator", option_type(string_type)], ["theme", option_type(Excel_ExcelTheme$reflection())]]);
}

export function ExcelExportProperties$1_Default() {
    let arg, clo;
    return new ExcelExportProperties$1([], void 0, void 0, (arg = toString(utcNow(), "yyyy_mm_dd"), (clo = toText(printf("%s.xlsx")), clo(arg))), void 0, void 0, void 0, void 0, void 0, void 0);
}

export class ItemModelBase extends Record {
    "constructor"(id, text) {
        super();
        this.id = id;
        this.text = text;
    }
}

export function ItemModelBase$reflection() {
    return record_type("Syncfusion.SfGrid.ItemModelBase", [], ItemModelBase, () => [["id", string_type], ["text", string_type]]);
}

export class ToolBar_ItemModel extends Record {
    "constructor"(id, text, disabled, prefixIcon, suffixIcon, visible, type, click) {
        super();
        this.id = id;
        this.text = text;
        this.disabled = disabled;
        this.prefixIcon = prefixIcon;
        this.suffixIcon = suffixIcon;
        this.visible = visible;
        this.type = type;
        this.click = click;
    }
}

export function ToolBar_ItemModel$reflection() {
    return record_type("Syncfusion.SfGrid.ToolBar.ItemModel", [], ToolBar_ItemModel, () => [["id", string_type], ["text", string_type], ["disabled", bool_type], ["prefixIcon", option_type(string_type)], ["suffixIcon", option_type(string_type)], ["visible", bool_type], ["type", option_type(string_type)], ["click", lambda_type(class_type("Syncfusion.SfGrid.ToolBar.ClickEventArgs"), unit_type)]]);
}

export class Format_DateFormatOptions extends Record {
    "constructor"(type, format) {
        super();
        this.type = type;
        this.format = format;
    }
}

export function Format_DateFormatOptions$reflection() {
    return record_type("Syncfusion.SfGrid.Format.DateFormatOptions", [], Format_DateFormatOptions, () => [["type", string_type], ["format", string_type]]);
}

export class Format_NumberFormatOptions extends Record {
    "constructor"(minimumFractionDigits, maximumFractionDigits, minimumSignificantDigits, maximumSignificantDigits, currency, minimumIntegerDigits, format) {
        super();
        this.minimumFractionDigits = (minimumFractionDigits | 0);
        this.maximumFractionDigits = (maximumFractionDigits | 0);
        this.minimumSignificantDigits = (minimumSignificantDigits | 0);
        this.maximumSignificantDigits = (maximumSignificantDigits | 0);
        this.currency = currency;
        this.minimumIntegerDigits = (minimumIntegerDigits | 0);
        this.format = format;
    }
}

export function Format_NumberFormatOptions$reflection() {
    return record_type("Syncfusion.SfGrid.Format.NumberFormatOptions", [], Format_NumberFormatOptions, () => [["minimumFractionDigits", int32_type], ["maximumFractionDigits", int32_type], ["minimumSignificantDigits", int32_type], ["maximumSignificantDigits", int32_type], ["currency", string_type], ["minimumIntegerDigits", int32_type], ["format", string_type]]);
}

export function Format_NumberFormatOptions_get_Currency() {
    return new Format_NumberFormatOptions(2, 2, 2, 2, "C2", 2, "C2");
}

export class ColumnModel$1 extends Record {
    "constructor"(field, headerText, format, type, width, visible, isIdentity, isPrimaryKey) {
        super();
        this.field = field;
        this.headerText = headerText;
        this.format = format;
        this.type = type;
        this.width = (width | 0);
        this.visible = visible;
        this.isIdentity = isIdentity;
        this.isPrimaryKey = isPrimaryKey;
    }
}

export function ColumnModel$1$reflection(gen0) {
    return record_type("Syncfusion.SfGrid.ColumnModel`1", [gen0], ColumnModel$1, () => [["field", string_type], ["headerText", string_type], ["format", obj_type], ["type", string_type], ["width", int32_type], ["visible", bool_type], ["isIdentity", bool_type], ["isPrimaryKey", bool_type]]);
}

export class GridModel$1 extends Record {
    "constructor"(toolbarClick, columns, dataSource, queryString, toolbar, rowSelected, actionBegin) {
        super();
        this.toolbarClick = toolbarClick;
        this.columns = columns;
        this.dataSource = dataSource;
        this.queryString = queryString;
        this.toolbar = toolbar;
        this.rowSelected = rowSelected;
        this.actionBegin = actionBegin;
    }
}

export function GridModel$1$reflection(gen0) {
    return record_type("Syncfusion.SfGrid.GridModel`1", [gen0], GridModel$1, () => [["toolbarClick", lambda_type(class_type("Syncfusion.SfGrid.GridEvents.ClickEventArgs"), unit_type)], ["columns", array_type(ColumnModel$1$reflection(gen0))], ["dataSource", array_type(gen0)], ["queryString", string_type], ["toolbar", array_type(obj_type)], ["rowSelected", option_type(lambda_type(class_type("Syncfusion.SfGrid.GridEvents.RowSelectEventArgs`1", [gen0]), unit_type))], ["actionBegin", option_type(lambda_type(class_type("Syncfusion.SfGrid.GridEvents.ActionEventArgs"), unit_type))]]);
}

export class Workbook {
    "constructor"() {
    }
}

export function Workbook$reflection() {
    return class_type("Syncfusion.SfGrid.Workbook", void 0, Workbook);
}

export function Workbook_$ctor() {
    return new Workbook();
}

export function Grid_getSelectedRecords(grid) {
    return grid.getSelectedRecords();
}

export function Grid_excelExport(grid, excelExportProperties, isBlob) {
    grid.excelExport(excelExportProperties, false, (void 0), false);
}

export function Grid_refresh(grid) {
    grid.refresh();
}

export class columns {
    "constructor"() {
    }
}

export function columns$reflection() {
    return class_type("Syncfusion.SfGrid.columns", void 0, columns);
}

export class column {
    "constructor"() {
    }
}

export function column$reflection() {
    return class_type("Syncfusion.SfGrid.column", void 0, column);
}

export class inject {
    "constructor"() {
    }
}

export function inject$reflection() {
    return class_type("Syncfusion.SfGrid.inject", void 0, inject);
}

export class aggregateColumns {
    "constructor"() {
    }
}

export function aggregateColumns$reflection() {
    return class_type("Syncfusion.SfGrid.aggregateColumns", void 0, aggregateColumns);
}

export class aggregateColumn {
    "constructor"() {
    }
}

export function aggregateColumn$reflection() {
    return class_type("Syncfusion.SfGrid.aggregateColumn", void 0, aggregateColumn);
}

export class aggregates {
    "constructor"() {
    }
}

export function aggregates$reflection() {
    return class_type("Syncfusion.SfGrid.aggregates", void 0, aggregates);
}

export class aggregate {
    "constructor"() {
    }
}

export function aggregate$reflection() {
    return class_type("Syncfusion.SfGrid.aggregate", void 0, aggregate);
}

