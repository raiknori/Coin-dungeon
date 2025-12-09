using UnityEngine;

[System.Serializable]
public class AudioValue
{
    [SerializeField] public string audioName;
    [SerializeField] public AudioClip audioClip;
    [SerializeField] public bool randomPitched;
}