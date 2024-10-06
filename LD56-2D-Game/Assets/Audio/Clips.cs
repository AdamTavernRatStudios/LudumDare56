using UnityEngine;
using System.Collections.Generic;

namespace Audio
{
public static class Clips
{
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) BlankClip => AudioManager.GetClip("BlankClip");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) healSound => AudioManager.GetClip("healSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_01 => AudioManager.GetClip("hit_01");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_02 => AudioManager.GetClip("hit_02");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_03 => AudioManager.GetClip("hit_03");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_04 => AudioManager.GetClip("hit_04");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_05 => AudioManager.GetClip("hit_05");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) loseSound => AudioManager.GetClip("loseSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit
    {
        get
        {
        var Clips = new (AudioSource audioSource, AudioDataCustomOverrides overrides)[]
        {
            hit_01,
            hit_02,
            hit_03,
            hit_04,
            hit_05,
        };
        return Clips[Random.Range(0, Clips.Length)];
        }
    }

    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) placeItem => AudioManager.GetClip("placeItem");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) ui_blip => AudioManager.GetClip("ui_blip");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) ui_blip_negative => AudioManager.GetClip("ui_blip_negative");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) winSound => AudioManager.GetClip("winSound");
    public static Dictionary<string, (AudioSource audioSource, AudioDataCustomOverrides overrides)> clipDict => new(){
       { "BlankClip", Clips.BlankClip},
       { "healSound", Clips.healSound},
       { "hit_01", Clips.hit_01},
       { "hit_02", Clips.hit_02},
       { "hit_03", Clips.hit_03},
       { "hit_04", Clips.hit_04},
       { "hit_05", Clips.hit_05},
       { "loseSound", Clips.loseSound},
       { "placeItem", Clips.placeItem},
       { "ui_blip", Clips.ui_blip},
       { "ui_blip_negative", Clips.ui_blip_negative},
       { "winSound", Clips.winSound},
       { "hit", Clips.hit},

   };
}
}
