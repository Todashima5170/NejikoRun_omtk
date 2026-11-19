using UnityEngine;

public class NejikoHitAction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // ねじ子が衝突した時に処理される箇所
        Debug.Log("衝突したよ");
    }
}
