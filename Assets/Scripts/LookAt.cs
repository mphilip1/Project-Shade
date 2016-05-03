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

		if(Physics.Raycast(this.transform.position, fwd, out hit, 6f)) {
			//Debug.Log ("raycast hit: " + hit.collider.gameObject.name);
			GameObject go = hit.collider.gameObject;
			Item item = go.GetComponent<Item>();
			if(item != null) {
				//Debug.Log("CAN INTERACT: " + item.CanExamine());
				if (item.CanExamine()) {
					//Debug.Log ("object has item");
					go.GetComponent<Highlight> ().Highlighted = true;

					if (Input.GetKeyDown (KeyCode.E)) {
						messageBox.GetComponent<DisplayMessageBox> ().Interact (go.GetComponent<Item>().Examine());
						GetComponentInParent<OVRPlayerController>().SetHaltUpdateMovement(true);
					}
				}
			}
		}
	}

	void FixedUpdate () {

	}
	void LateUpdate() {
	}
}
