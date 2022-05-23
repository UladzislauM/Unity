using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoundNum1 : MonoBehaviour
{
   
    [SerializeField] private Text _messageText;
    [SerializeField] private InputField _numberInputField;
    private int _hiddenNumber;
    private bool _isGameStarted;

    private void Restart()
    {
        // ����� �������� text ���������� Text �������������� ���������
        // ��� ������ �������� ���������� ������������� ������������� �����
        // ����� ����� � �������� ������� ����� �������� �� �� ��������
        _messageText.text = $"�������� ����� � ��������� �� 1 �� 101 ������������";

        // ������� ���� �����
        _numberInputField.text = "";

        // ����� Range ���������� ��������� ����� � ��������� ���������, �� ������� �������� ������� �������, �� ����, ������ �������� �� 1 �� 5, �� ������� ��������� ����� 1, 2, 3 � 4
        _hiddenNumber = Random.Range(1, 101);

        // ����������� ���� �������� true, ����� �������� ��������� ����� ��������� � ������  ����
        _isGameStarted = true;
    }

    void Start()
    {
        Restart();
    }

   public void OnClickRest ()
    {
        Restart();
    }

    public void OnCkickAnsw()
    {
        if (_isGameStarted)
        {
            ParseAnsver();
        }
        else
        {
            _messageText.text = "���� ���������, ������� ���� ��� ������ ������ ����";
        }
        _numberInputField.text = "";
    }

    private void ParseAnsver()
    {
        bool isSuccess = int.TryParse(_numberInputField.text, out int number);
        if(isSuccess)
        {
            AcceptAnswer(number);
        }
        else
        {
            _messageText.text = "�� ���������� ���� - ������� �����";
        }
    }

    private void AcceptAnswer(int number)
    {
        if(_hiddenNumber < number)
        {
            _messageText.text = "����� ������ ��� ...";
        }
        if(_hiddenNumber > number)
        {
            _messageText.text = "����� ������ ���...";
        }
        else
        {
            _messageText.text = $"����������� ����� {_hiddenNumber} �������";
            _isGameStarted = false;
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
