module Server

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn

open Shared

type Storage () =
    let configOption = ResizeArray<_>()

    member __.GetConfig () =
        List.ofSeq configOption

    member __.AddConfig (setting: ConfigSetting) =
        if ConfigSetting.isValid setting.Description then
            configOption.Add setting
            Ok ()
        else Error "Invalid todo"

let storage = Storage()

storage.AddConfig(ConfigSetting.create "Create new SAFE project" 1) |> ignore
storage.AddConfig(ConfigSetting.create "Write your app" 2) |> ignore
storage.AddConfig(ConfigSetting.create "Ship it !!!" 3) |> ignore

let todosApi =
    { GetConfig = fun () -> async { return storage.GetConfig () }
      AddConfig =
        fun todo -> async {
            match storage.AddConfig todo with
            | Ok () -> return todo
            | Error e -> return failwith e
        } }

let webApp =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue todosApi
    |> Remoting.buildHttpHandler

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

run app
