using UnityEngine;

public abstract class InputService : MonoBehaviour, IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    protected const string Attack = "Attack";
    protected const string Aim = "Aim";

    public bool IsEnabled { get; private set; }

    public abstract Vector2 Axis { get; }

    public bool IsShootButtonUp() => SimpleInput.GetButtonUp(Attack);

    public bool IsShootButtonDown() => SimpleInput.GetButtonDown(Aim);
    
    public bool Enable()
    {
        gameObject.SetActive(true);
        return true;
    }

    public bool Disable()
    {
        gameObject.SetActive(false);
        return false;
    }

    protected static Vector2 GetSimpleInputAxis() =>
        new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}