module Index

open Elmish
open Fable.Remoting.Client
open Shared

type Model =
    { Todos: ConfigSetting list
      Input: string }

type Msg =
    | GotTodos of ConfigSetting list
    | SetInput of string
    | AddTodo
    | AddedTodo of ConfigSetting

let todosApi =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<IConfigApi>

let init(): Model * Cmd<Msg> =
    let model =
        { Todos = []
          Input = "" }
    let cmd = Cmd.OfAsync.perform todosApi.GetConfig () GotTodos
    model, cmd

let update (msg: Msg) (model: Model): Model * Cmd<Msg> =
    match msg with
    | GotTodos todos ->
        { model with Todos = todos }, Cmd.none
    | SetInput value ->
        { model with Input = value }, Cmd.none
    | AddTodo ->
        let todo = ConfigSetting.create model.Input 1
        let cmd = Cmd.OfAsync.perform todosApi.AddConfig todo AddedTodo
        { model with Input = "" }, cmd
    | AddedTodo todo ->
        { model with Todos = model.Todos @ [ todo ] }, Cmd.none

open Fable.React
open Fable.React.Props
open Fulma
open Feliz.MaterialUI


let containerBox (model : Model) (dispatch : Msg -> unit) =
    Box.box' [ ] [
        Content.content [ ] [
            Content.Ol.ol [ ] [
                for todo in model.Todos do
                    li [ ] [ str todo.Description ]
            ]
        ]
        Field.div [ Field.IsGrouped ] [
            Control.p [ Control.IsExpanded ] [
                Input.text [
                  Input.Value model.Input
                  Input.Placeholder "What needs to be done?"
                  Input.OnChange (fun x -> SetInput x.Value |> dispatch) ]
            ]
            Control.p [ ] [
                Button.a [
                    Button.Color IsPrimary
                    Button.Disabled (ConfigSetting.isValid model.Input |> not)
                    Button.OnClick (fun _ -> dispatch AddTodo)
                ] [
                    str "Add"
                ]
            ]
        ]
    ]

let view (model : Model) (dispatch : Msg -> unit) =
    Hero.hero [
        Hero.Color IsPrimary
        Hero.IsFullHeight
        Hero.Props [
            Style [
                Background """linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url("https://unsplash.it/1200/900?random") no-repeat center center fixed"""
                BackgroundSize "cover"
            ]
        ]
    ] [
        Hero.head [ ] [
            Mui.appBar [
            ]
        ]

        Hero.body [ ] [
            Container.container [ ] [
                Column.column [
                    Column.Width (Screen.All, Column.Is6)
                    Column.Offset (Screen.All, Column.Is3)
                ] [
                    Heading.p [ Heading.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [ str "NAC_SA_MUSIC" ]
                    containerBox model dispatch
                ]
            ]
        ]
    ]
