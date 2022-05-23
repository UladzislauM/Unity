using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResControl : MonoBehaviour
{
    [SerializeField] private Text resurseText;

    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int iron;
    [SerializeField] private int gold;
    [SerializeField] private List<GameObject> _units;
    private int population;

    public List<GameObject> units { get { return _units; } set { _units = value; } }

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateResurses();
    }

    private void UpdateResurses()
    {
        population = _units.Count;
        resurseText.text = "Wood :" + wood + " Stone: " + stone + " Iron: " + iron +" Gold: " + gold + "    |   popul: " + population;
    }

    public void NewUnit(GameObject unit)
    {
        _units.Add(unit);
    }
}
