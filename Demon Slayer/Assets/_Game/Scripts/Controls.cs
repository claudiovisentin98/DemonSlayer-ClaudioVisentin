using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
    private Animator m_anim;

    public static int health = 30;
    public static int kills = 0;
    public bool Gamepad = false;
    public bool ishit = false;
    public GameObject mesh1;
    public GameObject mesh2;
    public bool canbehit = true;
    private void Start()
    {

        m_anim = GetComponent<Animator>();

    }

    IEnumerator HitAnimation()
    {
        ishit = false;
        canbehit = false;
        mesh1.SetActive (false);
        mesh2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        mesh1.SetActive(true);
        mesh2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        mesh1.SetActive(false);
        mesh2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        mesh1.SetActive(true);
        mesh2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        canbehit = true;
    }

    void Update()
    {
        if (ishit && canbehit)
        {
            health -= 1;
        }
        if (ishit == true)
        {
            StartCoroutine("HitAnimation");
        }

        if (Gamepad == false)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            transform.Rotate(0, x, 0);
            m_anim.SetFloat("Walk", Input.GetAxis("Vertical"));
            m_anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
            if (Input.GetButtonDown("Jump"))
            {
                m_anim.SetTrigger("Jump");
            }
            if (Input.GetButtonDown("Attack"))
            {
                m_anim.SetTrigger("Attack");
            }
            if (Input.GetButton("Running"))
            {
                m_anim.SetBool("Running", true);
            }
            else
            {
                m_anim.SetBool("Running", false);
            }
        }
        if (Gamepad == true)
        {
            var x = Input.GetAxis("HorizontalGamepad") * Time.deltaTime * 150.0f;
            transform.Rotate(0, x, 0);
            m_anim.SetFloat("Walk", Input.GetAxis("VerticalGamepad"));
            m_anim.SetFloat("Turn", Input.GetAxis("HorizontalGamepad"));
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                m_anim.SetTrigger("Jump");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                m_anim.SetTrigger("Attack");
            }
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                m_anim.SetBool("Running", true);
            }
            else
            {
                m_anim.SetBool("Running", false);
            }

        }
    }
}