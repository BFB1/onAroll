using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fibonacci
{
    // Reiknar Fibonacci röðina á stateful hátt.
    
    private readonly List<double> m_LastTwoNumbers = new List<double>() {0, 1};

    public double Current => m_LastTwoNumbers.Sum();
    
    public double Next()
    {
        double returnValue = m_LastTwoNumbers.Sum();
        m_LastTwoNumbers.RemoveAt(0);
        m_LastTwoNumbers.Add(returnValue);
        return returnValue;
    }

    public double Advance(int steps)
    {
        for (int i = 0; i < steps - 1; i++)
        {
            Next();
        }
        return Next();
    }
}