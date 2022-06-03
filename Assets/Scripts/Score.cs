using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text[] text;
    int floor = 0;
    int finalscore = 0;
    public Text _finalScore;
    public Inventory inventory;
    
    public void finalScore()
    {
        int score = 0;
        int health = PlayerPrefs.GetInt("_health");
        int inventNumber = PlayerPrefs.GetInt("inventNum");
        int _skin = PlayerPrefs.GetInt("skinNumber");
        int finalscore = PlayerPrefs.GetInt("_finalScore");

        if (_skin == 1) score = 5;
        else if (health == 1) score = 3;
        else if (health == 2) score = 4;
        else score = 5;

        text[floor].text = score.ToString();
        finalscore += score;
        floor++;

        if (floor == 9) _finalScore.text = finalscore.ToString() + " / 50";

        print(floor);
        print(score);

        PlayerPrefs.SetInt("_finalScore", finalscore);
        PlayerPrefs.Save();
    }
}