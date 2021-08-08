using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cell bundle data", menuName = "Cell bundle data")]
public class CellBundleData : ScriptableObject
{
    [SerializeField] private CellData[] _cells;
    public CellData[] Cells => _cells;
}
