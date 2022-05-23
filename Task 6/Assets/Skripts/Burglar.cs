using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burglar : MonoBehaviour
{
    #region Pins
    [SerializeField] private int _pin1;
    [SerializeField] private Text _pin1Text;
    [SerializeField] private int _pin2;
    [SerializeField] private Text _pin2Text;
    [SerializeField] private int _pin3;
    [SerializeField] private Text _pin3Text;
    private int _savePin1;
    private int _savePin2;
    private int _savePin3;
    #endregion
    #region Tools
    [SerializeField] private int _toolDrill_1;
    [SerializeField] private int _toolDrill_2;
    [SerializeField] private int _toolDrill_3;
    [SerializeField] private Text _toolDrillText;
    [SerializeField] private int _toolMasterKey_1;
    [SerializeField] private int _toolMasterKey_2;
    [SerializeField] private int _toolMasterKey_3;
    [SerializeField] private Text _toolMasterKeyText;
    [SerializeField] private int _toolHummer_1;
    [SerializeField] private int _toolHummer_2;
    [SerializeField] private int _toolHummer_3;
    [SerializeField] private Text _toolHummerText;
    [SerializeField] private int _toolcuttingMachine_1;
    [SerializeField] private int _toolcuttingMachine_2;
    [SerializeField] private int _toolcuttingMachine_3;
    [SerializeField] private Text _toolcuttingMachineText;
    [SerializeField] private int _toolchisel_1;
    [SerializeField] private int _toolchisel_2;
    [SerializeField] private int _toolchisel_3;
    [SerializeField] private Text _toolchiselText;
    #endregion
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _gameOverWin;
    [SerializeField] private GameObject _gameOverLose;
    [SerializeField] private GameObject _masterKey;
    [SerializeField] private GameObject _drill;
    [SerializeField] private GameObject _hummer;
    [SerializeField] private GameObject _cuttingMachine;
    [SerializeField] private GameObject _chisel;
    [SerializeField] private float _timerStart;
    [SerializeField] private int _winPin;
    private float _currectTime = 0f;
    private bool _gameOver = false;
    [SerializeField] private GameObject _failText;
    private float _timeX;

    void Start()
    {
        PinToCanvas(_pin1, _pin2, _pin3);

        _toolDrillText.text = $"{_toolDrill_1}|{_toolDrill_2}|{_toolDrill_3}\n{_drill.name}";
        _toolMasterKeyText.text = $"{_toolMasterKey_1}|{_toolMasterKey_2}|{_toolMasterKey_3}\n{_masterKey.name}";
        _toolHummerText.text = $"{_toolHummer_1}|{_toolHummer_2}|{_toolHummer_3}\n{_hummer.name}";
        _toolcuttingMachineText.text = $"{_toolcuttingMachine_1}|{_toolcuttingMachine_2}|{_toolcuttingMachine_3}\n{_cuttingMachine.name}";
        _toolchiselText.text = $"{_toolchisel_1}|{_toolchisel_2}|{_toolchisel_3}\n{_chisel.name}";

        _savePin1 = _pin1;
        _savePin2 = _pin2;
        _savePin3 = _pin3;
    }
   public void NewGameButton()
    {
        _currectTime = _timerStart;
        _gameOver = true;
    }
    public void EndGameButton ()
    {
        _gameOver = false;
    }
    void Update()
    {
        if (_gameOver)
        {
                _currectTime -= Time.deltaTime;
                UpdateTimeText();
            Debug.Log(_currectTime);

            if (Mathf.Round(_currectTime) == Mathf.Round(_timeX) - 4f)
            {
                _failText.SetActive(false);
            }
            if (_pin1 == _winPin && _pin2 == _winPin && _pin3 == _winPin)
            {
                _gameOverWin.SetActive(true);
            }
            if (_currectTime <= 0f)
            {
                _currectTime = _timerStart;
                TimeMashine();
            }
            
        }
    }

    private void UpdateTimeText()
    {
        if (_currectTime < 0)
            _currectTime = 0;

        float seconds = Mathf.FloorToInt(_currectTime % 60);
        _timerText.text = string.Format("{00}", seconds);
    }
    public void TimeMashine()
    {
            _gameOver = false;
            _gameOverLose.SetActive(true);
    }
    private void PinToCanvas(int pin1, int pin2, int pin3)
    {
        _pin1Text.text = pin1.ToString();
        _pin2Text.text = pin2.ToString();
        _pin3Text.text = pin3.ToString();

        _pin1 = pin1;
        _pin2 = pin2;
        _pin3 = pin3;
    }
   // private string ToolsToCanvas(int tool1_1, int tool1_2,
   //int tool1_3, GameObject tool)
   // {
   //     string text;
   //     text = $"{tool1_1}|{tool1_2}|{tool1_3}\n {tool.name}";
   //     return text;
   // }

    public void Button1()
    {
        GameMetod(_pin1, _pin2, _pin3, _toolDrill_1, _toolDrill_2, _toolDrill_3);
    }
    public void Button2()
    {
        GameMetod(_pin1, _pin2, _pin3, _toolMasterKey_1, _toolMasterKey_2, _toolMasterKey_3);
    }
    public void Button3()
    {
        GameMetod(_pin1, _pin2, _pin3, _toolHummer_1, _toolHummer_2, _toolHummer_3);
    }
    public void Button4()
    {
        GameMetod(_pin1, _pin2, _pin3, _toolcuttingMachine_1, _toolcuttingMachine_2, _toolcuttingMachine_3);
    }
    public void Button5()
    {
        GameMetod(_pin1, _pin2, _pin3, _toolchisel_1, _toolchisel_2, _toolchisel_3);
    }

    public void GameMetod(int pin1, int pin2, int pin3, int tool1, int tool2, int tool3)
    {
        _timeX = _currectTime;
        pin1 += tool1;
        pin2 += tool2;
        pin3 += tool3;
        PinToCanvas(pin1, pin2, pin3);
        if (pin1 > 10 || pin2 > 10 || pin3 > 10)
        {
            pin1 -= tool1;
            pin2 -= tool2;
            pin3 -= tool3;
            PinToCanvas(pin1, pin2, pin3);
            _failText.SetActive(true);
        }
        if (pin1 < 0 || pin2 < 0 || pin3 < 0)
        {
            pin1 -= tool1;
            pin2 -= tool2;
            pin3 -= tool3;
            PinToCanvas(pin1, pin2, pin3);
            _failText.SetActive(true);
        }
    }

    public void Reset()
    {
        _gameOver = true;
        _currectTime = _timerStart;
        _pin1 = _savePin1;
        _pin2 = _savePin2;
        _pin3 = _savePin3;
        PinToCanvas(_pin1, _pin2, _pin3);
    }
}