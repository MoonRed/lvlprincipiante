//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EnemigoController.cs (07/05/2018)											\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controller del enemigo.										\\
// Fecha Mod:		07/05/20188													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using LvlP.SubSistemas;
#endregion

namespace LvlP.Controladores
{
	/// <summary>
	/// <para>Controller del enemigo.</para>
	/// </summary>
	public class EnemigoController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Velocidad de movimiento del enemigo.</para>
		/// </summary>
		public float vel = 10f;							// Velocidad de movimiento del enemigo
		/// <summary>
		/// <para><see cref="ManagerDemo"/> de la escena.</para>
		/// </summary>
		public ManagerDemo goManager;                   // ManagerDemo de la escena
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Objetivo (Waypoint) del enemigo.</para>
		/// </summary>
		private Transform objetivo;						// Objetivo (Waypoint) del enemigo
		/// <summary>
		/// <para>Index del waypoint actual.</para>
		/// </summary>
		private int puntoIndex = 0;                     // >Index del waypoint actual
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="EnemigoController"/>.</para>
		/// </summary>
		private void Start()// Cargador de EnemigoController
		{
			// Asignar las variables necesarias
			objetivo = ManagerPath.puntos[0];
			goManager = GameObject.Find("Manager").GetComponent<ManagerDemo>();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="EnemigoController"/>.</para>
		/// </summary>
		private void Update()// Actualizador de EnemigoController
		{
			// Movemos al enemigo hacia el objetivo
			Vector3 dir = objetivo.position - transform.position;
			this.transform.Translate(dir.normalized * vel * Time.deltaTime, Space.World);

			// Comprobamos si se ha llegado al objetivo
			if (Vector3.Distance(this.transform.position, objetivo.position) <= 0.2f)
			{
				GetProximoWayPoint();
			}

			// Rotamos al enemigo hacia el objetivo
			Quaternion lookRotacion = Quaternion.LookRotation(dir);
			Vector3 rotacion = Quaternion.Lerp(this.transform.rotation, lookRotacion, Time.deltaTime * 15f).eulerAngles;
			this.transform.rotation = Quaternion.Euler(0f, rotacion.y, 0f);
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Obtener el proximo waypoint.</para>
		/// </summary>
		private void GetProximoWayPoint()// Obtener el proximo waypoint
		{
			// Si ya no hay mas waypoint, destruimos el objeto y quitamos una vida
			if (puntoIndex >= ManagerPath.puntos.Length - 1)
			{
				goManager.vidas = goManager.vidas - 1;
				Destroy(this.gameObject);
				return;
			}

			// Aumentamos el index del waypoint
			puntoIndex++;

			// Asignamos el nuevo objetivo
			objetivo = ManagerPath.puntos[puntoIndex];
		}
		#endregion
	}
}
