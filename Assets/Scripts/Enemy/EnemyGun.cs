using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;

public class EnemyGun : MonoBehaviour {
    public Bullet enemyBullet;
    public float force = 1000f;
    List<Bullet> bullets;

    Stopwatch watch;

    void Start()
    {
        bullets = new List<Bullet>();
        watch = new Stopwatch();
        watch.Start();
    }

	// Update is called once per frame
	void Update () {
        if (bullets.Count > 10)
        {
            return;
        }

        if (watch.Elapsed.Milliseconds > Random.Range(500, 2000))
        {
            Bullet bullet = Instantiate(enemyBullet, transform.position, transform.rotation) as Bullet;
            bullet.Create(MagnetType.ORANGE, force);
            bullets.Add(bullet);

            watch.Reset();
            watch.Start();
        }

    }
}
