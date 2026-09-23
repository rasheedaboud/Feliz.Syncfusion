import fs from "node:fs";
const summary=JSON.parse(fs.readFileSync("coverage/coverage-summary.json","utf8"));
let worst=0, worstFile="";
for(const [file,m] of Object.entries(summary)){
  if(file==="total") continue;
  const src=fs.existsSync(file)?fs.readFileSync(file,"utf8"):"";
  const complexity=1+(src.match(/\b(if|for|while|catch|switch)\b|&&|\|\||\?/g)||[]).length;
  const coverage=Math.max(0,Math.min(100,m.branches?.pct ?? m.lines?.pct ?? 0))/100;
  const score=complexity*complexity*Math.pow(1-coverage,3)+complexity;
  if(score>worst){worst=score;worstFile=file;}
}
console.log(`Worst CRAP proxy: ${worst.toFixed(2)} ${worstFile}`);
if(worst>30){console.error("CRAP gate failed: maximum is 30.");process.exit(1);}