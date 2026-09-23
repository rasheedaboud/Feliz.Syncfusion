import fs from "node:fs";
import path from "node:path";
const baseline = JSON.parse(fs.readFileSync("type-safety-baseline.json","utf8"));
let total = 0;
const byFile = {};
for (const file of fs.readdirSync("Felize.Syncfusion").filter(f => f.endsWith(".fs"))) {
  const text=fs.readFileSync(path.join("Felize.Syncfusion",file),"utf8");
  const count=(text.match(/\bobj\b/g)||[]).length;
  byFile[file]=count; total+=count;
}
const regressions=Object.entries(byFile).filter(([f,c]) => c > (baseline.files[f] ?? 0));
if (total > baseline.total || regressions.length) {
  console.error("Unsafe interop budget regressed.", {total, allowed: baseline.total, regressions});
  process.exit(1);
}
console.log(`Unsafe interop budget: ${total}/${baseline.total}. New obj usage is blocked; drive this number down toward zero.`);