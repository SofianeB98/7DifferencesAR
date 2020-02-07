using System;
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

    private Vector2 offsetRangeShot = new Vector2(400.0f,200.0f);

    private bool canShot = true;
    
    private void Start()
    {
        this.offsetRangeShot.x = Screen.width / 1.706667f / 2;
        this.offsetRangeShot.y = Screen.height / 1.706667f / 2;
    }

    private void Update()
    {
        if (!this.canShot)
            return;
        
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.position.x > Screen.width / 2 + offsetRangeShot.x 
                || t.position.x < Screen.width / 2 - offsetRangeShot.x
                || t.position.y > Screen.height / 2 + offsetRangeShot.y
                || t.position.y < Screen.height / 2 - offsetRangeShot.y)
                return;
                
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

    public void SetCanShot(bool val)
    {
        this.canShot = val;
    }

    public void SetCanShot()
    {
        this.canShot = !this.canShot;
    }
}
