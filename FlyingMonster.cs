using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour
{
    Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 0.8f;
    public float moveCoolDown = 1f;

    private Vector2 initPos;
    private float nextMoveTime = 0f;
    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initPos = new Vector2(animator.transform.position.x, animator.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.transform.position.y > 6)
        {
            Vector3 target = new Vector2(animator.transform.position.x, animator.transform.position.y - 3);
            if (animator.transform.position == target)
            {
                return;
            }
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }
        if (!move)
        {
            float distance = Vector3.Distance(player.position, rb.transform.position);
            if (distance <= 3 && distance >=0.5f)
            {
                Vector3 target = new Vector2(player.position.x, player.position.y + 0.1f);
                if (animator.transform.position == target)
                {
                    return;
                }
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
            }
        }
        if (move)
        {
            float distance = Vector3.Distance(player.position, rb.transform.position);
            if (distance <= 3)
            {
                Vector3 target = new Vector2(player.position.x + 1, player.position.y + 1);
                //Vector3 target = initPos;
                if (animator.transform.position == target)
                {
                    return;
                }
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
            }
        }
        if (Time.time >= nextMoveTime)
        {
            nextMoveTime = Time.time + 1f / moveCoolDown;
            move = !move;
        }

        if (!gameObject.GetComponent<Worm>().isAlive)
        {
            player.GetComponent<Player_script>().manna += 2;
            player.GetComponent<Player_script>().experience += 10;
            this.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }
    }
}
