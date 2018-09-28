#include <iostream>
/// Пытаясь разложить небольшие числа на слагаемые, произведение которых максимально, то легко можно заметить закономерность,
/// что максимальное произвидение достигается, когда большинство слагаемых = 3. Как это объснить, я пока не знаю, но с радостью воспользуюсь этой закономерностью.
/// Используя это - выделим три частных случая: 
/// 1) когда число кратно трем, тогда можно его представить всеми тройками;
// N%3==0 => N=3+..(N/3 раз)..+3 => MaxP=3*..(N/3 раз)..*3
/// 2) когда остаток от деления = 1, то 1 в произвидении не даст нам ничего, поэтому эту единицу лучше сложить с последней тройкой;
// N%3==1 => N=3+..(N/3 раз)..+3+1 = 3+..(N/3-1 раз)..+3+4 => MaxP=3*..(N/3-1 раз)..*3*4
/// 3) когда остаток от деления = 2, то он и остаётся последним слагаемым и множителем
// N%3==2 => N=3+..(N/3 раз)..+3+2 => MaxP=3*..(N/3 раз)..*3*2

// Значит зная заранее послий и предпоследний множители (слагаемые) - составим массив констант для быстрого доступа к ним
const int derivatives_of_the_residue[3] = { 3, (3 + 1), 3 * 2 };

// Сама функция имеет сложность O(1)
unsigned long long split_summand_on_max_multipl(int n)
{
	// А результат будет = 3^(N/3-1) * значение из массива по остатку
	return static_cast<unsigned long long>(pow(3, n / 3 - 1) * derivatives_of_the_residue[n % 3]);
}

int main()
{
	// Tests
	std::cout << split_summand_on_max_multipl(4) << std::endl;		// Should be 4
	std::cout << split_summand_on_max_multipl(5) << std::endl;		// Should be 6
	std::cout << split_summand_on_max_multipl(6) << std::endl;		// Should be 9
	std::cout << split_summand_on_max_multipl(7) << std::endl;		// Should be 12
	std::cout << split_summand_on_max_multipl(8) << std::endl;		// Should be 18
	std::cout << split_summand_on_max_multipl(9) << std::endl;		// Should be 27
	std::cout << split_summand_on_max_multipl(10) << std::endl;		// Should be 36
	std::cout << split_summand_on_max_multipl(11) << std::endl;		// Should be 54
	std::cout << split_summand_on_max_multipl(12) << std::endl;		// Should be 81
	std::cout << split_summand_on_max_multipl(13) << std::endl;		// Should be 108
	std::cout << split_summand_on_max_multipl(14) << std::endl;		// Should be 162
	std::cout << split_summand_on_max_multipl(15) << std::endl;		// Should be 243
	std::cout << split_summand_on_max_multipl(16) << std::endl;		// Should be 324
	std::cout << split_summand_on_max_multipl(17) << std::endl;		// Should be 486
	std::cout << split_summand_on_max_multipl(18) << std::endl;		// Should be 729
	std::cout << split_summand_on_max_multipl(19) << std::endl;		// Should be 972
	std::cout << split_summand_on_max_multipl(20) << std::endl;		// Should be 1458
	// ...
	std::cout << split_summand_on_max_multipl(100) << std::endl;	// Should be 7412080755407364

	return 0;
}
