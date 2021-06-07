using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMov : MonoBehaviour
{
    public float speed;
    


    public float scale;
    public bool mouse;
    public int cornCount;
    public ObjectPooling objPool;
    public GameObject corn;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = 2f;

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            mouse = true;
            transform.DOScale(scale, 0.3f).SetEase(Ease.Linear);
        }
        else
        {
            mouse = false;
            transform.DOScale(2f, 0.3f).SetEase(Ease.Linear);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            if (mouse)
            {
                if (scale == 0.65f)
                {
                    Debug.Log("die");
                }
            }
            else
            {
                scale = 1f;
            }
        }

        if (other.CompareTag("SPipe"))
        {
            scale = 0.65f;
        }

        if (other.CompareTag("Obstacle"))
        {
            if(mouse == false)
            {
                Debug.Log("Die");
            }
        }

        if (other.CompareTag("ObstacleInside"))
        {
            if(mouse)
            {
                Debug.Log("Die");
            }
        }

        if (other.CompareTag("Corn"))
        {
            if (mouse)
            {
                CollectCorn();
            }

        }
    }

    void CollectCorn()
    {
        corn.SetActive(false);
        cornCount++;
    }

}
