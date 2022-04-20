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
            ParticleSystem ps = Instantiate(selfExplosion);
            ps.transform.position = collision.transform.position;

            audioSrc.PlayOneShot(selfDestroySound, 0.5f);
            Destroy(ps.gameObject, 2.0f);

            // Hide Player until sound ends
            gameObject.transform.Translate(Vector3.forward * 10);
            Destroy(gameObject, selfDestroySound.length);
        }

        if (isColliding) return;

        isColliding = true;
        if (collision.gameObject.CompareTag("Human"))
        {
            EnemyPoints go = collision.gameObject.GetComponentInParent<EnemyPoints>();
            gm.IncrementHumanSaved();
            gm.AddScore(-go.GetPoints());

            PlayerPrefs.SetInt("Score", gm.GetScore());
            audioSrc.PlayOneShot(humanSound, 1.0f);
            Destroy(collision.gameObject);
        }
    }
}
