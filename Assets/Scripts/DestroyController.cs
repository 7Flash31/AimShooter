using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float sphereRadius;

    private void Start()
    {
        Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, sphereRadius);

        if(overlappingColliders.Length > 1)
        {
            meshRenderer.enabled = false;
        }

        StartCoroutine(DestroyGameObject());
    }

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
