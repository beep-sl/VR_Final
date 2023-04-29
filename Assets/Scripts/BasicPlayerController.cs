using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

    	transform.Translate(Vector3.forward * Time.deltaTime * 2 * forwardInput);
        transform.Rotate(Vector3.up, 100 * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * 2 * horizontalInput)
    }
}