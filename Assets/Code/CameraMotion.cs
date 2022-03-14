using System;
using DG.Tweening;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [Header("Move Settings")] 
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    
    [Header("Timing Settings")] 
    [SerializeField] private float startDelay;
    [SerializeField] private float toEndMoveTime;

    [Header("Eases")] 
    [SerializeField] private Ease toEndEase = Ease.Linear;

    public event Action OnMotionFinished; 
    
    public void StartMotion()
    {
        gameObject.transform.position = startPosition;
        
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(startDelay);
        sequence.Append(transform.DOLocalMove(endPosition, toEndMoveTime).SetEase(toEndEase));
    }
}
