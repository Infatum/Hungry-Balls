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
        public float speed;
        public float score;
        private float coeficient;


        
        //public int Score()
        //{

        //}
        public virtual float ScaleMethod(PlayerController player, EnemyController enemy)
        {
            return size = player.size + enemy.size * 0.4f;
        }
        public virtual float Coeficient()
        {
            return coeficient = score / 10;

        }
        public virtual float GetSize(float size)
        {
            return size;
        }
        public int Step(int n)
        {
            int step = 0;
            return step = n + 2;
            n++;
        }

    }
}
