using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private int index = 0;

    [SerializeField]
    private bool oneInteraction;
    [SerializeField]
    private ItemText itemText;

    public bool CanInteract { get; private set; }
    public string CurText { get { return itemText[GameManager.GetState()][index]; } }

    public void NextText()
    {
        index++;

        ItemText.Content content = itemText[GameManager.GetState()];

        if (index == content.Count)
        {
            if (oneInteraction)
            {
                CanInteract = false;
            }
            index = 0;
        }
    }

    // On ChangeStateEvent, set index to 0
	
}
