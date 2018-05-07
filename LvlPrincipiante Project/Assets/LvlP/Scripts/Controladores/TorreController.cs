//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TorreController.cs (07/05/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controlador de la torre.									\\
// Fecha Mod:		07/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlP.Controladores
{
	/// <summary>
	/// <para>Controlador de la torre.</para>
	/// </summary>
	public class TorreController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Rango de ataque de la torre.</para>
		/// </summary>
		public float rango = 3f;							// Rango de ataque de la torre
		/// <summary>
		/// <para>Velocidad de ataque de la torre.</para>
		/// </summary>
		public float velAtaque = 1f;						// Velocidad de ataque de la torre
		/// <summary>
		/// <para>Velocidad de giro de la torre.</para>
		/// </summary>
		public float velGiro = 10f;							// Velocidad de giro de la torre
		/// <summary>
		/// <para>Prefab del efecto.</para>
		/// </summary>
		public GameObject efectoPrefab;                     // Prefab del efecto
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Objetivo de la torre.</para>
		/// </summary>
		private Transform objetivo;							// Objetivo de la torre
		/// <summary>
		/// <para>CD interno del ataque.</para>
		/// </summary>
		private float cdAtaque = 0f;						// CD interno del ataque
		/// <summary>
		/// <para>Desde donde se realiza la rotacion.</para>
		/// </summary>
		private Transform rotacionTransform;				// Desde donde se realiza la rotacion
		/// <summary>
		/// <para>Tag del enemigo.</para>
		/// </summary>
		private string tagEnemigo = "Enemigo";				// Tag del enemigo
		/// <summary>
		/// <para>Posicion donde se inicia el ataque.</para>
		/// </summary>
		private Transform pInicioAtaque;                    // Posicion donde se inicia el ataque
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="TorreController"/>.</para>
		/// </summary>
		private void Start()// Cargador de TorreController
		{
			// Asignar todas las variables necesarias
			rotacionTransform = this.transform.Find("MageUnit");
			pInicioAtaque = this.transform;

			// Actualizar el objetivo cada 0.5s
			InvokeRepeating("ActualizarObjetivo", 0f, 0.5f);
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="TorreController"/>.</para>
		/// </summary>
		private void Update()// Actualizador de TorreController
		{
			// Si no hay objetivo, volver
			if (objetivo == null) return;

			// Fijar direccion del objetivo
			Vector3 dir = objetivo.position - transform.position;
			Quaternion lookRotacion = Quaternion.LookRotation(dir);
			Vector3 rotacion = Quaternion.Lerp(rotacionTransform.rotation, lookRotacion, Time.deltaTime * velGiro).eulerAngles;
			rotacionTransform.rotation = Quaternion.Euler(0f, rotacion.y, 0f);

			// Controlar el cd de ataque
			if (cdAtaque <= 0f)
			{
				Atacar();
				cdAtaque = 1f / velAtaque;
			}

			cdAtaque -= Time.deltaTime;

		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Actualiza el objetivo por prioridad.</para>
		/// </summary>
		private void ActualizarObjetivo()// Actualiza el objetivo por prioridad
		{
			// Asignar las variables necesarias
			GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
			float distanciaMenor = Mathf.Infinity;
			GameObject enemigoCercano = null;

			// Recorrer todos los enemigos
			foreach (GameObject enemigo in enemigos)
			{
				// Buscar el enemigo mas cercano
				float distanciaEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
				if (distanciaEnemigo < distanciaMenor)
				{
					distanciaMenor = distanciaEnemigo;
					enemigoCercano = enemigo;
				}
			}

			// Asignar nuevo objetivo cercano
			if (enemigoCercano != null && distanciaMenor <= rango)
			{
				objetivo = enemigoCercano.transform;
			}
			else
			{
				objetivo = null;
			}
		}

		/// <summary>
		/// <para>Ataca al enemigo.</para>
		/// </summary>
		private void Atacar()// Ataca al enemigo
		{
			// Instanciar el efecto
			GameObject go = (GameObject)Instantiate(efectoPrefab, pInicioAtaque.position, pInicioAtaque.rotation);
			EfectoController efecto = go.GetComponent<EfectoController>();

			// Buscar objetivo si hay efecto
			if (efecto != null) efecto.BuscarObjetivo(objetivo);
		}
		#endregion
	}
}
