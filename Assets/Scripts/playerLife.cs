using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    bool dead = false;

    [SerializeField] AudioSource deathSound;

    void Update()
    {
        if (transform.position.y < -30f && !dead)
        {
            Die();
        }
    }  
        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Die();
        }
    }
    void Die()
    {
        
        Invoke(nameof(ReloadLevel), 0.5f);
        dead = true;
        deathSound.Play();
      
        

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
