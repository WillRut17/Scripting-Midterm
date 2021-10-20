using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Buildings")
        {
            Debug.Log("Hit");
            if (GetComponent<Collider>().bounds.size.y > other.gameObject.GetComponent<Collider>().bounds.size.y)
            {
                Destroy(other.gameObject);
                transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
        else if (other.gameObject.tag != "Buildings")
            Debug.Log("Incorrect Hit");
    }
}
