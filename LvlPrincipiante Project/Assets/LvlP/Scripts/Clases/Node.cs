//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Node.cs (29/03/2018)															\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Clase base del nodo.										\\
// Fecha Mod:		29/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using LvlP.SubSistemas;
#endregion

namespace LvlP.Clases
{
	/// <summary>
	/// <para>Clase base del nodo.</para>
	/// </summary>
	public class Node : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Color cuando se ha presionado.</para>
		/// </summary>
		public Color colorPresionado;							// Color cuando se ha presionado
		/// <summary>
		/// <para>Pequeña desviacion que se le quiera dar a la torre.</para>
		/// </summary>
		public Vector3 offSet;									// Pequeña desviacion que se le quiera dar a la torre
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Root donde estan todas las torres.</para>
		/// </summary>
		private Transform rootTorres;							// Root donde estan todas las torres
		/// <summary>
		/// <para>Torre instanciada (Solo la ultima).</para>
		/// </summary>
		private GameObject torre;								// Torre instanciada (Solo la ultima)
		/// <summary>
		/// <para>Componente renderer del nodo.</para>
		/// </summary>
		private Renderer rend;									// Componente renderer del nodo
		/// <summary>
		/// <para>Color inicial del nodo.</para>
		/// </summary>
		private Color colorInicial;								// Color inicial del nodo
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="Node"/>.</para>
		/// </summary>
		private void Start()// Cargador de Node
		{
			// Asignar todas las variables necesarias
			rend = GetComponent<Renderer>();
			colorInicial = rend.material.color;
			rootTorres = GameObject.Find("Torres").transform;
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el mouse es presionado.</para>
		/// </summary>
		private void OnMouseDown()// Cuando el mouse es presionado.
		{
			// Comprobamos que el nodo no tenga una torre ya
			if (torre != null)
			{
				return;
			}

			// Obtenemos la torre para instanciarla y posteriormente colocarla hija del root de torres
			GameObject torreParaInstanciar = ManagerBuild.instance.GetTorre();
			torre = (GameObject)Instantiate(torreParaInstanciar, transform.position + offSet, transform.rotation);
			torre.transform.parent = rootTorres;
		}

		/// <summary>
		/// <para>Cuando el mouse es clicado.</para>
		/// </summary>
		private void OnMouseEnter()// Cuando el mouse es clicado
		{
			// Cambiar el color
			rend.material.color = colorPresionado;
		}

		/// <summary>
		/// <para>Cuando el mouse deja de ser clicado.</para>
		/// </summary>
		private void OnMouseExit()// Cuando el mouse deja de ser clicado
		{
			// Cambiar el color
			rend.material.color = colorInicial;
		}
		#endregion
	}
}
