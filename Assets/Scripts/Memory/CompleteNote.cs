using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompleteNote
{
    [SerializeField] string noteID;
    [SerializeField] Sprite image;
    [SerializeField] bool unlocked;

    public bool Unlocked { get => unlocked; set => unlocked = value; }
    public string NoteID { get => noteID; }
}
