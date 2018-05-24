//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MenuController.cs (23/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controlador del menu principal.								\\
// Fecha Mod:		23/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using LvlP.SubSistemas;
using LvlP.Sistemas;
#endregion

namespace LvlP.Controllers
{
	/// <summary>
	/// <para>Controlador del menu principal.</para>
	/// </summary>
	public class MenuController : MonoBehaviour 
	{
		#region Constantes
		/// <summary>
		/// <para>Index de Mainx1.</para>
		/// </summary>
		private const int mainx1Index = 0;					// Index de Mainx1
		/// <summary>
		/// <para>Index de Mainx2.</para>
		/// </summary>
		private const int mainx2Index = 1;					// Index de Mainx2
		/// <summary>
		/// <para>Index de Mainx3.</para>
		/// </summary>
		private const int mainx3Index = 2;					// Index de Mainx3
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Animator Controller padre.</para>
		/// </summary>
		private Animator animController;					// Animator Controller padre
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Animator de Mainx1.</para>
		/// </summary>
		public Animator Mainx1Animator { get; private set; }
		/// <summary>
		/// <para>Animator de Mainx2.</para>
		/// </summary>
		public Animator Mainx2Animator { get; private set; }
		/// <summary>
		/// <para>Animator de Mainx3.</para>
		/// </summary>
		public Animator Mainx3Animator { get; private set; }
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializacion de <see cref="MenuController"/>.</para>
		/// </summary>
		private void Awake()// Inicializacion de MenuController
		{
			// Asignamos el animator del objeto
			animController = this.GetComponent<Animator>();

			// Asignamos el transform del objeto
			var transformLocalCache = this.GetComponent<Transform>();

			// Asignamos a las propiedades cada uno de los animators
			Mainx1Animator = transformLocalCache.Find("Mainx1").GetComponent<Animator>();
			Mainx2Animator = transformLocalCache.Find("Mainx2").GetComponent<Animator>();
			Mainx3Animator = transformLocalCache.Find("Mainx3").GetComponent<Animator>();
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Btn para iniciar la demo.</para>
		/// </summary>
		public void BtnDemo()// Btn para iniciar la demo
		{
			ManagerGame.Instance.escenaActual = ManagerGame.EscenaActual.Demo;
			transform.parent.GetComponentInChildren<ManagerLoader>().CargarNivel("Demo");
		}

		/// <summary>
		/// <para>Btn para abrir el menu opciones.</para>
		/// </summary>
		public void BtnOpciones()// Btn para abrir el menu opciones
		{
			animController.SetInteger("Index", mainx2Index);
		}

		/// <summary>
		/// <para>Btn para abrir el menu volver.</para>
		/// </summary>
		public void BtnVolver()// Btn para abrir el menu volver
		{
			animController.SetInteger("Index", mainx1Index);
		}

		/// <summary>
		/// <para>Btn para abrir el menu salir.</para>
		/// </summary>
		public void BtnSalir()// Btn para abrir el menu salir
		{
			animController.SetInteger("Index", mainx3Index);
		}

		/// <summary>
		/// <para>Btn para salir de la app.</para>
		/// </summary>
		public void Salir()// Btn para salir de la app
		{
			Application.Quit();
		}

		/// <summary>
		/// <para>Btn para cambiar el nivel grafico a low.</para>
		/// </summary>
		public void BtnGraficLow()// Btn para cambiar el nivel grafico a low
		{
			QualitySettings.SetQualityLevel(0, true);
			Debug.Log(QualitySettings.GetQualityLevel());
		}

		/// <summary>
		/// <para>Btn para cambiar el nivel grafico a Medio.</para>
		/// </summary>
		public void BtnGraficMed()// Btn para cambiar el nivel grafico a Medio
		{
			QualitySettings.SetQualityLevel(2, true);
			Debug.Log(QualitySettings.GetQualityLevel());
		}

		/// <summary>
		/// <para>Btn para cambiar el nivel grafico a Alto.</para>
		/// </summary>
		public void BtnGraficHig()// Btn para cambiar el nivel grafico a Alto
		{
			QualitySettings.SetQualityLevel(6, true);
			Debug.Log(QualitySettings.GetQualityLevel());
		}

		/// <summary>
		/// <para>Cambio de muteo.</para>
		/// </summary>
		/// <param name="tog"></param>
		public void CambioMute(Toggle tog)// Cambio de muteo
		{
			ManagerGame.Instance.GetComponent<ManagerAudio>().Mute = tog.isOn;
		}
		#endregion
	}
}
