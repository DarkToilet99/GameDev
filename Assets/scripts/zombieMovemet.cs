using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMovemet : MonoBehaviour 
{
    public float speed = 5;
    public float deadZone = -30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
