using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLogic : MonoBehaviour
{
    [SerializeField] private CellBundleData[] _cellBundles;
    [SerializeField] private LevelData[] _levels;
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] private LevelUI _levelUI;

    private CellBundleData _currentBundle;
    private CellQueue<Sprite> _cellSprites;
    private int _answerId;
    private int _levelId;

    private void Start()
    {
        _currentBundle = _cellBundles[Random.Range(0, _cellBundles.Length)];
        Sprite[] sprites = new Sprite[_currentBundle.Cells.Length];
        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = _currentBundle.Cells[i].Sprite;
        }
        _cellSprites = new CellQueue<Sprite>(sprites);
        _cellSprites.Shuffle();
        NextLevel();
    }

    private void NextLevel()
    {
        if(_levelId >= _levels.Length)
        {
            _levelUI.EndLevel();
            return;
        }
        _gridSpawner.Spawn(_levels[_levelId], _cellSprites.ToArray(), _answerId, () => { NextLevel(); });
        SetTask(_currentBundle.Cells[_cellSprites.GetNativeId()].Name);
        _cellSprites.GetNext();
        _answerId = _cellSprites.Id;
        _levelId++;
    }

    private void SetTask(string name)
    {
        _levelUI.ChangeTask($"Find {name}");
    }

}