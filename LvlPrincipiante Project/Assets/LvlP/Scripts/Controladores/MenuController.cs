//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MenuController.cs (02/05/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controlador del menu principal.								\\
// Fecha Mod:		02/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using LvlP.SubSistemas;
#endregion

namespace LvlP.Controladores
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
		private const int mainx3Index = 2;                  // Index de Mainx3
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Animator Controller padre.</para>
		/// </summary>
		private Animator animController;                    // Animator Controller padre
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
		public void BtnDemo()
		{
			transform.parent.GetComponentInChildren<ManagerLoader>().CargarNivel("Demo");
		}

		public void BtnOpciones()
		{
			animController.SetInteger("Index", mainx2Index);
		}

		public void BtnVolver()
		{
			animController.SetInteger("Index", mainx1Index);
		}

		public void BtnSalir()
		{
			animController.SetInteger("Index", mainx3Index);
		}

		public void Salir()
		{
			Application.Quit();
		}
		#endregion
	}
}
