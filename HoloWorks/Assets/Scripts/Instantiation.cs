using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    public void Instantiate()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
