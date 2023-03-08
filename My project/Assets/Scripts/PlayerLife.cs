using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    void Die()
    {
        
        GetComponent<MeshRenderer>().enabled = false;   //making invisible
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
        
        
    }

    void ReloadLevel()
    {
        //We accessed the currently Active Scene and it's name to reLoad after collion 
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
