using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int coinsCollected;// BASIC DROP ITEM BONUS. 2 possible rewards

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }


    [SerializeField] private bool isInvincible;
    [SerializeField] private bool canAttack;


    private float horizontal;
    private float vertical;
    [SerializeField] private float invincibleTimer;
    [SerializeField] private float timeInvincible = 2.0f;
    [SerializeField] private float speed = 3.0f;


    [SerializeField] private GameObject _particleSystemPrefab;

    Rigidbody2D rb;
    Animator animator;
    CinemachineVirtualCamera cmvc;
    AudioSource audio;
    public AudioClip swordWoosh;
    public AudioClip swordHit;


    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 move;
    public AudioClip hurt;

    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        cmvc = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (!IsOwner) return;
        cmvc.Follow = gameObject.transform;

        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        // Check for owner of game instance.
        // All code ran must only run on each players machine
        if (!IsOwner) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal, vertical);

        //Move player
        Move(move);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                if (hit.collider != null)
                {
                    NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                    if (character != null)
                    {
                        character.DisplayDialog();
                    }
                }
            }
        }

        if(Input.GetMouseButtonDown(0))
        {

            PlayerAttack();
        }

    }

    private void Move(Vector2 _moveInput)
    {
        // Move player x y directions
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    private void PlayerAttack()
    {

        if (canAttack)
        {
            audio.PlayOneShot(swordWoosh, .75f);

            StartCoroutine(AttackCoolDown());

            if (lookDirection.x == 1)
            {
                Debug.Log("Attack Triggered");

                animator.SetBool("isAttackingRight", true);
            }
            else if (lookDirection.x == -1)
            {
                animator.SetBool("isAttackingLeft", true);
            }
            else if (lookDirection.y == 1)
            {
                animator.SetBool("isAttackingUp", true);
            }
            else if (lookDirection.y == -1)
            {
                animator.SetBool("isAttackingDown", true);
            }
        }

        

    }

    IEnumerator AttackCoolDown()
    {
        //Attack cooldown is best performed with a timer = Time.time. Will implement if hired
        
        canAttack = false;

        yield return new WaitForSeconds(.5f);

        //Debug.Log("Reset Attack");
        animator.SetBool("isAttackingRight", false);
        animator.SetBool("isAttackingLeft", false);
        animator.SetBool("isAttackingUp", false);
        animator.SetBool("isAttackingDown", false);

        canAttack = true;
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rb.MovePosition(position);

    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {

            animator.SetTrigger("Hit");
            audio.PlayOneShot(hurt, 0.75f);

            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        CameraShake.Instance.ShakeCamera(1.5f, 1f);
        GameObject blood = Instantiate(_particleSystemPrefab, transform.position, Quaternion.identity);
        blood.GetComponent<ParticleSystem>().Play();


    }
    // Pick REWARD item (Basic between 2 possible rewards)
    public void PickUpCoins(int coins)
    {
        coinsCollected += coins;
        Debug.Log(coinsCollected);
    }

    //Will Implement if hired
    [ServerRpc]
    private void MoveServerRPC(Vector2 movementInput)
    {
        Debug.Log("Running on server");
    }
}
