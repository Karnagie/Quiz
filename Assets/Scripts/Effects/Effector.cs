using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Effector : MonoBehaviour
{
    [SerializeField] protected UnityEvent _onStartEvent;

    protected void Start()
    {
        _onStartEvent.Invoke();
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
