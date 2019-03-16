﻿namespace ws2
open WebSharper

[<JavaScript>]
module Clarity =

    open WebSharper.UI.Html
    open WebSharper.UI.Client
    open WebSharper.UI
    open Microsoft.EntityFrameworkCore.Internal
    open System.Security.Claims
    open System.ComponentModel.DataAnnotations

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


        
