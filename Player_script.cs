using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public MannaBar mannaBar;
    public LayerMask knightLayer;
    public LayerMask archerLayer;
    public LayerMask wizardLayer;
    public LayerMask wormLayer;
    public Transform attackPoint;
    public Rigidbody2D rigidBody;
    public GameObject gameOver;
    public Animator animator;
    public Transform firePoint;
    public GameObject energyPrefab;
    public GameObject blockEffect;


    public int level = 1;
    public float speed;
    public float attackRange = 0.2f;
    public int attackDamage = 20;
    public int maxHealth = 200;
    public int currentHealth;
    public bool isAlive = true;
    public bool hasKey = false;
    public float attackSpeed = 0.5f;
    public float jumpCoolDown = 1f;
    public float shieldRegen = 0.3f;
    public float rollCoolDown = 1.2f;
    public float jumpHeight = 4f;
    public int experience = 0;
    public int sheildDurability = 15;
    public int currentShield;
    public int maxManna = 100;
    public int manna = 0;
    public bool learnedEnergy = false;
    public bool attatchedToVine = false;
    public int rollDistance = 35;

    public int numHealthPotions = 0;
    public int numMannaPotions = 0;
    public int numCoins = 0;
    public bool jumpNotAllowed = false;

    float nextAttackTime = 0f;
    float nextJumpTime = 0f;
    float nextShieldHeal = 0f;
    float nextRollTime = 0f;
    bool blocking = false;
    bool isFlipped = false;
    bool rolling = false;

    // Start is called before the first frame update
    void Start()
    {
        setMaxHealth();
        setMaxSheildDurability();
    }

    // Update is called once per frame
    void Update()
    {
        bool running = false;
        healthBar.SetHealth(currentHealth);
        mannaBar.SetManna(manna);
        shieldBar.SetDurability(currentShield);
        if (Time.time >= nextJumpTime)
        {
            float vel = System.Math.Abs(rigidBody.velocity.y);
            bool velNeg = System.Math.Sign(rigidBody.velocity.y) == -1;
            if (Input.GetKeyDown(KeyCode.W) && !jumpNotAllowed && vel < 3 || Input.GetKeyDown(KeyCode.Space) && !jumpNotAllowed && vel < 3 )
            {
                FindObjectOfType<AudioManager>().play("Jump");
                //yes this is janky, but calling stopAttacking fixed the bug when jumping and attacking at same time.
                stopAttacking(); 
                animator.SetBool("isJumping", true);
                rigidBody.velocity = Vector2.up * jumpHeight;
                nextJumpTime = Time.time + 1f / jumpCoolDown;
            }
        }

        if (Input.GetKey(KeyCode.D) && !blocking)
        {
            bool roll = false;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                roll = true;
            }
            if (roll)
            {
                if (Time.time >= nextRollTime)
                {
                    stopAttacking();
                    rolling = true;
                    animator.SetTrigger("Roll");
                    transform.position += Vector3.right * rollDistance * Time.deltaTime;
                    currentShield += 1;
                    nextRollTime = Time.time + 1f / rollCoolDown;
                }
            }
            FindObjectOfType<AudioManager>().play("Run");
            running = true;
            //transform.localScale = new Vector3(.4f, .4f, 1);
            if (isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetFloat("speed", speed);
        }

        if (Input.GetKey(KeyCode.A) && !blocking)
        {
            bool roll = false;
            if (Input.GetKeyDown(KeyCode.Z)){
                roll = true;
            }
            if (roll)
            {
                if (Time.time >= nextRollTime)
                {
                    stopAttacking();
                    rolling = true;
                    animator.SetTrigger("Roll");
                    transform.position += Vector3.left * rollDistance * Time.deltaTime;
                    currentShield += 1;
                    nextRollTime = Time.time + 1f / rollCoolDown;
                }
            }
            FindObjectOfType<AudioManager>().play("Run");
            running = true;
            if (!isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
            animator.SetFloat("speed", speed);
        }

        if (Time.time >= nextAttackTime && !blocking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }

        if (Input.GetMouseButton(1) && currentShield>0)
        {
            block();
        }
        if (Input.GetMouseButtonUp(1))
        {
            stopBlocking();
        } 
        if (!running)
        {
            animator.SetFloat("speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            shootEnergyBeam();
        }
        
        if (currentShield < sheildDurability)
        {
            if (Time.time >= nextShieldHeal)
            {
                currentShield += 1;
                nextShieldHeal = Time.time + 1f / shieldRegen;
            }
        }
        if (currentShield < 0)
        {
            currentShield = 0;
        }
        if (currentShield > sheildDurability)
        {
            currentShield = sheildDurability;
        }

    }

    public void stopAttacking()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isAttacking2", false);
        animator.SetBool("isAttacking3", false);
    }

    public void stopJumping()
    {
        animator.SetBool("isJumping", false);
    }

    public void stopBlocking()
    {
        blocking = false;
    }

    public void stopRolling()
    {
        rolling = false;
    }

    void attack()
    {
        FindObjectOfType<AudioManager>().play("Slash");
        //I realize this problem with jumping/ attacking could maybe be solved with triggers, but i cant be bothered
        stopJumping();
        stopRolling();

        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            animator.SetBool("isAttacking", true);
        }
        if (rand == 1)
        {
            animator.SetBool("isAttacking2", true);
        }
        if (rand == 2)
        {
            animator.SetBool("isAttacking3", true);
        }
        // fix this so its less repeat code

        Collider2D[] hitKnights = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, knightLayer);

        foreach(Collider2D enemy in hitKnights)
        {
            if (enemy.GetComponent<Swordsman>().isAlive)
            {
                enemy.GetComponent<Swordsman>().TakeDamage(attackDamage);
            }
        }
        Collider2D[] hitArchers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, archerLayer);

        foreach (Collider2D enemy in hitArchers)
        {
            if (enemy.GetComponent<Archer>().isAlive)
            {
                enemy.GetComponent<Archer>().TakeDamage(attackDamage);
            }
        }
        Collider2D[] hitWizard = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wizardLayer);

        foreach (Collider2D enemy in hitWizard)
        {
            if (enemy.GetComponent<FireWizard>().isAlive)
            {
                enemy.GetComponent<FireWizard>().TakeDamage(attackDamage);
            }
        }

        Collider2D[] hitWorm = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wormLayer);

        foreach (Collider2D enemy in hitWorm)
        {
            if (enemy.GetComponent<Worm>().isAlive)
            {
                enemy.GetComponent<Worm>().TakeDamage(attackDamage);
            }
        }
    }

    public void takeDamage(int damage)
    {
        if (!blocking && !rolling)
        {
            FindObjectOfType<AudioManager>().play("Damaged");
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //play hurt animation
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                die();
            }
        }
        else if (blocking && currentShield > 0)
        {
            Instantiate(blockEffect, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().play("Block");
            currentShield -= damage/10;
            shieldBar.SetDurability(currentShield);
        }
    }

    void die()
    {
        experience = 0;
        gameOver.GetComponent<Respawn>().gameOver();
        isAlive = false;
        animator.SetBool("isDead", true);
        //Disable the Collider
        //GetComponent<Collider2D>().enabled = false;
        //Disable the enemy
        this.enabled = false;
    }

    void block()
    {
        blocking = true;
        animator.SetTrigger("block");
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void setMaxManna()
    {
        manna = maxManna;
        mannaBar.setMaxManna(maxManna);
    }

    public void setMaxSheildDurability()
    {
        currentShield = sheildDurability;
        shieldBar.setMaxDurability(sheildDurability);
    }

    public void shootEnergyBeam()
    {
        if (manna >= 5 && learnedEnergy)
        {
            FindObjectOfType<AudioManager>().play("Energy");
            Instantiate(energyPrefab, firePoint.position, firePoint.rotation);
            manna -= 5;
            mannaBar.SetManna(manna);
        }
    }
    
    public void setBarsNextLevel() //this doesnt actually work right now, fix later. 
    {
        Debug.Log("function called");
        if (healthBar == null)
        {
            healthBar = GameObject.FindGameObjectWithTag("healthbar").GetComponent<HealthBar>();
        }
        if (shieldBar == null)
        {
            shieldBar = GameObject.FindGameObjectWithTag("shieldbar").GetComponent<ShieldBar>();
        }
        healthBar.SetHealth(currentHealth);
    }

    public void climbVine()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();;
        // grab onto vine
        if (Input.GetKeyDown(KeyCode.E))
        {
            stopAttacking();
            stopJumping();
            stopBlocking();
            attatchedToVine = true;
            animator.SetBool("isClimbing", true);
            startVineMovement(rb);
        }
        if (Input.GetKey(KeyCode.S) && attatchedToVine)
        {
            //move down
            rb.velocity = Vector2.down;
        }
        if (Input.GetKey(KeyCode.W) && attatchedToVine)
        {
            rb.gravityScale = 1f;
            rb.velocity = Vector2.up;
            //move up
        }
        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.S)))
        {
            startVineMovement(rb);
        }

    }
    public void resumeNormalMovement(Rigidbody2D rb)
    {
        // stop climbing the vine
        jumpNotAllowed = false;
        rb.gravityScale = 1f;
        attatchedToVine = false;
        animator.SetBool("isClimbing", false);
    }
    private void startVineMovement(Rigidbody2D rb)
    {
        jumpNotAllowed = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
    }

    public void repsawn()
    {
        animator.SetBool("isDead", false);
        isAlive = true;
        GetComponent<Collider2D>().enabled = true;
        setMaxHealth();

    }

}

