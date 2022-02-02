using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HologramInstruction", menuName = "Hologram Instruction")]
public class HologramInstruction : ScriptableObject
{
    //data for the Object
    public string ObjectName;
    public GameObject ObjectModel;
}
