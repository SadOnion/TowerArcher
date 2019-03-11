using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Arrow arrow;
    public BowProperties bow;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleScale();
    }

    private void HandleScale()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x) sr.flipX = true ;
        else sr.flipX = false;
    }
}
