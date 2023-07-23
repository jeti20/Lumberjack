using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // Obiekt, który przeciwnik bêdzie œciga³
    public float moveSpeed = 0.01f; // Szybkoœæ poruszania siê przeciwnika

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Obliczamy wektor kierunku, w którym przeciwnik powinien siê poruszaæ
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Poruszamy przeciwnika w wyliczonym kierunku
            rb.velocity = direction * moveSpeed;
        }
    }
}
