# Syncfusion EJ2 control coverage and F# plan

Reviewed 2026-09-24 against the [Syncfusion React EJ2 control catalog](https://ej2.syncfusion.com/react/documentation/introduction) and this repository's source. Scope is React wrappers over Syncfusion's TypeScript/EJ2 API. The catalog contains some aliases or overlapping product names, so it should not be used as a precise count of distinct npm exports.

## Current coverage

The repository wraps 21 distinct UI controls. Sixteen use the original `Feliz.IReactProperty` API; ComboBox, MultiSelect, DateTimePicker, Tooltip, and Kanban add control-specific property interfaces. DatePicker, FileUploader, SplitButton, and Grid also have duplicate typed facades in `Syncfusion.Typed`. `DataManager`, `Query`, adaptors, and `DialogUtility` are supporting APIs, not UI controls.

| Catalog family | Existing wrapper | Missing control-level wrapper |
| --- | --- | --- |
| Smart components | — | Smart Paste Button, Smart TextArea |
| Grids | Data Grid | Pivot Table, TreeGrid, Spreadsheet |
| Interactive chat | — | AI AssistView, Chat UI |
| File viewers and editors | — | Block Editor, Document Editor, Image Editor, In-place Editor, Rich Text Editor, PDF Viewer, Word Processor (check upstream relationship to Document Editor) |
| Layout | Dialog (`SfModal`), ListView, Tooltip; predefined alert/confirm utilities are partial | Splitter, Dashboard Layout, Card, Avatar, Timeline |
| Data visualization | Kanban | Accumulation Chart, Charts, 3D Chart, Stock Chart, Circular Gauge, Linear Gauge, Maps, Diagram, HeatMap, Range Selector, Smith Chart, Sparkline, Barcode, TreeMap, Bullet Chart, Sankey. The catalog lists both “Maps” and “Map”; resolve these to actual exports before counting. |
| Buttons | Button, Progress Button, SplitButton, Chips | ButtonGroup, DropDownButton (catalog “Dropdown Menu”), Floating Action Button, Speed Dial |
| Calendars | DatePicker, DateTimePicker | Scheduler, Gantt Chart, Calendar, DateRangePicker, TimePicker |
| Inputs | TextBox, Numeric TextBox, CheckBox, File Upload | TextArea, MaskedTextBox, RadioButton, Color Picker, Slider, Switch, Signature, Rating, OTP Input, Speech To Text |
| Forms | — | Form Validator, Query Builder |
| Dropdowns | AutoComplete, ComboBox, MultiSelect | ListBox, DropDownList, DropDownTree, Mention, MultiColumn ComboBox |
| Navigation | Menu Bar, Sidebar, AppBar | Accordion, Carousel, standalone Context Menu, Ribbon, Tabs, Toolbar, TreeView, File Manager, Stepper, Breadcrumb, standalone Pager. Grid's ContextMenu/Pager services are not standalone wrappers. |
| Notifications | — | Toast, Progress Bar, Spinner, Badge, Skeleton, Message |

This is **component coverage**, not full API parity. Existing wrappers expose selected props, events, directives, and methods. Audit those independently before calling any one control complete.

## Repository findings that shape the implementation

- `Felize.Syncfusion/Feliz.Syncfusion.fsproj` targets `netstandard2.1`, declares Syncfusion npm dependencies beginning at `34.2.0`, and includes packages for several currently unwrapped families. `package.json` installs only the families used by existing browser contracts. Keep these lists aligned with the actual supported surface as coverage grows.
- The legacy facade accepts `IReactProperty list` and has an existing `obj` baseline of 239 occurrences. New controls should not grow this baseline. Keep unsafe `unbox`/JS object construction inside private interop functions.
- The newer per-control interfaces improve property isolation but do not yet tie row/item types across `dataSource`, field mappings, values, and callbacks. For example, `Syncfusion.Typed.Grid.Column<'T>` has string fields and a string column type; `SfComboBox` accepts any `'T array` while its change event fixes the selected value to `string`.
- `tests/contracts` and Playwright mount and update the 16 legacy controls and 9 typed test cases, but they do not verify every important property or event. `verify-syncfusion-exports.mjs` is a hand-maintained symbol list. New components need export checks and focused interaction contracts.
- The README lists fewer controls than the code and shows a license registration path that differs from `Syncfusion.SyncfusionLicenseProvider.register`.

## Implementation plan

### 0. Freeze the upstream contract and coverage manifest

1. Pin one supported Syncfusion EJ2 release and its TypeScript declarations for implementation. Retain the existing latest-version compatibility job as an early warning, not as the source of public API types.
2. Generate a reviewed manifest from the actual `@syncfusion/ej2-react-*` package exports and `.d.ts` files: package, component export, model type, directives, injectable services, event types, CSS dependency, and status (`missing`, `partial`, `complete`). Resolve catalog aliases such as Map/Maps and Document Editor/Word Processor there.
3. Publish the manifest in the repository and make CI compare it with declared bindings and imported symbols. Treat a missing wrapper as intentional backlog, but fail on a wrapper whose upstream export disappears.

### 1. Establish one idiomatic typed F# facade

1. Use a private interop module for Fable imports and JavaScript object creation. Expose `SfX.create : ISfXProperty<'T> list -> ReactElement` for data-bound controls, and a nongeneric property type for simple controls. Keep the existing legacy API through a migration window, with obsolete guidance only after equivalent typed coverage exists.
2. Model finite vendor options with `[<StringEnum>]` using exact compiled values. Model nullable values and optional event fields explicitly; use `U2`/`U3` only for genuine TypeScript unions. Give events typed arguments and preserve mutable `cancel` where Syncfusion permits cancellation.
3. Make data source, field descriptor, selected value, templates, and event payload share the same row/value type. Use compile-checked `nameof` for ordinary fields and a clearly marked string path for dynamic or nested fields. Do not rely on runtime reflection in Fable.
4. Add small reusable builders for width/height, templates, children/directives, typed refs, and injection services without introducing a universal property bag. Keep each control's public props specific to that control.
5. Move the four duplicate typed facades and five newer wrappers toward a consistent public namespace before copying either pattern across the full catalog. Document the migration path with compileable F# examples.

### 2. Ship common controls in small, complete vertical slices

| Order | Controls | Reason and required contracts |
| --- | --- | --- |
| A | DropDownList, Calendar, DateRangePicker, TimePicker, TextArea, RadioButton, Switch, Slider | Reuse existing dropdown, calendar, and input families; prove typed value/change/nullability patterns. |
| B | Tabs, Accordion, Toolbar, TreeView, Breadcrumb, Toast, Message, Spinner | Reuse navigation/popups; prove children, templates, selection events, and imperative APIs. |
| C | Splitter, Dashboard Layout, DropDownTree, ListBox, Context Menu, Pager, Query Builder | Prove nested directives, data binding, and constrained events. |
| D | TreeGrid, Charts/Accumulation Chart, Scheduler, Gantt, Pivot Table | Larger service/directive and data contracts; complete one control at a time. |
| E | Diagram, Maps/gauges/other visualization, File Manager, editors/viewers, Spreadsheet, chat and smart controls | Package-heavy or rapidly changing APIs; prioritize from consumer demand after checking licensing, assets, and upstream types. |

Each slice covers a usable baseline: component, essential typed props, data/children/templates, key events, relevant services, and a small example. Avoid empty wrappers that only expose `create`. The coverage manifest is the completion ledger: every distinct catalog control must eventually be implemented or explicitly marked as an alias/non-component with supporting upstream evidence.

### 3. Acceptance gate for every control

- Compile a Fable consumer using valid props and at least one compile-fail contract for an incompatible prop/value/event type.
- Verify package export names and emitted enum/string values against the pinned TypeScript declaration and installed module.
- Mount, interact, rerender with changed props, and unmount in Chromium; assert observable DOM/events and no uncaught runtime errors. Add a focused cancellation/ref test when the control supports one.
- Verify styles and optional package installation instructions. Keep package metadata, manifest, docs, and examples in sync.
- Run `dotnet build`, Fable build, contract build, export check, type-safety budget, Playwright, and NuGet pack/consumer smoke test before releasing each batch. The existing CI scripts provide much of this path, but the contract and manifest checks need extension.

## Parallel agent execution

The root agent is the integration owner. Run at most three implementation agents alongside it. Agents share a workspace, so assign disjoint files and let the root agent edit shared project files, package metadata, the coverage manifest, and the central test harness. An agent must report changes and verification; it should not commit, rebase, or overwrite another lane's work.

### Gate 0: freeze the contract before parallel control work

The root agent implements Phase 0/1 and a complete DropDownList reference control. It records a short binding template covering public namespace (`Syncfusion.Typed.<Control>` for new wrappers), property interface shape, generic item/value relationships, optional/event types, directives, refs, and private interop. It also provides one positive Fable consumer, one negative type contract, and a Chromium interaction example. Existing `Syncfusion.Sf*` APIs remain available during migration.

Two agents can work independently while the root builds that reference:

| Lane | Owned output | Completion evidence |
| --- | --- | --- |
| Catalog agent | New coverage manifest and upstream export/type inventory in `audit/`; no wrapper or shared project edits | Every row links a pinned npm export/model declaration; duplicates and aliases resolved; missing controls allocated to a later queue |
| Contract agent | New reusable contract helpers and negative-type fixtures under `tests/parallel-contracts/`; no edits to existing `tests/contracts/Contracts.fs` | Helpers compile in their own project or include-ready module; one browser scenario shape documented against DropDownList |

The root reviews both outputs, resolves package names against the pinned release, and freezes the template. Only then should control agents start. If the template changes later, the root sends the same revision to every active agent and integrates the change before adding more controls.

### Gate 1: three independent control lanes

Each lane owns **new** files for its controls and a matching include-ready F# contract module and browser spec. Do not edit legacy `SfInputs.fs`, `SfGrid.fs`, or other existing wrappers during this wave.

| Lane | First queue | File ownership |
| --- | --- | --- |
| Dropdowns | ListBox, DropDownTree, Mention, MultiColumn ComboBox | `Felize.Syncfusion/SfDropdown*.fs`, `tests/parallel-contracts/Dropdowns.fs`, `tests/browser/dropdowns.spec.mjs` |
| Calendars | Calendar, DateRangePicker, TimePicker | `Felize.Syncfusion/SfCalendar*.fs`, `tests/parallel-contracts/Calendars.fs`, `tests/browser/calendars.spec.mjs` |
| Inputs | TextArea, MaskedTextBox, RadioButton, Switch, Slider | New `Felize.Syncfusion/SfTextArea.fs`, `SfMaskedTextBox.fs`, `SfRadioButton.fs`, `SfSwitch.fs`, `SfSlider.fs`; `tests/parallel-contracts/Inputs.fs`, `tests/browser/inputs.spec.mjs` |

The root alone updates `Feliz.Syncfusion.fsproj` compile order, `package.json`, npm dependency metadata, `verify-syncfusion-exports.mjs`, the manifest, `tests/contracts/Contracts.fs`, browser entry HTML/JS, CI, and documentation. The root integrates one lane at a time, compiles and runs that lane's interaction tests, then runs the full suite after all three are present. A lane is not complete merely because its source file compiles: its Fable consumer and browser contract must pass through the integrated harness.

### Later waves until the manifest is closed

After Gate 1, pull up to three independent tickets from this queue. Give each ticket one control or a tight package family and unique files. Keep data contracts, child directives, styles, and browser cases with that ticket. Large controls such as Spreadsheet, Gantt, Pivot Table, Diagram, and PDF Viewer each get a dedicated ticket rather than sharing one agent's batch.

1. **Common UI:** remaining inputs, button variants, smart components, navigation, layout, forms, and notifications from the coverage table.
2. **Data controls:** TreeGrid, Pivot Table, Spreadsheet, Scheduler, Gantt, File Manager, and all chart/visualization controls. Sequence components that reuse a package after the first binding in that family is integrated.
3. **Editors and chat:** each editor/viewer, AI AssistView, and Chat UI. Verify upstream package and product aliases before creating separate wrappers.
4. **Existing API parity:** migrate the 21 existing controls to the frozen typed facade, remove duplicate typed definitions through compatibility aliases where possible, and reduce the `obj` budget without breaking existing consumers. This work can run beside independent new-control tickets only when file ownership does not overlap.

For every wave, the root updates the manifest status only after the acceptance gate passes, records exact upstream versions, and runs the full CI/package consumer checks. Final completion means no unassigned or `missing` distinct control remains in the manifest, every `partial` entry has an explicit API-parity disposition, and the packed NuGet artifact passes consumer compilation and browser smoke tests.

### Agent handoff format

Give each agent the pinned Syncfusion version, the frozen DropDownList template, exact controls, owned paths, and a prohibition on shared-file edits. Ask it to return: (1) upstream TypeScript models/exports used, (2) new files, (3) exposed props/events/directives/methods and deliberate omissions, (4) compile/browser evidence, and (5) any proposed shared-contract change for root review. The root accepts a lane only after inspecting its diff and running the integrated gates.

## First deliverable

Complete Gate 0, then dispatch the three Gate 1 lanes. This makes parallelism effective without letting agents invent incompatible F# APIs or conflict in the project and test harness files.
