using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript1 : MonoBehaviour

{
    public Rigidbody rb;
    public Transform chController;
    bool inside = false;
    public float speedUpDown = 3.2f;
    public static bool stopPlayerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stopPlayerInput = FindObjectOfType<PlayerController>().canMove;
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
           stopPlayerInput = true;
            rb.useGravity = false;
            stopPlayerInput = false;
            inside = !inside;
           
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            stopPlayerInput = false;
            rb.useGravity = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (inside == true && ( Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)))
        {
            chController.transform.position += Vector3.up * speedUpDown* Time.deltaTime;
        }

        if (inside == true && (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)))
        {
            chController.transform.position += Vector3.down *speedUpDown * Time.deltaTime;
        }
    }

}