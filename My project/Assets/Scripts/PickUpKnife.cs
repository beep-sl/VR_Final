using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKnife : MonoBehaviour
{
    public Transform Weapon;
    public float speed = 5.0f;
    public Camera playerCamera;
    public BoxCollider boxCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the weapon is close enough to the player
            float distance = Vector3.Distance(
                this.transform.position,
                Weapon.position
            );

            if (distance <= 2.0f)
            {
                // Calculate the direction from the player to the weapon
                Vector3 direction = (Weapon.position - playerCamera.transform.position).normalized;

                // Move the weapon towards the player
                Weapon.position = Vector3.MoveTowards(Weapon.position, boxCollider.transform.position, speed * Time.deltaTime);
                
                //Weapon.position = this.transform.position;

                // Rotate the weapon to face the player
                
                Weapon.rotation = Quaternion.identity;

                // Parent the weapon to the player's hand
                Weapon.parent = boxCollider.transform;
            }
        }
    }
}