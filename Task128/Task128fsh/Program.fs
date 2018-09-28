// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

// Если число разбивать на Х слагаемых и мы ищем максимальное произведение этих слагаемых, то имеет место быть следующее неравенство
// 
//  s1 + s2 + ... + sX      x   ___________________
//  ------------------  >=  _  / 
//           X               \/  s1 * s2 * .. * sX
// 
// С учётом этого несложно понять, что неравенство превращается в равенство только тогда, когда s1=s2=...=sX= N / X
// Отсюда следует, что максимальное значение достижимо только в случае si = N / X и произведение не может превышать (N/X)^X.
// Но так как число может быть не кратным, а слагаемые должны быть натуральными, то нужно учитывать и остаток. Рассмотрим следующий алгоритм:
let SplitSummandOnMaxMultipl N = 
    // Назначим максимальным произведением слагаемых N (когда слагаемое одно)
    let mutable maxMultiple = int64 N
    // И пройдем по всем возможным количествам слагаемых от 2 до И
    for x in 2..N do
        // Сначала посчитаем произведение без последнего множителя (N/x)^(x-1)
        let mutable multiple = double (N / x) ** double (x - 1)
        // Посчитаем остаток
        let remainder = N % x
        // И если остаток совпадает
        match remainder with
        // с 0, то к произвидению добавляем последний множитель, равный предыдущим
        | 0 -> multiple <- multiple * double (N / x)
        // с 1, то к произведению добавляем последний множитель увеличенный на остаток (на 1), т.к. 1 не увеличит наше суммарное произведение
        | 1 -> multiple <- multiple * double (N / x + remainder)
        // если остаток совпадает с чем-нибудь другим, то к произведению добавляем еще один множитель и остаток от деления
        | SomeElse -> multiple <- multiple * double (N / x) * double SomeElse
        // И если текущее произведение больше максимального
        if int64 multiple > maxMultiple then
            // то назначим его - максимальным
            maxMultiple <- int64 multiple
    // И вернем значение
    maxMultiple

[<EntryPoint>]
let main argv = 
    printfn "%A" (SplitSummandOnMaxMultipl 4)     // Should be 4
    printfn "%A" (SplitSummandOnMaxMultipl 5)     // Should be 6
    printfn "%A" (SplitSummandOnMaxMultipl 6)     // Should be 9
    printfn "%A" (SplitSummandOnMaxMultipl 7)     // Should be 12
    printfn "%A" (SplitSummandOnMaxMultipl 8)     // Should be 18
    printfn "%A" (SplitSummandOnMaxMultipl 9)     // Should be 27
    printfn "%A" (SplitSummandOnMaxMultipl 10)    // Should be 36
    printfn "%A" (SplitSummandOnMaxMultipl 11)    // Should be 54
    printfn "%A" (SplitSummandOnMaxMultipl 12)    // Should be 81
    printfn "%A" (SplitSummandOnMaxMultipl 13)    // Should be 108
    printfn "%A" (SplitSummandOnMaxMultipl 14)    // Should be 162
    printfn "%A" (SplitSummandOnMaxMultipl 15)    // Should be 243
    printfn "%A" (SplitSummandOnMaxMultipl 16)    // Should be 324
    printfn "%A" (SplitSummandOnMaxMultipl 17)    // Should be 486
    printfn "%A" (SplitSummandOnMaxMultipl 18)    // Should be 729
    printfn "%A" (SplitSummandOnMaxMultipl 19)    // Should be 972
    printfn "%A" (SplitSummandOnMaxMultipl 20)    // Should be 1458
    // ...
    printfn "%A\n" (SplitSummandOnMaxMultipl 100)   // Shoul be 7412080755407364
    0 // return an integer exit code
