using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public ScoreDisplay[] scoreDisplays = new ScoreDisplay[3];

    // Start is called before the first frame update
    void Start()
    {
        string[] scoreNames = PlayerPrefsX.GetStringArray("scoreNames");

        float[] scoreTimes = PlayerPrefsX.GetFloatArray("scoreTimes");

        int minLength = Mathf.Min(scoreDisplays.Length, scoreNames.Length, scoreTimes.Length);

        Debug.Log(scoreNames.Length);

        //i -> index
        for (int i = 0; i < minLength; i++)
        {
            //�a recup�re le scoreDisplay � la case i, le mets � jour avec les valeurs scoreNames et scoreTimes .
            //ce qu'il y a dans les crochets ( [] ) correspond � la case du tableau qu'on va r�cuperer.
            scoreDisplays[i].UpdateScore(scoreNames[i], scoreTimes[i]);
        }

    }

}
