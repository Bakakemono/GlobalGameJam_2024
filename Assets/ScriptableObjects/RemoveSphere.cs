using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveSphere", menuName = "ScriptableObjects/RemoveSphereEffect", order = 1)]
public class RemoveSphere : Choice
{
    public override void Effect() {
        Sphere[] allSphere = FindObjectsOfType<Sphere>();
        foreach (Sphere sphere in allSphere) {
            Destroy(sphere);
        }
    }
}
