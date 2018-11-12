// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System;
open System.Collections.Generic;

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
let SubArrayWithMaxAbsSum2 (inputArray: int[]) =
    // Получаем сумму для всего массива
    let sum = Array.sum inputArray
    // Инициализируем массив для возврата 
    let mutable result = Array.empty
    // выбираем элементы, которые дадут по модулю максимальную сумму
    for i in 0..inputArray.Length - 1 do
        // Если общая сумма - положительна
        if sum > 0 && inputArray.[i] > 0 then 
            // то и конечный подмассив надо строить из положительных элементов
            result <- Array.append result [|inputArray.[i]|]
        // Аналочино - если сумма отрицательна
        elif sum < 0 && inputArray.[i] < 0 then
            result <- Array.append result [|inputArray.[i]|]
    // вернем подмассив
    result

// Метод 03. Неоптимальный
let SubArrayWithMaxAbsSum3 (inputArray: int[]) =
    // Заведем список для сумм
    let mutable sums = Array.empty
    // И список списков для подмассивов
    let subLists = new List<List<int>>()
    // Максимальной суммой назначим первый элемент массива
    let mutable max = inputArray.[0]
    // Пройдем по всем элементам исходного массива
    for i in 0..inputArray.Length - 1 do
        // Назначим текущий элемент - началом подмассива и от него будем считать сумму
        sums <- Array.append sums [|inputArray.[i]|]
        let subList = new List<int>()
        subList.Add(inputArray.[i])
        subLists.Add(subList)
        // Проверяем элементы исходного массива начиная со следующего и до конца
        for j in i+1..inputArray.Length-1 do
            // Если сумма по модулю со следующим элементом увеличиться
            if abs(sums.[i]) < abs(sums.[i] + inputArray.[j]) then
                // То увеличим сумму
                sums.[i] <- sums.[i] + inputArray.[j]
                subLists.[i].Add(inputArray.[j])
        // Теперь вычисляем максимальную сумму по модулю и индекс
        if (abs(sums.[i]) > abs(max)) then
            max <- sums.[i]
    // И вернем подмассив
    subLists.[Array.IndexOf(sums, max)].ToArray()

// Tests
[<EntryPoint>]
let main argv = 
    // Test from task
    let inputArray = [|-1; 2; -1; 3; -4;|]
    printfn "Input = %A\nAnswer = %A\n\n" inputArray (SubArrayWithMaxAbsSum1(inputArray))
    printfn "Input = %A\n Answer = %A\n\n" inputArray (SubArrayWithMaxAbsSum2(inputArray))
    printfn "Input = %A\n Answer = %A\n\n" inputArray (SubArrayWithMaxAbsSum3(inputArray))
    0 // return an integer exit code
