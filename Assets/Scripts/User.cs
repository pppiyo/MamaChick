using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string userName;
    public string userScore;

    // private System.Random random = new System.Random();

    public User()
    {
        PlayerScores player = new PlayerScores();

        // userName = PlayerScores.playerName;
        // userScore = player.scoreText.text;
    }
}
