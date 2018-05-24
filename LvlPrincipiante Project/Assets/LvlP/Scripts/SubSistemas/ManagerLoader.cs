//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerLoader.cs (20/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager que controla el cambio de escena.					\\
// Fecha Mod:		20/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#endregion

namespace LvlP.SubSistemas
{
	/// <summary>
	/// <para>Manager que controla el cambio de escena.</para>
	/// </summary>
	public class ManagerLoader : MonoBehaviour 
	{
		#region Variables Protegidas
		/// <summary>
		/// <para>Objeto del loader.</para>
		/// </summary>
		protected GameObject loader;							// Objeto del loader
		/// <summary>
		/// <para>Canvas group del <see cref="loader"/>.</para>
		/// </summary>
		protected CanvasGroup canvasGroupLoader;                // Canvas group del loader
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializacion de <see cref="ManagerLoader"/>.</para>
		/// </summary>
		private void Awake()// Inicializacion de ManagerLoader
		{
			// Asignamos a loader el objeto con nombre de Loader y le agregamos un componente CanvasGroup
			loader = this.transform.Find("Loader").gameObject;
			loader.AddComponent<CanvasGroup>();

			// Asignamos a canvasGroup el componente que creamos en el loader
			canvasGroupLoader = loader.GetComponent<CanvasGroup>();
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Carga un nivel dado.</para>
		/// </summary>
		/// <param name="nombreNivel">Nombre del nivel.</param>
		public void CargarNivel(string nombreNivel)// Carga un nivel dado
		{
			if (Application.CanStreamedLevelBeLoaded(nombreNivel))
			{
				// Iniciar Procesamiento
				StartCoroutine(FadeIn(nombreNivel));
			}
			else
			{
				// Mostrar error por consola y no cargar nivel
				Debug.LogError("La escena " + nombreNivel + " no existe o no esta en BuildSettings.");
			}
		}
		#endregion

		#region Procesado
		/// <summary>
		/// <para>Proceso FadeIn.</para>
		/// </summary>
		/// <param name="nombreNivel">Nombre del nivel.</param>
		/// <returns></returns>
		IEnumerator FadeIn(string nombreNivel)// Proceso FadeIn
		{
			// Crear una variable temporal para la velocidad
			const float velFade = 3f;

			// Resetear el alpha del canvasGroup
			canvasGroupLoader.alpha = 0f;

			// Preparar la escena
			PrepararCambioNivel();

			while (canvasGroupLoader.alpha < 0.99f)
			{
				// Aqui tenemos el timescale a 0
				// entonces tenemos que usarl unscaledDeltaTime
				canvasGroupLoader.alpha += Time.unscaledDeltaTime * velFade;
				yield return null;
			}

			// En este momento, el alfa es aproximadamente 0,9, por lo que lo forzamos a 1
			canvasGroupLoader.alpha = 1f;

			// TimeScale a 1
			Time.timeScale = 1f;

			// Cargamos el mismo nivel
			CargarNivelConNombre(nombreNivel);
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Prepara los objetos para el cambio de nivel.</para>
		/// </summary>
		protected void PrepararCambioNivel()// Prepara los objetos para el cambio de nivel
		{
			// Activa el objeto loader, selecciona el padre 
			loader.SetActive(true);
			loader.transform.SetParent(this.transform.parent);

			// Mueve al loader al final de la lista para que sea el primero en renderizar
			loader.transform.SetAsLastSibling();
		}

		/// <summary>
		/// <para>Carga un nivel por su nombre.</para>
		/// </summary>
		/// <param name="nombreNivel">Nombre del nivel.</param>
		protected void CargarNivelConNombre(string nombreNivel)// Carga un nivel por su nombre
		{
			SceneManager.LoadScene(nombreNivel);
		}
		#endregion
	}
}
