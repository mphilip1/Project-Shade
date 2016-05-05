using UnityEngine;

using System;

public class GameManager : MonoBehaviour {
	

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Game Manager").AddComponent<GameManager>();
            }

            return instance;
        }
    }

    private State curState;
	public bool HappyEnding { get; set; }

    public event Action<State> OnNewState;

	void Start() {
		HappyEnding = false;
		print (curState);
	}

    public static State GetState() {
        return Instance.curState;
    }

    public void PauseGame()
    {
        // TODO: Figure out how to pause the game
    }

    public void NextState()
    {
        curState++;
		Debug.Log("CURRENT STATE: " + curState);
        OnNewState(curState);


//		if (curState.Equals (State.Start)) {
//			// Play first ad
//		}
//		if (curState.Equals (State.PlaneTicket1)) {
//			// Play helicopter sound quietly for a little while
//			// Change plant
//
//
//
//		}
//		if (curState.Equals (State.Vacuum)) {
//			// Add sand to floor
//			//Play next radio ad
//			// Change plant back to 1st plant
//		}
//
//		if (curState.Equals (State.Snack)) {
//			// Add sand to the ground in the kitchen
//			// Make box of crackers appear
//			// If crackers are examined, turn them to sand
//			// Play new radio ad
//		}
//		if (curState.Equals (State.Closet)) {
//			// Turn door to sand
//			//
//		}
//		if (curState.Equals (State.Stove)) {
//			// Turn stove to sand
//			// Turn rest of the kitchen to sand if the player wants to
//		}

		if (curState.Equals(State.Finale)) {
			GameObject.FindGameObjectWithTag("Environment").GetComponent<HouseToSand>().Play();
		}



    }


}
