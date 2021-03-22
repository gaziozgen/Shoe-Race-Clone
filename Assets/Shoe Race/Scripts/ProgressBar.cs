using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Player player;
    private Slider slider;
    private float platformLength;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        slider = transform.GetComponent<Slider>();
        platformLength = FindObjectOfType<Platform>().transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (player.transform.position.z - 0.5f) / (platformLength - 1);
    }
}
