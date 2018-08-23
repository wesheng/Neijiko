using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsRegion : MonoBehaviour
{

    [SerializeField] private List<Bounds> bounds;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (var bound in bounds)
        {
            Gizmos.DrawWireCube(bound.center + transform.position, bound.size);
        }
    }

    public Vector3 GetRandomPoint()
    {
        int boundIndex = Random.Range(0, bounds.Count);
        Bounds bound = bounds[boundIndex];
        Vector3 min = bound.min;
        Vector3 max = bound.max;
        Vector3 pos = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z));
        return pos + transform.localPosition;
    }
}
