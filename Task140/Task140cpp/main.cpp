#include <iostream>

bool isThatHorse(const std::string& chess_move)
{
	return false;
}

int main()
{
	// Test from task
	auto chess_move = std::string{ "E2-E4" };
	std::cout << chess_move.c_str() << " -> " << std::boolalpha << isThatHorse(chess_move) << std::endl;	// Should be FALSE

	chess_move = std::string{ "B1-C3" };
	std::cout << chess_move.c_str() << " -> " << std::boolalpha << isThatHorse(chess_move) << std::endl;	// Should be TRUE

	return 0;
}