
Partial Public Class NativeConstants

    '''FBWF_MIN_CACHE_THRESHOLD -> 16
    Public Const FBWF_MIN_CACHE_THRESHOLD As Integer = 16
    
    '''FBWF_DEFAULT_CACHE_THRESHOLD -> 64
    Public Const FBWF_DEFAULT_CACHE_THRESHOLD As Integer = 64
    
    '''FBWF_MAX_CACHE_THRESHOLD -> 1024
    Public Const FBWF_MAX_CACHE_THRESHOLD As Integer = 1024
End Class

<System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet:=System.Runtime.InteropServices.CharSet.[Unicode])>  _
Public Structure FbwfCacheDetail
    
    '''ULONG->unsigned int
    Public cacheSize As UInteger
    
    '''ULONG->unsigned int
    Public openHandleCount As UInteger
    
    '''ULONG->unsigned int
    Public fileNameLength As UInteger
    
    '''WCHAR[1]
    <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)>  _
    Public fileName As String
End Structure

<System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)>  _
Public Structure FbwfMemoryUsage
    
    '''ULONG->unsigned int
    Public currCacheThreshold As UInteger
    
    '''ULONG->unsigned int
    Public nextCacheThreshold As UInteger
    
    '''ULONG->unsigned int
    Public dirStructure As UInteger
    
    '''ULONG->unsigned int
    Public fileData As UInteger
End Structure

Partial Public Class NativeMethods
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfEnableFilter")>  _
    Public Shared Function FbwfEnableFilter() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfDisableFilter")>  _
    Public Shared Function FbwfDisableFilter() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfProtectVolume")>  _
    Public Shared Function FbwfProtectVolume(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''removeExclusionList: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfUnprotectVolume")>  _
    Public Shared Function FbwfUnprotectVolume(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, ByVal removeExclusionList As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''threshold: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfSetCacheThreshold")>  _
    Public Shared Function FbwfSetCacheThreshold(ByVal threshold As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''currSession: ULONG->unsigned int
    '''volumeList: PVOID->void*
    '''size: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfGetVolumeList")>  _
    Public Shared Function FbwfGetVolumeList(ByVal currSession As UInteger, ByVal volumeList As System.IntPtr, ByVal size As System.IntPtr) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''currentSession: PULONG->ULONG*
    '''nextSession: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfIsFilterEnabled")>  _
    Public Shared Function FbwfIsFilterEnabled(<System.Runtime.InteropServices.OutAttribute()> ByRef currentSession As UInteger, <System.Runtime.InteropServices.OutAttribute()> ByRef nextSession As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''currentSession: PULONG->ULONG*
    '''nextSession: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfIsVolumeProtected")>  _
    Public Shared Function FbwfIsVolumeProtected(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, <System.Runtime.InteropServices.OutAttribute()> ByRef currentSession As UInteger, <System.Runtime.InteropServices.OutAttribute()> ByRef nextSession As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''usage: PFbwfMemoryUsage->_FbwfMemoryUsage*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfGetMemoryUsage")>  _
    Public Shared Function FbwfGetMemoryUsage(ByRef usage As FbwfMemoryUsage) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfFindClose")>  _
    Public Shared Function FbwfFindClose() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''cacheDetail: PFbwfCacheDetail->_FbwfCacheDetail*
    '''size: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfFindNext")>  _
    Public Shared Function FbwfFindNext(ByRef cacheDetail As FbwfCacheDetail, ByVal size As System.IntPtr) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''cacheDetail: PFbwfCacheDetail->_FbwfCacheDetail*
    '''size: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfFindFirst")>  _
    Public Shared Function FbwfFindFirst(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, ByRef cacheDetail As FbwfCacheDetail, ByVal size As System.IntPtr) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfEnableCompression")>  _
    Public Shared Function FbwfEnableCompression() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfDisableCompression")>  _
    Public Shared Function FbwfDisableCompression() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''currentSession: PULONG->ULONG*
    '''nextSession: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfIsCompressionEnabled")>  _
    Public Shared Function FbwfIsCompressionEnabled(<System.Runtime.InteropServices.OutAttribute()> ByRef currentSession As UInteger, <System.Runtime.InteropServices.OutAttribute()> ByRef nextSession As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfEnableCachePreAllocation")>  _
    Public Shared Function FbwfEnableCachePreAllocation() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfDisableCachePreAllocation")>  _
    Public Shared Function FbwfDisableCachePreAllocation() As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''currentSession: PULONG->ULONG*
    '''nextSession: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfIsCachePreAllocationEnabled")>  _
    Public Shared Function FbwfIsCachePreAllocationEnabled(<System.Runtime.InteropServices.OutAttribute()> ByRef currentSession As UInteger, <System.Runtime.InteropServices.OutAttribute()> ByRef nextSession As UInteger) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''path: PWCHAR->WCHAR*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfAddExclusion")>  _
    Public Shared Function FbwfAddExclusion(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, <System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal path As String) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''path: PWCHAR->WCHAR*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfRemoveExclusion")>  _
    Public Shared Function FbwfRemoveExclusion(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, <System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal path As String) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''currSession: ULONG->unsigned int
    '''exclusionList: PVOID->void*
    '''size: PULONG->ULONG*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfGetExclusionList")>  _
    Public Shared Function FbwfGetExclusionList(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, ByVal currSession As UInteger, ByVal exclusionList As System.IntPtr, ByVal size As System.IntPtr) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''path: PWCHAR->WCHAR*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfCommitFile")>  _
    Public Shared Function FbwfCommitFile(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, <System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal path As String) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''volume: PWCHAR->WCHAR*
    '''path: PWCHAR->WCHAR*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfRestoreFile")>  _
    Public Shared Function FbwfRestoreFile(<System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal volume As String, <System.Runtime.InteropServices.InAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal path As String) As UInteger
    End Function
    
    '''Return Type: ULONG->unsigned int
    '''threshold: ULONG->unsigned int
    '''event: HANDLE->void*
    <System.Runtime.InteropServices.DllImportAttribute("fbfwlib.dll", EntryPoint:="FbwfCacheThresholdNotification")>  _
    Public Shared Function FbwfCacheThresholdNotification(ByVal threshold As UInteger, ByVal [event] As System.IntPtr) As UInteger
    End Function
End Class
