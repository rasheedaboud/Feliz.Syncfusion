import { test, expect } from "@playwright/test";

const routes = [
  "dropdown-list", "list-box", "dropdown-tree", "mention", "multi-column",
  "calendar", "date-range", "time", "text-area", "masked-text", "radio",
  "switch", "slider", "appbar", "sidebar", "list-view", "menu-bar",
  "button", "progress-button", "split-button", "chips", "combo-box",
  "multi-select", "auto-complete", "date-picker", "date-time-picker",
  "text-box", "numeric-text-box", "check-box", "file-uploader",
  "grid", "kanban", "modal", "tooltip"
];

test("gallery routes mount every control and navigation works", async ({ page }) => {
  const errors = [];
  page.on("pageerror", error => errors.push(error.message));
  await page.goto("/");
  await expect(page.locator(".e-appbar")).toBeVisible();
  await expect(page.locator(".e-sidebar")).toBeVisible();
  await expect(page.locator("nav a")).toHaveCount(routes.length);

  for (const route of routes) {
    await page.goto(`/?demo=${route}`);
    await expect(page.locator(`nav a[href="/?demo=${route}"]`)).toHaveClass(/active/);
    await expect(page.locator(".demo-card h1")).toBeVisible();
    await expect(page.locator(".control-stage > *"), route).not.toHaveCount(0);
  }

  await page.getByRole("link", { name: "Calendar", exact: true }).click();
  await expect(page).toHaveURL(/\?demo=calendar$/);
  await page.goBack();
  await expect(page).toHaveURL(/\?demo=tooltip$/);
  await page.locator(".menu-button").dispatchEvent("click");
  await expect(page.locator(".e-sidebar")).toHaveClass(/e-close/);
  expect(errors).toEqual([]);
});

test("gallery opens with usable content on a narrow screen", async ({ page }) => {
  await page.setViewportSize({ width: 390, height: 800 });
  await page.goto("/?demo=calendar");
  await expect(page.locator(".e-sidebar")).toHaveClass(/e-close/);
  const card = await page.locator(".demo-card").boundingBox();
  const calendar = await page.locator(".e-calendar").boundingBox();
  expect(card.x).toBeGreaterThanOrEqual(0);
  expect(card.x + card.width).toBeLessThanOrEqual(390);
  expect(calendar.x + calendar.width).toBeLessThanOrEqual(390);
  await page.locator(".menu-button").dispatchEvent("click");
  await expect(page.locator(".e-sidebar")).toHaveClass(/e-open/);
});
