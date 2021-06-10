﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    [SerializeField] private GameObject checkPointSign;
    
    [SerializeField]
    GameObject CheckPoint;

    [SerializeField] private AudioClip checkpointSFX;
    
    [SerializeField]
    HealthManager healthManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthManager.lastCheckPointPosition = CheckPoint.transform.position;
            checkPointSign.GetComponent<Animation>().Play();

            StartCoroutine(WaitForBling());

        }
    }


    IEnumerator WaitForBling()
    {
        
        this.GetComponent<AudioSource>().PlayOneShot(checkpointSFX);
        yield return new WaitForSeconds(checkpointSFX.length);
        Destroy(this.gameObject);

    }
}
