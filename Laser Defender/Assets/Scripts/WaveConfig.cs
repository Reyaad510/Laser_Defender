using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This puts EnemyWaveConfig when you go to "Create Empty" in Unity
[CreateAssetMenu(menuName = "Enemy Wave Config")]

//Scriptable bcuz holding values for other scripts to grab
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public GameObject PathPrefab()
    {
        return pathPrefab;
    }

    public float TimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float SpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int NumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float MoveSpeed()
    {
        return moveSpeed;
    }
    

}
