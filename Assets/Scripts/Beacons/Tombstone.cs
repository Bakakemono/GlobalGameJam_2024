using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{
    [SerializeField] GameObject[] RingAndTomb;

    public void Activate() {
        foreach (GameObject go in RingAndTomb) {
            go.SetActive(true);
        }
    }
}
