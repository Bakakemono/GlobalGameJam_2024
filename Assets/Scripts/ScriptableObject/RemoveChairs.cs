using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveChairs", menuName = "ScriptableObjects/RemoveChairsEffect")]
public class RemoveChair : Choice
{
    public override void Effect() {
        List<Chair> allChairs = FindObjectsOfType<Chair>().ToList<Chair>();

        while(allChairs.Count > 0) {
            Chair chair = allChairs.First();
            allChairs.RemoveAt(0);
            Destroy(chair.gameObject);
        }
    }
}
