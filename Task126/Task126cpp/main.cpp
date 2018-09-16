#include <iostream>
#include <cassert>
#include <vector>

// Note lpestl: часть кода для составления таблицы факториала во время компиляции позаимствовал отсюда:
// https://ru.stackoverflow.com/questions/2479/%D0%A1%D0%B0%D0%BC%D1%8B%D0%B9-%D0%B1%D1%8B%D1%81%D1%82%D1%80%D1%8B%D0%B9-%D1%84%D0%B0%D0%BA%D1%82%D0%BE%D1%80%D0%B8%D0%B0%D0%BB
// Таблица длинная, по этому посчитаем ее во время компиляции (С++14).
template<int N>
struct Table {
	constexpr Table() : t() {
		t[0] = 1;
		for (auto i = 1; i < N; ++i)
			t[i] = t[i - 1] * i;
	}
	std::uint64_t t[N];
};

template<typename T>
T fac(T x) {
	static_assert(sizeof(T) <= sizeof(std::uint64_t), "T is too large");
	constexpr auto table = Table<66>();
	assert(x >= 0);
	return x < 66 ? static_cast<T>(table.t[x]) : 0;
}
// Note lpestl: end

// Pn(k) = n!/(k! * (n - k)!) * P^k * (1 - P)^(n-k)
double calculacte_p_Bernoulli(unsigned int n, unsigned int k, double probability)
{
	return static_cast<double>(fac(n)) / (fac(k) * fac(n - k)) * pow(probability, k) * pow(1 - probability, n - k);
}

unsigned int number_of_possible_options(std::vector<char> source_alphabet, unsigned int lenght_option, std::string except_substring) 
{
	auto all_option = static_cast<unsigned int>(pow(source_alphabet.size(), lenght_option));
	auto p_char = static_cast<double>(1) / source_alphabet.size();
	auto p_miss = static_cast<double>(source_alphabet.size() - 1) / source_alphabet.size();
	double p = 0;
	for (unsigned int i = 1; i <= lenght_option - except_substring.size(); ++i)
		p += pow(p_char, except_substring.size()) * pow(p_miss, lenght_option - except_substring.size() + i) * pow(p_char, lenght_option - except_substring.size());
	

	//auto p_start_substring = 1 - calculacte_p_Bernoulli(lenght_option - except_substring.size() + 1, 0, p_char);
	//auto p_other_char_substring = pow(p_char, except_substring.size() - 1);
	//auto p_common = p_start_substring * p_other_char_substring;
	//auto p_common = calculacte_p_Bernoulli(lenght_option, except_substring.size(), p_char);

	return all_option - p;
}

int main() 
{
	// Test from task
	std::vector<char> source_alphabet01 { '1', '2', '3' };
	auto n01 = 3;
	std::string except_substring01 = "12";
	auto answer01 = number_of_possible_options(source_alphabet01, n01, except_substring01);
	// Answer should be 21
	std::cout << "For: '1', '2', '3'; N=3; without_sub_str=\"12\"" << std::endl << "Answer = " << answer01 << std::endl;

	// Test from task
	std::vector<char> source_alphabet02{ '0', '1' };
	auto n02 = 2;
	std::string except_substring02 = "1";
	auto answer02 = number_of_possible_options(source_alphabet02, n02, except_substring02);
	// Answer should be 21
	std::cout << "For: '0', '1'; N=2; without_sub_str=\"1\"" << std::endl << "Answer = " << answer02 << std::endl;

 	return 0;
}