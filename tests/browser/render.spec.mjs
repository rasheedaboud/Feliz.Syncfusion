import { test, expect } from "@playwright/test";
const names=["AppBar","Button","SplitButton","ListView","MenuBar","Modal","Sidebar","Grid","FileUploader","DatePicker","AutoComplete","NumericTextBox","ProgressButton","TextBox","CheckBox","Chip"];
test("all Feliz.Syncfusion components mount without runtime errors", async ({page})=>{
  const errors=[]; page.on("pageerror",e=>errors.push(e.message));
  await page.goto("/");
  for(const name of names){
    const host=page.locator(`[data-component="${name}"]`);
    await expect(host).toBeVisible();
    await expect.poll(async()=>await host.evaluate(el=>el.childElementCount)).toBeGreaterThan(0);
  }
  expect(errors).toEqual([]);
});
test("representative widgets receive Syncfusion markup", async ({page})=>{
  await page.goto("/");
  await expect(page.locator('[data-component="Grid"] .e-grid')).toHaveCount(1);
  await expect(page.locator('[data-component="Button"] .e-btn')).toHaveCount(1);
  await expect(page.locator('[data-component="ListView"] .e-listview')).toHaveCount(1);
});