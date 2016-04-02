using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public sealed class ItemText : IEnumerable<ItemText.Content>
{
    [SerializeField]
    private Content[] content;

    public int Count { get { return content.Length; } }

    public Content this[State state] { get { return content[(int) state]; } }

    public IEnumerator<Content> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return content[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    [Serializable]
    public sealed class Content : IEnumerable<string>
    {
        [SerializeField]
        [TextArea(2, 4)]
        private string[] text;

        public int Count { get { return text.Length; } }

        public string this[int index] { get { return text[index]; } }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
