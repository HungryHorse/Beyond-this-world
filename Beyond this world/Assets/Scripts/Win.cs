using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public AudioSource winSound;
    public GameObject Player;
    private bool won;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayWin();
            won = true;
        }
    }

    private void PlayWin()
    {
        Player.GetComponent<Movement>().enabled = false;
        Player.GetComponent<ChangeWorld>().enabled = false;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        Player.GetComponent<Animator>().SetBool("Ghost", false);
        Player.GetComponent<Animator>().Play("Fly");
        winSound.Play();
    }

    private void Update()
    {
        if (won)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, gameObject.transform.position, 0.01f);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, gameObject.transform.position, 0.01f);
        }
        if (Player.transform.position.y >= 0.8 && Player.transform.position.x >= 52)
        {
            SceneManager.LoadScene(2);
        }
    }
}
