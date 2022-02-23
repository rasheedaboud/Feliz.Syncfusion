# Feliz.Syncfusion 

A wrapper around a hanfull of Syncfusion React controls.

- Grid
- Modal
- DatePicker
- TextBox
- NumericTextBox
- Autocomplete
- ProgressButton

### Examples

Install the package

```fs
 dotnet add package Felize.Syncfusion
```

Before using any of these components, make sure you install the nessessary npm packages for example to use grid you will need the following:

```fs
  npm install @syncfusion/ej2-react-grids
```
You will also need to load the styles, they offer bootstrap 4/5, material ui and fluent ui.

```fs
importAll "@syncfusion/ej2/<style>.css";
```


In order to access some of the functionality of these components you must use react userRef hook:

```fs
  let grid = React.useRef(None)
  
  let setGridRef =
    (fun (element:Element) ->
      if not (isNull element) then
        grid.current <- Some (element :?> Grid<'a>))
  
```
 You can then access grid methods, for example accessing the grids toolbar click event to export to excel.
 ```fs
   let onToolBarButtonClicked =
    fun (args:SfGridToolBar.ClickEventArgs) ->
      if args.item.id = ExcelExport.value then
        export()
```

Here is how a grid would look:

```fs
module App

open Feliz
open SfGrid

SfGrid.create [
            prop.id id
            prop.ref setGridRef
            SfGrid.height "100%"
            SfGrid.enableAdaptiveUI false
            SfGrid.allowGrouping true
            SfGrid.allowFiltering true
            SfGrid.allowPaging true
            SfGrid.allowSorting true
            SfGrid.allowExcelExport true
            SfGrid.dataSource state.Clients
            SfGrid.showColumnChooser true
            SfGrid.actionBegin (fun x-> actionBegin x)
            SfGrid.rowSelected (fun x -> rowSelected x)
            SfGrid.pageSettings PageSettingsModel.Default
            SfGrid.editSettings EditSettingsModel.Default
            SfGrid.filterSettings FilterSettingsModel.Default
            SfGrid.selectionSettings SelectionSettingsModel.Default
            SfGrid.toolbar [| SfGridToolBar.ItemModel {
                                id=Add.value;
                                text= "Add";
                                disabled= false
                                prefixIcon=Some "e-add";
                                suffixIcon= None;
                                visible=true;
                                ``type``= Some SfGridToolBar.ItemType.Button
                                click = onToolBarButtonClicked };
                            |]
            
            prop.children [
              columns.create [
                prop.children [
                  column.create [
                    column.field "ClientId"
                    column.headerText "ClientId"
                    column.isKey true
                    column.isIdentity true
                    column.isVisible false
                    column.width 200
                  ]
                  column.create [
                    column.field (fun (s:Client) -> nameof s.ClientName)
                    column.headerText "Name"
                    column.width 200
                  ]
                  column.create [
                    column.field (fun (s:Client) -> nameof s.Address)
                    column.headerText "Address"
                    column.width 200
                  ]
                  column.create [
                    column.field (fun (s:Client) -> nameof s.PhoneNumber)
                    column.headerText "Phone No."
                    column.width 200
                  ]
                  column.create [
                    column.field (fun (s:Client) -> nameof s.Email)
                    column.headerText "Email"
                    column.width 200
                  ]
                  column.create [
                    column.field (fun (s:Client) -> nameof s.PurchaseOrderNumber)
                    column.headerText "PO No."
                    column.width 200
                  ]
                ]
              ]

              inject.create [
                inject.services [|
                  Services.Page
                  Services.Aggregate
                  Services.Sort
                  Services.Filter
                  Services.Group
                  Services.ColumnChooser
                  Services.Edit
                  Services.ToolBar
                  Services.Resize
                  Services.ExcelExport
                  Services.DetailRow
                |]
              ]      
            ]
          ]
        ]
      ]
    ]
  ]
```



Here is how a modal would look:

```fs
module App

open Feliz
open SfModal

SfModal.create [
    prop.ref setModalRef
    SfModal.position {X= Position.Offset Offset.Center; Y= Position.Number 70;}
    SfModal.visible true
    SfModal.height (length.percent 90)
    SfModal.isModal true
    SfModal.close (fun x -> DisplayGrid |> dispatch)
    SfModal.width (length.percent 90)
    prop.children [
      AddClient(state,dispatch)
    ]
  ]
```
Here is how a numeric text box would look:

```fs
module App

open Feliz
open SfNumericTextBox

SfTextBox.create [
    SfTextBox.placeholder "Contract Number"
    SfTextBox.floatLabelType FloatLabelType.Always
    SfTextBox.readonly false
    SfTextBox.value ""
    SfTextBox.change handleContractNumberChanged
  ]
```
Here is how a numeric text box would look:

```fs
module App

open Feliz
open SfNumericTextBox

SfNumericTextBox.create [
    SfNumericTextBox.placeholder "Hourly Rate"
    SfNumericTextBox.floatLabelType FloatLabelType.Always
    SfNumericTextBox.strictMode true
    SfNumericTextBox.min 0.01
    SfNumericTextBox.max 1000.00
    SfNumericTextBox.showSpinButton false
    SfNumericTextBox.decimals 2
    SfNumericTextBox.currency CurrencyCode.CAD
    SfNumericTextBox.format "C2"
    SfNumericTextBox.value (Values.Decimal hourlyRate)
    SfNumericTextBox.blur handleHourlyRateChanged
  ]
```
### Documentation

Syncfusion documentation can be found [here](https://ej2.syncfusion.com/react/documentation/getting-started/quick-start).

These controls are a commercial product and requires a paid license for possession or use. Syncfusion’s licensed software, including this component, is subject to the terms and conditions of Syncfusion's EULA (https://www.syncfusion.com/eula/es/). To acquire a license, you can purchase one at https://www.syncfusion.com/sales/products or start a free 30-day trial here (https://www.syncfusion.com/account/manage-trials/start-trials).

A free community license (https://www.syncfusion.com/products/communitylicense) is also available for companies and individuals whose organizations have less than $1 million USD in annual gross revenue and five or fewer developers.
