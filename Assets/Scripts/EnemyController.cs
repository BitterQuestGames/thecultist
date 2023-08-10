using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float healthPoints;
    public float maxHealthPoints = 4;
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;



    float timer;
    int direction = 1;

    Rigidbody2D rb;
    Animator animator;

    public HealthBars healthBar;
    public GameObject rewardPrefab;
    public GameObject rewardPrefab2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthPoints = maxHealthPoints;
        healthBar.SetHealth(healthPoints, maxHealthPoints);
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = changeTime;

            if(vertical && direction > 0)
            {
                vertical = false;
                animator.SetFloat("MoveX", direction);
                animator.SetFloat("MoveY", 0);

            }else if(!vertical && direction > 0)
            {
                vertical = true;
                direction = -direction;
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", direction);


            }
            else if(vertical && direction < 0)
            {
                vertical = false;
                direction= -1;
                animator.SetFloat("MoveX", direction);
                animator.SetFloat("MoveY", 0);


            }
            else if(!vertical && direction < 0)
            {
                
                vertical = true;
                direction = 1;
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", direction);


            }

        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
        }

        rb.MovePosition(position);
    }

    public void TakeDamage(float damage)
    {

        if (vertical && direction > 0)
        {
            vertical = false;
            animator.SetBool("HurtUp", true);


        }
        else if (!vertical && direction > 0)
        {
            vertical = true;
            animator.SetBool("HurtRight", true);


        }
        else if (vertical && direction < 0)
        {
            vertical = false;
            animator.SetBool("HurtLeft", true);



        }
        else if (!vertical && direction < 0)
        {

            vertical = true;
            animator.SetBool("HurtDown", true);

        }

        StartCoroutine(AttackCoolDown());


        healthPoints -= damage;

        if(healthPoints  < 0)
        {
            gameObject.SetActive(false);
            SpawnReward();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private void SpawnReward()
    {
        // GENERATE A RANDOM REWARD BETWEEN 2 ITEMS
        float r = Random.Range(-1.0f, 1.0f);
        Debug.Log("Random Reward = " + r);

        if(r > 0)
        {
            Instantiate(rewardPrefab, gameObject.transform.position, gameObject.transform.rotation);

        }
        else
        {
            Instantiate(rewardPrefab2, gameObject.transform.position, gameObject.transform.rotation);

        }
    }

    IEnumerator AttackCoolDown()
    {
        //Attack cool down is best used with a timer Time.time. Will implement if hired

        yield return new WaitForSeconds(.5f);

        //Debug.Log("Reset Attack");
        animator.SetBool("HurtUp", false);
        animator.SetBool("HurtDown", false);
        animator.SetBool("HurtLeft", false);
        animator.SetBool("HurtRight", false);

    }
}
