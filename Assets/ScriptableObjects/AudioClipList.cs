using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object List/Audio")]
public class AudioClipList : ObjectList<AudioClip>
{
    [Serializable]
    public class StringAudioClipPair : StringValuePair<AudioClip>
    {

    }
    
    [SerializeField] private List<StringAudioClipPair> _dictionary;

    public override AudioClip this[string key]
    {
        get { return _dictionary.Find(kvp => kvp.Key.Equals(key)).Value; }
    }
}
