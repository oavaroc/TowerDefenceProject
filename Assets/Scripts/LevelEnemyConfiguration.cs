using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelEnemyConfiguration
{
    public int _levelNumber;
    public List<EnemyTypeEnum> _enemyType;
    public List<int> _spawnAmount;
    public List<float> _spawnRate;
}