using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplicationTable : MonoBehaviour
{
    private int[,] multNum = new int[10, 10];
    [SerializeField] private Text textM1;
    [SerializeField] private Text textM2;

    public void MultTable1()
    {
        int numM = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                numM = (i + 1) * (j + 1);
                multNum[i, j] = numM;

                if (j != 9)
                {
                    Debug.Log($"{i + 1} x {j + 1} = {multNum[i, j]}");
                    textM1.text += $"{i + 1} x {j + 1} = {multNum[i, j]}, \n";
                }
                else
                {
                    Debug.Log($"{i + 1} x {j + 1} = {multNum[i, j]}");
                    textM1.text += $"{i + 1} x {j + 1} = {multNum[i, j]}. \n\n";
                }
            }
        }
    }
    public void MultTable2()
    {
        int numM = 0;
        for (int i = 4; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                numM = (i + 1) * (j + 1);
                multNum[i, j] = numM;

                if (j != 9)
                {
                    Debug.Log($"{i + 1} x {j + 1} = {multNum[i, j]}");
                    textM2.text += $"{i + 1} x {j + 1} = {multNum[i, j]}, \n";
                }
                else
                {
                    Debug.Log($"{i + 1} x {j + 1} = {multNum[i, j]}");
                    textM2.text += $"{i + 1} x {j + 1} = {multNum[i, j]}. \n\n";
                }
            }
        }
    }
}
