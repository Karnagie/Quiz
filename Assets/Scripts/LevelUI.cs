using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Text _task;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private LevelLoader _levelLoader;

    public void ChangeTask(string text)
    {
        _task.text = text;
    }

    public void EndLevel()
    {
        _endScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        _levelLoader.LoadLevel(0);
    }
}
