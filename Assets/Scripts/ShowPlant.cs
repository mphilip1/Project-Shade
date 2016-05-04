using UnityEngine;
using System.Collections;

public class ShowPlant : MonoBehaviour {

	public GameObject[] plants;

	// Use this for initialization
	void Start () {
		//plants = GetComponentsInChildren<GameObject> ();
	}

	void OnEnable() {
		GameManager.Instance.OnNewState += OnNewState;
	}

	void OnDisable() {
		GameManager.Instance.OnNewState -= OnNewState;
	}


	void OnNewState(State state) {
		if (state == State.PlaneTicket1) {
			DisplayPlant (1);
		} else if (state == State.PlaneTicket3) {
			DisplayPlant (0);
		} else if (state == State.Closet) {
			DisplayPlant (2);
		} else if (state == State.Stove) {
			// Disable and turn to sand
		}
	}

	public void DisplayPlant(int idx) {
		for (int i = 0; i < plants.Length; i++) {
			plants[i].SetActive(false);
		}
		plants [idx].SetActive (true);
	}
}
