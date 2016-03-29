using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private State curState;

    public static State GetState() {
        return instance.curState;
    }

    public void PauseGame()
    {
        // TODO: Figure out how to pause the game
    }

    void Awake() {
        instance = this;
        curState = State.DrinkWater;
    }

    public void NextState()
    {
        curState++;
    }
}
