using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private Vector2 travelDirection;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.singleton;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Fire1") && CompareTag("Player") && gameManager.playing)
        {
            Fire();
        }
    }

    void Fire()
    {
        gameManager.musicHandler.PlaySoundEffect(1);
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);

        laserInstance.tag = "Laser";
        
        travelDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        laserInstance.GetComponent<Rigidbody2D>().AddForce(20 * travelDirection, ForceMode2D.Impulse);
        Destroy(laserInstance, 2f);

        gameManager.shots++;
        gameManager.plasma--;
        
    }
}
