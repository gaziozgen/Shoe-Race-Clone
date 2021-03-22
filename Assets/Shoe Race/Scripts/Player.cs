using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Competitor
{
    private new void Awake()
    {
        base.Awake();
    }

    private new void Update()
    {
        base.Update();
    }

    public void ChangeColorFromButton(Colors color)
    {
        ChangeColor(color);
    }
}
