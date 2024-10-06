using Audio;
using UnityEngine;
public class SFXPlayer : MonoBehaviour
{
    public void play_BlankClip(){AudioManager.PlayClip(Clips.BlankClip);}
    public void play_BlankClip_randomized(){AudioManager.PlayClip(Clips.BlankClip, AudioManager.GenericRandomizedData);}
    public void play_loop_BlankClip(float time){AudioManager.PlayClip(Clips.BlankClip, data: new() { Loop = true, LoopDuration = time});}
    public void play_healSound(){AudioManager.PlayClip(Clips.healSound);}
    public void play_healSound_randomized(){AudioManager.PlayClip(Clips.healSound, AudioManager.GenericRandomizedData);}
    public void play_loop_healSound(float time){AudioManager.PlayClip(Clips.healSound, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit_01(){AudioManager.PlayClip(Clips.hit_01);}
    public void play_hit_01_randomized(){AudioManager.PlayClip(Clips.hit_01, AudioManager.GenericRandomizedData);}
    public void play_loop_hit_01(float time){AudioManager.PlayClip(Clips.hit_01, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit_02(){AudioManager.PlayClip(Clips.hit_02);}
    public void play_hit_02_randomized(){AudioManager.PlayClip(Clips.hit_02, AudioManager.GenericRandomizedData);}
    public void play_loop_hit_02(float time){AudioManager.PlayClip(Clips.hit_02, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit_03(){AudioManager.PlayClip(Clips.hit_03);}
    public void play_hit_03_randomized(){AudioManager.PlayClip(Clips.hit_03, AudioManager.GenericRandomizedData);}
    public void play_loop_hit_03(float time){AudioManager.PlayClip(Clips.hit_03, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit_04(){AudioManager.PlayClip(Clips.hit_04);}
    public void play_hit_04_randomized(){AudioManager.PlayClip(Clips.hit_04, AudioManager.GenericRandomizedData);}
    public void play_loop_hit_04(float time){AudioManager.PlayClip(Clips.hit_04, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit_05(){AudioManager.PlayClip(Clips.hit_05);}
    public void play_hit_05_randomized(){AudioManager.PlayClip(Clips.hit_05, AudioManager.GenericRandomizedData);}
    public void play_loop_hit_05(float time){AudioManager.PlayClip(Clips.hit_05, data: new() { Loop = true, LoopDuration = time});}
    public void play_loseSound(){AudioManager.PlayClip(Clips.loseSound);}
    public void play_loseSound_randomized(){AudioManager.PlayClip(Clips.loseSound, AudioManager.GenericRandomizedData);}
    public void play_loop_loseSound(float time){AudioManager.PlayClip(Clips.loseSound, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit(){AudioManager.PlayClip(Clips.hit);}
    public void play_hit_randomized(){AudioManager.PlayClip(Clips.hit, AudioManager.GenericRandomizedData);}
    public void play_loop_hit(float time){AudioManager.PlayClip(Clips.hit, data: new() { Loop = true, LoopDuration = time});}
    public void play_placeItem(){AudioManager.PlayClip(Clips.placeItem);}
    public void play_placeItem_randomized(){AudioManager.PlayClip(Clips.placeItem, AudioManager.GenericRandomizedData);}
    public void play_loop_placeItem(float time){AudioManager.PlayClip(Clips.placeItem, data: new() { Loop = true, LoopDuration = time});}
    public void play_ui_blip(){AudioManager.PlayClip(Clips.ui_blip);}
    public void play_ui_blip_randomized(){AudioManager.PlayClip(Clips.ui_blip, AudioManager.GenericRandomizedData);}
    public void play_loop_ui_blip(float time){AudioManager.PlayClip(Clips.ui_blip, data: new() { Loop = true, LoopDuration = time});}
    public void play_ui_blip_negative(){AudioManager.PlayClip(Clips.ui_blip_negative);}
    public void play_ui_blip_negative_randomized(){AudioManager.PlayClip(Clips.ui_blip_negative, AudioManager.GenericRandomizedData);}
    public void play_loop_ui_blip_negative(float time){AudioManager.PlayClip(Clips.ui_blip_negative, data: new() { Loop = true, LoopDuration = time});}
    public void play_winSound(){AudioManager.PlayClip(Clips.winSound);}
    public void play_winSound_randomized(){AudioManager.PlayClip(Clips.winSound, AudioManager.GenericRandomizedData);}
    public void play_loop_winSound(float time){AudioManager.PlayClip(Clips.winSound, data: new() { Loop = true, LoopDuration = time});}
}
