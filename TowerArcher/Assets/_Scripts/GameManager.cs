using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Archer player;
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject manager = new GameObject("GameManager");
                _instance = manager.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindObjectOfType<Archer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
