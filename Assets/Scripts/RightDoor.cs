using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    MagicalDoorsManager _magicalDoorsManager;
    private void Start() {
        _magicalDoorsManager = FindObjectOfType<MagicalDoorsManager>();
    }


}
