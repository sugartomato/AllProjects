using System;
using System.Runtime.InteropServices;


namespace ZS.Common.Win32
{
    public partial class API
    {

        /// <summary>
        /// The sndPlaySound function plays a waveform sound specified either by a file name or by an entry in the registry or the WIN.INI file. This function offers a subset of the functionality of the PlaySound function; sndPlaySound is being maintained for backward compatibility.
        /// </summary>
        /// <param name="lpszSound">
        ///     [in]
        ///     A string that specifies the sound to play. This parameter can be either an entry in the registry or in WIN.INI that identifies a system sound, or it can be the name of a waveform-audio file. (If the function does not find the entry, the parameter is treated as a file name.) If this parameter is NULL, any currently playing sound is stopped.
        /// </param>
        /// <param name="fuSound">
        ///     [in]
        ///     声音播放方式。可多项并存。如SND_SYNC|SND_LOOP
        ///     Flags for playing the sound. The following values are defined.
        /// </param>
        /// <returns>
        /// Returns TRUE if successful or FALSE otherwise.
        /// </returns>
        /// <remarks>
        /// If the specified sound cannot be found, sndPlaySound plays the system default sound. If there is no system default entry in the registry or WIN.INI file, or if the default sound cannot be found, the function makes no sound and returns FALSE.
        /// The specified sound must fit in available physical memory and be playable by an installed waveform-audio device driver. If sndPlaySound does not find the sound in the current directory, the function searches for it using the standard directory-search order.
        /// </remarks>
        /// <see cref="https://msdn.microsoft.com/en-us/library/dd798676(v=vs.85).aspx"/>
        [DllImport("Winmm.dll")]
        public static extern Boolean sndPlaySound(String lpszSound, PlaySoundFlags fuSound);

        /// <summary>
        /// 声音播放方式。
        /// </summary>
        public enum PlaySoundFlags : UInt32
        {
            /// <summary>
            /// The sound is played asynchronously and PlaySound returns immediately after beginning the sound. To terminate an asynchronously played waveform sound, call PlaySound with pszSound set to NULL.
            /// </summary>
            SND_ASYNC = 0x0001,
            /// <summary>
            /// 循环播放声音，直到再次调用sndPlaySound并且将lpszSound参数设置为null。循环播放必须指定SND_ASYNC
            /// The sound plays repeatedly until sndPlaySound is called again with the lpszSound parameter set to NULL. You must also specify the SND_ASYNC flag to loop sounds.
            /// </summary>
            SND_LOOP = 0x0008,
            /// <summary>
            /// The parameter specified by lpszSound points to an image of a waveform sound in memory. The data passed must be trusted by the application.
            /// </summary>
            SND_MEMORY = 0x0004,
            /// <summary>
            /// 如果找不到声音文件，不播放默认声音。
            /// If the sound cannot be found, the function returns silently without playing the default sound.
            /// </summary>
            SND_NODEFAULT = 0x0002,
            /// <summary>
            /// If a sound is currently playing in the same process, the function immediately returns FALSE, without playing the requested sound.
            /// </summary>
            SND_NOSTOP = 0x0010,
            /// <summary>
            /// Note  Requires Windows Vista or later.
            /// If this flag is set, the function triggers a SoundSentry event when the sound is played. For more information, see PlaySound.
            /// </summary>
            SND_SENTRY,
            /// <summary>
            /// The sound is played synchronously and the function does not return until the sound ends.
            /// </summary>
            SND_SYNC = 0x0000,
            /// <summary>
            /// Note  Requires Windows Vista or later.
            /// If this flag is set, the sound is assigned to the audio session for system notification sounds. For more information, see PlaySound.
            /// </summary>
            SND_SYSTEM

        }

    }
}
