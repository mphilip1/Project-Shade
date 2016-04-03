using UnityEngine;
using System.Collections;

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
    }
}
