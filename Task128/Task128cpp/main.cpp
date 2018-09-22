#include <iostream>

int derivatives_of_the_residue[3] = { 3, 4, 3 * 2 };

unsigned long long split_summand_on_max_multipl(int n)
{
	return static_cast<unsigned long long>(pow(3, n / 3 - 1) * derivatives_of_the_residue[n % 3]);
}

int main()
{
	// Test from task
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
	std::cout << split_summand_on_max_multipl(100) << std::endl;

	return 0;
}
