using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearing : MonoBehaviour
{
    Color _color;
    public float step = 1;
    float curAlpha = 1.0f;
    bool isDisappearing;
    bool isAppearing;
    Renderer _renderer;

    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
        curAlpha = _renderer.material.color.a;
    }

    public void Update()
    {
        if (isDisappearing)
        {
            if(curAlpha >= 0f)
            {
                curAlpha -= Time.deltaTime / 3;
                _color.a = curAlpha;
                _renderer.material.color = _color;
            }
        }
        if (isAppearing)
        {
            if(curAlpha <= 1f)
            {
                curAlpha += Time.deltaTime / 3;
                _color.a = curAlpha;
                _renderer.material.color = _color;
            }
        }
    }

    public void OnCollisionEnter2D()
    {
        isDisappearing = true;
        isAppearing = false;
    }

    public void SwitchBool()
    {
        if(isDisappearing == true)
        {
            isDisappearing = false;
        } else
        {
            isDisappearing = true;
        }
        if(isAppearing == true)
        {
            isAppearing = false;
        } else
        {
            isAppearing = true;
        }
    }
}