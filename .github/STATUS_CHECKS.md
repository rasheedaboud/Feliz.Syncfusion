# Required status checks

Protect `master` and require these checks before merge:

- `build`
- `component-contracts`
- `latest-audit-package`

The `component-contracts` check compiles the F# bindings with the repository-supported toolchain, mounts every exported UI wrapper in Chromium, rerenders each wrapper with changed React props, verifies the observable DOM update, and fails on uncaught browser runtime errors.

The `latest-audit-package` check upgrades Fable and Syncfusion packages to the latest stable versions available at CI run time, repeats compile/export/type-safety and browser mount/update contracts, then creates a uniquely versioned pre-release NuGet package plus an audit manifest recording the exact versions tested.

Recommended repository settings: require pull request review, dismiss stale approvals, require branches to be up to date, and block force pushes/deletions.
