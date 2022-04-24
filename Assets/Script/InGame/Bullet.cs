using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private PlayerPhysics playerPhysics;
    [SerializeField] private bool targetDirectIsRight;

    [SerializeField] private float range;

    private Vector3 TargetPos;

    void Start()
    {
        range = 12f;
        playerPhysics = GameObject.Find("Player").GetComponent<PlayerPhysics>();
        targetDirectIsRight = playerPhysics.isFacingRight;

        if (targetDirectIsRight)
        {
            TargetPos = transform.position + Vector3.right * range;
            transform.Rotate(new Vector3(0,0,-90));
        }
        else
        {
            TargetPos = transform.position + Vector3.left * range;
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
    void Update()
    {
        if (CheckRange())
        {
            Destroy(gameObject);
        }   
    }

    private bool CheckRange()
    {
        if (targetDirectIsRight)
        {

            if (transform.position.x >= TargetPos.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (transform.position.x <= TargetPos.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
