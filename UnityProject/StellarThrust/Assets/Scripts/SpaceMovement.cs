using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 30;i++) {
            Instantiate(rock, new Vector3(Random.Range(-60, 80), Random.Range(-30, 60), Random.Range(5, 20)), Quaternion.identity);
        }
        InvokeRepeating("CreateRocks",0,4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRocks()
    {
        for(int i = 0;i < 10;i++) {
            Instantiate(rock, new Vector3(Random.Range(70, 100), Random.Range(-30, 60), Random.Range(0, 20)), Quaternion.identity);
        }
    }
}
