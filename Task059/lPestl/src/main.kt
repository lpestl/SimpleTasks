import java.util.Arrays

// Функция, которая считает максимальную заработанную сумму денег в пределах доступного времени
fun getMaximumEarnings(t: Int, arr: IntArray) : Int {
	// Выгода (сумматор)
	var earnings = 0
	// Количество необходимых итераций в массиве. Если t < Array.Size - то нет необходимости отсортировывать весь массив
	var steps = if (t < arr.size) t else arr.size
	// Счетчик итераций
	var i = 0
	// Сортировка массива по убыванию методом прямого выбора (Selection sort) O(n^2)
	while (i < steps) {
		// Инициализируем индекс максимального элемента первым индексом
		var indexMax = i
		// Счетчик для прохода неотсортированной части массива
		var j = i + 1
		while (j < arr.size) {
			// Если текущий элемент больше максимального, то запоминаем индекс, как индекс максимального
			if (arr[indexMax] < arr[j]) indexMax = j
			j++
		}
		// Kotlin-альтернатива функции swap. Меняем местами максимальный и первый/текущий элемента из массива 
		arr[i] = arr[indexMax].also { arr[indexMax] = arr[i] }
		// Увеличиваем сумматор на максимально выгодный проект
		earnings += arr[i]
		i++
	}	
	
	// Возвращаем максимальную выгоду
	return earnings	
}


fun main(args : Array<String>) { 
	var t1 = 3; var arr1 : IntArray = intArrayOf(1, 1, 1, 1, 1)
	var t2 = 4; var arr2 : IntArray = intArrayOf(11, 2)
	var t3 = 4; var arr3 : IntArray = intArrayOf(8, 2, 9, 17, 4, 4, 10)
	
	println(java.lang.String.format("T = %d, Arr = %s : Answer = %d", t1, Arrays.toString(arr1), getMaximumEarnings(t1, arr1)))
	println(java.lang.String.format("T = %d, Arr = %s : Answer = %d", t2, Arrays.toString(arr2), getMaximumEarnings(t2, arr2)))
	println(java.lang.String.format("T = %d, Arr = %s : Answer = %d", t3, Arrays.toString(arr3), getMaximumEarnings(t3, arr3)))
}