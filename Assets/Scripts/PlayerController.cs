using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb ;
    float gravitymodifier = 2.0f;
    float speed = 10.0f;
    int jumpcount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravitymodifier;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalinput = Input.GetAxis("Vertical");
        float horizontalinput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalinput);   
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalinput);

        if(transform.position.y <= 0.5f)
        {
            transform.position = new Vector3(-0.328f, 2.457f, -4.91f);
        }

        JumpPlayer();


    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }

    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpcount < 1)
        {
            playerRb.AddForce(Vector3.up * 10 , ForceMode.Impulse);
            jumpcount++;
        }
    }
}
