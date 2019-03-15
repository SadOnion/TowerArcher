using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IDamageable,IFreezable,IDmgOverTime
{

    public int hp;
    public int destruction;
    public float speed;
    protected int frozenBonus=1;
    protected bool isSlowed;
    protected bool isFrozen;
    protected bool dmgOverTime;
    public ParticleSystem blood;
    protected Rigidbody2D body;
    protected Animator anim;
    protected SpriteRenderer[] sprites;
    protected float currentSpeed;
    protected Archer player;
    public virtual void TakeDamage(int amount)
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        hp -= amount*frozenBonus;
        if (hp <= 0) Die();
    }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
        currentSpeed = speed;
        player = GameManager.Instance.player;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    
    public virtual void Die()
    {
        
        Destroy(gameObject);
    }
    protected abstract void Attack();

    public void SlownDown(int duration)
    {
        if (!isSlowed)
        {
            StartCoroutine(Slownes(duration));
        }
    }
    private IEnumerator Slownes(int duration)
    {
        isSlowed = true;
        currentSpeed *= 0.5f;
        foreach (var item in sprites)
        {
            item.color = Color.cyan;
        }
        yield return new WaitForSeconds(duration);
        foreach (var item in sprites)
        {
            item.color = Color.white;
        }
        currentSpeed = speed;
        isSlowed = false;
    }
    private IEnumerator Frozen(int duration)
    {
        isFrozen = true;
        currentSpeed =0;
        frozenBonus = 2;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        frozenBonus = 1;
        isFrozen = false;
    }
    

    public void Freze(int duration)
    {
        if (!isFrozen)
        {
            StartCoroutine(Frozen(duration));
        }
        
        
    }

    public void DmgOverTime(int duration)
    {
        if (!dmgOverTime)
        {
            StartCoroutine(TimedDmg(duration));
        }
    }
    private IEnumerator TimedDmg(int duration)
    {
        dmgOverTime = true;
        for (int i = 0; i < duration; i++)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(1);
        }
        dmgOverTime = false;
    }
}
