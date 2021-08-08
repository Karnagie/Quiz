using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : Effect
{
    [SerializeField] private float _endValue = 1;
    [SerializeField] private float _duration = 1;

    protected override void InitializeEffect()
    {
        GetComponent<Image>().DOFade(_endValue, _duration);
    }
}
