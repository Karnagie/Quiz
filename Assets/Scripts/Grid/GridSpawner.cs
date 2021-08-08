using DG.Tweening;
using System;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GridTransform _gridTransorm;

    private GameObject[] cells;

    public void Spawn(LevelData levelData, Sprite[] cellSprites, int answerId, Action onWin)
    {
        if(cells != null)
        {
            foreach (GameObject cell in cells)
            {
                cell.transform.DOKill();
                Destroy(cell);
            }
        }
        cells = CreateCells(levelData, cellSprites, answerId);
        cells[0].GetComponent<Cell>().SetWinAction(onWin);
        _gridTransorm.SetGrid(levelData.RowCount, levelData.ColumnCount, cells);
    }

    private GameObject[] CreateCells(LevelData levelData, Sprite[] cellSprites, int answerId)
    {
        GameObject[] cells = new GameObject[levelData.RowCount * levelData.ColumnCount];
        cells[0] = CreateCell(cellSprites[answerId], true);
        for (int i = 1; i < cells.Length; i++)
        {
            cells[i] = CreateCell(cellSprites[(i+answerId) % cellSprites.Length], false);
        }
        return cells;
    }

    private GameObject CreateCell(Sprite sprite, bool isRight)
    {
        GameObject cell = Instantiate(_cellPrefab, transform);
        cell.GetComponent<Cell>().SetData(sprite, isRight);
        return cell;
    }
}
