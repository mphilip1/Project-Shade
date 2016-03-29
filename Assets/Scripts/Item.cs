using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    [SerializeField]
    private ItemText itemText;

    public string GetText()
    {
        return itemText[GameManager.GetState()];
    }
	
}
