using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IDamageable,IFreezable
{

    public int hp;
    public int destruction;
    public float speed;
    

    public ParticleSystem blood;
    protected Rigidbody2D body;
    protected Animator anim;
    protected SpriteRenderer[] sprites;
    protected bool isSlowed;
    protected bool isFrozen;
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
        anim = GetComponent<Animator>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CloseEnough();
    }
    public virtual bool CloseEnough()
    {
        RaycastHit2D info = Physics2D.Raycast(transform.position, Vector2.right, 2);
        if (info.transform.gameObject.layer == 10)
        {
            Debug.Log("Asd");
            anim.SetBool("closeEnough", true);
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void Die()
    {
        
        Destroy(gameObject);
    }
    protected abstract void Attack();

    public void SlownDown()
    {
        if(!isSlowed)
        {
            speed *= 0.5f;
            isSlowed = true;
            foreach (var sr in sprites)
            {
                sr.color = Color.cyan;
            }

        }
        
    }

    public void Freze()
    {
        if (!isFrozen)
        {
            speed = 0;
            isFrozen = true;
            foreach (var sr in sprites)
            {
                sr.color = Color.blue;
            }
        }
        
    }
}
