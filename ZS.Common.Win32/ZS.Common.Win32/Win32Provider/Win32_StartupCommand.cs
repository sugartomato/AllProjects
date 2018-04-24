using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// represents a command that runs automatically when a user logs onto the computer system.
    /// </summary>
    /// <remarks>
    /// Computer startup does not end after the operating system has been loaded. 
    /// Instead, the Windows operating system can be configured so that startup commands are run each time Windows starts. 
    /// Startup commands are stored in the registry or as part of the user profile and are used to automatically start specified scripts or applications each time Windows is loaded.
    /// In most cases, autostart programs are useful; they ensure that certain applications, such as antivirus tools, are automatically started and run each time Windows is loaded. However, autostart programs also can be responsible for problems such as:
    ///     Computers that take an exceptionally long time to start. This might be the result of a large number of applications that must be started each time Windows starts.
    ///     Applications that are represented in the Taskbar or in Task Manager, even though the user did not start them. Although these applications do not necessarily cause problems, they can result in help desk calls from users who are confused as to where these programs came from and why they are running.
    ///     Computers experiencing problems even when they seem idle. These problems are often traced to startup commands that are running when no one is aware that they are running.
    /// 
    /// Identifying the applications and scripts that automatically run at startup is an important but difficult administrative task, because startup commands can be stored in many different locations:
    ///     HKLM\Software\Microsoft\Windows\CurrentVersion\Run
    ///     HKLM\Software\Microsoft\Windows\CurrentVersion\RunOnce
    ///     HKCU\Software\Microsoft\Windows\CurrentVersion\Run
    ///     HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce
    ///     HKU\ProgID\Software\Microsoft\Windows\CurrentVersion\Run
    ///     systemdrive\Documents and Settings\All Users\Start Menu\Programs\Startup
    ///     systemdrive\Documents and Settings\username\Start Menu\Programs\Startup
    ///     
    /// You can use the WMI Win32_StartupCommand class to enumerate autostart programs regardless of where the information is stored.
    /// The calling process that uses this class must have the SE_RESTORE_NAME privilege on the computer in which the registry resides. For example, if you enumerate this class on the local computer, the account under which your application runs must have this privilege. For more information, see Executing Privileged Operations.
    /// You can change the registry values where Win32_StartupCommand obtains data by calling the WMI System Registry Provider methods in script or in C++. For more information, see Modifying the System Registry.
    /// </remarks>
    /// <link>
    /// https://msdn.microsoft.com/en-us/library/aa394464(v=vs.85).aspx
    /// </link>
    public class Win32_StartupCommand:Win32ProviderBase
    {

        /// <summary>
        /// Short textual description of the current object.
        /// </summary>
        public String Caption { get; set; }
        /// <summary>
        /// Command run by the startup command.
        /// WMI obtains this data from the registry key
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
        /// </summary>
        public String Command { get; set; }
        /// <summary>
        /// Textual description of the current object.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Identifier by which the current object is known.
        /// </summary>
        public String SettingID { get; set; }
        /// <summary>
        /// Path where the startup command resides on the disk file system.
        /// </summary>
        public String Location { get; set; }
        /// <summary>
        /// File name of the startup command.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// User name for whom this startup command will run.
        /// </summary>
        public String User { get; set; }
        /// <summary>
        /// The UserSID property indicates the SID of the user for whom this startup command will run. That User property may be empty but UserSID still has a value if the user name can't be resolved (like in the case of a deleted user). The property is helpful to distinguish between commands associated w/ two different users with unresolved names. It may be NULL when the command is associated with items not actually identifying a user like All Users.
        /// </summary>
        public String UserSID { get; set; }

    }
}
