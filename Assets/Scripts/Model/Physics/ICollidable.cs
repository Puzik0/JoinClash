using UnityEngine;
namespace Model.Physics
{
    public interface ICollidable
    {
        void OnCollisionEnter(Collision collision);
        void OnCollisionStay(Collision collision);
        void OnCollisionExit(Collision collision);
    }
}