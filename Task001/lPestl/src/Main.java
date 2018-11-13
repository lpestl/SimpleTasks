import java.util.*;

public class Main
{
	// Функция проверки уникальности символов в строке
	public static boolean checkUniquenessSymbols(String str) 
	{
		// Создаем хеш карту для хранения количества встречаемых символов
		Map<String, Integer> hashMap = new HashMap<>();
		
		// Проходим строку посимвольно
		for (int i=0; i < str.length(); i++){
			// Если текущий символ уже встречался в строке
			if (hashMap.get(Character.toString(str.charAt(i))) != null) {
				// То возвращаем False
				return false;
			} else {
				// Иначе указываем в хеш карте по символу 0
				hashMap.put(Character.toString(str.charAt(i)), 0);
			}
		}
		return true;
	}
	
	
	public static void main(String[] args)
	{
		System.out.printf("\nbuga - %b", checkUniquenessSymbols("buga"));
		System.out.printf("\nbugaga - %b", checkUniquenessSymbols("bugaga"));
		System.out.printf("\nbugavu - %b", checkUniquenessSymbols("bugavu"));
		System.out.printf("\n - %b", checkUniquenessSymbols(""));
	}
}
