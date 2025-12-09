using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour
{
    public PowerupType type;
    public float duration;
    private CommandManager _cmdManager;
    private PlayerController _player;

    private void Awake()
    {
        _cmdManager = FindObjectOfType<CommandManager>();
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ICommand command = new PowerupCommand(_player, type, duration);
            _cmdManager.ExecuteCommand(command);
            gameObject.SetActive(false);
        }
    }
}
