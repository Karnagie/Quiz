using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cell data", menuName = "Cell data")]
public class CellData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;

    public Sprite Sprite => _sprite;
    public string Name => _name;
}
