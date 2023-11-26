using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrella : MonoBehaviour
{
    [SerializeField]
    private int cantBalas = 10;


    [SerializeField]
    private int numPuntas = 6;

    [SerializeField]
    

    private Vector2 direccionMovimientoBala;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    public void Fire()
    {
        float angleStep = 360f / cantBalas;
        float angle = 0f;

        for (int i = 0; i < cantBalas + 1; i++)
        {

            
            float balaDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float balaDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 vectorBalaMover = new Vector3(balaDirX, balaDirY, 0f);
            Vector2 balaDir = (vectorBalaMover - transform.position).normalized;

            float VelExtra = Mathf.Abs(Mathf.Sin(numPuntas * angle * (Mathf.PI / 360f))) * -1f;


            GameObject bala = BulletPool.instanciadePool.GetBullet();
            bala.transform.position = transform.position;
            bala.transform.rotation = transform.rotation;
            bala.SetActive(true);
            bala.GetComponent<Bala>().cambioDireccion(balaDir,VelExtra);

            

            if (angle >= 360f)
            {
                angle = 0;
            }

            angle += angleStep;
        }





    }
}
