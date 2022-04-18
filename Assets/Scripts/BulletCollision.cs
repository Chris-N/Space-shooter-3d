using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public ParticleSystem explosion;
    public ParticleSystem humanDeath;
    public AudioClip enemyDestroySound;
    public AudioClip humanDestroySound;

    EnemyPoints enemyPoints;
    GameObject gameManager;
    AudioSource globalSrc;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            globalSrc = GameObject.Find("Global Sound").GetComponent<AudioSource>();

            ParticleSystem ps = Instantiate(explosion);
            ps.transform.position = collision.gameObject.transform.position;
            ps.Play();
            Destroy(ps.gameObject, 2);

            globalSrc.PlayOneShot(enemyDestroySound, 1.0f);
            UpdateScore(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Human"))
        {
            globalSrc = GameObject.Find("Global Sound").GetComponent<AudioSource>();

            ParticleSystem ps = Instantiate(humanDeath);
            ps.transform.position = collision.gameObject.transform.position;
            ps.Play();
            Destroy(ps.gameObject, 2);

            globalSrc.PlayOneShot(humanDestroySound, 1.0f);
            UpdateScore(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void UpdateScore(GameObject go)
    {
        enemyPoints = go.GetComponentInParent<EnemyPoints>();
        if (enemyPoints == null) return;

        gameManager = GameObject.Find("Game Manager");
        GameManager gm = gameManager.GetComponent<GameManager>();
        gm.AddScore(enemyPoints.GetPoints());
    }
}
