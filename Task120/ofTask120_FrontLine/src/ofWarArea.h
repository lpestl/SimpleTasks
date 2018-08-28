#pragma once
#include "ofPoint.h"
#include "ofRectangle.h"
#include "MilitaryIntelligence.h"

struct cell
{
	char value;
	std::vector<neighbor_status> borders;
};

class ofWarArea
{
public:
	void setup(std::vector<std::vector<char>> real_area);
	void update();
	void draw();
	void windowResized(int w, int h);
	void next_step();
private:
	std::vector<std::vector<char>> real_area_;
	ofPoint logicSizeArea_;
	ofRectangle rectArea_;
	ofPoint cellSize_;
	std::vector<std::vector<cell>> area_;
	float betweenInterval_;
	military_intelligence * mi_;
	operation_status op_status_;
	intelligence_report report_;
};

