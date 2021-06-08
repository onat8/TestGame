using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceParent : MonoBehaviour
{
    bool fractureControl;

   
    void Update()
    {
        if(Level.instance.playMode == Level.PlayMode.LOSE && !fractureControl)
        {
            
            fractureControl = true;
            Invoke(nameof(GetPiece),0.2f);
        }
    }


    void GetPiece()
    {
        Level.instance.ShakeCamera(5f, 0.7f);
        foreach ( Transform piece in transform.GetChild(0))
        {

            Rigidbody rb = piece.GetComponent<Rigidbody>();
            rb.mass = 0.1f;
            rb.AddExplosionForce(5000f,piece.transform.position,100f);
            rb.useGravity = false;
        }

    }
}
