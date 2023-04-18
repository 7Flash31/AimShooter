using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private GameObject EscapePanel;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private float speedRotate;

    private float xRot;
    public bool isPaused;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        weaponController.isCanShoot = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            weaponController.isCanShoot = false;
            EscapePanel.SetActive(isPaused);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            weaponController.isCanShoot = true;
            EscapePanel.SetActive(isPaused);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate()
    {
        if(isPaused)
        {
            return;
        }

        Vector2 mou = new Vector2(Input.GetAxisRaw("Mouse X") * CanvasController.sensitivityValue, Input.GetAxisRaw("Mouse Y") * CanvasController.sensitivityValue);

        xRot -= mou.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mou.x);
    }
}
