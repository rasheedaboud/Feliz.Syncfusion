import { test, expect } from "@playwright/test";

const names = [
  "AppBar","Button","SplitButton","ListView","MenuBar","Modal","Sidebar","Grid",
  "FileUploader","DatePicker","AutoComplete","NumericTextBox","ProgressButton",
  "TextBox","CheckBox","Chip"
];

test.beforeEach(async ({ page }) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/");
  await page.waitForFunction(() => Array.isArray(window.__componentCases) && window.__componentCases.length === 16);
  page.__runtimeErrors = errors;
});

test("every exported UI binding mounts real Syncfusion DOM without runtime errors", async ({ page }) => {
  for (const name of names) {
    const host = page.locator(`[data-component="${name}"]`);
    await expect(host).toBeVisible();
    await expect.poll(async () => host.evaluate(el => el.childElementCount)).toBeGreaterThan(0);
  }

  await expect(page.locator('[data-component="Grid"] .e-grid')).toHaveCount(1);
  await expect(page.locator('[data-component="Button"] .e-btn')).toHaveCount(1);
  await expect(page.locator('[data-component="ListView"] .e-listview')).toHaveCount(1);
  expect(page.__runtimeErrors).toEqual([]);
});

const contracts = [
  ["AppBar", async page => {
    await expect(page.locator('[data-component="AppBar"]')).toContainText("App bar initial");
    await page.evaluate(() => window.__updateComponent("AppBar"));
    await expect(page.locator('[data-component="AppBar"]')).toContainText("App bar updated");
  }],
  ["Button", async page => {
    await expect(page.locator('[data-component="Button"] .e-btn')).toContainText("Button initial");
    await page.evaluate(() => window.__updateComponent("Button"));
    await expect(page.locator('[data-component="Button"] .e-btn')).toContainText("Button updated");
  }],
  ["SplitButton", async page => {
    await expect(page.locator('[data-component="SplitButton"]')).toContainText("Actions initial");
    await page.evaluate(() => window.__updateComponent("SplitButton"));
    await expect(page.locator('[data-component="SplitButton"]')).toContainText("Actions updated");
  }],
  ["ListView", async page => {
    await expect(page.locator('[data-component="ListView"]')).toContainText("List initial");
    await page.evaluate(() => window.__updateComponent("ListView"));
    await expect(page.locator('[data-component="ListView"]')).toContainText("List updated");
  }],
  ["MenuBar", async page => {
    await expect(page.locator('[data-component="MenuBar"]')).toContainText("Menu initial");
    await page.evaluate(() => window.__updateComponent("MenuBar"));
    await expect(page.locator('[data-component="MenuBar"]')).toContainText("Menu updated");
  }],
  ["Modal", async page => {
    await expect(page.locator('[data-component="Modal"]')).toContainText("Dialog initial");
    await page.evaluate(() => window.__updateComponent("Modal"));
    await expect(page.locator('[data-component="Modal"]')).toContainText("Dialog updated");
    await expect(page.locator('[data-component="Modal"]')).toContainText("Dialog body updated");
  }],
  ["Sidebar", async page => {
    await expect(page.locator('[data-component="Sidebar"]')).toContainText("Sidebar initial");
    await page.evaluate(() => window.__updateComponent("Sidebar"));
    await expect(page.locator('[data-component="Sidebar"]')).toContainText("Sidebar updated");
  }],
  ["Grid", async page => {
    await expect(page.locator('[data-component="Grid"]')).toContainText("Grid initial");
    await page.evaluate(() => window.__updateComponent("Grid"));
    await expect(page.locator('[data-component="Grid"]')).toContainText("Grid updated");
  }],
  ["FileUploader", async page => {
    const input = page.locator('[data-component="FileUploader"] input[type="file"]');
    await expect(input).not.toHaveAttribute("multiple", "");
    await page.evaluate(() => window.__updateComponent("FileUploader"));
    await expect(input).toHaveAttribute("multiple", "");
    await expect(input).toHaveAttribute("accept", ".png");
  }],
  ["DatePicker", async page => {
    const input = page.locator('[data-component="DatePicker"] input');
    await expect(input).toHaveValue("2026-09-23");
    await page.evaluate(() => window.__updateComponent("DatePicker"));
    await expect(input).toHaveValue("2026-09-24");
  }],
  ["AutoComplete", async page => {
    const input = page.locator('[data-component="AutoComplete"] input');
    await expect(input).toHaveValue("Alpha");
    await page.evaluate(() => window.__updateComponent("AutoComplete"));
    await expect(input).toHaveValue("Gamma");
  }],
  ["NumericTextBox", async page => {
    const input = page.locator('[data-component="NumericTextBox"] input');
    await expect(input).toHaveValue("42");
    await page.evaluate(() => window.__updateComponent("NumericTextBox"));
    await expect(input).toHaveValue("84");
  }],
  ["ProgressButton", async page => {
    await expect(page.locator('[data-component="ProgressButton"]')).toContainText("Run initial");
    await page.evaluate(() => window.__updateComponent("ProgressButton"));
    await expect(page.locator('[data-component="ProgressButton"]')).toContainText("Run updated");
  }],
  ["TextBox", async page => {
    const input = page.locator('[data-component="TextBox"] input');
    await expect(input).toHaveValue("Text initial");
    await page.evaluate(() => window.__updateComponent("TextBox"));
    await expect(input).toHaveValue("Text updated");
  }],
  ["CheckBox", async page => {
    const input = page.locator('[data-component="CheckBox"] input[type="checkbox"]');
    await expect(input).not.toBeChecked();
    await page.evaluate(() => window.__updateComponent("CheckBox"));
    await expect(input).toBeChecked();
    await expect(page.locator('[data-component="CheckBox"]')).toContainText("Check updated");
  }],
  ["Chip", async page => {
    await expect(page.locator('[data-component="Chip"]')).toContainText("Chip initial");
    await page.evaluate(() => window.__updateComponent("Chip"));
    await expect(page.locator('[data-component="Chip"]')).toContainText("Chip updated");
  }]
];

for (const [name, assertUpdate] of contracts) {
  test(`${name} mounts and responds to React prop updates`, async ({ page }) => {
    await assertUpdate(page);
    expect(page.__runtimeErrors).toEqual([]);
  });
}
