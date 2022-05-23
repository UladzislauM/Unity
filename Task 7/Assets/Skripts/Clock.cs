using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private bool tick;

    private Image _img;
    private float _currectTime;

    private void Start()
    {
        _img = GetComponent<Image>();
        _currectTime = _maxTime;
    }


    private void Update()
    {
        tick = false;
        _currectTime -= Time.deltaTime;

        TickCheck();
        
        _img.fillAmount = _currectTime / _maxTime;
    }

    public bool TickCheck ()
    {
        if (_currectTime <= 0)
        {
            tick = true;
            _currectTime = _maxTime;
        }
        return tick;
    }

    public float maxTime { get { return this._maxTime; } }
    public float currectTime { get { return this._currectTime; } set {this._currectTime = value; } }

}
