// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

[CreateAssetMenu(fileName = "StringVariable", menuName = "Variables/StringVariable", order = 142)]
public class StringVariable : ScriptableObject
{
    [SerializeField]
    private string value = "";

    public string Value {
        get { return value; }
        set { this.value = value; }
    }
}