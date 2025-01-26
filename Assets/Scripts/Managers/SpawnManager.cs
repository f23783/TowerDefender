using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DistanceList
{
    public GameObject enemyGO;
    public Vector2 enemyDistance;
}

[Serializable]
public class enemyType
{
    public GameObject enemyGO;
    public int spawnableWave;
    public float spawnFrequency;
}

[Serializable]
public class Waves
{
    public int spawnableEnemyNumber;
    public float spawnFrequency;
    public int prepartionTime;
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private List<enemyType> enemyType = new();
    [SerializeField]private List<DistanceList> distanceLists = new();
    [SerializeField]private List<Waves> waves = new();

    [SerializeField]private List<GameObject> spawnables;
    [SerializeField]private List<Vector3> spawnLocations;

    [SerializeField]private int waveNumber = 0;
    [SerializeField]private int spawnedEnemyNumber;

    [SerializeField]private float spawnTimer;
    [SerializeField]private float spawnFrequency;

    [SerializeField]private bool tempbool = false;

    private void Start() {
        NewWave();
    }

    private void Update() 
    {
        spawnTimer += Time.deltaTime;
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        int spawnSelector;
        int spawnLocationSelector;
        if (spawnTimer >= spawnFrequency && spawnedEnemyNumber < waves[waveNumber].spawnableEnemyNumber)
        {
            spawnSelector = UnityEngine.Random.Range(0, spawnables.Capacity + 1);
            spawnLocationSelector = UnityEngine.Random.Range(0,2);

            Instantiate(spawnables[spawnSelector], spawnLocations[spawnLocationSelector], Quaternion.identity);
            
            spawnedEnemyNumber++;
            spawnTimer = 0;
        }
        else if (spawnedEnemyNumber >= waves[waveNumber].spawnableEnemyNumber && !tempbool)
        {
            tempbool = true;
            StartCoroutine(SpawnPause());
        }
    }

    private void NewWave()
    {
        spawnedEnemyNumber = 0;
        spawnables.Clear();
        waveNumber++;
        foreach (var item in enemyType)
        {
            if (item.spawnableWave <= waveNumber)
            {
                spawnables.Add(item.enemyGO);
            }
        }
        spawnFrequency = waves[waveNumber].spawnFrequency;
        tempbool = false;
    } 

    IEnumerator SpawnPause()
    {
        spawnTimer = 0;
        while (spawnTimer <= waves[waveNumber].prepartionTime)
        {
            Debug.Log("Last:" + (waves[waveNumber].prepartionTime - spawnTimer));
            spawnTimer += Time.deltaTime;
            yield return null;
        }
        NewWave();
    }
}
