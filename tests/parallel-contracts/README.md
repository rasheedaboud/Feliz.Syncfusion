# Parallel control contracts

Run `pwsh tests/parallel-contracts/verify.ps1` from the repository root. The
positive project must build and the negative project must fail with F# type
errors in `Negative.fs`. Keep negative examples in a separate project so the
normal build stays green. These fixtures use the existing typed DatePicker as a
working baseline; add a positive and a negative expression for each new control
after its public API is frozen.

For a generic data-bound control, exercise the same row and selected-value types
through `dataSource`, field mapping, `value`, and `change`. Negative expressions
should test a foreign control's property, a wrong selected-value type, and a
callback that assumes the wrong event value type. Each expected failure needs a
nearby `EXPECT` comment and a corresponding diagnostic check in `verify.ps1`.

The positive DropDownList fixture ties `Choice` and `int` through `dataSource`,
`fields`, `value`, and `change`. The browser contract should render an initial selection,
assert the input text, open the popup, select a different item, and assert the
typed change callback receives the selected value. Rerender with a changed
`dataSource` and `value`, assert the new selection, then unmount and assert no
popup remains. Collect `pageerror` events throughout. Use the existing
`tests/browser/typed.spec.mjs` and `tests/browser/typed-main.js` harness for
mount/update/unmount wiring once the reference control is integrated.
