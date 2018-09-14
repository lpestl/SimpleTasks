#include <iostream>
#include <math.h>
#include <vector>

unsigned int number_of_possible_options(std::vector<char> source_alphabet, unsigned int lenght_option, std::string except_substring) 
{
	auto all_option = static_cast<unsigned int>(pow(source_alphabet.size(), lenght_option));
	auto p_char_hit = static_cast<double>(lenght_option - except_substring.length()) / source_alphabet.size();
	double p = 1;
	for (auto i = 0; i < except_substring.length(); ++i)
		p *= p_char_hit;
	
	return all_option - static_cast<unsigned int>(p * all_option);
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

	return 0;
}