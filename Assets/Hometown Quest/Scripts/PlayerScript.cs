using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> droids = new List<GameObject>();
    private int level = 1;

    public int experience
    {
        get { return xp; }
    }

    public int RequiredExp
    {
        get { return requiredXp; }
    }

    public int LevelBase
    {
        get { return levelBase; }
    }

    public List<GameObject> Droids
    {
        get { return droids; }
    }

    private void Start()
    {
        
    }

    public void AddExperience()
    {
        xp = Mathf.Max(0, xp);
    }

    public void AddDroid(GameObject droid)
    {
        droids.Add(droid);
    }

    private void InitLevelData()
    {
        level = (xp / levelBase) + 1;
        requiredXp = levelBase * level; 
    }
}

