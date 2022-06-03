using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] skin;
    public GameObject[] _raccoonNum;
    public GameObject[] _inhalerNum;
    public GameObject[] _aiButton;
    public GameObject[] _antiHate;
    public GameObject[] _studak;
    public GameObject[] _paper;

    public Score scoreScript;
    public GameController gameController;
    public PlayerController _playerController;

    public void FixedUpdate()
    {
        int _skin = PlayerPrefs.GetInt("inventNumber");
        for (int i = 0; i <= 9; i++)
        {
            skin[i].SetActive(false);
        }
        skin[_skin].SetActive(true);
    }

    public void InhalerOn()                                                     // Inhaler
    {
        for(int i = 0; i < 8; i++)
        {
            _inhalerNum[i].SetActive(true);
        }
    }
    public void InhalerOff()
    {
        for (int i = 0; i < 8; i++)
        {
            _inhalerNum[i].SetActive(false);
        }
    }

    public void RaccoonOn()                                                     // Raccoon
    {
        for (int i = 0; i < 9; i++)
        {
            _raccoonNum[i].SetActive(true);
        }
    }

    public void RaccoonOff()
    {
        for (int i = 0; i < 9; i++)
        {
            _raccoonNum[i].SetActive(false);
        }
    }
    public void AIOn()                                                          // Masha
    {
        for (int i = 0; i < 9; i++)
        {
            _aiButton[i].SetActive(true);
        }
    }

    public void AIOff()
    {
        for (int i = 0; i < 9; i++)
        {
            _aiButton[i].SetActive(false);
        }
    }

    public void antiHateOn()                                                    // Senya
    {
        for (int i = 0; i < 9; i++)
        {
            _antiHate[i].SetActive(true);
        }
    }

    public void antiHateOff()
    {
        for (int i = 0; i < 9; i++)
        {
            _antiHate[i].SetActive(false);
        }
    }

    public void studOn()                                                    // Student Card
    {
        for (int i = 0; i < 9; i++)
        {
            _studak[i].SetActive(true);
        }
    }

    public void studOff()
    {
        for (int i = 0; i < 9; i++)
        {
            _studak[i].SetActive(false);
        }
    }

    public void paperOn()                                                    // Student Card
    {
        for (int i = 0; i < 9; i++)
        {
            _paper[i].SetActive(true);
        }
    }

    public void paperOff()
    {
        for (int i = 0; i < 9; i++)
        {
            _paper[i].SetActive(false);
        }
    }

    public void Zlatoust()                                                      // Zlatoust
    {
        int _skin = PlayerPrefs.GetInt("inventNumber");
        int randN = Random.Range(0, 10);
        _skin = randN;
        if (_skin == 7) InhalerOn();
        else if (_skin == 2) RaccoonOn();
        PlayerPrefs.SetInt("inventNumber", _skin);
        PlayerPrefs.Save();
    }

    public void _Heal()
    {
        _playerController.Heal();
    }

    public void Fox()                                                           // Fox
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        int health = PlayerPrefs.GetInt("_health");
        int usePet = PlayerPrefs.GetInt("_usePet");

        if(usePet > 0)
        {
            scoreScript.finalScore();
            health = 3;
            if (_skin == 3) health = 4;
            usePet--;
            if (usePet == 0) gameObject.SetActive(false);
            gameController.NextLevel();
        }

        PlayerPrefs.SetInt("_usePet", usePet);
        PlayerPrefs.SetInt("_health", health);
        PlayerPrefs.Save();
    }

    public void Panda()
    {
        int _finalscore = PlayerPrefs.GetInt("finalscore");
        _finalscore += 25;
        PlayerPrefs.SetInt("finalscore", _finalscore);
        PlayerPrefs.Save();
    }
}