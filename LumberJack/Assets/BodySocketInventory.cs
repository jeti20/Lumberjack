using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class bodySocket
{
   
    public GameObject gameObject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}

public class BodySocketInventory : MonoBehaviour
{
    public GameObject HMD;
    public bodySocket[] SocketInteractors;

    private Vector3 _currentHMDPosition;
    private Quaternion _currentHMDRotation;

    private void Update()
    {
        //przypisanie pozycji kamery do zmiennych
        _currentHMDPosition = HMD.transform.position;
        _currentHMDRotation = HMD.transform.rotation;

        //dla kazdego socekta z tablicy
        foreach (var socketInteractor in SocketInteractors)
        {
            updatBodySocketHeight(socketInteractor);
        }
        UpdateSocketInventory();
    }

    private void updatBodySocketHeight(bodySocket bodySocket)
    {
        bodySocket.gameObject.transform.position = new Vector3(bodySocket.gameObject.transform.position.x, _currentHMDPosition.y * bodySocket.heightRatio, bodySocket.gameObject.transform.position.z);
    }

    private void UpdateSocketInventory()
    {
        transform.position = new Vector3(_currentHMDPosition.x, 0, _currentHMDPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x, _currentHMDRotation.y, transform.rotation.z, _currentHMDRotation.w);
    }
}
