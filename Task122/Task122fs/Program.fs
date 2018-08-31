// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System;
/// ///////////////////////////////////////////////////////////////////////////////
/// Start solution
/// ///////////////////////////////////////////////////////////////////////////////

// Структура для ответа
type MaxSumSubMatrixData = {
    Sum: int64      // Максимальная сумма
    IStart: int     // Индекс строки левого верхнего угла подматрицы
    JStart: int     // Индекс столбца левого верхнего угла подматрицы
    IEnd: int       // Индекс строки прового нижнего угла подматрицы (включительно)
    JEnd: int       // Индекс строки правого нижнего угла подматрицы (включительно)
}
// функция для расчета максимальной суммы с перебором всех подматриц
let CalculateMaxSumSubMatrix (matrix: int[][]) =
    // Инициализация переменной для хранения ответа первым элементом матрицы
    let mutable res = { Sum = int64(matrix.[0].[0]); IStart = 0; JStart = 0; IEnd = 0; JEnd = 0; }
    // Функция расчета суммы элементов подматрицы от стартовых индексов до конечных (правый нижний угол подматрицы)
    let getSum istart jstart iend jend =
        // Суммируются элементы по очереди, значит общую сумму можно инициализировать нулем
        let mutable sum = int64(0)
        // Проходим по строкам и столбуам подматрицы
        for i in istart..iend do
            for j in jstart..jend do
                // И считаем сумму элементов
                sum <- sum + int64(matrix.[i].[j])
        // И возвращаем значение суммы с координатами подматрицы
        { Sum = sum; IStart = istart; JStart = jstart; IEnd = iend; JEnd = jend; }
    // Функция для перебора всех подматриц начинающихся с координат istart jstart
    let calculateMaxSumSubMatrixAtStart istart jstart =
        // Инициализируем переменную для хранения максимальной суммы и координат
        let mutable sumIJ = { Sum = int64(matrix.[istart].[jstart]); IStart = istart; JStart = jstart; IEnd = istart; JEnd = jstart; }
        // От текущих координат до правой и нижней границы матрицы - переберем все конечные координаты, чтобы точно перебрать все подматрицы
        for i in istart..matrix.Length - 1 do
            for j in jstart..matrix.[0].Length - 1 do
                // Получаем сумму текущей подматрицы
                let curSum = getSum istart jstart i j
                // И если она больше, то назаначаем её максимальной для всех подматриц с началом в istart jstart
                if curSum.Sum > sumIJ.Sum then
                    sumIJ <- curSum
        // Возвращаем максимальную сумму и координаты для istart jstart
        sumIJ
    // В цикле переберем все элементы, чтобы от них перебрать все подматрицы
    for i in 0..matrix.Length - 1 do 
        for j in 0..matrix.[0].Length - 1 do
            // Получаем максимальную сумму для i j
            let curSet = calculateMaxSumSubMatrixAtStart i j
            // и если она больше - то записываем её как ответ
            if curSet.Sum > res.Sum then
                res <- curSet
    // А после перебора всех возвращаем ответ
    res

/// ///////////////////////////////////////////////////////////////////////////////
/// End solution
/// ///////////////////////////////////////////////////////////////////////////////
/// 
/// ///////////////////////////////////////////////////////////////////////////////
/// Start Tests
/// ///////////////////////////////////////////////////////////////////////////////

[<EntryPoint>]
let main argv = 
    // Test 01: Test from task
    let matrix01 = [| [|-1; -2; -3|];
                      [| 1;  1; -4|];
                      [| 1;  1; -5|] |]

    let answer01 = CalculateMaxSumSubMatrix matrix01
    printf "%A\n" matrix01
    printf "MaxSum = %A\n" answer01.Sum
    printf "SubMatrix Coordinate: (%A, %A) - (%A, %A)\n\n" (answer01.IStart + 1) (answer01.JStart + 1) (answer01.IEnd + 1) (answer01.JEnd + 1)

    // Test 02: Test with negative int
    let matrix02 = [| [|-1; -2; -3|];
                      [|-4; -5; -6|];
                      [|-3; -2; -1|] |]

    let answer02 = CalculateMaxSumSubMatrix matrix02
    printf "%A\n" matrix02
    printf "MaxSum = %A\n" answer02.Sum
    printf "SubMatrix Coordinate: (%A, %A) - (%A, %A)\n\n" (answer02.IStart + 1) (answer02.JStart + 1) (answer02.IEnd + 1) (answer02.JEnd + 1)

    // Test 03: Test from task 8
    let matrix03 = [| [|-1; 10; -9; 5; 6; -10|] |]

    let answer03 = CalculateMaxSumSubMatrix matrix03
    printf "%A\n" matrix03
    printf "MaxSum = %A\n" answer03.Sum
    printf "SubMatrix Coordinate: (%A, %A) - (%A, %A)\n\n" (answer03.IStart + 1) (answer03.JStart + 1) (answer03.IEnd + 1) (answer03.JEnd + 1)

    // Test 04: Test from task 8 v2
    let matrix04 = [| [|1; 5; 7; -20; 3; 100; -250; 88; 33; 1; -40; 120|] |]

    let answer04 = CalculateMaxSumSubMatrix matrix04
    printf "%A\n" matrix04
    printf "MaxSum = %A\n" answer04.Sum
    printf "SubMatrix Coordinate: (%A, %A) - (%A, %A)\n\n" (answer04.IStart + 1) (answer04.JStart + 1) (answer04.IEnd + 1) (answer04.JEnd + 1)

    // Test generator
    printf "Press ESC to stop or other key for starting generate test matrix\n\n"
    
    while (Console.ReadKey(true).Key <> ConsoleKey.Escape ) do
        let rnd = new Random()
        let height = rnd.Next(1, 15)
        let width = rnd.Next(1, 15)
        let mutable matrix = Array.map(fun x -> Array.create width 0) [|0..height-1|]
        for i in 0..height - 1 do
            for j in 0..width - 1 do                
                matrix.[i].[j] <- rnd.Next(-1000, 1000)
            printf "%A\n" matrix.[i]
        let answer = CalculateMaxSumSubMatrix matrix
        printf "MaxSum = %A\n" answer.Sum
        printf "SubMatrix Coordinate: (%A, %A) - (%A, %A)\n\n" (answer.IStart + 1) (answer.JStart + 1) (answer.IEnd + 1) (answer.JEnd + 1)
    0 // return an integer exit code

/// ///////////////////////////////////////////////////////////////////////////////
/// End Tests
/// ///////////////////////////////////////////////////////////////////////////////
