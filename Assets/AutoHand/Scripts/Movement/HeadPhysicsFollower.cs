using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autohand{
    [RequireComponent(typeof(Rigidbody))]
    public class HeadPhysicsFollower : MonoBehaviour{

        [Header("References")]
        public Camera headCamera;
        public Transform trackingContainer;
        public Transform followBody;

        [Header("Follow Settings")]
        public float followStrength = 50f;
        [Tooltip("The maximum allowed distance from the body for the headCamera to still move")]
        public float maxBodyDistance = 0.5f;

        internal SphereCollider headCollider;
        Vector3 startHeadPos;
        bool started;
        Transform _moveTo = null;
        Transform moveTo {
            get {
                if(!gameObject.activeInHierarchy)
                    return null;
                if(_moveTo == null) {
                    _moveTo = new GameObject().transform;
                    _moveTo.transform.rotation = transform.rotation;
                    _moveTo.rotation = transform.rotation;
                    _moveTo.name = "HEAD FOLLOW POINT";
                }

                return _moveTo;
            }
        }
        internal Rigidbody body;
        CollisionTracker collisionTracker = null;

        public void Start() {
            if(collisionTracker == null) {
                collisionTracker = gameObject.AddComponent<CollisionTracker>();
                collisionTracker.disableTriggersTracking = true;
            }
            body = GetComponent<Rigidbody>();
            gameObject.layer = LayerMask.NameToLayer(AutoHandPlayer.HandPlayerLayer);
            transform.position = headCamera.transform.position;
            transform.rotation = headCamera.transform.rotation;
            headCollider = GetComponent<SphereCollider>();
            startHeadPos = headCamera.transform.position;
        }


        internal void Init() {
            if(collisionTracker == null) {
                collisionTracker = gameObject.AddComponent<CollisionTracker>();
                collisionTracker.disableTriggersTracking = true;
            }
            gameObject.layer = LayerMask.NameToLayer(AutoHandPlayer.HandPlayerLayer);
            transform.position = headCamera.transform.position;
            transform.rotation = headCamera.transform.rotation;
            headCollider = GetComponent<SphereCollider>();
            startHeadPos = headCamera.transform.position;
        }

        protected void FixedUpdate() {
            moveTo.position = headCamera.transform.position;

            if(startHeadPos.y != headCamera.transform.position.y && !started) {
                started = true;
                body.position = headCamera.transform.position;
            }

            if(!started)
                return;
            
            
            moveTo.position = headCamera.transform.position;
            MoveTo();
        }

        public bool Started() {
            return started;
        }
        
        internal virtual void MoveTo() {
            var movePos = moveTo.position;
            var distance = Vector3.Distance(movePos, transform.position);
            
            //Sets velocity linearly based on distance from hand
            var vel = (movePos - transform.position).normalized * followStrength * distance;
            body.velocity = vel;
        }

        
        public int CollisionCount() {
            return collisionTracker.collisionCount;
        }

    }
}