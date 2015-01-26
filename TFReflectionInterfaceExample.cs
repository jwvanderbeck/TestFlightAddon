using System;
using System.Reflection;
using System.Collections;

using UnityEngine;

namespace TestFlightAddon
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class TFReflectionInterfaceExample : MonoBehaviour
    {
        Type tfInterface = null;
        bool isReady = false;

        public void Start()
        {
            Debug.Log("TFReflectionInterfaceExample: Start");
            try
            {
                tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore");
                if ((bool)tfInterface.InvokeMember("TestFlightInstalled", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null))
                {
                    Debug.Log("TFReflectionInterfaceExample: Starting coroutine to wait until TestFlight is ready");
                    StartCoroutine("ConnectToTestFlight");
                }
            }
            catch
            {
                Debug.Log("TFReflectionInterfaceExample: Failed to find Interface");
            }
        }

        IEnumerator ConnectToTestFlight()
        {
            while (!(bool)tfInterface.InvokeMember("TestFlightReady", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null))
                yield return null;

            Debug.Log("TFReflectionInterfaceExample: TestFlight is ready");
            Startup();
        }

        void Startup()
        {
            Debug.Log("TFReflectionInterfaceExample: Startup");
            isReady = true;
        }

        public void Update()
        {
            if (!isReady)
                return;

            foreach (Part part in FlightGlobals.ActiveVessel.parts)
            {
                bool tfAvailableOnPart = (bool)tfInterface.InvokeMember("TestFlightAvailable", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] { part });
                if (tfAvailableOnPart)
                {
                    double flightData = (double)tfInterface.InvokeMember("GetFlightData", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] { part });
                    Debug.Log(String.Format("TFReflectionInterfaceExample: Current FlightData for {0} is {1:f2}du", part.name, flightData));
                }
            }
        }
    }
}

