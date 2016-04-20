using UnityEngine;
using System.Collections;

public class EnableCamera : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        print(Camera.main);
        print(Camera.allCameras.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
