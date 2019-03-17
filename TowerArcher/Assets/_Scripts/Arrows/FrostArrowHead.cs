using System;
using UnityEngine;

public class FrostArrowHead : ArrowHead
{
    public int duration=5;
   
   
    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (freezable != null)
        {
            damageable.TakeDamage(player.bow.dmg);
            freezable.Freze(duration);

        }
        Destroy(gameObject);

    }
}
