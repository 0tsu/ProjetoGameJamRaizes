using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteFragment
{
    [SerializeField] string noteID;
    [SerializeField] int fragmentIndex;
    [SerializeField] Sprite iamge;
    [SerializeField] bool collected;

    public string NoteID { get => noteID; }
    public int FragmentIndex { get => fragmentIndex; }
    public bool Collected { get => collected; set => collected = value; }
}
