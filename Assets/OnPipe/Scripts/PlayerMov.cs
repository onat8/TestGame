using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMov : MonoBehaviour
{
    public float speed;
    


    public Vector3 scale;
    public bool mouse;
    public float cornCount;
    public ObjectPooling objPool;
    public GameObject corn;
    public GameObject player;
    public float cornSlider;
    
    
    void Start()
    {
        scale = new Vector3(1.4f, 0.8f, 1.4f);
        
        
        

    }

    //Small scale with click
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
            transform.DOScale(new Vector3(1.4f, 0.8f, 1.4f), 0.1f).SetEase(Ease.Linear);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            if (mouse)
            {
                if (scale.x == 0.65f)
                {
                    
                    Level.instance.SetMode(Level.PlayMode.LOSE);
                   
                }
            }
            else
            {
                //Large pipe big scale
                scale = new Vector3(1f, 0.8f, 1f);

            }
        }

        if (other.CompareTag("SPipe"))
        {
            //Small pipe small scale
            scale = new Vector3(0.65f, 0.8f, 0.65f);
        }

        if (other.CompareTag("Obstacle"))
        {
            if(mouse == false)
            {
          
                Level.instance.SetMode(Level.PlayMode.LOSE);
                
            }
        }

        if (other.CompareTag("ObstacleInside"))
        {
            if(mouse)
            {
                
                Level.instance.SetMode(Level.PlayMode.LOSE);
                
            }
        }

        if (other.CompareTag("Corn"))
        {
            if (mouse)
            {
                other.gameObject.SetActive(false);
                CollectCorn();
            }
            
            

        }
    }
    //If 
    void CollectCorn()
    {
        GameObject flyCorn = objPool.GetPooledObject();
        flyCorn.SetActive(true);
        flyCorn.transform.parent = transform;
        flyCorn.transform.localPosition = Vector3.down;

        if (cornCount >= 0 && cornCount < 63)
        {
            cornSlider = cornSlider + 0.0002f;
        }else if(cornCount >= 63 && cornCount < 84){
            cornSlider = (cornSlider + 0.0003f) * 2;
        }else if(cornCount >= 84 && cornCount < 105)
        {
            cornSlider = (cornSlider + 0.0003f) * 3;
        }
        

        GameManager.instance.slider.fillAmount += cornSlider;

    }

    

}
