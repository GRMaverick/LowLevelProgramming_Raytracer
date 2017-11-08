#include <iostream>
#include "MemoryPoolManager.h"

MemoryPoolManager* MemoryPoolManager::m_Instance = nullptr;

MemoryPoolManager::MemoryPoolManager(void)
{
	m_MemoryPools.clear();
}
MemoryPoolManager::~MemoryPoolManager(void)
{
	for (auto iter = m_MemoryPools.begin(); iter != m_MemoryPools.end(); iter++)
	{
		delete iter->second;
	}

	m_MemoryPools.clear();
}

MemoryPoolManager* MemoryPoolManager::Instance(void)
{
	if (!m_Instance)
	{
		m_Instance = new MemoryPoolManager();
	}
	return m_Instance;
}

void MemoryPoolManager::GenerateReport()
{
#ifdef _DEBUG
	std::map<std::string, MemoryPool*>::iterator iterator = m_MemoryPools.begin();

	std::cout << "Memory Pool Manager: " << std::endl;
	for (; iterator != m_MemoryPools.end(); iterator++)
	{
		std::cout << " >> " << iterator->first.c_str() << " MemoryPool " << std::endl;
		std::cout << "		- Size Allocated: " << iterator->second->GetSizeAllocated() << std::endl;
		std::cout << "		- Size Used: " << iterator->second->GetSizeUsed() << std::endl;
		std::cout << "		- Peak Size Used: " << iterator->second->GetPeakSizeUsed() << std::endl;
		std::cout << "		- Number of Allocations: " << iterator->second->GetNumberOfAllocations() << std::endl;
	}
#endif
}
MemoryPool* MemoryPoolManager::GetMemoryPool(std::string name, int objectCount, int objectSize)
{
	if (!m_MemoryPools[name])
	{
		m_MemoryPools[name] = new MemoryPool(name, objectCount, objectSize);
	}
	return m_MemoryPools[name];
}