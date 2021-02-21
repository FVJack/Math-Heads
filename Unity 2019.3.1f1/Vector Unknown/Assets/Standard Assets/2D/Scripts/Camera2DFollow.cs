using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float m_OffsetY = 4f;
        public float m_OffsetZ;

        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
           
            m_LastTargetPosition = target.position + Vector3.up * m_OffsetY;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;            
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ + Vector3.up * m_OffsetY;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }

        public float getCameraHeight()
        {
            return m_OffsetY;
        }

        public void setCameraHeight(float val)
        {
            Debug.Log("camera change");
            m_OffsetY = val;
        }

        public float getCameraZoom()
        {
            return m_OffsetZ;
        }

        public void setCameraZoom(float val)
        {
            Debug.Log("camera change");
            m_OffsetZ = val;
        }

    }
}
