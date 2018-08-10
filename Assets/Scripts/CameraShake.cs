using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Shake(float time)
    {
        StartCoroutine(ShakeCoroutine(time));
    }

    IEnumerator ShakeCoroutine(float time)
    {
        Vector3 originalPos = transform.position;
        while (time > 0)
        {
            transform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;
            time -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
