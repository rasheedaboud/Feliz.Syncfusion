import { test, expect } from "@playwright/test";

async function open(page, component) {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto(`/typed.html?component=${component}`);
  await page.waitForFunction(() => window.__typedReady === true);
  return errors;
}

const cases = [
  ["TextArea", "#typed-textarea textarea"],
  ["MaskedTextBox", "#typed-maskedtextbox input"],
  ["RadioButton", "#typed-radiobutton input[type=radio]"],
  ["Switch", "#typed-switch .e-switch-wrapper"],
  ["Slider", "#typed-slider .e-slider"],
];

for (const [name, selector] of cases) {
  test(`${name} mounts, updates, and unmounts`, async ({ page }) => {
    const errors = await open(page, name);
    await expect(page.locator(selector)).toBeAttached();
    await page.evaluate(component => window.__typedUpdateComponent(component), name);
    await expect(page.locator(selector)).toBeAttached();
    await page.evaluate(component => window.__typedUnmountComponent(component), name);
    await expect(page.locator(selector)).toHaveCount(0);
    expect(errors).toEqual([]);
  });
}

test("TextArea emits typed input value", async ({ page }) => {
  const errors = await open(page, "TextArea");
  await page.locator("#typed-textarea textarea").fill("Edited note");
  await expect(page.locator("#typed-textarea-output")).toHaveText("Edited note");
  expect(errors).toEqual([]);
});

test("Switch emits checked state", async ({ page }) => {
  const errors = await open(page, "Switch");
  await page.getByRole("switch").dispatchEvent("click");
  await expect(page.locator("#typed-switch-output")).toHaveText("true");
  expect(errors).toEqual([]);
});
