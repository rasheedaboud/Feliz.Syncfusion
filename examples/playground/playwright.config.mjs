import { defineConfig } from "@playwright/test";

const port = Number(process.env.PLAYGROUND_TEST_PORT ?? 4183);
export default defineConfig({
  testDir: ".",
  testMatch: "*.spec.mjs",
  timeout: 60000,
  use: { baseURL: `http://127.0.0.1:${port}`, headless: true },
  webServer: {
    command: `npm run playground -- --port ${port} --strictPort`,
    url: `http://127.0.0.1:${port}`,
    reuseExistingServer: false
  }
});
