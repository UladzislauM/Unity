using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumFibonachi : MonoBehaviour
{
    [SerializeField] private Text _textOutFib;

    public void CalcFibonachi()
    {
        var j = 0;
        var result = 0;
        for (int i = 1; i <= 4_000_000; i += j)
        {
            Debug.Log("i=" + i);
            if (i % 2 == 0)
            {
                result += i;
            }
            j = i - j;
        }
        _textOutFib.text = $"{result}";
    }

}
