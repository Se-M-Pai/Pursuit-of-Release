using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector3 pos;
    public GameObject[] skin;
    public GameObject _inventory;
    public GameObject _diplom;
    public GameObject _failEnd;
    public GameObject _pauseButton;

    private int usePet;
    private int lives;
    //public Text fText;

    public Inventory _invScript;

    [SerializeField] private int health;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;
    [SerializeField] private Sprite extraHeart;

    public void StartPos()
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        int _invent = PlayerPrefs.GetInt("inventNumber");

        if (_skin == 3) lives = 4;                                  // Kirill
        else if (_skin == 1) lives = 1;                             // AB
        else lives = 3;

        transform.position = new Vector3(15f, 11f, 0f);
        health = lives;
        PlayerPrefs.SetInt("_health", health);

        _inventory.SetActive(true);
        _pauseButton.SetActive(true);

        if (_invent == 7) _invScript.InhalerOn();
        if (_invent == 2) _invScript.RaccoonOn();
        if (_invent == 9) _invScript.studOn();
        if (_invent == 8) _invScript.paperOn();
        if (_skin == 5) _invScript.AIOn();
        if (_skin == 7) _invScript.antiHateOn();


        if (_skin == 0) usePet = 2;                                 // AK
        else usePet = 1;
        PlayerPrefs.SetInt("_usePet", usePet);

        PlayerPrefs.Save();
    }

    public void NextLevelPlayer()
    {
        if (transform.position.y != 146f) 
        {
            transform.position = transform.position + new Vector3(0f, 15f, 0f);
        }
        else if (transform.position == new Vector3(15f, 146, 0f))
        {
            _diplom.SetActive(true);
        }
    }

    public void FixedUpdate()
    {
        int _skin = PlayerPrefs.GetInt("skinNumber");
        health = PlayerPrefs.GetInt("_health");

        if (health == 0 && transform.position.y > 5f ) _failEnd.SetActive(true);
        if (health > lives) health = lives;

        for (int i = 0; i <= 7; i++)
        {
            skin[i].SetActive(false);
        }
        skin[_skin].SetActive(true);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) hearts[i].sprite = aliveHeart;
            else hearts[i].sprite = deadHeart;
            if (health == 4) hearts[3].sprite = extraHeart;
            if (i < lives) hearts[i].enabled = true;
            else hearts[i].enabled = false;
        }
    }

    public void Heal()
    {
        health = PlayerPrefs.GetInt("_health");
        health++;
        PlayerPrefs.SetInt("_health", health);
    }
}