using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollide : MonoBehaviour
{
    private NejikoController controller;
    private AudioPlayer audioPlayer;

    private void Start()
    {
        controller = GetComponent<NejikoController>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            PowerUp powerupComp = hit.gameObject.GetComponent<PowerUp>();

            audioPlayer.PlayClip("Powerup");
            
            powerupComp.GiveEffect(controller);
            Destroy(hit.gameObject);
        }
    }
}
