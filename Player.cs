using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour
{

    public Animator PlayerAnimator;
    public int Pebbles, Razorblades, Cigbutts;
    public float PlayerSpeed,PlayerStrength, PlayerHealth, PlayerDamage,DefaultSpeed;
    float timeDamaged;

    bool HSA, isAlive;
    public bool Attacking;//herpisyphilaids
    public GameObject TutorialPanel,AxeSpawn,Axe;
    public Text Notification,PebblesCounter,Tutorial,BladeCounter,CigCounter;
    public Slider HealthBar;


    void Start()
    {
        //load in File if applicable??? nah???
        HealthBar.value = HealthBar.maxValue;
        PlayerSpeed = 5;
        PlayerStrength = 10;
        PlayerHealth = 500;
        PlayerDamage = 30;
        isAlive = true;
        HSA = false;
        TutorialPanel.SetActive(false);
        Pebbles = 05;
        Razorblades = 05;
        Cigbutts = 0;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        if (isAlive)
        {
            HealthBar.value = PlayerHealth;
            if (!PlayerAnimator.GetBool("isDamaged"))
            {
                Controls();
            }
            else
            {

                timeDamaged += Time.deltaTime;
                if (timeDamaged >= .25f)
                {
                    PlayerAnimator.SetBool("isDamaged", false);
                    timeDamaged = 0;
                }
            }

        }
        else if (!isAlive)
        {
            Application.Quit();
        }
    }
    void Controls()
    {

        //move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.Translate(-transform.right * Time.deltaTime * PlayerSpeed, Space.World);
            this.GetComponent<SpriteRenderer>().flipX = true;
            PlayerAnimator.SetBool("isWalking", true);
           

        }
        //stopwalking
        if (Input.GetAxis("Horizontal") == 0)
        {
            PlayerAnimator.SetBool("isWalking", false);

        }

            //moveright
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.Translate(transform.right * Time.deltaTime * PlayerSpeed, Space.World);
            this.GetComponent<SpriteRenderer>().flipX = false;
            PlayerAnimator.SetBool("isWalking", true);
        }

        //jump
        if (Input.GetAxis("Jump") > 0)
        {
            this.transform.Translate(transform.up * Time.deltaTime * PlayerStrength);
            PlayerAnimator.SetBool("isJumping", true);
        }
            //jab
        if (Input.GetAxis("Jab") >0)
        {
            PlayerAnimator.SetBool("SyringAttack", true);
            Attacking = true;
        }
        if (Input.GetAxis("Jab") == 0)
        {
            PlayerAnimator.SetBool("SyringAttack", false);
            Attacking = false;
        }

        if (Input.GetAxis("Axe") > 0)
        {
            if (Razorblades > 0)
            {
                ThrowAxe();

            }
        }
        if (Input.GetAxis("Axe") == 0)
        {
            PlayerAnimator.SetBool("RazorAttack", false);

        }

        //////trow pebble
        ////if (Input.GetAxis("Pebble") > 0)
        ////{
        ////    if (Pebbles > 0)
        ////    {
        ////        PlayerAnimator.SetBool("PebbleAttack", true);
        ////        Attacking = true;
        ////    }
        ////    // PlayerAnimator.SetBool("PebbleAttack", false);
        ////    Attacking = false;
        ////}
        ////if (Input.GetAxis("Pebble") >= 0)
        ////{
        ////    PlayerAnimator.SetBool("PebbleAttack", false);
        ////    Attacking = false;
        ////}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            PlayerAnimator.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collison");
            Debug.Log("attacking:" + Attacking);
            if (Attacking)
            {
                Debug.Log("Attacking");
                collision.gameObject.GetComponent<Enemy>().TakeDamage(PlayerDamage);
            }
        }
    }


    void ThrowAxe()
    {
        if (Razorblades > 0)
        {
            PlayerAnimator.SetBool("RazorAttack", true);
            Transform toSpawn = AxeSpawn.transform;
            GameObject axe = Instantiate(Axe, toSpawn);
            Destroy(axe, 2f);
            Razorblades--;
        }
    }

    public void PlayerTakeDamage(float attack)
    {
       
        if (!Attacking && !PlayerAnimator.GetBool("isDamaged"))
        {
            PlayerHealth = PlayerHealth - attack;
            //PlayerAnimator.SetBool("isDamaged", false);
        }
        //check if player is dead
        if(PlayerHealth < 0)
        {
            isAlive = false;
        }
        PlayerAnimator.SetBool("isDamaged", true);
    }
    //called to check for upgrade in player update
    void ChangeDamage()
    {
        if (PlayerStrength % 5 == 0)
        {
            PlayerDamage = PlayerDamage * 1.01f;
        }
        //ten percent increase in damage
    }
}
