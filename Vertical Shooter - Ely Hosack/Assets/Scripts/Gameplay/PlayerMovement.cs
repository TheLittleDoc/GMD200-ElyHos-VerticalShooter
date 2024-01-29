using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 mouse;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse - (Vector2)transform.position);
        //set movement vector based on input and direction the player is facing
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) ;
        //add force based on the direction the player is facing
        rb.AddForce(movement * 10f);
    }
}
