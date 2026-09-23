import React from "react";
import { createRoot } from "react-dom/client";
import "@syncfusion/ej2/material.css";
import { appbar } from "../../artifacts/fable/SfAppBar.js";
import { sfButton } from "../../artifacts/fable/SfButton.js";
import { sfSplitButton } from "../../artifacts/fable/SfSplitButton.js";
import { listViewComponent } from "../../artifacts/fable/SfListView.js";
import { menuBar } from "../../artifacts/fable/SfMenuBar.js";
import { DialogComponent } from "../../artifacts/fable/SfModal.js";
import { sidebar } from "../../artifacts/fable/SfSideBar.js";
import { gridComponent } from "../../artifacts/fable/SfGrid.js";
import {
  SfFileUploader_uploader, SfDatePicker_datePickerComponent, SfAutoComplete_autoComplete,
  SfNumericTextBox_numericTextBoxComponent, ProgressButton_progressButtonComponent,
  SfTextBox_textBox, SfCheckBox_checkBox, SfChip_chip
} from "../../artifacts/fable/SfInputs.js";

const cases=[
 ["AppBar",appbar,{children:"App bar"}],
 ["Button",sfButton,{content:"Button"}],
 ["SplitButton",sfSplitButton,{content:"Actions",items:[{text:"One"}]}],
 ["ListView",listViewComponent,{dataSource:[{id:"1",text:"One"}],fields:{id:"id",text:"text"}}],
 ["MenuBar",menuBar,{items:[{text:"File"}]}],
 ["Modal",DialogComponent,{visible:true,isModal:false,header:"Dialog",content:"Dialog body",width:"320px"}],
 ["Sidebar",sidebar,{isOpen:true,width:"180px",children:"Sidebar"}],
 ["Grid",gridComponent,{dataSource:[{id:1,name:"One"}]}],
 ["FileUploader",SfFileUploader_uploader,{autoUpload:false,multiple:false}],
 ["DatePicker",SfDatePicker_datePickerComponent,{value:new Date(2026,8,23)}],
 ["AutoComplete",SfAutoComplete_autoComplete,{dataSource:["Alpha","Beta"],value:"Alpha"}],
 ["NumericTextBox",SfNumericTextBox_numericTextBoxComponent,{value:42}],
 ["ProgressButton",ProgressButton_progressButtonComponent,{content:"Run"}],
 ["TextBox",SfTextBox_textBox,{value:"Text"}],
 ["CheckBox",SfCheckBox_checkBox,{label:"Check",checked:true}],
 ["Chip",SfChip_chip,{chips:["One","Two"]}]
];

const root=document.getElementById("root");
root.style.display="grid"; root.style.gap="16px"; root.style.padding="24px";
for(const [name,Component,props] of cases){
  const host=document.createElement("section");
  host.dataset.component=name;
  host.style.minHeight="56px";
  root.appendChild(host);
  createRoot(host).render(React.createElement(Component,props));
}
window.__componentCases=cases.map(([name])=>name);