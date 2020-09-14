﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDL.Core
{
    public class FrameRateCounter : MonoBehaviour
    {
        
        int m_frameCounter = 0;
        float m_timeCounter = 0.0f;
        float m_lastFramerate = 0.0f;
        public float m_refreshTime = 0.5f;
        [SerializeField] Text fpsText;

        private void Update()
        {
            if(fpsText != null) fpsText.text = GetFrameRate().ToString();
        }

        public float GetFrameRate()
        {
            if (m_timeCounter < m_refreshTime)
            {
                m_timeCounter += Time.deltaTime;
                m_frameCounter++;
            }
            else
            {
                //This code will break if you set your m_refreshTime to 0, which makes no sense.
                m_lastFramerate = (float)m_frameCounter / m_timeCounter;
                m_frameCounter = 0;
                m_timeCounter = 0.0f;
            }

            return m_lastFramerate;
        }
    }
}
