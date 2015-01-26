using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

using TestFlightAPI;

/************************************************************************************
 * IMPORTANT NOTE: This file is set to NOT compile, and therefore this PartModule 
 * will not be available in KSP.  This is done so that multiple developers don't 
 * accidently ship the same SimpleExample module.
 * 
 * Use this as an example.  If you want to use it as a base, then make a NEW file, 
 * copy this code into it and RENAME THE CLASS.
 * 
 * In this simple example all of the available methods are shown but most everything
 * is commented out.  This is because if you have a basic simple failure plugin, 
 * and you use the base class you really only need to implement two simple methods!
 * **********************************************************************************/

namespace TestFlightAddon
{
	public class TestFlightFailure_SimpleExample : TestFlightFailureBase
	{
        // PARTMODULE events that you may want to use, btu not really needed for a simple failure module
//		public override void OnAwake()
//		{
//			Debug.Log("TestFlightFailure_SimpleExample: OnAwake()");
//			base.OnAwake();
//		}
//        public override void OnStart(StartState state)
//		{
//			Debug.Log("TestFlightFailure_SimpleExample: OnSart()");
//			base.OnStart(state);
//		}

        /// <summary>
        /// Triggers the failure controlled by the failure module
        /// </summary>
        public override void DoFailure()
        {
            Debug.Log("TestFlightFailure_SimpleExample: DoFailure()");
            this.part.explode();
        }

        /// <summary>
        /// Repairs the failure.
        /// This method is not part of the public interface, but is used internally by the base class.
        /// If you wish to let the base class do most of the work fot you, then you can simply put
        /// the code neccesary for repairing your failure in here, and the base class will call
        /// it automatically when appropriate (IE all proper conditions have been met, and the
        /// repair chance roll succeeded)
        /// </summary>
        /// <returns>The time required to complete the repair, <c>0</c> if the repair is finished, or <c>-1</c> if the repair failed.</returns>
        public override double DoRepair()
        {
            Type.GetType("");
            Debug.Log("TestFlightFailure_SimpleExample: DoRepair()");
            return -1;
        }

        /******************************************************************************
         * All of the below methods are commented out because they are not needed
         * for a simple failure module where you use the base class to do all the
         * heavy work.  The base class will handle everything appropriately based
         * on the settings in the part's ConfigNode
         * ***************************************************************************/

		/// <summary>
		/// Gets the details of the failure encapsulated by this module.  In most cases you can let the base class take care of this unless oyu need to do somethign special
		/// </summary>
		/// <returns>The failure details.</returns>
//		public TestFlightFailureDetails GetFailureDetails()
//		{
//			TestFlightFailureDetails details = new TestFlightFailureDetails();
//
//            // Generally you would load this data from your config node, but you can do it however you want
//            // If you let the base class handle this, then it will automaticly fill it out as per the settings in the config node.
//
//            return details;
//		}
		/// <summary>
		/// Gets the repair requirements from the Failure module for display to the user
		/// </summary>
		/// <returns>A List of all repair requirements for attempting repair of the part</returns>
//		public List<RepairRequirements> GetRepairRequirements()
//		{
//            // Here you can indicate all requirements for repair, one per list item
//            // The base class will automaticly handle this as per settings in the config node
//
//            return null;
//		}
		/// <summary>
		/// Asks the repair module if all condtions have been met for the player to attempt repair of the failure. Here the module can verify things such as the conditions (landed, eva, splashed), parts requirements, etc
		/// </summary>
		/// <returns><c>true</c> if this instance can attempt repair; otherwise, <c>false</c>.</returns>
//		public override bool CanAttemptRepair()
//		{
//			Debug.Log("TestFlightFailure_SimpleExample: CanAttemptRepair()");
//			return true;
//		}
		/// <summary>
		/// Gets the seconds until repair is complete
		/// </summary>
		/// <returns>The seconds until repair is complete, <c>0</c> if repair is complete, and <c>-1</c> if something changed the inteerupt the repairs and reapir has stopped with the part still broken.</returns>
//		public double GetSecondsUntilRepair()
//		{
//			Debug.Log("TestFlightFailure_SimpleExample: GetSecondsUntilRepair()");
//			return 0;
//		}
		/// <summary>
		/// Trigger a repair ATTEMPT of the module's failure. It is the module's responsability to take care of any consumable resources, data transmission, etc required to perform the repair
		/// </summary>
		/// <returns>Should return the amount of seconds needed to complete repairs, <c>0></c> if repair is completed instantly, or <c>-1</c> if repair failed and has stopped.</returns>
//		public override double AttemptRepair()		
//		{			
//			Debug.Log("TestFlightFailure_SimpleExample: AttemptRepair()");			
//			return 0;
//		}	
		/// <summary>
		/// Forces the repair.  This should instantly repair the part, regardless of whether or not a normal repair can be done.  IOW if at all possible the failure should fixed after this call.
		/// This is made available as an API method to allow things like failure simulations.
		/// </summary>
		/// <returns><c>true</c>, if failure was repaired, <c>false</c> otherwise.</returns>
//		public bool ForceRepair()
//		{
//			Debug.Log("TestFlightFailure_SimpleExample: ForceRepair()");			
//			return true;
//		}
	}
}

