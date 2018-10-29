// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
// Функция подсчета всех возможных вариантов пирамид
let CountPosiblePiramids N =
    // Рекурсивная функция с параметрами ОСТАТОК блоков, максимальная длинна текщего слоя из блоков и количество возможных пирамид
    let rec CalcTopLayer remainder maxLenght count =
        // Счетсик делаем изменяемым
        let mutable currCount = count
        // Если остаток и максимальная длинна корректны
        if remainder >= 0 && maxLenght >= 0 then
            // то проверим остаток блоков
            if remainder = 0 then
                // если все израсходованы - то пирамида готова
                currCount <- currCount + 1
            // иначе
            else
                // попробуем собрать следующий слой
                if remainder - maxLenght >= 0 then
                    // с учетом того, что остаток уменьшится на количество блоков в текщем слое, 
                    // а следующий слой будет минимально на единицу меньще текущего
                    currCount <- CalcTopLayer (remainder-maxLenght) (maxLenght - 1) currCount
                // Если максимальная длинна слоя может быть уменьшена
                if maxLenght - 1 > 0 then
                    // то уменьшим его и посчитаем все варианты пирамид для такого случая
                    currCount <- CalcTopLayer remainder (maxLenght-1) currCount
        // И вернем подсчитанное количество возможных пирамид
        currCount

    // Запуск рекурсии и ответ - количество возможных вариантов
    CalcTopLayer N N 0

[<EntryPoint>]
let main argv = 
    // Tests from task
    printfn "N = %A; Answer = %A" 3 (CountPosiblePiramids 3) 
    printfn "N = %A; Answer = %A" 5 (CountPosiblePiramids 5)
    printfn "N = %A; Answer = %A" 6 (CountPosiblePiramids 6)
    // Other tests
    printfn "N = %A; Answer = %A" 7 (CountPosiblePiramids 7)
    printfn "N = %A; Answer = %A" 8 (CountPosiblePiramids 8)
    printfn "N = %A; Answer = %A" 9 (CountPosiblePiramids 9)
    printfn "N = %A; Answer = %A" 10 (CountPosiblePiramids 10)
    printfn "N = %A; Answer = %A" 20 (CountPosiblePiramids 20)
    printfn "N = %A; Answer = %A" 30 (CountPosiblePiramids 30)
    printfn "N = %A; Answer = %A" 40 (CountPosiblePiramids 40)
    printfn "N = %A; Answer = %A" 50 (CountPosiblePiramids 50)
    printfn "N = %A; Answer = %A" 60 (CountPosiblePiramids 60)
    printfn "N = %A; Answer = %A" 70 (CountPosiblePiramids 70)
    printfn "N = %A; Answer = %A" 80 (CountPosiblePiramids 80)
    printfn "N = %A; Answer = %A" 90 (CountPosiblePiramids 90)
    printfn "N = %A; Answer = %A" 100 (CountPosiblePiramids 100)
    // Tests from chat
    printfn "N = %A; Answer = %A" 42 (CountPosiblePiramids 42)
    0 // return an integer exit code
