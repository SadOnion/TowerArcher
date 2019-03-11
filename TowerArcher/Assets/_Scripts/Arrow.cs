using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject baseArrowPrefab;
    public ArrowProperties arrowProperties;
    private Bow bowWhichShootThisArrow;
    private const float tripleShotAngle = Mathf.PI / 10;
    // Start is called before the first frame update
    void Start()
    {
        bowWhichShootThisArrow = GetComponentInParent<Bow>();
    }

    
    public void TripleShot(float forcePower)
    {
        GameObject[] arrow = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            Quaternion rotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, transform.parent.rotation.x - 20 + 20 * i);
            
            arrow[i] = Instantiate(baseArrowPrefab, transform.position, rotation );
            Rigidbody2D body = arrow[i].GetComponent<Rigidbody2D>();
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            vec.Normalize();
            float x = vec.x * Mathf.Cos(-tripleShotAngle+tripleShotAngle*i) - vec.y * Mathf.Sin(-tripleShotAngle + tripleShotAngle * i);
            float y = vec.x * Mathf.Sin(-tripleShotAngle + tripleShotAngle * i) + vec.y * Mathf.Cos(-tripleShotAngle + tripleShotAngle * i);
            Vector2 forceVector = new Vector2(x,y);
            forceVector.Normalize();
            Vector2 force = forceVector * bowWhichShootThisArrow.currentBow.force * forcePower;
            body.AddForce(force);
        }
        
         

        
    }
    public void Shoot(float precetage)
    {
        SpawnArrow(precetage);

    }
    void SpawnArrow(float precetage)
    {
        GameObject arrow = Instantiate(baseArrowPrefab, transform.position, transform.parent.rotation);
        Rigidbody2D body = arrow.GetComponent<Rigidbody2D>();
        
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 forceVector = new Vector2(vec.x, vec.y);
        forceVector.Normalize();
        Vector2 force = forceVector * bowWhichShootThisArrow.currentBow.force * precetage;
        body.AddForce(force);
    }
    
        
        
}
