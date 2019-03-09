using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{


    // Update is called once per frame
    protected override void Update()
    {
        body.velocity = Vector2.right * speed * Time.deltaTime;
    }
}
