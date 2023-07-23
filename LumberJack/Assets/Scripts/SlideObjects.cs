using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SlideObjects : MonoBehaviour
{
    public DispawnHull dispawnHull;
    public Transform startSlicePoint;
    public VelocityEstimator velocityEstimator;
    public Transform endSlicePoint;
    public LayerMask sliceableLayer;
  
    public Material corssSectionMaterial;
    public float cutForce = 2000;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }



    public void Slice(GameObject target)
    {

        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, corssSectionMaterial);
            SetupSlicedComponent(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, corssSectionMaterial);
            SetupSlicedComponent(lowerHull);


            Destroy(target);
        }
    }

    

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider colider = slicedObject.AddComponent<MeshCollider>();
        colider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 10000000000);

        XRGrabInteractable Grab = slicedObject.AddComponent<XRGrabInteractable>();
        AddTagToObject(slicedObject, "Drewno");
    }

    private void AddTagToObject(GameObject obj, string tag)
    {
        obj.tag = tag;
    }
}
