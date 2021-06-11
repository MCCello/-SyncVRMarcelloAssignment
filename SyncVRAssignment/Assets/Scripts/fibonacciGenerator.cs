using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fibonacciGenerator : MonoBehaviour
{
    public List<int> fibNumbers = new List<int>();
    private void Awake()
    {
        GenerateFibLength(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateFibLength( int length)
    {
      FibRececursive(0, 1, 1, length);
    }
    public void FibRececursive(int a,int b, int counter, int length)
    {
        if (counter<=length)
        {
           // Debug.Log(a);
            fibNumbers.Add(a);
            FibRececursive(b, a + b, counter + 1, length);
        }
    }
    public void GetNextFibNumber()
    {
        double a = fibNumbers[fibNumbers.Count - 1] * (1 + Mathf.Sqrt(5)) / 2.0;
        //Debug.Log(next);
        fibNumbers.Add((int)Mathf.Round((float)a));
    }
}
