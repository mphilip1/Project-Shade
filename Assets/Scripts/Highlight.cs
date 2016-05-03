using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highlight : MonoBehaviour {

	public new string name;
	public Shader highlight;
	public Shader def;
	private bool isHighlighted;
	private bool highlighted;
	private Text hoverText;


    public bool Highlighted {
        get { return highlighted; }
        set { highlighted = value; }
    }

	// Use this for initialization
	void Start () {
		highlighted = false;
		isHighlighted = false;
		hoverText = GameObject.FindGameObjectWithTag ("HoverText").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
	}

	void Steve(bool on) {
		foreach(Renderer rend in gameObject.GetComponentsInChildren<Renderer>()) {
			if (!rend.gameObject.CompareTag("HoverText")) {
				rend.material.shader = on ? highlight : def;
				//hoverText.text = on ? "[e] Examine " + name : "";
				isHighlighted = on;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("enter!");
	}

	void OnCollisionExit(Collision collision) {
		Debug.Log ("exit!");
	}

	void LateUpdate() {
		if(!highlighted && isHighlighted) {
			Steve(false);
		} else if(highlighted && !isHighlighted) {
			Steve(true);
		}
		highlighted = false;
	}
}
