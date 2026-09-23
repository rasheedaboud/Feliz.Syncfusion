# Required status checks

Protect `master` and require these checks before merge:

- `build`
- `component-contracts`

The `component-contracts` check compiles the F# bindings with current Fable, mounts every exported UI wrapper in Chromium, rerenders each wrapper with changed React props, verifies the observable DOM update, and fails on uncaught browser runtime errors.

Recommended repository settings: require pull request review, dismiss stale approvals, require branches to be up to date, and block force pushes/deletions.
