#include <fstream>
#include <iostream>
#include <Windows.h>

#include "Timer.h"
#include "RTAParameters.h"

Timer::Timer(std::string type)
{
	m_Name = type;

	m_HeadNode = nullptr;
	m_TimingInfo = std::vector<TimerInfo*>();
}
Timer::~Timer(void)
{
	this->DestroyList(m_HeadNode);
}

std::string Timer::GetName(void)
{
	return m_Name;
}

void Timer::StartTracking(std::string name, int frame)
{
	TimerInfo* node = new TimerInfo();
	node->pNext = nullptr;
	node->Name = name;
	node->Frame = frame;
	node->StartTime = std::chrono::steady_clock::now();

	if (!m_HeadNode)
	{
		m_HeadNode = node;
		m_TailNode = node;
	}
	else
	{
		m_TailNode->pNext = node;
		m_TailNode = m_TailNode->pNext;
	}
}
void Timer::EndTracking(std::string name)
{
	this->EndTrackingNode(m_HeadNode, name);
}

void Timer::ExportReport(void)
{
	this->PopulateReport(m_HeadNode);

	std::ofstream ofs(std::string(RTAParameters::ReportPath + "\\Timings\\" + m_Name + "_TimingInfo.csv").c_str(), std::ofstream::out);
	if (ofs.is_open())
	{
		ofs << "ENTRY_NAME\tFRAME\tDURATION" << std::endl;
		for (TimerInfo* info : m_TimingInfo)
		{
			ofs << info->Name << "\t" << info->Frame << "\t" << GetExecutionTimeRecursive(m_HeadNode, info->Name) << std::endl;
		}
	}
	else
	{
		std::cout << RTAParameters::ReportPath + "\\Timings\\" + m_Name + "_TimingInfo.csv IO FAILED" << std::endl;
	}
}
double Timer::GetExecutionTime(std::string name)
{
	return GetExecutionTimeRecursive(m_HeadNode, name);
}

void Timer::EndTrackingNode(TimerInfo* pNode, std::string name)
{
	if (pNode->Name != name)
	{
		EndTrackingNode(pNode->pNext, name);
	}
	else
	{
		pNode->EndTime = std::chrono::steady_clock::now();

		std::chrono::duration<double, std::milli> ms = pNode->EndTime - pNode->StartTime;
		pNode->Duration = ms.count();
	}
}
void Timer::PopulateReport(TimerInfo* pNode)
{
	if (pNode)
	{
		m_TimingInfo.push_back(pNode);
		PopulateReport(pNode->pNext);
	}
}
void Timer::DestroyList(TimerInfo* pNode)
{
	if (pNode->pNext)
	{
		DestroyList(pNode->pNext);
	}
	delete pNode;
}
double Timer::GetExecutionTimeRecursive(TimerInfo* pNode, std::string name)
{
	while (pNode != nullptr)
		if (pNode->Name == name)
			return pNode->Duration;
		else
			return GetExecutionTimeRecursive(pNode->pNext, name);

	return 0.0;
}