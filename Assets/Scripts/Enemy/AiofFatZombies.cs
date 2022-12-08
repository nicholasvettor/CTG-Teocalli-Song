using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AiofFatZombies : MonoBehaviour
{
    Transform player; public Animator anim;
    public float playerHealth = 100; 
    public Text playerhath;
    public bool allowtohit = false;
    UnityEngine.AI.NavMeshAgent nav;
    float navspeed = 0.5f;
    public static float floathealth = 100;
    public bool zombiesdeath = false;
    public Texture blooody;
    //public GameObject Player;

    void Awake()
    {
        if (!zombiesdeath)
        {
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //player = GameObject.FindGameObjectWithTag("Player").transform;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            anim = GetComponent<Animator>();
            playerhath.text = "Player Health =" + floathealth.ToString();
        }
    }
    void OnGUI()
    {
        nav.SetDestination(player.position);
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        navspeed += Time.deltaTime / 50;
        nav.speed = navspeed;
        anim.SetBool("walk", true);
        anim.SetBool("attack", false);
        if (distance <= 7)
        {
            nav.Stop();
            anim.SetBool("attack", true);
            floathealth -= Time.deltaTime;
            playerhath.text = "Player Health=  " + floathealth.ToString();
            if ((int)floathealth == 0)
            {
                player.SendMessage("1");
            }
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blooody);

            anim.SetBool("walk", false);


        }


    }


    public void ApplyDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth == 0)
        {

            Death();
        }
    }
    public void Death()
    {
        zombiesdeath = true;
        nav.Stop();
        anim.SetTrigger("death");
        Destroy(this.gameObject, 10.0f);
    }

}

















































/*
public class BasicEnemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
