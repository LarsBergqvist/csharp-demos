using System;

namespace DelegatesDemo;

public class DataProcessor
{
    public delegate int BusinessRuleDelegate(int x, int y);
    public int ProcessData(int x, int y, BusinessRuleDelegate rules)
    {
        return rules(x, y);
    }
    public int ProcessDataWithFunc(int x, int y, Func<int, int, int> rules)
    {
        return rules(x, y);
    }
}