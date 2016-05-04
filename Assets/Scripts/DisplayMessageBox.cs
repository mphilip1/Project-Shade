using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMessageBox : MonoBehaviour {

	public Text messageBoxText;
	private float characterDelay = 0.065f;
	public GameObject playerController;
	private OVRPlayerController ovrpc;
	private bool talking;
	private Item lastItem;

	string message;

	void Start() {
		ovrpc = playerController.GetComponent<OVRPlayerController> ();
	}

	public void Interact (Item item) {
		talking = true;
		this.gameObject.SetActive (true);
		this.message = item.Examine();
		StopAllCoroutines ();
		StartCoroutine (TypeMessage());
		lastItem = item;
	}

	IEnumerator TypeMessage() {
		messageBoxText.text = "";

		foreach(char c in this.message) {
			yield return new WaitForSeconds (characterDelay);
			messageBoxText.text += c;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && talking) {
			this.gameObject.SetActive (false);
			ovrpc.SetHaltUpdateMovement(false);
			talking = false;
			lastItem.IncrementText();
		}
	}
}
