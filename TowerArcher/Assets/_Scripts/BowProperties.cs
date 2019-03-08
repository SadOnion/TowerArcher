using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bow",menuName ="Items/New Bow")]
public class BowProperties : ScriptableObject
{

    public new string name = "New Bow";
    [Range(0,1000)]
    public int dmg = 0;
    [Range(0, 3)]
    public float fireRate = 1;
    public int force;
    public Sprite[] sprites = new Sprite[4];
    
}
