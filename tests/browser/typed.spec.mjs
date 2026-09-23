import { test, expect } from "@playwright/test";

const openTyped = async (page) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/typed.html");
  await page.waitForFunction(() => window.__typedReady === true);
  return errors;
};

test("typed Feliz ARMM components mount through Fable without runtime errors", async ({ page }) => {
  const errors = await openTyped(page);
  await expect(page.locator("#typed-combo .e-combobox")).toHaveCount(1);
  await expect(page.locator("#typed-multi .e-multiselect").first()).toBeAttached();
  await expect(page.locator("#typed-datetime .e-datetimepicker")).toHaveCount(1);
  await expect(page.locator("#typed-kanban .e-kanban")).toHaveCount(1);
  await expect(page.locator("#typed-date .e-datepicker")).toHaveCount(1);
  await expect(page.locator("#typed-upload .e-upload")).toHaveCount(1);
  await expect(page.locator("#typed-split .e-split-btn-wrapper")).toHaveCount(1);
  await expect(page.locator("#typed-grid .e-grid")).toHaveCount(1);
  await expect(page.locator("#typed-tooltip button")).toContainText("Hover target");
  expect(errors).toEqual([]);
});

const updateCases = [
  ["ComboBox", async page => expect(page.locator("#typed-combo input")).toHaveValue("Beta")],
  ["MultiSelect", async page => expect(page.locator("#typed-multi")).toContainText("Two")],
  ["DateTimePicker", async page => expect(page.locator("#typed-datetime input")).toHaveValue(/2026-09-24/)],
  ["Kanban", async page => expect(page.locator("#typed-kanban")).toContainText("Updated")],
  ["DatePicker", async page => expect(page.locator("#typed-date input")).toHaveValue("2026-09-24")],
  ["FileUploader", async page => expect(page.locator("#typed-upload .e-upload")).toHaveClass(/upload-updated/)],
  ["SplitButton", async page => expect(page.locator("#typed-split")).toContainText("Export updated")],
  ["Grid", async page => expect(page.locator("#typed-grid")).toContainText("Updated")],
];

for (const [name, assertion] of updateCases) {
  test(`typed ${name} propagates React updates without runtime errors`, async ({ page }) => {
    const errors = await openTyped(page);
    await page.evaluate(componentName => window.__typedUpdateComponent(componentName), name);
    await assertion(page);
    expect(errors).toEqual([]);
  });
}

test("typed Tooltip mounts and updates portal content", async ({ page }) => {
  const errors = await openTyped(page);
  const target = page.locator("#typed-tooltip button");
  await target.hover();
  await expect(page.locator(".e-tooltip-wrap")).toContainText("Tooltip initial");

  await page.evaluate(() => window.__typedUpdateComponent("Tooltip"));
  await target.hover();
  await expect(page.locator(".e-tooltip-wrap")).toContainText("Tooltip updated");
  expect(errors).toEqual([]);
});

test("typed Syncfusion Data Query and DataManager execute locally", async ({ page }) => {
  const errors = await openTyped(page);
  const diagnostics = await page.evaluate(() => window.__typedDataQueryDiagnostics());
  expect(diagnostics.allCount).toBe(1);
  expect(diagnostics.countRequired).toBe(true);
  expect(diagnostics.filteredCount).toBe(1);
  expect(errors).toEqual([]);
});
