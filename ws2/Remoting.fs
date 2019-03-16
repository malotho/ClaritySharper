namespace ws2

open WebSharper
open fred

open db1

module Server =

    [<Rpc>]
    let DoSomething input =
        let R (s: string) = System.String(Array.rev(s.ToCharArray()))
        async {
            return R input
        }


    [<Rpc>]
    let GetNames () : Async<string list> = 
        async {
            return allPeople ()
        }


