using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // プレイヤーの入力を受け取るスクリプト
    private InputAction jumpAction;
    private InputAction moveAction;
    private void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        // ジャンプの入力を表示
        if(jumpAction.triggered)
        {
            Debug.Log("ジャンプしたよ");
        }

        // 移動の入力を表示
        // 左右上下キーの入力Vector2（二次元方向）で出力
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // TODO：左右の入力を分割して取得、表示
    }
}
