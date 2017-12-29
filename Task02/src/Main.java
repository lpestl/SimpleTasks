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
		int[] array02 = {8,9,0,1,2,3,4,5,6,7};
		int[] array03 = {0,1,2,3,4,5,6,7,8,9};
		int[] array04 = {1,2,3,4,5,6,7,8,9,0};
		int[] array05 = {6,7,8,9,1,2,3,4,5};
		int[] array06 = {8,9,1,2,3,4,5,6,7};
		int[] array07 = {3,4,5,6,7,8,9,1,2};
		int[] array08 = {1,2,3,4,5,6,7,8,9};
		int[] array09 = {2,3,4,5,6,7,8,9,1};
		int[] array10 = {1,2};
		int[] array11 = {2,1};
		int[] array12 = {1};
		int[] array13 = {2,3,3,1,1,2};
		int[] array14 = {2,2,3,3,3,1,1,1};
		int[] array15 = {1,2,3,1};
		int[] array16 = {};
		
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
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array07[index]);
	        
	    index = minFromSortArray(array08);
	    printArray(array08);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array08[index]);
	        
	    index = minFromSortArray(array09);
	    printArray(array09);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array09[index]);
	        
	    index = minFromSortArray(array10);
	    printArray(array10);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array10[index]);
	        
	    index = minFromSortArray(array11);
	    printArray(array11);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array11[index]);
	        
	    index = minFromSortArray(array12);
	    printArray(array12);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array12[index]);
	        
	    index = minFromSortArray(array13);
	    printArray(array13);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array13[index]);
	        
	    index = minFromSortArray(array14);
	    printArray(array14);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array14[index]);
	        
	    index = minFromSortArray(array15);
	    printArray(array15);
	    System.out.printf("Min index is %d and min = %d\n", 
	        index, 
	        array15[index]);
	        
	    index = minFromSortArray(array16);
	    printArray(array16);
	    System.out.printf ("Min index is %d and min = \n", 
	        index);
	}
}
