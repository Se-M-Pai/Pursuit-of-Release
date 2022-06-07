using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private int skinNumber = 0;
    private int inventNumber = 0;

    public void NextLevel()
    {
        StartCoroutine("Sleep");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextSkin()
    {
        if(skinNumber == 7)
        {
            skinNumber = 0;
            PlayerPrefs.SetInt("skinNumber", skinNumber);
            PlayerPrefs.Save();
        } else if (skinNumber >= 0)
        {
            skinNumber += 1;
            PlayerPrefs.SetInt("skinNumber", skinNumber);
            PlayerPrefs.Save();
        }
    }

    public void PreviousSkin()
    {
        if(skinNumber == 0)
        {
            skinNumber = 7;
            PlayerPrefs.SetInt("skinNumber", skinNumber);
            PlayerPrefs.Save();
        } else if(skinNumber <= 7)
        {
            skinNumber -= 1;
            PlayerPrefs.SetInt("skinNumber", skinNumber);
            PlayerPrefs.Save();
        }
    }

    public void NextSkinInventory()
    {
        if (inventNumber == 9)
        {
            inventNumber = 0;
            PlayerPrefs.SetInt("inventNumber", inventNumber);
            PlayerPrefs.Save();
        }
        else if (inventNumber >= 0)
        {
            inventNumber += 1;
            PlayerPrefs.SetInt("inventNumber", inventNumber);
            PlayerPrefs.Save();
        }
    }

    public void PreviousSkinInventory()
    {
        if (inventNumber == 0)
        {
            inventNumber = 9;
            PlayerPrefs.SetInt("inventNumber", inventNumber);
            PlayerPrefs.Save();
        }
        else if (inventNumber <= 9)
        {
            inventNumber -= 1;
            PlayerPrefs.SetInt("inventNumber", inventNumber);
            PlayerPrefs.Save();
        }
    }

    public void QuitButton()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void DeleteCash()
    {
        PlayerPrefs.DeleteAll();
    }
}