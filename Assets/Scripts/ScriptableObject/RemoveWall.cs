using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveWalls", menuName = "ScriptableObjects/RemoveWallsEffect")]
public class RemoveWall : Choice
{
    public override void Effect() {
        List<Wall> walls = FindObjectsOfType<Wall>().ToList<Wall>();

        while(walls.Count > 0) {
            Wall wall = walls.First();
            walls.RemoveAt(0);
            Destroy(wall.gameObject);
        }
    }
}
