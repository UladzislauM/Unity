using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparison3Nums : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private InputField _inputField2;
    [SerializeField] private InputField _inputField3;
    [SerializeField] private Text _textBotton;
    private Text _equalNum;

    public void Comp3()
    {
        if (int.TryParse(_inputField.text, out int fNum) 
            && int.TryParse(_inputField2.text, out int secNum) 
            && int.TryParse(_inputField3.text, out int thridNum))
        {
            if (fNum > secNum)
            {
                if (thridNum < secNum)
                {
                    _textBotton.text = $"{fNum} and {secNum} Biggest";
                }
                else if (secNum < thridNum)
                {
                    _textBotton.text = $"{fNum} and {thridNum} Biggest";
                }
                else if (secNum == thridNum)
                {
                    _textBotton.text = $"{fNum} Biggest";
                }
            }
            else if (fNum < secNum)
            {
                if (thridNum < fNum)
                {
                    _textBotton.text = $"{fNum} and {secNum} Biggest";
                }
                else if (fNum < thridNum)
                {
                    _textBotton.text = $"{secNum} and {thridNum} Biggest";
                }
                else if (fNum == thridNum)
                {
                    _textBotton.text = $"{secNum} Biggest";
                }
            }
            else if (fNum == secNum)
            {
                if (thridNum < fNum)
                {
                    _textBotton.text = $"{fNum}, {secNum} Biggest and equally";
                }
                else if (thridNum > fNum)
                {
                    _textBotton.text = $"{thridNum} Biggest";
                }
                else
                {
                    _textBotton.text = "All equally";
                }
            }
        }
        else
        {
            _textBotton.text = "0";
        }
    }
}
