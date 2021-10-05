using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Material green;
    public Material red;
    public Material black;
    public Rigidbody rb;
    public int speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime) ,
                transform.position.y + transform.position.z);
        }
    }
}
