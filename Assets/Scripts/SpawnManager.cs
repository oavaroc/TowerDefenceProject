using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{

    private static int _enemiesSpawningThisLevel = 0;

    public void StartSpawning(EnemyTypeEnum _enemyToSpawn, int amount, float spawnRate, Vector3 position)
    {
        StartCoroutine(SpawnRoutine(_enemyToSpawn, amount, spawnRate, position));
    }

    private IEnumerator SpawnRoutine(EnemyTypeEnum _enemyToSpawn, int amount, float spawnRate, Vector3 position)
    {
        _enemiesSpawningThisLevel += amount;
        Debug.Log("Spawn Routine _enemiesSpawningThisLevel:"+ _enemyToSpawn.ToString() + _enemiesSpawningThisLevel);
        yield return new WaitForSeconds(3f);
        while (amount > 0 )
        {
            SpawnEnemy(ObjectPoolManager.Instance.RequestEnemy(_enemyToSpawn), position);
            amount--;
            yield return new WaitForSeconds(spawnRate);

        }
    }

    private void SpawnEnemy(GameObject enemy, Vector3 position)
    {
        enemy.transform.position = position;
        enemy.SetActive(true);
        Debug.Log("EnemySpawned");
    }

    public void SubtractEnemySpawnThisLevel()
    {
        _enemiesSpawningThisLevel--;
        Debug.Log("Destination Reached _enemiesSpawningThisLevel:"  + _enemiesSpawningThisLevel);
        if (_enemiesSpawningThisLevel <= 0)
        {
            LevelManager.Instance.LevelFinished();
        }
    }
}
