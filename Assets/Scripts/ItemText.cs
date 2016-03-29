using UnityEngine;

using System;

[Serializable]
public sealed class ItemText {

    [SerializeField]
    private TextAsset[] text;

    public string this[State state] { get { return text[(int) state].text; } }
}
