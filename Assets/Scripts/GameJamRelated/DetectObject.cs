using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    private GameObject _player;

    // object that represents what the player should see
    public GameObject objectChecker;

    private float _checkDistance;

    public string[] tagsToCheck;

    private GameObject[] _objectsToCheckArray;

    private List<GameObject> _objectsToCheck = new List<GameObject>();


    // Sets _player to player
    void Start()
    {
        _player = PlayerStatic.Player;

        // Looks for objects with apropriate tag that should only appear when looked at
        foreach (string tag in tagsToCheck)
        {
            _objectsToCheckArray = GameObject.FindGameObjectsWithTag(tag);
            foreach (var obj in _objectsToCheckArray)
            {
                _objectsToCheck.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        // Sorry I know this is not efficient at all
        // Checks each object that should be checked
        foreach (var obj in _objectsToCheck)
        {
            // Makes a vector direction towards the object that needs to be checked if player has line of sight
            Vector3 dirToObj = obj.transform.position - objectChecker.transform.position;

            // Makes distance between player pov and object
            _checkDistance = Vector3.Distance(objectChecker.transform.position, obj.transform.position);

            // Raycast towards object from object checker (player pov)
            if (Physics.Raycast(objectChecker.transform.position, dirToObj, out hit, _checkDistance))
            {
                // Checks if the detected object is not the object that needs to be checked
                if (hit.transform.gameObject != obj.transform.gameObject)
                {
                    // Disables it if so
                    obj.transform.gameObject.SetActive(false);
                }
            }
            else
            {
                // If there is nothing detected in between the check object and the object to be checked's location
                // set true
                if (Vector3.Distance(_player.transform.position, obj.transform.position) > 3f)
                {
                    obj.transform.gameObject.SetActive(true);
                }
            }
        }
    }
}
