using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_DeActivateObjects", menuName = "ScriptableObjects/DeActivateObjectsEffect")]
public class DeActivateObjects : Choice
{
    [SerializeField] List<GameObject> _objectsToEnable;
    [SerializeField] List<GameObject> _objectToDisable;

    public override void Effect() {
        foreach (GameObject obj in _objectsToEnable) {
            obj.SetActive(true);
        }
        foreach (GameObject obj in _objectToDisable) {
            obj.SetActive(false);
        }
    }
}
