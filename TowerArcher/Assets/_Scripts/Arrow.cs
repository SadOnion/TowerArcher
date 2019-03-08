using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject baseArrowPrefab;
    public ArrowProperties arrowProperties;
    private Bow bowWhichShootThisArrow;

    // Start is called before the first frame update
    void Start()
    {
        bowWhichShootThisArrow = GetComponentInParent<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(float precetage)
    {
        GameObject arrow = Instantiate(baseArrowPrefab, transform.position, transform.parent.rotation);
        Rigidbody2D body = arrow.GetComponent<Rigidbody2D>();
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 forceVector = new Vector2(vec.x,vec. y);
        forceVector.Normalize();
        Vector2 force = forceVector * bowWhichShootThisArrow.currentBow.force*precetage;
        body.AddForce(force);
    }
}
