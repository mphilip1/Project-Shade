using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMessageBox : MonoBehaviour {

	public Text messageBoxText;
	public float characterDelay = 0.1f;

	string message;

	public void Interact (string messageIn) {
		this.gameObject.SetActive (true);
		this.message = messageIn;
		StopAllCoroutines ();
		StartCoroutine (TypeMessage());
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
		if (Input.GetKeyDown(KeyCode.Return)) {
			this.gameObject.SetActive (false);
		}
	}
}
