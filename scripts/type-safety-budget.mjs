import fs from "node:fs";
import path from "node:path";

const baseline = JSON.parse(fs.readFileSync("type-safety-baseline.json", "utf8"));
let total = 0;
const byFile = {};

for (const [file, allowed] of Object.entries(baseline.files)) {
  const fullPath = path.join("Felize.Syncfusion", file);
  if (!fs.existsSync(fullPath)) {
    console.error(`Baseline file missing: ${file}`);
    process.exit(1);
  }
  const text = fs.readFileSync(fullPath, "utf8");
  const count = (text.match(/\bobj\b/g) || []).length;
  byFile[file] = count;
  total += count;
  if (count > allowed) {
    console.error(`Unsafe interop budget regressed in ${file}: ${count} > ${allowed}`);
    process.exit(1);
  }
}

if (total > baseline.total) {
  console.error(`Unsafe interop budget regressed: ${total} > ${baseline.total}`);
  process.exit(1);
}

console.log(`Unsafe public binding interop budget: ${total}/${baseline.total}. New obj usage is blocked.`);
