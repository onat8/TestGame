using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject spipe01;
    public GameObject spipe02;
    public GameObject lpipe01;
    public GameObject lpipe02;
    public GameObject lpipe03;
    public GameObject lopipe01;
    public GameObject lopipe02;
    public GameObject lopipe03;
    public GameObject lopipe04;
    public GameObject sopipe01;
    
    public bool pipe;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject grave = GameObject.FindGameObjectWithTag("Grave");
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            if (pipe)
            {
                
                
                    int chance = Random.Range(0, 5);

                    switch (chance)
                    {
                        default:
                            objectToPool = lpipe01;
                            break;
                        case 1:
                            objectToPool = spipe01;
                            break;
                        case 2:
                            objectToPool = lpipe02;
                            break;
                        case 3:
                            objectToPool = lpipe03;
                            break;
                        case 4:
                            objectToPool = spipe02;
                            break;
                    }
                

                
                    int obchance = Random.Range(0, 4);

                    switch (obchance)
                    {
                        default:
                            objectToPool = lopipe01;
                            break;
                        case 1:
                            objectToPool = lopipe02;
                            break;
                        case 2:
                            objectToPool = lopipe03;
                            break;
                        case 3:
                            objectToPool = lopipe04;
                            break;
                        case 4:
                            objectToPool = sopipe01;
                            break;

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

