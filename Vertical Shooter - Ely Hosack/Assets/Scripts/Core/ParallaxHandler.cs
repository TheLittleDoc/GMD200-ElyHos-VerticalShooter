using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHandler : MonoBehaviour
{
    private GameManager gameManager;

    private float length, yPos;
    private Vector2 startingPosition;
    [SerializeField] private float parallax, speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleton;
        startingPosition = transform.position;
        yPos = startingPosition.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        //Debug.Log(length);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //autoincrement y using parallax factor
        yPos -= parallax * -speed * Time.deltaTime;

        //if y is less than -length, reset y to starting position
        if (yPos <= -(length))
        {
            yPos = 0;
        }
        //Debug.Log(yPos);

        //run parallax effect based on player position
        Vector3 temp = new Vector3(transform.position.x, yPos, transform.position.z);
        float distance = player.transform.position.x * parallax;
        Vector3 newPosition = new Vector3(startingPosition.x + distance, temp.y, temp.z);




        transform.position = newPosition;





    }
}
