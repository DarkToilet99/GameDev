using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnRate = 2;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        if( timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnZombie();
            timer = 0;
        }
    }

    void spawnZombie()
    {
        Instantiate(zombie, transform.position, transform.rotation);
    }
}
