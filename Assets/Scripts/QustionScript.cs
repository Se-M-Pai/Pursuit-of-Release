using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QustionScript : MonoBehaviour
{
    public QuestionList[] questions;
    public Text qText;
    public Text[] answersText;
    public Text[] _ai;
    public Image[] _antiHate;
    public Image[] _raccoon;
    public GameObject[] _inhaler;

    [SerializeField] private Sprite _Kashtanova;
    [SerializeField] private Sprite _Zusman;
    [SerializeField] private Sprite _Krasnenko;
    [SerializeField] private Sprite paper;

    public Inventory inventory;
    public Score scoreScript;
    public GameController gameController;

    List<object> qList;
    QuestionList crntQ;

    int randQ;
    int health;
    int score = 0;
    int _useAI = 0;
    //int finalScr = 0;

    public void Start()
    {
        OnLevelStart();
    }

    public void OnLevelStart()
    {
        qList = new List<object>(questions);
        questionGenerate();
    }

    void questionGenerate()
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        if(qList.Count > 0)
        {
            if(_antiHate.Length > 0 && _skin == 7)
            {
                for (int k = 0; k < 4; k++)
                {
                    _antiHate[k].enabled = false;
                }
                int randOn = Random.Range(0, 3);
                if (randOn == 1) inventory.antiHateOn();
            }

            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
    }

    public void answersButtons(int index)
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        health = PlayerPrefs.GetInt("_health");
        if (answersText[index].text.ToString() == crntQ.answers[0])
        {
            if(_skin == 6)                                                      // Ortem
            {
                int randNum = Random.Range(0, 5);
                if (randNum == 1) score = 2;
            }
            score++;
            if (score == 3)
            {
                scoreScript.finalScore();
                gameController.NextLevel();
                health = 3;
                if (_skin == 1) health = 1;
                else if (_skin == 3) health = 4;                                // Kirill
            }
            print(score);
        }
        else if (_skin == 4)                                                    // Misha
        {
            int randNum = Random.Range(0, 5);
            health--;
            if (randNum == 1)
            {
                score++;
                health++;
                if (score == 3)
                {
                    scoreScript.finalScore();
                    gameController.NextLevel();
                    health = 3;
                }
            }
        }
        else
        {
            health--;
        }

        PlayerPrefs.SetInt("_health", health);
        PlayerPrefs.Save();
        qList.RemoveAt(randQ);
        questionGenerate();
    }

    public void antiHate()                                                      // Senya
    {
        int _hateRand = Random.Range(0, 4);
        if (answersText[_hateRand].text.ToString() == crntQ.answers[0])
        {
            int _helpSkin = Random.Range(0, 2);
            _antiHate[_hateRand].enabled = true;
            if (_helpSkin == 1) _antiHate[_hateRand].sprite = _Kashtanova;
            else _antiHate[_hateRand].sprite = _Krasnenko;
        }
        else
        {
            int _helpSkin = Random.Range(0, 2);
            _antiHate[_hateRand].enabled = true;
            if (_helpSkin == 1) _antiHate[_hateRand].sprite = _Zusman;
            else _antiHate[_hateRand].sprite = _Krasnenko;
        }

        inventory.antiHateOff();
    }

    public void AI()                                                            // Masha
    {
        _useAI = PlayerPrefs.GetInt("useAI", _useAI);

        if (_useAI < 10)
        {
            for (int i = 0; i < 4; i++)
            {
                if (answersText[i].text.ToString() == crntQ.answers[0])
                {
                    int helpRate = Random.Range(40, 80);
                    string _helpRate = helpRate.ToString();
                    _ai[i].text = _helpRate;
                    _ai[i].enabled = true;
                }
                else
                {
                    int helpRate = Random.Range(20, 60);
                    string _helpRate = helpRate.ToString();
                    _ai[i].text = _helpRate;
                    _ai[i].enabled = true;
                }
            }
            inventory.AIOn();
        }
        else
        {
            inventory.AIOff();
            _useAI = 0;
        }
        print(_useAI);
        _useAI++;
        PlayerPrefs.SetInt("useAI", _useAI);
        PlayerPrefs.Save();
    }

    public void Raccoon()                                                       // Raccoon
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        int usePet = PlayerPrefs.GetInt("_usePet");

        if(usePet > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (answersText[i].text.ToString() == crntQ.answers[0])
                {
                    _raccoon[i].gameObject.SetActive(true);
                }
            }
            usePet--;
            if(usePet == 0) inventory.RaccoonOff();
        }

        PlayerPrefs.SetInt("_usePet", usePet);
    }

    public void Inhaler()                                                       // Inhaler
    {
        for (int i = 0; i <= 1; i++)
        {
            int t = Random.Range(0, 4);
            _inhaler[t].SetActive(true);
        }
    }

    public void StudentCard()                                                   // Student Card
    {
        score++;
            if (score == 3)
            {
                scoreScript.finalScore();
                gameController.NextLevel();
            }
            print(score);
        qList.RemoveAt(randQ);
        questionGenerate();
    }



    public void Paper()                                                        // Paper
    {
        for (int i = 0; i < 4; i++)
        {
            if (answersText[i].text.ToString() == crntQ.answers[0])
            {
                    _raccoon[i].gameObject.SetActive(true);
                    _raccoon[i].sprite = paper;
            }
        }
    }

    public void FixedUpdate()
    {
        if(_raccoon.Length != 0)
        {
            for (int i = 0; i < 4; i++)                                         // Raccoon
            {
                if (answersText[i].text.ToString() == crntQ.answers[0]) _raccoon[i].enabled = true;
                else _raccoon[i].enabled = false;
            }
        }
    }
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}