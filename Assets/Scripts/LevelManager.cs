using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] 
    private List<SpawnPoint> _spawnPoints;

    [SerializeField]
    private int _enemiesThisRound;

    private int levelReached = 1;

    public void StartLevel(int level)
    {
        _spawnPoints.ForEach(x => x.StartSpawnPoint(level));
    }

    public void LevelFinished()
    {
        StartCoroutine(LevelFinishRoutine());
    }

    IEnumerator LevelFinishRoutine()
    {
        yield return new WaitForSeconds(5f);
        StartLevel(++levelReached);
    }
}
