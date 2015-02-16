using System;
using System.Reflection;

using UnityEngine;

namespace TestFlightAddon
{
    public class TFInteropExample : PartModule
    {
        // TestFlight Interop
        private Type tfInterface = null;
        private BindingFlags tfBindingFlags = BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static;

        public override void OnAwake()
        {
            base.OnAwake();
            Debug.Log("TFInteropExample: OnAwake");

            tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore", false);

            if (tfInterface != null)
            {
                tfInterface.InvokeMember("AddInteropValue", tfBindingFlags, null, null, new System.Object[] { this.part, "tank_type", "default", "TFInteropExample" });
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }

        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
            Debug.Log("TFInteropExample: OnLoad");

            tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore", false);

            if (tfInterface != null)
            {
                tfInterface.InvokeMember("AddInteropValue", tfBindingFlags, null, null, new System.Object[] { this.part, "tank_type", "default", "TFInteropExample" });
            }
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public void Start()
        {
            Debug.Log("TFInteropExample: Start");

            tfInterface = Type.GetType("TestFlightCore.TestFlightInterface, TestFlightCore", false);

            if (tfInterface != null)
            {
                tfInterface.InvokeMember("AddInteropValue", tfBindingFlags, null, null, new System.Object[] { this.part, "tank_type", "default", "TFInteropExample" });
            }
        }

    }
}

