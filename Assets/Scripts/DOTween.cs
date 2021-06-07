using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTween : MonoBehaviour

    
{
    [SerializeField]
    private Vector3 _targetLocation = Vector3.zero;

    private float _moveDirection = 1.0f;

    private Ease _moveEase = Ease.Linear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
