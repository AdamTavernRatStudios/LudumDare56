using UnityEngine;
using System.Collections.Generic;

namespace Audio
{
public static class Clips
{
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) BlankClip => AudioManager.GetClip("BlankClip");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) BubbleGrow => AudioManager.GetClip("BubbleGrow");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) BubblePop => AudioManager.GetClip("BubblePop");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) CannonBlast => AudioManager.GetClip("CannonBlast");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) Coins => AudioManager.GetClip("Coins");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) DrumRoll => AudioManager.GetClip("DrumRoll");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FireCrackleLoop => AudioManager.GetClip("FireCrackleLoop");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_01 => AudioManager.GetClip("FleaNoises_01");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_02 => AudioManager.GetClip("FleaNoises_02");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_03 => AudioManager.GetClip("FleaNoises_03");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_04 => AudioManager.GetClip("FleaNoises_04");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_05 => AudioManager.GetClip("FleaNoises_05");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_06 => AudioManager.GetClip("FleaNoises_06");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_07 => AudioManager.GetClip("FleaNoises_07");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_08 => AudioManager.GetClip("FleaNoises_08");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_09 => AudioManager.GetClip("FleaNoises_09");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_10 => AudioManager.GetClip("FleaNoises_10");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_11 => AudioManager.GetClip("FleaNoises_11");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_12 => AudioManager.GetClip("FleaNoises_12");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_13 => AudioManager.GetClip("FleaNoises_13");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_14 => AudioManager.GetClip("FleaNoises_14");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_15 => AudioManager.GetClip("FleaNoises_15");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_16 => AudioManager.GetClip("FleaNoises_16");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_17 => AudioManager.GetClip("FleaNoises_17");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_18 => AudioManager.GetClip("FleaNoises_18");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_19 => AudioManager.GetClip("FleaNoises_19");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_20 => AudioManager.GetClip("FleaNoises_20");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_21 => AudioManager.GetClip("FleaNoises_21");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_22 => AudioManager.GetClip("FleaNoises_22");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_23 => AudioManager.GetClip("FleaNoises_23");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_24 => AudioManager.GetClip("FleaNoises_24");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_25 => AudioManager.GetClip("FleaNoises_25");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises_26 => AudioManager.GetClip("FleaNoises_26");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) healSound => AudioManager.GetClip("healSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) FleaNoises
    {
        get
        {
        var Clips = new (AudioSource audioSource, AudioDataCustomOverrides overrides)[]
        {
            FleaNoises_01,
            FleaNoises_02,
            FleaNoises_03,
            FleaNoises_04,
            FleaNoises_05,
            FleaNoises_06,
            FleaNoises_07,
            FleaNoises_08,
            FleaNoises_09,
            FleaNoises_10,
            FleaNoises_11,
            FleaNoises_12,
            FleaNoises_13,
            FleaNoises_14,
            FleaNoises_15,
            FleaNoises_16,
            FleaNoises_17,
            FleaNoises_18,
            FleaNoises_19,
            FleaNoises_20,
            FleaNoises_21,
            FleaNoises_22,
            FleaNoises_23,
            FleaNoises_24,
            FleaNoises_25,
            FleaNoises_26,
        };
        return Clips[Random.Range(0, Clips.Length)];
        }
    }

    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_01 => AudioManager.GetClip("hit_01");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_02 => AudioManager.GetClip("hit_02");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_03 => AudioManager.GetClip("hit_03");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_04 => AudioManager.GetClip("hit_04");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) hit_05 => AudioManager.GetClip("hit_05");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) HopOnOffBall => AudioManager.GetClip("HopOnOffBall");
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

    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) loseSound => AudioManager.GetClip("loseSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) ObjectCreateSound => AudioManager.GetClip("ObjectCreateSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) placeItem => AudioManager.GetClip("placeItem");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) PogoBounce => AudioManager.GetClip("PogoBounce");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) TrampolineBounce => AudioManager.GetClip("TrampolineBounce");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) TrapezeGrab => AudioManager.GetClip("TrapezeGrab");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) TrapezeSound => AudioManager.GetClip("TrapezeSound");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) ui_blip => AudioManager.GetClip("ui_blip");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) ui_blip_negative => AudioManager.GetClip("ui_blip_negative");
    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) winSound => AudioManager.GetClip("winSound");
    public static Dictionary<string, (AudioSource audioSource, AudioDataCustomOverrides overrides)> clipDict => new(){
       { "BlankClip", Clips.BlankClip},
       { "BubbleGrow", Clips.BubbleGrow},
       { "BubblePop", Clips.BubblePop},
       { "CannonBlast", Clips.CannonBlast},
       { "Coins", Clips.Coins},
       { "DrumRoll", Clips.DrumRoll},
       { "FireCrackleLoop", Clips.FireCrackleLoop},
       { "FleaNoises_01", Clips.FleaNoises_01},
       { "FleaNoises_02", Clips.FleaNoises_02},
       { "FleaNoises_03", Clips.FleaNoises_03},
       { "FleaNoises_04", Clips.FleaNoises_04},
       { "FleaNoises_05", Clips.FleaNoises_05},
       { "FleaNoises_06", Clips.FleaNoises_06},
       { "FleaNoises_07", Clips.FleaNoises_07},
       { "FleaNoises_08", Clips.FleaNoises_08},
       { "FleaNoises_09", Clips.FleaNoises_09},
       { "FleaNoises_10", Clips.FleaNoises_10},
       { "FleaNoises_11", Clips.FleaNoises_11},
       { "FleaNoises_12", Clips.FleaNoises_12},
       { "FleaNoises_13", Clips.FleaNoises_13},
       { "FleaNoises_14", Clips.FleaNoises_14},
       { "FleaNoises_15", Clips.FleaNoises_15},
       { "FleaNoises_16", Clips.FleaNoises_16},
       { "FleaNoises_17", Clips.FleaNoises_17},
       { "FleaNoises_18", Clips.FleaNoises_18},
       { "FleaNoises_19", Clips.FleaNoises_19},
       { "FleaNoises_20", Clips.FleaNoises_20},
       { "FleaNoises_21", Clips.FleaNoises_21},
       { "FleaNoises_22", Clips.FleaNoises_22},
       { "FleaNoises_23", Clips.FleaNoises_23},
       { "FleaNoises_24", Clips.FleaNoises_24},
       { "FleaNoises_25", Clips.FleaNoises_25},
       { "FleaNoises_26", Clips.FleaNoises_26},
       { "healSound", Clips.healSound},
       { "hit_01", Clips.hit_01},
       { "hit_02", Clips.hit_02},
       { "hit_03", Clips.hit_03},
       { "hit_04", Clips.hit_04},
       { "hit_05", Clips.hit_05},
       { "HopOnOffBall", Clips.HopOnOffBall},
       { "loseSound", Clips.loseSound},
       { "ObjectCreateSound", Clips.ObjectCreateSound},
       { "placeItem", Clips.placeItem},
       { "PogoBounce", Clips.PogoBounce},
       { "TrampolineBounce", Clips.TrampolineBounce},
       { "TrapezeGrab", Clips.TrapezeGrab},
       { "TrapezeSound", Clips.TrapezeSound},
       { "ui_blip", Clips.ui_blip},
       { "ui_blip_negative", Clips.ui_blip_negative},
       { "winSound", Clips.winSound},
       { "FleaNoises", Clips.FleaNoises},
       { "hit", Clips.hit},

   };
}
}
