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
    private CellQueue<Sprite> _queue;
    private int answerId;
    private int levelId;

    private void Start()
    {
        _currentBundle = _cellBundles[Random.Range(0, _cellBundles.Length)];
        Sprite[] sprites = new Sprite[_currentBundle.Cells.Length];
        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = _currentBundle.Cells[i].Sprite;
        }
        _queue = new CellQueue<Sprite>(sprites);
        _queue.Shuffle();
        NextLevel();
    }

    private void NextLevel()
    {
        if(levelId >= _levels.Length)
        {
            _levelUI.EndLevel();
            return;
        }
        _gridSpawner.Spawn(_levels[levelId], _queue.ToArray(), answerId, () => { NextLevel(); });
        SetTask(_currentBundle.Cells[_queue.GetNativeId()].Name);
        _queue.GetNext();
        answerId = _queue.Id;
        levelId++;
    }

    private void SetTask(string name)
    {
        _levelUI.ChangeTask($"Find {name}");
    }

}