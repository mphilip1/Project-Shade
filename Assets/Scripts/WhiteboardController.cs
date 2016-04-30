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

	[SerializeField]
	private Text text5;
	[SerializeField]
	private Toggle toggle5;

	void OnEnable()
	{
		GameManager.Instance.OnNewState += OnFindingPlaneTickets;
		GameManager.Instance.OnNewState += OnVacuuming;
		GameManager.Instance.OnNewState += OnSnack;
		GameManager.Instance.OnNewState += OnCloset;
		GameManager.Instance.OnNewState += OnStove;
	}
	
	void OnDisable()
	{
		GameManager.Instance.OnNewState -= OnFindingPlaneTickets;
		GameManager.Instance.OnNewState -= OnVacuuming;
		GameManager.Instance.OnNewState -= OnSnack;
		GameManager.Instance.OnNewState -= OnCloset;
		GameManager.Instance.OnNewState -= OnStove;
	}
	
	private void OnFindingPlaneTickets(State state) {
		UpdateWhiteboard (State.PlaneTicket3, text, "Vacuum the floor", toggle);
	}

	private void OnVacuuming(State state) {
		UpdateWhiteboard (State.Vacuum, text2, "Grab a snack", toggle2);
	}

	private void OnSnack(State state) {
		UpdateWhiteboard (State.Snack, text3, "Clean the closet", toggle3);
	}

	private void OnCloset(State state) {
		UpdateWhiteboard (State.Closet, text4, "Turn off the stove", toggle4);
	}

	private void OnStove(State state) {
		UpdateWhiteboard (State.Stove, text5, "WHAT'S GOING ON!!!", toggle5);
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
