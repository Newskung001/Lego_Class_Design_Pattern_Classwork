using UnityEngine;

public class PowerUpCommand : ICommand
{
    private PlayerController _player;
    private float _duration;
    private float _multiplier;

    public PowerUpCommand(PlayerController player, float duration, float multiplier)
    {
        _player = player;
        _duration = duration;
        _multiplier = multiplier;
    }

    public void Execute()
    {
        _player.ApplySpeedBoost(_multiplier, _duration);
    }

    public void Undo()
    {
        _player.ResetSpeed();
    }
}
