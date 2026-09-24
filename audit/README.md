# EJ2 React coverage inventory

This first-wave inventory is pinned to the published `34.2.8` npm tarballs. The repository's browser dependencies now use exact `34.2.8` versions; `34.2.0` itself is not published for the checked React packages. `coverage.json` records the React export, upstream model, declaration path, and current binding status for the controls in Gate 0 and Gate 1 of `CONTROL_COVERAGE_PLAN.md`.

The declaration path is relative to each `@syncfusion/ej2-react-*` package. Each component declaration imports its model from the corresponding `@syncfusion/ej2-*` core package, and the package root `index.d.ts` reexports `src/index.d.ts`. The model is a **core package type**, not a model declared by the React wrapper.

Notable catalog corrections:

- `RadioButtonComponent` and `SwitchComponent` belong to `ej2-react-buttons`, not `ej2-react-inputs`.
- `MultiColumnComboBoxComponent` has its own `ej2-react-multicolumn-combobox` package; it is absent from `ej2-react-dropdowns`.
- `DateRangePicker` exposes `PresetsDirective` and `PresetDirective`; `MultiColumnComboBox` exposes column directives. Include these when their APIs are bound.
- `SmartTextAreaComponent` is exported from `ej2-react-inputs`; `SmartPasteButtonComponent` is exported from `ej2-react-buttons`.
- The catalog label “Word Processor” appears to refer to Document Editor, and “Map”/“Maps” to one component. Those aliases are not counted in this first-wave file pending a wider package inventory.

The `partial` status means a typed control-level F# wrapper, consumer compile contract, and at least a browser mount contract exist, while API parity or parts of the full interaction gate remain open. This inventory is intentionally limited to the first wave; the complete catalog remains tracked in `CONTROL_COVERAGE_PLAN.md`.

Source: exact npm tarballs for the packages named in `coverage.json`, downloaded with `npm pack <package>@34.2.8`; package `index.d.ts`, `src/index.d.ts`, and listed component declaration files were inspected on 2026-09-24. For example, the [dropdowns package at 34.2.8](https://www.npmjs.com/package/@syncfusion/ej2-react-dropdowns/v/34.2.8) and its [declarations](https://unpkg.com/@syncfusion/ej2-react-dropdowns@34.2.8/src/drop-down-list/dropdownlist.component.d.ts).
