namespace Syncfusion

open Fable.Core
open Fable.Core.JsInterop
open Feliz

/// Compatibility helpers for Feliz-style third-party bindings.
/// Feliz 3 removed the old public Interop helpers, so bindings keep these
/// minimal erased constructors locally while using the current React API.
[<RequireQualifiedAccess>]
module Interop =

    let inline mkAttr (key: string) (value: 'a) : IReactProperty =
        unbox (key, box value)

    let inline createElement (name: string) (props: IReactProperty list) : ReactElement =
        ReactLegacy.createElement(unbox<ReactElement> name, createObj !!props)

    let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) : ReactElement =
        ReactLegacy.createElement(unbox<ReactElement> name, {| children = Seq.toArray children |})

    [<RequireQualifiedAccess>]
    module reactApi =
        let inline createElement (component: obj, props: obj) : ReactElement =
            ReactLegacy.createElement(unbox<ReactElement> component, props)
