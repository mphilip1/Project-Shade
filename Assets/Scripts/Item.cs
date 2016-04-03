using UnityEngine;

public class Item : MonoBehaviour {

    private int index = 0;

    [SerializeField]
    [TextArea(2, 4)]
    private string defaultText;
    [SerializeField]
    private bool oneInteraction;
    [SerializeField]
    private ItemText itemText;

    public bool CanInteract { get; private set; }

    public string CurText {
        get
        {
            ItemText.Content content = itemText[GameManager.GetState()];
            if (content.Count == 0)
            {
                return defaultText;
            }
            return itemText[GameManager.GetState()][index];
        }
    }

    public void IncrementText()
    {        
        ItemText.Content content = itemText[GameManager.GetState()];

        if (content.Count != 0)
        {
            index++;
            if (index == content.Count)
            {
                if (oneInteraction)
                {
                    CanInteract = false;
                }
                index = 0;
            }
        }
    }

    public string Interact()
    {
        string text = CurText;
        IncrementText();
        return text;
    }

    // On ChangeStateEvent, set index to 0
	
}
