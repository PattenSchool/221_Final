using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Original Code used is from my enemy scripts used last semester
public class EnemyTrack : MonoBehaviour
{
    // Variable for player and enemy navmesh agent
    private GameObject _player;
    private NavMeshAgent _enemyAgent;
    public float distanceThreshold;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _player = PlayerStatic.Player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If player is close to enemy follow player
        if (Vector3.Distance(this.transform.position, _player.transform.position) < distanceThreshold)
        {
            _enemyAgent.destination = _player.transform.position;
        }
        else
        {
            _enemyAgent.ResetPath();
        }
    }
}
