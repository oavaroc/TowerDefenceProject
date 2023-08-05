using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{

    [SerializeField]
    private List<EnemyGameObjectEnumPairing> _enemy;
    [SerializeField]
    private int _enemiesInPool = 10;

    private Dictionary<EnemyTypeEnum, List<GameObject>> _enemies;
    private void Start()
    {
        _enemies = new Dictionary<EnemyTypeEnum, List<GameObject>>();
        foreach(EnemyTypeEnum type in Enum.GetValues(typeof(EnemyTypeEnum)))
        {
            InitializeBulkEnemies(type);
        }
    }

    private void InitializeBulkEnemies(EnemyTypeEnum type)
    {
        _enemies.Add(type, new List<GameObject>());
        for (int i=0;i< _enemiesInPool;i++)
        {
            _enemies[type].Add(SpawnEnemy(type));
        }
    }

    public GameObject RequestEnemy(EnemyTypeEnum _enemyType)
    {
        GameObject _enemyToReturn = _enemies[_enemyType].Find(x => !x.gameObject.activeSelf);
        if (_enemyToReturn == null)
        {
            _enemyToReturn = SpawnEnemy(_enemyType);
        }
        return _enemyToReturn;
    }

    private GameObject SpawnEnemy(EnemyTypeEnum _enemyType)
    {
        GameObject enemy = Instantiate(_enemy.Find(x=>x.enumValue==_enemyType).gameObject, WaypointManager.Instance.GetSpawnPoint(_enemyType).position, Quaternion.identity, transform);
        enemy.SetActive(false);
        _enemies[_enemyType].Add(enemy);
        return enemy;
    }

}
