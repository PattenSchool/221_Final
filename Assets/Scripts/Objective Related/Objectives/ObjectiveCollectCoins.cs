using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollectCoins : AbstractObjective
{
    private OldCharacterController _controller;

    public int coinsAmount;

    private void Start()
    {
        _controller = PlayerStatic.Player.GetComponent<OldCharacterController>();
    }

    public override void UpdateThis()
    {
        if (_controller.coins >= coinsAmount)
        {
            MarkComplete();
        }
    }
}
