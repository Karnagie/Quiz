using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public void Invoke()
    {
        InitializeEffect();
    }

    protected abstract void InitializeEffect();
}
