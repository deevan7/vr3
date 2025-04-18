using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public Rigidbody rb;
public float forwardForce = 2000f;
public float sidewaysForce = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
      //  Debug.Log("game Start");
       // rb.useGravity = true;
       // rb.AddForce(0,-200,500);
    //}

    // Update is called once per frame 
    void FixedUpdate()
    {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);   //after every frame

        if (Input.GetKey("d")){
                 rb.AddForce(sidewaysForce * Time.deltaTime,0,0);
        }
        if (Input.GetKey("a")){
                 rb.AddForce(-sidewaysForce * Time.deltaTime,0,0);
        }        
    }
}
