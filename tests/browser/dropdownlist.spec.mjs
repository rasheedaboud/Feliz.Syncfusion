import { test, expect } from "@playwright/test";

test("typed DropDownList selects, updates, and unmounts", async ({ page }) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/typed.html?component=DropDownList");
  await page.waitForFunction(() => window.__typedReady === true);
  const input = page.locator("#typed-dropdownlist input.e-dropdownlist");
  await expect(input).toHaveValue("One");
  await input.focus();
  await input.press("ArrowDown");
  await input.press("Enter");
  await expect(page.locator("#typed-dropdownlist-output")).toHaveText("2");
  await page.evaluate(() => window.__typedUpdateComponent("DropDownList"));
  await expect(input).toHaveValue("Two");
  await page.evaluate(() => window.__typedUnmountComponent("DropDownList"));
  await expect(input).toHaveCount(0);
  expect(errors).toEqual([]);
});
