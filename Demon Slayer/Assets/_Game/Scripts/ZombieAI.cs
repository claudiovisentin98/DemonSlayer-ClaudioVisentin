using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour {
    private GameObject m_hero;
    public int health = 3;
    public Animator m_anim;
    SwordScript swordcheck;
    private NavMeshAgent navy;
    bool checkforplayer = false;

    void AttackHero ()
    {
        if (m_hero.GetComponent<Controls>().canbehit == true)
        {
            m_hero.GetComponent<Controls>().ishit = true;
        }
    }

    void Start () {
        StartCoroutine("Spawn");
        m_hero = GameObject.FindGameObjectWithTag("Player");
        swordcheck = GameObject.FindGameObjectWithTag("Player").GetComponent<SwordScript>();
        navy = this.gameObject.GetComponent<NavMeshAgent>();


    }
	
    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(2);
        m_anim = this.gameObject.GetComponent<Animator>();
        navy.enabled = true;
        checkforplayer = true;
    }
	void Update () {
        if (checkforplayer == true)
        {
            navy.SetDestination(m_hero.transform.position);
        }


        if (swordcheck.animationtrigger == true)
        {
            StartCoroutine("Health");
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag ("Player"))
        {
            if (m_hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == false)
            {
                m_anim.SetTrigger("Attack");
            }

        }
    }

    IEnumerator Health ()
    {

        yield return new WaitForSeconds(0);

        if (health <= 0) {
            m_anim.SetBool ("Death", true);
            yield return new WaitForSeconds(6);
            Controls.kills += 1;
            Destroy(this.gameObject);
        }
        swordcheck.animationtrigger = false;
    }
}
