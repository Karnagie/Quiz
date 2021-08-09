using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private float _delay;

    public void LoadLevel(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(AsyncLoad(sceneIndex));
    }

    private IEnumerator AsyncLoad(int sceneIndex)
    {
        yield return new WaitForSeconds(_delay);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
