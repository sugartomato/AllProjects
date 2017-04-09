
Namespace Win32Manager


    Public Class Win32ManageAdapter


        Public Shared Function GetTargetAllInfo(ByVal target As String) As List(Of Dictionary(Of String, Object))

            Dim listR As List(Of Dictionary(Of String, Object)) = Nothing
            Using searcher As New Management.ManagementObjectSearcher()
                searcher.Query.QueryString = "SELECT * FROM " & target.ToString()
                Dim re As Management.ManagementObjectCollection = searcher.Get()
                If (Not re Is Nothing AndAlso re.Count > 0) Then
                    listR = New List(Of Dictionary(Of String, Object))()
                    For Each o As Management.ManagementObject In re
                        Dim dic As New Dictionary(Of String, Object)
                        For Each p In o.Properties
                            dic.Add(p.Name, p.Value)
                        Next
                        listR.Add(dic)
                    Next
                End If

            End Using

            Return listR
        End Function

    End Class


    Namespace Win32Classes

        Namespace ComputerSystemHardware
            Public Class CoolingDevice

            End Class

            ''' <summary>
            ''' 输入设备
            ''' </summary>
            Public Class InputDevice
                Public Const Win32_Keyboard = "Win32_Keyboard"
                Public Const Win32_PointingDevice = "Win32_PointingDevice	"
            End Class

            ''' <summary>
            ''' Classes in the Mass Storage subcategory represent storage devices such as hard disk drives, CD-ROM drives, and tape drives.
            ''' </summary>
            Public Class MassStorage
                '' <summary>Represents the settings for the autocheck operation of a disk.</summary>
                Public Const Win32_AutochkSetting = "Win32_AutochkSetting"
                '' <summary>Represents a CD-ROM drive on a computer system running Windows.</summary>
                Public Const Win32_CDROMDrive = "Win32_CDROMDrive"
                '' <summary>Represents a physical disk drive as seen by a computer running the Windows operating system.</summary>
                Public Const Win32_DiskDrive = "Win32_DiskDrive"
                '' <summary>Manages the capabilities of a floppy disk drive.</summary>
                Public Const Win32_FloppyDrive = "Win32_FloppyDrive"
                '' <summary>Represents any type of documentation or storage medium.</summary>
                Public Const Win32_PhysicalMedia = "Win32_PhysicalMedia"
                '' <summary>Represents a tape drive on a computer system running Windows.</summary>
                Public Const Win32_TapeDrive = "Win32_TapeDrive"
            End Class

        End Namespace


    End Namespace
    Public Class Win32Classess
        Public Class ComputerSystemHardware
        End Class

    End Class


    '    Public Enum Win32Classes

    '    Win32_1394Controller
    '    Win32_1394ControllerDevice
    '    Win32_Fan
    '    Win32_HeatPipe
    '    Win32_Refrigeration
    '    Win32_TemperatureProbe
    '    Win32_AssociatedProcessorMemory
    '    Win32_AutochkSetting
    '    Win32_BaseBoard
    '    Win32_Battery
    '    Win32_BIOS
    '    Win32_Bus
    '    Win32_CacheMemory
    '    Win32_CDROMDrive
    '    Win32_CIMLogicalDeviceCIMDataFile
    '    Win32_ComputerSystemProcessor
    '    Win32_CurrentProbe
    '    Win32_DesktopMonitor
    '    Win32_DeviceBus
    '    Win32_DeviceChangeEvent
    '    Win32_DeviceMemoryAddress
    '    Win32_DeviceSettings
    '    Win32_DiskDrive
    '    Win32_DiskDriveToDiskPartition
    '    Win32_DiskPartition
    '    Win32_DisplayControllerConfiguration
    '    Win32_DMAChannel
    '    Win32_DriverForDevice
    '    Win32_FloppyController
    '    Win32_FloppyDrive
    '    Win32_IDEController
    '    Win32_IDEControllerDevice
    '    Win32_InfraredDevice
    '    Win32_IRQResource
    '    Win32_Keyboard
    '    Win32_LogicalDisk
    '    Win32_LogicalDiskRootDirectory
    '    Win32_LogicalDiskToPartition
    '    Win32_LogicalProgramGroup
    '    Win32_LogicalProgramGroupDirectory
    '    Win32_LogicalProgramGroupItem
    '    Win32_LogicalProgramGroupItemDataFile
    '    Win32_MappedLogicalDisk
    '    Win32_MemoryArray
    '    Win32_MemoryArrayLocation
    '    Win32_MemoryDevice
    '    Win32_MemoryDeviceArray
    '    Win32_MemoryDeviceLocation
    '    Win32_MotherboardDevice
    '    Win32_NetworkAdapter
    '    Win32_NetworkAdapterConfiguration
    '    Win32_NetworkAdapterSetting
    '    Win32_NetworkClient
    '    Win32_NetworkConnection
    '    Win32_NetworkLoginProfile
    '    Win32_NetworkProtocol
    '    Win32_OnBoardDevice
    '    Win32_ParallelPort
    '    Win32_PCMCIAController
    '    Win32_PhysicalMemory
    '    Win32_PhysicalMemoryArray
    '    Win32_PhysicalMemoryLocation
    '    Win32_PnPAllocatedResource
    '    Win32_PnPDevice
    '    Win32_PnPDeviceProperty
    '    Win32_PnPDevicePropertyUint8
    '    Win32_PnPDevicePropertyUint16
    '    Win32_PnPDevicePropertyUint32
    '    Win32_PnPDevicePropertyUint64
    '    Win32_PnPDevicePropertySint8
    '    Win32_PnPDevicePropertySint16
    '    Win32_PnPDevicePropertySint32
    '    Win32_PnPDevicePropertySint64
    '    Win32_PnPDevicePropertyString
    '    Win32_PnPDevicePropertyBoolean
    '    Win32_PnPDevicePropertyReal32
    '    Win32_PnPDevicePropertyReal64
    '    Win32_PnPDevicePropertyDateTime
    '    Win32_PnPDevicePropertySecurityDescriptor
    '    Win32_PnPDevicePropertyBinary
    '    Win32_PnPDevicePropertyUint16Array
    '    Win32_PnPDevicePropertyUint32Array
    '    Win32_PnPDevicePropertyUint64Array
    '    Win32_PnPDevicePropertySint8Array
    '    Win32_PnPDevicePropertySint16Array
    '    Win32_PnPDevicePropertySint32Array
    '    Win32_PnPDevicePropertySint64Array
    '    Win32_PnPDevicePropertyStringArray
    '    Win32_PnPDevicePropertyBooleanArray
    '    Win32_PnPDevicePropertyReal32Array
    '    Win32_PnPDevicePropertyReal64Array
    '    Win32_PnPDevicePropertyDateTimeArray
    '    Win32_PnPDevicePropertySecurityDescriptorArray
    '    Win32_PnPEntity
    '    Win32_PointingDevice
    '    Win32_PortableBattery
    '    Win32_PortConnector
    '    Win32_PortResource
    '    Win32_POTSModem
    '    Win32_POTSModemToSerialPort
    '    Win32_Printer
    '    Win32_PrinterConfiguration
    '    Win32_PrinterController
    '    Win32_PrinterDriver
    '    Win32_PrinterDriverDll
    '    Win32_PrinterSetting
    '    Win32_PrinterShare
    '    Win32_PrintJob
    '    Win32_Processor
    '    Win32_SCSIController
    '    Win32_SCSIControllerDevice
    '    Win32_SerialPort
    '    Win32_SerialPortConfiguration
    '    Win32_SerialPortSetting
    '    Win32_SMBIOSMemory
    '    Win32_SoundDevice
    '    Win32_TapeDrive
    '    Win32_TCPIPPrinterPort
    '    Win32_USBController
    '    Win32_USBControllerDevice
    '    Win32_VideoController
    '    Win32_VideoSettings
    '    Win32_VoltageProbe


    'End Enum


End Namespace
