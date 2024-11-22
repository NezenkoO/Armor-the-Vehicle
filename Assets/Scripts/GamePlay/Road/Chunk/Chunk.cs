using UnityEngine;
using GamePlay.Enemy;

namespace GamePlay
{
    public abstract class Chunk : MonoBehaviour
    {
        public IChunkReclaimer ChunkReclaimer { get; set; }
        public Transform Begin => begin;
        public Transform End => end;

        [SerializeField] private Transform begin, end;

        public void ChangeTransformBasedOnPreviousChunk(Chunk previousChunk)
        {
            transform.position = previousChunk.Begin.position - End.localPosition;
        }

        public virtual void SpawnEnemiesOnChunk(EnemiesSpawner enemiesSpawner, int count)
        {
            Vector3 roadDirection = (end.position - begin.position).normalized;
            float roadLength = Vector3.Distance(begin.position, end.position);

            for (int i = 0; i < count; i++)
            {
                float randomDistance = Random.Range(0f, roadLength);
                Vector3 enemyPosition = begin.position + roadDirection * randomDistance;

                Vector3 roadWidthOffset = Vector3.right * Random.Range(-5f, 5f);
                enemyPosition += roadWidthOffset;

                var enemy = enemiesSpawner.SpawnZombie(new EnemyContext(0.4f, 1, 1, 100, 1));
                enemy.transform.position = enemyPosition;
            }
        }

        public void Recycle()
        {
            if (ChunkReclaimer == null)
            {
                Destroy(gameObject);
                return;
            }
            ChunkReclaimer.Reclaim(this);
        }
    }
}
