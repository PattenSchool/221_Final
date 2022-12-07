using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _player;

    private OldCharacterController _controller;

    public float pickUpRadius = 0;


    // Start is called before the first frame update
    void Start()
    {
        _player = PlayerStatic.Player;

        _controller = _player.GetComponent<OldCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(_player.transform.position);

        if (Vector3.Distance(_player.transform.position, this.transform.position) < pickUpRadius)
        {
            if (this.gameObject.activeInHierarchy)
            {
                _controller.AddCoin();

                this.gameObject.SetActive(false);
            }
        }
    }
}
