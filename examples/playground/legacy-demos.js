import React from "react";
import { listViewComponent } from "../../artifacts/playground/Felize.Syncfusion/SfListView.js";
import { menuBar } from "../../artifacts/playground/Felize.Syncfusion/SfMenuBar.js";
import { sfButton } from "../../artifacts/playground/Felize.Syncfusion/SfButton.js";
import { sfSplitButton } from "../../artifacts/playground/Felize.Syncfusion/SfSplitButton.js";
import { gridComponent } from "../../artifacts/playground/Felize.Syncfusion/SfGrid.js";
import { DialogComponent } from "../../artifacts/playground/Felize.Syncfusion/SfModal.js";
import {
  SfFileUploader_uploader,
  SfDatePicker_datePickerComponent,
  SfAutoComplete_autoComplete,
  SfNumericTextBox_numericTextBoxComponent,
  ProgressButton_progressButtonComponent,
  SfTextBox_textBox,
  SfCheckBox_checkBox,
  SfChip_chip
} from "../../artifacts/playground/Felize.Syncfusion/SfInputs.js";
import { SfComboBox_syncfusionComponent } from "../../artifacts/playground/Felize.Syncfusion/SfComboBox.js";
import { SfMultiSelect_syncfusionComponent } from "../../artifacts/playground/Felize.Syncfusion/SfMultiSelect.js";
import { SfDateTimePicker_syncfusionComponent } from "../../artifacts/playground/Felize.Syncfusion/SfDateTimePicker.js";
import { SfTooltip_syncfusionComponent } from "../../artifacts/playground/Felize.Syncfusion/SfTooltip.js";
import { SfKanban_syncfusionComponent } from "../../artifacts/playground/Felize.Syncfusion/SfKanban.js";

const itemRows = [{ id: "alpha", text: "Alpha" }, { id: "beta", text: "Beta" }];
const kanbanRows = [{ id: 1, status: "Open", title: "First task" }, { id: 2, status: "Done", title: "Second task" }];

const examples = {
  "list-view": [listViewComponent, { dataSource: itemRows, fields: { id: "id", text: "text" } }],
  "menu-bar": [menuBar, { items: [{ text: "File", items: [{ text: "New" }, { text: "Open" }] }, { text: "Help" }] }],
  "button": [sfButton, { content: "Click me", isPrimary: true }],
  "progress-button": [ProgressButton_progressButtonComponent, { content: "Run task", duration: 1500 }],
  "split-button": [sfSplitButton, { content: "Export", items: [{ text: "PDF" }, { text: "CSV" }] }],
  "chips": [SfChip_chip, { chips: ["Alpha", "Beta", "Gamma"] }],
  "combo-box": [SfComboBox_syncfusionComponent, { dataSource: ["Alpha", "Beta", "Gamma"], value: "Alpha", allowCustom: true }],
  "multi-select": [SfMultiSelect_syncfusionComponent, { dataSource: ["Alpha", "Beta", "Gamma"], value: ["Alpha"] }],
  "auto-complete": [SfAutoComplete_autoComplete, { dataSource: ["Alpha", "Beta", "Gamma"], placeholder: "Type a letter" }],
  "date-picker": [SfDatePicker_datePickerComponent, { value: new Date(2026, 8, 24), format: "yyyy-MM-dd" }],
  "date-time-picker": [SfDateTimePicker_syncfusionComponent, { value: new Date(2026, 8, 24, 9, 30), format: "yyyy-MM-dd HH:mm" }],
  "text-box": [SfTextBox_textBox, { value: "Sample text", placeholder: "Enter text" }],
  "numeric-text-box": [SfNumericTextBox_numericTextBoxComponent, { value: 42, min: 0, max: 100 }],
  "check-box": [SfCheckBox_checkBox, { label: "Enable notifications", checked: false }],
  "file-uploader": [SfFileUploader_uploader, { autoUpload: false, multiple: false, allowedExtensions: ".pdf,.png" }],
  "grid": [gridComponent, { dataSource: [{ id: 1, name: "Alpha" }, { id: 2, name: "Beta" }] }],
  "kanban": [SfKanban_syncfusionComponent, { keyField: "status", dataSource: kanbanRows, cardSettings: { headerField: "id", contentField: "title" }, columns: [{ headerText: "Open", keyField: "Open" }, { headerText: "Done", keyField: "Done" }] }],
  "modal": [DialogComponent, { visible: true, isModal: false, header: "Example dialog", content: "A nonmodal Syncfusion dialog.", width: "320px" }],
  "tooltip": [SfTooltip_syncfusionComponent, { content: "Hello from Tooltip", opensOn: "Hover", children: React.createElement("button", {}, "Hover me") }]
};

export function renderLegacy(slug) {
  const example = examples[slug];
  return example ? React.createElement(example[0], example[1]) : React.createElement("p", {}, "Choose a component from the sidebar.");
}
