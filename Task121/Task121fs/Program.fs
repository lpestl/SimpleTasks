// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

module StringHelper =
    let ToMirrorRegistr(str:string) =
        let chars = str.ToCharArray()
        for i in 0..chars.Length do
            chars.[i] = (((chars.[i] >= 0x61) && (chars.[i] <= 0x7A)) || ((chars.[i] >= 0x430) && (chars.[i] <= 0x44F))) ? 
                (char) (chars.[i] - 0x20) : 
                    (((chars.[i] >= 0x41) && (chars.[i] <= 0x5A)) || ((chars.[i] >= 0x410) && (chars.[i] <= 0x42F))) ? 
                        (char) (chars.[i] + 0x20) : chars.[i];

[<EntryPoint>]
let main argv = 
    let message =  "cAPS LOCK. я ТЕБЯ ненавижу!"
    printf "%A\n" message

    printf "еЩЁ ОДНА кРиВаЯ СТРОКА\n"
    0 // return an integer exit code
