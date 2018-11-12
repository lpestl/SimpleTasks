#include <iostream>
#include <vector>
#include <complex>
#include <numeric>

/*						Метод 01. Простые суммы						 */
// Возвращает подмассив с максимальной суммой по модулю
std::vector<int> sub_array_with_max_abs_sum1(const std::vector<int>& input_array)
{
	// Почему бы не завести два массива для положительных и отрицательных?
	std::vector<int> positive;
	std::vector<int> negative;
	// И посчитаем их сумму
	unsigned long long sum_positive = 0;
	unsigned long long sum_negative = 0;
	// Пройдем по всем элементам массива
	for (auto& value : input_array)
		// Если положительный элемент
		if (value > 0) 
		{
			// Добавим в массив и подсчитаем сумму
			positive.push_back(value);
			sum_positive += value;
		}
		// Если он отрицательный
		else if (value < 0) 
		{
			// Добавим в подмассив и подсчитаем сумму
			negative.push_back(value);
			sum_negative -= value;
		}
	// Вернем подмассив в зависимости от того, у которого сумма по модулю больше
	return sum_positive > sum_negative ? positive : negative;
}

/*						Метод 02. Сумма - индикатор					   */			
std::vector<int> sub_array_with_max_abs_sum2(const std::vector<int>& input_array)
{
	// Получаем сумму для всего массива
	long long sum = std::accumulate(input_array.begin(), input_array.end(), 0);
	// Инициализируем вектор для возврата 
	std::vector<int> output_array;
	// выбираем элементы, которые дадут по модулю максимальную сумму
	for (auto& value : input_array)
	{
		// Если общая сумма - положительна
		if (sum > 0)
			// то и конечный подмассив надо строить из положительных элементов
			if (value > 0)
				output_array.push_back(value);
		// Аналочино - если сумма отрицательна
		if (sum < 0)
			if (value < 0)
				output_array.push_back(value);
	}
	// вернем подмассив
	return output_array;
}

/*						Метод 03. Неоптимальный					   */
std::vector<int> sub_array_with_max_abs_sum3(const std::vector<int>& input_array)
{
	// Заведем вектор для сумм
	std::vector<long long> sums;
	// И в векторе для каждой суммы будем собирать свой подмассив
	std::vector<std::vector<int>> sub_arrays;
	// Назначим max и i_max для сумм - как первый элемент
	int max = input_array[0]; int i_max = 0;
	// Пройдем по всем элементам исходного массива
	for (size_t i = 0; i < input_array.size(); ++i)
	{
		// Назначим текущий элемент - началом подмассива и от него будем считать сумму
		sums.push_back(input_array[i]);
		sub_arrays.push_back(std::vector<int> { input_array[i] });
		// Проверяем элементы исходного массива начиная со следующего и до конца
		for (size_t j = i + 1; j < input_array.size(); ++j)
			// Если сумма по модулю со следующим элементом увеличиться
			if (std::abs(sums[i]) < std::abs(sums[i] + input_array[j]))
			{
				// То увеличим сумму
				sums[i] += input_array[j];
				// И добавим элемент в подмассив
				sub_arrays[i].push_back(input_array[j]);
			}
		// Теперь вычисляем максимальную сумму по модулю и индекс
		if (std::abs(sums[i]) > std::abs(max))
		{
			max = sums[i];
			i_max = i;
		}
	}
	// И возвращаем подмассив с максимальной суммой по модулю
	return sub_arrays[i_max];
}


// Вспомогательная функция для вывода вектора на экран
void print_vector(const std::vector<int>& vector)
{
	// Если вектор пустой
	if (vector.empty())
	{
		// выводим пустые скобки
		std::cout << "[ ]" << std::endl;
		return;
	}
	// Выводим скобочку и первый элемент
	std::cout << "[ " << vector[0];
	// а остальные элементы (если они есть), через запятую
	for (size_t i = 1; i < vector.size(); ++i)
		std::cout << ", " << vector[i];
	// закрываем скобку
	std::cout << " ]" << std::endl;
}

int main()
{
	// Test from task
	std::vector<int> input_vector = { -1, 2, -1, 3, -4 };

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum1(input_vector)); std::cout << std::endl;

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum2(input_vector)); std::cout << std::endl;

	std::cout << "Input = "; print_vector(input_vector);
	std::cout << "Answer = "; print_vector(sub_array_with_max_abs_sum3(input_vector)); std::cout << std::endl;
	return 0;
}
