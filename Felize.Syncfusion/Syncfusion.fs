namespace Feliz.Syncfusion

    [<RequireQualifiedAccess>]
    module License =
        open Fable
        open Fable.Core
        open Fable.Core.JsInterop
        

        [<Import("registerLicense", from="@syncfusion/ej2-base")>]
        let register(x: string): unit = jsNative