import fs from "node:fs";
import path from "node:path";

const expected = {
  "@syncfusion/ej2-react-navigations": ["AppBarComponent","MenuComponent","SidebarComponent"],
  "@syncfusion/ej2-react-buttons": ["ButtonComponent","ChipListComponent","CheckBoxComponent","RadioButtonComponent","SwitchComponent"],
  "@syncfusion/ej2-react-lists": ["ListViewComponent"],
  "@syncfusion/ej2-react-popups": ["DialogComponent","DialogUtility","TooltipComponent"],
  "@syncfusion/ej2-react-grids": ["GridComponent","ColumnsDirective","ColumnDirective","Inject","AggregatesDirective","AggregateDirective","AggregateColumnDirective","AggregateColumnsDirective","Page","Sort","Filter","Group","Edit","Toolbar","Aggregate","ColumnChooser","ColumnMenu","CommandColumn","ContextMenu","DetailRow","ForeignKey","Freeze","Resize","Reorder","RowDD","Search","Selection","Scroll","Print","VirtualScroll","ExcelExport","PdfExport"],
  "@syncfusion/ej2-react-inputs": ["UploaderComponent","NumericTextBoxComponent","TextBoxComponent","TextAreaComponent","MaskedTextBoxComponent","SliderComponent"],
  "@syncfusion/ej2-react-calendars": ["DatePickerComponent","DateTimePickerComponent","CalendarComponent","DateRangePickerComponent","TimePickerComponent"],
  "@syncfusion/ej2-react-dropdowns": ["AutoCompleteComponent","ComboBoxComponent","MultiSelectComponent","DropDownListComponent","ListBoxComponent","DropDownTreeComponent","MentionComponent"],
  "@syncfusion/ej2-react-multicolumn-combobox": ["MultiColumnComboBoxComponent"],
  "@syncfusion/ej2-react-splitbuttons": ["SplitButtonComponent","ProgressButtonComponent"],
  "@syncfusion/ej2-react-kanban": ["KanbanComponent","ColumnsDirective","ColumnDirective"],
  "@syncfusion/ej2-grids": ["Pager"],
  "@syncfusion/ej2-data": ["DataManager","ODataV4Adaptor","JsonAdaptor","Query","Predicate"]
};

const failures = [];
const manifest = JSON.parse(fs.readFileSync("audit/coverage.json", "utf8"));
for (const control of manifest.controls) {
  const packageFile = path.join("node_modules", control.package, "package.json");
  if (!fs.existsSync(packageFile)) {
    failures.push(`${control.name}: ${control.package} is not installed`);
    continue;
  }
  const installedVersion = JSON.parse(fs.readFileSync(packageFile, "utf8")).version;
  if (process.env.SYNCFUSION_ALLOW_LATEST !== "1" && installedVersion !== manifest.syncfusionVersion) failures.push(`${control.name}: expected ${manifest.syncfusionVersion}, found ${installedVersion}`);
  const packageExports = await import(control.package);
  if (!(control.export in (packageExports.default ?? packageExports))) failures.push(`${control.name}: missing ${control.export}`);
}
for (const [pkg, names] of Object.entries(expected)) {
  const imported = await import(pkg);
  const mod = imported.default ?? imported;
  for (const name of names) if (!(name in mod)) failures.push(`${pkg} missing export ${name}`);
}

for (const file of fs.readdirSync("Felize.Syncfusion").filter(f => f.endsWith(".fs"))) {
  const text = fs.readFileSync(path.join("Felize.Syncfusion", file), "utf8");
  for (const match of text.matchAll(/(?:import\s+|Import\(")([^"]+)/g)) {
    if (match[1] !== match[1].trim()) failures.push(`${file}: import symbol has surrounding whitespace: "${match[1]}"`);
  }
}
if (failures.length) {
  console.error(failures.join("\n"));
  process.exit(1);
}
console.log("Syncfusion export/import contract verified.");
