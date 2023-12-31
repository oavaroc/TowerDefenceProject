using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private List<LevelEnemyConfiguration> _levelEnemyConfigurations;

    public void StartSpawnPoint(int level)
    {

        LevelEnemyConfiguration config = _levelEnemyConfigurations.Find(x => x._levelNumber == level);
        if (config == null)
        {
            Debug.Log("You Win");
        }
        else
        {
            StartCoroutine(StartSpawnRoutine(config));
        }
    }

    IEnumerator StartSpawnRoutine(LevelEnemyConfiguration config)
    {
        for (int i = 0; i < config._enemyType.Count; i++)
        {
            SpawnManager.Instance.StartSpawning(config._enemyType[i], config._spawnAmount[i], config._spawnRate[i], transform.position);
            yield return new WaitForSeconds(config._spawnRate[i]* config._spawnAmount[i]);
        }

    }
}
