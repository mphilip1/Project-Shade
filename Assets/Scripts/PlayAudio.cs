using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	public AudioClip[] clips;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = clips [0];
		audioSource.Play ();
	}

	// Use this for initialization
	void OnEnable() {
		GameManager.Instance.OnNewState += OnNewState;
	}
	
	void OnDisable() {
		GameManager.Instance.OnNewState -= OnNewState;
	}

	void OnNewState(State state) {
		if (state == State.PlaneTicket3) {
			audioSource.clip = clips[1];
			audioSource.Play();
		} else if (state == State.Snack) {
			audioSource.clip = clips[2];
			audioSource.Play();
		} else if (state == State.Finale) {
			if (GameManager.Instance.HappyEnding) {
				//helicopter gets louder, good ending radio audio plays, screen fades to black
				audioSource.clip = clips[4];
			} else {
				//helicopter comes and goes, screen fades to black
				audioSource.clip = clips[3];
			}
			StartCoroutine(PlayDelayedAudio());
		} 
	}

	IEnumerator PlayDelayedAudio() {
		yield return new WaitForSeconds (20);
		audioSource.Play ();
	}
}
