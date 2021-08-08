using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTime : MonoBehaviour
{
    [SerializeField] private float _timer = 5;
    private void Start()
    {
        StartCoroutine(Dying(_timer));
    }

    private IEnumerator Dying(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
