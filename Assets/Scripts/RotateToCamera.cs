using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RotateToCamera : MonoBehaviour
{
    private GameObject player;
    private GameObject MainCamera;
    private float Speed = 10.0f;
    private bool isRotating = false;
 
    void Awake ()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
 
    void Update ()
    {
        //Set your input right here to start the rotation
        if (Input.GetKeyDown(KeyCode.Space))
            isRotating = !isRotating; //Starts the rotation
 
        if (isRotating) //Check if your game object is currently rotating
            SetRotate(this.gameObject, MainCamera);
 
        //When your child game object and your camera have the same rotation.y value, it stops the rotation
        if (this.gameObject.transform.rotation.eulerAngles.y == GetComponent<Camera>().transform.rotation.eulerAngles.y)
            isRotating = !isRotating;
    }
 
    void SetRotate(GameObject toRotate, GameObject camera)
    {
        //You can call this function for any game object and any camera, just change the parameters when you call this function
        transform.rotation = Quaternion.Lerp(toRotate.transform.rotation, camera.transform.rotation, Speed * Time.deltaTime);
    }
}