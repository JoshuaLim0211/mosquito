using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    #region Property
    //정보
    [SerializeField] private int playerLevel;
    //이동
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Transform groundCheck;

    public float checkRadius;
    public float speed;
    public float jumpPower;

    public bool isFacingRight = true;
    bool isGround;

    public LayerMask whatIsGround;

    //전투
    [SerializeField] private GameObject UsingBullet;
    [SerializeField] public GameObject BulletA;
    [SerializeField] public GameObject BulletB;

    [SerializeField] private float bulletSpeed;

    private float curFireDelay;
    private float maxFireDelay = 0.2f;
    #endregion

    #region Unity Methods
    private void Start()
    {
        ChangeBullet();
    }
    void Update()
    {
        //Debug.Log(isGround);
        Move();
        Jump();
        Fire();
        Relod();
        ChangeBullet();

        isGround = CheckOnGround();

        



        
    }
    #endregion

    #region Custome Methods
    void Move()
    {
        float inputHorizon = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(inputHorizon * speed, rigid.velocity.y);

        if (isFacingRight && inputHorizon < 0)
        {

            Flip();
        }
        else if (!isFacingRight && inputHorizon > 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower/* * (speed * 0.1f)*/);

        }

    }

    bool CheckOnGround()
    {
    return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }



    private void Fire()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (curFireDelay > maxFireDelay)
            {
                GameObject tempBullet = Instantiate(UsingBullet, transform.position, transform.rotation);
               
                Rigidbody2D rigid = tempBullet.GetComponent<Rigidbody2D>();
                if (isFacingRight)
                {
                rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                }
                else
                {
                rigid.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
                }
                curFireDelay = 0f;
            }

        }
        
    }
    private void Relod()
    {
        curFireDelay += Time.deltaTime;
    }
    private void ChangeBullet()
    {
        switch (playerLevel)
        {
            case 0:
                UsingBullet = BulletA;
                break;
            case 1:
                UsingBullet = BulletB;
                break;

        }
    }
    #endregion
}

