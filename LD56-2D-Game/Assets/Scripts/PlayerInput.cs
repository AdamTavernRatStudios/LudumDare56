using System.Linq;
using UnityEngine;
using Rewired;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    private Player rewiredPlayer => ReInput.players.GetPlayer(0);

    public float MoveInput => rewiredPlayer?.GetAxis("Move") ?? 0f;
    public bool JumpIsPressed => rewiredPlayer?.GetButton("Jump") ?? false;
    public bool JumpJustPressed => rewiredPlayer?.GetButtonDown("Jump") ?? false;
    public bool JustJustReleased => rewiredPlayer?.GetButtonUp("Jump") ?? false;
    public bool SpinIsPressed => rewiredPlayer?.GetButton("Spin") ?? false;
    public bool SpinJustPressed => rewiredPlayer?.GetButtonDown("Spin") ?? false;
    public bool SpinJustReleased => rewiredPlayer?.GetButtonUp("Spin") ?? false;
}
