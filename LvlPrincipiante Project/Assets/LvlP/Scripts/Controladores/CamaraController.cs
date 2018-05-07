//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CamaraController.cs (07/05/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Controller de la camara.									\\
// Fecha Mod:		07/05/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace LvlP.Controladores
{
	/// <summary>
	/// <para>Controller de la camara.</para>
	/// </summary>
	public class CamaraController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Scrollbar de la escena.</para>
		/// </summary>
		public Scrollbar scroll;                                    // Scrollbar de la escena
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Mueve la Camara.</para>
		/// </summary>
		public void MoverCamara()// Mueve la Camara
		{
			// Recoger el valor actual del scrollbar
			float valorScroll = scroll.value;

			// Modificar la posicion local de la camara con el valor obtenido (aumentado)
			this.transform.localPosition = new Vector3(valorScroll * 5, 4.46f, -6.65f);
		}
		#endregion
	}
}
