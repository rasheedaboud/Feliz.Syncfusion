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
  SfFileUploader_uploader,
  SfDatePicker_datePickerComponent,
  SfAutoComplete_autoComplete,
  SfNumericTextBox_numericTextBoxComponent,
  ProgressButton_progressButtonComponent,
  SfTextBox_textBox,
  SfCheckBox_checkBox,
  SfChip_chip
} from "../../artifacts/fable/SfInputs.js";

const cases = [
  ["AppBar", appbar, { children: "App bar initial" }],
  ["Button", sfButton, { content: "Button initial" }],
  ["SplitButton", sfSplitButton, { content: "Actions initial", items: [{ text: "One" }] }],
  ["ListView", listViewComponent, { dataSource: [{ id: "1", text: "List initial" }], fields: { id: "id", text: "text" } }],
  ["MenuBar", menuBar, { items: [{ text: "Menu initial" }] }],
  ["Modal", DialogComponent, { visible: true, isModal: false, header: "Dialog initial", content: "Dialog body initial", width: "320px" }],
  ["Sidebar", sidebar, { isOpen: true, width: "180px", children: "Sidebar initial" }],
  ["Grid", gridComponent, { dataSource: [{ id: 1, name: "Grid initial" }] }],
  ["FileUploader", SfFileUploader_uploader, { autoUpload: false, multiple: false, allowedExtensions: ".pdf" }],
  ["DatePicker", SfDatePicker_datePickerComponent, { value: new Date(2026, 8, 23), format: "yyyy-MM-dd" }],
  ["AutoComplete", SfAutoComplete_autoComplete, { dataSource: ["Alpha", "Beta"], value: "Alpha" }],
  ["NumericTextBox", SfNumericTextBox_numericTextBoxComponent, { value: 42 }],
  ["ProgressButton", ProgressButton_progressButtonComponent, { content: "Run initial" }],
  ["TextBox", SfTextBox_textBox, { value: "Text initial" }],
  ["CheckBox", SfCheckBox_checkBox, { label: "Check initial", checked: false }],
  ["Chip", SfChip_chip, { chips: ["Chip initial"] }]
];

const updates = {
  AppBar: { children: "App bar updated" },
  Button: { content: "Button updated" },
  SplitButton: { content: "Actions updated", items: [{ text: "Two" }] },
  ListView: { dataSource: [{ id: "2", text: "List updated" }], fields: { id: "id", text: "text" } },
  MenuBar: { items: [{ text: "Menu updated" }] },
  Modal: { visible: true, isModal: false, header: "Dialog updated", content: "Dialog body updated", width: "360px" },
  Sidebar: { isOpen: true, width: "220px", children: "Sidebar updated" },
  Grid: { dataSource: [{ id: 2, name: "Grid updated" }] },
  FileUploader: { autoUpload: false, multiple: true, allowedExtensions: ".png" },
  DatePicker: { value: new Date(2026, 8, 24), format: "yyyy-MM-dd" },
  AutoComplete: { dataSource: ["Gamma", "Delta"], value: "Gamma" },
  NumericTextBox: { value: 84 },
  ProgressButton: { content: "Run updated" },
  TextBox: { value: "Text updated" },
  CheckBox: { label: "Check updated", checked: true },
  Chip: { chips: ["Chip updated"] }
};

const hostRoot = document.getElementById("root");
hostRoot.style.display = "grid";
hostRoot.style.gap = "16px";
hostRoot.style.padding = "24px";

const roots = new Map();
const components = new Map();
for (const [name, Component, props] of cases) {
  const host = document.createElement("section");
  host.dataset.component = name;
  host.style.minHeight = "56px";
  hostRoot.appendChild(host);
  const root = createRoot(host);
  roots.set(name, root);
  components.set(name, Component);
  root.render(React.createElement(Component, props));
}

window.__componentCases = cases.map(([name]) => name);
window.__updateComponent = (name) => {
  const root = roots.get(name);
  const Component = components.get(name);
  if (!root || !Component || !updates[name]) throw new Error(`Unknown component: ${name}`);
  root.render(React.createElement(Component, updates[name]));
};
