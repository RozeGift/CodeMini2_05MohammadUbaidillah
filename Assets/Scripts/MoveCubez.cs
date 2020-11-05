using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubez : MonoBehaviour
{
    float forwardspd = 10.0f;
    float zlimit = 27.5f;
    float secondzlimit = -1.0f;
    bool collidewall = false; 
    public GameObject Player;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < zlimit && collidewall == false )
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardspd);
        }
        if (transform.position.z > zlimit)
        {

            collidewall = true; 
        }
        if(collidewall == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -forwardspd);
        }
        if(transform.position.z < secondzlimit)
        {
           collidewall = false;
        }


    }
   
           private void OnTriggerEnter(Collider other)
           {
               if(other.gameObject == Player)
               {
                   Player.transform.parent = transform; 
               }
           }

           private void OnTriggerExit(Collider other)
           {
               if (other.gameObject == Player)
               {
                   Player.transform.parent = null; 
               }
           }
     
}
