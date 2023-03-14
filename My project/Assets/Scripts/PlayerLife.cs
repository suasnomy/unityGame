using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] AudioSource fallingSound;
    bool dead = false;

    private void Update()
    {
        if(transform.position.y < -1f && !dead)
        {

            fallingSound.Play();
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;   //making invisible
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        
        
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        
        
    }

    void ReloadLevel()
    {
         //We accessed the currently Active Scene and it's name to reLoad after collion 
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
