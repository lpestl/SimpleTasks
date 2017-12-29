// Learn more about F# at http://fsharp.org
open System

// Функция для расчета минимального времени
let getMinTime(D: float32, V: float32, Vi: float32[], Ti: float32[]) =
    // Формула для расчета общего времени, где 
    // Vo - сумма увеличения скорости для всех устанавливаемых апгрейдов на текущем наборе
    // To - сумма задержки на старте для установки всех апгрейдов на текущем наборе
    let TotalTime Vo To = D / (V + Vo) + To
    // N - сколько всего апгрейдов возможно установить
    let N = Vi.Length
    // size - количество всех возможных вариантов установки апгрейдов
    let size = Convert.ToInt32(Math.Pow(2.0, (float)N))
    // Инициализируем массив, в котором будем хранить общее время заезда для текущего набора апгрейдов
    let mutable timeArray = Array.init size (fun _ -> 0.0f)
    let mutable index = 0
    // Через побитовый сдвиг, 
    [0..(1<<<N)-1]
    |> List.map (fun mask->
            // зададим набор коэффициентов для каждого апгрейда на текущем наборе.
            // т.е. Ki[i] = 0 (апгрейд не устанавливается) или 1(апгрейд устанавливается).
            // Ki - строка коэффициентов из таблицы истинности вроде:
            //          0   0
            //          0   1
            //          1   0
            //          1   1
            let Ki = Array.init N (fun i -> 
                if mask &&& (1<<<i) = 0 
                then 0 else 1)

            // Vo, To - начальные значения сумм прироста скорости и времени задержки
            let mutable Vo = 0.0f
            let mutable To = 0.0f
            // В цикле считаем суммы
            for i in 0..(N - 1) do 
                Vo <- Vo + Vi.[i] * (float32)Ki.[i]
                To <- To + Ti.[i] * (float32)Ki.[i]
            
            // Считаем время заезда с данным набором апгрейдов и с учетом задержки
            timeArray.[index] <- TotalTime Vo To
            //printfn "Time on set pack %A = %f " Ki timeArray.[index]
            index <- index + 1
            ) |> ignore
    // Находим и возвращаем минимум из массива со временем
    Array.min(timeArray)

// Точка входа
[<EntryPoint>]
let main argv =
    // Дано
    let D = 100.0f
    let V = 5.0f
    let Vi = [| 5.0f; 5.0f|]
    let Ti = [| 3.0f; 3.0f|]

    // Решение
    let minTime = getMinTime(D, V, Vi, Ti)
    printfn "Min time is %.3f" minTime
    0 // return an integer exit code
