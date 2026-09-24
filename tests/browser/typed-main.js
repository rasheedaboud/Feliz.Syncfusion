import "@syncfusion/ej2/material.css";
import {
  mountAll,
  mountComponent,
  updateAll,
  updateComponent,
  dataQueryCount,
  dataQueryDiagnostics
} from "../../artifacts/contracts/Contracts.js";

const component = new URLSearchParams(window.location.search).get("component");
if (component) {
  mountComponent(component);
} else {
  mountAll();
}

window.__typedReady = true;
window.__typedUpdateAll = updateAll;
window.__typedUpdateComponent = updateComponent;
window.__typedDataQueryCount = dataQueryCount;
window.__typedDataQueryDiagnostics = dataQueryDiagnostics;
