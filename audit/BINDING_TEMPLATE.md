# Typed binding template (Gate 0)

New controls use `Syncfusion.Typed.<Control>` and a control-specific property interface. Data-bound controls use `I<Control>Property<'Item, 'Value>` so the source, selected value, and change event share types. Non-data controls use a nongeneric property interface. Keep imports and `unbox` inside the binding file; consumers use typed `prop` builders and `create`.

`DropDownList` in `SfDropDownList.fs` is the reference. It exposes source, fields, value, placeholder, enabled, filtering, CSS class, and a typed change event. `Fields<'Item>` contains JavaScript field names: use `nameof` for direct record fields and a literal path only for nested or dynamic fields. Syncfusion event values can be absent, so the event interface uses `option`. Existing `Syncfusion.Sf*` bindings remain available.

The pinned implementation target is Syncfusion EJ2 React 34.2.8. New bindings must be checked against that release's exports and declarations, then mounted and interacted with in Chromium before manifest status changes to complete.
