using UnityEngine;

namespace Raketa420
{
    public class PlayerGun : MonoBehaviour, IGun
    {
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform barrel;
        [SerializeField] private Transform muzzle;
        [SerializeField] private BulletPlayer bullet;
        
        private Crosshair crosshair;
        private Transform pointer;
        private bool isBarrelNeedToBeDirected;

        public void Initialize()
        {
            crosshair = FindObjectOfType<Crosshair>();
            pointer = FindObjectOfType<DebugSphere>().transform;
        }

        private void FixedUpdate()
        {
            if (!crosshair) 
                return;
            
            Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
            Debug.DrawLine(ray.origin, ray.direction * 100f, Color.yellow);

            if (!Physics.Raycast(ray, out RaycastHit hitInfo)) 
                return;
            
            pointer.position = hitInfo.point;
            
            if (isBarrelNeedToBeDirected)
            {
                barrel.rotation = Quaternion.LookRotation(hitInfo.point);
            }
        }

        public void Shoot()
        {
            ProjectileBase projectile = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bulletsParent);
            projectile.SetTarget(pointer.position);
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