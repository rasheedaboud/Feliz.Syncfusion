# Type-safety strategy

Syncfusion ships TypeScript declaration files. They are the source of truth for the low-level JavaScript API.

This package uses a curated Feliz facade rather than publishing raw generator output. CI now:
1. verifies every imported Syncfusion symbol against the installed current package;
2. compiles the binding with current Fable;
3. mounts every UI binding in Chromium;
4. blocks any increase in existing `obj` escape hatches.

## Generator research

As of September 2026, ts2fable's stable npm release is old and its own documentation says generated bindings can require manual correction. Glutinum follows the safer model: generate a binding baseline, then curate and test it. We therefore do not replace the public API with unchecked generator output.

## Full type-safety migration

The remaining `obj` budget is technical debt, not an accepted design target. Each touched API should replace `obj`, stringly typed choices and broad erased unions with typed interfaces, discriminated/string enums, generic records, and typed event arguments. The CI budget can only decrease and is intended to reach zero.
