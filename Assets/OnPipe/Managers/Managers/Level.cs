using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;




public class Level : MonoBehaviour
{
    public PlayMode playMode;
    public static Level instance;
    public PlayerMov player;

    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    public CinemachineVirtualCamera cm;

    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startIntensity;

    public enum PlayMode
    {
        NOT_STARTED,
        STARTED,
        LOSE,
        FINISH,
        
    }

    public Scene scene
    {
        get
        {
            if (this == null || gameObject == null)
            {
                return SceneManager.GetActiveScene();
            }

            return gameObject.scene;
        }
    }

    private void Awake()
    {
        
        instance = this;

        if (GameManager.instance == null)
        {
            Debug.Log("GameManager isnt loaded. Trying to load");
            SceneManager.LoadSceneAsync("ManagerScene", LoadSceneMode.Additive).completed += (op) =>
               {
                   GameManager.instance.OnLevelEnabled();

               };
        }
        else
        {
            GameManager.instance.OnLevelEnabled();
        }

        StartCoroutine(SetSceneActive());

        _cinemachineBasicMultiChannelPerlin = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    IEnumerator SetSceneActive()
    {
        yield return new WaitUntil(() => SceneManager.GetSceneByName(scene.name).isLoaded);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.name));
        yield return null;
    }

    public void ShakeCamera(float intensity, float timer)
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _shakeTimer = timer;
        _shakeTimerTotal = timer;
        _startIntensity = intensity;
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(_startIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));
        }
    }

    void Start()
    {
        //Level.instance.SetMode(PlayMode.LOSE);

    }

  

    public void SetMode(PlayMode playMode)
    {
        this.playMode = playMode;
        //Debug.Log("playmode is " + playMode);
        switch (playMode)
        {
            case PlayMode.NOT_STARTED:
               
                break;
            case PlayMode.STARTED:
              
                break;
           
            case PlayMode.FINISH:

               
                break;
           

            case PlayMode.LOSE:
                player.speed = 3f;
                GameManager.instance.LosePanel();
                
                
                break;
          

        }

    }

   

}
