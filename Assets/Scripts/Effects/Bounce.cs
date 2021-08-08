using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : Effect
{
	[SerializeField] private float _bounceHeight = 1;
	[SerializeField] private float _bounceTime = 1;

	protected override void InitializeEffect()
    {
		transform
				.DOMoveY(transform.position.y + _bounceHeight, _bounceTime / 2)
				.SetDelay(_bounceTime / 2)
				.SetEase(Ease.OutQuad)
				.OnComplete(() =>
				{
					transform
						.DOMoveY(transform.position.y - _bounceHeight, _bounceTime / 2)
						.SetEase(Ease.InQuad);
				});
	}
}
