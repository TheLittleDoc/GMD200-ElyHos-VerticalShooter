using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 mouse;
    private Vector2 movement;


    private Vector2 initialPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        initialPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetAxis("Vertical") > 0)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-.02f, .02f), transform.position.y + Random.Range(-.02f, .02f));
        }
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse - (Vector2)transform.position);
        //set movement vector based on input and direction the player is facing
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")/8f) ;
        //add force based on the direction the player is facing
        //add bounds to the player
        if (initialPos.x + GameManager.maxX < transform.position.x)
        {
            transform.position = new Vector2(initialPos.x + GameManager.maxX, transform.position.y);
        }
        else if (initialPos.x - GameManager.maxX > transform.position.x)
        {
            transform.position = new Vector2(initialPos.x - GameManager.maxX, transform.position.y);
        }

        if (initialPos.y + GameManager.maxY < transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, initialPos.y + GameManager.maxY);
        }
        else if (initialPos.y - GameManager.maxY > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, initialPos.y - GameManager.maxY);
        }
        rb.AddForce(movement * 10f);
    }
}
