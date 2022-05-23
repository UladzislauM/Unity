using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cycleScR : MonoBehaviour
{
   private int[] evenNum = new int[5];
   [SerializeField] private Text text;

    public void FillEvenNum()
    {
        int check = 0;
        for (int i = 1; i < 11; i++)
        {
            if (i % 2 == 0)
            {
                evenNum[check] = i;
                Debug.Log(evenNum[check]);
                text.text += $"{evenNum[check]}";
                if (check != 4)
                { 
                    text.text += $", "; 
                }
                else
                {
                    text.text += $". ";
                }
                    check++;
            }
        }
    }
}
