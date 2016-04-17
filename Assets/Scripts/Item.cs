using UnityEngine;

using System;

public class Item : MonoBehaviour {

    private int index = 0;

    [SerializeField]
    private bool oneInteraction;
    [SerializeField]
    private ItemText itemText;

    private bool canInteract;

    private ItemText.Content curContent;

    #region Unity Methods
    void OnEnable()
    {
        GameManager.Instance.OnNewState += OnNewState;
    }

    void OnDisable()
    {
        GameManager.Instance.OnNewState -= OnNewState;
    }

    void Start()
    {
        State state = GameManager.GetState();
        curContent = itemText[state];
        while (curContent.Count == 0 && state != 0)
        {
            state--;
            curContent = itemText[state];
        }
        index = 0;
        canInteract = true;
    }
    #endregion

    public bool CanInteract()
    {
        return curContent.Count != 0 && canInteract;
    }

    public string Interact()
    {
        if (!CanInteract())
        {
            throw new NotImplementedException("The " + gameObject.name + " can not be interacted yet at this stage!");
        }
        string text = CurText;
        IncrementText();
        return text;
    }

    private string CurText { get { return curContent[index]; } }

    private void IncrementText()
    {
        if (curContent.Count > 0)
        {
            index++;
            if (index == curContent.Count)
            {
                if (oneInteraction)
                {
                    canInteract = false;
                }
                index = 0;
            }
        }
    }

    private void OnNewState(State state)
    {
        ItemText.Content content = itemText[state];
        if (content.Count > 0)
        {
            index = 0;
            curContent = content;
        }
    }
	
}
