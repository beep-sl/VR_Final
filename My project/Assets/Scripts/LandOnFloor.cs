using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandOnFloor : MonoBehaviour
{

    //GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (transform.position.y > 0 && transform.position.y < .6) {
            GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces

        }    
    }
}
