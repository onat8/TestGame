using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinAnim : MonoBehaviour
{
    float angle;
    private void Update()
    {
        angle+= Random.Range(0,3);
        angle = angle % 360;
        transform.rotation = Quaternion.Euler(new Vector3(angle,90,90));
    }
}