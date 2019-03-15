using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour
{

    int rand;
    private void OnParticleCollision(GameObject other)
    {
        
        IFreezable fre = other.GetComponent<IFreezable>();
        rand = Random.Range(1, 100);
        if(fre!=null)
        {
            fre.SlownDown(5);
            if (rand == 50)
            {
                
                fre.Freze(3);
            }
        }
        
        
    }




}
