using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CellEffector : MonoBehaviour
{
    [SerializeField] protected UnityEvent _onStartEvent;
    [SerializeField] private UnityEvent _onFailEvent;
    [SerializeField] private UnityEvent _onRightEvent;
    [SerializeField] private GridLogic _logic;
    [SerializeField] private float _delay = 1;

    private Action onRight;

    protected void Start()
    {
        _onStartEvent.Invoke();
    }

    public void Invoke()
    {
        if (onRight != null)
        {
            StartCoroutine(Delay(_delay));
        }
        else _onFailEvent.Invoke();
    }

    public void SetActionOnRight(Action action)
    {
        onRight = action;
    }

    private IEnumerator Delay(float time)
    {
        _onRightEvent.Invoke();
        yield return new WaitForSeconds(time);
        onRight.Invoke();
    }
}
