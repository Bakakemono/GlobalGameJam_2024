using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveCarpet", menuName = "ScriptableObjects/RemoveCarpetEffect")]
public class RemoveCarpet : Choice
{
    public override void Effect() {
        Destroy(FindObjectOfType<Carpet>().gameObject);
    }
}
