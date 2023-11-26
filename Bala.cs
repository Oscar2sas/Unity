using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    

    private void OnEnable()
    {
        Invoke("Destruir", 3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = moveSpeed ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void cambioDireccion(Vector2 dir, float velExt)
    {
        moveSpeed = 5f;
        moveDirection = dir;
        moveSpeed = moveSpeed * velExt;
    }   

    public void Destruir()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
