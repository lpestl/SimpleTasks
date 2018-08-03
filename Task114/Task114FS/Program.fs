// Количество целочисленных точек внутри круга
let rec NumberOfIntPoints radius =
    // счетчик
    let mutable res = 0
    // в цикле считаем количество целочисленных точек внутри одной четверти круга, 
    for x in 1..radius do
        // (!!!) не лежащих на его осях (поэтому считаем не с нуля, а с единицы)
        let mutable y = x
        while ((y <= radius) && ((x * x + y * y) <= radius * radius)) do
            if x = y then
                res <- res + 1
            else res <- res + 2
            y <- y + 1
    // Результат умножаем на количество четвертей у круга, 
    // добавляем количество точек лежащих на осях в четыре стороны от центра,
    // и добавляем центр окружности (по условиям задачи он целочисленный)
    1 + 4 * radius + 4 * res

[<EntryPoint>]
let main argv = 
    // 1, 5, 13, 29, 49, 81, 113, 149, 197, 253, 317 (последовательность A000328 в OEIS).
    for i in 1..10 do
        let answer = NumberOfIntPoints i
        printfn "Radius = %A; Answer = %A" i answer
    0 // return an integer exit code
