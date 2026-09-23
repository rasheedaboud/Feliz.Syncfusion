namespace Syncfusion.Typed

open System
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module Data =

    [<StringEnum; RequireQualifiedAccess>]
    type FilterOperator =
        | [<CompiledName("equal")>] Equal
        | [<CompiledName("notequal")>] NotEqual
        | [<CompiledName("contains")>] Contains
        | [<CompiledName("startswith")>] StartsWith
        | [<CompiledName("endswith")>] EndsWith
        | [<CompiledName("greaterthan")>] GreaterThan
        | [<CompiledName("greaterthanorequal")>] GreaterThanOrEqual
        | [<CompiledName("lessthan")>] LessThan
        | [<CompiledName("lessthanorequal")>] LessThanOrEqual

    [<Import("Predicate","@syncfusion/ej2-data")>]
    type Predicate(field: string, operatorName: string, value: obj, ?ignoreCase: bool) =
        [<Emit("$0.and($1)")>]
        member _.andAlso(other: Predicate): Predicate = jsNative
        [<Emit("$0.or($1)")>]
        member _.orElse(other: Predicate): Predicate = jsNative

    let private operatorName (operatorValue: FilterOperator) : string = unbox operatorValue

    let predicateString field operatorValue value ignoreCase =
        Predicate(field, operatorName operatorValue, box value, ignoreCase)

    let predicateNumber field operatorValue (value: float) =
        Predicate(field, operatorName operatorValue, box value)

    let predicateBool field operatorValue (value: bool) =
        Predicate(field, operatorName operatorValue, box value)

    let predicateDate field operatorValue (value: DateTime) =
        Predicate(field, operatorName operatorValue, box value)

    [<Import("Query","@syncfusion/ej2-data")>]
    type Query() =
        member _.clone(): Query = jsNative
        member _.requiresCount(): Query = jsNative
        member _.where(predicate: Predicate): Query = jsNative
        member _.search(searchKey: string, fieldNames: string array, ?operatorName: string, ?ignoreCase: bool): Query = jsNative
        member _.sortBy(fieldName: string, ?direction: string): Query = jsNative
        member _.isCountRequired: bool = jsNative

    let whereString field operatorValue value ignoreCase (query: Query) =
        query.where(predicateString field operatorValue value ignoreCase)

    let whereNumber field operatorValue value (query: Query) =
        query.where(predicateNumber field operatorValue value)

    let whereBool field operatorValue value (query: Query) =
        query.where(predicateBool field operatorValue value)

    let whereDate field operatorValue value (query: Query) =
        query.where(predicateDate field operatorValue value)

    [<Import("JsonAdaptor","@syncfusion/ej2-data")>]
    type JsonAdaptor() = class end

    type DataManagerOptions<'T> = {
        json: 'T array
        adaptor: JsonAdaptor
    }

    [<AllowNullLiteral>]
    type CountedDataResult<'T> =
        abstract count: float option
        abstract result: ResizeArray<'T> option

    [<Import("DataManager","@syncfusion/ej2-data")>]
    type DataManager<'T>(options: DataManagerOptions<'T>) =
        member _.executeLocal(?query: Query): U2<ResizeArray<'T>, CountedDataResult<'T>> = jsNative

    let createLocal (data: 'T array) =
        DataManager<'T>({ json = data; adaptor = JsonAdaptor() })
