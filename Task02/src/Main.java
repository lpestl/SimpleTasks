import java.util.*;

public class Main
{
	// ћетод возвращает индекс минимального элемента в циклически сдвинутом отсортированном массиве
	public static int minFromSortArray(int[] sortArray) {
		// «апоминаем левый и правый индекс
		int leftIndex = 0, rightIndex = sortArray.length - 1;
		// “екущий индекс = середине между правым и левым индексом, если массив не пустой. »наче = -1
		int currIndex = (rightIndex >= 0) ? (rightIndex - leftIndex) / 2 : rightIndex;
		
		// ÷икл работает до тех пор, пока текущий индекс измен€етс€
		while (currIndex > 0) {
			// ≈сли элемент в массиве на средней позиции интервала между правым и левы индексами больше элемента на позиции правого индекса
			if (sortArray[leftIndex + currIndex] > sortArray[rightIndex]) {    
				// то мен€ем левый индекс на среднюю позицию интервал€
				leftIndex = leftIndex + currIndex;
			} else {
				// иначе мен€ем правый индекс на среднюю позицию интервала
				rightIndex = leftIndex + currIndex;
			}
			// считаем изменение дл€ средней позиции интервала
			currIndex = (rightIndex - leftIndex) / 2;
		}
		// ≈сли разница между интервалами = 1, то чравниваем два оставшихс€ элемента. 
		// если левый элемент больше, то значит правый - минимум. Ќужно увеличить смещение индекса на единицу
		if ((currIndex == 0) && (sortArray[leftIndex] > sortArray[rightIndex])) currIndex++;
		return leftIndex + currIndex;
	}
 
	public static void printArray(int[] array) {
		for (int i = 0; i < array.length; ++i) {
			System.out.printf("\t%d", array[i]);
		}
		System.out.println("");
	}
 
	public static void main(String[] args)
	{
		int[] array01 = {3,4,5,6,7,8,9,0,1,2};
		int[] array02 = {2,3,4,5,6,7,8,9,1};
		int[] array03 = {1,2};
		int[] array04 = {2,1};
		int[] array05 = {1};
		int[] array06 = {1,2,3,1};
		int[] array07 = {};
		
		int index = minFromSortArray(array01);
		printArray(array01);
		System.out.printf("Min index is %d and min = %d\n", index, array01[index]);
		
		index = minFromSortArray(array02);
		printArray(array02);
		System.out.printf("Min index is %d and min = %d\n", index, array02[index]);   
        
		index = minFromSortArray(array03);
		printArray(array03);
		System.out.printf("Min index is %d and min = %d\n", 
        index, 
        array03[index]);
        
	    index = minFromSortArray(array04);
	    printArray(array04);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array04[index]);
	        
	    index = minFromSortArray(array05);
	    printArray(array05);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array05[index]);
	        
	    index = minFromSortArray(array06);
	    printArray(array06);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array06[index]);
	        
	    index = minFromSortArray(array07);
	    printArray(array07);
	    System.out.printf("Min index is %d and min = NaN\n", 
	        index);
	        //array07[index]);	        
	}
}
