using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispawnHull : MonoBehaviour
{
    public LayerMask _scietyPieniek;
    private bool isInCollider = false;
    float amout = 0;
   
    private float timer = 0f;


    private void Update()
    {
        if (isInCollider)
        {
            timer += Time.deltaTime;
            if (timer >= 5f && gameObject.CompareTag("Drewno"));
            {
                // Usuñ obiekt
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drewno"))
        {
            Debug.Log("Enter");
            isInCollider = true;

        }

        if (other.CompareTag("Drewno"))
        {
            amout++;
            Debug.Log(amout);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drewno"))
        {
            Debug.Log("Exit");
        }
    }
}
