using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingTree : MonoBehaviour
{
    public float hitCount = 0;
    public int requiredHits = 1;
    public GameObject smallerTreePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            hitCount++;
            Debug.Log("Liczba trafieñ: " + hitCount);

            if (hitCount >= requiredHits)
            {
                // Rozdziel drzewo na 4 mniejsze elementy
                SplitTree();
                Debug.Log("Drzewo podzielone");
            }
        }
    }

    private void SplitTree()
    {
        Destroy(gameObject);

        GameObject smallerTree1 = Instantiate(smallerTreePrefab, transform.position, transform.rotation);
        GameObject smallerTree2 = Instantiate(smallerTreePrefab, transform.position, transform.rotation);
        GameObject smallerTree3 = Instantiate(smallerTreePrefab, transform.position, transform.rotation);
        GameObject smallerTree4 = Instantiate(smallerTreePrefab, transform.position, transform.rotation);
    }

}
