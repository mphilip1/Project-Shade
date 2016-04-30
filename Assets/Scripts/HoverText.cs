using UnityEngine;
using System.Collections;

public class HoverText : MonoBehaviour {

	public Camera mainCamera;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
	}
}
