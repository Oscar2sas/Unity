using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoCircular : MonoBehaviour
{
    [SerializeField]
    private int cantBalas = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 direccionMovimientoBala;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / cantBalas;
        float angle = startAngle;

        for (int i = 0; i < cantBalas + 1; i++)
        {
            float balaDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float balaDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            float ses = 0;

            Vector3 vectorBalaMover = new Vector3(balaDirX, balaDirY, 0f);
            Vector2 balaDir = (vectorBalaMover - transform.position).normalized;

            GameObject bala = BulletPool.instanciadePool.GetBullet();
                bala.transform.position = transform.position;
                bala.transform.rotation = transform.rotation;
                bala.SetActive(true);
                bala.GetComponent<Bala>().cambioDireccion(balaDir,ses);

            angle += angleStep;
        }




        
    }
}
