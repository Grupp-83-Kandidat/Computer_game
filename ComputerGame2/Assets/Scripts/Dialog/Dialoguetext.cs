using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/ new Dialog behållare")]
public class Dialoguetext : ScriptableObject
{
    public string namn;
    [TextArea(5, 10)]
    public string[] paragrafer;
}
