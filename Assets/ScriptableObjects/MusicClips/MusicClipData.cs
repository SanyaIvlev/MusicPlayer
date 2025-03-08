using UnityEngine;

[CreateAssetMenu(fileName = "MusicClipData", menuName = "MusicClipData")]
public class MusicClipData : ScriptableObject
{
    public AudioClip audioClip;
    public string Name;
    public string Author;
    public Texture Icon;
}