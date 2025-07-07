using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Object
{
    
    private float resetLocation = 35.6f;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

     protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
        base.Update();
        }
        

    }

    

     void OnTriggerEnter ()
     {
        GameManager.instance.AddPoint ();
        Vector3 newPos = new Vector3(resetLocation, transform.position.y, transform.position.z);
            transform.position = newPos;
     }
}
