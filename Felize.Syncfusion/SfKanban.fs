namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type ISfKanbanProperty = interface end

module SfKanban =
    let private syncfusionComponent: ReactElement = import "KanbanComponent" "@syncfusion/ej2-react-kanban"
    let private columnsDirective: ReactElement = import "ColumnsDirective" "@syncfusion/ej2-react-kanban"
    let private columnDirective: ReactElement = import "ColumnDirective" "@syncfusion/ej2-react-kanban"

    [<AllowNullLiteral>]
    type CardClickEventArgs<'T> =
        abstract data: 'T
        abstract cancel: bool with get, set

    [<AllowNullLiteral>]
    type ActionEventArgs<'T> =
        abstract requestType: string
        abstract changedRecords: ResizeArray<'T> option

    type CardSettings = {
        headerField: string
        contentField: string
    }

    type Column = {
        headerText: string
        keyField: string
    }

    [<Erase>]
    type prop =
        static member inline keyField(value: string) : ISfKanbanProperty = unbox ("keyField", value)
        static member inline dataSource(value: 'T array) : ISfKanbanProperty = unbox ("dataSource", value)
        static member inline cardSettings(value: CardSettings) : ISfKanbanProperty = unbox ("cardSettings", value)
        static member inline allowDragAndDrop(value: bool) : ISfKanbanProperty = unbox ("allowDragAndDrop", value)
        static member inline cssClass(value: string) : ISfKanbanProperty = unbox ("cssClass", value)
        static member inline cardClick(callback: CardClickEventArgs<'T> -> unit) : ISfKanbanProperty = unbox ("cardClick", callback)
        static member inline actionComplete(callback: ActionEventArgs<'T> -> unit) : ISfKanbanProperty = unbox ("actionComplete", callback)
        static member inline children(value: ReactElement list) : ISfKanbanProperty = unbox ("children", value)

    let column (column: Column) : ReactElement =
        ReactLegacy.createElement(columnDirective, createObj [ "headerText" ==> column.headerText; "keyField" ==> column.keyField ])

    let columns (items: ReactElement list) : ReactElement =
        ReactLegacy.createElement(columnsDirective, createObj [ "children" ==> items ])

    let create (props: ISfKanbanProperty list) : ReactElement =
        ReactLegacy.createElement(syncfusionComponent, createObj !!props)
