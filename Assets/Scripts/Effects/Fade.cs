using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpriteFade : Effect
{
    [SerializeField] private float _endValue = 1;
    [SerializeField] private float _duration = 1;

    protected override void InitializeEffect()
    {
        GetComponent<SpriteRenderer>().DOFade(_endValue, _duration);
    }
}
