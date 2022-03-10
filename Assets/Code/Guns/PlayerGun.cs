using System;
using UnityEngine;
using Zenject;

namespace Raketa420
{
    public class PlayerGun : MonoBehaviour, IGun
    {
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform barrel;
        [SerializeField] private Transform muzzle;
        [SerializeField] private BulletPlayer bullet;

        private Camera camera;
        private Crosshair crosshair;
        private Pointer pointer;
        private bool isBarrelNeedToBeDirected;

        [Inject]
        public void Construct(Camera camera, Crosshair crosshair, Pointer pointer)
        {
            this.crosshair = crosshair;
            this.pointer = pointer;
            this.camera = camera;
        }
        private void FixedUpdate()
        {
            if (!crosshair) 
                return;
            
            Ray ray = camera.ScreenPointToRay(crosshair.transform.position);
            Debug.DrawLine(ray.origin, ray.direction * 100f, Color.yellow);

            if (!Physics.Raycast(ray, out RaycastHit hitInfo)) 
                return;
            
            pointer.transform.position = hitInfo.point;
            
            if (isBarrelNeedToBeDirected)
            {
                barrel.rotation = Quaternion.LookRotation(hitInfo.point);
            }
        }

        public void Shoot()
        {
            ProjectileBase projectile = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bulletsParent);
            projectile.SetTarget(pointer.transform.position);
        }

        public void DirectBarrel()
        {
            isBarrelNeedToBeDirected = true;
        }

        public void UndirectBarrel()
        {
            isBarrelNeedToBeDirected = false;
        }
    }
}