import { describe, it, expect } from "vitest";
import { AppBarComponent, MenuComponent, SidebarComponent } from "@syncfusion/ej2-react-navigations";
import { ButtonComponent, ChipListComponent, CheckBoxComponent } from "@syncfusion/ej2-react-buttons";
import { ListViewComponent } from "@syncfusion/ej2-react-lists";
import { DialogComponent } from "@syncfusion/ej2-react-popups";
import { GridComponent } from "@syncfusion/ej2-react-grids";
import { TextBoxComponent, NumericTextBoxComponent, UploaderComponent } from "@syncfusion/ej2-react-inputs";
import { DatePickerComponent } from "@syncfusion/ej2-react-calendars";
import { AutoCompleteComponent } from "@syncfusion/ej2-react-dropdowns";
import { SplitButtonComponent, ProgressButtonComponent } from "@syncfusion/ej2-react-splitbuttons";
import { DataManager, ODataV4Adaptor } from "@syncfusion/ej2-data";

const contracts=[
 ["AppBar",AppBarComponent],["MenuBar",MenuComponent],["Sidebar",SidebarComponent],
 ["Button",ButtonComponent],["Chip",ChipListComponent],["CheckBox",CheckBoxComponent],
 ["ListView",ListViewComponent],["Dialog",DialogComponent],["Grid",GridComponent],
 ["TextBox",TextBoxComponent],["NumericTextBox",NumericTextBoxComponent],["Uploader",UploaderComponent],
 ["DatePicker",DatePickerComponent],["AutoComplete",AutoCompleteComponent],
 ["SplitButton",SplitButtonComponent],["ProgressButton",ProgressButtonComponent]
];
describe("Syncfusion runtime contracts",()=>{
  for(const [name,component] of contracts) it(`${name} export is renderable`,()=>expect(component).toBeTypeOf("function"));
  it("DataManager constructs with typed adaptor",()=>{
    const manager=new DataManager({json:[{id:1}], adaptor:new ODataV4Adaptor()});
    expect(manager).toBeTruthy();
    expect(manager.executeLocal).toBeTypeOf("function");
  });
});