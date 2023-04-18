using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlashObj;
    [SerializeField] private Transform muzzleFlashSpawn;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shoot;

    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameController gameController;
    [SerializeField] private SpawnController spawnController;

    [SerializeField] private float range;
    [SerializeField] private float fireRate;

    public bool isCanShoot;

    private void Update()
    {
        audioSource.volume = CanvasController.musicValue;

        if(Input.GetKeyDown(KeyCode.Mouse0) && isCanShoot)
        {
            Shoot();

            GameObject muzzleFlash = Instantiate(muzzleFlashObj, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation, muzzleFlashSpawn);
            Destroy(muzzleFlash, 5f);
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        audioSource.PlayOneShot(shoot);

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if(hit.transform.gameObject.tag == "Good")
            {
                Destroy(hit.transform.gameObject);
                gameController.score++;
                scoreText.text = "Результат: " + gameController.score.ToString();
                gameController.SetSphere();
            }

            if(hit.transform.gameObject.tag == "Bad")
            {
                Destroy(hit.transform.gameObject);
                gameController.score -= 5;
                scoreText.text = "Результат: " + gameController.score.ToString();
            }

            if(hit.transform.gameObject.tag == "Super")
            {
                Destroy(hit.transform.gameObject);
                gameController.score += 5;
                scoreText.text = "Результат: " + gameController.score.ToString();
            }
        }
    }
}
