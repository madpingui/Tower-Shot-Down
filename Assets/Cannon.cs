using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform rotator;
    public bool isMyTurn;
    public GameObject myCamera;
    public Transform hole;
    public GameObject bulletPrefab;

    public GameObject enemyCam;
    public Cannon enemy;

    private float speed = 0.2f;

    void Update()
    {
        if (isMyTurn)
        {
            float h = Input.GetAxisRaw("Horizontal") * speed;
            float v = Input.GetAxisRaw("Vertical") * speed;
            rotator.RotateAround(rotator.transform.position, Vector3.up, h);
            rotator.Rotate(-v, 0, 0);

            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Fire());
                isMyTurn = false;
            }
        }
    }

    IEnumerator Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, hole.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(hole.up * 3000);
        yield return new WaitForSeconds(2.5f);
        myCamera.SetActive(false);
        enemyCam.SetActive(true);
        enemy.isMyTurn = true;
    }
}
