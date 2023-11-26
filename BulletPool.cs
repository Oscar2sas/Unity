using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instanciadePool;
    [SerializeField]
    private GameObject pooledBullet;
    private bool nocoso = true;

    private List<GameObject> balas;

    private void Awake()
    {
        instanciadePool = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        balas = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (balas.Count > 0)
        {
            for (int i = 0; i < balas.Count; i++)
            {
                if (!balas[i].activeInHierarchy)
                {
                    return balas[i];
                }
            }
        }

        if (nocoso)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            balas.Add(bul);
            return bul;
        }

        return null;
    }
}
