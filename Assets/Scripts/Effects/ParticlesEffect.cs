using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesEffect : Effect
{
    [SerializeField] private GameObject _particles;

    protected override void InitializeEffect()
    {
        Instantiate(_particles, transform.position, transform.rotation);
    }
}
