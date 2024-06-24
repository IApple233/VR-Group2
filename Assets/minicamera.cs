using UnityEngine;

public class SyncRotationWithCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 获取主相机的旋转
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // 创建新的旋转，x 和 z 轴不变，y 轴等于主相机的 y 轴旋转加上90度
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cameraRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        // 将当前物体的旋转设置为新的旋转
        transform.rotation = newRotation;

        // 获取主相机的位置
        Vector3 cameraPosition = Camera.main.transform.position;

        // 创建新的位置，x 坐标等于主相机的 x 坐标，y 和 z 坐标等于物体当前的 y 和 z 坐标
        Vector3 newPosition = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);

        // 将当前物体的位置设置为新的位置
        transform.position = newPosition;
    }
}
