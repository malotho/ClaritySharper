namespace ws2

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
open WebSharper.UI.Templating
open Clarity

[<JavaScript>]
module Client =
    
    let factory = 
        // Infinite sequence of numbers & get enumerator
        let numbers = Seq.initInfinite id
        let en = numbers.GetEnumerator()
        fun () -> 
            // Move to the next number and return it
            en.MoveNext() |> ignore
            en.Current


    let csv = { 
        Selection = "4" 
        ErrorState = false
        SubText = "Helper Text" 
        Values = ["4"; "5"; "6"]
        Id = "MySelect"
        Label = "This is my label"
        }


    let csvV = Var.Create csv
    let stv = csvV.LensAuto (fun p -> p.SubText)
    let selV = csvV.LensAuto (fun p -> p.Selection) 
    let showError = csvV.LensAuto (fun p -> p.ErrorState)
    let csvSel = csvV.View.Map(fun i -> i.Selection)

    let observe v =
        JavaScript.Console.Log(v)
        if v = "6" then 
            stv.Value <- "some new helper"
            selV.Value <- "4"
            showError.Value <- true

    View.Sink observe csvSel

    let civ = {
        Value = ""
        Placeholder = "placeholder text"
        SubText = "Helper text"
        ErrorState = false
        Label = "Some label"
        Id = "MyInput"
        }

    let civV = Var.Create civ

    let username = Var.Create {
        Value = ""
        Placeholder = "username"
        SubText = "Please enter your username"
        ErrorState = false
        Label = "Username"
        Id = "IdUsername"
    }

    let password = Var.Create {
        Value = ""
        Placeholder = "password"
        SubText = "Please enter your pasword"
        ErrorState = false
        Label = "Password"
        Id = "IdPassword"
    }

    let checks = Var.Create {
        Id = "IdCheck"
        ErrorState = false
        SubText = "Choose some options"
        Label = "Checkboxes"
        Options = ListModel.FromSeq [{Option = "Option 1"; Checked = false};{Option = "Option 2"; Checked = false}]
    }

    let mmm = checks.Value.Options

    let item = {Option = "Option 1"; Checked = false}

    let nnn : Var<ClarityCheckboxItem> = mmm.Lens item 

    let observe2 v = 
        JavaScript.Console.Log(v)

    View.Sink observe2 mmm.View

    let but1 = Var.Create {
            Type = Danger
            Disabled = false
            Size = Small
            Text = "Press Me!"
        }

    let cdp = Var.Create {
        TheDate = ""
        Year = 2019
        Month = 3
        Day = 24
    }

    let cbcv = {
        Heading = "Header"
        MainAction = Some(fun () -> JavaScript.Console.Log("Main Action hit") )
        Blocks = [
            {
                Title = "Block"
                Text = "Card content can contain text, links, images, data visualizations, lists and more."
            }
        ]
        Actions = [
            {
                Text = "Footer Action 1"
                Action = fun () -> JavaScript.Console.Log("Action 1 hit")
            };
             {
                Text = "Footer Action 2"
                Action = fun () -> JavaScript.Console.Log("Action 2 hit")
            };
             {
                Text = "Footer Action 3"
                Action = fun () -> JavaScript.Console.Log("Action 3 hit")
            };
             {
                Text = "Footer Action 4"
                Action = fun () -> JavaScript.Console.Log("Action 4 hit")
            }
       ]
    }
    

    let pv = V(civV.V.Label)

    let its = Var.Create []
    let sel = Var.Create "1"
    let sel2 = Var.Create 1
    let loginType = Var.Create "local"
    let v2 = sel2.View.Map(fun i -> sprintf "%A" i)

    let GetNames () (callback: string list -> unit) =
        async {
            let! names = Server.GetNames ()
            return callback names
        }
        |> Async.Start


    type MyTemplate = Template<"templates/my-template.html">

    let it mytext = li [] [text mytext]

    let f (l:string list) : unit = 
        let a = Seq.toList l
        its.Value <- a
        //MyTemplate().Content()
        ()


    let f2 (n:string) : unit =
        its.Value <- [n]
        ()

    let GetN () : unit = 
        GetNames () f
        ()


    let Main () =
        let varText = Var.Create "initial value"
        let d = 
            its.View 
            |> View.MapSeqCached(fun i ->
                li [] [text (string i)]
            )
            |> Doc.BindView Doc.Concat
        let rvInput = Var.Create ""
        let submit = Submitter.CreateOption rvInput.View
        let vReversed =
            submit.View.MapAsync(function
                | None -> async { return "" }
                | Some input -> Server.DoSomething input
            )
        div [] [
            ClarityRow [
                ClarityColumn4 [
                    span [attr.style "justify-content: center;display:flex"] [text "4"]
                ]
                ClarityColumn4 [
                    ClarityDatePicker cdp
                ]
                ClarityColumn4 [
                    ClarityBasicCard cbcv
                ]
            ]

            div [attr.``class`` "login-wrapper"] [
                form [attr.``class`` "login"] [
                    section [attr.``class`` "title"] [
                        h3 [attr.``class`` "welcome"] [text "Welcome to"]
                        text "Company Product Name"
                        h5 [attr.``class`` "hint"] [text "Use your Company ID to sign in or create one now"]
                    ]
                    div [attr.``class`` "login-group"] [
                        div [attr.``class`` "clr-control-container clr-form-control"] [
                            div [attr.``class`` "clr-select-wrapper"] [
                                select [] [
                                    Tags.option [attr.value "local"] [text "Local Users"]
                                    Tags.option [attr.value "admin"] [text "Administrator"]
                                ]
                            ]
                        ]
                        ClarityInput [] username
                        ClarityPassword [] password
                        div [] [
                            Doc.TextView sel.View
                            Doc.TextView (Lens username.V.Value).View
                            Doc.TextView varText.View
                        ]
                        ClaritySelect [] csvV
                        ClarityInput [] civV
                        ClarityCheckbox [] checks
                        div [] [
                            Doc.TextView csvSel
                        ]
                        ClarityButton but1 (fun () -> (Lens but1.V.Disabled).Value <- true )
                    ]
                ]
            ]
            Doc.Input [] rvInput
            Doc.Button "Send" [] submit.Trigger
            Doc.Button "Get" [] GetN
            hr [] []
            h4 [attr.``class`` "text-muted"] [text "The server responded:"]
            div [attr.``class`` "jumbotron"] [h1 [] [textView vReversed]]
            ul [] [d]
            MyTemplate().Content(d)
                .Doc()
        ]

