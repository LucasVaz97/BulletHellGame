using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float rotationSpeed;
    public bool rotateRight;
    float attackTimer;
    public float fireRatio;
    public bool isShooting;

    // Start is called before the first frame update
    void Start()
    {

        firePoint = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(ShootRoutine(fireRatio));
        }

        if (isShooting)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            ChangeRotation();


        }


    }

    void Shoot()
    {
        Vector2 b = firePoint.up * -bulletForce;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rd = bullet.GetComponent<Rigidbody2D>();
        rd.AddForce(b, ForceMode2D.Impulse);

    }



    void ChangeRotation()

    {
        float angle = transform.eulerAngles.z;
        if (angle >= 90f && angle <= 180f && rotateRight == true)
        {

            rotationSpeed = rotationSpeed * -1;
            rotateRight = false;

        }
        else if (angle <= 270f && angle >= 180f && rotateRight == false)
        {


            rotationSpeed = rotationSpeed * -1;
            rotateRight = true;

        }

    }


    private IEnumerator ShootRoutine(float waitTime)
    {
        isShooting = true;
        attackTimer = 4f;
        while (attackTimer >= 0)
        {
            yield return new WaitForSeconds(waitTime);
            attackTimer = attackTimer - waitTime;
            Shoot();
        }
        isShooting = false;
        transform.rotation = Quaternion.identity;

    }


    public void CallRoutine()
    {
        StartCoroutine(ShootRoutine(fireRatio));
    }





}
