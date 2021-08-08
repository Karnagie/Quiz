using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : Effect
{
    protected override void InitializeEffect()
    {
        GetComponent<Text>().DOFade(1,1);
    }
}
