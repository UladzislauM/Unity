using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuadraticEquation : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private InputField _inputField3;
    [SerializeField] private Text _textBotton;
    private Text _equalNum;

    public void QuadraticEq ()
    {
       
        if (int.TryParse(_inputField.text, out int a)
            && int.TryParse(_inputField2.text, out int b)
            && int.TryParse(_inputField3.text, out int c))
        {
            double dD = (b * b) - (4 * a * c);
            Debug.Log($"{dD}");

            if(dD > 0)
            {
                double resoultD1 = ((b + Math.Sqrt(dD)) / (2 * a));
                double resoultD2 = ((b - Math.Sqrt(dD)) / (2 * a));
                
                Debug.Log($"D<0, {Math.Sqrt(dD)}, {-( b - Math.Sqrt(dD))}");
                _textBotton.text = $"x1 = {resoultD1}, x2 = {resoultD2}";
            }
            else if (dD == 0)
            {
                double resoultD12 = -(b / (2 * a));
                Debug.Log($"D=0");
                _textBotton.text = $"x1 = x2 = {resoultD12}";
            }
            else if (dD < 0)
            {
                _textBotton.text = $"There are no roots";
            }
        }
        else
        {
            _textBotton.text = "0";
        }
    }
}
