import { test, expect } from "@playwright/test";

test.beforeEach(async ({ page }) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/typed.html");
  await page.waitForFunction(() => window.__typedReady === true);
  page.__runtimeErrors = errors;
});

test("typed Feliz ARMM components mount through Fable without runtime errors", async ({ page }) => {
  await expect(page.locator("#typed-combo .e-combobox")).toHaveCount(1);
  await expect(page.locator("#typed-multi .e-multiselect")).toHaveCount(1);
  await expect(page.locator("#typed-datetime .e-datetimepicker")).toHaveCount(1);
  await expect(page.locator("#typed-kanban .e-kanban")).toHaveCount(1);
  await expect(page.locator("#typed-date .e-datepicker")).toHaveCount(1);
  await expect(page.locator("#typed-upload .e-upload")).toHaveCount(1);
  await expect(page.locator("#typed-split .e-split-btn-wrapper")).toHaveCount(1);
  await expect(page.locator("#typed-grid .e-grid")).toHaveCount(1);
  await expect(page.locator("#typed-tooltip button")).toContainText("Hover target");
  expect(page.__runtimeErrors).toEqual([]);
});

test("typed Feliz controls propagate updates", async ({ page }) => {
  await expect(page.locator("#typed-combo input")).toHaveValue("Alpha");
  await expect(page.locator("#typed-date input")).toHaveValue("2026-09-23");
  await expect(page.locator("#typed-datetime input")).toContainText("");
  await expect(page.locator("#typed-split")).toContainText("Export initial");
  await expect(page.locator("#typed-grid")).toContainText("Initial");
  await expect(page.locator("#typed-kanban")).toContainText("Initial");
  await expect(page.locator("#typed-upload .e-upload")).toHaveClass(/upload-initial/);

  await page.evaluate(() => window.__typedUpdateAll());

  await expect(page.locator("#typed-combo input")).toHaveValue("Beta");
  await expect(page.locator("#typed-date input")).toHaveValue("2026-09-24");
  await expect(page.locator("#typed-split")).toContainText("Export updated");
  await expect(page.locator("#typed-grid")).toContainText("Updated");
  await expect(page.locator("#typed-kanban")).toContainText("Updated");
  await expect(page.locator("#typed-upload .e-upload")).toHaveClass(/upload-updated/);
  expect(page.__runtimeErrors).toEqual([]);
});

test("typed Tooltip mounts and updates portal content", async ({ page }) => {
  const target = page.locator("#typed-tooltip button");
  await target.hover();
  await expect(page.locator(".e-tooltip-wrap")).toContainText("Tooltip initial");

  await page.evaluate(() => window.__typedUpdateAll());
  await target.hover();
  await expect(page.locator(".e-tooltip-wrap")).toContainText("Tooltip updated");
  expect(page.__runtimeErrors).toEqual([]);
});

test("typed Syncfusion Data Query and DataManager execute locally", async ({ page }) => {
  expect(await page.evaluate(() => window.__typedDataQueryCount())).toBe(1);
  expect(page.__runtimeErrors).toEqual([]);
});
