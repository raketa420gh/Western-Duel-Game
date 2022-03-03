public interface ISwitchable
{
    bool IsEnabled { get; }
    bool Enable();
    bool Disable();
}