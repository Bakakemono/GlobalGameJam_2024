using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_RemoveAllNormalMaps", menuName = "ScriptableObjects/RemoveNormalMapsEffect")]
public class RemoveAllNormalMaps : Choice
{
    [SerializeField] Texture2D flatNormalMap;
    public override void Effect() {
        MeshRenderer[] meshRenderers = FindObjectsOfType<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers) {
            meshRenderer.material.SetTexture("_BumpMap", flatNormalMap);
        }
    }
}
