namespace fred 

open System
open FSharp.Data.Sql
open System.Data

module db1 =

    let [<Literal>] connStr2017 = "Persist Security Info=False;Integrated Security=true;Initial Catalog=websharp;server=(local)"
    [<Literal>]
    let resolutionFolder = __SOURCE_DIRECTORY__

    FSharp.Data.Sql.Common.QueryEvents.SqlQueryEvent |> Event.add (printfn "Executing SQL: %O")

    type HR = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, connStr2017, ResolutionPath = resolutionFolder>


    let ctx = HR.GetDataContext()

    let allPeople () = 
        query {
            for c in ctx.Dbo.Person do select (c.Firstname)
        } |> Seq.toList






