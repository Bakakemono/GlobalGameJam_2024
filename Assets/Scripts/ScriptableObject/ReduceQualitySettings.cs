using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_ReduceQualitySetting", menuName = "ScriptableObjects/ReduceQualityEffect")]
public class ReduceQualitySettings : Choice
{
    public override void Effect() {
        //QualitySettings.globalTextureMipmapLimit = 0;
    }
}
