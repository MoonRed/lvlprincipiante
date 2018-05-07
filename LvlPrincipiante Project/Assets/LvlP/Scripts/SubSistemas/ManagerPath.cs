//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerPath.cs (07/05/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager de rutas											\\
// Fecha Mod:		07/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlP.SubSistemas
{
	/// <summary>
	/// <para>Manager de rutas.</para>
	/// </summary>
	public class ManagerPath : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Root inicial de WayPoints.</para>
		/// </summary>
		public GameObject rootWayPoints;					// Root inicial de WayPoints
		/// <summary>
		/// <para>Puntos de Waypoints.</para>
		/// </summary>
		public static Transform[] puntos;                   // Puntos de Waypoints
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="ManagerPath"/>.</para>
		/// </summary>
		private void Awake()// Inicializador de ManagerPath
		{
			// Buscamos el objeto padre de WayPoints
			rootWayPoints = this.transform.Find("WayPoints").gameObject;

			// Inicializamos el array y agregamos los waypoints
			puntos = new Transform[rootWayPoints.transform.childCount];
			for (int n = 0; n < puntos.Length; n++)
			{
				puntos[n] = rootWayPoints.transform.GetChild(n);
			}
		}
		#endregion
	}
}
