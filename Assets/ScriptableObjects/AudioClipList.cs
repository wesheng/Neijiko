using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Object List/Audio")]
public class AudioClipList : ObjectList<List<AudioClip>>
{
    [Serializable]
    public class StringAudioClipPair : StringValuePair
    {

    }
    
    [SerializeField] private List<StringAudioClipPair> _dictionary;

    public override List<AudioClip> this[string key]
    {
        get { return _dictionary.Find(kvp => kvp.Key.Equals(key)).Value; }
    }

    public override int Count
    {
        get { return _dictionary.Count; }
    }

    /// <summary>
    /// Plays a random audio clip that matches the specified key.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="key">The key.</param>
    public void PlayClip(AudioSource source, string key)
    {
        var audioClipList = this[key];
        source.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        source.Play();
    }
}
