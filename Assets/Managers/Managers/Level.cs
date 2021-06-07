using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;




public class Level : MonoBehaviour
{
    public PlayMode playMode;
    public static Level instance;
   

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

    }

    IEnumerator SetSceneActive()
    {
        yield return new WaitUntil(() => SceneManager.GetSceneByName(scene.name).isLoaded);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.name));
        yield return null;
    }

    void Start()
    {
        Level.instance.SetMode(PlayMode.LOSE);

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

                GameManager.instance.LosePanel();
                break;
          

        }

    }

   

}
