using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WakeUp : MonoBehaviour {

	private Animator anim;
	private OVRPlayerController pc;
	public Text hoverText;
	private OVRScreenFade fade;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		pc = GetComponent<OVRPlayerController> ();
		fade = GetComponentInChildren<OVRScreenFade> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && GameManager.GetState().Equals(State.Wakeup)) {
			Debug.Log("WE DID IT");
			fade.enabled = true;
			StartCoroutine(PlayWakeUp(1.5f));
		}
	}

	IEnumerator PlayWakeUp(float seconds) {
		hoverText.text = "";
		//anim.Play("GetUpFromBed");
		transform.position = new Vector3 (-26.96f, 4.61f, -10.06f);
		transform.rotation = Quaternion.Euler (0, 180, 0);
		yield return new WaitForSeconds (seconds);
		anim.enabled = false;
		pc.enabled = true;

		hoverText.text = "WASD To move";

		bool keyPressed = false;
		while (!keyPressed) {
			if (Input.GetKeyDown(KeyCode.W)) {
				keyPressed = true;
			} else if (Input.GetKeyDown(KeyCode.A)) {
				keyPressed = true;
			} else if (Input.GetKeyDown(KeyCode.S)) {
				keyPressed = true;
			} else if (Input.GetKeyDown(KeyCode.D)) {
				keyPressed = true;
			}
			yield return null;
		}
		hoverText.enabled = false;
	}
}
