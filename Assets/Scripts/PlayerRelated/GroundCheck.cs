using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = PlayerStatic.Player;
    }

    private void Update()
    {
        this.transform.parent = _player.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            return;
        }
        _player.GetComponent<OldCharacterController>().SetGrounded(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            return;
        }
        _player.GetComponent<OldCharacterController>().SetGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player)
        {
            return;
        }
        _player.GetComponent<OldCharacterController>().SetGrounded(true);
    }
}
