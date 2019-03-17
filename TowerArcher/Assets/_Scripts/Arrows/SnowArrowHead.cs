using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowArrowHead : ArrowHead
{
    [Range(0,100)]
    public int frezeChance=5;
    [Range(0, 100)]
    public int slowChance = 50;
    public int slowDuration = 5;
    
    public int frezeDuration = 5;

   

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (freezable != null)
        {
            damageable.TakeDamage(player.bow.dmg);
            int rand = Random.Range(1, 100);
            if(rand < slowChance)
            {
                freezable.SlownDown(slowDuration);
            }
            if(rand < frezeChance)
            {
                freezable.Freze(frezeDuration);
            }

        }
        Destroy(gameObject);

    }


}
