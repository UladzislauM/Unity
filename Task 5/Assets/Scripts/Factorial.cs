using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factorial : MonoBehaviour
{
    private List<int> _factArray;
    [SerializeField] private InputField _textM;
    [SerializeField] private Text _outTextn;

    public void FactorialCalc (int numF)
    {
        int n = 1;
        int m = int.Parse(_textM.text);

        if (m < 0)
        {
            Debug.Log($"{0}");
            _outTextn.text = $"{0}";
        }
        else if (m == 0)
        {
            Debug.Log($"{1}");
            _outTextn.text = $"{1}";
        }
        else
        {
            for (int i = 2; i <= m; i++)
            {
                n *= i;
            }
            Debug.Log($"{n}");
            _outTextn.text = $"{n}";
        }
    }
}
