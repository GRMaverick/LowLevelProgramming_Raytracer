#pragma once

#include <map>
#include <ctime>
#include <vector>
#include <chrono>

class Timer
{
public:
	static void Start(void);
	static void Stop(void);
	static void Reset(void);
	static void StartTracking(std::string name);
	static void EndTracking(std::string name);

	static void GenerateReport(void);
	static void ExportReport(void);

	//static float Average(void);
	//static float ElapsedTimeInSeconds(void);

private:
	static std::vector<std::string>																m_TrackingIds;
	static std::map<std::string, double>														m_FrameTimes;
	static std::map<std::string, std::chrono::steady_clock::time_point>	m_TrackingEnds;
	static std::map<std::string, std::chrono::steady_clock::time_point>	m_TrackingStarts;

	static std::chrono::steady_clock::time_point										m_LastLap;
	static std::chrono::steady_clock::time_point										m_StartTime;
	static std::chrono::steady_clock::time_point										m_EndTime;
};