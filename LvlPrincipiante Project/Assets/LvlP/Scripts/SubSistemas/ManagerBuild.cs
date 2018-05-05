//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerBuild.cs (02/05/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager de la construccion de torres.						\\
// Fecha Mod:		02/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlP.SubSistemas
{
	/// <summary>
	/// <para>Manager de la construccion de torres.</para>
	/// </summary>
	public class ManagerBuild : MonoBehaviour 
	{
		#region Singleton
		/// <summary>
		/// <para>Instancia de <see cref="ManagerBuild"/>.</para>
		/// </summary>
		public static ManagerBuild instance;                // Instancia de ManagerBuild
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Prefab de la torre para instanciar.</para>
		/// </summary>
		public GameObject torrePrefab;                      // Prefab de la torre para instanciar
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Siguiente torre para construir.</para>
		/// </summary>
		private GameObject torreAConstruir;                 // Siguiente torre para construir
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="ManagerBuild"/>.</para>
		/// </summary>
		private void Awake()// Inicializador de ManagerBuild
		{
			// Singleton simple
			if (instance != null)
			{
				return;
			}
			instance = this;
		}

		/// <summary>
		/// <para>Cargador de <see cref="ManagerBuild"/>.</para>
		/// </summary>
		private void Start()// Cargador de ManagerBuild
		{
			// Nueva torre para construir
			torreAConstruir = torrePrefab;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la torre para construirla.</para>
		/// </summary>
		/// <returns></returns>
		public GameObject GetTorre()// Obtiene la torre para construirla
		{
			return torreAConstruir;
		}
		#endregion
	}
}
