using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Audio/AudioManager")]
public class AudioManager : ScriptableObject
{
    public List<ListSounds> listSounds;
}
[System.Serializable]
public class ListSounds
{
    public string NameSound;
    public int Number;
    public AudioClip AudioSound;
}