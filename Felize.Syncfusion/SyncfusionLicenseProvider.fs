namespace Syncfusion

[<RequireQualifiedAccess>]
module SyncfusionLicenseProvider = 

    open Fable.Core

    [<Import("registerLicense", from="@syncfusion/ej2-base")>]
    let register(x: string): unit = jsNative

