using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GamePlay.Projectiles
{
    public class ProjectilesContainer : MonoBehaviour
    {
        [Inject] private ProjectileFactory _projectileFactory;

        private List<Projectile> _projectiles = new();    

        public Projectile Spawn(ProjectileType type, ProjectileContext context)
        {
            var projectile = _projectileFactory.Create(type, context);
            _projectiles.Add(projectile);
            return projectile;
        }

        public void Clear()
        {
            _projectiles.ForEach(p => Destroy(p.gameObject));
            _projectiles.Clear();
        }
    }
}
