using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FateGames;

public class ShoeRaceLevel : LevelManager
{
    private new void Awake()
    {
        base.Awake();


    }
    public override void FinishLevel(bool success)
    {
        print("finish level");
    }

    public override void StartLevel()
    {
        print("start level");
    }

}
