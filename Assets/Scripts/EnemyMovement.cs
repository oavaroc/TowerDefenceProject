using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _destination;
    private NavMeshAgent _ai;
    // Start is called before the first frame update
    void Start()
    {
        _ai = GetComponent<NavMeshAgent>();
        if (_ai == null)
        {
            Debug.Log("AI is null");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {
            Debug.Log("Destination Reached");
            SpawnManager.Instance.SubtractEnemySpawnThisLevel();
            gameObject.SetActive(false);

        }
        else if (other.CompareTag("Start"))
        {
            Debug.Log("Starting");
            _ai.SetDestination(WaypointManager.Instance.GetDestination().position);

        }

    }
    
}
