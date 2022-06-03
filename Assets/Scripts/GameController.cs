using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Disappearing disApp;
    public Camera _camera;
    public PlayerController player;

    public void NextLevel()
    {
        disApp.SwitchBool();
        StartCoroutine("NextLevelSleep");
    }

    IEnumerator NextLevelSleep()
    {
        yield return new WaitForSeconds(3);
        _camera.NextLevelCamera();
        player.NextLevelPlayer();
        disApp.SwitchBool();
    }
}