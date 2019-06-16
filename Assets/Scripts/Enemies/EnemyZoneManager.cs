using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyZoneManager : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int maxNumberOfEnemiesSpawneds;
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;
    public int enemiesToStart;

    private List<Transform> spawnsPoints;
    private List<GameObject> enemiesSpawned;
    private bool canSpawn;

    void Start()
    {
        if (!isServer)
        {
            enabled = false;
        }
        canSpawn = false;
        enemiesSpawned = new List<GameObject>();
        spawnsPoints = new List<Transform>();

        Transform spManager = transform.Find("SpawnsPoint");
        Transform[] tChildren = spManager.GetComponentsInChildren<Transform>();

        foreach (Transform t in tChildren)
        {
            if (t != spManager)
            {
                spawnsPoints.Add(t);
            }
        }
        StartToSpawn();
    }

    public void StartToSpawn()
    {
        canSpawn = true;
        int i, random;
        if (enemiesToStart > 0)
        {
            List<Transform> t = spawnsPoints.Select(item => item).ToList(); ;
            for (i = 0; i < enemiesToStart - 1; i++)
            {
                random = Random.Range(0, t.Count);

                GameObject enemy = (GameObject)Instantiate(enemyPrefab, t[random].position, t[random].rotation);
                NetworkServer.Spawn(enemy);

                t.RemoveAt(random);

                enemiesSpawned.Add(enemy);
            }
        }

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (canSpawn)
        {
            if (maxNumberOfEnemiesSpawneds > enemiesSpawned.Count)
            {
                int random;
                random = Random.Range(0, spawnsPoints.Count);

                GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnsPoints[random].position, spawnsPoints[random].rotation);
                enemy.transform.parent = transform;
                NetworkServer.Spawn(enemy);

                enemiesSpawned.Add(enemy);
            }

            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
        }
    }
    
    public void StopToSpawn()
    {
        canSpawn = false;
    }

    [Command]
    public void CmdRemoveEnemy(GameObject enemy)
    {
        enemiesSpawned.Remove(enemy);
        StartCoroutine(RemoveEnemy(enemy));
    }

    IEnumerator RemoveEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(5f);
        NetworkServer.Destroy(enemy);
    }
}
