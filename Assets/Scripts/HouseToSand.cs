﻿using UnityEngine;
using System.Collections;

public class HouseToSand : MonoBehaviour {

    public GameObject container;
    private Collider[] allColliders;
    public GameObject terrain;
    public GameObject roof;

	// Use this for initialization
	void Start () {
        allColliders = container.GetComponentsInChildren<Collider>();
        

    }

	public void Play() {
		StartCoroutine(enableAndWait(25));
	}

    IEnumerator disableObjectsAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    /* Give the terrain time to load so when the house falls, it doesn't lag through it */
    IEnumerator enableAndWait(float seconds)
    {
        terrain.SetActive(true);
        yield return new WaitForSeconds(seconds);
        fallDown();
    }

    public void fallDown()
    {
        // Disable roof first for a better effect
        roof.SetActive(false);
        container.GetComponent<Rigidbody>().isKinematic = false;
        // Disable colliders to allow house to fall through floor
        for (int i = 0; i < allColliders.Length; i++)
        {
            allColliders[i].enabled = false;
        }

		//container.AddComponent<EZCameraShake.CameraShaker>().ShakeOnce(10, 5, .1f, 3.5f);
        Camera.main.gameObject.AddComponent<EZCameraShake.CameraShaker>().ShakeOnce(10, 5, .1f, 3.5f);
        // Enable rigidbody to apply gravity
        
        StartCoroutine(disableObjectsAfterSeconds(container, 1.5f));
    }
}
