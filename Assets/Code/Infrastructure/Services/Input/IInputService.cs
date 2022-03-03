using UnityEngine;

public interface IInputService : IService, ISwitchable
{
    Vector2 Axis { get; }
    
    bool IsShootButtonUp();
    bool IsShootButtonDown();
}