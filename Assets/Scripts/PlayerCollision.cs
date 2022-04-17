using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    AudioSource audioSrc;
    bool isColliding;

    public GameManager gm;
    public ParticleSystem selfExplosion;
    public AudioClip humanSound;
    public AudioClip selfDestroySound;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        isColliding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gm.isGameOver)
        {
            Debug.Log("Player Destroyed!!");
            ParticleSystem ps = Instantiate(selfExplosion);
            ps.transform.position = collision.transform.position;

            audioSrc.PlayOneShot(selfDestroySound, 1.0f);
            Destroy(ps.gameObject, 2.0f);

            // Hide Player until sound ends
            gameObject.transform.Translate(Vector3.forward * 10);
            Destroy(gameObject, selfDestroySound.length);
        }

        if (isColliding) return;

        isColliding = true;
        if (collision.gameObject.CompareTag("Human"))
        {
            gm.IncrementHumanSaved();
            audioSrc.PlayOneShot(humanSound, 1.0f);
            Destroy(collision.gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (isColliding) return;

    //    isColliding = true;
    //    if (other.gameObject.CompareTag("Human"))
    //    {
    //        gm.IncrementHumanSaved();
    //        audioSrc.PlayOneShot(humanSound, 1.0f);
    //        Destroy(other.gameObject);
    //    }
    //}
}
