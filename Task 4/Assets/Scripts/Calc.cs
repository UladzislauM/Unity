using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
   [SerializeField] private InputField _inputField;
   [SerializeField] private InputField _inputField2;
   [SerializeField] private Text _resaltEqually;

    #region Metods
    public void Plus()
    {
        if (int.TryParse(_inputField.text, out int fNum) && int.TryParse(_inputField2.text, out int secNum))
        {
            _resaltEqually.text = $"{fNum + secNum}";
        }
        else
        {
            _resaltEqually.text = "0";
        }
    }
    public void Deduct()
    {
        if (int.TryParse(_inputField.text, out int fNum) && int.TryParse(_inputField2.text, out int secNum))
        {
            _resaltEqually.text = $"{fNum - secNum}";
        }
        else
        {
            _resaltEqually.text = "0";
        }
    }

    public void Multiply()
    {
        if (int.TryParse(_inputField.text, out int fNum) && int.TryParse(_inputField2.text, out int secNum))
        {
            _resaltEqually.text = $"{fNum * secNum}";
        }
        else
        {
            _resaltEqually.text = "0";
        }
    }
    public void Divide()
    {
        if (int.TryParse(_inputField.text, out int fNum) && int.TryParse(_inputField2.text, out int secNum))
        {
            _resaltEqually.text = $"{fNum / secNum}";
        }
        else
        {
            _resaltEqually.text = "0";
        }
    }

    public void AC()
    {
        _resaltEqually.text = "";
        _inputField.text = "";
        _inputField2.text = "";
    }
   
    #endregion
}
