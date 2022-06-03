using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 pos;
    private float speed = 2.0f;

    public PlayerController player;
    public Disappearing disApp;

    public float time = 3.0f;
    public float _timeLeft = 0f;

    private void Start()
    {
        pos = new Vector3(15f, 0f, -10f);
    }
    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if(transform.position.x < 15f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
            if (transform.position.x >= 10f)
            {
                speed -= 0.0075f;
            }
        }
        if (transform.position.x == 15f && transform.position.y == 0f)
        {
            transform.position = transform.position + new Vector3(0.001f, 0f, 0f);
            speed = 1.0f;
            _timeLeft = time;
            StartCoroutine(StartTimer());

            disApp.SwitchBool();
        }
        if (_timeLeft < 0 && transform.position.y == 0f)
        {
            transform.position = new Vector3(20f, 15f, -10f);
            player.StartPos();
            disApp.SwitchBool();
        }
    }

    public void NextLevelCamera()
    {
        if (transform.position.y != 150f) transform.position = transform.position + new Vector3(0f, 15f, 0f);
        else if (transform.position == new Vector3(20f, 150f, -10f)) print("Camera work");
    }

    public IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            yield return null;
        }
    }
}