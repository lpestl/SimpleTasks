#include <iostream>

bool validation_input(const std::string& chess_move)
{
	return (chess_move.size() == 5) && 
		(chess_move.at(0) >= 'A') && (chess_move.at(0) <= 'H') && 
		(chess_move.at(3) >= 'A') && (chess_move.at(3) <= 'H') && 
		(chess_move.at(1) >= '1') && (chess_move.at(1) <= '8') && 
		(chess_move.at(4) >= '1') && (chess_move.at(4) <= '8');
}

bool isThatHorse(const std::string& chess_move)
{
	if (!validation_input(chess_move))
		return false;

	return  (chess_move.at(3) == chess_move.at(0) - 1 || chess_move.at(3) == chess_move.at(0) + 1) && 
			(chess_move.at(1) == chess_move.at(4) - 2 || chess_move.at(1) == chess_move.at(4) + 2) || 
			(chess_move.at(3) == chess_move.at(0) - 2 || chess_move.at(3) == chess_move.at(0) + 2) && 
			(chess_move.at(1) == chess_move.at(4) - 1 || chess_move.at(1) == chess_move.at(4) + 1);
}

int main()
{
	// Test from task
	auto chess_move = std::string{ "E2-E4" };
	std::cout << chess_move.c_str() << " -> " << std::boolalpha << isThatHorse(chess_move) << std::endl;	// Should be FALSE

	chess_move = std::string{ "B1-C3" };
	std::cout << chess_move.c_str() << " -> " << std::boolalpha << isThatHorse(chess_move) << std::endl;	// Should be TRUE

	// My tests
	chess_move = std::string{ "" };

	return 0;
}