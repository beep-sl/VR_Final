using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound;

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Oxygen") {
            playSound.Play();
        }
    }
}
