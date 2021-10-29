using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LightRender flash;

    public float speedRoam;
    public float speedChase;
    private float waitTime;
    public float startWaitTime;
    public float distance;

    // private Transform[] moveSpots;
    // private int randomSpot;

    private Transform target;

    private Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    private Coroutine roaming = null;
    private float left, right;

    public bool isFacingLeft;
    public bool spawnFacingLeft;
    private Vector2 facingLeft;

    // protected virtual void Initialization()
    // {
    
    //     if(spawnFacingLeft)
    //     {
    //         transform.localScale = facingLeft;
    //         isFacingLeft = true;
    //     }
    // }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        SetNewDistances();
    }

    void Start()
    {
        spawnFacingLeft = true;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        // randomSpot = Random.Range(0, moveSpots.Length);
        // waitTime = startWaitTime;
    }

    // protected virtual void Flip()
    // {
    //     if (isFacingLeft)
    //     {
    //     }
    //     if (!isFacingLeft)
    //     {
    //     }
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetLeft = target.position.x < rigidbody.position.x;

        if (targetLeft)
        {
            spriteRenderer.flipX = false;

        }
        if (!targetLeft)
        {
            spriteRenderer.flipX = true;
            FlipSprite();
        }


        if (target != null)
        {
            if ((flash.on && Vector2.Distance(target.position, transform.position) <= 17) || Vector2.Distance(target.position, transform.position) <= 3)
            {
                rigidbody.position = Vector2.MoveTowards(rigidbody.position, new Vector2(target.position.x, rigidbody.position.y), speedChase * Time.deltaTime);
            }
            else
            {
                if (roaming == null)
                {
                    roaming = StartCoroutine(MoveToNextSpot());
                }
            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            flash = GameObject.FindObjectOfType<LightRender>();
        }
    }

    private IEnumerator MoveToNextSpot()
    {
        float destination = Random.Range(left, right);

        while (rigidbody.position.x != destination)
        {
            rigidbody.position = Vector2.MoveTowards(rigidbody.position, new Vector2(destination, rigidbody.position.y), speedRoam * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(startWaitTime);

        roaming = null;
    }

    private void SetNewDistances()
    {
        left = rigidbody.position.x - distance;
        right = rigidbody.position.x + distance;

        // RoamFlip();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // private void RoamFlip()
    // {
    //     if (target = null)
    //     {
    //         if (left < right)
    //         {
    //             spriteRenderer.flipX = true;
    //         }
    //         if (right > left)
    //         {
    //             spriteRenderer.flipX = false;
    //         }
    //     }
    // }
}
