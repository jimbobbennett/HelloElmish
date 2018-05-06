namespace HelloElmish

open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews
open Xamarin.Forms

type Model = 
    {
        Count : int
    }

type Msg =
    | Increment
    | Decrement

type App() =
    inherit Application()

    let init() = { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { Count = model.Count + 1 }
        | Decrement -> { Count = model.Count - 1 }

    let view () =
        MainPage(),
        [ "Count" |> Binding.oneWay (fun m -> m.Count.ToString())
          "Increment" |> Binding.msg Increment
          "Decrement" |> Binding.msg Decrement
        ]

    let runner = 
        Program.mkSimple init update view
        |> Program.withStaticView
        |> Program.run

    do base.MainPage <- runner.InitialMainPage
