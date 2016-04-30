using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Put this script on the character camera*/

public class LookAt : MonoBehaviour {

	public GameObject messageBox;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = this.transform.TransformDirection (Vector3.forward);

		if(Physics.Raycast(this.transform.position, fwd, out hit, 4f)) {
			GameObject go = hit.collider.gameObject;
			if(go.GetComponent<Item>() != null && go.GetComponent<Item>().CanExamine() ) {
				go.GetComponent<Highlight> ().isHighlighted = true;

				if (Input.GetKeyDown (KeyCode.E)) {
					messageBox.GetComponent<DisplayMessageBox> ().Interact (go.GetComponent<Item>().Examine());
				}
			}
		}
	}

	void FixedUpdate () {

	}
	void LateUpdate() {
	}
}
