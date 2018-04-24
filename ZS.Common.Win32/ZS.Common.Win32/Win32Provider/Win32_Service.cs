using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    ///  represents a service on a computer system running Windows.
    /// </summary>
    public class Win32_Service : Win32ProviderBase
    {
        /// <summary>
        /// 获取服务是否可以被暂停
        /// Indicates whether the service can be paused.
        /// </summary>
        public Boolean AcceptPause { get; set; }
        /// <summary>
        /// 获取服务是否可以被停止
        /// Indicates whether the service can be stopped.
        /// </summary>
        public Boolean AcceptStop { get; set;}
        /// <summary>
        /// Short description of the service —a one-line string.
        /// </summary>
        public String Caption { get; set;}
        /// <summary>
        /// Value that the service increments periodically to report its progress during a long start, stop, pause, or continue operation. For example, the service increments this value as it completes each step of its initialization when it is starting up. The user interface program that invokes the operation on the service uses this value to track the progress of the service during a lengthy operation. This value is not valid and should be zero when the service does not have a start, stop, pause, or continue operation pending.
        /// </summary>
        public UInt32 CheckPoint { get; set;}
        /// <summary>
        /// Name of the first concrete class to appear in the inheritance chain used in the creation of an instance. When used with the other key properties of the class, this property allows all instances of this class and its subclasses to be uniquely identified.
        /// </summary>
        public String CreationClassName { get; set; }
        /// <summary>
        /// If True, the service is started after other auto-start services are started plus a short delay.
        /// </summary>
        /// <remarks>
        /// Windows Server 2012 R2, Windows 8.1, Windows Server 2012, Windows 8, Windows Server 2008 R2, Windows 7, Windows Server 2008, and Windows Vista:  This property is not supported before Windows Server 2016 Technical Preview and Windows 10.
        /// </remarks>
        public Boolean DelayedAutoStart { get; set; }
        /// <summary>
        /// Description of the object.
        /// </summary>
        public String Description { get; set;}
        /// <summary>
        /// Indicates whether the service can create or communicate with windows on the desktop, and thus interact in some way with a user. Interactive services must run under the Local System account. Most services are not interactive; that is, they do not communicate with the user in any way.
        /// </summary>
        public Boolean DesktopInteract { get; set; }
        /// <summary>
        /// Name of the service as viewed in the Services snap-in. 
        /// This string has a maximum length of 256 characters. Note that the display name and the service name (which is stored in the registry) are not always the same. For example, the DHCP Client service has the service name Dhcp but the display name DHCP Client. The name is case-preserved in the Service Control Manager. However, DisplayName comparisons are always case-insensitive.
        /// Constraint: Accepts the same value as the Name property.
        /// Example: "Atdisk"
        /// </summary>
        public String DisplayName { get; set;}
        /// <summary>
        /// Severity of the error if this service fails to start during startup. The value indicates the action taken by the startup program if failure occurs. All errors are logged by the computer system.
        /// </summary>
        public String ErrorControl { get; set;}
        /// <summary>
        /// Windows error code that defines errors encountered in starting or stopping the service. This property is set to ERROR_SERVICE_SPECIFIC_ERROR (1066) when the error is unique to the service represented by this class, and information about the error is available in the ServiceSpecificExitCode property. The service sets this value to NO_ERROR when running, and again upon normal termination.
        /// </summary>
        public UInt32 ExitCode { get; set;}
        /// <summary>
        /// Date object is installed. This property does not require a value to indicate that the object is installed.
        /// </summary>
        public DateTime InstallDate { get; set; }
        /// <summary>
        /// Unique identifier of the service that provides an indication of the functionality that is managed.This functionality is described in the Description property of the object.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Fully qualified path to the service binary file that implements the service.
        /// Example: "\SystemRoot\System32\drivers\afd.sys"
        /// </summary>
        public String PathName { get; set; }
        /// <summary>
        /// Process identifier of the service.
        /// </summary>
        public UInt32 ProcessId { get; set; }
        /// <summary>
        /// Service-specific error code for errors that occur while the service is either starting or stopping. The exit codes are defined by the service represented by this class. This value is only set when the ExitCode property value is ERROR_SERVICE_SPECIFIC_ERROR (1066).
        /// </summary>
        public UInt32 ServiceSpecificExitCode { get; set; }
        /// <summary>
        /// Type of service provided to calling processes.
        /// </summary>
        public String ServiceType { get; set; }
        /// <summary>
        /// Indicates whether or not the service is started.
        /// </summary>
        public Boolean Started { get; set; }
        /// <summary>
        /// Start mode of the Windows base service.
        /// </summary>
        public String StartMode { get; set; }
        /// <summary>
        /// Account name under which a service runs. Depending on the service type, the account name may be in the form of "DomainName\Username" or UPN format ("Username@DomainName"). The service process is logged by using one of these two forms when it runs. If the account belongs to the built-in domain, then ".\Username" can be specified. For kernel or system-level drivers, StartName contains the driver object name (that is, "\FileSystem\Rdr" or "\Driver\Xns") which the I/O system uses to load the device driver. Additionally, if NULL is specified, the driver runs with a default object name created by the I/O system based on the service name.
        /// </summary>
        public String StartName { get; set; }
        /// <summary>
        /// Current state of the base service.
        /// </summary>
        public String State { get; set; }
        /// <summary>
        /// Current status of the object. 
        /// Various operational and nonoperational statuses can be defined. 
        /// Operational statuses include: "OK", "Degraded", and "Pred Fail" (an element, such as a SMART-enabled hard disk drive, may be functioning properly but predicting a failure in the near future). Nonoperational statuses include: "Error", "Starting", "Stopping", and "Service". The latter, "Service", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is online, yet the managed element is neither "OK" nor in one of the other states.
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// Type name of the system that hosts this service.
        /// </summary>
        public String SystemCreationClassName { get; set; }
        /// <summary>
        /// Name of the system that hosts this service.
        /// </summary>
        public String SystemName { get; set; }
        /// <summary>
        /// Unique tag value for this service in the group. A value of 0 (zero) indicates that the service does not have a tag. A tag can be used to order service startup within a load order group by specifying a tag order vector in the registry located at:
        /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\    GroupOrderList
        /// Tags are only evaluated for Kernel Driver and File System Driver start type services that have Boot or System start modes.
        /// </summary>
        public UInt32 TagId { get; set; }
        /// <summary>
        /// Estimated time required, in milliseconds, for a pending start, stop, pause, or continue operation. After the specified time has elapsed, the service makes its next call to the SetServiceStatus method with either an incremented CheckPoint value or a change in CurrentState. If the amount of time specified by WaitHint passes, and CheckPoint has not been incremented, or CurrentState has not changed, the service control manager or service control program assumes that an error has occurred.
        /// </summary>
        public UInt32 WaitHint { get; set; }


        /// <summary>
        /// 服务类型定义
        /// </summary>
        public class ServiceTypeDef
        {
            /// <summary></summary>
            public const String KernelDriver = "Kernel Driver";
            /// <summary></summary>
            public const String FileSystemDriver = "File System Driver";
            /// <summary></summary>
            public const String Adapter = "Adapter";
            /// <summary></summary>
            public const String RecognizerDriver = "Recognizer Driver";
            /// <summary></summary>
            public const String OwnProcess = "Own Process";
            /// <summary></summary>
            public const String ShareProcess = "Share Process";
            /// <summary></summary>
            public const String InteractiveProcess = "Interactive Process";
        }

        /// <summary>
        /// 服务启动模式定义
        /// </summary>
        public class StartModeDef
        {
            /// <summary>Device driver started by the operating system loader (valid only for driver services).</summary>
            public const String Boot = "Boot";
            /// <summary>Device driver started by the operating system initialization process. This value is valid only for driver services.</summary>
            public const String System = "System";
            /// <summary>Service to be started automatically by the service control manager during system startup. Auto services are started even if a user does not log on.</summary>
            public const String Auto = "Auto";
            /// <summary>ervice to be started by the Service Control Manager when a process calls the StartService method. These services do not start unless a user logs on and starts them.</summary>
            public const String Manual = "Manual";
            /// <summary>Service that cannot be started until its StartMode is changed to either Auto or Manual.</summary>
            public const String Disabled = "Disabled";
        }

        /// <summary>
        /// 服务state定义
        /// </summary>
        public class StateDef
        {
            /// <summary>已停止</summary>
            public const String Stopped = "Stopped";
            /// <summary></summary>
            public const String StartPending = "Start Pending";
            /// <summary></summary>
            public const String StopPending = "Stop Pending";
            /// <summary></summary>
            public const String Running = "Running";
            /// <summary></summary>
            public const String Continue_Pending = "Continue Pending";
            /// <summary></summary>
            public const String PausePending = "Pause Pending";
            /// <summary></summary>
            public const String Paused = "Paused";
            /// <summary></summary>
            public const String Unknown = "Unknown";
        }

        /// <summary>
        /// 服务status定义
        /// </summary>
        public class StatusDef
        {
            /// <summary></summary>
            public const String OK = "OK";
            /// <summary></summary>
            public const String Error = "Error";
            /// <summary></summary>
            public const String Degraded = "Degraded";
            /// <summary></summary>
            public const String Unknown = "Unknown";
            /// <summary></summary>
            public const String PredFail = "Pred Fail";
            /// <summary></summary>
            public const String Starting = "Starting";
            /// <summary></summary>
            public const String Stopping = "Stopping";
            /// <summary></summary>
            public const String Service = "Service";
            /// <summary></summary>
            public const String Stressed = "Stressed";
            /// <summary></summary>
            public const String NonRecover = "NonRecover";
            /// <summary></summary>
            public const String NoContact = "No Contact";
            /// <summary></summary>
            public const String LostComm = "Lost Comm";
        }
    }
}
