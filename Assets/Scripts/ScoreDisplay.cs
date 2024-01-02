using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameUI;
    public TextMeshProUGUI timeUI;

   public void UpdateScore(string playerName, float time)
    {
        playerNameUI.text = playerName;

        //time.ToString() -> transformer le float "time" en string.
        timeUI.text = time.ToString("0.00") + "s";
    }
}
