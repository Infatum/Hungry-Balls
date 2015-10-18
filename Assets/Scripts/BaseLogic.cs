using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// 
    /// </summary>
   public abstract class BaseLogic : MonoBehaviour
    {
        
        public float startsize = 1;
        public float size;
        public float speed;
        public int score;
        protected float coeficient;
        protected int step = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public virtual float ScaleMethod(PlayerController player, EnemyController enemy)
        {
            return size += CalculateCoeficient(player, enemy) * enemy.GetSize();
        }
        /// <summary>
        /// Calculates the coeficients for scaling
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public float CalculateCoeficient(PlayerController player, EnemyController enemy)
        {
            if (player.GetSize() > player.startsize * 2f)
            {
                return coeficient = 0.012f;
            }
            if (player.GetSize() > player.startsize * 4f)
            {
                return coeficient = 0.015f;
            }
            if (player.GetSize() > player.startsize * 6f)
            {
                return coeficient = enemy.GetSize() * 0.016f;
            }
            else
            {
                if (player.GetSize() < player.startsize * 2)
                {
                    if (player.GetSize() <= player.startsize * 0.5f)
                    {
                        return coeficient = enemy.GetSize() * 0.02f;
                    }
                    else
                    {
                        return coeficient = enemy.GetSize() * 0.025f;
                    }
                }
            }
            return coeficient;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public virtual float GetSize(float size)
        {
            return size;
        }
        
    }
}
