using System;
using UnityEngine;

public class FrostArrowHead : ArrowHead,ISkill
{
    public int duration=5;
    private GameObject oldArrow;
    private bool isUsed;
    public void UseSkill()
    {
        if (player == null)
        {

            player = GameManager.Instance.player;
            player.bowObject.ShotFire += SkillUsed;
        }
        oldArrow = player.arrow.baseArrowPrefab;

        player.arrow.baseArrowPrefab = arrowPrefab;

        isUsed = true;
    }
    private void SkillUsed(object sender, EventArgs e)
    {
        if (isUsed)
        {
            player.arrow.baseArrowPrefab = oldArrow;
            isUsed = false;
        }
    }
    

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
