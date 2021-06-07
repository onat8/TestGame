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
    public GameObject player;
    public ParticleSystem flyCorn;
    
    // Start is called before the first frame update
    void Start()
    {
        scale = 2f;
        flyCorn.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            mouse = true;
            transform.DOScale(scale, 0.1f).SetEase(Ease.Linear);
        }
        else
        {
            mouse = false;
            transform.DOScale(2f, 0.1f).SetEase(Ease.Linear);
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
                    
                    Level.instance.SetMode(Level.PlayMode.LOSE);
                    player.SetActive(false);
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
          
                Level.instance.SetMode(Level.PlayMode.LOSE);
                player.SetActive(false);
            }
        }

        if (other.CompareTag("ObstacleInside"))
        {
            if(mouse)
            {
                
                Level.instance.SetMode(Level.PlayMode.LOSE);
                player.SetActive(false);
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
        
        flyCorn.Play();
        
        cornCount++;

    }

}
