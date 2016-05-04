using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WhiteboardController : MonoBehaviour {

	[SerializeField]
	private Text text;
	[SerializeField]
	private Toggle toggle;

	[SerializeField]
	private Text text2;
	[SerializeField]
	private Toggle toggle2;

	[SerializeField]
	private Text text3;
	[SerializeField]
	private Toggle toggle3;

	[SerializeField]
	private Text text4;
	[SerializeField]
	private Toggle toggle4;

	void OnEnable()
	{
		GameManager.Instance.OnNewState += OnFindingPlaneTickets;
		GameManager.Instance.OnNewState += OnSnack;
		GameManager.Instance.OnNewState += OnCloset;
		GameManager.Instance.OnNewState += OnStove;
	}
	
	void OnDisable()
	{
		GameManager.Instance.OnNewState -= OnFindingPlaneTickets;
		GameManager.Instance.OnNewState -= OnSnack;
		GameManager.Instance.OnNewState -= OnCloset;
		GameManager.Instance.OnNewState -= OnStove;
	}
	
	private void OnFindingPlaneTickets(State state) {
		UpdateWhiteboard (State.PlaneTicket3, text, "Grab a snack", toggle);
	}

	private void OnSnack(State state) {
		UpdateWhiteboard (State.Snack, text2, "Clean the closet", toggle2);
	}

	private void OnCloset(State state) {
		UpdateWhiteboard (State.Closet, text3, "Turn off the stove", toggle3);
	}

	private void OnStove(State state) {
		UpdateWhiteboard (State.Stove, text4, "WHAT'S GOING ON!!!", toggle4);
	}

	private void UpdateWhiteboard(State state, Text text, string str, Toggle toggle) {
		if (PrevState (GameManager.GetState()) == state) {
			text.text = str;
			toggle.isOn = true;
		}
	}

	private State PrevState(State state) {
		return (State)(state - 1);
	}
}
