using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRocket : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Debug.Log("I should disappear now");
            Destroy(this.gameObject);
            //Destroy()
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
