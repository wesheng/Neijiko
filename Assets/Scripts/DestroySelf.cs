using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{

    public float TimeToDestroy = 0.3f;
    public bool EnableOnAwake = true;


    private void Awake()
    {
        if (EnableOnAwake)
        {
            BeginDestroy();
        }
    }

    public void BeginDestroy()
    {
        StartCoroutine(DestroyCoroutine(TimeToDestroy));
    }

    IEnumerator DestroyCoroutine(float time)
    {
        float current = 0.0f;
        while (current <= time)
        {        
            current += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
