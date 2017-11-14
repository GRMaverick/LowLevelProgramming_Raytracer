#pragma once

#include <map>
#include <ctime>
#include <vector>
#include <chrono>

class Timer
{
public:
	Timer(void);
	~Timer(void);

	void Start(void);
	void Stop(void);
	void Reset(void);
	void StartTracking(std::string name);
	void EndTracking(std::string name);

	void GenerateReport(void);
	void ExportReport(void);

private:
	std::string m_Name;
	std::vector<std::string>																m_TrackingIds;
	std::map<std::string, double>														m_FrameTimes;
	std::map<std::string, std::chrono::steady_clock::time_point>	m_TrackingEnds;
	std::map<std::string, std::chrono::steady_clock::time_point>	m_TrackingStarts;
	
	std::chrono::steady_clock::time_point										m_LastLap;
	std::chrono::steady_clock::time_point										m_StartTime;
	std::chrono::steady_clock::time_point										m_EndTime;
};