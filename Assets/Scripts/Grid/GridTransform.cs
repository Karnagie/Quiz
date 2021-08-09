using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTransform : MonoBehaviour
{
    [SerializeField] private float _cellMargin = 1;
    [SerializeField] private float _cellSize = 1;
    [SerializeField] private GameObject _background;
    [SerializeField] private float _backgroundBorder =1;

    private Vector3 _defaultSize;

    private void Start()
    {
        _defaultSize = _background.transform.localScale;
    }

    public void SetGrid(int xCells, int yCells, GameObject[] cells)
    {
        CellQueue<GameObject> mixedCells = new CellQueue<GameObject>(cells);
        mixedCells.Shuffle();

        _background.transform.localScale = _defaultSize;
        float cellSize = (_cellSize + _cellMargin);
        SetBackgroundSize(xCells, yCells, cellSize);

        for (int i = 0; i < yCells; i++)
        {
            for (int n = 0; n < xCells; n++)
            {
                GameObject g = mixedCells.GetNext();
                g.transform.position = CalculatePosition(xCells, yCells, n, i, cellSize);
            }
        }
    }

    private void SetBackgroundSize(int xCells, int yCells, float cellSize)
    {
        Vector3 backgroundScale = _background.transform.localScale;
        backgroundScale.x *= xCells * cellSize + _backgroundBorder;
        backgroundScale.y *= yCells * cellSize + _backgroundBorder;
        _background.transform.localScale = backgroundScale;
    }

    private Vector3 CalculatePosition(int rows, int columns, int x, int y, float  cellSize)
    {
        Vector3 position = new Vector3();
        position.x = CalculateAxis(rows, x, cellSize);
        position.y = CalculateAxis(columns, y, cellSize);
        
        return position;
    }

    private float CalculateAxis(int line, int axis, float cellSize)
    {
        float lengthx = line * cellSize;
        float nextCellX = (lengthx / line) * axis;
        return nextCellX - (cellSize / 2 * (line - 1));
    }
}
