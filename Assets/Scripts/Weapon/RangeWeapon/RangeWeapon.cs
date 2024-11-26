using UnityEngine;

namespace Weapon.RangeWeapon
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _weaponPoint;
        [SerializeField] private float _range;
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                var ray = _camera.ViewportPointToRay(_weaponPoint.position);

                if (Physics.Raycast(ray, out var hit, _range))
                {
                    if (hit.transform.TryGetComponent(out Enemy.Enemy enemy))
                    {
                        print(enemy.name);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(_weaponPoint.position, _weaponPoint.forward * _range, Color.red);
        }
    }
}