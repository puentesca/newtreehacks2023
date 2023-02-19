using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi.TTS.Utilities;
public class TTSManager : MonoBehaviour
{
    public TTSSpeaker speaker;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void SpeakText(string text)
    {
        speaker.Speak(text);
    }
}