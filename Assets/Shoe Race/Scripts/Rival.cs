using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : Competitor
{
    [SerializeField] Vector2 randomTimeRange = new Vector2(1, 3);

    private new void Awake()
    {
        base.Awake();
        RandomColorChange();
    }

    private new void Update()
    {
        base.Update();
    }

    public void RandomColorChange()
    {
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        if (Physics.Raycast(pos, -Vector3.up, out RaycastHit hit))
        {
            Floor floor = hit.transform.GetComponent<Floor>();
            if (floor)
            {
                if (floor.color != color)
                {
                    ChangeColor(floor.color);
                }
            }
        }

        float time = Random.Range(randomTimeRange.x, randomTimeRange.y);

        LeanTween.delayedCall(time, () =>
        {
            RandomColorChange();
        });
    }
}
