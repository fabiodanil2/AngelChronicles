﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockingTimer : MonoBehaviour
{
    // Start is called before the first frame update

    
    public bool doesDamageToPlayer;


    [SerializeField] private float timeShocking;

    private float timeUntilNextShock;


    IEnumerator ItsShockingTime()
    {
        doesDamageToPlayer = true;
        yield return new WaitForSeconds(timeShocking);
        doesDamageToPlayer = false;
    }

    private void Update()
    {
        if (timeUntilNextShock <= timeShocking && !doesDamageToPlayer)
            timeUntilNextShock += Time.deltaTime;
        else
        {
            StartCoroutine(ItsShockingTime());
            timeUntilNextShock = 0f;
        }
    }
}
