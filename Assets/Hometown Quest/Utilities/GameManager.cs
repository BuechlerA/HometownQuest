using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerScript currentPlayer;

    public PlayerScript CurrentPlayer
    {
        get { return currentPlayer; }
    }

    private void Awake()
    {
        Assert.IsNotNull(currentPlayer);
    }
}
