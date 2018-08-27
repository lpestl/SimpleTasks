#include "ofWarArea.h"
#include "ofMesh.h"
#include "ofBitmapFont.h"
#include "of3dUtils.h"

void ofWarArea::setup(std::vector<std::vector<char>> real_area)
{
	real_area_ = real_area;
	logicSizeArea_.y = real_area.size();
	logicSizeArea_.x = real_area[0].size();

	for (auto i = 0; i < logicSizeArea_.y; ++i)
	{
		std::vector<cell> line;
		for (auto j = 0; j < logicSizeArea_.x; ++j)
		{
			cell curCell;
			curCell.value = ' ';
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			curCell.borders.push_back(not_explored);
			line.push_back(curCell);
		}
		area_.push_back(line);
	}

	auto winWidth = ofGetWindowWidth();
	auto winHeight = ofGetWindowHeight();
	windowResized(winWidth, winHeight);
	mi_ = new military_intelligence(position(0, 0), real_area);
}

void ofWarArea::update()
{
}

void ofWarArea::draw()
{
	ofSetColor(127, 127, 127);
	ofDrawRectangle(rectArea_);
	for (auto i = 0; i < logicSizeArea_.y; ++i)
	{
		for (auto j = 0; j < logicSizeArea_.x; ++j)
		{
  			if (area_[i][j].value == 'R')
				ofSetColor(0, 255, 0);
			else if (area_[i][j].value == 'F')
				ofSetColor(255, 127, 0);
			else if (area_[i][j].value == ' ')
				ofSetColor(127, 127, 127);
			else if (area_[i][j].value == 'X')
				ofSetColor(255, 255, 255);
			auto y = i * (betweenInterval_ + cellSize_.y) + betweenInterval_ / 2 + rectArea_.y;
			auto x = j * (betweenInterval_ + cellSize_.x) + betweenInterval_ / 2 + rectArea_.x;
			ofDrawRectangle(x, y, cellSize_.x, cellSize_.y);

			switch (area_[i][j].borders[N]) { 
			case not_explored: break;
			case perimeter: 
				ofSetColor(0, 0, 0);
				ofDrawRectangle(x, y - betweenInterval_, cellSize_.x, betweenInterval_);
				break;
			case contact_line: 
				ofSetColor(255, 0, 0);
				ofDrawRectangle(x, y - betweenInterval_, cellSize_.x, betweenInterval_);
				break;
			case our: 
				ofSetColor(255, 255, 255);
				ofDrawRectangle(x, y - betweenInterval_, cellSize_.x, betweenInterval_);
				break;
			}
			switch (area_[i][j].borders[E]) {
			case not_explored: break;
			case perimeter:
				ofSetColor(0, 0, 0);
				ofDrawRectangle(x + cellSize_.x, y, betweenInterval_, cellSize_.y);
				break;
			case contact_line:
				ofSetColor(255, 0, 0);
				ofDrawRectangle(x + cellSize_.x, y, betweenInterval_, cellSize_.y);
				break;
			case our:
				ofSetColor(255, 255, 255);
				ofDrawRectangle(x + cellSize_.x, y, betweenInterval_, cellSize_.y);
				break;
			}
			switch (area_[i][j].borders[S]) {
			case not_explored: break;
			case perimeter:
				ofSetColor(0, 0, 0);
				ofDrawRectangle(x, y + cellSize_.y, cellSize_.x, betweenInterval_);
				break;
			case contact_line:
				ofSetColor(255, 0, 0);
				ofDrawRectangle(x, y + cellSize_.y, cellSize_.x, betweenInterval_);
				break;
			case our:
				ofSetColor(255, 255, 255);
				ofDrawRectangle(x, y + cellSize_.y, cellSize_.x, betweenInterval_);
				break;
			}
			switch (area_[i][j].borders[W]) {
			case not_explored: break;
			case perimeter:
				ofSetColor(0, 0, 0);
				ofDrawRectangle(x - betweenInterval_, y, betweenInterval_, cellSize_.y);
				break;
			case contact_line:
				ofSetColor(255, 0, 0);
				ofDrawRectangle(x - betweenInterval_, y, betweenInterval_, cellSize_.y);
				break;
			case our:
				ofSetColor(255, 255, 255);
				ofDrawRectangle(x - betweenInterval_, y, betweenInterval_, cellSize_.y);
				break;
			}
		}
	}

	if (mi_ != nullptr)
	{
		ofSetColor(0, 127, 0);
		auto pos = mi_->get_position();
		auto dir = mi_->get_direction();
		auto x = pos.x * (betweenInterval_ + cellSize_.x) + betweenInterval_ / 2 + rectArea_.x;
		auto y = pos.y * (betweenInterval_ + cellSize_.y) + betweenInterval_ / 2 + rectArea_.y;
 		ofDrawRectangle(x, y, cellSize_.x, cellSize_.y);
		ofSetColor(255, 255, 255);
		auto arrowHead = cellSize_.x / 15;
		switch (dir) { 
		case N: ofDrawArrow(ofVec3f(x + cellSize_.x / 2, y + cellSize_.y), ofVec3f(x + cellSize_.x / 2, y), arrowHead); break;
		case E: ofDrawArrow(ofVec3f(x, y + cellSize_.y / 2), ofVec3f(x + cellSize_.x, y + cellSize_.y /2), arrowHead); break;
		case S: ofDrawArrow(ofVec3f(x + cellSize_.x / 2, y), ofVec3f(x + cellSize_.x / 2, y + cellSize_.y), arrowHead); break;
		case W: ofDrawArrow(ofVec3f(x + cellSize_.x, y + cellSize_.y / 2), ofVec3f(x, y + cellSize_.y / 2), arrowHead); break;
		}
	}
}

void ofWarArea::windowResized(int w, int h)
{
	ofPoint size(w / logicSizeArea_.x, h / logicSizeArea_.y);
	if (size.x < size.y)
	{
		cellSize_.x = size.x / 6 * 5;
		betweenInterval_ = size.x / 6;
		cellSize_.y = cellSize_.x;
		rectArea_.width = w;
		rectArea_.height = size.x * logicSizeArea_.y;
	} else
	{
		cellSize_.y = size.y / 6 * 5;
		betweenInterval_ = size.y / 6;
		cellSize_.x = cellSize_.y;
		rectArea_.height = h;
		rectArea_.width = size.y * logicSizeArea_.x;
	}
	rectArea_.x = w / 2 - rectArea_.width / 2;
	rectArea_.y = h / 2 - rectArea_.height / 2;
}

void ofWarArea::next_step()
{
   	if (mi_ != nullptr)
	{
		auto pos = mi_->get_position();
		auto dir = mi_->get_direction();
		area_[pos.y][pos.x].value = 'X';
		auto step_result = mi_->next_step();
		if (step_result.second != mission_complete)
		{
 			area_[pos.y][pos.x].borders[dir] = step_result.first;
 		} else
		{
			auto report = mi_->get_report();
			delete mi_;
			mi_ = nullptr;
			for (auto i = 0; i < logicSizeArea_.y; ++i)
			{
				for (auto j = 0; j < logicSizeArea_.x; ++j)
				{
					area_[i][j].value = real_area_[i][j];
				}
			}
		}
	}
}


