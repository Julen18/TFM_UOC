using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyZoneManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxNumberOfEnemiesSpawneds;
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;
    public int enemiesToStart;
    public bool startSpawning;

    private CanvasItemsUIQuest quest;
    private List<Transform> spawnsPoints;
    private List<GameObject> enemiesSpawned;
    private bool canSpawn;
    private int HowManyDeads;
    void Start()
    {
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
        if (startSpawning) StartToSpawn();
        HowManyDeads = 0;
        quest = null;
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
                enemy.SendMessage("SetZone", name);

                t.RemoveAt(random);
                if (t.Count == 0)
                {
                    t = spawnsPoints.Select(item => item).ToList(); ;
                }
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
                //enemy.transform.parent = transform;
                enemy.SendMessage("SetZone", name);

                enemiesSpawned.Add(enemy);
            }

            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
        }
    }
    
    public void StopToSpawn()
    {
        canSpawn = false;
    }

    public void CmdRemoveEnemy(GameObject enemy)
    {
        if (quest != null)
        {
            quest.SetTextKills("Boss", HowManyDeads, enemiesToStart - 1);
        }
        HowManyDeads++;
        enemiesSpawned.Remove(enemy);
        StartCoroutine(RemoveEnemy(enemy));
    }

    public void SetQuest(CanvasItemsUIQuest q)
    {
        quest = q;
    }

    public int TotallyKillSpawns()
    {
        return HowManyDeads;
    }

    public int TotallySpawns()
    {
        return enemiesToStart - 1;
    }

    IEnumerator RemoveEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(5f);
        Destroy(enemy);
    }
}
