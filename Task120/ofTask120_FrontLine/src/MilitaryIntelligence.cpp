#include "MilitaryIntelligence.h"

military_intelligence::military_intelligence(position landing_point, std::vector<std::vector<char>> area):
	war_area_(area),
	current_dislocation_(intelligence_key(landing_point, N)),
	perimeter_(0),
	front_(0),
	operation_status_(in_process)
{
}

position military_intelligence::get_position()
{
	return current_dislocation_.current_position;
}

direction military_intelligence::get_direction()
{
	return current_dislocation_.current_direction;
}

neighbor_status military_intelligence::check_neighbor(direction dir)
{
	neighbor_status status = not_explored;

	if (((dir == N) && (current_dislocation_.current_position.y == 0)) ||
		((dir == S) && (current_dislocation_.current_position.y == war_area_.size() - 1)) ||
		((dir == E) && (current_dislocation_.current_position.x == war_area_[0].size() - 1)) ||
		((dir == W) && (current_dislocation_.current_position.x == 0)))
	{
		status = perimeter;
		perimeter_++;
	}
	else
	{
		position checking_position = get_position();
		switch (dir) 
		{ 
			case N: checking_position.y--; break;
			case E: checking_position.x++; break;
			case S: checking_position.y++; break;
			case W: checking_position.x--; break;
		}

		if (war_area_[checking_position.y][checking_position.x] == war_area_[current_dislocation_.current_position.y][current_dislocation_.current_position.x])
			status = our;
		else
		{
			status = contact_line;
			front_++;
		}
	}
	explored_.push_back(current_dislocation_);
	return status;
}

std::pair<neighbor_status, operation_status> military_intelligence::next_step()
{
	neighbor_status result_checking = not_explored;
	bool finded = false;
	for (auto prev_pos : explored_)
		if ((prev_pos.current_position.x == current_dislocation_.current_position.x) && 
			(prev_pos.current_position.y == current_dislocation_.current_position.y) &&
			(prev_pos.current_direction == current_dislocation_.current_direction))
		{
			finded = true;
			break;
		}
	if (finded)
		operation_status_ = mission_complete;
	else
	{
		result_checking = check_neighbor(current_dislocation_.current_direction);
		if (result_checking != our)
			switch (current_dislocation_.current_direction)
			{
				case N: current_dislocation_.current_direction = E; break;
				case E: current_dislocation_.current_direction = S; break;
				case S: current_dislocation_.current_direction = W; break;
				case W: current_dislocation_.current_direction = N; break;
			}
		else
			switch (current_dislocation_.current_direction) 
			{ 
				case N: 
					current_dislocation_.current_direction = W;
					current_dislocation_.current_position.y--;
					break;
				case E:
					current_dislocation_.current_direction = N;
					current_dislocation_.current_position.x++; 
					break;
				case S:
					current_dislocation_.current_direction = E;
					current_dislocation_.current_position.y++; 
					break;
				case W:
					current_dislocation_.current_direction = S;
					current_dislocation_.current_position.x--; 
					break;
			}
	}
	return std::pair<neighbor_status, operation_status>(result_checking, operation_status_);
}

intelligence_report military_intelligence::get_report()
{
	intelligence_report report{};
	report.front_line = front_;
	if (war_area_[current_dislocation_.current_position.y][current_dislocation_.current_position.x] == 'R')
	{
		report.perimeter_R = perimeter_ + front_;
		report.perimeter_F = war_area_.size() * 2 + war_area_[0].size() * 2 - perimeter_ + front_;
	} else
	{
		report.perimeter_F = perimeter_ + front_;
		report.perimeter_R = war_area_.size() * 2 + war_area_[0].size() * 2 - perimeter_ + front_;
	}
	return report;
}

