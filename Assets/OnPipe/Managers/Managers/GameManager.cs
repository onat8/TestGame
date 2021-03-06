using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameView;

    public Image slider;
    [SerializeField] List<Scene> Levels;
    [SerializeField] Text levelText;
    public TextMeshProUGUI woodCount;

    public GameObject winPanel;
    public GameObject losePanel;
    [SerializeField] GameObject startbutton;
    public Image levelBar;
    public PlayerMov pslider;


    void Awake()
    {
        instance = this;

        if (PlayerPrefs.GetInt("v1") != 1)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("v1", 1);

        }
        if (Level.instance == null && SceneManager.sceneCount == 1)
        {
            try
            {
                LoadingManager.instance.LoadLevel(DataManager.PlayerData.Level);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                int level_count = UnityEngine.Random.Range(2, Levels.Count);

                DataManager.PlayerData.Level = level_count;
                LoadingManager.instance.LoadLevel(level_count);
            }
        }

    }



    public void OnLevelEnabled()
    {
        startbutton.SetActive(true);
        slider.fillAmount = 0;
        LoadingManager.instance.loadingScreen.SetActive(false);

        levelBar.fillAmount = 0;
        gameView.gameObject.SetActive(true);

        levelText.text = DataManager.GameData.Level_id.ToString();
        Level.instance.SetMode(Level.PlayMode.NOT_STARTED);



    }

    public void NextStage()
    {
        DataManager.GameData.Level_id++;

        if (DataManager.PlayerData.Level < Levels.Count)
        {
            DataManager.PlayerData.Level++;
        }
        else
        {
            int level_count = UnityEngine.Random.Range(1, Levels.Count);
            DataManager.PlayerData.Level = level_count;
        }

        SceneManager.UnloadSceneAsync(Level.instance.scene).completed += (op) =>
         {
             SceneManager.LoadSceneAsync("Level " + DataManager.PlayerData.Level, LoadSceneMode.Additive).completed += (op2) =>
             {


                 losePanel.SetActive(false);
                 winPanel.SetActive(false);

             };

         };
    }

    public void CSlider()
    {
        
        
    }

    public void Restart()
    {
        SceneManager.UnloadSceneAsync(Level.instance.scene).completed += (op) =>
        {
            SceneManager.LoadSceneAsync("Level " + DataManager.PlayerData.Level, LoadSceneMode.Additive).completed += (op2) =>
            {
                losePanel.SetActive(false);
                winPanel.SetActive(false);
            };

        };
    }
    public void WinPanel()
    {
        gameView.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(true);
    }
    public void LosePanel()
    {
        gameView.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        Level.instance.SetMode(Level.PlayMode.STARTED);
        startbutton.SetActive(false);
    }
}
