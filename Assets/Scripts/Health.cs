﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHearts;

    public Image[] hearts;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < health){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }
        
    }
}
