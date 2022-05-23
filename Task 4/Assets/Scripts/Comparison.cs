using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparison : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private Text _textBotton;
    private Text _equalNum; 

    public void Comp()
    {
        if (int.TryParse(_inputField.text, out int fNum) && int.TryParse(_inputField2.text, out int secNum))
        {
            if(fNum < secNum)
            {
                _textBotton.text = $"{secNum} Biggest";
            }

            if (fNum > secNum)
            {
                _textBotton.text = $"{fNum} Biggest";
            }
            if (fNum == secNum)
            {
                _textBotton.text = $"Numbers are equal";
            }
        }
        else
        {
            _textBotton.text = "0";
        }
    }

}
