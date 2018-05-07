//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerDemo.cs (07/05/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager de la escena Demo									\\
// Fecha Mod:		07/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
#endregion

namespace LvlP.SubSistemas
{
	/// <summary>
	/// <para>Manager de la escena Demo.</para>
	/// </summary>
	public class ManagerDemo : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Auxiliar para iniciar el sistema.</para>
		/// </summary>
		public bool auxInit = false;					// Auxiliar para iniciar el sistema
		/// <summary>
		/// <para>Vidas del usuario (Max. 3).</para>
		/// </summary>
		public int vidas = 3;							// Vidas del usuario (Max. 3)
		/// <summary>
		/// <para>Punto inicial del spawn.</para>
		/// </summary>
		public Transform puntoInicial;					// Punto inicial del spawn
		/// <summary>
		/// <para>Prefab del enemigo.</para>
		/// </summary>
		public Transform prefabEnemigo;					// Prefab del enemigo
		/// <summary>
		/// <para>Root de los objetos enemigos.</para>
		/// </summary>
		public Transform rootEnemigos;					// Root de los objetos enemigos
		/// <summary>
		/// <para>Texto de tiempo entre oleadas.</para>
		/// </summary>
		public Text txtOleada;							// Texto de tiempo entre oleadas
		/// <summary>
		/// <para>Imagen vida 1.</para>
		/// </summary>
		public GameObject vida1Imagen;					// Imagen vida 1
		/// <summary>
		/// <para>Imagen vida 2.</para>
		/// </summary>
		public GameObject vida2Imagen;					// Imagen vida 2
		/// <summary>
		/// <para>Imagen vida 3.</para>
		/// </summary>
		public GameObject vida3Imagen;                  // Imagen vida 3
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Tiempo entre oleadas.</para>
		/// </summary>
		private float tiempoOleadas = 5f;				// Tiempo entre oleadas
		/// <summary>
		/// <para>Cd de spawn.</para>
		/// </summary>
		private float cd = 2f;							// Cd de spawn
		/// <summary>
		/// <para>Index de la oleada.</para>
		/// </summary>
		private int indexOleada = 0;                    // Index de la oleada
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="ManagerDemo"/>.</para>
		/// </summary>
		private void Update()// Actualizador de ManagerDemo
		{
			// Comprueba si se puede iniciar
			if (auxInit == true)
			{
				// Actualiza las vidas del usuario
				ActualizarVidas();

				// Comprobar si tiene vidas
				ComprobarVidas();

				// Spawmear oleada
				if (cd <= 0f)
				{
					StartCoroutine(SpawnOleada());
					cd = tiempoOleadas;
				}

				cd -= Time.deltaTime;

				// Actualizar el texto
				txtOleada.text = "Oleada: " + indexOleada + " - " + Mathf.Round(cd).ToString();
			}
		}
		#endregion

		#region Corrutinas
		/// <summary>
		/// <para>Spawmea los enemigos.</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator SpawnOleada()// Spawmea los enemigos
		{
			indexOleada++;

			for (int i = 0; i < indexOleada; i++)
			{
				SpawnEnemigo();
				yield return new WaitForSeconds(0.5f);
			}
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Instancia un enemigo.</para>
		/// </summary>
		private void SpawnEnemigo()// Instancia un enemigo
		{
			Transform instancia = Instantiate(prefabEnemigo, puntoInicial.position, puntoInicial.rotation);
			instancia.transform.parent = rootEnemigos;
		}

		/// <summary>
		/// <para>Actualiza la interfaz de las vidas.</para>
		/// </summary>
		private void ActualizarVidas()// Actualiza la interfaz de las vidas
		{
			// Desactiva o activa dependiendo de las vidas
			switch (vidas)
			{
				case 0:
					vida1Imagen.SetActive(false);
					vida2Imagen.SetActive(false);
					vida3Imagen.SetActive(false);
					break;

				case 1:
					vida1Imagen.SetActive(true);
					vida2Imagen.SetActive(false);
					vida3Imagen.SetActive(false);
					break;

				case 2:
					vida1Imagen.SetActive(true);
					vida2Imagen.SetActive(true);
					vida3Imagen.SetActive(false);
					break;

				case 3:
					vida1Imagen.SetActive(true);
					vida2Imagen.SetActive(true);
					vida3Imagen.SetActive(true);
					break;

				default:
					vida1Imagen.SetActive(false);
					vida2Imagen.SetActive(false);
					vida3Imagen.SetActive(false);
					break;
			}
		}

		/// <summary>
		/// <para>Comprueba las vidas del usuario.</para>
		/// </summary>
		private void ComprobarVidas()// Comprueba las vidas del usuario
		{
			// Si no le quedan vidas, llevar al menu
			if (vidas <= 0)
			{
				SceneManager.LoadScene("Main");
			}
		}
		#endregion
	}
}
