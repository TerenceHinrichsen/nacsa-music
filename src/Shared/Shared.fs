namespace Shared

open System

type ConfigSetting =
    { Id : Guid
      Description : string
      Option : int }

module ConfigSetting =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) (option: int) =
        { Id = Guid.NewGuid()
          Description = description
          Option = option }

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type IConfigApi =
    { GetConfig : unit -> Async<ConfigSetting list>
      AddConfig : ConfigSetting -> Async<ConfigSetting> }