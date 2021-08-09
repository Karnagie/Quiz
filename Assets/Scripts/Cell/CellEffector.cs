using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CellEffector : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStartEvent;
    [SerializeField] private UnityEvent _onFailEvent;
    [SerializeField] private UnityEvent _onRightEvent;
    [SerializeField] private float _delay = 1;

    private Action _onRightAction;

    protected void Start()
    {
        _onStartEvent.Invoke();
    }

    public void Invoke()
    {
        if (_onRightAction != null)
        {
            StartCoroutine(Delay(_delay));
        }
        else _onFailEvent.Invoke();
    }

    public void SetActionOnRight(Action action)
    {
        _onRightAction = action;
    }

    private IEnumerator Delay(float time)
    {
        _onRightEvent.Invoke();
        yield return new WaitForSeconds(time);
        _onRightAction.Invoke();
    }
}
