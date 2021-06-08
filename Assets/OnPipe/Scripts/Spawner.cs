﻿using System.Collections;
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
        
        //transform.position = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        distant = transform.position.z - player.transform.position.z;

        if(distant <= 30f)
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

        for (int i = 0; i <= 2; i++)
        {

            GameObject pipe = pipePool.GetPooledObject();
            pipe.SetActive(true);
            
            //pipe.transform.parent = transform;
            pipe.transform.position = transform.position;
            transform.position += Vector3.forward * 40f;
        }
        

        
    

}

    /*void CornSpawner()
    {
        

        for (int i = 0; i <= 4; i++)
        {
            GameObject corn = cornPool.GetPooledObject();
            corn.SetActive(true);

            corn.transform.position = transform.position;

            float rcorn = Random.Range(0, 10);
            float mcorn = rcorn / 10;
            Debug.Log(mcorn);
            corn.transform.position += Vector3.forward * rcorn;
        }
        

    }*/

    

    void ObstacleSpawner()
    {

    }
}
