using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Object
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 bottomPosition;
    [SerializeField] private float rockSpeed = 2.5f;
    private float rotationSpeed = -25.0f;
    
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Move (bottomPosition));
    }

    protected override void Update()
    {
        
        if (GameManager.instance.PlayerActive)
        {
        base.Update();
        }


       
       
    }

  

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.50f)
        {
            
            //ternary expression that has 3 parts. this says "a new Vector3 named diretion is equal to Vector 3 up if target y is equal to topPosition y oyherwise it is equal to Vector3 down".
            Vector3 direction = target.y == topPosition.y ? Vector3.up  : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * rockSpeed;
            
            
            yield return null;
        }

        

        yield return new WaitForSeconds (0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine (Move (newTarget));
    }
    
}
