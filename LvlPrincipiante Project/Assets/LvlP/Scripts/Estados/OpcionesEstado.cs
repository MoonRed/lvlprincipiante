//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// OpcionesEstado.cs (23/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Estado de opciones.											\\
// Fecha Mod:		23/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using LvlP.Controllers;
#endregion

namespace LvlP.Estados
{
	/// <summary>
	/// <para>Estado de opciones.</para>
	/// </summary>
	public class OpcionesEstado : StateMachineBehaviour
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado.</para>
		/// </summary>
		/// <param name="animator"></param>
		/// <param name="stateInfo"></param>
		/// <param name="layerIndex"></param>
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			var controller = animator.GetComponent<MenuController>();
			controller.Mainx1Animator.SetBool("IsActive", false);
			controller.Mainx2Animator.SetBool("IsActive", true);
			controller.Mainx3Animator.SetBool("IsActive", false);
		}
		#endregion
	}
}
