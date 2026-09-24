import { defineConfig } from "@playwright/test";
const port = Number(process.env.PLAYWRIGHT_PORT ?? 4173);
export default defineConfig({
  testDir: "tests/browser",
  timeout: 30000,
  reporter: [
    ["line"],
    ["html", { outputFolder: "playwright-report", open: "never" }]
  ],
  use: {
    baseURL: `http://127.0.0.1:${port}`,
    headless: true
  },
  webServer: {
    command: `npx vite tests/browser --host 127.0.0.1 --port ${port}`,
    url: `http://127.0.0.1:${port}`,
    reuseExistingServer: false
  }
});
