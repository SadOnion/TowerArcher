using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{

    Archer player;
    SpriteRenderer spriteRenderer;
    ArrowProperties properties;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        spriteRenderer = GetComponent<SpriteRenderer>();
        properties = player.arrow.arrowProperties;
        spriteRenderer.sprite = properties.sprite;
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(player.bow.dmg);
            
        }
        Destroy(gameObject);
    }
}
