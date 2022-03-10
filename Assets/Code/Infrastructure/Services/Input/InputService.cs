using UnityEngine;

public abstract class InputService : MonoBehaviour, IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string Attack = "Attack";

    public bool IsEnabled { get; private set; }

    public abstract Vector2 Axis { get; }

    public bool IsShootButtonUp() => SimpleInput.GetButtonUp(Attack);

    public bool IsShootButtonDown() => SimpleInput.GetButtonDown(Attack);
    
    public void Enable()
    {
        IsEnabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;
    }

    public bool IsAxisDragged()
    {
        return Axis.y != 0 || Axis.x != 0;
    }

    protected static Vector2 GetSimpleInputAxis() =>
        new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    
}