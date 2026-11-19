using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //‚Ë‚¶‚±‚ÌˆÊ’uî•ñ‚ğæ“¾‚·‚é•Ï”
    [SerializeField]
    private Transform nejikoTransform;

    private float cameraRockAt = 5f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, nejikoTransform.position.z - cameraRockAt);
    }
}
