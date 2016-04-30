using UnityEngine;

using System;

[RequireComponent(typeof(Highlight))]
public class Item : MonoBehaviour {

    private int index = 0;

    [SerializeField]
    private bool nonRepeatableExamination;
    [SerializeField]
    private ItemText itemText;

    private bool canExamine;

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
        canExamine = true;
    }
    #endregion

    // Returns true if you can examine the item
    public bool CanExamine()
    {
        return curContent.Count != 0 && canExamine;
    }

    // Returns a string giving a description for the item given the current state
    public string Examine()
    {
		Debug.Log ("Examining!");
        if (!CanExamine())
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
                if (nonRepeatableExamination)
                {
                    canExamine = false;
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
