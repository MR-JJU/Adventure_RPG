using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog 
{
//Textfield in unity to insert Text the npc´s can say 
    [SerializeField] List<string> lines;  

    public List<string> Lines 
    {
    get {return lines;}
    }
}
