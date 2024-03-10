using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_CloseTheGame", menuName = "ScriptableObjects/CloseTheGameEffect")]
public class CloseTheGame : Choice
{
    public override void Effect() {
        Application.Quit();
    }
}
