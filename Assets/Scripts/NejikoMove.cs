using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class NejikoMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private PlayerInput playerInput = null;

    private bool isMoveKeyInput = false;

    private int axisMovePower = 1;

    //ねじこが飛んでいる最中かどうかの判定
    private bool isFlyFlag = false;
    //ねじこが最初にいたY座標(高さ)

    //落下速度
    [SerializeField]
    private float initialHeight = 0f;

    private float fallSpeed = 10f;

    private float totalTime = 0f;

    //ジャンプパワー
    [SerializeField]
    private float jumpPower = 2f;

    //private FlowStateTransitionEditor fallSpeed;

    //ゲーム開始時にねじこの高さを取得
    void Start()
    {
        initialHeight = this.transform.position.y;
    }

    private void Update()
    {
        float movePower = Time.deltaTime * moveSpeed;
        transform.Translate(0, 0, movePower);
        if (movePower > 0)
        {
            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
        }
        if (playerInput.inputMove.x == 0)
        {
            isMoveKeyInput = false;
        }
        if (playerInput.inputMove.x > 0 && isMoveKeyInput == false)
        {
            Debug.Log("右キー入力");
            transform.Translate(axisMovePower, 0, 0);
            isMoveKeyInput = true;
        }
        else if (playerInput.inputMove.x < 0 && isMoveKeyInput == false)
        {
            Debug.Log("左キー入力");
            transform.Translate(axisMovePower * -1, 0, 0);
            isMoveKeyInput = true;
        }
        if (playerInput.isJumpTrigger)
        {
            Debug.Log("ジャンプキー入力");
            this.transform.position += Vector3.up * jumpPower;
            //bool 0.1 true/false,飛んでいる/飛んでいないか
            isFlyFlag = true;
            
        }
        if(isFlyFlag == true)
        {
            //もしもねじこの現在のY座標(高さ)がinitialHeight(初期の初期の高さ)
            //よりも低くなったら処理を止める
            if (this.transform.position.y < initialHeight)
            {
                this.transform.position = new Vector3(this.transform.position.x, initialHeight, this.transform.position.z);
                isFlyFlag = false;
                totalTime = 0f;
                return;

            }
            //ねじこを徐々に下げる処理
            totalTime += Time.deltaTime;

            this.transform.position -= Vector3.up / fallSpeed * totalTime;
        }


    }
}