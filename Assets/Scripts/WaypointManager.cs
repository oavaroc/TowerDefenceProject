using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoSingleton<WaypointManager>
{

    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private Transform _capsulespawnPoint;
    [SerializeField]
    private Transform _destination;

    public Transform GetSpawnPoint(EnemyTypeEnum _enemyType)
    {
        switch (_enemyType)
        {
            case EnemyTypeEnum.Diver:
                return _spawnPoint;
            case EnemyTypeEnum.Capsule:
                return _capsulespawnPoint;
            default:
                return _spawnPoint;

        }
    }

    public Transform GetDestination()
    {
        return _destination;
    }
}
