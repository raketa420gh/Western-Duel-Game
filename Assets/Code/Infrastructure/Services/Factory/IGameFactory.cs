 using System;
 using UnityEngine;

public interface IGameFactory : IService
{
    GameObject PlayerCharacterGameObject { get; }
    event Action OnPlayerCharacterCreated;
    GameObject CreatePlayerCharacter(Vector3 initialPointPosition);
}