using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FateGames;

public class Competitor : MonoBehaviour
{
    [SerializeField] Color[] colors;
    [SerializeField] GameObject character = null;
    [SerializeField] protected Colors color;

    private float speed = 2;
    private bool start = false;
    private SkinnedMeshRenderer meshRend;
    public Animator animator;

    public enum Colors { Red, Blue, Green };

    protected void Awake()
    {
        meshRend = character.transform.GetChild(1).gameObject.transform.GetComponent<SkinnedMeshRenderer>();
        meshRend.sharedMaterial.color = colors[(int)color];
        animator = character.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.STARTED)
        {
            if (!start)
            {
                animator.SetTrigger("start");
                start = true;
            }
            Move();
            CheckFloor();
        }
    }

    protected void ChangeColor(Colors newColor)
    {
        meshRend.sharedMaterial.color = colors[(int)newColor];
        color = newColor;
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.z += Time.deltaTime * speed;
        transform.position = pos;
    }

    private void CheckFloor()
    {
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        if (Physics.Raycast(pos, -Vector3.up, out RaycastHit hit))
        {
            Floor floor = hit.transform.GetComponent<Floor>();
            if (floor)
            {
                if (floor.color == color)
                {
                    speed = 2;
                    animator.SetBool("run", true);
                }
                else
                {
                    speed = 1;
                    animator.SetBool("run", false);
                }
            }
               
        }
    }





}
