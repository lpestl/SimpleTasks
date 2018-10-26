/*			01. Метод "Перебор всех возможных комбинаци слоев"			 */

#include <iostream>
// рекурсивная функция для подсчета.
// remainder_blocks - оставшееся количество не использованных блоков
// count по ссылке - счетчик для подсчета возможных вариантов
// used_blocks - количество уже используемых блоков
// last_layer_lenght - ширина количества блоков в последнеем слое пирамиды
void calc_top_layers(int remainder_blocks, unsigned int & count, int used_blocks, int last_layer_lenght)
{
	// на текущий слой попробуем положить блоков начиная от максимально возможного количества и заканчивая всего одним
	for (auto i = last_layer_lenght - 1; i > 0; --i)
		// если после возведения еще одного слоя еще остались кирпичи (блоки)
		if (remainder_blocks - i > 0)
			// то считаем количество возможных завершений пирамиды, начиная с текущей кладки (с текущего слоя)
			calc_top_layers(remainder_blocks - i, count, used_blocks + i, i);
		// иначе если кирпичей не осталось,
		else if (remainder_blocks - 1 == 0)
			// значит пирамиду можно считать завершенной
			count++;
}

// функция подсчета количества возможных пирамид из определенного количества блоков
unsigned int count_possible_pyramids(int count_blocks)
{
	// объявим счетчик для подсчета возможных реализаций пирамид
	unsigned int count = 0;
	// и вызовем рекурсивный метод
	calc_top_layers(count_blocks, count, 0, count_blocks + 1);
	// результат подсчета вернем
	return count;
}

int main()
{
	// Test from task
	std::cout << "N = 3; Answer = " << count_possible_pyramids(3) << std::endl;
	std::cout << "N = 5; Answer = " << count_possible_pyramids(5) << std::endl;
	std::cout << "N = 6; Answer = " << count_possible_pyramids(6) << std::endl;
	// Other tests
	std::cout << "N = 7; Answer = " << count_possible_pyramids(7) << std::endl;
	std::cout << "N = 8; Answer = " << count_possible_pyramids(8) << std::endl;
	std::cout << "N = 9; Answer = " << count_possible_pyramids(9) << std::endl;
	std::cout << "N = 10; Answer = " << count_possible_pyramids(10) << std::endl;
	std::cout << "N = 20; Answer = " << count_possible_pyramids(20) << std::endl;
	std::cout << "N = 30; Answer = " << count_possible_pyramids(30) << std::endl;
	std::cout << "N = 40; Answer = " << count_possible_pyramids(40) << std::endl;
	std::cout << "N = 50; Answer = " << count_possible_pyramids(50) << std::endl;
	std::cout << "N = 60; Answer = " << count_possible_pyramids(60) << std::endl;
	std::cout << "N = 70; Answer = " << count_possible_pyramids(70) << std::endl;
	std::cout << "N = 80; Answer = " << count_possible_pyramids(80) << std::endl;
	std::cout << "N = 90; Answer = " << count_possible_pyramids(90) << std::endl;
	std::cout << "N = 100; Answer = " << count_possible_pyramids(100) << std::endl;
	// Test from chat
	std::cout << "N = 42; Answer = " << count_possible_pyramids(42) << std::endl;
	return 0;
}
