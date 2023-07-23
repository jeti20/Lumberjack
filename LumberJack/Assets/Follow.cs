using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // Obiekt, kt�ry przeciwnik b�dzie �ciga�
    public float moveSpeed = 0.01f; // Szybko�� poruszania si� przeciwnika

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Obliczamy wektor kierunku, w kt�rym przeciwnik powinien si� porusza�
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Poruszamy przeciwnika w wyliczonym kierunku
            rb.velocity = direction * moveSpeed;
        }
    }
}
