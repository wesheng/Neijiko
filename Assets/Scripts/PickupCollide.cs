using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollide : MonoBehaviour
{

    private NejikoController controller;

    private void Start()
    {
        controller = GetComponent<NejikoController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            PowerUp powerupComp = hit.gameObject.GetComponent<PowerUp>();
            powerupComp.GiveEffect(controller);
            Destroy(hit.gameObject);
        }
    }
}
