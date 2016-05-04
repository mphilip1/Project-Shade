using UnityEngine;
using System.Collections;

public class ShowSandPile : MonoBehaviour {

	// 0 = center
	// 1 = closet
	// 2 = kitchen
	// 3 = kitchen2
	public GameObject[] sandPiles;
	
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
		if (state == State.PlaneTicket2) {
			ShowSand(0);
		} else if (state == State.Snack) {
			// Kitchen
			ShowSand(2);
			ShowSand(3);
		} else if (state == State.Closet) {
			// Closet
			ShowSand(1);
		}
	}

	void ShowSand(int idx) {
//		for (int i = 0; i < sandPiles.Length; i++) {
//			sandPiles[i].SetActive(false);
//		}
		sandPiles[idx].SetActive (true);
	}
}
