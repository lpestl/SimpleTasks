// Learn more about F# at http://fsharp.org
open System

// Считаем конечный массив частичных сумм sum(i,j) = SUM(a(k,t))
let partialAmounts(array:int[][], width:int, height:int) =

    // Инициализация конечного массива
    Array.init height (fun i -> Array.init width (fun j -> // Сумма текущей "части" (i,j элемент конечного массива). Инициилизируем как 0
                                                           let mutable sum = 0
                                                           // Циклы с k и t, где k<=i,t<=j
                                                           for k in 0..i do
                                                               for t in 0..j do
                                                                   // Считаем сумму по формуле
                                                                   sum <- sum + array.[k].[t]
                                                           // Возвращаем сумму как i,j элемент конечной матрицы
                                                           sum )) 

[<EntryPoint>]
let main argv =
    // Инициализация массива
    let A = [| [| 1; 2; 3; 4; 5; |]; 
               [| 5; 4; 3; 2; 1; |];
               [| 2; 3; 1; 5; 4; |] |]
               
    // Вызываем функцию подсчета частичных сумм
    // Функция возвращает новый двумерный массив с суммами
    let answer = partialAmounts(A,5,3)
    
    // Вывод конечного массива
    printfn "%A" answer

    // Ожидание ввода символа
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
