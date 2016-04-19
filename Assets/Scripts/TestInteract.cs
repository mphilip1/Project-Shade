using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Item))]
public class TestInteract : MonoBehaviour {

    private Item item;

	// Use this for initialization
	void Start () {
        item = GetComponent<Item>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            if (item.CanExamine())
            {
                Debug.Log(item.Examine());
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.NextState();
            Debug.Log("CURRENT STATE: " + GameManager.GetState());
        }
	}
}
