using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyArr;
    public GameObject human;
    [SerializeField] GameManager gm;

    // Enemy position
    private float enemySpawnX = 20.0f;
    private float enemySpawnMaxY = 10.0f;
    private float enemySpawnMinY = 1.7f;

    // Human position
    private float humanSpawnY = 13.0f;
    private float humanSpawnMaxX = 13.0f;
    private float humanSpawnMinX = 2.0f;

    private float zPosition = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0.5f, 1);

        StartCoroutine(SpawnHuman());
    }

    void SpawnRandomEnemy()
    {
        if (gm.isGameOver) return;

        int randomIndex = Random.Range(0, enemyArr.Length);
        float randomYRange = Random.Range(enemySpawnMinY, enemySpawnMaxY);

        Vector3 randomPosition = new Vector3(enemySpawnX, randomYRange, zPosition);

        GameObject newEnemy = Instantiate(enemyArr[randomIndex], randomPosition, enemyArr[randomIndex].transform.rotation);

        // [Future improvement] Adjust with difficulty?
        newEnemy.GetComponent<MoveLeft>().speed += gm.GetHumanSaved();
    }

    IEnumerator SpawnHuman()
    {
        if (gm.isGameOver) yield break;

        int humanCount = 0;
        while (true)
        {
            float seconds = Random.Range(3.0f, 8.0f);
            yield return new WaitForSeconds(seconds);

            float randomXRange = Random.Range(humanSpawnMinX, humanSpawnMaxX);

            Vector3 randomPosition = new Vector3(randomXRange, humanSpawnY, zPosition);

            Instantiate(human, randomPosition, human.transform.rotation);
            humanCount++;
        }
    }
}
