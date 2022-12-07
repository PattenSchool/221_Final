using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    private OldCharacterController _controller;

    public TextMeshProUGUI text;

    private void Start()
    {
        _controller = PlayerStatic.Player.GetComponent<OldCharacterController>();
    }

    private void Update()
    {
        text.text = _controller.maxHealth.ToString();
    }
}
