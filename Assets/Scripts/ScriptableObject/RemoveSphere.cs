using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveSphere", menuName = "ScriptableObjects/RemoveSphereEffect")]
public class RemoveSphere : Choice
{
    public override void Effect() {
        List<Sphere> allSphere = FindObjectsOfType<Sphere>().ToList<Sphere>();
        
        while (allSphere.Count > 0) {
            Sphere sphere = allSphere.First();
            allSphere.RemoveAt(0);
            Destroy(sphere.gameObject);
        }
    }
}
