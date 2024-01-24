using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static void StartMusicInStartGame(){
        StaticStorage.MusicInStartGameMenuStatic.Play();
        Debug.Log(8);
        StaticStorage.MusicInZoneStatic.Stop();
        StaticStorage.MusicInLabStatic.Stop();
    }
    public static void StartMusicInLab(){
        StaticStorage.MusicInStartGameMenuStatic.Stop();
        StaticStorage.MusicInZoneStatic.Stop();
        StaticStorage.MusicInLabStatic.Play();
    }
    public static void StartMusicInZone(){
        StaticStorage.MusicInStartGameMenuStatic.Stop();
        StaticStorage.MusicInZoneStatic.Play();
        StaticStorage.MusicInLabStatic.Stop();
    }
}
