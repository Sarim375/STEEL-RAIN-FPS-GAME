using System.Collections;
using System.Transactions;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 200f;
    public float impaceForce = 50f;
    public float fireRate = 10f;


    private float nextBullet = 0f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public Camera fpsCam;

    private bool isReloading = false;
    public ParticleSystem muzzleFlash;
    public float reloadTime = 1f;

    public bool isScoped = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0) {


            StartCoroutine(Reload());
            currentAmmo = maxAmmo;
            return;
        
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!isScoped)
            {
                animator.SetBool("Scope", true);
                isScoped = true;
                fpsCam.fieldOfView = 45;
            }
            else
            {
                animator.SetBool("Scope", false);
                isScoped = false;
                fpsCam.fieldOfView = 60;
            }
           
        }
        if (Input.GetButton("Fire1") && Time.time >=nextBullet)     
        {
                nextBullet = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    IEnumerator Reload()
    {
        Debug.Log("Reloding");
        isReloading = true;
        animator.SetBool("Reload", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reload", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
       
    }

    void Shoot()
    {
        SoundManager.Instance.shootingSoundM4.Play();
        animator.SetTrigger("RECOIL");
        muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);
            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * impaceForce);
            }
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if ( (enemy !=null))
            {
                enemy.GetDamage(damage);
            }

        }
    }
}
