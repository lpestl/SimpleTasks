import java.util.Arrays

// �������, ������� ������� ������������ ������������ ����� ����� � �������� ���������� �������
fun getMaximumEarnings(t: Int, arr: IntArray) : Int {
	// ������ (��������)
	var earnings = 0
	// ���������� ����������� �������� � �������. ���� t < Array.Size - �� ��� ������������� ��������������� ���� ������
	var steps = if (t < arr.size) t else arr.size
	// ������� ��������
	var i = 0
	// ���������� ������� �� �������� ������� ������� ������ (Selection sort) O(n^2)
	while (i < steps) {
		// �������������� ������ ������������� �������� ������ ��������
		var indexMax = i
		// ������� ��� ������� ����������������� ����� �������
		var j = i + 1
		while (j < arr.size) {
			// ���� ������� ������� ������ �������������, �� ���������� ������, ��� ������ �������������
			if (arr[indexMax] < arr[j]) indexMax = j
			j++
		}
		// Kotlin-������������ ������� swap. ������ ������� ������������ � ������/������� �������� �� ������� 
		arr[i] = arr[indexMax].also { arr[indexMax] = arr[i] }
		// ����������� �������� �� ����������� �������� ������
		earnings += arr[i]
		i++
	}	
	
	// ���������� ������������ ������
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