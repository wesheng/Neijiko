using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectList<T> : ScriptableObject
{
    [Serializable]
    public class StringValuePair
    {
        public string Key;
        public T      Value;
    }


    public abstract T this[string key] { get; }
    public abstract int Count { get; }
}
