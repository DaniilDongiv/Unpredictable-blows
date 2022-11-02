using UnityEngine;
using Random = System.Random;

namespace Script
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int Idle = Animator.StringToHash("idle");
        private static readonly int Hit1 = Animator.StringToHash("hit1");
        private static readonly int Hit2 = Animator.StringToHash("hit2");

        void Start()
        {
            _animator = GetComponent<Animator>();
        }
    
        private void Update()
        {
            var idle = true;
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += Vector3.forward/50;
                _animator.SetInteger(Speed, 1);
                idle = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += Vector3.back/60;
                _animator.SetInteger(Speed, -1);
                idle = !idle;
            }

            if (Input.GetMouseButtonUp(0))
            {
                var randomAnim = new Random();
                var anim = randomAnim.Next(0, 2);
                if (anim == 0)
                {
                    _animator.SetTrigger(Hit1);
                }
                if (anim == 1)
                {
                    _animator.SetTrigger(Hit2);
                }
            }
            _animator.SetBool(Idle,idle);
        }
    }
}