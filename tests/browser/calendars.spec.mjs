import { test, expect } from "@playwright/test";

const cases = [
  ["Calendar", "#typed-calendar .e-calendar"],
  ["DateRangePicker", "#typed-range input.e-daterangepicker"],
  ["TimePicker", "#typed-time input.e-timepicker"]
];

for (const [name, selector] of cases) {
  test(`${name} mounts and updates through Fable`, async ({ page }) => {
    const errors = [];
    page.on("pageerror", error => errors.push(error.message));
    await page.goto(`/typed.html?component=${name}`);
    await page.waitForFunction(() => window.__typedReady === true);
    await expect(page.locator(selector).first()).toBeAttached();
    await page.evaluate(component => window.__typedUpdateComponent(component), name);
    await expect(page.locator(selector).first()).toBeAttached();
    expect(errors).toEqual([]);
  });
}

test("Calendar selection reports a changed date", async ({ page }) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/typed.html?component=Calendar");
  await page.waitForFunction(() => window.__typedReady === true);
  await page.getByRole("gridcell", { name: "25", exact: true }).click();
  await expect.poll(() => page.evaluate(() => window.__calendarChange?.value)).toBeTruthy();
  expect(errors).toEqual([]);
});
