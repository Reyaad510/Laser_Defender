using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        // When start called do this thing. yield means come back to start once StartCoroutine(SpawnAllWaves()); is done and then goes to while and then goes back to do;
        // This allows for waves to loop enemy spawsn
        do
        {

            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }
    }


    // creates number of enemies depedning on what NumberofEnemies is in Wave.Config
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.NumberOfEnemies(); enemyCount++)
        {

             // creating new enemy and then passing in that specific enenmy wave information(allowing each wave to have diff speeds etc)
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns());
        }
    }

}
