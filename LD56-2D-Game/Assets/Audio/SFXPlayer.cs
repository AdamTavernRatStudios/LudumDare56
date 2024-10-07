using Audio;
using UnityEngine;
public class SFXPlayer : MonoBehaviour
{
    public void play_BlankClip(){AudioManager.PlayClip(Clips.BlankClip);}
    public void play_BlankClip_randomized(){AudioManager.PlayClip(Clips.BlankClip, AudioManager.GenericRandomizedData);}
    public void play_loop_BlankClip(float time){AudioManager.PlayClip(Clips.BlankClip, data: new() { Loop = true, LoopDuration = time});}
    public void play_BubbleGrow(){AudioManager.PlayClip(Clips.BubbleGrow);}
    public void play_BubbleGrow_randomized(){AudioManager.PlayClip(Clips.BubbleGrow, AudioManager.GenericRandomizedData);}
    public void play_loop_BubbleGrow(float time){AudioManager.PlayClip(Clips.BubbleGrow, data: new() { Loop = true, LoopDuration = time});}
    public void play_BubblePop(){AudioManager.PlayClip(Clips.BubblePop);}
    public void play_BubblePop_randomized(){AudioManager.PlayClip(Clips.BubblePop, AudioManager.GenericRandomizedData);}
    public void play_loop_BubblePop(float time){AudioManager.PlayClip(Clips.BubblePop, data: new() { Loop = true, LoopDuration = time});}
    public void play_CannonBlast(){AudioManager.PlayClip(Clips.CannonBlast);}
    public void play_CannonBlast_randomized(){AudioManager.PlayClip(Clips.CannonBlast, AudioManager.GenericRandomizedData);}
    public void play_loop_CannonBlast(float time){AudioManager.PlayClip(Clips.CannonBlast, data: new() { Loop = true, LoopDuration = time});}
    public void play_Coins(){AudioManager.PlayClip(Clips.Coins);}
    public void play_Coins_randomized(){AudioManager.PlayClip(Clips.Coins, AudioManager.GenericRandomizedData);}
    public void play_loop_Coins(float time){AudioManager.PlayClip(Clips.Coins, data: new() { Loop = true, LoopDuration = time});}
    public void play_DrumRoll(){AudioManager.PlayClip(Clips.DrumRoll);}
    public void play_DrumRoll_randomized(){AudioManager.PlayClip(Clips.DrumRoll, AudioManager.GenericRandomizedData);}
    public void play_loop_DrumRoll(float time){AudioManager.PlayClip(Clips.DrumRoll, data: new() { Loop = true, LoopDuration = time});}
    public void play_FireCrackleLoop(){AudioManager.PlayClip(Clips.FireCrackleLoop);}
    public void play_FireCrackleLoop_randomized(){AudioManager.PlayClip(Clips.FireCrackleLoop, AudioManager.GenericRandomizedData);}
    public void play_loop_FireCrackleLoop(float time){AudioManager.PlayClip(Clips.FireCrackleLoop, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_01(){AudioManager.PlayClip(Clips.FleaNoises_01);}
    public void play_FleaNoises_01_randomized(){AudioManager.PlayClip(Clips.FleaNoises_01, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_01(float time){AudioManager.PlayClip(Clips.FleaNoises_01, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_02(){AudioManager.PlayClip(Clips.FleaNoises_02);}
    public void play_FleaNoises_02_randomized(){AudioManager.PlayClip(Clips.FleaNoises_02, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_02(float time){AudioManager.PlayClip(Clips.FleaNoises_02, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_03(){AudioManager.PlayClip(Clips.FleaNoises_03);}
    public void play_FleaNoises_03_randomized(){AudioManager.PlayClip(Clips.FleaNoises_03, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_03(float time){AudioManager.PlayClip(Clips.FleaNoises_03, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_04(){AudioManager.PlayClip(Clips.FleaNoises_04);}
    public void play_FleaNoises_04_randomized(){AudioManager.PlayClip(Clips.FleaNoises_04, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_04(float time){AudioManager.PlayClip(Clips.FleaNoises_04, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_05(){AudioManager.PlayClip(Clips.FleaNoises_05);}
    public void play_FleaNoises_05_randomized(){AudioManager.PlayClip(Clips.FleaNoises_05, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_05(float time){AudioManager.PlayClip(Clips.FleaNoises_05, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_06(){AudioManager.PlayClip(Clips.FleaNoises_06);}
    public void play_FleaNoises_06_randomized(){AudioManager.PlayClip(Clips.FleaNoises_06, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_06(float time){AudioManager.PlayClip(Clips.FleaNoises_06, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_07(){AudioManager.PlayClip(Clips.FleaNoises_07);}
    public void play_FleaNoises_07_randomized(){AudioManager.PlayClip(Clips.FleaNoises_07, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_07(float time){AudioManager.PlayClip(Clips.FleaNoises_07, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_08(){AudioManager.PlayClip(Clips.FleaNoises_08);}
    public void play_FleaNoises_08_randomized(){AudioManager.PlayClip(Clips.FleaNoises_08, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_08(float time){AudioManager.PlayClip(Clips.FleaNoises_08, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_09(){AudioManager.PlayClip(Clips.FleaNoises_09);}
    public void play_FleaNoises_09_randomized(){AudioManager.PlayClip(Clips.FleaNoises_09, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_09(float time){AudioManager.PlayClip(Clips.FleaNoises_09, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_10(){AudioManager.PlayClip(Clips.FleaNoises_10);}
    public void play_FleaNoises_10_randomized(){AudioManager.PlayClip(Clips.FleaNoises_10, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_10(float time){AudioManager.PlayClip(Clips.FleaNoises_10, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_11(){AudioManager.PlayClip(Clips.FleaNoises_11);}
    public void play_FleaNoises_11_randomized(){AudioManager.PlayClip(Clips.FleaNoises_11, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_11(float time){AudioManager.PlayClip(Clips.FleaNoises_11, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_12(){AudioManager.PlayClip(Clips.FleaNoises_12);}
    public void play_FleaNoises_12_randomized(){AudioManager.PlayClip(Clips.FleaNoises_12, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_12(float time){AudioManager.PlayClip(Clips.FleaNoises_12, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_13(){AudioManager.PlayClip(Clips.FleaNoises_13);}
    public void play_FleaNoises_13_randomized(){AudioManager.PlayClip(Clips.FleaNoises_13, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_13(float time){AudioManager.PlayClip(Clips.FleaNoises_13, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_14(){AudioManager.PlayClip(Clips.FleaNoises_14);}
    public void play_FleaNoises_14_randomized(){AudioManager.PlayClip(Clips.FleaNoises_14, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_14(float time){AudioManager.PlayClip(Clips.FleaNoises_14, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_15(){AudioManager.PlayClip(Clips.FleaNoises_15);}
    public void play_FleaNoises_15_randomized(){AudioManager.PlayClip(Clips.FleaNoises_15, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_15(float time){AudioManager.PlayClip(Clips.FleaNoises_15, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_16(){AudioManager.PlayClip(Clips.FleaNoises_16);}
    public void play_FleaNoises_16_randomized(){AudioManager.PlayClip(Clips.FleaNoises_16, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_16(float time){AudioManager.PlayClip(Clips.FleaNoises_16, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_17(){AudioManager.PlayClip(Clips.FleaNoises_17);}
    public void play_FleaNoises_17_randomized(){AudioManager.PlayClip(Clips.FleaNoises_17, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_17(float time){AudioManager.PlayClip(Clips.FleaNoises_17, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_18(){AudioManager.PlayClip(Clips.FleaNoises_18);}
    public void play_FleaNoises_18_randomized(){AudioManager.PlayClip(Clips.FleaNoises_18, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_18(float time){AudioManager.PlayClip(Clips.FleaNoises_18, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_19(){AudioManager.PlayClip(Clips.FleaNoises_19);}
    public void play_FleaNoises_19_randomized(){AudioManager.PlayClip(Clips.FleaNoises_19, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_19(float time){AudioManager.PlayClip(Clips.FleaNoises_19, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_20(){AudioManager.PlayClip(Clips.FleaNoises_20);}
    public void play_FleaNoises_20_randomized(){AudioManager.PlayClip(Clips.FleaNoises_20, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_20(float time){AudioManager.PlayClip(Clips.FleaNoises_20, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_21(){AudioManager.PlayClip(Clips.FleaNoises_21);}
    public void play_FleaNoises_21_randomized(){AudioManager.PlayClip(Clips.FleaNoises_21, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_21(float time){AudioManager.PlayClip(Clips.FleaNoises_21, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_22(){AudioManager.PlayClip(Clips.FleaNoises_22);}
    public void play_FleaNoises_22_randomized(){AudioManager.PlayClip(Clips.FleaNoises_22, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_22(float time){AudioManager.PlayClip(Clips.FleaNoises_22, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_23(){AudioManager.PlayClip(Clips.FleaNoises_23);}
    public void play_FleaNoises_23_randomized(){AudioManager.PlayClip(Clips.FleaNoises_23, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_23(float time){AudioManager.PlayClip(Clips.FleaNoises_23, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_24(){AudioManager.PlayClip(Clips.FleaNoises_24);}
    public void play_FleaNoises_24_randomized(){AudioManager.PlayClip(Clips.FleaNoises_24, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_24(float time){AudioManager.PlayClip(Clips.FleaNoises_24, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_25(){AudioManager.PlayClip(Clips.FleaNoises_25);}
    public void play_FleaNoises_25_randomized(){AudioManager.PlayClip(Clips.FleaNoises_25, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_25(float time){AudioManager.PlayClip(Clips.FleaNoises_25, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises_26(){AudioManager.PlayClip(Clips.FleaNoises_26);}
    public void play_FleaNoises_26_randomized(){AudioManager.PlayClip(Clips.FleaNoises_26, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises_26(float time){AudioManager.PlayClip(Clips.FleaNoises_26, data: new() { Loop = true, LoopDuration = time});}
    public void play_healSound(){AudioManager.PlayClip(Clips.healSound);}
    public void play_healSound_randomized(){AudioManager.PlayClip(Clips.healSound, AudioManager.GenericRandomizedData);}
    public void play_loop_healSound(float time){AudioManager.PlayClip(Clips.healSound, data: new() { Loop = true, LoopDuration = time});}
    public void play_FleaNoises(){AudioManager.PlayClip(Clips.FleaNoises);}
    public void play_FleaNoises_randomized(){AudioManager.PlayClip(Clips.FleaNoises, AudioManager.GenericRandomizedData);}
    public void play_loop_FleaNoises(float time){AudioManager.PlayClip(Clips.FleaNoises, data: new() { Loop = true, LoopDuration = time});}
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
    public void play_HopOnOffBall(){AudioManager.PlayClip(Clips.HopOnOffBall);}
    public void play_HopOnOffBall_randomized(){AudioManager.PlayClip(Clips.HopOnOffBall, AudioManager.GenericRandomizedData);}
    public void play_loop_HopOnOffBall(float time){AudioManager.PlayClip(Clips.HopOnOffBall, data: new() { Loop = true, LoopDuration = time});}
    public void play_hit(){AudioManager.PlayClip(Clips.hit);}
    public void play_hit_randomized(){AudioManager.PlayClip(Clips.hit, AudioManager.GenericRandomizedData);}
    public void play_loop_hit(float time){AudioManager.PlayClip(Clips.hit, data: new() { Loop = true, LoopDuration = time});}
    public void play_loseSound(){AudioManager.PlayClip(Clips.loseSound);}
    public void play_loseSound_randomized(){AudioManager.PlayClip(Clips.loseSound, AudioManager.GenericRandomizedData);}
    public void play_loop_loseSound(float time){AudioManager.PlayClip(Clips.loseSound, data: new() { Loop = true, LoopDuration = time});}
    public void play_ObjectCreateSound(){AudioManager.PlayClip(Clips.ObjectCreateSound);}
    public void play_ObjectCreateSound_randomized(){AudioManager.PlayClip(Clips.ObjectCreateSound, AudioManager.GenericRandomizedData);}
    public void play_loop_ObjectCreateSound(float time){AudioManager.PlayClip(Clips.ObjectCreateSound, data: new() { Loop = true, LoopDuration = time});}
    public void play_placeItem(){AudioManager.PlayClip(Clips.placeItem);}
    public void play_placeItem_randomized(){AudioManager.PlayClip(Clips.placeItem, AudioManager.GenericRandomizedData);}
    public void play_loop_placeItem(float time){AudioManager.PlayClip(Clips.placeItem, data: new() { Loop = true, LoopDuration = time});}
    public void play_PogoBounce(){AudioManager.PlayClip(Clips.PogoBounce);}
    public void play_PogoBounce_randomized(){AudioManager.PlayClip(Clips.PogoBounce, AudioManager.GenericRandomizedData);}
    public void play_loop_PogoBounce(float time){AudioManager.PlayClip(Clips.PogoBounce, data: new() { Loop = true, LoopDuration = time});}
    public void play_TrampolineBounce(){AudioManager.PlayClip(Clips.TrampolineBounce);}
    public void play_TrampolineBounce_randomized(){AudioManager.PlayClip(Clips.TrampolineBounce, AudioManager.GenericRandomizedData);}
    public void play_loop_TrampolineBounce(float time){AudioManager.PlayClip(Clips.TrampolineBounce, data: new() { Loop = true, LoopDuration = time});}
    public void play_TrapezeGrab(){AudioManager.PlayClip(Clips.TrapezeGrab);}
    public void play_TrapezeGrab_randomized(){AudioManager.PlayClip(Clips.TrapezeGrab, AudioManager.GenericRandomizedData);}
    public void play_loop_TrapezeGrab(float time){AudioManager.PlayClip(Clips.TrapezeGrab, data: new() { Loop = true, LoopDuration = time});}
    public void play_TrapezeSound(){AudioManager.PlayClip(Clips.TrapezeSound);}
    public void play_TrapezeSound_randomized(){AudioManager.PlayClip(Clips.TrapezeSound, AudioManager.GenericRandomizedData);}
    public void play_loop_TrapezeSound(float time){AudioManager.PlayClip(Clips.TrapezeSound, data: new() { Loop = true, LoopDuration = time});}
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
