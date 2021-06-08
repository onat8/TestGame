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
    public float distant;
    // Start is called before the first frame update
    void Start()
    {
        PipeSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        distant = transform.position.z - player.transform.position.z;

        if(distant <= 10)
        {
            PipeSpawner();
        }

        //if(Level.instance.playMode == Level.PlayMode.STARTED)
        //{
            //ObstacleSpawner();
        //}
    }

    public void PipeSpawner()
    { 

        
         GameObject pipe = pipePool.GetPooledObject();
         pipe.SetActive(true);
        pipe.transform.parent = transform;
         pipe.transform.position = transform.position;
        
         transform.position += Vector3.forward * 30f;

        
    }

    void CornSpawner()
    {
        GameObject corn = cornPool.GetPooledObject();
        corn.SetActive(true);


    }

    void ObstacleSpawner()
    {

    }
}
