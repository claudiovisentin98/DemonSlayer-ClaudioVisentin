using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public Text health;
    public Text kills;
    public Text GameOver;
    public Image black;

    private void Awake()
    {
        GameOver.enabled = false;
        black.enabled = false;
    }
    void Update () {
	    health.text = ("Health : " + Controls.health);
        kills.text = ("Kills : " + Controls.kills);
        if (Controls.health <= 0)
        {
            StartCoroutine("Reset");
        }
	}

   IEnumerator Reset ()
    {
        GameOver.enabled = true;
        black.enabled = true;
        yield return new WaitForSeconds(3);
        Controls.health = 30;
        SceneManager.LoadScene("MainLevel");
    }
}
