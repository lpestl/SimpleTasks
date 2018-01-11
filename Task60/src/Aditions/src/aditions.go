package main
import "fmt"
// Узел односвязного списка
type Item struct {
	pNext *Item
	val int
}
// Создание односвязного списка из массива
func createList(fromArray []int) *Item {
	if len(fromArray) == 0 {
		return nil
	}
	pHead := &Item{nil, fromArray[0]}
	pCurr := pHead
	for i:= 1; i < len(fromArray); i++ {
		pItem := &Item{nil, fromArray[i]}
		pCurr.pNext = pItem
		pCurr = pItem
	}
	return pHead
}

// Вывод односвязного списка в консоль
func printList(pList *Item) {
	pCurr := pList
	for {
		fmt.Printf("%d ", pCurr.val)
		if pCurr.pNext != nil {
			pCurr = pCurr.pNext
		} else {
			break
		}
	}
	fmt.Println("")
}

// Сложение односвязных списков
func addition(summands... *Item) *Item {
	// Память для следующего разряда,
	// Например 5+7 = 12, то есть order (текущий разряд) = 2, а следующий разряд - memory = 1
	memory := 0
	// Флаг для остановки цикла
	stop := false
	// Результирующий односвязный список (указатель на первый узел)
	pRes := &Item{nil, 0}
	// Курсор по текщему односвязному списку
	pCur := pRes
	// Инициализация курсоров для слагаемых из числа параметров
	curItems := make([]*Item, len(summands))
	for i:= 0; i < len(summands); i++ {
		// Устанавливаем курсоры на первый узел слагаемых
		curItems[i] = summands[i]
	}
	// Цикл по узлам слагаемых - односвязных списков 
	for {
		stop = true
	    order := 0
	    // Проверка: Все ли узлы всех слагаемых пройдены
	    for i:= 0; i < len(curItems); i++ {
	    	// Если текущий узел i-го слагаемого не равен nil
			if curItems[i] != nil {
				// то общий цикл еще не надо останавливать
				stop = false
				// считаем сумму для текущего разряда
				order += curItems[i].val
				// Курсор слагаемого передвигаем на следующий узел
				curItems[i] = curItems[i].pNext
			}
	    }
	    // Если сумма разряда = 0 и память = 0 и все узлы во всех слагаемых пройдены, то выходим из цикла
	    if order == 0 && memory == 0 && stop {
	    	break
	    }
	    // К сумме текущих разрядов прибавляем память из суммы предыдущих разрядов
	    temp := order + memory
	    // Текущий разряд = остатку от деления суммы на 10
		order = temp % 10
		// А в память записываем резульат деления на 10 (т.е. когда сумма разряда > 9, то запоминаем десятки, чтобы в следующем разряде их сложить
		memory = temp / 10
		
		// Записываем результат в узел и сдвигаем курсор на следующий узел
		pItem := &Item{nil, order}
		pCur.pNext = pItem
		pCur = pItem
	}
	// Возвращаем рузультирующий список без нулевого элемента, который был создан лишь для инициализации
	return pRes.pNext
}

func main() {
	// Главный тест
	array1 := [3]int { 4, 5, 7}
	array2 := [3]int { 8, 2, 1}
	pList1 := createList(array1[:])
	pList2 := createList(array2[:])

	fmt.Printf("----\n  ")
	printList(pList1)
	fmt.Printf("+ ")
	printList(pList2)
	fmt.Printf("= ")
	printList(addition(pList1, pList2))
	
	// Дополнительные тесты
	array3 := [2]int { 5, 5}
	array4 := [3]int { 8, 9, 1}
	pList3 := createList(array3[:])
	pList4 := createList(array4[:])

	fmt.Printf("----\n  ")
	printList(pList3)
	fmt.Printf("+ ")
	printList(pList4)
	fmt.Printf("= ")
	printList(addition(pList3, pList4))
	
	// Одно слагаемое	
	fmt.Printf("----\n  ")
	printList(pList4)
	fmt.Printf("= ")
	printList(addition(pList4))
	
	// Четыре слагаемых
	fmt.Printf("----\n  ")
	printList(pList1)
	fmt.Printf("+ ")
	printList(pList2)
	fmt.Printf("+ ")
	printList(pList3)
	fmt.Printf("+ ")
	printList(pList4)
	fmt.Printf("= ")
	printList(addition(pList1, pList2, pList3, pList4))
	
	// Сумма nil + слагаемое
	fmt.Printf("----\n  ")
	fmt.Printf("nil + ")
	printList(pList3)
	fmt.Printf("= ")
	printList(addition(nil, pList3))
	
	// Сумма nil слагаемых
	fmt.Printf("----\n  ")
	fmt.Printf("nil + nil")
	fmt.Printf(" = ")
	//printList(addition(nil, nil))
	fmt.Printf("nil")
}