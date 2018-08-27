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
	position pos(0, 0);
	auto ch = real_area[pos.y][pos.x];
	for (auto i = 0; i < logicSizeArea_.y; ++i)
	{
		for (auto j = 0; j < logicSizeArea_.x; ++j)
		{
			if (real_area[i][j] != ch)
			{
				pos.x = j;
				pos.y = i;
				break;
			}
		}
		if ((pos.x != 0) || (pos.y != 0))
			break;
	}
	mi_ = new military_intelligence(pos, real_area);
}

void ofWarArea::update()
{
}

void ofWarArea::draw()
{
	ofPushMatrix();
	ofScale(0.75, 0.75);
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
		auto offset = cellSize_.x / 6;
		switch (dir) { 
		case N: 
			ofDrawTriangle(x + offset, y + cellSize_.y / 2, x + cellSize_.x / 2, y + offset, x + cellSize_.x - offset, y + cellSize_.y / 2);
			break;
		case E:
			ofDrawTriangle(x + cellSize_.x / 2, y + offset, x + cellSize_.x - offset, y + cellSize_.y / 2, x + cellSize_.x / 2, y + cellSize_.y - offset);
			break;
		case S:
			ofDrawTriangle(x + offset, y + cellSize_.y / 2, x + cellSize_.x / 2, y + cellSize_.y - offset, x + cellSize_.x - offset, y + cellSize_.y / 2);
			break;
		case W:
			ofDrawTriangle(x + cellSize_.x / 2, y + offset, x + offset, y + cellSize_.y / 2, x + cellSize_.x / 2, y + cellSize_.y - offset);
			break;
		}
	}
	ofScale(1, 1);
	ofPopMatrix();
	
	ofSetColor(255, 255, 255, 127);
	ofDrawRectangle(ofGetWindowWidth() - 300, 0, 300, ofGetWindowHeight());

	auto currX = ofGetWindowWidth() - 250;
	auto currY = 100;
	ofSetColor(0, 0, 0);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Perimeter", currX + betweenInterval_ * 3, currY + betweenInterval_);
	
	currY += 50;
	ofSetColor(255, 255, 255);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Explored", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 50;
	ofSetColor(127, 127, 127);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Not Explored", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 50;
	ofSetColor(255, 0, 0);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Front Line", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 50;
	ofSetColor(0, 255, 0);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Russian", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 50;
	ofSetColor(255, 127, 0);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Fascists", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 50;
	ofSetColor(0, 127, 0);
	ofDrawRectangle(currX, currY, betweenInterval_ * 3, betweenInterval_);
	ofSetColor(0, 0, 0);
	ofDrawBitmapString(" - Intelligence group", currX + betweenInterval_ * 3, currY + betweenInterval_);

	currY += 100;
	ofSetColor(0, 0, 0);
	ofDrawBitmapString("Press 'SPACE' to next step", currX, currY + betweenInterval_);

	if (op_status_ == mission_complete)
	{
		currY += 100;
		ofDrawBitmapStringHighlight("Mission Complete!", currX, currY, ofColor::red);
		currY += 25;
		ofDrawBitmapStringHighlight("Front Line = " + ofToString(report_.front_line), currX, currY);
		currY += 25;
		ofDrawBitmapStringHighlight("Perimeter R = " + ofToString(report_.perimeter_R), currX, currY);
		currY += 25;
		ofDrawBitmapStringHighlight("Perimeter F = " + ofToString(report_.perimeter_F), currX, currY);
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
			op_status_ = mission_complete;
			report_ = mi_->get_report();

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


