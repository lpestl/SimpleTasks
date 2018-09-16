// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorial(n-1)

let pBernoulli (n: int, k: int, p:double) =
    double(factorial(n) / (factorial(k) * factorial(n-k))) * (p ** double k) * ((1.0 - p) ** double(n - k))

let NumberOfPossibleOptions(alphabet: char[], length: uint32, substr: string) =
    let all_option = double alphabet.Length ** double length
    let p_char = double 1 / double alphabet.Length
    let p = pBernoulli(alphabet.Length, int length - substr.Length + 1, p_char)
    
    (1.0 - p) * all_option


[<EntryPoint>]
let main argv = 
    // Test from task
    let alphabet01 = [|'1';'2';'3'|]
    let n01 = 3u
    let substring01 = "12"
    let answer01 = NumberOfPossibleOptions(alphabet01, n01, substring01)
    printf "For: %A; N=%A; without_sub_str=%A\nAnswer = %A\n" alphabet01 n01 substring01 answer01

    // Test from task
    let alphabet02 = [|'0';'1'|]
    let n02 = 2u
    let substring02 = "1"
    let answer02 = NumberOfPossibleOptions(alphabet02, n02, substring02)
    printf "For: %A; N=%A; without_sub_str=%A\nAnswer = %A\n" alphabet02 n02 substring02 answer02

    let a = pBernoulli(2, 0, double 1 / double 2);
    printf "%A \n" a

    0 // return an integer exit code
