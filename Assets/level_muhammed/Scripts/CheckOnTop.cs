using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnTop : MonoBehaviour
{
    public float raycastDistance = 1f;
    public PhysicMaterial bouncyMaterial;
    public PhysicMaterial normalMaterial;
    private List<GameObject> cubesOnTop = new List<GameObject>();

    private void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, -Vector3.up, raycastDistance);

        cubesOnTop.Clear(); // List leeghalen

        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("platform"))
            {
                cubesOnTop.Add(hit.collider.gameObject);
            }
        }

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("platform");
        foreach (var cube in cubes)
        {
            MeshCollider cubeCollider = cube.GetComponent<MeshCollider>();
            if (cubeCollider != null)
            {
                if (cubesOnTop.Contains(cube))
                {
                    cubeCollider.material = normalMaterial;
                }
                else
                {
                    cubeCollider.material = bouncyMaterial;
                }
            }
        }
    }
}
