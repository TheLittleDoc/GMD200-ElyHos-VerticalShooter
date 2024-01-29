using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private Vector2 travelDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);

        laserInstance.tag = "Laser";
        // add impulse
        travelDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        laserInstance.GetComponent<Rigidbody2D>().AddForce(20 * travelDirection, ForceMode2D.Impulse);
        Destroy(laserInstance, 2f);

    }
}
