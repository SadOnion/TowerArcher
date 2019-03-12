using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{
    protected override void Attack()
    {
        
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        body.velocity = Vector2.right * speed * Time.deltaTime;
    }
    
}
