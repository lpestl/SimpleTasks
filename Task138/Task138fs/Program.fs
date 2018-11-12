// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

//	Метод 01. Простые суммы	
let SubArrayWithMaxAbsSum1 (inputArray: int[]) =
    // Почему бы не завести два массива для положительных и отрицательных?
    let mutable positive = Array.empty
    let mutable negative = Array.empty
    let mutable result = Array.empty
    // Пройдем по всем элементам массива
    for i in 0..inputArray.Length - 1 do
        // Если положительный элемент
        if inputArray.[i] > 0 then
            // Добавим в массив
            positive <- Array.append positive [|inputArray.[i]|]
        // Если он отрицательный
        elif inputArray.[i] < 0 then
            negative <- Array.append negative [|inputArray.[i]|]
    // Вернем подмассив в зависимости от того, у которого сумма по модулю больше
    if Array.sum positive > abs(Array.sum negative) then
        result <- positive
    else
        result <- negative
    result
    
// Метод 02. Сумма - индикатор
//let SubArrayWithMaxAbsSum2 (inputArray: int[]) =

// Tests
[<EntryPoint>]
let main argv = 
    // Test from task
    let inputArray = [|-1; 2; -1; 3; -4;|]
    printfn "Input = %A\nAnswer = %A\n\n" inputArray (SubArrayWithMaxAbsSum1(inputArray))
    //printfn "Input = %A\n Answer = %A\n\n" inputArray (SubArrayWithMaxAbsSum2(inputArray))
    //printfn "Input = %A\n Answer = %A\n\n" inputArray (SubArrayWithMaxAbsSum3(inputArray))
    0 // return an integer exit code
