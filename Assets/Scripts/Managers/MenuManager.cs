using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CRI.ConnectedGymnasium
{
	public class MenuManager : MonoBehaviour
	{
		// Menu gameObjects
		[SerializeField] private GameObject playMenu;
		[SerializeField] private GameObject mainMenu;
		[SerializeField] private GameObject calibrationMenu;
		[SerializeField] private GameObject exitMenu;

		// Button gameObjects
		[SerializeField] private Button playButton;
		[SerializeField] private Button calibrationButton;
		[SerializeField] private Button calibrateButton;
		[SerializeField] private Button backButtonPlay;
		[SerializeField] private Button backButtonCalibrate;
		[SerializeField] private Button pongButton;
		[SerializeField] private Button mazeButton;
		[SerializeField] private Button baryButton;
		[SerializeField] private Button exitButton;
		[SerializeField] private Button yesButton;
		[SerializeField] private Button backExitButton;


		// Calibration gameObject
		[SerializeField] private GameObject calibrationGO;

		public void PlayButtonListener()
		{
			mainMenu.SetActive(false);
			playMenu.SetActive(true);
		}

		public void BackButtonPlayListener()
		{
			mainMenu.SetActive(true);
			playMenu.SetActive(false);
		}
			
		public void BackButtonCalibrateListener()
		{
			mainMenu.SetActive(true);
			calibrationMenu.SetActive(false);
			calibrationGO.SetActive(false);
		}

		public void CalibrationButtonListener()
		{
			mainMenu.SetActive(false);
			calibrationMenu.SetActive(true);
			calibrationGO.SetActive(true);
		}

		public void CalibrateButtonListener()
		{
			calibrationGO.GetComponent<Calibration>().Calibrate();
			mainMenu.SetActive(true);
			calibrationMenu.SetActive(false);
		}

		public void PongButtonListener()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("PongUpgrade", LoadSceneMode.Single);
		}

		public void MazeButtonListener()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Maze", LoadSceneMode.Single);
		}

		public void BaryButtonListener()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Barycentre", LoadSceneMode.Single);
		}

		public void MusicalChairButtonListener()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Musical Chair", LoadSceneMode.Single);
		}

		public void ExitButtonListener()
		{
			mainMenu.SetActive(false);
			exitMenu.SetActive(true);
		}

		public void YesExitButtonListener()
		{
			Application.Quit();
		}

		public void BackExitButtonListener()
		{
			exitMenu.SetActive(false);
			mainMenu.SetActive(true);
		}
	}
}