using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool isClick = false;
    private ManHanging _manHanging;
    void Start()
    {
        _manHanging = FindObjectOfType<ManHanging>();
    }

    private void OnMouseDown()
    {
        if (!isClick && !_manHanging.isGameOver)
        {
            _manHanging.CheckRightLetter(this.name);
            isClick = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f,0.7f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
