//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoController.cs (29/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controlador del efecto.										\\
// Fecha Mod:		29/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlP.Controllers
{
	/// <summary>
	/// <para>Controlador del efecto.</para>
	/// </summary>
	public class EfectoController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Velocidad de movimiento.</para>
		/// </summary>
		public float vel = 70f;						// Velocidad de movimiento
		/// <summary>
		/// <para>FX al impactar.</para>
		/// </summary>
		public GameObject efectoImpacto;            // FX al impactar
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Objetivo del efecto.</para>
		/// </summary>
		private Transform objetivo;                 // Objetivo del efecto
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="EfectoController"/>.</para>
		/// </summary>
		private void Update()// Actualizador de EfectoController
		{
			// Comprobar si existe un objetivo, sino destruir objeto
			if (objetivo == null)
			{
				Destroy(gameObject);
				return;
			}

			// Obtener datos para el movimiento
			Vector3 dir = objetivo.position - transform.position;
			float distancia = vel * Time.deltaTime;

			// Si ya ha llegado al objetivo
			if (dir.magnitude <= distancia)
			{
				Hit();
				return;
			}

			// Mover al objetivo
			transform.Translate(dir.normalized * distancia, Space.World);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Buscar un objetivo.</para>
		/// </summary>
		/// <param name="target"></param>
		public void BuscarObjetivo(Transform target)// Buscar un objetivo
		{
			objetivo = target;
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Golpear al enemigo.</para>
		/// </summary>
		private void Hit()// Golpear al enemigo
		{
			// Instanciar efecto y destruirlo a los 2 segundos
			GameObject efecto = (GameObject)Instantiate(efectoImpacto, transform.position, transform.rotation);
			Destroy(efecto, 2f);

			// Destruir objeto
			Destroy(objetivo.gameObject);
			Destroy(gameObject);
		}
		#endregion
	}
}
