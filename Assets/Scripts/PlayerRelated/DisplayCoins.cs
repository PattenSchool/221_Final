using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoins : MonoBehaviour
{
    public TextMeshProUGUI _text;

    private OldCharacterController _controller;

    private void Start()
    {
        _controller = PlayerStatic.Player.GetComponent<OldCharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        _text.text = _controller.coins.ToString();
    }
}
