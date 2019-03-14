using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostArrowHead : ArrowHead
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
        if (freezable != null)
        {
            int rand = Random.Range(0, 100);
            if(rand > 50)
            {
                freezable.SlownDown();
            }
            if(rand > 95)
            {
                freezable.Freze();
            }

        }
        Destroy(gameObject);

    }


}
