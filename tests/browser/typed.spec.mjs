import { test, expect } from "@playwright/test";

const openTyped = async (page, component) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  const suffix = component ? `?component=${encodeURIComponent(component)}` : "";
  await page.goto(`/typed.html${suffix}`);
  await page.waitForFunction(() => window.__typedReady === true);
  return errors;
};

const mountCases = [
  ["ComboBox", "#typed-combo .e-combobox"],
  ["MultiSelect", "#typed-multi .e-multiselect"],
  ["DateTimePicker", "#typed-datetime .e-datetimepicker"],
  ["Kanban", "#typed-kanban .e-kanban"],
  ["DatePicker", "#typed-date .e-datepicker"],
  ["FileUploader", "#typed-upload .e-upload"],
  ["SplitButton", "#typed-split .e-split-btn-wrapper"],
  ["Grid", "#typed-grid .e-grid"],
  ["Tooltip", "#typed-tooltip #typed-tooltip-target"]
];

for (const [name, selector] of mountCases) {
  test(`typed ${name} mounts through Fable without runtime errors`, async ({ page }) => {
    const errors = await openTyped(page, name);
    await expect(page.locator(selector).first()).toBeAttached();
    expect(errors).toEqual([]);
  });
}

const updateCases = [
  ["ComboBox", async page => expect(page.locator("#typed-combo input")).toHaveValue("Beta")],
  ["MultiSelect", async page => expect(page.locator("#typed-multi")).toContainText("Two")],
  ["DateTimePicker", async page => expect(page.locator("#typed-datetime input")).toHaveValue(/2026-09-24/)],
  ["Kanban", async page => expect(page.locator("#typed-kanban")).toContainText("Updated")],
  ["DatePicker", async page => expect(page.locator("#typed-date input")).toHaveValue("2026-09-24")],
  ["FileUploader", async page => expect(page.locator("#typed-upload .e-upload")).toHaveClass(/upload-updated/)],
  ["SplitButton", async page => expect(page.locator("#typed-split")).toContainText("Export updated")],
  ["Grid", async page => expect(page.locator("#typed-grid")).toContainText("Updated")]
];

for (const [name, assertion] of updateCases) {
  test(`typed ${name} propagates React updates without runtime errors`, async ({ page }) => {
    const errors = await openTyped(page, name);
    await page.evaluate(componentName => window.__typedUpdateComponent(componentName), name);
    await assertion(page);
    expect(errors).toEqual([]);
  });
}

test("typed Tooltip opens and reflects updated content", async ({ page }) => {
  const errors = await openTyped(page, "Tooltip");
  const target = page.locator("#typed-tooltip-target");
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
  expect(diagnostics.filteredCount).toBe(1);
  expect(diagnostics.countRequired).toBe(true);
  expect(diagnostics.countedCount).toBe(1);
  expect(errors).toEqual([]);
});
