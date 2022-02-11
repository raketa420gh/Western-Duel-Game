using UnityEngine;

namespace Raketa420
{
    public class PlayerGun : MonoBehaviour, ICharacterGun
    {
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform pointer;
        [SerializeField] private Transform barrel;
        [SerializeField] private Transform muzzle;
        [SerializeField] private BulletPlayer bullet;
        private Crosshair crosshair;
        private bool isBarrelNeedToBeDirected;

        private void Start()
        {
            crosshair = FindObjectOfType<Crosshair>();
        }

        private void FixedUpdate()
        {
            if (crosshair != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
                Debug.DrawLine(ray.origin, ray.direction * 100f, Color.yellow);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    pointer.position = hitInfo.point;

                    if (isBarrelNeedToBeDirected)
                    {
                        barrel.rotation = Quaternion.LookRotation(hitInfo.point);
                    }
                }
            }
        }

        public void Shoot()
        {
            var bulletObject = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bulletsParent);
            var projectile = bulletObject.GetComponent<BulletPlayer>();
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
