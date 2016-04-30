using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highlight : MonoBehaviour {

	public Shader highlight;
	public Shader def;
	private bool isHighlighted;
	public TextMesh hoverText;
	Renderer rend;

    public bool IsHighlighted {
        get { return isHighlighted; }
        set { isHighlighted = value; }
    }

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		isHighlighted = false;
	}

	// Update is called once per frame
	void Update () {
	}

	void LateUpdate() {
		if(!isHighlighted) {
			rend.material.shader = def;
			hoverText.gameObject.SetActive (false);
		} else {
			rend.material.shader = highlight;
			hoverText.gameObject.SetActive (true);
		}
		isHighlighted = false;
	}
}
