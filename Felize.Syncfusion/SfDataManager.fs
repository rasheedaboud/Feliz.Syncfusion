namespace Syncfusion
open Fable.Core
open Fable.Core.JS
open System

module rec SfDataManagerTypes =

    [<AllowNullLiteral>]
    type Function =
        abstract name: string
        abstract length: int
        abstract apply: thisArg: obj * args: obj[] -> obj
        abstract bind: thisArg: obj * [<ParamArray>] args: obj[] -> Function
        abstract call: thisArg: obj * [<ParamArray>] args: obj[] -> obj

        [<Emit "$0($1...)">]
        abstract Invoke: [<ParamArray>] args: obj[] -> obj

        [<Emit "new $0($1...)">]
        abstract Create: [<ParamArray>] args: obj[] -> obj

    /// An event which takes place in the DOM.
    type [<AllowNullLiteral>] Event =
        /// Returns true or false depending on how event was initialized. True if event goes through its target's ancestors in reverse tree order, and false otherwise.
        abstract bubbles: bool
        abstract cancelBubble: bool with get, set
        /// Returns true or false depending on how event was initialized. Its return value does not always carry meaning, but true can indicate that part of the operation during which event was dispatched, can be canceled by invoking the preventDefault() method.
        abstract cancelable: bool
        /// Returns true or false depending on how event was initialized. True if event invokes listeners past a ShadowRoot node that is the root of its target, and false otherwise.
        abstract composed: bool
        /// Returns true if preventDefault() was invoked successfully to indicate cancelation, and false otherwise.
        abstract defaultPrevented: bool
        /// Returns the event's phase, which is one of NONE, CAPTURING_PHASE, AT_TARGET, and BUBBLING_PHASE.
        abstract eventPhase: float
        /// Returns true if event was dispatched by the user agent, and false otherwise.
        abstract isTrusted: bool
        [<Obsolete("")>]
        abstract returnValue: bool with get, set
        /// Returns the type of event, e.g. "click", "hashchange", or "submit".
        abstract ``type``: string
        /// If invoked when the cancelable attribute value is true, and while executing a listener for the event with passive set to false, signals to the operation that caused event to be dispatched that it needs to be canceled.
        abstract preventDefault: unit -> unit
        /// Invoking this method prevents event from reaching any registered event listeners after the current one finishes running and, when dispatched in a tree, also prevents event from reaching any other objects.
        abstract stopImmediatePropagation: unit -> unit
        /// When dispatched in a tree, invoking this method prevents event from reaching any objects other than the current obj.
        abstract stopPropagation: unit -> unit
        abstract AT_TARGET: float
        abstract BUBBLING_PHASE: float
        abstract CAPTURING_PHASE: float
        abstract NONE: float

    /// Ajax class provides ability to make asynchronous HTTP request to the server
    /// <code lang="typescript">
    ///    var ajax = new Ajax("index.html", "GET", true);
    ///    ajax.send().then(
    ///                function (value) {
    ///                    console.log(value);
    ///                },
    ///                function (reason) {
    ///                    console.log(reason);
    ///                });
    /// </code>
    type [<AllowNullLiteral>] Ajax =
        /// <summary>Specifies the URL to which request to be sent.</summary>
        /// <default>null</default>
        abstract url: string with get, set
        /// <summary>Specifies which HTTP request method to be used. For ex., GET, POST</summary>
        /// <default>GET</default>
        abstract ``type``: string with get, set
        /// <summary>Specifies the data to be sent.</summary>
        /// <default>null</default>
        abstract data: U2<string, obj> with get, set
        /// <summary>A boolean value indicating whether the request should be sent asynchronous or not.</summary>
        /// <default>true</default>
        abstract mode: bool with get, set
        /// <summary>Specifies the callback for creating the XMLHttpRequest obj.</summary>
        /// <default>null</default>
        abstract httpRequest: XMLHttpRequest with get, set
        /// <summary>A boolean value indicating whether to ignore the promise reject.</summary>
        /// <default>true</default>
        abstract emitError: bool with get, set
        abstract onLoad: (XMLHttpRequest -> Event -> obj) with get, set
        abstract onProgress: (XMLHttpRequest -> Event -> obj) with get, set
        abstract onError: (XMLHttpRequest -> Event -> obj) with get, set
        abstract onAbort: (XMLHttpRequest -> Event -> obj) with get, set
        abstract onUploadProgress: (XMLHttpRequest -> Event -> obj) with get, set
        /// <summary>Send the request to server.</summary>
        /// <param name="data">To send the user data</param>
        /// <returns>?</returns>
        abstract send: ?data: U2<string, obj> -> Promise<Ajax>
        /// <summary>
        /// Specifies the callback function to be triggered before sending request to sever.
        /// This can be used to modify the XMLHttpRequest obj before it is sent.
        /// </summary>
        abstract beforeSend: Function with get, set
        /// <summary>
        /// Specifies callback function to be triggered after XmlHttpRequest is succeeded.
        /// The callback will contain server response as the parameter.
        /// </summary>
        abstract onSuccess: Function with get, set
        /// <summary>Triggers when XmlHttpRequest is failed.</summary>
        abstract onFailure: Function with get, set
        /// <summary>To get the response header from XMLHttpRequest</summary>
        /// <param name="key">Key to search in the response header</param>
        /// <returns>?</returns>
        abstract getResponseHeader: key: string -> string

    
    /// Interface for numberFormatOptions
    type [<AllowNullLiteral>] NumberFormatOptions =
        /// Specifies minimum fraction digits in formatted value.
        abstract minimumFractionDigits: float option with get, set
        /// Specifies maximum fraction digits in formatted value.
        abstract maximumFractionDigits: float option with get, set
        /// Specifies minimum significant digits in formatted value.
        abstract minimumSignificantDigits: float option with get, set
        /// Specifies maximum significant digits in formatted value.
        abstract maximumSignificantDigits: float option with get, set
        /// Specifies whether to use grouping or not in formatted value,
        abstract useGrouping: bool option with get, set
        /// Specifies the skeleton for perform formatting.
        abstract skeleton: string option with get, set
        /// Specifies the currency code to be used for formatting.
        abstract currency: string option with get, set
        /// Specifies minimum integer digits in formatted value.
        abstract minimumIntegerDigits: float option with get, set
        /// Specifies custom number format for formatting.
        abstract format: string option with get, set
        /// Species which currency symbol to consider.
        abstract altSymbol: string option with get, set

    /// Interface for dateFormatOptions
    type [<AllowNullLiteral>] DateFormatOptions =
        /// Specifies the skeleton for date formatting.
        abstract skeleton: string option with get, set
        /// Specifies the type of date formatting either date, dateTime or time.
        abstract ``type``: string option with get, set
        /// Specifies custom date formatting to be used.
        abstract format: string option with get, set
        /// Specifies the calendar mode other than gregorian
        abstract calendar: string option with get, set
        /// Enable server side date formating.
        abstract isServerRendered: bool option with get, set
    
    /// Predicate class is used to generate complex filter criteria.
    /// This will be used by DataManager to perform multiple filtering operation.
    type [<AllowNullLiteral>] Predicate =
        abstract field: string with get, set
        abstract operator: string with get, set
        abstract value: U6<string, float, DateTime, bool, Predicate, ResizeArray<Predicate>> option with get, set
        abstract condition: string with get, set
        abstract ignoreCase: bool with get, set
        abstract ignoreAccent: bool with get, set
        abstract isComplex: bool with get, set
        abstract predicates: ResizeArray<Predicate> with get, set
        abstract comparer: Function with get, set
        [<EmitIndexer>] abstract Item: x: string -> U7<string, float, DateTime, bool, Predicate, ResizeArray<Predicate>, Function> option with get, set
        /// <summary>Adds new predicate on existing predicate with “and” condition.</summary>
        /// <param name="field">Defines the column field.</param>
        /// <param name="operator">Defines the operator how to filter data.</param>
        /// <param name="value">Defines the values to match with data.</param>
        /// <param name="ignoreCase">
        /// ? - If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract ``and``: field: U2<string, Predicate> * ?operator: string * ?value: U4<string, float, DateTime, bool> * ?ignoreCase: bool * ?ignoreAccent: bool -> Predicate
        /// <summary>Adds new predicate on existing predicate with “or” condition.</summary>
        /// <param name="field">Defines the column field.</param>
        /// <param name="operator">Defines the operator how to filter data.</param>
        /// <param name="value">Defines the values to match with data.</param>
        /// <param name="ignoreCase">
        /// ? - If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract ``or``: field: U2<string, Predicate> * ?operator: string * ?value: U4<string, float, DateTime, bool> * ?ignoreCase: bool * ?ignoreAccent: bool -> Predicate
        /// <summary>Validate the record based on the predicates.</summary>
        /// <param name="record">Defines the datasource record.</param>
        abstract validate: record: obj -> bool
        /// Converts predicates to plain JavaScript.
        /// This method is uses Json stringify when serializing Predicate obj.
        abstract toJson: unit -> obj
    

    [<AllowNullLiteral>]
    type   QueryOptions =
        abstract fn : string option with get, set
        abstract e : QueryOptions option with get, set
        abstract fieldNames : U2<string, ResizeArray<string>> option with get, set
        abstract operator : string option with get, set
        abstract searchKey : U3<string, float, bool> option with get, set
        abstract ignoreCase : bool option with get, set
        abstract ignoreAccent : bool option with get, set
        abstract comparer : U2<string, Function> option with get, set
        abstract format : U3<string, NumberFormatOptions, DateFormatOptions> option with get, set
        abstract direction : string option with get, set
        abstract pageIndex : float option with get, set
        abstract pageSize : float option with get, set
        abstract start : float option with get, set
        abstract ``end`` : float option with get, set
        abstract nos : float option with get, set
        abstract field : string option with get, set
        abstract fieldName : string option with get, set
        abstract ``type`` : obj option with get, set
        abstract name : U2<string, ResizeArray<string>> option with get, set
        abstract filter : obj option with get, set
        abstract key : string option with get, set
        abstract value : U6<string, float, DateTime, bool, Predicate, ResizeArray<Predicate>> option with get, set
        abstract isComplex : bool option with get, set
        abstract predicates : ResizeArray<Predicate> option with get, set
        abstract condition : string option with get, set

    [<AllowNullLiteral>]
    type   IQueryList =
        abstract onSelect : QueryOptions option with get, set
        abstract onPage : QueryOptions option with get, set
        abstract onSkip : QueryOptions option with get, set
        abstract onTake : QueryOptions option with get, set
        abstract onRange : QueryOptions option with get, set

    [<AllowNullLiteral>]
    type   IParamOption =
        abstract key : string with get, set
        abstract value : string option with get, set
        abstract fn : Function option with get, set
    /// Predicate class is used to generate complex filter criteria.
    /// This will be used by DataManager to perform multiple filtering operation.
    [<AllowNullLiteral>]
    type   IPredicate =
        abstract field : string with get, set
        abstract operator : string with get, set
        abstract value : U6<string, float, DateTime, bool, Predicate, ResizeArray<Predicate>> option with get, set
        abstract condition : string with get, set
        abstract ignoreCase : bool with get, set
        abstract ignoreAccent : bool with get, set
        abstract isComplex : bool with get, set
        abstract predicates : ResizeArray<Predicate> with get, set
        abstract comparer : Function with get, set

        [<EmitIndexer>]
        abstract Item : x: string -> U7<string, float, DateTime, bool, Predicate, ResizeArray<Predicate>, Function> option with get, set

        /// <summary>Adds new predicate on existing predicate with “and” condition.</summary>
        /// <param name="field">Defines the column field.</param>
        /// <param name="operator">Defines the operator how to filter data.</param>
        /// <param name="value">Defines the values to match with data.</param>
        /// <param name="ignoreCase">
        /// ? - If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract ``and`` : field: U2<string, Predicate>* ?operator: string* ?value: U4<string, float, DateTime, bool>* ?ignoreCase: bool * ?ignoreAccent: bool ->Predicate
        /// <summary>Adds new predicate on existing predicate with “or” condition.</summary>
        /// <param name="field">Defines the column field.</param>
        /// <param name="operator">Defines the operator how to filter data.</param>
        /// <param name="value">Defines the values to match with data.</param>
        /// <param name="ignoreCase">
        /// ? - If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract ``or`` : field: U2<string, Predicate>* ?operator: string * ?value: U4<string, float, DateTime, bool> * ?ignoreCase: bool * ?ignoreAccent: bool ->Predicate
        /// <summary>Validate the record based on the predicates.</summary>
        /// <param name="record">Defines the datasource record.</param>
        abstract validate : record: obj -> bool
        /// Converts predicates to plain JavaScript.
        /// This method is uses Json stringify when serializing Predicate obj.
        abstract toJson : unit -> obj

    type [<AllowNullLiteral>] ParamOption =
        abstract key: string with get, set
        abstract value: string option with get, set
        abstract fn: Function option with get, set

    /// Query class is used to build query which is used by the DataManager to communicate with datasource.
    [<AllowNullLiteral>]
    type   Query =
        abstract queries : ResizeArray<QueryOptions> with get, set
        abstract key : string with get, set
        abstract fKey : string with get, set
        abstract fromTable : string with get, set
        abstract lookups : ResizeArray<string> with get, set
        abstract expands : ResizeArray<obj> with get, set
        abstract sortedColumns : ResizeArray<obj> with get, set
        abstract groupedColumns : ResizeArray<obj> with get, set
        abstract subQuerySelector : Function with get, set
        abstract subQuery : Query with get, set
        abstract isChild : bool with get, set
        abstract ``params`` : ResizeArray<ParamOption> with get, set
        abstract lazyLoad : ResizeArray<{| key: string; value: U2<obj, bool> |}> with get, set
        abstract isCountRequired : bool with get, set
        abstract dataManager : IDataManager with get, set
        abstract distincts : ResizeArray<string> with get, set
        /// <summary>Sets the primary key.</summary>
        /// <param name="field">Defines the column field.</param>
        abstract setKey : field: string -> Query
        /// <summary>Sets default DataManager to execute query.</summary>
        /// <param name="dataManager">Defines the DataManager.</param>
        abstract using : dataManager: IDataManager -> Query
        /// <summary>Executes query with the given DataManager.</summary>
        /// <param name="dataManager">Defines the DataManager.</param>
        /// <param name="done">Defines the success callback.</param>
        /// <param name="fail">Defines the failure callback.</param>
        /// <param name="always">
        /// Defines the callback which will be invoked on either success or failure.
        ///
        /// &lt;pre&gt;
        /// let dataManager: DataManager = new DataManager([{ ID: '10' }, { ID: '2' }, { ID: '1' }, { ID: '20' }]);
        /// let query: Query = new Query();
        /// query.sortBy('ID', (x: string, y: string): number =&gt; { return parseInt(x, 10) - parseInt(y, 10) });
        /// let promise: Promise&lt; obj &gt; = query.execute(dataManager);
        /// promise.then((e: { result: obj }) =&gt; { });
        /// &lt;/pre&gt;
        /// </param>
        abstract execute : ?dataManager: IDataManager * ?``done``: Function * ?fail: Function * ?always: Function -> Promise<obj>
        /// <summary>Executes query with the local datasource.</summary>
        /// <param name="dataManager">Defines the DataManager.</param>
        abstract executeLocal : ?dataManager: IDataManager -> ResizeArray<obj>
        /// Creates deep copy of the Query obj.
        abstract clone : unit -> Query
        /// <summary>Specifies the name of table to retrieve data in query execution.</summary>
        /// <param name="tableName">Defines the table name.</param>
        abstract from : tableName: string -> Query
        /// <summary>Adds additional parameter which will be sent along with the request which will be generated while DataManager execute.</summary>
        /// <param name="key">Defines the key of additional parameter.</param>
        /// <param name="value">Defines the value for the key.</param>
        abstract addParams : key: string * value: U2<Function, string> option -> Query
        abstract distinct : fields: U2<string, ResizeArray<string>> -> Query
        /// <summary>Expands the related table.</summary>
        /// <param name="tables" />
        abstract expand : tables: U2<string, ResizeArray<obj>> -> Query
        /// <summary>Filter data with given filter criteria.</summary>
        /// <param name="fieldName">Defines the column field or Predicate.</param>
        /// <param name="operator">Defines the operator how to filter data.</param>
        /// <param name="value">Defines the values to match with data.</param>
        /// <param name="ignoreCase">
        /// If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract where : fieldName: U3<string, Predicate<'T>, ResizeArray<Predicate<'T>>> * ?operator: string* ?value: U4<string, DateTime, float, bool> * ?ignoreCase: bool* ?ignoreAccent: bool -> Query
        /// <summary>Search data with given search criteria.</summary>
        /// <param name="searchKey">Defines the search key.</param>
        /// <param name="fieldNames">Defines the collection of column fields.</param>
        /// <param name="operator">Defines the operator how to search data.</param>
        /// <param name="ignoreCase">
        /// If ignore case set to false, then filter data with exact match or else
        /// filter data with case insensitive.
        /// </param>
        abstract search : searchKey: U3<string, float, bool>* ?fieldNames: U2<string, ResizeArray<string>>* ?operator: string * ?ignoreCase: bool * ?ignoreAccent: bool ->Query
        /// <summary>
        /// Sort the data with given sort criteria.
        /// By default, sort direction is ascending.
        /// </summary>
        /// <param name="fieldName">Defines the single or collection of column fields.</param>
        /// <param name="comparer">Defines the sort direction or custom sort comparer function.</param>
        abstract sortBy : fieldName: U2<string, ResizeArray<string>> * ?comparer: U2<string, Function> * ?isFromGroup: bool -> Query
        /// <summary>
        /// Sort the data with given sort criteria.
        /// By default, sort direction is ascending.
        /// </summary>
        /// <param name="fieldName">Defines the single or collection of column fields.</param>
        /// <param name="comparer">Defines the sort direction or custom sort comparer function.</param>
        /// <param name="direction">Defines the sort direction .</param>
        abstract sortByForeignKey : fieldName: U2<string, ResizeArray<string>>* ?comparer: U2<string, Function>* ?isFromGroup: bool* ?direction: string ->Query
        /// <summary>Sorts data in descending order.</summary>
        /// <param name="fieldName">Defines the column field.</param>
        abstract sortByDesc : fieldName: string -> Query
        /// <summary>Groups data with the given field name.</summary>
        /// <param name="fieldName">Defines the column field.</param>
        abstract group : fieldName: string * ?fn: Function * ?format: U3<string, NumberFormatOptions, DateFormatOptions> -> Query
        /// <summary>Gets data based on the given page index and size.</summary>
        /// <param name="pageIndex">Defines the current page index.</param>
        /// <param name="pageSize">Defines the no of records per page.</param>
        abstract page : pageIndex: float * pageSize: float -> Query
        /// <summary>Gets data based on the given start and end index.</summary>
        /// <param name="start">Defines the start index of the datasource.</param>
        /// <param name="end">Defines the end index of the datasource.</param>
        abstract range : start: float * ``end``: float -> Query
        /// <summary>Gets data from the top of the data source based on given number of records count.</summary>
        /// <param name="nos">Defines the no of records to retrieve from datasource.</param>
        abstract take : nos: float -> Query
        /// <summary>Skips data with given number of records count from the top of the data source.</summary>
        /// <param name="nos">Defines the no of records skip in the datasource.</param>
        abstract skip : nos: float -> Query
        /// <summary>Selects specified columns from the data source.</summary>
        /// <param name="fieldNames">Defines the collection of column fields.</param>
        abstract select : fieldNames: U2<string, ResizeArray<string>> -> Query
        /// <summary>Gets the records in hierarchical relationship from two tables. It requires the foreign key to relate two tables.</summary>
        /// <param name="query">Defines the query to relate two tables.</param>
        /// <param name="selectorFn">Defines the custom function to select records.</param>
        abstract hierarchy : query: Query * selectorFn: Function -> Query
        /// <summary>Sets the foreign key which is used to get data from the related table.</summary>
        /// <param name="key">Defines the foreign key.</param>
        abstract foreignKey : key: string -> Query
        /// It is used to get total number of records in the DataManager execution result.
        abstract requiresCount : unit -> Query
        /// <summary>Aggregate the data with given type and field name.</summary>
        /// <param name="type">Defines the aggregate type.</param>
        /// <param name="field">Defines the column field to aggregate.</param>
        abstract aggregate : ``type``: string * field: string -> Query



    [<AllowNullLiteral>]
    type   DataOptions =
        abstract url : string option with get, set
        abstract adaptor : AdaptorOptions option with get, set
        abstract insertUrl : string option with get, set
        abstract removeUrl : string option with get, set
        abstract updateUrl : string option with get, set
        abstract crudUrl : string option with get, set
        abstract batchUrl : string option with get, set
        abstract json : ResizeArray<obj> option with get, set
        abstract headers : ResizeArray<obj> option with get, set
        abstract accept : bool option with get, set
        abstract data : JSON option with get, set
        abstract timeTillExpiration : float option with get, set
        abstract cachingPageSize : float option with get, set
        abstract enableCaching : bool option with get, set
        abstract requestType : string option with get, set
        abstract key : string option with get, set
        abstract crossDomain : bool option with get, set
        abstract jsonp : string option with get, set
        abstract dataType : string option with get, set
        abstract offline : bool option with get, set
        abstract requiresFormat : bool option with get, set
        abstract timeZoneHandling : bool option with get, set


    [<Erase>]
    type   KeyOf<'T> = Key of string

    type [<StringEnum>] [<RequireQualifiedAccess>] XMLHttpRequestResponseType =
        | [<CompiledName "">] Empty
        | Arraybuffer
        | Blob
        | Document
        | Json
        | Text


    /// Use XMLHttpRequest (XHR) objects to interact with servers. You can retrieve data from a URL without having to do a full page refresh. This enables a Web page to update just part of a page without disrupting what the user is doing.
    [<AllowNullLiteral>]
    type   XMLHttpRequest =
        abstract onreadystatechange : (XMLHttpRequest -> Event -> obj option) option with get, set
        /// Returns client's state.
        abstract readyState : float
        /// Returns the response body.
        abstract response : obj option
        /// Returns response as text.
        ///
        /// Throws an "InvalidStateError" DOMException if responseType is not the empty string or "text".
        abstract responseText : string
        /// Returns the response type.
        ///
        /// Can be set to change the response type. Values are: the empty string (default), "arraybuffer", "blob", "document", "json", and "text".
        ///
        /// When set: setting to "document" is ignored if current global obj is not a Window obj.
        ///
        /// When set: throws an "InvalidStateError" DOMException if state is loading or done.
        ///
        /// When set: throws an "InvalidAccessError" DOMException if the synchronous flag is set and current global obj is a Window obj.
        abstract responseType : XMLHttpRequestResponseType with get, set
        abstract responseURL : string

        abstract status : float
        abstract statusText : string
        /// Can be set to a time in milliseconds. When set to a non-zero value will cause fetching to terminate after the given time has passed. When the time has passed, the request has not yet completed, and this's synchronous flag is unset, a timeout event will then be dispatched, or a "TimeoutError" DOMException will be thrown otherwise (for the send() method).
        ///
        /// When set: throws an "InvalidAccessError" DOMException if the synchronous flag is set and current global obj is a Window obj.
        abstract timeout : float with get, set

        /// True when credentials are to be included in a cross-origin request. False when they are to be excluded in a cross-origin request and when cookies are to be ignored in its response. Initially false.
        ///
        /// When set: throws an "InvalidStateError" DOMException if state is not unsent or opened, or if the send() flag is set.
        abstract withCredentials : bool with get, set
        /// Cancels any network activity.
        abstract abort : unit -> unit
        abstract getAllResponseHeaders : unit -> string
        abstract getResponseHeader : name: string -> string option
 /// <summary>
        /// Acts as if the <c>Content-Type</c> header value for a response is mime. (It does not change the header.)
        ///
        /// Throws an "InvalidStateError" DOMException if state is loading or done.
        /// </summary>
        abstract overrideMimeType : mime: string -> unit

        /// Combines a header in author request headers.
        ///
        /// Throws an "InvalidStateError" DOMException if either state is not opened or the send() flag is set.
        ///
        /// Throws a "SyntaxError" DOMException if name is not a header name or if value is not a header value.
        abstract setRequestHeader : name: string * value: string -> unit
        abstract DONE : float
        abstract HEADERS_RECEIVED : float
        abstract LOADING : float
        abstract OPENED : float
        abstract UNSENT : float


    [<AllowNullLiteral>]
    type IAdaptor = interface end

    /// <summary>
    /// Adaptors are specific data source type aware interfaces that are used by DataManager to communicate with DataSource.
    /// This is the base adaptor class that other adaptors can extend.
    /// </summary>
    [<AllowNullLiteral>]
    type   Adaptor =
        inherit IAdaptor
        /// <summary>Specifies the datasource option.</summary>
        /// <default>null</default>
        abstract dataSource : DataOptions with get, set
        abstract updateType : string with get, set
        abstract updateKey : string with get, set
        abstract options : RemoteOptions with get, set
        /// <summary>Returns the data from the query processing.</summary>
        /// <param name="data" />
        /// <param name="ds">?</param>
        /// <param name="query">?</param>
        /// <param name="xhr">?</param>
        /// <returns>obj</returns>
        abstract processResponse : data: obj * ?ds: DataOptions * ?query: Query * ?xhr: XMLHttpRequest -> obj
        /// <summary>Specifies the type of adaptor.</summary>
        /// <default>Adaptor</default>
        abstract ``type`` : obj with get, set

    type [<AllowNullLiteral>] Aggregates =
        abstract sum: Function option with get, set
        abstract average: Function option with get, set
        abstract min: Function option with get, set
        abstract max: Function option with get, set
        abstract truecount: Function option with get, set
        abstract falsecount: Function option with get, set
        abstract count: Function option with get, set
        abstract ``type``: string option with get, set
        abstract field: string option with get, set


    type [<AllowNullLiteral>] DataResult =
        abstract nodeType: float option with get, set
        abstract addedRecords: ResizeArray<obj> option with get, set
        abstract d: U2<DataResult, ResizeArray<obj>> option with get, set
        abstract Count: float option with get, set
        abstract count: float option with get, set
        abstract result: obj option with get, set
        abstract results: U2<ResizeArray<obj>, DataResult> option with get, set
        abstract aggregate: DataResult option with get, set
        abstract aggregates: Aggregates option with get, set
        abstract value: obj option with get, set
        abstract Items: U2<ResizeArray<obj>, DataResult> option with get, set
        abstract keys: ResizeArray<string> option with get, set
        abstract groupDs: ResizeArray<obj> option with get, set

    type [<AllowNullLiteral>] Group =
        abstract GroupGuid: string option with get, set
        abstract level: float option with get, set
        abstract childLevels: float option with get, set
        abstract records: ResizeArray<obj> option with get, set
        abstract key: string option with get, set
        abstract count: float option with get, set
        abstract items: ResizeArray<obj> option with get, set
        abstract aggregates: obj option with get, set
        abstract field: string option with get, set
        abstract result: obj option with get, set

    type [<AllowNullLiteral>] CrudOptions =
        abstract changedRecords: ResizeArray<obj> option with get, set
        abstract addedRecords: ResizeArray<obj> option with get, set
        abstract deletedRecords: ResizeArray<obj> option with get, set
        abstract changed: ResizeArray<obj> option with get, set
        abstract added: ResizeArray<obj> option with get, set
        abstract deleted: ResizeArray<obj> option with get, set
        abstract action: string option with get, set
        abstract table: string option with get, set
        abstract key: string option with get, set

    type [<AllowNullLiteral>] Requests =
        abstract sorts: ResizeArray<QueryOptions> with get, set
        abstract groups: ResizeArray<QueryOptions> with get, set
        abstract filters: ResizeArray<QueryOptions> with get, set
        abstract searches: ResizeArray<QueryOptions> with get, set
        abstract aggregates: ResizeArray<QueryOptions> with get, set

    /// <summary>
    /// URL Adaptor of DataManager can be used when you are required to use remote service to retrieve data.
    /// It interacts with server-side for all DataManager Queries and CRUD operations.
    /// </summary>
    [<AllowNullLiteral>]
    type   UrlAdaptor =
        inherit IAdaptor
        inherit Adaptor
        /// <summary>Process the query to generate request body.</summary>
        /// <param name="dm" />
        /// <param name="query" />
        /// <param name="hierarchyFilters">?</param>
        /// <returns>p</returns>
        abstract processQuery : dm: IDataManager * query: Query * ?hierarchyFilters: ResizeArray<obj> -> obj
        /// <summary>Convert the obj from processQuery to string which can be added query string.</summary>
        /// <param name="req" />
        /// <param name="query" />
        /// <param name="dm" />
        abstract convertToQueryString : request: obj * query: Query * dm: IDataManager -> string
        /// <summary>Return the data from the data manager processing.</summary>
        /// <param name="data" />
        /// <param name="ds">?</param>
        /// <param name="query">?</param>
        /// <param name="xhr">?</param>
        /// <param name="request">?</param>
        /// <param name="changes">?</param>
        abstract processResponse :    data: DataResult* ?ds: DataOptions* ?query: Query* ?xhr: XMLHttpRequest* ?request: obj* ?changes: CrudOptions ->DataResult

        abstract formRemoteGroupedData : data: ResizeArray<Group> * level: float * childLevel: float -> ResizeArray<Group>
        /// <summary>Add the group query to the adaptor`s option.</summary>
        /// <param name="e" />
        /// <returns>void</returns>
        abstract onGroup : e: ResizeArray<QueryOptions> -> ResizeArray<QueryOptions>
        /// <summary>Add the aggregate query to the adaptor`s option.</summary>
        /// <param name="e" />
        /// <returns>void</returns>
        abstract onAggregates : e: ResizeArray<Aggregates> -> unit
        /// <summary>
        /// Prepare the request body based on the newly added, removed and updated records.
        /// The result is used by the batch request.
        /// </summary>
        /// <param name="dm" />
        /// <param name="changes" />
        /// <param name="e" />
        abstract batchRequest : dm: IDataManager * changes: CrudOptions * e: obj * query: Query * ?original: obj -> obj
        /// <summary>
        /// Method will trigger before send the request to server side.
        /// Used to set the custom header or modify the request options.
        /// </summary>
        /// <param name="dm" />
        /// <param name="request" />
        /// <returns>void</returns>
        abstract beforeSend : dm: IDataManager * request: XMLHttpRequest -> unit
        /// <summary>Prepare and returns request body which is used to insert a new record in the table.</summary>
        /// <param name="dm" />
        /// <param name="data" />
        /// <param name="tableName" />
        abstract insert : dm: IDataManager * data: obj * tableName: string * query: Query -> obj
        /// <summary>Prepare and return request body which is used to remove record from the table.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName" />
        abstract remove :  dm: IDataManager * keyField: string * value: U2<float, string> * tableName: string * query: Query -> obj
        /// <summary>Prepare and return request body which is used to update record.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName" />
        abstract update : dm: IDataManager * keyField: string * value: obj * tableName: string * query: Query -> obj
        /// <summary>To generate the predicate based on the filtered query.</summary>
        /// <param name="data" />
        /// <param name="query" />
        abstract getFiltersFrom :     data: U3<ResizeArray<obj>, ResizeArray<string>, ResizeArray<float>> * query: Query -> Predicate

        abstract getAggregateResult :        pvt: obj * data: DataResult * args: DataResult * ?groupDs: ResizeArray<obj> * ?query: Query -> DataResult

        abstract getQueryRequest : query: Query -> Requests

        abstract addParams :options:{|  dm: IDataManager
                                        query: Query
                                        ``params``: ResizeArray<ParamOption>
                                        reqParams: obj |} -> unit

    type [<AllowNullLiteral>] RemoteArgs =
        abstract guid: string option with get, set
        abstract url: string option with get, set
        abstract key: string option with get, set
        abstract cid: float option with get, set
        abstract cSet: string option with get, set


    /// <summary>
    /// The Web API is a programmatic interface to define the request and response messages system that is mostly exposed in JSON or XML.
    /// The DataManager uses the WebApiAdaptor to consume Web API.
    /// Since this adaptor is targeted to interact with Web API created using OData endpoint, it is extended from ODataAdaptor
    /// </summary>
    type [<AllowNullLiteral>]    WebApiAdaptor =
        inherit IAdaptor
        inherit ODataAdaptor
        abstract getModuleName: unit -> string
        /// <summary>Prepare and returns request body which is used to insert a new record in the table.</summary>
        /// <param name="dm" />
        /// <param name="data" />
        /// <param name="tableName">?</param>
        abstract insert: dm: IDataManager * data: obj * ?tableName: string -> obj
        /// <summary>Prepare and return request body which is used to remove record from the table.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName">?</param>
        abstract remove: dm: IDataManager * keyField: string * value: float * ?tableName: string -> obj
        /// <summary>Prepare and return request body which is used to update record.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName">?</param>
        abstract update: dm: IDataManager * keyField: string * value: obj * ?tableName: string -> obj
        abstract batchRequest: dm: IDataManager * changes: CrudOptions * e: RemoteArgs -> obj
        /// <summary>
        /// Method will trigger before send the request to server side.
        /// Used to set the custom header or modify the request options.
        /// </summary>
        /// <param name="dm" />
        /// <param name="request" />
        /// <param name="settings" />
        /// <returns>void</returns>
        abstract beforeSend: dm: IDataManager * request: XMLHttpRequest * settings: Ajax -> unit
        /// <summary>Returns the data from the query processing.</summary>
        /// <param name="data" />
        /// <param name="ds">?</param>
        /// <param name="query">?</param>
        /// <param name="xhr">?</param>
        /// <param name="request">?</param>
        /// <param name="changes">?</param>
        /// <returns>aggregateResult</returns>
        abstract processResponse: data: DataResult * ?ds: DataOptions * ?query: Query * ?xhr: XMLHttpRequest * ?request: Ajax * ?changes: CrudOptions -> obj


    /// <summary>OData Adaptor that is extended from URL Adaptor, is used for consuming data through OData Service.</summary>
    [<AllowNullLiteral>]
    type   ODataAdaptor =
        inherit IAdaptor
        inherit UrlAdaptor
        abstract getModuleName : unit -> string
        /// <summary>Specifies the root url of the provided odata url.</summary>
        /// <default>null</default>
        abstract rootUrl : string with get, set
        /// <summary>Specifies the resource name of the provided odata table.</summary>
        /// <default>null</default>
        abstract resourceTableName : string with get, set
        abstract options : RemoteOptions with get, set
        /// <summary>Generate request string based on the filter criteria from query.</summary>
        /// <param name="pred" />
        /// <param name="requiresCast">?</param>
        abstract onPredicate : predicate: Predicate * query: U2<Query, bool> * ?requiresCast: bool -> string

        abstract addParams :options: {| dm: IDataManager
                                        query: Query
                                        ``params``: ResizeArray<ParamOption>
                                        reqParams: obj |} -> unit
        /// <summary>Generate request string based on the multiple filter criteria from query.</summary>
        /// <param name="pred" />
        /// <param name="requiresCast">?</param>
        abstract onComplexPredicate : predicate: Predicate * query: Query * ?requiresCast: bool -> string
        /// <summary>Generate query string based on the multiple filter criteria from query.</summary>
        /// <param name="filter" />
        /// <param name="requiresCast">?</param>
        abstract onEachWhere : filter: Predicate * query: Query * ?requiresCast: bool -> string
        /// <summary>Generate query string based on the multiple filter criteria from query.</summary>
        /// <param name="filters" />
        abstract onWhere : filters: ResizeArray<string> -> string
        /// <summary>Generate query string based on the multiple search criteria from query.</summary>
        /// <param name="e" />
        /// <param name="operator" />
        /// <param name="key" />
        /// <param name="">} ignoreCase</param>
        abstract onEachSearch :e:{| fields: ResizeArray<string>
                                    operator: string
                                    key: string
                                    ignoreCase: bool |} ->unit
        /// <summary>Generate query string based on the search criteria from query.</summary>
        /// <param name="e" />
        abstract onSearch : e: obj -> string
        /// <summary>Generate query string based on multiple sort criteria from query.</summary>
        /// <param name="e" />
        abstract onEachSort : e: QueryOptions -> string
        /// <summary>Returns sort query string.</summary>
        /// <param name="e" />
        abstract onSortBy : e: ResizeArray<string> -> string
        /// <summary>Adds the group query to the adaptor option.</summary>
        /// <param name="e" />
        /// <returns>string</returns>
        abstract onGroup : e: ResizeArray<QueryOptions> -> ResizeArray<QueryOptions>
        /// <summary>Returns the select query string.</summary>
        /// <param name="e" />
        abstract onSelect : e: ResizeArray<string> -> string
        /// <summary>Add the aggregate query to the adaptor option.</summary>
        /// <param name="e" />
        /// <returns>string</returns>
        abstract onAggregates : e: ResizeArray<obj> -> string
        /// <summary>Returns the query string which requests total count from the data source.</summary>
        /// <param name="e" />
        /// <returns>string</returns>
        abstract onCount : e: bool -> string
        /// <summary>
        /// Method will trigger before send the request to server side.
        /// Used to set the custom header or modify the request options.
        /// </summary>
        /// <param name="dm" />
        /// <param name="request" />
        /// <param name="settings">?</param>
        abstract beforeSend : dm: IDataManager * request: XMLHttpRequest * ?settings: Ajax -> unit
        /// <summary>Returns the data from the query processing.</summary>
        /// <param name="data" />
        /// <param name="ds">?</param>
        /// <param name="query">?</param>
        /// <param name="xhr">?</param>
        /// <param name="request">?</param>
        /// <param name="changes">?</param>
        /// <returns>aggregateResult</returns>
        abstract processResponse :data: DataResult* ?ds: DataOptions* ?query: Query* ?xhr: XMLHttpRequest* ?request: Ajax* ?changes: CrudOptions ->obj
        /// <summary>Converts the request obj to query string.</summary>
        /// <param name="req" />
        /// <param name="query" />
        /// <param name="dm" />
        /// <returns>tableName</returns>
        abstract convertToQueryString : request: obj * query: Query * dm: IDataManager -> string
        /// <summary>Prepare and returns request body which is used to insert a new record in the table.</summary>
        /// <param name="dm" />
        /// <param name="data" />
        /// <param name="tableName">?</param>
        abstract insert : dm: IDataManager * data: obj * ?tableName: string -> obj
        /// <summary>Prepare and return request body which is used to remove record from the table.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName">?</param>
        abstract remove : dm: IDataManager * keyField: string * value: float * ?tableName: string -> obj
        /// <summary>Updates existing record and saves the changes to the table.</summary>
        /// <param name="dm" />
        /// <param name="keyField" />
        /// <param name="value" />
        /// <param name="tableName">?</param>
        /// <returns>this</returns>
        abstract update :dm: IDataManager * keyField: string * value: obj * ?tableName: string * ?query: Query * ?original: obj ->obj
        /// <summary>
        /// Prepare the request body based on the newly added, removed and updated records.
        /// The result is used by the batch request.
        /// </summary>
        /// <param name="dm" />
        /// <param name="changes" />
        /// <param name="e" />
        /// <returns />
        abstract batchRequest :dm: IDataManager * changes: CrudOptions * e: RemoteArgs * query: Query * ?original: CrudOptions -> obj
        /// <summary>
        /// Generate the string content from the removed records.
        /// The result will be send during batch update.
        /// </summary>
        /// <param name="arr" />
        /// <param name="e" />
        /// <returns>this</returns>
        abstract generateDeleteRequest : arr: ResizeArray<obj> * e: RemoteArgs * dm: IDataManager -> string
        /// <summary>
        /// Generate the string content from the inserted records.
        /// The result will be send during batch update.
        /// </summary>
        /// <param name="arr" />
        /// <param name="e" />
        abstract generateInsertRequest : arr: ResizeArray<obj> * e: RemoteArgs * dm: IDataManager -> string
        /// <summary>
        /// Generate the string content from the updated records.
        /// The result will be send during batch update.
        /// </summary>
        /// <param name="arr" />
        /// <param name="e" />
        abstract generateUpdateRequest :arr: ResizeArray<obj> * e: RemoteArgs * dm: IDataManager * ?org: ResizeArray<obj> -> string

        abstract processBatchResponse :data: DataResult * ?query: Query * ?xhr: XMLHttpRequest * ?request: Ajax * ?changes: CrudOptions ->U2<CrudOptions, DataResult>

        abstract compareAndRemove : data: obj * original: obj * ?key: string -> obj



    [<AllowNullLiteral>]
    type   RemoteOptions =
        abstract from : string option with get, set
        abstract requestType : string option with get, set
        abstract sortBy : string option with get, set
        abstract select : string option with get, set
        abstract skip : string option with get, set
        abstract group : string option with get, set
        abstract take : string option with get, set
        abstract search : string option with get, set
        abstract count : string option with get, set
        abstract where : string option with get, set
        abstract aggregates : string option with get, set
        abstract expand : string option with get, set
        abstract accept : string option with get, set
        abstract multipartAccept : string option with get, set
        abstract batch : string option with get, set
        abstract changeSet : string option with get, set
        abstract batchPre : string option with get, set
        abstract contentId : string option with get, set
        abstract batchContent : string option with get, set
        abstract changeSetContent : string option with get, set
        abstract batchChangeSetContentType : string option with get, set
        abstract updateType : string option with get, set
        abstract localTime : bool option with get, set
        abstract apply : string option with get, set
        abstract getData : Function option with get, set
        abstract updateRecord : Function option with get, set
        abstract addRecord : Function option with get, set
        abstract deleteRecord : Function option with get, set
        abstract batchUpdate : Function option with get, set
        


    [<AllowNullLiteral>]
    type  IODataV4Adaptor =
        inherit IAdaptor
        inherit ODataAdaptor
        abstract getModuleName : unit -> string
        abstract options : RemoteOptions with get, set
        /// <summary>Returns the query string which requests total count from the data source.</summary>
        /// <param name="e" />
        /// <returns>string</returns>
        abstract onCount : e: bool -> string
        /// <summary>Generate request string based on the filter criteria from query.</summary>
        /// <param name="pred" />
        /// <param name="requiresCast">?</param>
        abstract onPredicate : predicate: Predicate * query: U2<Query, bool> * ?requiresCast: bool -> string

        /// <summary>Generate query string based on the search criteria from query.</summary>
        /// <param name="e" />
        abstract onSearch : e: obj -> string
        /// <summary>Returns the expand query string.</summary>
        /// <param name="e" />
        abstract onExpand:e:{|  selects: ResizeArray<string>
                                expands: ResizeArray<string> |} ->string
        /// <summary>Returns the groupby query string.</summary>
        /// <param name="e" />
        abstract onDistinct : distinctFields: ResizeArray<string> -> obj
        /// <summary>Returns the select query string.</summary>
        /// <param name="e" />
        abstract onSelect : e: ResizeArray<string> -> string
        /// <summary>
        /// Method will trigger before send the request to server side.
        /// Used to set the custom header or modify the request options.
        /// </summary>
        /// <param name="dm" />
        /// <param name="request" />
        /// <param name="settings" />
        /// <returns>void</returns>
        abstract beforeSend : dm: IDataManager * request: XMLHttpRequest * settings: Ajax -> unit
        /// <summary>Returns the data from the query processing.</summary>
        /// <param name="data" />
        /// <param name="ds">?</param>
        /// <param name="query">?</param>
        /// <param name="xhr">?</param>
        /// <param name="request">?</param>
        /// <param name="changes">?</param>
        /// <returns>aggregateResult</returns>
        abstract processResponse :data: DataResult* ?ds: DataOptions* ?query: Query* ?xhr: XMLHttpRequest* ?request: Ajax* ?changes: CrudOptions ->obj

    type [<AllowNullLiteral>] AdaptorOptions =
        abstract processQuery: Function option with get, set
        abstract processResponse: Function option with get, set
        abstract beforeSend: Function option with get, set
        abstract batchRequest: Function option with get, set
        abstract insert: Function option with get, set
        abstract remove: Function option with get, set
        abstract update: Function option with get, set
        abstract key: string option with get, set
    /// DataManager is used to manage and manipulate relational data.
    [<AllowNullLiteral>]
    type IDataManager =
        /// <summary>Overrides DataManager's default query with given query.</summary>
        /// <param name="query">Defines the new default query.</param>
        abstract setDefaultQuery : query: Query -> IDataManager
        /// <summary>Executes the given query with local data source.</summary>
        /// <param name="query">Defines the query to retrieve data.</param>
        abstract executeLocal : ?query: Query -> ResizeArray<obj>
        /// <summary>
        /// Executes the given query with either local or remote data source.
        /// It will be executed as asynchronously and returns Promise obj which will be resolved or rejected after action completed.
        /// </summary>
        /// <param name="query">Defines the query to retrieve data.</param>
        /// <param name="done">Defines the callback function and triggers when the Promise is resolved.</param>
        /// <param name="fail">Defines the callback function and triggers when the Promise is rejected.</param>
        /// <param name="always">Defines the callback function and triggers when the Promise is resolved or rejected.</param>
        abstract executeQuery :query: U2<Query, Function> * ?``done``: Function * ?fail: Function * ?always: Function -> Promise<Ajax>
        /// <summary>
        /// Save bulk changes to the given table name.
        /// User can add a new record, edit an existing record, and delete a record at the same time.
        /// If the datasource from remote, then updated in a single post.
        /// </summary>
        /// <param name="changes">Defines the CrudOptions.</param>
        /// <param name="key">Defines the column field.</param>
        /// <param name="tableName">Defines the table name.</param>
        /// <param name="query">Sets default query for the DataManager.</param>
        abstract saveChanges :changes: obj * ?key: string * ?tableName: U2<string, Query> * ?query: Query * ?original: obj ->U2<Promise<obj>, obj>
        /// <summary>Inserts new record in the given table.</summary>
        /// <param name="data">Defines the data to insert.</param>
        /// <param name="tableName">Defines the table name.</param>
        /// <param name="query">Sets default query for the DataManager.</param>
        abstract insert :data: obj * ?tableName: U2<string, Query> * ?query: Query * ?position: float -> U2<obj, Promise<obj>>
        /// <summary>Removes data from the table with the given key.</summary>
        /// <param name="keyField">Defines the column field.</param>
        /// <param name="value">Defines the value to find the data in the specified column.</param>
        /// <param name="tableName">Defines the table name</param>
        /// <param name="query">Sets default query for the DataManager.</param>
        abstract remove :keyField: string * value: obj * ?tableName: U2<string, Query> * ?query: Query -> U2<obj, Promise<obj>>
        /// <summary>Updates existing record in the given table.</summary>
        /// <param name="keyField">Defines the column field.</param>
        /// <param name="value">Defines the value to find the data in the specified column.</param>
        /// <param name="tableName">Defines the table name</param>
        /// <param name="query">Sets default query for the DataManager.</param>
        abstract update :keyField: string * value: obj * ?tableName: U2<string, Query> * ?query: Query * ?original: obj ->U2<obj, Promise<obj>>

module SfDataManager = 
    open SfDataManagerTypes

    [<Erase>]
    type DataManagerOptions = {
        url:string
        adaptor: IAdaptor
    }

    [<Import("DataManager","@syncfusion/ej2-data")>]
    type DataManager(options) =
        interface IDataManager with
            /// <summary>Overrides DataManager's default query with given query.</summary>
            /// <param name="query">Defines the new default query.</param>
            member _.setDefaultQuery(query: Query) :IDataManager = jsNative
            /// <summary>Executes the given query with local data source.</summary>
            /// <param name="query">Defines the query to retrieve data.</param>
            member _.executeLocal(?query: Query): ResizeArray<obj> = jsNative
            /// <summary>
            /// Executes the given query with either local or remote data source.
            /// It will be executed as asynchronously and returns Promise obj which will be resolved or rejected after action completed.
            /// </summary>
            /// <param name="query">Defines the query to retrieve data.</param>
            /// <param name="done">Defines the callback function and triggers when the Promise is resolved.</param>
            /// <param name="fail">Defines the callback function and triggers when the Promise is rejected.</param>
            /// <param name="always">Defines the callback function and triggers when the Promise is resolved or rejected.</param>
            member _.executeQuery(query: U2<Query, Function> , ?``done``: Function , ?fail: Function , ?always: Function): Promise<Ajax> = jsNative
            /// <summary>
            /// Save bulk changes to the given table name.
            /// User can add a new record, edit an existing record, and delete a record at the same time.
            /// If the datasource from remote, then updated in a single post.
            /// </summary>
            /// <param name="changes">Defines the CrudOptions.</param>
            /// <param name="key">Defines the column field.</param>
            /// <param name="tableName">Defines the table name.</param>
            /// <param name="query">Sets default query for the DataManager.</param>
            member _.saveChanges(changes: obj , ?key: string , ?tableName: U2<string, Query> , ?query: Query , ?original: obj) : U2<Promise<obj>, obj> = jsNative
            /// <summary>Inserts new record in the given table.</summary>
            /// <param name="data">Defines the data to insert.</param>
            /// <param name="tableName">Defines the table name.</param>
            /// <param name="query">Sets default query for the DataManager.</param>
            member _.insert(data: obj , ?tableName: U2<string, Query> , ?query: Query , ?position: float ): U2<obj, Promise<obj>> = jsNative
            /// <summary>Removes data from the table with the given key.</summary>
            /// <param name="keyField">Defines the column field.</param>
            /// <param name="value">Defines the value to find the data in the specified column.</param>
            /// <param name="tableName">Defines the table name</param>
            /// <param name="query">Sets default query for the DataManager.</param>
            member _.remove(keyField: string , value: obj , ?tableName: U2<string, Query> , ?query: Query): U2<obj, Promise<obj>>= jsNative
            /// <summary>Updates existing record in the given table.</summary>
            /// <param name="keyField">Defines the column field.</param>
            /// <param name="value">Defines the value to find the data in the specified column.</param>
            /// <param name="tableName">Defines the table name</param>
            /// <param name="query">Sets default query for the DataManager.</param>
            member _.update(keyField: string , value: obj , ?tableName: U2<string, Query> , ?query: Query , ?original: obj):U2<obj, Promise<obj>>= jsNative


            
    


    [<Import("ODataV4Adaptor","@syncfusion/ej2-data")>]
    type OdataV4Adaptor()=
        class end

    [<Import("WebApiAdaptor ","@syncfusion/ej2-data")>]
    let WebApiAdaptor: WebApiAdaptor  = jsNative


