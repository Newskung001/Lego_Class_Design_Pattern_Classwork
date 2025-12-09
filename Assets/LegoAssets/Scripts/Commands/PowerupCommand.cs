public class PowerupCommand : ICommand
{
    private PlayerController _receiver;
    private PowerupType _type;
    private float _duration;

    public PowerupCommand(PlayerController r, PowerupType t, float d)
    {
        _receiver = r;
        _type = t;
        _duration = d;
    }

    public void Execute()
    {
        _receiver.ApplyPowerUp(_type, _duration);
    }

    public void Undo()
    {
        _receiver.CancelPowerUp(_type);
    }
}
