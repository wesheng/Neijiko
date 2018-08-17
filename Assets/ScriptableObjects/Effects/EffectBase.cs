using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBase : ScriptableObject
{
    public abstract IEnumerator EffectCoroutine(NejikoController controller);
}
