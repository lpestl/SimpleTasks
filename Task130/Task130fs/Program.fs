// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.Diagnostics
open System.Threading.Tasks
// Получить все разбиения на слагаемые
let GetAllPartitions(n:int) : Task<uint64> =
    async {
        // Переменная для подсчета количества разложений
        let mutable count = 0UL
        // Вывод на экран
        let print(summands:int[], top:int) =
            // Строим строку, для дальнейшего вывода
            let mutable str = System.String.Empty
            for i in 0..top-2 do
                str <- str + summands.[i].ToString() + "+"
            // И выводим её
            printfn "%s" (str + summands.[top - 1].ToString())

        // Рекрсивная функция, для получения очередного разлодения
        let rec get_next_partitions ( remaind:int,      // остаток до полной суммы
                                      summand:int,      // текущее слагаемое
                                      summands:int[],   // массив предыдущих слагаемых
                                      index:int ) =     // индекс слагаемого в массиве
                // Если остаток равен нулю, то выводим все разлодение на экран
                if remaind = 0 then
                    print(summands, index)
                    count <- count + 1UL
                // Иначе если остаток положительный и слагаемое текущее больше нуля, то
                elif remaind > 0 && summand > 0 then
                    // Проверим, что с текущим слагаеммым общая сумма не превысит нужной
                    if remaind - summand >= 0 then
                        // Если это так, то слагаемое нам подходит, добавляем его в массив
                        summands.[index] <- summand
                        // И ищем следующее подходящее слагаемое, обновив остаток и индекс
                        get_next_partitions(remaind - summand, summand, summands, index + 1)
                    // А теперь текущее слагаемое уменьшаем на один, и проверим его, подойдет ли для разложения
                    get_next_partitions(remaind, summand - 1, summands, index)
        
        // Инициализируем массив слагаемых нулями
        let summands = Array.zeroCreate n
        // И запустим рекрсию, по нахожлению разложений
        get_next_partitions(n, n, summands, 0)
        // Вернем количество
        return count
    } |> Async.StartAsTask

[<EntryPoint>]
let main argv = 
    // Test
    // Засекем время выполнения
    let sw = new Stopwatch();
    sw.Start()
    // Вызовем асинхронную функцию поиска, синхронно
    let count = 30 |> GetAllPartitions |> Async.AwaitTask |> Async.RunSynchronously
    // Выведем количество на экран
    printfn "Count = %A\n----------" count
    // Остановим счетчик времени и тоже выведем на экран
    sw.Stop()
    printfn "Estimated runtime is %A m. %A s. %A ms." ((sw.ElapsedMilliseconds / 1000L) / 60L) ((sw.ElapsedMilliseconds / 1000L) % 60L) (sw.ElapsedMilliseconds % 1000L)
    0 // return an integer exit code
