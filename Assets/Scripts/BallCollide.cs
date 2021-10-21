using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollide : MonoBehaviour
{
    public AudioSource explosionSound;

    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Buildings")
        {
            Debug.Log("Hit");
            if (GetComponent<Collider>().bounds.size.y > other.gameObject.GetComponent<Collider>().bounds.size.y)
            {
                Destroy(other.gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
                explosionSound.Play(0);
                transform.localScale += new Vector3(25f, 25f, 25f);
                Score.PlayerScore += 1;
            }
        }
        else if (other.gameObject.tag != "Buildings")
            Debug.Log("Incorrect Hit");
    }
}
