﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Put this script on the character camera*/

public class LookAt : MonoBehaviour {

	public GameObject messageBox;
	public AudioSource radioSource;
	public AudioClip phoneChargerClip;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = this.transform.TransformDirection (Vector3.forward);

		if(Physics.SphereCast(this.transform.position, 0.25f, fwd, out hit, 6f)) {
			//Debug.Log ("raycast hit: " + hit.collider.gameObject.name);
			GameObject go = hit.collider.gameObject;
			Item item = go.GetComponent<Item>();
			if(item != null) {
				//Debug.Log("CAN INTERACT: " + item.CanExamine());
				if (item.CanExamine()) {
					//Debug.Log ("object has item");
					go.GetComponent<Highlight> ().Highlighted = true;

					if (Input.GetKeyDown (KeyCode.E)) {
						messageBox.GetComponent<DisplayMessageBox> ().Interact (go.GetComponent<Item>());
						GetComponentInParent<OVRPlayerController>().SetHaltUpdateMovement(true);
					}
				} else if (item.CanInteract ()) {
					//highlight, check for input e, then turn to sand
					go.GetComponent<Highlight> ().Highlighted = true;

					if (Input.GetKeyDown (KeyCode.E)) {
						//GREG turn to sand
						TurnToSand toSand = go.GetComponent<TurnToSand>();
						if (toSand != null) {
							GameManager.Instance.NextState ();
							toSand.ToSand();
						} else if (go.CompareTag("Phone Charger")){
							//phone charger packed
							go.SetActive(false);
							GameManager.Instance.HappyEnding = true;
							radioSource.clip = phoneChargerClip;
							radioSource.Play ();
						}
					}
				}
			}
		}
	}	
}
