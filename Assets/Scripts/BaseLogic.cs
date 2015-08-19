using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
   public abstract class BaseLogic : MonoBehaviour
    {
        public float size;
        public float startsize;
        public float speed;
        public float score;
        protected float coeficient;


        public virtual float ScaleMethod(PlayerController player, EnemyController enemy)
        {
            return size = player.size + enemy.size * Coeficient(coeficient);
        }
        public virtual float Coeficient(float denominator)
        {
            return coeficient = score / denominator;

        }
        public float CalculateCoeficient(PlayerController player, EnemyController enemy)
        {
            if (player.GetSize() > player.startsize * 2f)
            {
                return coeficient = enemy.GetSize() / 5;
            }
            if (player.GetSize() > player.startsize * 4f)
            {
                return coeficient = enemy.GetSize() / 8;
            }
            if (player.GetSize() > player.startsize * 6f)
            {
                return coeficient = enemy.GetSize() * 0.16f;
            }
            else
            {
                if (player.GetSize() < player.startsize * 2)
                {
                    if (player.GetSize() <= player.startsize * 0.5f)
                    {
                        return coeficient = enemy.GetSize() * 0.2f;
                    }
                    else
                    {
                        return coeficient = enemy.GetSize() * 0.25f;
                    }
                }
            }
            return coeficient;
        }
        public virtual float GetSize(float size)
        {
            return size;
        }
        public int Step(int n)
        {
            int step = 0;
            return step = n * (n + 2);
        }

    }
}
