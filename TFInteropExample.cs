using System;
using System.Reflection;

using UnityEngine;

namespace TestFlightAddon
{
    public class TFInteropExample : PartModule
    {
        // TestFlight Interop
        private Type tfInterop;
        private BindingFlags tfBindingFlags = BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static;

        public override void OnAwake()
        {
            base.OnAwake();
            Debug.Log("TFInteropExample: OnAwake");
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }

        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
            Debug.Log("TFInteropExample: OnLoad");
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public void Awake()
        {
            Debug.Log("TFInteropExample: Awake");
        }

        public void Start()
        {
            Debug.Log("TFInteropExample: Start");
            if (this.part.Modules.Contains("TestFlightInterop"))
            {
                tfInterop = this.part.Modules["TestFlightInterop"].GetType();
                tfInterop.InvokeMember("AddInteropValue", tfBindingFlags, null, null, new System.Object[] { "tank_type", "default", "TFInteropExample" });
            }
        }

    }
}

