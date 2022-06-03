using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //[SerializeField] private float time;
    public float time = 3.0f;

    public float _timeLeft = 0f;

    public IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            yield return null;
            //Debug.Log(_timeLeft);
        }
    }

    public void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
}