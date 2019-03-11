using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public Transform[] points;
    public BowProperties currentBow;
    private float stretchValue = 0;
    private readonly float valueToStretch = 1;
    private bool isStretched;
    private float stretchPrecetage=0;
    private SpriteRenderer sr;
    private Arrow currentArrow;
    private string shotSound = "Sample";
    public delegate void ShootMethod();
    ShootMethod Shoot;
    private const int lMax = 130, lMin = -130;

    public void SetBow(BowProperties newBow)
    {
        currentBow = newBow;
    }
    // Start is called before the first frame update
    void Start()
    {
        Shoot = TripleShot;
        currentBow = GameManager.Instance.player.bow;
        sr = GetComponent<SpriteRenderer>();
        currentArrow = GetComponentInChildren<Arrow>();
        arrow.GetComponent<SpriteRenderer>().sprite = currentArrow.arrowProperties.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        UpdateBowState();
        UpdateRotation();
       
    }
    private void HandleInputs()
    {
        if (Input.GetMouseButton(0))
        {
            Stretch();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isStretched) Shoot();
            else stretchValue = 0;
        }
    }
    private void UpdateRotation()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        
        
        
        

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    
    private void UpdateBowState()
    {
        stretchPrecetage = (stretchValue / valueToStretch) * 100;
        if (stretchPrecetage <= 33)
        {

            sr.sprite = currentBow.sprites[0];
            arrow.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (stretchPrecetage > 33 && stretchPrecetage < 66)
        {
            arrow.GetComponent<SpriteRenderer>().enabled = true;
            sr.sprite = currentBow.sprites[1];
            arrow.transform.position = points[0].position;
        }
        if (stretchPrecetage >= 66 && stretchPrecetage < 100)
        {
            sr.sprite = currentBow.sprites[2];
            arrow.transform.position = points[1].position;
        }
        if (stretchPrecetage >= 100)
        {
            sr.sprite = currentBow.sprites[3];
            arrow.transform.position = points[2].position;
        }
    }
    private void TripleShot()
    {
        currentArrow.TripleShot(stretchPrecetage / 100);
        stretchValue = 0;
        AudioManager.instance.Play(shotSound);
    }
    private void BaseShot()
    {
        currentArrow.Shoot(stretchPrecetage/100);
        stretchValue = 0;
        AudioManager.instance.Play(shotSound);
    }
    private void Stretch()
    {
        
        stretchValue += Time.deltaTime * currentBow.fireRate;
        if (stretchValue > valueToStretch) stretchValue = valueToStretch;
        if (stretchPrecetage >= 33) isStretched = true;
        else isStretched = false;
    }
    public void ChangeMode()
    {
        if(Shoot == TripleShot)
        {
            Shoot = BaseShot;
        }
        else
        {
            Shoot = TripleShot;
        }
    }
    
}
