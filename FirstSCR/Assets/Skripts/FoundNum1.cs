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
        // Задаём свойству text компонента Text приветственное сообщение
        // Для вывода значений переменных воспользуемся интерполяцией строк
        // имена полей в фигурных скобках будут заменены на их значения
        _messageText.text = $"Загадано число в диапазоне от 1 до 101 включительно";

        // Очищаем поле ввода
        _numberInputField.text = "";

        // Метод Range возвращает случайное число в указанном диапазоне, не включая значение верхней границы, то есть, указав диапазон от 1 до 5, мы получим случайные числа 1, 2, 3 и 4
        _hiddenNumber = Random.Range(1, 101);

        // Присваиваем полю значение true, чтобы сообщить остальной части программы о начале  игры
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
            _messageText.text = "Игра завершена, нажмите рест для начала нововй игры";
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
            _messageText.text = "Не корректный ввод - введите число";
        }
    }

    private void AcceptAnswer(int number)
    {
        if(_hiddenNumber < number)
        {
            _messageText.text = "число муньше чем ...";
        }
        if(_hiddenNumber > number)
        {
            _messageText.text = "число больше чем...";
        }
        else
        {
            _messageText.text = $"Поздравляем число {_hiddenNumber} угадано";
            _isGameStarted = false;
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
