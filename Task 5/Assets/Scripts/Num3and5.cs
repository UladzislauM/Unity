using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num3and5 : MonoBehaviour
{
    [SerializeField] private Text _textOut;

    public void Mult3Or5 ()
    {
        int three = 0;
        int five = 0;
        int sum = 0;

        for (int i = 0; i < 1000; i++)
        {
            three = i % 3;
            if(three == 0)
            {
                sum += i;
            }
            five = i % 5;
            if(five == 0)
            {
                sum += i;
            }
        }
        Debug.Log($"{sum}");
        _textOut.text = $"{sum}";
    }
}
