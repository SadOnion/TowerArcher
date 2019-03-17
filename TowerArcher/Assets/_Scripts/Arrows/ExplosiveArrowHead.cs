using System;
using UnityEngine;

public class ExplosiveArrowHead : ArrowHead,ISkill
{
    public float explosionRadius = 1f;
    public int extraDmg = 5;
    public ParticleSystem explosion;
    private bool isUsed;
    private GameObject oldArrow;
    public void UseSkill()
    {
        if (player == null) {

            player = GameManager.Instance.player;
            player.bowObject.ShotFire += SkillUsed;
        }
        oldArrow = player.arrow.baseArrowPrefab;
        
        player.arrow.baseArrowPrefab = arrowPrefab;
        
        isUsed = true;
    }
    private void SkillUsed(object sender,EventArgs e)
    {
        if (isUsed)
        {
            player.arrow.baseArrowPrefab = oldArrow;
            
            isUsed = false;
        }
    }
    protected override void  Start()
    {
        base.Start();
        player.bowObject.ShotFire += SkillUsed;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
       RaycastHit2D[]  info = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);
        Instantiate(explosion, transform.position, Quaternion.identity);
        foreach (var item in info)
        {
            IDamageable damageable = item.transform.gameObject.GetComponent<IDamageable>();
            if (damageable != null) damageable.TakeDamage(player.bow.dmg+extraDmg);
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
