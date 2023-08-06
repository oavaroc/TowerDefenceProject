using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _placementPoint;

    public Transform GetPlacementPoint()
    {
        return _placementPoint;
    }
}
