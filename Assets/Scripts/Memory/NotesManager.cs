using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    [SerializeField] List<NoteFragment> allFragmants;
    [SerializeField] List<CompleteNote> allNotes;

    [SerializeField] Dictionary<string, List<NoteFragment>> fragmentsByNote;

    void Start()
    {
        OrganizeFragments();
        //LoadGame();
    }

    void OrganizeFragments()
    {
        fragmentsByNote = new Dictionary<string, List<NoteFragment>>();

        foreach(var fragment in allFragmants)
        {
            if (!fragmentsByNote.ContainsKey(fragment.NoteID))
                fragmentsByNote[fragment.NoteID] = new List<NoteFragment>();

            fragmentsByNote[fragment.NoteID].Add(fragment);
        }
    }

    public void CollectFragment(string noteId, int fragmentIndex)
    {
        var fragment = allFragmants.FirstOrDefault(f => f.NoteID == noteId && f.FragmentIndex == fragmentIndex);
        if(fragment != null && !fragment.Collected)
        {
            fragment.Collected = true;
            CheckCompleteNote(noteId);
            //SaveGame();
        }
    }

    void CheckCompleteNote(string noteID)
    {
        if (fragmentsByNote[noteID].All(f => f.Collected))
        {
            var note = allNotes.FirstOrDefault(n => n.NoteID == noteID);
            if(note != null)
            {
                note.Unlocked = true;
                Debug.Log($"Anotação completa desbloqueada: {noteID}");
            }
        }
    }

    public bool IsNoteComplete(string noteID)
    {
        return allNotes.Any(n => n.NoteID == noteID && n.Unlocked);
    }

/*    public void SaveGame()
    {
        string json = JsonUtility.ToJson(this, true);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }*/
}
