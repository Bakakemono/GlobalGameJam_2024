using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveTorches", menuName = "ScriptableObjects/RemoveTorchesEffect")]
public class RemoveTorches : Choice
{
    public override void Effect() {
        List<Torches> torches = FindObjectsOfType<Torches>().ToList<Torches>();

        while(torches.Count > 0) {
            Torches torche = torches.First();
            torches.RemoveAt(0);
            Destroy(torche.gameObject);
        }
    }
}
