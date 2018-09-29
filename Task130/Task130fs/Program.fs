// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.Diagnostics
open System.Collections.Generic
open System
open System.Threading.Tasks

let mutable count = 0

let PrintSummand (summands: int[], lastSummand: int) =
    async {
        let mutable str = String.Empty
        for i in 1..summands.Length - 1 do
            str <- str + summands.[i].ToString() + "+"
        printf "%A\n" (str + lastSummand.ToString())
        count <- count + 1
    } |> Async.StartAsTask :> Task
    
    
let rec GetAllPartitions (summands: int[]) : Task =    
    async {
        let tasks = new List<Task>()
        let mutable nextSummand = summands.[summands.Length - 1]
        while nextSummand > 0 do
            summands.[0] <- summands.[0] - nextSummand
            if summands.[0] > 0 then
                    tasks.Add(GetAllPartitions(Array.append summands [|nextSummand|]))
            else 
                if summands.[0] = 0 then
                    tasks.Add(PrintSummand(summands, nextSummand))
            summands.[0] <- summands.[0] + nextSummand
            nextSummand <- nextSummand - 1
        for i in 0..tasks.Count - 1 do 
            do! tasks.[i] |> Async.AwaitIAsyncResult |> Async.Ignore
    } |> Async.StartAsTask :> Task

[<EntryPoint>]
let main argv = 
    let sw = new Stopwatch();
    sw.Start()
    
    GetAllPartitions([|30;|]) |> Async.AwaitTask |> Async.RunSynchronously
    printfn "Count = %A\n----------" count
    
    sw.Stop()
    printfn "Estimated runtime is %A m. %A s. %A ms." ((sw.ElapsedMilliseconds / 1000L) / 60L) ((sw.ElapsedMilliseconds / 1000L) % 60L) (sw.ElapsedMilliseconds % 1000L)
    0 // return an integer exit code
