#pragma once

#include <map>
#include <ctime>
#include <vector>
#include <chrono>

class TimerInfo
{
public:
	std::string																Name;
	int																			Frame;
	double																	Duration;
	std::chrono::steady_clock::time_point					StartTime;
	std::chrono::steady_clock::time_point					EndTime;
	TimerInfo*															pNext;
	TimerInfo*															pPrevious;
};

class Timer
{
public:
	Timer(std::string type);
	~Timer(void);

	std::string GetName(void);

	void StartTracking(std::string name, int frame);
	void EndTracking(std::string name);
	double GetExecutionTime(std::string name);

	void ExportReport(void);
	
private:
	void DestroyList(TimerInfo* pNode);
	void EndTrackingNode(TimerInfo* pNode, std::string name);
	void PopulateReport(TimerInfo* pNode);
	double GetExecutionTimeRecursive(TimerInfo* pNode, std::string name);

	TimerInfo*									m_HeadNode;
	TimerInfo*									m_TailNode;

	std::string										m_Name;
	std::vector<TimerInfo*>				m_TimingInfo;
};