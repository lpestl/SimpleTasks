/*					01_1. Факторизация с максимальных цифер				*/	

#include <iostream>
#include <vector>
#include <algorithm>
// Введем ENUM для удобства восприятия, в котором -1 - набор множителей не найден, а 1 - найден оптимаьный набор множителей
enum status { NOT_FOUND = -1, DONE = 1 };

// Рекурсивная функция. Вычисляет очередной текущий множитель и добавляет его в вектор
int factor(unsigned remainder, std::vector<int> &multipliers)
{
	// если остаток меньще 10 (является цифрой)
	if (remainder < 10) 
	{
		// то добавляем его в конец вектора
		multipliers.push_back(remainder);
		// и заканчиваем поиск
		return DONE;
	}
	// Так как нам нужно минимизировать число-ответ, то чтобы уменьшить число знаков, нам нужно максимизировать каждую цифру в этом числе
	// Поэтому цикл начинается с максимальной цифры и идет до самой низкой.
	for (auto i = 9; i > 1; --i)
		// Если остаток делиться на текущее число без остатка
		if (remainder % i == 0)
		{
			// То добавляем очередной множитель
			multipliers.push_back(i);
			// И если дальнейший поиск привел к комбинации множителей
			if (factor(remainder / i, multipliers) == DONE)
				// То прерваем дпльнейшие действия и сообщаем, что макцимальные цифры-множители найдены
				return DONE;
			// Иначе убираем текущее число из массива
			multipliers.pop_back();
		}
	// Возвращаем информацию, о том, что комбинайция не найдена
	return NOT_FOUND;
}

// Получаем минимальное натуральное число из набора множителей
long long get_min_number(std::vector<int>& multipliers)
{
	// Для начала сортируем вектор со множителями по убыванию
	std::sort(multipliers.begin(), multipliers.end(), std::greater<int>());
	// Инициализируем переменную, которая и будет являтся самим числом
	long long number = 0;
	// И каждую цифру конвертируем в слагаемое в соответсявии с разрядом
	for (auto i = 0; i < multipliers.size(); ++i)
		number += multipliers[i] * static_cast<long long>(std::pow(10.0, i));
	// И вернем результат
	return number;
}

// Функция запуска рекурсии факторизации и получение минимального чисала
long long factoring(unsigned n)
{
	// Инициализирум вектор для множителей 
	std::vector<int> multipliers;	
	// Если множители не найдены, то вернем -1. Иначе переведем вектор в число 
	return factor(n, multipliers) == NOT_FOUND ? -1 : get_min_number(multipliers);
}

int main()
{
	unsigned n;

	// Tests from task
	n = 11;	std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 12;	std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 14; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	
	// My test
	n = 126; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 300; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;
	n = 1000000000; std::cout << "N = " << n << "; Answer = " << factoring(n) << std::endl;

	return 0;
}
