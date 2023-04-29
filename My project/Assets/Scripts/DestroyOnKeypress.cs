using UnityEngine;

public class DestroyOnKeypress : MonoBehaviour
{
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G)) {
    //        float attackDistance = 1f;
    //        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, attackDistance, pickUpLayerMask)) {
    //            Debug.Log(raycastHit.transform);
    //            if (raycastHit.transform.TryGetComponent(out weapon)) {
    //                weapon.Grab(objectGrabPointTransform);
    //                Debug.Log(weapon);
    //            }
    //        }
    //    }
    //}
	void Update ()
	{
		// Check if any key was pressed
		if (Input.anyKeyDown) 
		{
			// Destroy the gameobject this script is attached to
			Destroy(gameObject);
		}
	}
}