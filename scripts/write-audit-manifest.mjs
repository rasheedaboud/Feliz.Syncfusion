import fs from "node:fs";
import { execFileSync } from "node:child_process";

const output = process.argv[2] ?? "artifacts/audit-manifest.json";
const packages = [
  "@syncfusion/ej2",
  "@syncfusion/ej2-base",
  "@syncfusion/ej2-data",
  "@syncfusion/ej2-react-buttons",
  "@syncfusion/ej2-react-calendars",
  "@syncfusion/ej2-react-dropdowns",
  "@syncfusion/ej2-react-grids",
  "@syncfusion/ej2-react-inputs",
  "@syncfusion/ej2-react-lists",
  "@syncfusion/ej2-react-navigations",
  "@syncfusion/ej2-react-popups",
  "@syncfusion/ej2-react-splitbuttons"
];

function command(cmd, args) {
  return execFileSync(cmd, args, { encoding: "utf8" }).trim();
}

function installedVersion(name) {
  const json = JSON.parse(command("npm", ["ls", name, "--json", "--depth=0"]));
  return json.dependencies?.[name]?.version ?? null;
}

const toolList = command("dotnet", ["tool", "list", "--local"])
  .split(/\r?\n/)
  .map(line => line.trim().split(/\s+/))
  .find(parts => parts[0]?.toLowerCase() === "fable");

const manifest = {
  generatedAtUtc: new Date().toISOString(),
  node: process.version,
  dotnet: command("dotnet", ["--version"]),
  fable: toolList?.[1] ?? null,
  syncfusion: Object.fromEntries(packages.map(name => [name, installedVersion(name)]))
};

fs.mkdirSync(new URL(".", `file://${process.cwd()}/${output}`).pathname, { recursive: true });
fs.writeFileSync(output, JSON.stringify(manifest, null, 2) + "\n");
console.log(JSON.stringify(manifest, null, 2));
