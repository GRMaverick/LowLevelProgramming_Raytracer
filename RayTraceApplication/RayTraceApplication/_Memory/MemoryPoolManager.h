#pragma once
#include <map>
#include <typeindex>

#include "MemoryPool.h"

class MemoryPoolManager
{
public:
	~MemoryPoolManager(void);

	static MemoryPoolManager* Instance(void);

	void GenerateReport(void);
	MemoryPool* GetMemoryPool(std::string name, int objectCount, int objectSize);

private:
	static MemoryPoolManager* m_Instance;
	std::map<std::string, MemoryPool*> m_MemoryPools;

	MemoryPoolManager(void);
};