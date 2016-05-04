using UnityEngine;
using System.Collections;

public class PlaySoundEffects : MonoBehaviour {

	public AudioClip[] clips;
	private AudioSource audioSource;
	
	void Start() {
		audioSource = GetComponent<AudioSource> ();
//		audioSource.clip = clips [0];
//		audioSource.Play ();
	}
	
	// Use this for initialization
	void OnEnable() {
		GameManager.Instance.OnNewState += OnNewState;
	}
	
	void OnDisable() {
		GameManager.Instance.OnNewState -= OnNewState;
	}
	
	void OnNewState(State state) {
		if (state == State.PlaneTicket1) {
			audioSource.clip = clips[0];
			audioSource.volume = .25f;
			audioSource.Play();
		} else if (state == State.Finale) {
			audioSource.Play();
			if (!GameManager.Instance.HappyEnding) {
				Debug.Log ("Not happy");
			} else {
				audioSource.volume = 1;

				Debug.Log("Happy");
			}


		} 
	}

	IEnumerator ReduceAudioSound() {
		float timer = clips[0].length;

		while (timer > 0) {
			timer -= Time.deltaTime;
			audioSource.volume -= Time.deltaTime/5;
			yield return null;
		}
	}
}
