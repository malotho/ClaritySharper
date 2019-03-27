namespace ws2
open WebSharper

[<JavaScript>]
module Clarity =

    open WebSharper.UI.Html
    open WebSharper.UI.Client
    open WebSharper.UI
    open WebSharper.JavaScript
    open System.Globalization
    open FSharp.Date
    open System
    open WebSharper.Core.AST
    open WebSharper.JavaScript
    open WebSharper.UI.Client
    open WebSharper.UI.Client
    open WebSharper.UI.Client
    open WebSharper.UI.Client

    type Date = DateProvider<epoch=1970>

    type ClarityButtonType = 
        | Primary
        | Success
        | Warning
        | Danger
        | Regular
        | SuccessOutline
        | Info
        | WarningOutline
        | DangerOutline
        | Flat
        | Secondary
        | Tertiary

    type ClaritySelectVar = {
        Selection: string 
        ErrorState: bool 
        Values: List<string> 
        SubText: string
        Id: string
        Label: string
        }

    type ClarityInputVar = {
        Value: string
        Label: string
        ErrorState: bool
        SubText: string
        Placeholder: string
        Id: string
    }

    type ClarityCheckboxItem = {
        Option: string
        Checked: bool
    }

    type ClarityCheckboxVar = {
        Id: string
        ErrorState: bool
        SubText: string
        Options: ListModel<ClarityCheckboxItem, ClarityCheckboxItem>
        Label: string
    }

    type ClarityButtonSpec = {
        Type: ClarityButtonType
        Disabled: bool
        Size: ButtonSize
        Text: string
    }
    and ButtonSize = 
        | Small
        | Normal

    type ClarityDatePickerVar ={
        TheDate: string
        Month: int
        Year: int
        Day: int
    }

    let AttrDisabledDyn = Attr.DynamicPred "disabled"
    
    let ButtonSizePred = Attr.DynamicClassPred "btn-sm"

    let ClarityButton (spec:Var<ClarityButtonSpec>) callback = 
        let ButtonClass t = 
            match t with 
                | ClarityButtonType.Primary -> "btn-primary"
                | ClarityButtonType.Success -> "btn-success"
                | ClarityButtonType.Danger -> "btn-danger"
                | ClarityButtonType.Warning -> "btn-warning"
                | ClarityButtonType.Regular -> "btn-outline"
                | ClarityButtonType.SuccessOutline -> "btn-success-outline"
                | ClarityButtonType.Info -> "btn-info-outline"
                | ClarityButtonType.WarningOutline -> "btn-warning-outline"
                | ClarityButtonType.DangerOutline -> "btn-danger-outline"
                | ClarityButtonType.Flat -> "btn-link"
                | ClarityButtonType.Secondary -> ""
                | ClarityButtonType.Tertiary -> "btn-link"
        let classes = String.concat " " ["btn"; (ButtonClass spec.Value.Type)]
        let vpred = V(spec.V.Disabled)
        let vstr = (Var.Create "").View
        let vsize = V(spec.V.Size).Map (fun p -> 
            match p with
                | Small -> true
                | Normal -> false
            )
        Doc.Button spec.Value.Text [attr.``class`` classes; (AttrDisabledDyn vpred vstr); ButtonSizePred vsize] callback
        

    //let ClarityTextInput attrs children var =
    //    let a = attr.``type`` "text"::attr.``class`` "clr-input"::attrs
    //    match var with
    //        | Some(var) -> Doc.Input a var
    //        | None -> input a children

    let ClarityInputWrapper children =
        div [attr.``class`` "clr-input-wrapper"] children

    let ClaritySelectWrapper children = 
        div [attr.``class`` "clr-select-wrapper"] children
    
    let ClarityFormControl children =
        div [attr.``class`` "clr-form-control"] children

    let ClarityCheckboxWrapper children = 
        div [attr.``class`` "clr-checkbox-wrapper"] children

    let ClarityControlContainer showError children =
        let d = div [attr.``class`` "clr-control-container"; Attr.DynamicClassPred "clr-error" showError] children
        d

    let ClarityControlLabel (attrs:seq<Attr>) labelText =
        label (Seq.append attrs [attr.``class`` "clr-control-label"]) [text labelText]

    let ClaritySubtextWrapper children = 
        div [attr.``class`` "clr-subtext-wrapper"] children

    let ClarityCheckbox attrs (ccv:Var<ClarityCheckboxVar>) =
        let Id = ccv.Value.Id
        let mapper k (vp:Var<ClarityCheckboxItem>) =
            ClarityCheckboxWrapper [
                Doc.CheckBox [attr.id vp.Value.Option] (Lens vp.V.Checked)
                ClarityControlLabel [attr.``for`` vp.Value.Option] vp.Value.Option
            ]
        let res = ccv.Value.Options.MapLens mapper |> Doc.BindView Doc.Concat
        let stw = ClaritySelectWrapper [
            Doc.Element "clr-icon" [attr.``class`` "clr-validate-icon";Attr.Create "shape" "exclamation-circle"] []
            span [attr.``class`` "clr-subtext"] [Doc.TextView (Lens ccv.V.SubText).View]
        ]
        let d2 = ClarityControlContainer (Lens ccv.V.ErrorState).View [res]::[stw]
        ClarityFormControl (ClarityControlLabel [] ccv.Value.Label::d2)


    let ClarityInput attrs (civ:Var<ClarityInputVar>) =
        let Id = civ.Value.Id
        let a = attr.placeholder civ.Value.Placeholder::attr.id Id::attr.``type`` "text"::attr.``class`` "clr-input"::attrs
        let doc = Doc.Input a (Lens civ.V.Value)
        let wdoc = ClarityInputWrapper [
            doc
            Doc.Element "clr-icon" [attr.``class`` "clr-validate-icon";Attr.Create "shape" "exclamation-circle"] []
        ]
        let d2 = ClarityControlContainer (Lens civ.V.ErrorState).View [
            wdoc
            span [attr.``class`` "clr-subtext"] [Doc.TextView (Lens civ.V.SubText).View]
        ]
        ClarityFormControl [
            ClarityControlLabel [attr.``for`` Id] civ.Value.Label
            d2
        ]

    let ClarityPassword attrs (civ:Var<ClarityInputVar>) =
        let Id = civ.Value.Id
        let a = attr.placeholder civ.Value.Placeholder::attr.id Id::attr.``type`` "text"::attr.``class`` "clr-input"::attrs
        let doc = Doc.PasswordBox a (Lens civ.V.Value)
        let wdoc = ClarityInputWrapper [
            doc
            Doc.Element "clr-icon" [attr.``class`` "clr-validate-icon";Attr.Create "shape" "exclamation-circle"] []
        ]
        let d2 = ClarityControlContainer (Lens civ.V.ErrorState).View [
            wdoc
            span [attr.``class`` "clr-subtext"] [Doc.TextView (Lens civ.V.SubText).View]
        ]
        ClarityFormControl [
            ClarityControlLabel [attr.``for`` Id] civ.Value.Label
            d2
        ]

    let ClaritySelect attrs (csv:Var<ClaritySelectVar>) =
        let Id = csv.Value.Id
        let showDefault (value) = 
            match box value with
                | :? string as s -> s
                | _ -> sprintf "%A" value
        let a = attr.id Id::attr.``class`` "clr-select"::attrs
        let doc = Doc.Select a showDefault csv.Value.Values (Lens csv.V.Selection)
        let wdoc = ClaritySelectWrapper [
            doc
            Doc.Element "clr-icon" [attr.``class`` "clr-validate-icon";Attr.Create "shape" "exclamation-circle"] []
        ]
        let d2 = ClarityControlContainer (Lens csv.V.ErrorState).View [
            wdoc
            span [attr.``class`` "clr-subtext"] [Doc.TextView (Lens csv.V.SubText).View]
        ]
        ClarityFormControl [
            ClarityControlLabel [attr.``for`` Id] csv.Value.Label
            d2
        ]

    let ClarityInputGroup children = 
        div [attr.``class`` "clr-input-group"] children

    let ClarityDateContainer children =
        Doc.Element "clr-date-container" [attr.``class`` "clr-form-control"] children

    type DatePickerType =
        | Invisible
        | DayPicker
        | MonthPicker
        | YearPicker

    type DatePickerViewManager = {
        CurrentView: DatePickerType
    }

    let MonthNameFromMonthNumber m =
        match m with
            | 1 -> "Jan"
            | 2 -> "Feb"
            | 3 -> "Mar"
            | 4 -> "Apr"
            | 5 -> "May"
            | 6 -> "Jun"
            | 7 -> "Jul"
            | 8 -> "Aug"
            | 9 -> "Sep"
            | 10 -> "Oct"
            | 11 -> "Nov"
            | 12 -> "Dec"

    let ClarityDatePicker (cdp:Var<ClarityDatePickerVar>) =
        let dd = Lens cdp.V.Day
        let m = Lens cdp.V.Month
        let y = Lens cdp.V.Year
        let cal = (Var.Create {CurrentView = Invisible})
        let ccv = Lens cal.V.CurrentView
        let listen (evt:Dom.Event) =
            let myel = JS.Document.GetElementById("datepicker")
            let target = downcast evt.Target
            let rec f (a) =
                match a with
                    | (m, n) when n = null -> ccv.Value <- Invisible;() // outside
                    | (m, n) when n.ToString() = m.ToString() -> () // inside
                    | (m, n:Dom.Element) -> f(m, downcast n.ParentNode)
            if myel <> null then f(myel, target)
            ()

        let activateMonthPicker a b =
            ccv.Value <- MonthPicker
        let activateYearPicker a b =
            ccv.Value <- YearPicker
        let clickHandler a b = 
            let myel = JS.Document.GetElementById("datepicker")
            if myel = null then
                ccv.Value <- DayPicker 
                JS.Document.AddEventListener("click", listen)
            else
                ccv.Value <- Invisible
                JS.Document.RemoveEventListener("click", listen)
            ()
        let dayClickHandler (a:Dom.Element) b = 
            dd.Value <- a.FirstChild.TextContent |> int
            ccv.Value <- Invisible
            ()
        let previousMonthHandler a b =
            let cd = DateTime(y.Value, m.Value, dd.Value).AddMonths(-1)
            m.Value <- cd.Month
            y.Value <- cd.Year
            dd.Value <- cd.Day
            ()
        let nextMonthHandler a b =
            let cd = DateTime(y.Value, m.Value, dd.Value).AddMonths(1)
            m.Value <- cd.Month
            y.Value <- cd.Year
            dd.Value <- cd.Day
            ()
        let currentMonthHandler a b =
            let cd = DateTime.Today
            m.Value <- cd.Month
            y.Value <- cd.Year
            dd.Value <- cd.Day
            ()

        let c1 = Doc.BindView (fun a -> input [attr.``type`` "text";attr.value ((a.Day |> string) + "/" + (a.Month |> string) + "/" + (a.Year |> string))][]) cdp.View
        let c2 = button [attr.``type`` "button"; attr.``class`` "clr-input-group-icon-action"; Attr.Handler "click" clickHandler] [
            Doc.Element "clr-icon" [Attr.Create "shape" "calendar"] []
        ]
        let calendarStartDate year month =
            let rec back (da:System.DateTime) =
                match da.DayOfWeek with 
                    | System.DayOfWeek.Sunday -> da
                    | _ -> back (da.AddDays(-1.0))
            back (System.DateTime(year, month, 1))
        let lastSaturday year month =
            let rec moveToLast (lastDay:System.DateTime) =
                match lastDay.DayOfWeek with
                    | System.DayOfWeek.Saturday -> lastDay
                    | _ -> moveToLast (lastDay.AddDays(1.0))
            moveToLast((System.DateTime(year, month+1, 1)).AddDays(-1.0))

        let createDateRange4 (date1:System.DateTime) date2 =
            let start = min date1 date2
            let totalDays = (date2 - date1).TotalDays |> abs |> int |> (+) 1
            Seq.init totalDays (float >> start.AddDays)            

        let monthPicker () : Doc list =
            [Doc.Element "clr-datepicker-view-manager" [attr.``class`` "datepicker";attr.tabindex "0";attr.id "datepicker"] [
                    Doc.Element "clr-monthpicker" [Attr.Class "monthpicker"] [
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 1;ccv.Value <- DayPicker) ] [text "January"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 2;ccv.Value <- DayPicker) ] [text "February"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 3;ccv.Value <- DayPicker) ] [text "March"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 4;ccv.Value <- DayPicker) ] [text "April"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 5;ccv.Value <- DayPicker) ] [text "May"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 6;ccv.Value <- DayPicker) ] [text "June"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 7;ccv.Value <- DayPicker) ] [text "July"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 8;ccv.Value <- DayPicker) ] [text "August"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 9;ccv.Value <- DayPicker) ] [text "September"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 10;ccv.Value <- DayPicker) ] [text "October"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 11;ccv.Value <- DayPicker) ] [text "November"]
                        button [attr.``class`` "calendar-btn month";attr.``type`` "button";attr.tabindex "-1"; Attr.Handler "click" (fun a b -> m.Value <- 12;ccv.Value <- DayPicker) ] [text "December"]
                    ]
                ] 
            ]
        let yearPicker () : Doc list =
            let yc = Var.Create y.Value 
            let ycv = yc.View
            [Doc.Element "clr-datepicker-view-manager" [attr.``class`` "datepicker";attr.tabindex "0";attr.id "datepicker"] [
                    Doc.Element "clr-yearpicker" [attr.``class`` "yearpicker"] [
                        div [attr.``class`` "year-switchers"] [
                            button [attr.``class`` "calendar-btn switcher";attr.``type`` "button"] [
                                Doc.Element "clr-icon" [attr.dir "left"; attr.shape "angle"; attr.title "Previous";Attr.Handler "click" (fun a b -> yc.Value <- (yc.Value-10) )][]
                            ]
                            button [attr.``class`` "calendar-btn switcher";attr.``type`` "button"] [
                                Doc.Element "clr-icon" [attr.shape "event"; attr.title "Jump to current";Attr.Handler "click" (fun a b -> yc.Value <- y.Value )][]
                            ]
                            button [attr.``class`` "calendar-btn switcher";attr.``type`` "button"] [
                                Doc.Element "clr-icon" [attr.dir "right"; attr.shape "angle"; attr.title "Next";Attr.Handler "click" (fun a b -> yc.Value <- (yc.Value+10) )][]
                            ]
                        ]
                        div [attr.``class`` "years"] [
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-9;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-9 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-8;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-8 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-7;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-7 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-6;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-6 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-5;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-5 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-4;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-4 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-3;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-3 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-2;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-2 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-1;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-1 |> string))]
                            button [attr.``class`` "calendar-btn year";attr.``type`` "button"; attr.tabindex "-1";Attr.Handler "click" (fun a b -> y.Value <- yc.Value-0;ccv.Value <- DayPicker)] [textView (ycv.Map (fun a -> a-0 |> string))]
                        ]
                    ]
                ] 
            ]
        let dayPicker () : Doc list =
            let start year month = calendarStartDate year month
            let endDate year month = lastSaturday year month
            let datelist year month = createDateRange4 (start year month) (endDate year month)
            let datelistByWeek year month = Seq.chunkBySize 7 (datelist year month)
            let calday (day:DateTime) =
                let ddoc x = 
                    match x with
                    | (d1, d2, m1, m2) when m1 <> m2 -> button [attr.``class`` "day-btn is-disabled"; attr.``type`` "button"; attr.tabindex "-1"; Attr.Handler "click" dayClickHandler] [text (day.Day.ToString())]
                    | (d1, d2, m1, m2) when d1 = DateTime.Today.Day && m1 = DateTime.Today.Month -> button [attr.``class`` "day-btn is-today"; attr.``type`` "button"; attr.tabindex "-1"; Attr.Handler "click" dayClickHandler] [text (day.Day.ToString())]
                    | _ -> button [attr.``class`` "day-btn"; attr.``type`` "button"; attr.tabindex "-1"; Attr.Handler "click" dayClickHandler] [text (day.Day.ToString())]
                td [attr.``class`` "calendar-cell"] [
                    Doc.Element "clr-day" [attr.``class`` "day"] [
                        ddoc (day.Day, dd.Value, day.Month, m.Value)
                    ]
                ]
            let calrow (w:DateTime []) =
                tr [attr.``class`` "calendar-row"] (seq {for day in w -> (calday day)})
            let calRows year month =
                seq {for week in datelistByWeek year month -> (calrow week)}
                    

            let dpickbinder (v:ClarityDatePickerVar) =
                Doc.Element "clr-daypicker" [attr.``class`` "daypicker"] [
                    div [attr.``class`` "calendar-header"] [
                        div [attr.``class`` "calendar-pickers"] [
                            button [attr.``class`` "calendar-btn monthpicker-trigger"; attr.``type`` "button"; Attr.Handler "click" activateMonthPicker] [text (MonthNameFromMonthNumber(v.Month))]
                            button [attr.``class`` "calendar-btn yearpicker-trigger"; attr.``type`` "button"; Attr.Handler "click" activateYearPicker] [text (v.Year.ToString())]
                        ]
                        div [attr.``class`` "calendar-switchers"] [
                            button [attr.``class`` "calendar-btn switcher"; attr.``type`` "button"; Attr.Handler "click" previousMonthHandler] [
                                Doc.Element "clr-icon" [attr.dir "left"; attr.shape "angle"] []
                            ]
                            button [attr.``class`` "calendar-btn switcher"; attr.``type`` "button"; Attr.Handler "click" currentMonthHandler] [
                                Doc.Element "clr-icon" [attr.shape "event"] []
                            ]
                            button [attr.``class`` "calendar-btn switcher"; attr.``type`` "button"; Attr.Handler "click" nextMonthHandler] [
                                Doc.Element "clr-icon" [attr.dir "right"; attr.shape "angle"] []
                            ]
                        ]
                    ]
                    Doc.Element "clr-calendar" [] [
                        table [attr.``class`` "calendar-table weekdays"] [
                            tbody [] [
                                tr [attr.``class`` "calendar-row"] [
                                    td [attr.``class`` "calendar-cell"] [text "S"]
                                    td [attr.``class`` "calendar-cell"] [text "M"]
                                    td [attr.``class`` "calendar-cell"] [text "T"]
                                    td [attr.``class`` "calendar-cell"] [text "W"]
                                    td [attr.``class`` "calendar-cell"] [text "T"]
                                    td [attr.``class`` "calendar-cell"] [text "F"]
                                    td [attr.``class`` "calendar-cell"] [text "S"]
                                ]
                            ]
                        ]
                        table [attr.``class`` "calendar-table calendar-dates"] [
                            tbody [] [
                                calRows (v.Year) (v.Month) |> Doc.Concat
                            ]
                        ]
                    ]
                ]
            let dpd = Doc.BindView dpickbinder cdp.View
            [Doc.Element "clr-datepicker-view-manager" [attr.``class`` "datepicker";attr.tabindex "0";attr.id "datepicker"] [dpd] ]
        let binder (v:DatePickerViewManager) = 
            match v.CurrentView with
                | Invisible -> JS.Document.RemoveEventListener("click", listen);[Doc.Verbatim "<!---->"]
                | DayPicker -> dayPicker()
                | MonthPicker -> monthPicker()
                | YearPicker -> yearPicker()
            |> Doc.Concat
        let d = Doc.BindView binder cal.View
        let cig = ClarityInputGroup [
            c1
            c2
            d
        ]
        let ciw = ClarityInputWrapper [
            cig
        ]
        let cc = ClarityControlContainer (Var.Create false).View [
            ciw
        ]
        cc

    type ClarityBasicCardVar = {
        Heading: string
        Blocks: ClarityCardBlock list
        Actions: ClarityAction list
    } 
    and ClarityCardBlock = {
        Title: string
        Text: string
    }
    and ClarityAction = {
        Text: string
        Action: (unit->unit)
    }

    let ClarityBasicCard (cbc:ClarityBasicCardVar) =

        let mo = Var.Create false 
        let rec listen (evt:Dom.Event) =
            let myel = JS.Document.GetElementById("carddrop")
            let myel2 = JS.Document.GetElementById("carddropmenu")
            let target = downcast evt.Target
            let rec f (a) =
                match (a:Dom.Element * Dom.Element) with
                    | (m, n) when n = null -> mo.Value <- false;JS.Document.RemoveEventListener("click", listen);() // outside
                    | (m, n) when n.IsEqualNode(m) -> () // inside
                    | (m, n:Dom.Element) -> f(m, downcast n.ParentNode)
            if myel.ClassList.Contains("open") then f(myel2, target)
            ()

        let MenuOpenPred = Attr.DynamicClassPred "open"
        let block (b:ClarityCardBlock) =
            div [attr.``class`` "card-block"][
                div [attr.``class`` "card-title"] [text b.Title]
                div [attr.``class`` "card-text"] [text b.Text]
            ]
        let blocks = List.map block cbc.Blocks |> Doc.Concat
        let act (a:ClarityAction) =
            ClarityButton (Var.Create {Type=Flat; Disabled=false;Size=Small;Text=a.Text}) a.Action
        let acts = match cbc.Actions.Length with
                    | a when a <=2 -> cbc.Actions |> List.map act |> Doc.Concat
                    | _ -> cbc.Actions |> Seq.take 2 |> Seq.map act |> Doc.Concat
        let drop (aa:ClarityAction) =
            a [attr.``class`` "dropdown-item";Attr.Handler "click" (fun a b -> mo.Value <- false; aa.Action())] [text aa.Text]
        let drops = 
            let links = cbc.Actions |> Seq.rev |> Seq.take (cbc.Actions.Length-2) |> Seq.rev |> Seq.map drop |> Doc.Concat
            let dd = div [attr.``class`` "dropdown top-left";MenuOpenPred mo.View;attr.id "carddrop"] [
                button [attr.``class`` "dropdown-toggle btn btn-sm btn-link";Attr.Handler "click" (fun a b -> mo.Value <- true;JS.Document.AddEventListener( "click", listen))] [
                    text "Dropdown 1"
                    Doc.Element "clr-icon" [attr.shape "caret down"] []
                ]
                div [attr.``class`` "dropdown-menu";attr.id "carddropmenu"] [
                    links
                ]
            ]
            dd

        div [attr.``class`` "card"] [
            div [attr.``class`` "card-header"][text cbc.Heading]
            blocks
            div [attr.``class`` "card-footer"] [
                acts
                (if cbc.Actions.Length > 2 then drops else Doc.Verbatim "")
            ]
        ]



        
