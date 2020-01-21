using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSelector : MonoBehaviour
{
    [SerializeField] private float rayLenght = 120.0f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform forwardDir;

    [Space(10)] 
    [SerializeField] private ErrorEvent onShoot;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                //Shoot
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if(GameManager.instance != null)
            if (!GameManager.instance.GameStarted)
                return;
        
        Debug.Log("Forward : " + this.forwardDir.forward);
        Debug.Log("Position point : " + this.startPoint.position);
        
        RaycastHit hit;
        if (Physics.Raycast(this.startPoint.position, this.forwardDir.forward, out hit, this.rayLenght))
        {
            Error err = hit.transform.GetComponent<Error>();
            
            Debug.Log("Quelque chose de toucher : " + hit.transform.name);
            this.onShoot.Invoke(err);
            return;
        }
        
        //Si le raycast ne touche rien, il faut notifier qu'on a tiré
        this.onShoot.Invoke(null);
    }
}
