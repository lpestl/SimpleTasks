#include <iostream>

int number_of_int_points(int radius)
{
	int res = 0;
	const auto max_x = /*cos(45)*/1 / sqrt(2) * radius;
	for (auto x = 1; x <= max_x; ++x)
	{
		auto max_y = sqrt(radius*radius - x * x);
		int part = (static_cast<int>(max_y) - x) * 2;
		res += part;
	}
	res += static_cast<int>(max_x);

	return 1 + 4 * radius + 4 * res;
}

int main()
{
	for (auto i = 1; i <= 20; ++i)
	{
		std::cout << "Radius = " << i << "; Answer = " << number_of_int_points(i) << std::endl;
	}
 	return 0;
}