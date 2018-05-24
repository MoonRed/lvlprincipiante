//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerAudio.cs (27/03/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Manager del sistema de sonido.								\\
// Fecha Mod:		27/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.Audio;
#endregion

namespace LvlP.SubSistemas
{
	/// <summary>
	/// <para>Manager del sistema de sonido.</para>
	/// </summary>
	public class ManagerAudio : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Audio Normal.</para>
		/// </summary>
		public AudioMixerSnapshot audioNormal;					// Audio Normal
		/// <summary>
		/// <para>Audio muteado.</para>
		/// </summary>
		public AudioMixerSnapshot audioMute;                    // Audio muteado
		#endregion

		#region Variables Privadas
		private bool auxMute = false;
		#endregion

		#region Propiedades
		public bool Mute
		{
			set
			{
				auxMute = value;
				if (auxMute == true)
				{
					audioNormal.TransitionTo(0.01f);
				}
				else
				{
					audioMute.TransitionTo(0.01f);
				}
			}
		}
		#endregion
	}
}
