using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text DisplayScore;
    public static int PlayerScore = 0;

    private void Update()
    {
        DisplayScore.text = "Score: " + PlayerScore.ToString();
    }
}
