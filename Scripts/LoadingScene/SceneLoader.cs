using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set;}

    public GameObject LoadingScene;
    public Slider Slider;
    public TMPro.TextMeshProUGUI LoadPercent;

    private void Awake() {
        if (Instance == null)
            Instance = this;
    }
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScene.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Slider.value = progress;
            LoadPercent.text = progress * 100f + "%";
            yield return null;
        }
        yield return null;
    }

}
