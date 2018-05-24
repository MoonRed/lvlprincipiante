//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SalirEstado.cs (23/03/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Estado de salir.											\\
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
	/// <para>Estado de salir.</para>
	/// </summary>
	public class SalirEstado : StateMachineBehaviour
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
			controller.Mainx2Animator.SetBool("IsActive", false);
			controller.Mainx3Animator.SetBool("IsActive", true);
		}
		#endregion
	}
}
