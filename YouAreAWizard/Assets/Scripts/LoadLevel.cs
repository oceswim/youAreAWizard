/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	public GameObject loadingScreen;
	public Slider slider;
    public TMP_Text percentage;

    private void Update()
    {
        if(PlayerPrefs.HasKey("changeScene"))
        {
            LoadtheLevel(PlayerPrefs.GetString("changeScene"));
            PlayerPrefs.DeleteKey("changeScene");
        }
    }
    public void LoadtheLevel(string sceneName)
    {
        loadingScreen.SetActive(true);
        
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    private IEnumerator LoadAsynchronously(string theScene)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(theScene);
        while(!operation.isDone)
        { 
            UpdateProgressUI(operation.progress);
            yield return null;
        }
        UpdateProgressUI(operation.progress);
        
    }
    private void UpdateProgressUI(float theProgress)
    {
        slider.value = theProgress;
        percentage.text = (int)(theProgress * 100f) + "%";
    }
}
