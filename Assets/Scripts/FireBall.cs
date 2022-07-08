using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public Vector2 ShootPointVec;
    public float FireRate;
    float ReadyForNextShot;

    void Update()
    {
        if (FindObjectOfType<GameManager>().HasFire == true)
        {
            if(Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1/FireRate;
                shoot();
            }
        }
    }

    public void WayHeLooking(Vector2 Looking)
    {
        ShootPointVec = Looking;
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(ShootPointVec * BulletSpeed);
        BulletIns.GetComponent<Movement>().SetinitialDirection(ShootPointVec);

        Destroy(BulletIns, 2f);
        while(BulletIns.gameObject == true)
        {
            BulletIns.GetComponent<Movement>().SetinitialDirection(ShootPointVec);
        }
    }
}
