using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private Competitor.Colors color;
    private Player player = null;

    private void Awake() 
    {
        player = FindObjectOfType<Player>();
    }

    public void ChangeColor()
    {
        player.ChangeColorFromButton(color);
    }

}
