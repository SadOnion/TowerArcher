using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    TrailRenderer trail;
    public float timeBtwSpawn=.2f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        time = timeBtwSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            
            trail.emitting = !trail.emitting;
            time = timeBtwSpawn;
        }
    }
}
