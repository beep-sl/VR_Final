using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandOnFloor : MonoBehaviour
{
    bool grounded = false;
    
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Graveyard_ground") {
            Debug.Log("I hit the ground!");
        }
    }

    //GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (transform.position.y > 0 && transform.position.y < .6 && !grounded) {
            GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            Debug.Log("I have set kinematic to true!!!!!");
        }    
        if(transform.position.y < .2 && transform.position.y > 0 && !grounded) {
            grounded = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("I have set kinematic to false!!!!!");
        }
    }
}
