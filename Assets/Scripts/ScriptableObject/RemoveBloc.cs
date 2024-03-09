using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_RemoveBloc", menuName = "ScriptableObjects/RemoveBlocEffect")]
public class RemoveBloc : Choice
{
    public override void Effect() {
        List<Bloc> allBlocs = FindObjectsOfType<Bloc>().ToList<Bloc>();

        while(allBlocs.Count > 0) {
            Bloc sphere = allBlocs.First();
            allBlocs.RemoveAt(0);
            Destroy(sphere.gameObject);
        }
    }
}
