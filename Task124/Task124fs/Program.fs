type ArrayPart = { Part: int[]; Sum: int }

let CalculateDiversification (array : int[]) =
    let sum (arr : int[]) = 
        let mutable s = arr.[0]
        for i in 1..arr.Length - 1 do
            s <- s + arr.[i]
        s
    let half = (sum array) / 2
    ({ Part = [|0|]; Sum = 0} , { Part = [|0|]; Sum = 0} )

[<EntryPoint>]
let main argv = 
    // Test01: from task
    let shares01 = [|1; 2; 3; 3|]
    let (part01_1, part01_2) = CalculateDiversification shares01
    printf "FirstShares = \"%A\", FirstTotalValue = %A\n" part01_1.Part part01_1.Sum
    printf "SecondShares = \"%A\", SecondTotalValue = %A\n\n" part01_2.Part part01_2.Sum

    // Test02: from chat
    let shares02 = [|4; 5; 6; 7; 8|]
    let (part02_1, part02_2) = CalculateDiversification shares02
    printf "FirstShares = \"%A\", FirstTotalValue = %A\n" part02_1.Part part02_1.Sum
    printf "SecondShares = \"%A\", SecondTotalValue = %A\n\n" part02_2.Part part02_2.Sum

    // Test03: from chat
    let shares03 = [| 10; 16; 82; 69; 69; 53; 13; 12; 96; 23 |]
    let (part03_1, part03_2) = CalculateDiversification shares03
    printf "FirstShares = \"%A\", FirstTotalValue = %A\n" part03_1.Part part03_1.Sum
    printf "SecondShares = \"%A\", SecondTotalValue = %A\n\n" part03_2.Part part03_2.Sum

    // Test04: from chat
    let shares04 = [| 19; 17; 13; 9; 6 |]
    let (part04_1, part04_2) = CalculateDiversification shares04
    printf "FirstShares = \"%A\", FirstTotalValue = %A\n" part04_1.Part part04_1.Sum
    printf "SecondShares = \"%A\", SecondTotalValue = %A\n\n" part04_2.Part part04_2.Sum
    0 // return an integer exit code
