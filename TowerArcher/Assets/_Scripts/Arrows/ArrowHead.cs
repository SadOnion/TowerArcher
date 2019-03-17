using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{
    
    protected Archer player;
    protected SpriteRenderer spriteRenderer;
    protected ArrowProperties properties;
    public GameObject arrowPrefab;

    protected virtual IEnumerator ChangeArrows(float duration)
    {
        if(player == null)
        {
            player = GameManager.Instance.player;
        }
        GameObject oldArrows = player.arrow.baseArrowPrefab;
        player.arrow.baseArrowPrefab = arrowPrefab;
        Debug.Log("asda");
        yield return new WaitForSeconds(duration);
        player.arrow.baseArrowPrefab = oldArrows;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
       
        player = GameManager.Instance.player;
        spriteRenderer = GetComponent<SpriteRenderer>();
        properties = player.arrow.arrowProperties;
        spriteRenderer.sprite = properties.sprite;

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(player.bow.dmg);
            
        }
        Destroy(gameObject);

    }
}
