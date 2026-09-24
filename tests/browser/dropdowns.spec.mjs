import { test, expect } from "@playwright/test";

// The central browser harness must map these names to the include-ready
// ParallelDropdownContracts examples and provide matching host IDs.
const cases = [
  ["ListBox", "#typed-listbox .e-listbox"],
  ["DropDownTree", "#typed-dropdowntree .e-ddt"],
  ["Mention", "#typed-mention-target"],
  ["MultiColumnComboBox", "#typed-multicolumn .e-multicolumncombobox"]
];

for (const [name, selector] of cases) {
  test(`typed ${name} mounts from an F# consumer`, async ({ page }) => {
    const errors = [];
    page.on("pageerror", error => errors.push(error.message));
    await page.goto(`/typed.html?component=${name}`);
    await page.waitForFunction(() => window.__typedReady === true);
    await expect(page.locator(selector).first()).toBeAttached();
    expect(errors).toEqual([]);
  });
}
