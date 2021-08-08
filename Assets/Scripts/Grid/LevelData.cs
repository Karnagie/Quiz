using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _rowCount;
    [SerializeField] private int _columnCount;

    public int RowCount => _rowCount;
    public int ColumnCount => _columnCount;
}
