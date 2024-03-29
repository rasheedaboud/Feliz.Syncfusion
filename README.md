# Feliz.Syncfusion 

A wrapper around a hanfull of Syncfusion React controls.

- ListView
- SideBar
- AppBar
- Grid
- Modal
- DatePicker
- TextBox
- NumericTextBox
- Autocomplete
- ProgressButton
- FileUploader
- Chip
- DataManager
- MenuBar
- Button
- SplitButton

### Installation

#### 1. Install the package

```fs
 dotnet add package Felize.Syncfusion
```
or 

```fs
 dotnet paket add Felize.Syncfusion -p <CLIENT  PROJECT>
```
#### 2. NPM Packages

Before using any of these components, make sure you install the nessessary npm packages for example to use grid you will need the following:

```fs
  npm install @syncfusion/ej2-react-grids
  npm install @syncfusion/ej2-base
```

As an alternative use femto, below assumes youre using default SAFE template. Run following from client project folder:
```fs
 dotnet tool install femto 
 
 femto install Feliz.Syncfusion
 femto --resolve

```
#### 3. Styles

You will also need to load the styles, they offer bootstrap 4/5, material ui and fluent ui.

```fs
importAll "@syncfusion/ej2/<style>.css";
```
Or as an alternative simply add cnd link to head of your index.html

```html
<head>
 <link href="https://cdn.syncfusion.com/ej2/ej2-react-inputs/styles/<style>.css" rel="stylesheet" />
</head>
```
#### 4. Liscense

These controls are a commercial product and requires a paid license for possession or use. Syncfusion does offer a community license. more information can be found [here](https://www.syncfusion.com/sales/communitylicense).

Add the following line of code to Index.fs:

```fs
 Feliz.Syncfusion.License.register("<YOUR KEY HERE>")
```


### Examples

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
      if args.item.id = "ExcelExport" then
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
  ]
```
Here is how a text box would look:

```fs
module App

open Feliz
open SfNumericTextBox

SfTextBox.create [
    SfTextBox.placeholder "Contract Number"
    SfTextBox.floatLabelType FloatLabelType.Always
    SfTextBox.readonly false
    SfTextBox.value ""
    SfTextBox.change handleChange
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
    SfNumericTextBox.blur handleChanged
  ]
```
Here is how file uploader would look:

```fs
module App

open Feliz
open SfFileUploader

FileUploader.create [
   FileUploader.allowedExtensions ".pdf,.jpeg,.jpg,.svg"
   FileUploader.buttons { browse = Some "Select File"; clear=Some ""; upload = Some "" }
   FileUploader.cssClass  "some-css-class"
   FileUploader.maxFileSize  5_242_881
   FileUploader.multiple false
   FileUploader.selected (fun x -> handleFileEvent x)
 ]
```
Here is how a date picker would look:

```fs
module App

open Feliz
open SfDatePicker

SfDatePicker.create [
 SfDatePicker.floatLabelType FloatLabelType.Always
 SfDatePicker.placeholder "Start Date"
 SfDatePicker.format "yyy-MM-dd"
 SfDatePicker.showClearButton false
 SfDatePicker.value startDate
 SfDatePicker.change handleChanged
 SfDatePicker.strictMode true
 SfDatePicker.min (DateTime.UtcNow.AddDays(-365))
 SfDatePicker.max (DateTime.UtcNow.AddDays(365))
 SfDatePicker.cssClass "some-css-class"
]
```
Here is example using Datamanager to populate data for a grid:

```fs
module App

open Feliz
open SfGrid
open SfDataManager

    let options =
       {| url = "https://services.odata.org/V4/(S(50tkajnxavrtffka05w4ebbb))/TripPinServiceRW/People"
           adaptor = new OdataV4Adaptor() |}

    let manager = new DataManager(options)


    Html.div [
        prop.children [
            SfGrid.create [
                prop.id (System.Guid.NewGuid().ToString())
                SfGrid.dataSource manager
                SfGrid.height "100%"
                SfGrid.enableAdaptiveUI false
                SfGrid.allowGrouping true
                SfGrid.allowFiltering true
                SfGrid.allowPaging true
                SfGrid.allowSorting true
                SfGrid.allowExcelExport true
                SfGrid.showColumnChooser true
                SfGrid.pageSettings PageSettingsModel.Default
                SfGrid.editSettings EditSettingsModel.Default
                SfGrid.filterSettings FilterSettingsModel.Default
                SfGrid.selectionSettings SelectionSettingsModel.Default
                prop.children [
                    columns.create [
                        prop.children [
                            column.create [
                                column.field "UserName"
                                column.headerText "User Name"
                                column.width 200
                            ]
                            column.create [
                                column.field "FirstName"
                                column.headerText "First Name"
                                column.width 200
                            ]
                            column.create [
                                column.field "LastName"
                                column.headerText "Last Name"
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
```
Which will render the following:

![Grid](https://github.com/rasheedaboud/Feliz.Syncfusion/blob/cf0b44904760ed47cda7361a38941a2a43aae9ea/Felize.Syncfusion/grid.PNG)


### Documentation

Syncfusion documentation can be found [here](https://ej2.syncfusion.com/react/documentation/getting-started/quick-start).

### License

These controls are a commercial product and requires a paid license for possession or use. Syncfusion’s licensed software, including this component, is subject to the terms and conditions of Syncfusion's EULA (https://www.syncfusion.com/eula/es/). To acquire a license, you can purchase one at https://www.syncfusion.com/sales/products or start a free 30-day trial here (https://www.syncfusion.com/account/manage-trials/start-trials).

A free community license (https://www.syncfusion.com/products/communitylicense) is also available for companies and individuals whose organizations have less than $1 million USD in annual gross revenue and five or fewer developers.
