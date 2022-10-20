using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
     void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
