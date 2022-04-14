using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    Vector3 offsetBullet = new Vector3(1.5f, 0, 0);
    float xRearBound = 1.6f;
    float xFrontBound = 18.4f;
    float yTopBound = 10.3f;
    float yBottomBound = 1.69f;
    AudioSource audioSrc;

    public GameObject bullet;
    public GameManager gm;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.isGameOver)
        {
            MovementConstraint();
            PlayerMoveControls();
            FireControl();
        }
    }

    void FireControl()
    {
        if (Input.GetButtonDown("Fire1") && !gm.isGameOver)
        {
            audioSrc.PlayOneShot(shootSound, 0.3f);
            Instantiate(bullet, transform.position + offsetBullet, bullet.transform.rotation);
        }
    }

    void PlayerMoveControls()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalMovement);
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalMovement);
    }

    void MovementConstraint()
    {
        if (transform.position.y > yTopBound)
        {
            transform.position = new Vector3(transform.position.x, yTopBound, transform.position.z);
        }
        if (transform.position.y < yBottomBound)
        {
            transform.position = new Vector3(transform.position.x, yBottomBound, transform.position.z);
        }
        else if (transform.position.x < xRearBound)
        {
            transform.position = new Vector3(xRearBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xFrontBound)
        {
            transform.position = new Vector3(xFrontBound, transform.position.y, transform.position.z);
        }
    }
}
