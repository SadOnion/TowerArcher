using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float rot_z = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;





        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
