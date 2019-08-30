using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
    [SerializeField] private float catchRate = 0.10f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defend = 0;
    [SerializeField] private int health = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public float SpawnRate
    {
        get { return spawnRate; }
    }

    public float CatchRate
    {
        get { return catchRate; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return Defense; }
    }

    public int Health
    {
        get { return health; }
    }

    private void OnMouseDown()
    {
        PocketDroidsSceneManager[] managers = FindObjectsOfType<PocketDroidsSceneManager>();
        foreach (PocketDroidsSceneManager pocketDroidsSceneManager in managers)
        {
            if (pocketDroidsSceneManager.gameObject.activeSelf)
            {
                pocketDroidsSceneManager.droidTapped(gameObject);
            }
        }
    }
}
