# Required status checks

Protect `master` and require these CI job checks before merge:

- `build`
- `browser-render`

Recommended branch settings: require pull request review, dismiss stale approvals, require branches to be up to date, block force pushes and deletions.

The connected GitHub integration used to maintain this repository can create the workflows but does not expose branch-protection writes, so repository rules must enforce these names in GitHub settings.
