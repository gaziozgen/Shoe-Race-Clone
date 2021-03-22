using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FateGames;

public class Final : MonoBehaviour
{
    private ShoeRaceLevel levelManager;

    private void Awake()
    {
        levelManager = (ShoeRaceLevel)LevelManager.Instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        Rival rival = other.transform.GetComponent<Rival>();
        if (player)
        {
            levelManager.FinishLevel(true);
            player.animator.SetTrigger("win");
            FindObjectOfType<Rival>().animator.SetTrigger("lose");
        }
        else if (rival)
        {
            levelManager.FinishLevel(false);
            rival.animator.SetTrigger("win");
            FindObjectOfType<Player>().animator.SetTrigger("lose");
        }
    }

}
