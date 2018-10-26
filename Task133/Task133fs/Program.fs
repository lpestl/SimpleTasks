//              03. Ретроспектива PacMan`а или обратный путь

// Подсчет количества шагов PacMan`a в обратном направлении
let CalcPacManPath width height row column : uint64 =
    let mutable i = row         // Текущая строка - строка последней точки
    let mutable j = column      // Текущий столбец - столбец последней точки
    let mutable direction = 0   // Направление - 0 - вверх, 1 - вправо, -1 - влево
    let mutable step = 1UL      // текущее количество шагов
    // Если конечная точка не на границе
    if column <> width && column <> 1 then
        if row % 2 = 0 then // и если строка четная
            direction <- 1  // меняем направление на "вправо"
        else                // если нечетная
            direction <- -1 // меняем направление на "влево"
    // Двигаемся до тех пор, пока не достигнем начала матрицы (пути откуда стартовал PacMan по задаче)
    while i <> 1 || j <> 1 do
        if j = width then               // Если мы у правой границы
            direction <- direction - 1  // то меняем направление на "вверх" (или "влево", если пред. направление было "вверх")
        if j = 1 then                   // Если мы у левой границы
            direction <- direction + 1  // то меняем направление на "вверх" (или "вправо", если пред. направление было "вверх")
        j <- j + direction              // и меняем текущий столбец в зависимости от направления
        if direction = 0 then           // Если направление "вверх", то
            i <- i - 1                  // меняем текущую строку
        step <- step + 1UL              // и считаем шаги
    step

[<EntryPoint>]
let main argv = 
    let mutable N = 3
    let mutable M = 3
    let mutable row = 1
    let mutable column = 1
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 1; column <- 2    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 1; column <- 3    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 2; column <- 3    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 2; column <- 2    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 2; column <- 1    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 3; column <- 1    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 3; column <- 2    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)

    row <- 3; column <- 3    
    printfn "N x M = %d x %d" N M
    printfn "ROW x COLUMN = %d x %d" row column
    printfn "Answer = %A\n" (CalcPacManPath N M row column)
    0 // return an integer exit code
