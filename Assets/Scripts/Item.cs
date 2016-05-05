using UnityEngine;

using System;

[RequireComponent(typeof(Highlight))]
[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour {

    private int index = 0;

	public State advanceState;

    [SerializeField]
    private bool nonRepeatableExamination;
    [SerializeField]
    private ItemText itemText;
	[SerializeField]
	private State thresholdInteraction;
	[SerializeField]
	private bool notInteractable;

    private bool canExamine;

    private ItemText.Content curContent;

	[SerializeField]
	private bool dontAdvanceState;

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
														//state is past plane ticket 3 and you're looking at a hiding spot
		return curContent.Count != 0 && canExamine && !(GameManager.GetState () > State.PlaneTicket3 && this.CompareTag("Troll"));
    }

	public bool CanInteract() {
		if (!notInteractable && GameManager.GetState () >= thresholdInteraction) {
			return true;
		}
		return false;
	}

    // Returns a string giving a description for the item given the current state
    public string Examine()
    {
		Debug.Log ("Examining!");
        if (!CanExamine())
        {
            throw new NotImplementedException("The " + gameObject.name + " can not be interacted yet at this stage!");
        }
        return CurText;
    }

	public bool DontAdvanceState { get {return dontAdvanceState;} }

    private string CurText { get { return curContent[index]; } }

    public void IncrementText()
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
				if (!this.dontAdvanceState) {
					GameManager.Instance.NextState(); 
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
