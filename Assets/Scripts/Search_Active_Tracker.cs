using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace CRI.ConnectedGymnasium
{
	public class Search_Active_Tracker : MonoBehaviour
	{
		private PlayerManager playerManager;
		void Start()
		{
			Debug.Log("Start");
			SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
			playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
			CheckForActiveTracker();
		}

		private void CheckForActiveTracker()
		{
			for (int i = 1; i < 10; i++)
			{
				ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)i);
				if (deviceClass == ETrackedDeviceClass.GenericTracker && OpenVR.System.IsTrackedDeviceConnected((uint)i))
				{
					Debug.Log("Tracker got connected at index:" + i);
					playerManager._trackers[i].GetComponent<ActiveTracker>().toActivate = true;
				}
			}
		}

		// A SteamVR device got connected/disconnected
		private void OnDeviceConnected(int index, bool connected)
		{

			if (connected)
			{
				if (OpenVR.System != null)
				{
					//lets figure what type of device got connected
					ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)index);
					if (deviceClass == ETrackedDeviceClass.Controller)
					{
						// not using any controllers at the moment
						Debug.Log("Controller got connected at index:" + index);
					}
					else if (deviceClass == ETrackedDeviceClass.GenericTracker)
					{
						Debug.Log("Tracker got connected at index:" + index);
						// index 0 is the HMD
						if (index > 0)
							playerManager._trackers[index - 1].GetComponent<ActiveTracker>().toActivate = true;
					}
				}
			}
		}
	}
}