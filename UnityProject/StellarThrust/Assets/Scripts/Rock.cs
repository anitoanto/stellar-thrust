using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.rotation = Random.rotation;
        Destroy(gameObject,Random.Range(90,150));
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Random.Range(-9,-2),0,0);
    }
}
