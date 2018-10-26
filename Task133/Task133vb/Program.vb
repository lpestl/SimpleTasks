'              04. Метод "Строковый анализатор" 

Module Program
    '  Функция подсчета ходов
    Function CalcPacManPath(width As Int32, height As Int32, row As Int32, column As Int32) As UInt64
        Dim count As UInt64 = 0     ' количество шагов (счетчик)
        Dim indexRow As Int32 = 1   ' индекс текущей строки
        ' Пройдем по строка с низу до текущей
        While indexRow < row
            ' прибавляя количество съеденных объектов в полной строке
            count += width
            indexRow += 1
        End While
        ' Если текущая строка - четная
        If indexRow Mod 2 = 0 Then
            count += width - (column - 1)   ' Добавляем часть строки справа от точки
        Else                                ' иначе
            count += column                 ' добавляем левую часть
        End If
        ' Вернем значение
        Return count
    End Function

    ' Tests
    Sub Main()
        Dim N As Int32 = 3
        Dim M As Int32 = 3
        Dim row As Int32 = 1
        Dim column As Int32 = 1
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 1
        column = 2
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 1
        column = 3
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 2
        column = 3
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 2
        column = 2
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 2
        column = 1
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 3
        column = 1
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 3
        column = 2
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
        
        row = 3
        column = 3
        Console.WriteLine($"N x M = {N} x {M};")
        Console.WriteLine($"ROW x COLUMN = {row} x {column}")
        Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)} ")
    End Sub

End Module
