using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ScaleUp", menuName = "ScriptableObjects/ScaleUpEffect")]
public class ScaleUp : Choice
{
    public override void Effect() {
        Transform roomTransform = FindObjectOfType<Scene>().transform;

        roomTransform.localScale =
            new Vector3(
                roomTransform.localScale.x,
                roomTransform.localScale.y * 10,
                roomTransform.localScale.z
                );
    }
}
