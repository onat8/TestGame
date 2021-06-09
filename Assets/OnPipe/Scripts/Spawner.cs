using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPooling pipePool;
    public ObjectPooling obstaclePool;
    public ObjectPooling cornPool;
    
    public GameObject player;
    public GameObject smallpipe;
    public GameObject winPipe;
    public float distant;
    public ObjectPooling obsCheck;
    public bool functionCalled = false;
    
    
    void Start()
    {
        if (Level.instance.playMode == Level.PlayMode.NOT_STARTED)
        {
            PipeSpawner();
        }
        
    }

    
    void Update()
    {

        distant = transform.position.z - player.transform.position.z;

        if(distant <= 30f && ( Level.instance.playMode == Level.PlayMode.STARTED || Level.instance.playMode == Level.PlayMode.NOT_STARTED))
        {
            
            if (Level.instance.playMode == Level.PlayMode.STARTED)
            {
                ObstacleSpawner();
            }
            else
            {
                PipeSpawner();
            }


        }
        else if (Level.instance.playMode == Level.PlayMode.END)
        {
            Debug.Log("End");
            Win();
        }



    }

    public void PipeSpawner()
    {
        GameObject pipe = pipePool.GetPooledObject();
        pipe.SetActive(true);

        foreach (Transform cornParent in pipe.transform)
        {
            if (cornParent.gameObject.CompareTag("Corn"))
            {
                foreach (Transform corn in cornParent.transform)
                {
                    corn.gameObject.SetActive(true);
                }
            }
            
        }
        //pipe.transform.parent = transform;
        pipe.transform.position = transform.position;
        transform.position += Vector3.forward * 40f;

    }

    void ObstacleSpawner()
    {
        GameObject pipe = obstaclePool.GetPooledObject();
        pipe.SetActive(true);
        foreach (Transform cornParent in pipe.transform)
        {
            if (cornParent.gameObject.CompareTag("Corn"))
            {
                foreach (Transform corn in cornParent.transform)
                {
                    corn.gameObject.SetActive(true);
                }
            }

        }
        //pipe.transform.parent = transform;
        pipe.transform.position = transform.position;
        transform.position += Vector3.forward * 40f;

    }

    void Win()
    {
        winPipe.transform.position = transform.position;


    }
}
