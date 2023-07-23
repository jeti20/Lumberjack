using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AddingWoods : MonoBehaviour
{
    public XRSocketInteractor[] socketInteractors;
    public GameObject particlePrefabFire;
    public GameObject particlePrefabSmoke;

    public Transform spawnPointFire;
    public Transform spawnPointSmoke;

    private bool hasGeneratedParticle = false;
    private GameObject spawnedFire;
    private GameObject spawnedSmoke;

    private void Update()
    {
        bool allSocketsOccupied = true;

        foreach (var interactor in socketInteractors)
        {
            if (interactor.selectTarget is XRBaseInteractable interactable)
            {
                if (!interactable.isSelected)
                {
                    allSocketsOccupied = false;
                    break;
                }
            }
            else
            {
                allSocketsOccupied = false;
                break;
            }
        }

        if (allSocketsOccupied && !hasGeneratedParticle)
        {
            hasGeneratedParticle = true;
            GenerateParticle();
            StartCoroutine(WaitAndDestroyObjects());
        }
    }

    private IEnumerator WaitAndDestroyObjects()
    {
        foreach (var interactor in socketInteractors)
        {
            if (interactor.selectTarget is XRBaseInteractable interactable)
            {
                yield return new WaitForSeconds(2f); // Czekamy 5 sekund przed zniszczeniem nastêpnego obiektu
                Destroy(interactable.gameObject);
            }
        }

        Destroy(spawnedFire);
        Destroy(spawnedSmoke);
        hasGeneratedParticle = false; // Zresetuj flagê hasGeneratedParticle do false, aby cz¹stki mog³y zostaæ wygenerowane ponownie
    }

    private void GenerateParticle()
    {
        spawnedFire = Instantiate(particlePrefabFire, spawnPointFire.position, Quaternion.identity);
        spawnedSmoke = Instantiate(particlePrefabSmoke, spawnPointSmoke.position, Quaternion.identity);
    }

}
