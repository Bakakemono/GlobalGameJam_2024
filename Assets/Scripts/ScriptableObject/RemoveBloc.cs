using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_RemoveBloc", menuName = "ScriptableObjects/RemoveBlocEffect")]
public class RemoveBloc : Choice
{
    public override void Effect() {
        Bloc[] blocs = FindObjectsOfType<Bloc>();
        foreach(Bloc bloc in blocs) {
            Destroy(bloc);
        }
    }
}
