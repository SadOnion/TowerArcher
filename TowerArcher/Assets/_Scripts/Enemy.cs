using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IDamageable
{

    public int hp;
    public float speed;
    
    public ParticleSystem blood;
    protected Rigidbody2D body;

    public virtual void TakeDamage(int amount)
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        hp -= amount;
        if (hp <= 0) Die();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    public virtual void Die()
    {
        
        Destroy(gameObject);
    }
}
