using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboard;
    private bool isLeaderboardOpen;
    
    public void ShowLeaderboard()
    {
        isLeaderboardOpen = !isLeaderboardOpen;
        _leaderboard.SetActive(isLeaderboardOpen);
    }
}
