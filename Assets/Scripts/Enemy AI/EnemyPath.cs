using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

// Original Code used is from my enemy scripts used last semester
public class EnemyPath : MonoBehaviour
{
    // Creates locations array and its index that the enemy will use
    // to patrol
    //public Vector3[] locations;

    private List<Vector3> locations = new List<Vector3> ();

    public List<GameObject> locationObjects;



    private int index;

    // Creates variables for the enemy's navmesh agent 
    private NavMeshAgent _enemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in locationObjects)
        {
            locations.Add(obj.transform.position);
        }


        _enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Patrol();
    }

    // Has the enemy patrol various locations set in the inspector 
    public void Patrol()
    {
        /*
        if (locations.Length >= 1)
        {
            if (Vector3.Distance(_enemyAgent.transform.position, locations[index]) < 2f)
            {
                if (index == (locations.Length - 1))
                {
                    index = 0;
                    _enemyAgent.SetDestination(locations[index]);
                }
                else
                {
                    index++;
                    _enemyAgent.SetDestination(locations[index]);
                }
            }
            else
                _enemyAgent.SetDestination(locations[index]);
        }
        */

        if (locations.Count >= 1)
        {
            if (Vector3.Distance(_enemyAgent.transform.position, locations[index]) < 2f)
            {
                if (index == (locations.Count - 1))
                {
                    index = 0;
                    _enemyAgent.SetDestination(locations[index]);
                }
                else
                {
                    index++;
                    _enemyAgent.SetDestination(locations[index]);
                }
            }
            else
                _enemyAgent.SetDestination(locations[index]);
        }
    }
}
