using UnityEngine;
using System.Collections;

public class TurnToSand : MonoBehaviour {

    public ParticleSystem sandSystem;

	// Use this for initialization
	void Start () {
	
	}
//	
//	// Update is called once per frame
//	void Update () {
//	    if (Input.GetKeyDown(KeyCode.P))
//        {
//            print(gameObject.transform.position);
//            gameObject.SetActive(false);
//            sandSystem.Play();
//            
//        }
//	}

	public void ToSand() {
		gameObject.SetActive (false);
		sandSystem.Play ();
	}
}
