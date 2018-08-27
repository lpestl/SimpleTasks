#pragma once

#include <map>
#include <vector>

struct intelligence_report
{
	unsigned int front_line;
	unsigned int perimeter_R;
	unsigned int perimeter_F;
};

enum neighbor_status { not_explored, perimeter, contact_line, our};

enum direction { N, E, S, W };

enum operation_status { in_process, mission_complete };

struct position
{
	unsigned int x;
	unsigned int y;
	position(unsigned int _x, unsigned int _y) : x(_x), y(_y) {};
};

struct intelligence_key
{
	position current_position;
	direction current_direction;
	intelligence_key(position pos, direction dir) : current_position(pos), current_direction(dir) {}
};

class military_intelligence
{
private:
	std::vector<intelligence_key> explored_;
	intelligence_key current_dislocation_;
	std::vector<std::vector<char>> war_area_;
	operation_status operation_status_;
	unsigned int perimeter_;
	unsigned int front_;
public:
	military_intelligence(position landing_point, std::vector<std::vector<char>> area);
	position get_position();
	direction get_direction();
	neighbor_status check_neighbor(direction dir);
	std::pair<neighbor_status, operation_status> next_step();
	intelligence_report get_report();
};

