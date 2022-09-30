using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int playerIndex;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;

    public Animator animator;

    void Start()
    {
        playerIndex = player.GetComponent<ThirdPersonMovement>().GetIndex();

        currentAmmo = maxAmmo;

    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    // Update is called once per frame
    void Update()
    {

        if (ActivePlayerManager.GetInstance().IsItMyTurn(playerIndex))
        {
            if (isReloading)
                return;


            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)

            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                source.PlayOneShot(clip);
            }



        }

        IEnumerator Reload()
        {
            isReloading = true;
            Debug.Log("Reloading...");

            source.PlayOneShot(clip2);

            animator.SetBool("Reloading", true);

            yield return new WaitForSeconds(reloadTime - .25f);
            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.25f);

            currentAmmo = maxAmmo;
            isReloading = false;
        }



        void Shoot()
        {

            muzzleFlash.Play();

            currentAmmo--;

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                PlayerHealth target = hit.transform.GetComponent<PlayerHealth>();
                if (target != null)
                {
                    target.TakeDamage(damage);

                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }
}
