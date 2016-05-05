using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class FadeToBlack : MonoBehaviour {
	private ScreenOverlay overlay;

	void Start () {
		overlay = GetComponent<ScreenOverlay> ();
	}


	void OnEnable() {
		GameManager.Instance.OnNewState += OnNewState;
	}
	
	void OnDisable() {
		GameManager.Instance.OnNewState -= OnNewState;
	}
	
	
	void OnNewState(State state) {
		if (state == State.Finale) {
			StartCoroutine(Fade (33));
		} 
	}
	IEnumerator Fade(float seconds) { 
		yield return new WaitForSeconds(seconds);
		float intense = 0;
		while (intense < 10) {
			intense += Time.deltaTime/5;
			overlay.intensity = intense;
			yield return null;

		}

	}
}

