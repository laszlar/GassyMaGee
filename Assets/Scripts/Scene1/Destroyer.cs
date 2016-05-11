using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    int deathTime = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DeathAfterSec(deathTime));
        }
        Destroy(collision.gameObject);
        Debug.Log("destroyed");
    }

    IEnumerator DeathAfterSec (int deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene("Scene2");
    }
}
