using System;
using System.Reflection;
using System.Collections;

using UnityEngine;

namespace TestFlightAddon
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class TFHybridInterfaceExample : MonoBehaviour
    {
        Type tfInterface = null;
        bool isReady = false;

        public void Start()
        {
            Debug.Log("TFHybridInterfaceExample: Start");
            try
            {
                tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore");
                if ((bool)tfInterface.InvokeMember("TestFlightInstalled", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null))
                {
                    Debug.Log("TFHybridInterfaceExample: Starting coroutine to wait until TestFlight is ready");
                    StartCoroutine("ConnectToTestFlight");
                }
            }
            catch
            {
                Debug.Log("TFHybridInterfaceExample: Failed to find Interface");
            }
        }

        IEnumerator ConnectToTestFlight()
        {
            while (!(bool)tfInterface.InvokeMember("TestFlightReady", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null))
                yield return null;

            Debug.Log("TFHybridInterfaceExample: TestFlight is ready");
            Startup();
        }

        void Startup()
        {
            Debug.Log("TFHybridInterfaceExample: Startup");
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
                    foreach (PartModule pm in part.Modules)
                    {
                        TestFlightAPI.ITestFlightCore core = pm as TestFlightAPI.ITestFlightCore;
                        if (core != null)
                        {
                            Debug.Log("TFHybridInterfaceExample: Found Core");
                            Debug.Log(String.Format("TFHybridInterfaceExample: Current FlightData for {0} is {1:f2}du", part.name, core.GetFlightData()));
                        }
                    }
                }
            }
        }
    }
}

