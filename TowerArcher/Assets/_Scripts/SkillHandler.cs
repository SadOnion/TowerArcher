using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    public GameObject baseArrow;
    public GameObject explosiveArrow;
    public GameObject frostArrow;
    public GameObject snowArrow;
    public GameObject accidArrow;
    private GameObject oldArrow;
    private Archer player;
    private bool isUsed;
    // private WheatherHandler wheatherSkills;

    private void Start()
    {
        player = GameManager.Instance.player;
        player.bowObject.ShotFire += ArrowFired;
    }
    
    public void UseArrow(GameObject prefabArrow)
    {
        oldArrow = player.arrow.baseArrowPrefab;
        player.arrow.baseArrowPrefab = prefabArrow;
        isUsed = true;
    }
    private void ArrowFired(object sender,EventArgs e)
    {
        if (isUsed)
        {
            player.arrow.baseArrowPrefab = baseArrow;
            isUsed = false;
        }
    }
}
