using UnityEngine;

public abstract class InputService : MonoBehaviour, IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string Attack = "Attack";
    private const string Aim = "Aim";

    public bool IsEnabled { get; private set; }

    public abstract Vector2 Axis { get; }

    public bool IsShootButtonUp() => SimpleInput.GetButtonUp(Attack);

    public bool IsShootButtonDown() => SimpleInput.GetButtonDown(Aim);
    
    public void Enable()
    {
        gameObject.SetActive(true);
        IsEnabled = true;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        IsEnabled = false;
    }

    protected static Vector2 GetSimpleInputAxis() =>
        new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}