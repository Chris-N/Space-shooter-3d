using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioClip enemyDestroySound;

    EnemyPoints enemyPoints;
    GameObject gameManager;
    AudioSource globalSrc;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            globalSrc = GameObject.Find("Global Sound").GetComponent<AudioSource>();

            Debug.Log("Killed enemy");
            ParticleSystem ps = Instantiate(explosion);
            ps.transform.position = collision.gameObject.transform.position;
            ps.Play();
            Destroy(ps.gameObject, 2);

            globalSrc.PlayOneShot(enemyDestroySound, 1.0f);
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
