using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject spipe;
    public GameObject lpipe;
    public bool pipe;
    public bool corn;
    public GameObject corn1LargePipe;
    public GameObject cornSmallPipe;
    public PlayerMov checkPipe;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject grave = GameObject.FindGameObjectWithTag("Grave");
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            if (pipe)
            {
                int chance = Random.Range(0, 4);
                Debug.Log(chance);
                if (chance < 2)
                {
                    objectToPool = spipe;
                }
                else if (chance >= 2)
                {
                    objectToPool = lpipe;
                }


            }

            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.transform.parent = grave.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    



    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

}

