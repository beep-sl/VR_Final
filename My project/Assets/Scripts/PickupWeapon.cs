using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private LayerMask destroyLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject particleSystem;

    private ObjectGrabbable weapon;
    private GameObject objectToDestroy;
    private GameObject gameObj;
    bool canDestroy;
    bool canPickup;

    private int i;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (weapon == null) {
                Debug.Log("Epress");

                float pickUpDistance = 3f;
                if (canPickup) {
                    //Debug.Log(raycastHit.transform);
                    if (gameObj.TryGetComponent(out weapon)) {
                        weapon.Grab(objectGrabPointTransform);
                        Debug.Log(weapon);
                    }
                }
            } else {
                weapon.Drop();
                
                weapon = null;
            }
        } else if (Input.GetKeyDown(KeyCode.G)) {
            //float attackDistance = 1f;
            Debug.Log("Gpress");
            Debug.Log(canDestroy);
            //Destroy(objectToDestroy);
            if (canDestroy == true && objectToDestroy != null) {
                canDestroy = false;
                Debug.Log("Were destroying");
                Debug.Log(objectToDestroy);
                Vector3 spawnPos = objectToDestroy.transform.position;
                Destroy(objectToDestroy);
                objectToDestroy = null;
                if (i == 5) {
                    Instantiate(prefab, spawnPos, Quaternion.identity);
                    //transform.position += Vector3.up * 1 * Time.deltaTime;
                } else {
                    Instantiate(particleSystem, spawnPos, Quaternion.identity);
                }
                i++;
            }
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Destroy") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canDestroy = true;
            Debug.Log("candestroy");
            objectToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            Debug.Log(objectToDestroy);
        } else if (other.gameObject.tag == "Weapon") {
            canPickup = true;
            Debug.Log("canpickup");
            gameObj = other.gameObject;
            Debug.Log(gameObj);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canDestroy = false;
        canPickup = false;
    }
}
