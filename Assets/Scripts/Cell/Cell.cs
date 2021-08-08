using System;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private CellEffector _effector;

    private bool _isRight;
    private Action _onRightAction;

    public void SetData(Sprite sprite, bool isRight)
    {
        _image.sprite = sprite;
        _isRight = isRight;
    }

    private void OnMouseDown()
    {
        if(_isRight)_effector.SetActionOnRight(_onRightAction);
        _effector.Invoke();
    }

    public void SetWinAction(Action action)
    {
        _onRightAction = action;
    }
}
