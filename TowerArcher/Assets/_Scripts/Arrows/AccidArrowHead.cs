using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidArrowHead : ArrowHead
{
    public int duration=5;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IDmgOverTime dmgOver = collision.gameObject.GetComponent<IDmgOverTime>();
        if (dmgOver != null)
        {
            dmgOver.DmgOverTime(duration);

        }
        Destroy(gameObject);

    }
}
