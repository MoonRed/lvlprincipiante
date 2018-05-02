//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerGame.cs (02/05/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager general del game.									\\
// Fecha Mod:		02/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlP.Sistemas
{
	/// <summary>
	/// <para>Manager general del game.</para>
	/// </summary>
	public class ManagerGame : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Escena actual del game.</para>
		/// </summary>
		public EscenaActual escenaActual;                               // Escena actual del game
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Instancia del <see cref="ManagerGame"/>.</para>
		/// </summary>
		private static ManagerGame instance;                            // Instancia del ManagerGame
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Instancia de <see cref="ManagerGame"/>.</para>
		/// </summary>
		public static ManagerGame Instance
		{
			get { return instance; }
		}
		#endregion

		#region Enums
		/// <summary>
		/// <para>Escena actual del game.</para>
		/// </summary>
		public enum EscenaActual
		{
			Menu,
			Demo
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="ManagerGame"/>.</para>
		/// </summary>
		private void Awake()// Inicializador de ManagerGame
		{
			// Destruir instancia si no es esta
			if (instance != null && instance != this)
			{
				Destroy(this.gameObject);
				return;
			}

			// No destruir objeto
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}

		/// <summary>
		/// <para>Cargador de <see cref="ManagerGame"/>.</para>
		/// </summary>
		private void Start()// Cargador de ManagerGame
		{
			escenaActual = EscenaActual.Menu;
		}
		#endregion

	}
}
