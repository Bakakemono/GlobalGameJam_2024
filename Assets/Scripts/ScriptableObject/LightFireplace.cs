using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_LightFireplace", menuName = "ScriptableObjects/RLightFireplaceEffect")]
public class LightFireplace : Choice
{
    public override void Effect() {
        FindObjectOfType<Fireplace>().gameObject.SetActive(true);
    }
}
