using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingScreen;
    [SerializeField] Image slider;
    public static LoadingManager instance;


    private void Awake()
    {
        instance = this;
    }

    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        slider.DOFillAmount(1f, 1.5f).OnComplete(() =>
        {

            StartCoroutine(LoadAsynchronously(sceneIndex));

            loadingScreen.SetActive(false);
        });
    }



    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level "+sceneIndex,LoadSceneMode.Additive);

        
      
        while(!operation.isDone)
        {

            yield return null;
        }

        
    }
}
