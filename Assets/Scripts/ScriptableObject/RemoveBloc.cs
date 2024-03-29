using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveBloc", menuName = "ScriptableObjects/RemoveBlocEffect")]
public class RemoveBloc : Choice
{
    public override void Effect() {
        List<Plant> allPlants = FindObjectsOfType<Plant>().ToList<Plant>();
        
        while(allPlants.Count > 0) {
            Plant plant = allPlants.First();
            allPlants.RemoveAt(0);
            Destroy(plant.gameObject);
        }
    }
}
