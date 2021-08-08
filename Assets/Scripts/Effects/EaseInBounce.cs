using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseInBounce : Effect
{
    [SerializeField] private float _duration = 1;
    [SerializeField] private Vector3 _strength = new Vector3(1, 0, 0);
    [SerializeField] private int _vibrato = 5;
    [SerializeField] private float _randomness = 0;
    [SerializeField] private bool _snapping = false;
    [SerializeField] private bool _fadeOut = true;

    private float time;

    protected override void InitializeEffect()
    {
        if (time > Time.time) return;
        Tweener t = transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
        time = Time.time + t.Duration();
    }
}
