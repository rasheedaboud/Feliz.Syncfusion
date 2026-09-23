export default {
  testRunner:"vitest",
  vitest:{configFile:"vitest.config.mjs"},
  mutate:["scripts/verify-syncfusion-exports.mjs","scripts/type-safety-budget.mjs"],
  reporters:["clear-text","progress","html"],
  thresholds:{high:80,low:60,break:60},
  coverageAnalysis:"perTest"
};