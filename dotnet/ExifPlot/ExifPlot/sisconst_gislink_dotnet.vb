Public Module GisLink

' Global Constants

' Horizontal Text alignment.
Public Const SIS_LEFT As Short = 0
Public Const SIS_RIGHT As Short = 2
Public Const SIS_CENTRE As Short = 6

' Vertical Text alignment.
Public Const SIS_TOP As Short = 0
Public Const SIS_BOTTOM As Short = 8
Public Const SIS_BASELINE As Short = 24
Public Const SIS_MIDDLE As Short = 72

' Horizontal and Vertical Text alignment.
Public Const SIS_TOP_LEFT As Short = 0
Public Const SIS_TOP_RIGHT As Short = 2
Public Const SIS_TOP_CENTRE As Short = 6
Public Const SIS_BOTTOM_LEFT As Short = 8
Public Const SIS_BOTTOM_RIGHT As Short = 10
Public Const SIS_BOTTOM_CENTRE As Short = 14
Public Const SIS_BASE_LEFT As Short = 24
Public Const SIS_BASE_RIGHT As Short = 26
Public Const SIS_BASE_CENTRE As Short = 30
Public Const SIS_MIDDLE_LEFT As Short = 72
Public Const SIS_MIDDLE_RIGHT As Short = 74
Public Const SIS_MIDDLE_CENTRE As Short = 78

' Menu commands.
Public Const SIS_COM_ALL As Short = 0
Public Const SIS_COM_ADD As Short = 1
Public Const SIS_COM_REMOVE As Short = 2
Public Const SIS_COM_NONE As Short = 3

' Overlay status.
Public Const SIS_INVISIBLE As Short = 0
Public Const SIS_VISIBLE As Short = 1
Public Const SIS_HITTABLE As Short = 2
Public Const SIS_EDITABLE As Short = 3

' Redraw.
Public Const SIS_CURRENTWINDOW As Short = 0
Public Const SIS_CURRENTSWD As Short = 1
Public Const SIS_ALLWINDOWS As Short = 2
Public Const SIS_QUICK_REDRAW As Short = 32

' Attribute filters.
Public Const SIS_FILTERRESET As Short = 0
Public Const SIS_FILTERADD As Short = 1
Public Const SIS_FILTERREMOVE As Short = 2

' Argument entry.
Public Const SIS_ARG_ESCAPE As Short = 0
Public Const SIS_ARG_ENTER As Short = 1
Public Const SIS_ARG_BACKSPACE As Short = 2
Public Const SIS_ARG_POSITION As Short = 3

' Save & Exit.
Public Const SIS_NOSAVE As Short = 0
Public Const SIS_SAVE As Short = 1
Public Const SIS_PROMPTSAVE As Short = 2

' Save Bitmap formats.
Public Const SIS_SAVEBMP_BMP As Short = 0
Public Const SIS_SAVEBMP_JPG As Short = 1
Public Const SIS_SAVEBMP_DITHERBMP As Short = 2
Public Const SIS_SAVEBMP_PNG As Short = 3
Public Const SIS_SAVEBMP_TIFF As Short = 4
Public Const SIS_SAVEBMP_TIFF_PACKBITS As Short = 5
Public Const SIS_SAVEBMP_TIFF_GP4 As Short = 6
Public Const SIS_SAVEBMP_TIFF_LZW As Short = 7
Public Const SIS_SAVEBMP_GIF As Short = 8

' Class filters.
Public Const SIS_CLASSEXCLUDE As Short = 0
Public Const SIS_CLASSINCLUDE As Short = 1
Public Const SIS_OPENBRANCH As Short = 2

' Units.
Public Const SIS_LENGTHDIM As Short = 1
Public Const SIS_AREADIM As Short = 2
Public Const SIS_VOLUMEDIM As Short = 3

' Boolean operations.
Public Const SIS_BOOLEAN_AND As Short = 1
Public Const SIS_BOOLEAN_OR As Short = 2
Public Const SIS_BOOLEAN_XOR As Short = 3
Public Const SIS_BOOLEAN_DIFF As Short = 4
Public Const SIS_REVERSE As Short = 64
Public Const SIS_FORCE_POSITIVE As Short = 65

' Deprecated scanning tests.
Public Const SIS_TEST_NOCHANGE As Short = -1
Public Const SIS_TEST_DISABLE As Short = 0
Public Const SIS_TEST_INSIDE As Short = 1
Public Const SIS_TEST_CROSSING As Short = 2
Public Const SIS_TEST_CONTAINS As Short = 3

' Geometry tests.
Public Const SIS_GT_EQUAL As Short = 0
Public Const SIS_GT_DISJOINT As Short = 1
Public Const SIS_GT_INTERSECT As Short = 2
Public Const SIS_GT_TOUCH As Short = 3
Public Const SIS_GT_CROSS As Short = 4
Public Const SIS_GT_CROSSBY As Short = 5
Public Const SIS_GT_WITHIN As Short = 6
Public Const SIS_GT_CONTAIN As Short = 7
Public Const SIS_GT_OVERLAP As Short = 8

' Geometry testing modes.
Public Const SIS_GM_ORIGIN As Short = 0
Public Const SIS_GM_EXTENTS As Short = 1
Public Const SIS_GM_GEOMETRY As Short = 2

' Property object types.
Public Const SIS_OT_CURITEM As Short = 0
Public Const SIS_OT_DEFITEM As Short = 1
Public Const SIS_OT_SYSTEM As Short = 2
Public Const SIS_OT_WINDOW As Short = 4
Public Const SIS_OT_OVERLAY As Short = 5
Public Const SIS_OT_DATASET As Short = 6
Public Const SIS_OT_OPTION As Short = 7
Public Const SIS_OT_NOL As Short = 8
Public Const SIS_OT_PRINTER As Short = 9
Public Const SIS_OT_FTABLE As Short = 10
Public Const SIS_OT_SCHEMA As Short = 11
Public Const SIS_OT_SCHEMACOLUMN As Short = 12
Public Const SIS_OT_THEME As Short = 13
Public Const SIS_OT_THEMECOMPONENT As Short = 14
Public Const SIS_OT_GPS As Short = 15

' Cadcorp SIS Control Licence Levels.
Public Const SIS_LEVEL_UNLICENSED As Short = 0
Public Const SIS_LEVEL_MANAGER As Short = 1
Public Const SIS_LEVEL_MODELLER As Short = 2
Public Const SIS_LEVEL_VIEWER As Short = 3

' General constants.
Public Const SIS_OVERRIDE As Short = 1
Public Const SIS_WRITEABLE As Short = 0
Public Const SIS_READONLY As Short = -1

' Rubber sheet methods.
Public Const SIS_RUBBER_BEST_FIT As Short = 0
Public Const SIS_RUBBER_LINEAR_PATCH As Short = 1
Public Const SIS_RUBBER_INVERSE_SQUARE As Short = 2

' 3D manipulation modes.
Public Const SIS_3DMODE_CRUISE As Short = 0
Public Const SIS_3DMODE_EYE As Short = 1
Public Const SIS_3DMODE_MODEL As Short = 2
Public Const SIS_3DMODE_PAN As Short = 3
Public Const SIS_3DMODE_ZOOM As Short = 4

' Line segment shapes.
Public Const SIS_LINE_STRAIGHT As Short = 0
Public Const SIS_LINE_BULGE As Short = 1
Public Const SIS_LINE_BEZIER As Short = 2

' Feature filters.
Public Const SIS_FEATUREEXCLUDE As Short = 0
Public Const SIS_FEATUREINCLUDE As Short = 1
Public Const SIS_FEATURECASCADE As Short = 2

' Blob formats.
Public Const SIS_BLOB_SIS As Short = 0
Public Const SIS_BLOB_OGIS_WKB As Short = 1
Public Const SIS_BLOB_OGIS_WKT As Short = 2
Public Const SIS_BLOB_OGIS_GML As Short = 3

' Creating Area items.
Public Const SIS_AREA_ONE_TO_ONE As Short = 0
Public Const SIS_AREA_MANY_TO_ONE As Short = 1
Public Const SIS_AREA_DISJOINT As Short = 2

' Rubber-banding.
Public Const SIS_RUBBERBAND_NONE As Short = 0
Public Const SIS_RUBBERBAND_LINE As Short = 1
Public Const SIS_RUBBERBAND_CIRCLE As Short = 2
Public Const SIS_RUBBERBAND_RECT As Short = 3
Public Const SIS_RUBBERBAND_ITEMS As Short = 4
Public Const SIS_RUBBERBAND_FIX_CIRCLE As Short = 5
Public Const SIS_RUBBERBAND_FIX_RECT As Short = 6

' Scatter Grid creation modes.
Public Const SIS_SCATTER_GRID_INTERPOLATE As Short = 0
Public Const SIS_SCATTER_GRID_CLOSEST As Short = 1
Public Const SIS_SCATTER_GRID_SUM As Short = 2
Public Const SIS_SCATTER_GRID_COUNT As Short = 3

' Cleaning Line items.
Public Const SIS_CLEAN_LINE_NONE As Short = 0
Public Const SIS_CLEAN_LINE_REMOVE_0 As Short = 1
Public Const SIS_CLEAN_LINE_REMOVE_180 As Short = 2
Public Const SIS_CLEAN_LINE_REMOVE_SELF As Short = 4

' Cleaning Topological items.
Public Const SIS_CLEAN_TOPO_NONE As Short = 0
Public Const SIS_CLEAN_TOPO_REMOVE_DANGLING As Short = 1
Public Const SIS_CLEAN_TOPO_FIX_UNDER_OVER As Short = 2
Public Const SIS_CLEAN_TOPO_REMOVE_SEEDS As Short = 4

' Formula calculations.
Public Const SIS_CALCULATE_COUNT As Short = 0
Public Const SIS_CALCULATE_SUM As Short = 1
Public Const SIS_CALCULATE_AVERAGE As Short = 2

' Axes types.
Public Const SIS_AXES_CARTESIAN As Short = 0
Public Const SIS_AXES_SPHERICAL As Short = 1

' Co-ordinate units.

' Type:
Public Const SIS_UNIT_ANGLE As Short = 0
Public Const SIS_UNIT_LINEAR As Short = 1
Public Const SIS_UNIT_AREA As Short = 2
Public Const SIS_UNIT_VOLUME As Short = 3

' Angle:
Public Const SIS_UNITA_DEGREES As Short = 0
Public Const SIS_UNITA_RADIANS As Short = 1
Public Const SIS_UNITA_DMS As Short = 2
Public Const SIS_UNITA_GRADIANS As Short = 3

' Linear:
Public Const SIS_UNIT1_M As Short = 0
Public Const SIS_UNIT1_MM As Short = 1
Public Const SIS_UNIT1_CM As Short = 2
Public Const SIS_UNIT1_KM As Short = 3
Public Const SIS_UNIT1_FEET As Short = 4
Public Const SIS_UNIT1_INCHES As Short = 5
Public Const SIS_UNIT1_IMPERIAL As Short = 6
Public Const SIS_UNIT1_YARD As Short = 7
Public Const SIS_UNIT1_FATHOM As Short = 8
Public Const SIS_UNIT1_MILE As Short = 9
Public Const SIS_UNIT1_NAUTMILE As Short = 10

' Area:
Public Const SIS_UNIT2_M As Short = 0
Public Const SIS_UNIT2_MM As Short = 1
Public Const SIS_UNIT2_CM As Short = 2
Public Const SIS_UNIT2_KM As Short = 3
Public Const SIS_UNIT2_FEET As Short = 4
Public Const SIS_UNIT2_INCHES As Short = 5
Public Const SIS_UNIT2_YARDS As Short = 6
Public Const SIS_UNIT2_ACRE As Short = 7
Public Const SIS_UNIT2_HECTARE As Short = 8
Public Const SIS_UNIT2_TUBO As Short = 9
Public Const SIS_UNIT2_MILE As Short = 10
Public Const SIS_UNIT2_NAUTMILE As Short = 11

' Volume:
Public Const SIS_UNIT3_M As Short = 0
Public Const SIS_UNIT3_MM As Short = 1
Public Const SIS_UNIT3_CM As Short = 2
Public Const SIS_UNIT3_LITRE As Short = 3
Public Const SIS_UNIT3_FEET As Short = 4
Public Const SIS_UNIT3_INCHES As Short = 5
Public Const SIS_UNIT3_YARDS As Short = 6
Public Const SIS_UNIT3_GALLON_IMP As Short = 7
Public Const SIS_UNIT3_GALLON_US As Short = 8

' Theme scaling functions:
Public Const SIS_FUNCTION_CONSTANT As Short = 0
Public Const SIS_FUNCTION_SQUAREROOT As Short = 1
Public Const SIS_FUNCTION_LINEAR As Short = 2
Public Const SIS_FUNCTION_LOG10 As Short = 3

' Printer colour capabilities:
Public Const SIS_PRINTCAPS_QUERY As Short = 0
Public Const SIS_PRINTCAPS_MONO As Short = 1
Public Const SIS_PRINTCAPS_COLOUR As Short = 2

' Theme annotation alignment:
Public Const SIS_ALIGN_BOTTOM_LEFT As Short = 0
Public Const SIS_ALIGN_BOTTOM_CENTRE As Short = 1
Public Const SIS_ALIGN_BOTTOM_RIGHT As Short = 2
Public Const SIS_ALIGN_MIDDLE_LEFT As Short = 3
Public Const SIS_ALIGN_MIDDLE_CENTRE As Short = 4
Public Const SIS_ALIGN_MIDDLE_RIGHT As Short = 5
Public Const SIS_ALIGN_TOP_LEFT As Short = 6
Public Const SIS_ALIGN_TOP_CENTRE As Short = 7
Public Const SIS_ALIGN_TOP_RIGHT As Short = 8

' NOL types:
Public Const SIS_NOL_FILE As Short = 0
Public Const SIS_NOL_STANDARD As Short = 16
Public Const SIS_NOL_TEMPORARY As Short = 32
Public Const SIS_NOL_WORKSPACE As Short = 64

' Graticule span types:
Public Const SIS_GRATICULE_NONE As Short = 0
Public Const SIS_GRATICULE_GRID As Short = 1
Public Const SIS_GRATICULE_CROSSHAIR As Short = 2
Public Const SIS_GRATICULE_CROSSHAIR_TEXT As Short = 3

' Deprecated constants:
Public Const SIS_ERROR_NO_CURRENT_LAYER As Short = 5
Public Const SIS_LEVEL_MAPPER As Short = 1
Public Const SIS_LEVEL_EDITOR As Short = 2

' Label Theme placement options:
Public Const SIS_LABEL_START As Short = 0
Public Const SIS_LABEL_MIDDLE As Short = 1
Public Const SIS_LABEL_END As Short = 2
Public Const SIS_LABEL_ALONG As Short = 3

' Index Dataset flags.
Public Const SIS_INDEX_OUTLINES As Short = 1
Public Const SIS_INDEX_LABELS As Short = 2
Public Const SIS_INDEX_PYRAMID As Short = 4

' Roamer shapes.
Public Const SIS_ROAMER_CIRCLE As Short = 0
Public Const SIS_ROAMER_SQUARE As Short = 1

' Keyhole shapes.
Public Const SIS_KEYHOLE_CIRCLE As Short = 0
Public Const SIS_KEYHOLE_SQUARE As Short = 1

' Hot snapping.
Public Const SIS_HOTSNAP_OFF As Short = 0
Public Const SIS_HOTSNAP_ON As Short = 1
Public Const SIS_HOTSNAP_ON_CURSOR As Short = 2

' GPS flags.
Public Const SIS_GPS_NMEA_GGA As Short = 1
Public Const SIS_GPS_NMEA_GLL As Short = 2
Public Const SIS_GPS_NMEA_RMC As Short = 4
Public Const SIS_GPS_NMEA_CHECKSUM As Short = 128

' Error codes.
Public Const SIS_ERROR_OK As Short = 0
Public Const SIS_ERROR_SYNTAX As Short = 1
Public Const SIS_ERROR_ITEM_NOT_FOUND As Short = 2
Public Const SIS_ERROR_ITEM_GEOM_NOT_OWNED As Short = 3
Public Const SIS_ERROR_NO_ITEM_OPEN As Short = 4
Public Const SIS_ERROR_NO_CURRENT_DATASET As Short = 5
Public Const SIS_ERROR_NO_CURRENT_WINDOW As Short = 6
Public Const SIS_ERROR_NO_POSITION As Short = 7
Public Const SIS_ERROR_INVALID_HWND As Short = 8
Public Const SIS_ERROR_UNSOLICITED As Short = 9
Public Const SIS_ERROR_NO_GROUP_OPEN As Short = 10
Public Const SIS_ERROR_BAD_INDEX As Short = 11
Public Const SIS_ERROR_INVALID_ANGLE As Short = 12
Public Const SIS_ERROR_BAD_ITEMSCAN_STATUS As Short = 13
Public Const SIS_ERROR_NO_ITEMSCAN_RUNNING As Short = 14
Public Const SIS_ERROR_FILTER_NOT_FOUND As Short = 15
Public Const SIS_ERROR_CLASS_NOT_FOUND As Short = 16
Public Const SIS_ERROR_INVALID_PROPERTY As Short = 17
Public Const SIS_ERROR_USER_CANCEL As Short = 18
Public Const SIS_ERROR_FAILED As Short = 19
Public Const SIS_ERROR_INVALID_DATASET As Short = 20
Public Const SIS_ERROR_INVALID_OVERLAY As Short = 21
Public Const SIS_ERROR_UNDEFINED_OVERRIDE As Short = 22
Public Const SIS_ERROR_INVALID_NAME As Short = 23
Public Const SIS_ERROR_INVALID_STATUS As Short = 24
Public Const SIS_ERROR_FILE_ACCESS As Short = 25
Public Const SIS_ERROR_BAD_FILTER_TYPE As Short = 26
Public Const SIS_ERROR_INVALID_POSITION As Short = 27
Public Const SIS_ERROR_INVALID_EXTENT As Short = 28
Public Const SIS_ERROR_INVALID_PARAM As Short = 29
Public Const SIS_ERROR_INVALID_LIST As Short = 30
Public Const SIS_ERROR_COMMAND_FAILED As Short = 31
Public Const SIS_ERROR_CORRUPT_MESSAGE As Short = 32
Public Const SIS_ERROR_LOCUS_NOT_FOUND As Short = 33
Public Const SIS_ERROR_BUSY As Short = 34
Public Const SIS_ERROR_LIBRARY As Short = 35
Public Const SIS_ERROR_DATASET_MODIFIED As Short = 36
Public Const SIS_ERROR_BAD_DATASET_TYPE As Short = 37
Public Const SIS_ERROR_ITEM_READONLY As Short = 38
Public Const SIS_ERROR_GROUP_ALREADY_PLACED As Short = 39
Public Const SIS_ERROR_GROUP_EMPTY As Short = 40
Public Const SIS_ERROR_NO_EDITABLE_ITEMS As Short = 41
Public Const SIS_ERROR_NO_SELECTION As Short = 42
Public Const SIS_ERROR_LIST_NOT_FOUND As Short = 43
Public Const SIS_ERROR_BAD_ITEM_TYPE As Short = 44
Public Const SIS_ERROR_EXTREME_PARAMETER As Short = 45
Public Const SIS_ERROR_NOL_NOT_FOUND As Short = 46
Public Const SIS_ERROR_EMPTY_RESULT As Short = 47
Public Const SIS_ERROR_ITEM_NOT_IN_SWD As Short = 48
Public Const SIS_ERROR_LIST_EMPTY As Short = 49
Public Const SIS_ERROR_INSUFFICIENT_ITEM_ACCESS As Short = 50
Public Const SIS_ERROR_PARTIAL_SUCCESS As Short = 51
Public Const SIS_ERROR_OUT_OF_MEMORY As Short = 52
Public Const SIS_ERROR_INCONSISTENT_PARAMS As Short = 53
Public Const SIS_ERROR_REMOVE_DEFAULT_NOL As Short = 54
Public Const SIS_ERROR_NO_COMPOSED_WINDOW As Short = 55
Public Const SIS_ERROR_NOL_NOT_SUITABLE As Short = 56
Public Const SIS_ERROR_METHOD_NOT_IN_LEVEL As Short = 57
Public Const SIS_ERROR_COMMAND_NOT_IN_LEVEL As Short = 58
Public Const SIS_ERROR_DIFFERENT_DATASETS As Short = 59
Public Const SIS_ERROR_NOT_DATA_ENABLED As Short = 60
Public Const SIS_ERROR_TEMPLATE_NO_DATASETS As Short = 61
Public Const SIS_ERROR_TEMPLATE_NO_PHOTO As Short = 62
Public Const SIS_ERROR_TEMPLATE_PHOTO_NOT_EMPTY As Short = 63
Public Const SIS_ERROR_BAD_RESAMPLE_METHOD As Short = 64
Public Const SIS_ERROR_INVALID_FORMULA As Short = 65
Public Const SIS_ERROR_SCHEMA_NOT_FOUND As Short = 66
Public Const SIS_ERROR_THEME_NOT_FOUND As Short = 67
Public Const SIS_ERROR_SEED_NOT_FOUND As Short = 68
Public Const SIS_ERROR_NAMER_NOT_FOUND As Short = 69
Public Const SIS_ERROR_COMMAND_NOT_FOUND As Short = 70
Public Const SIS_ERROR_PROJECTION_NOT_FOUND As Short = 71
Public Const SIS_ERROR_DATUM_NOT_FOUND As Short = 72
Public Const SIS_ERROR_FTABLE_NOT_FOUND As Short = 73
Public Const SIS_ERROR_PTEMP_NOT_FOUND As Short = 74
Public Const SIS_ERROR_TABLE_NOT_FOUND As Short = 75
Public Const SIS_ERROR_NO_FTABLE_LOADED As Short = 76
Public Const SIS_ERROR_NOL_MODIFIED As Short = 77
Public Const SIS_ERROR_BRUSH_NOT_FOUND As Short = 78
Public Const SIS_ERROR_COLOURSET_NOT_FOUND As Short = 79
Public Const SIS_ERROR_PEN_NOT_FOUND As Short = 80
Public Const SIS_ERROR_NO_SCHEMA_LOADED As Short = 81
Public Const SIS_ERROR_VIEW_NOT_FOUND As Short = 82
Public Const SIS_ERROR_NO_THEME_LOADED As Short = 83
Public Const SIS_ERROR_NO_LONGER_SUPPORTED As Short = 84
Public Const SIS_ERROR_NOL_OBJECT_NOT_FOUND As Short = 85
Public Const SIS_ERROR_UNLICENCED As Short = 86
Public Const SIS_ERROR_SESSION_NOT_FOUND As Short = 87
Public Const SIS_ERROR_SESSION_LIMIT As Short = 88
Public Const SIS_ERROR_SESSION_IN_USE As Short = 89
Public Const SIS_ERROR_NO_CURRENT_SESSION As Short = 90
Public Const SIS_ERROR_CURSOR_NOT_FOUND As Short = 91
Public Const SIS_ERROR_CURSOR_IS_CLOSED As Short = 92
Public Const SIS_ERROR_GPS_ALREADY_OPEN As Short = 93
Public Const SIS_ERROR_GPS_NOT_CONNECTED As Short = 94
Public Const SIS_ERROR_GPS_PAUSED As Short = 95
Public Const SIS_ERROR_GPS_NOT_REPLAYING As Short = 96
Public Const SIS_ERROR_GPS_NOT_LOGGING As Short = 97
Public Const SIS_ERROR_GPS_ALREADY_LOGGING As Short = 98

' Windows API calls made by GisLink routines.
Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
Declare Function RegisterWindowMessage Lib "user32"  Alias "RegisterWindowMessageA"(ByVal lpString As String) As Integer
Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Short, ByVal lParam As Integer) As Integer

' GLCORE.DLL routines.
Declare Function AtomFromText Lib "GLCORE32.DLL" (ByVal text As String) As Short
Declare Function TextFromAtom Lib "GLCORE32.DLL" (ByVal atom As Short, ByVal szName As String, ByVal maxlen As Short) As Short

' Variables used by GisLink routines.
Public errGis As Integer ' Result of last GIS call.
Dim hWndGis As Integer ' GIS link window. All messages sent here.
Dim hWndVB As Integer ' Visual Basic link window, must contain all command buttons.
Dim msgAdvertise As Integer ' Message used to advertise ourselves to GIS.
Dim msgExecute As Integer ' Message used to execute GIS operation.
Dim msgGetArg As Integer ' Message used while waiting for user to enter position etc.
Dim msgRelease As Integer ' Message used to release our control of GIS.
Dim msgRequest As Integer ' Message used to request data from GIS.
Dim msgTakeover As Integer ' Message used to take over control of GIS user interface.

Sub ExecuteGis(ByVal statement As String)
    Dim atom As Short
    If hWndGis <> 0 Then
        atom = AtomFromText(statement)
        errGis = SendMessage(hWndGis, msgExecute, atom, hWndVB)
        If errGis <> 0 Then
            'This would be a good place to put a Halt
        End If
    Else
        MsgBox("No Gis session linked")
    End If
End Sub

Function GisGetArg() As Integer
    ' Get number of arguments user has entered so far.
    Dim nArg As Integer
    nArg = GisGetInt(SIS_OT_SYSTEM, 0, "_NumArg&")
    
    ' Start argument collecting command in GIS.
    GisSwitchCommand("AComGetArg")
    GisRelease()
    
    Do 
        ' Let user interact with GIS session.
        System.Windows.Forms.Application.DoEvents()
        
        ' See if user has done something yet.
        errGis = SendMessage(hWndGis, msgGetArg, nArg, hWndVB)
        If errGis = 0 Then Exit Do ' We now have control again
    Loop 
    
    ' Find out what user did.
    GisGetArg = GisGetInt(SIS_OT_SYSTEM, 0, "_TypeArg&")
End Function

Function GisGetPos(ByRef x As Double, ByRef y As Double, ByRef z As Double) As Short
    GisGetPos = False
    Dim typeArg As Integer
    Dim pos As String
    Do 
        typeArg = GisGetArg()
        If typeArg = SIS_ARG_ESCAPE Then Exit Do
        If typeArg = SIS_ARG_POSITION Then
            pos = GisGetStr(SIS_OT_SYSTEM, 0, "_ArgPos$")
            If pos <> "" Then
                GisSplitPos(x, y, z, pos)
                GisGetPos = True
                Exit Do
            End If
        End If
    Loop 
End Function

Function GisGetPosEx(ByRef x As Double, ByRef y As Double, ByRef z As Double) As Integer
    GisGetPosEx = SIS_ARG_ESCAPE
    Dim typeArg As Integer
    Dim pos As String
    Do 
        typeArg = GisGetArg()
        GisGetPosEx = typeArg
        Select Case typeArg
            Case SIS_ARG_ESCAPE, SIS_ARG_ENTER, SIS_ARG_BACKSPACE
                Exit Function
            Case SIS_ARG_POSITION
                pos = GisGetStr(SIS_OT_SYSTEM, 0, "_ArgPos$")
                If pos <> "" Then
                    GisSplitPos(x, y, z, pos)
                    Exit Function
                End If
        End Select
    Loop 
End Function

Sub GisRelease()
    errGis = SendMessage(hWndGis, msgRelease, 0, hWndVB)
End Sub

Sub GisReleaseNA()
    errGis = SendMessage(hWndGis, msgRelease, 1, hWndVB)
End Sub

Sub GisSetForegroundWindow(ByVal hWndForm As System.IntPtr)
    Dim msgForeground As Short
    errGis = SendMessage(hWndGis, msgForeground, 0, hWndForm.ToInt32)
End Sub

Function GisSetupLink(ByVal hWndForm As System.IntPtr) As Integer
    hWndGis = FindWindow("AfxFrameOrView70", "GIS Link")
    If hWndGis = 0 Then
        hWndGis = FindWindow("AfxFrameOrView70d", "GIS Link")
    End If
    If hWndGis = 0 Then
        hWndGis = FindWindow("AfxFrameOrView42", "GIS Link")
    End If
    If hWndGis = 0 Then
        hWndGis = FindWindow("AfxFrameOrView42d", "GIS Link")
    End If
    hWndVB = hWndForm.ToInt32
    msgAdvertise = RegisterWindowMessage("WM_GISLINK_ADVERTISE")
    msgExecute = RegisterWindowMessage("WM_GISLINK_EXECUTE")
    msgGetArg = RegisterWindowMessage("WM_GISLINK_GETARG")
    msgRelease = RegisterWindowMessage("WM_GISLINK_RELEASE")
    msgRequest = RegisterWindowMessage("WM_GISLINK_REQUEST")
    msgTakeover = RegisterWindowMessage("WM_GISLINK_TAKEOVER")
    errGis = SendMessage(hWndGis, msgAdvertise, 0, hWndVB)
    GisSetupLink = hWndGis 'Will be 0 if link failed.
End Function

Function GisSplitExtent(ByRef x1 As Double, ByRef y1 As Double, ByRef z1 As Double, ByRef x2 As Double, ByRef y2 As Double, ByRef z2 As Double, ByVal ext As String) As Short
    Dim n As Short
    Dim strHead As String
    
    GisSplitExtent = False
    x1 = 0#
    y1 = 0#
    z1 = 0#
    x2 = 0#
    y2 = 0#
    z2 = 0#
    
    n = InStr(ext, ",")
    If n = 0 Then Exit Function
    strHead = Left(ext, n - 1)
    x1 = Val(strHead)
    ext = Mid(ext, n + 1)
    
    n = InStr(ext, ",")
    If n = 0 Then Exit Function
    strHead = Left(ext, n - 1)
    y1 = Val(strHead)
    ext = Mid(ext, n + 1)
    
    n = InStr(ext, ",")
    If n = 0 Then Exit Function
    strHead = Left(ext, n - 1)
    z1 = Val(strHead)
    ext = Mid(ext, n + 1)
    
    n = InStr(ext, ",")
    If n = 0 Then Exit Function
    strHead = Left(ext, n - 1)
    x2 = Val(strHead)
    ext = Mid(ext, n + 1)
    
    n = InStr(ext, ",")
    If n = 0 Then Exit Function
    strHead = Left(ext, n - 1)
    y2 = Val(strHead)
    ext = Mid(ext, n + 1)
    
    z2 = Val(ext)
    
    GisSplitExtent = True
End Function

Function GisSplitPos(ByRef x As Double, ByRef y As Double, ByRef z As Double, ByVal posn As String) As Short
    Dim n As Short
    Dim strHead As String
    
    GisSplitPos = False
    x = 0#
    y = 0#
    z = 0#
    
    n = InStr(posn, ",")
    If n = 0 Then Exit Function
    strHead = Left(posn, n - 1)
    x = Val(strHead)
    posn = Mid(posn, n + 1)
    
    n = InStr(posn, ",")
    If n = 0 Then Exit Function
    strHead = Left(posn, n - 1)
    y = Val(strHead)
    posn = Mid(posn, n + 1)
    
    z = Val(posn)
    
    GisSplitPos = True
End Function

Function GisTakeover() As Short
    errGis = SendMessage(hWndGis, msgTakeover, 0, hWndVB)
    If errGis = 0 Then
        GisTakeover = True
    Else
        GisTakeover = False
    End If
End Function

Function RequestGis(ByRef varname As String) As String
    Dim retval As String
    retval = ""

    Dim atom As Short
    Dim ans As Integer
    <VBFixedString(32767)> Static buffer As New String(Chr(0),32767)
    Dim nchar As Short
    If hWndGis <> 0 Then
        atom = AtomFromText(varname)

        ans = SendMessage(hWndGis, msgRequest, atom, hWndVB)

        ' Sign extend returned atom value so conversion does not overflow.
        If (ans And 32768) <> 0 Then ans = ans Or &HFFFF0000
        atom = CSng(ans)

        nchar = TextFromAtom(atom, buffer, 32767) ' The last param should be size of buffer.

        Dim e As System.Text.Encoding
        Dim b() As Byte
        e = System.Text.Encoding.Default ' Gets default code page.
        b = e.GetBytes(buffer)
        If (nchar > b.Length) Then nchar = b.Length
        retval = e.GetString(b, 0, nchar)
    Else
        MsgBox("No Gis session linked")
    End If
    RequestGis = retval
End Function

Sub GisAddToList (ByVal list As String)
    ExecuteGis ("GISADDTOLIST " + list)
End Sub

Sub GisBeginDatasetTransaction (ByVal nDataset As Integer)
    ExecuteGis ("GISBEGINDATASETTRANSACTION " + Str(nDataset))
End Sub

Sub GisBezierTo (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal x3 As Double, ByVal y3 As Double, ByVal z3 As Double)
    ExecuteGis ("GISBEZIERTO " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + Str(x3) + "" + Str(y3) + "" + Str(z3))
End Sub

Sub GisBulgeTo (ByVal angle As Double, ByVal x As Double, ByVal y As Double)
    ExecuteGis ("GISBULGETO " + Str(angle) + "" + Str(x) + "" + Str(y))
End Sub

Sub GisChangeFeatureFilter (ByVal aFilter As String, ByVal fcode As Integer, ByVal flag As Short)
    ExecuteGis ("GISCHANGEFEATUREFILTER " + aFilter + "" + Str(fcode) + "" + Str(flag))
End Sub

Sub GisChangeLocusTestMode (ByVal locus As String, ByVal geomTest As Short, ByVal geomMode As Short)
    ExecuteGis ("GISCHANGELOCUSTESTMODE " + locus + "" + Str(geomTest) + "" + Str(geomMode))
End Sub

Sub GisChangePrjUnits (ByVal prjOut As String, ByVal prjIn As String, ByVal mode As Short, ByVal dSize As Double)
    ExecuteGis ("GISCHANGEPRJUNITS " + prjOut + "" + prjIn + "" + Str(mode) + "" + Str(dSize))
End Sub

Sub GisChangeValueListFilter (ByVal aFilter As String, ByVal flag As Short, ByVal listval As String)
    ExecuteGis ("GISCHANGEVALUELISTFILTER " + aFilter + "" + Str(flag) + "" + listval)
End Sub

Sub GisCleanLines (ByVal list As String, ByVal tolerance As Double, ByVal options As Short)
    ExecuteGis ("GISCLEANLINES " + list + "" + Str(tolerance) + "" + Str(options))
End Sub

Sub GisCloseCursor (ByVal cursor As String)
    ExecuteGis ("GISCLOSECURSOR " + cursor)
End Sub

Sub GisCloseDataset (ByVal filename As String)
    ExecuteGis ("GISCLOSEDATASET " + filename)
End Sub

Sub GisCloseIndexDatasetTile (ByVal nDataset As Integer, ByVal tilename As String)
    ExecuteGis ("GISCLOSEINDEXDATASETTILE " + Str(nDataset) + "" + tilename)
End Sub

Sub GisCloseItem ()
    ExecuteGis ("GISCLOSEITEM")
End Sub

Sub GisCombineFilter (ByVal filterOutput As String, ByVal filter1 As String, ByVal filter2 As String, ByVal mode As Short)
    ExecuteGis ("GISCOMBINEFILTER " + filterOutput + "" + filter1 + "" + filter2 + "" + Str(mode))
End Sub

Sub GisCombineLists (ByVal listOutput As String, ByVal list1 As String, ByVal list2 As String, ByVal mode As Short)
    ExecuteGis ("GISCOMBINELISTS " + listOutput + "" + list1 + "" + list2 + "" + Str(mode))
End Sub

Sub GisCombineLocus (ByVal locusOutput As String, ByVal locus1 As String, ByVal locus2 As String, ByVal mode As Short)
    ExecuteGis ("GISCOMBINELOCUS " + locusOutput + "" + locus1 + "" + locus2 + "" + Str(mode))
End Sub

Sub GisCommitDatasetTransaction (ByVal nDataset As Integer)
    ExecuteGis ("GISCOMMITDATASETTRANSACTION " + Str(nDataset))
End Sub

Sub GisCompactDataset (ByVal nDataset As Integer)
    ExecuteGis ("GISCOMPACTDATASET " + Str(nDataset))
End Sub

Sub GisCompose ()
    ExecuteGis ("GISCOMPOSE")
End Sub

Sub GisConnectGps (ByVal port As String, ByVal baudrate As Integer, ByVal databits As Integer, ByVal parity As Integer, ByVal stopbits As Integer, ByVal flags As Integer)
    ExecuteGis ("GISCONNECTGPS " + port + "" + Str(baudrate) + "" + Str(databits) + "" + Str(parity) + "" + Str(stopbits) + "" + Str(flags))
End Sub

Sub GisCopyFeatureCode (ByVal fcodeTo As Integer, ByVal fcodeFrom As Integer, ByVal ftable As String)
    ExecuteGis ("GISCOPYFEATURECODE " + Str(fcodeTo) + "" + Str(fcodeFrom) + "" + ftable)
End Sub

Sub GisCopyListItems (ByVal list As String)
    ExecuteGis ("GISCOPYLISTITEMS " + list)
End Sub

Sub GisCopyThemeComponent (ByVal componentTo As Short, ByVal componentFrom As Short, ByVal theme As String)
    ExecuteGis ("GISCOPYTHEMECOMPONENT " + Str(componentTo) + "" + Str(componentFrom) + "" + theme)
End Sub

Sub GisCreateAreaFromLines (ByVal list As String, ByVal bDelete As Short, ByVal createOption As Short)
    ExecuteGis ("GISCREATEAREAFROMLINES " + list + "" + Str(bDelete) + "" + Str(createOption))
End Sub

Sub GisCreateAspectGrid (ByVal list As String, ByVal resolution As Double)
    ExecuteGis ("GISCREATEASPECTGRID " + list + "" + Str(resolution))
End Sub

Sub GisCreateAssembly (ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal shape As String, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISCREATEASSEMBLY " + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + shape + "" + Str(a) + "" + Str(s))
End Sub

Sub GisCreateBackdropOverlay (ByVal pos As Short, ByVal backdrop As String)
    ExecuteGis ("GISCREATEBACKDROPOVERLAY " + Str(pos) + "" + backdrop)
End Sub

Sub GisCreateBarTheme (ByVal nBlocks As Short)
    ExecuteGis ("GISCREATEBARTHEME " + Str(nBlocks))
End Sub

Sub GisCreateBds (ByVal filename As String)
    ExecuteGis ("GISCREATEBDS " + filename)
End Sub

Sub GisCreateBitmap (ByVal filename As String, ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal bLinked As Short, ByVal bStretch As Short)
    ExecuteGis ("GISCREATEBITMAP " + filename + "" + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2) + "" + Str(bLinked) + "" + Str(bStretch))
End Sub

Sub GisCreateBlock (ByVal list As String, ByVal blk As String, ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISCREATEBLOCK " + list + "" + blk + "" + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisCreateBoolean (ByVal list As String, ByVal boolop As Short)
    ExecuteGis ("GISCREATEBOOLEAN " + list + "" + Str(boolop))
End Sub

Sub GisCreateBoundary ()
    ExecuteGis ("GISCREATEBOUNDARY")
End Sub

Sub GisCreateBoxLabel (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal h As Double, ByVal text As String, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double)
    ExecuteGis ("GISCREATEBOXLABEL " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(h) + "" + text + "" + Str(x2) + "" + Str(y2) + "" + Str(z2))
End Sub

Sub GisCreateBoxText (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal h As Double, ByVal text As String)
    ExecuteGis ("GISCREATEBOXTEXT " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(h) + "" + text)
End Sub

Sub GisCreateBufferFromItems (ByVal list As String, ByVal radius As Double, ByVal resolution As Double)
    ExecuteGis ("GISCREATEBUFFERFROMITEMS " + list + "" + Str(radius) + "" + Str(resolution))
End Sub

Sub GisCreateBufferLocusFromItems (ByVal list As String, ByVal bDelete As Short, ByVal locus As String, ByVal radius As Double, ByVal resolution As Double)
    ExecuteGis ("GISCREATEBUFFERLOCUSFROMITEMS " + list + "" + Str(bDelete) + "" + locus + "" + Str(radius) + "" + Str(resolution))
End Sub

Sub GisCreateCircle (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal r As Double)
    ExecuteGis ("GISCREATECIRCLE " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(r))
End Sub

Sub GisCreateCircleLocus (ByVal locus As String, ByVal x As Double, ByVal y As Double, ByVal radius As Double)
    ExecuteGis ("GISCREATECIRCLELOCUS " + locus + "" + Str(x) + "" + Str(y) + "" + Str(radius))
End Sub

Sub GisCreateClassTreeFilter (ByVal aFilter As String, ByVal formula As String)
    ExecuteGis ("GISCREATECLASSTREEFILTER " + aFilter + "" + formula)
End Sub

Sub GisCreateCombinedFilter (ByVal aFilter As String)
    ExecuteGis ("GISCREATECOMBINEDFILTER " + aFilter)
End Sub

Sub GisCreateContourTheme (ByVal hMajor As Double, ByVal hMinor As Double)
    ExecuteGis ("GISCREATECONTOURTHEME " + Str(hMajor) + "" + Str(hMinor))
End Sub

Sub GisCreateConvexHull ()
    ExecuteGis ("GISCREATECONVEXHULL")
End Sub

Sub GisCreateDataSourceOverlay (ByVal pos As Short, ByVal clsDataSource As String, ByVal parameters As String)
    ExecuteGis ("GISCREATEDATASOURCEOVERLAY " + Str(pos) + "" + clsDataSource + "" + parameters)
End Sub

Sub GisCreateDbBlobOverlay (ByVal pos As Short, ByVal prj As String, ByVal rs As String, ByVal fmt As Short, ByVal nfBlob As Short, ByVal nfId As Short, ByVal nfVer As Short, ByVal nfSr As Short, ByVal nfSlMin As Short, ByVal nfSlMax As Short, ByVal span As Double)
    ExecuteGis ("GISCREATEDBBLOBOVERLAY " + Str(pos) + "" + prj + "" + rs + "" + Str(fmt) + "" + Str(nfBlob) + "" + Str(nfId) + "" + Str(nfVer) + "" + Str(nfSr) + "" + Str(nfSlMin) + "" + Str(nfSlMax) + "" + Str(span))
End Sub

Sub GisCreateDbOverlay (ByVal pos As Short, ByVal unused As Short, ByVal bTransact As Short, ByVal connect As String, ByVal tableItem As String, ByVal prj As String, ByVal fmt As Short, ByVal span As Double)
    ExecuteGis ("GISCREATEDBOVERLAY " + Str(pos) + "" + Str(unused) + "" + Str(bTransact) + "" + connect + "" + tableItem + "" + prj + "" + Str(fmt) + "" + Str(span))
End Sub

Sub GisCreateDbPointOverlay (ByVal pos As Short, ByVal prj As String, ByVal rs As String, ByVal aclass As String, ByVal nfX As Short, ByVal nfY As Short, ByVal nfId As Short, ByVal nfSr As Short, ByVal nfZ As Short, ByVal nfUnused As Short, ByVal span As Double)
    ExecuteGis ("GISCREATEDBPOINTOVERLAY " + Str(pos) + "" + prj + "" + rs + "" + aclass + "" + Str(nfX) + "" + Str(nfY) + "" + Str(nfId) + "" + Str(nfSr) + "" + Str(nfZ) + "" + Str(nfUnused) + "" + Str(span))
End Sub

Sub GisCreateDbTable (ByVal table As String, ByVal rs As String, ByVal linkfields As String, ByVal bReadOnly As Short)
    ExecuteGis ("GISCREATEDBTABLE " + table + "" + rs + "" + linkfields + "" + Str(bReadOnly))
End Sub

Sub GisCreateDisplacement (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double)
    ExecuteGis ("GISCREATEDISPLACEMENT " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2))
End Sub

Sub GisCreateDotTheme (ByVal formula As String)
    ExecuteGis ("GISCREATEDOTTHEME " + formula)
End Sub

Sub GisCreateDoubleBoolean (ByVal list1 As String, ByVal boolop1 As Short, ByVal list2 As String, ByVal boolop2 As Short, ByVal boolop3 As Short)
    ExecuteGis ("GISCREATEDOUBLEBOOLEAN " + list1 + "" + Str(boolop1) + "" + list2 + "" + Str(boolop2) + "" + Str(boolop3))
End Sub

Sub GisCreateDrapeBitmap (ByVal name As String)
    ExecuteGis ("GISCREATEDRAPEBITMAP " + name)
End Sub

Sub GisCreateEllipse (ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATEELLIPSE " + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreateExtrudeTheme (ByVal formula As String)
    ExecuteGis ("GISCREATEEXTRUDETHEME " + formula)
End Sub

Sub GisCreateExtrusion (ByVal height As Double)
    ExecuteGis ("GISCREATEEXTRUSION " + Str(height))
End Sub

Sub GisCreateFeatureFilter (ByVal aFilter As String, ByVal ftable As String)
    ExecuteGis ("GISCREATEFEATUREFILTER " + aFilter + "" + ftable)
End Sub

Sub GisCreateFilteredOverlay (ByVal oldPos As Short, ByVal newPos As Short, ByVal aFilter As String, ByVal locus As String)
    ExecuteGis ("GISCREATEFILTEREDOVERLAY " + Str(oldPos) + "" + Str(newPos) + "" + aFilter + "" + locus)
End Sub

Sub GisCreateFlowTheme ()
    ExecuteGis ("GISCREATEFLOWTHEME")
End Sub

Sub GisCreateFormulaGrid (ByVal formula As String)
    ExecuteGis ("GISCREATEFORMULAGRID " + formula)
End Sub

Sub GisCreateGeodeticBuffer (ByVal list As String, ByVal datum As String, ByVal distance As Double, ByVal nPoints As Integer)
    ExecuteGis ("GISCREATEGEODETICBUFFER " + list + "" + datum + "" + Str(distance) + "" + Str(nPoints))
End Sub

Sub GisCreateGradientGrid (ByVal list As String, ByVal resolution As Double)
    ExecuteGis ("GISCREATEGRADIENTGRID " + list + "" + Str(resolution))
End Sub

Sub GisCreateGraduatedTheme (ByVal formula As String)
    ExecuteGis ("GISCREATEGRADUATEDTHEME " + formula)
End Sub

Sub GisCreateGraticule (ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATEGRATICULE " + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreateGreatCircleLine (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal distance As Double, ByVal datum As String)
    ExecuteGis ("GISCREATEGREATCIRCLELINE " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + Str(distance) + "" + datum)
End Sub

Sub GisCreateGridFromQZone ()
    ExecuteGis ("GISCREATEGRIDFROMQZONE")
End Sub

Sub GisCreateGroup (ByVal groupType As String)
    ExecuteGis ("GISCREATEGROUP " + groupType)
End Sub

Sub GisCreateGroupFromItems (ByVal list As String, ByVal bDelete As Short, ByVal groupType As String)
    ExecuteGis ("GISCREATEGROUPFROMITEMS " + list + "" + Str(bDelete) + "" + groupType)
End Sub

Sub GisCreateIndexCoverage (ByVal list As String, ByVal tilename As String, ByVal namer As String, ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATEINDEXCOVERAGE " + list + "" + tilename + "" + namer + "" + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreateIndexOverlay (ByVal pos As Short, ByVal tilename As String, ByVal namer As String, ByVal flags As Short)
    ExecuteGis ("GISCREATEINDEXOVERLAY " + Str(pos) + "" + tilename + "" + namer + "" + Str(flags))
End Sub

Sub GisCreateIndividualTheme (ByVal formula As String, ByVal nValues As Short)
    ExecuteGis ("GISCREATEINDIVIDUALTHEME " + formula + "" + Str(nValues))
End Sub

Sub GisCreateIndividualThemeFromFeatureTable (ByVal ftable As String, ByVal codes As String)
    ExecuteGis ("GISCREATEINDIVIDUALTHEMEFROMFEATURETABLE " + ftable + "" + codes)
End Sub

Sub GisCreateInsert (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal blk As String, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISCREATEINSERT " + Str(x) + "" + Str(y) + "" + Str(z) + "" + blk + "" + Str(a) + "" + Str(s))
End Sub

Sub GisCreateInternalOverlay (ByVal overlay As String, ByVal pos As Short)
    ExecuteGis ("GISCREATEINTERNALOVERLAY " + overlay + "" + Str(pos))
End Sub

Sub GisCreateIsoRoute (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal r As Double, ByVal isoVal As Double, ByVal formula As String, ByVal aFilter As String, ByVal locusNoGo As String)
    ExecuteGis ("GISCREATEISOROUTE " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(r) + "" + Str(isoVal) + "" + formula + "" + aFilter + "" + locusNoGo)
End Sub

Sub GisCreateItem (ByVal blob As String, ByVal prj As String, ByVal fmt As Short)
    ExecuteGis ("GISCREATEITEM " + blob + "" + prj + "" + Str(fmt))
End Sub

Sub GisCreateItemFromLocus (ByVal locus As String)
    ExecuteGis ("GISCREATEITEMFROMLOCUS " + locus)
End Sub

Sub GisCreateKeyMap (ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal list As String, ByVal backdrop As String, ByVal view As String)
    ExecuteGis ("GISCREATEKEYMAP " + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2) + "" + list + "" + backdrop + "" + view)
End Sub

Sub GisCreateLabelTheme (ByVal formula As String)
    ExecuteGis ("GISCREATELABELTHEME " + formula)
End Sub

Sub GisCreateLayerFilter (ByVal aFilter As String, ByVal layers As String)
    ExecuteGis ("GISCREATELAYERFILTER " + aFilter + "" + layers)
End Sub

Sub GisCreateLineText (ByVal text As String)
    ExecuteGis ("GISCREATELINETEXT " + text)
End Sub

Sub GisCreateLinkFilter (ByVal aFilter As String, ByVal idlist As String)
    ExecuteGis ("GISCREATELINKFILTER " + aFilter + "" + idlist)
End Sub

Sub GisCreateListFromOverlay (ByVal pos As Short, ByVal list As String)
    ExecuteGis ("GISCREATELISTFROMOVERLAY " + Str(pos) + "" + list)
End Sub

Sub GisCreateLocusFromItem (ByVal locus As String, ByVal geomTest As Short, ByVal geomMode As Short)
    ExecuteGis ("GISCREATELOCUSFROMITEM " + locus + "" + Str(geomTest) + "" + Str(geomMode))
End Sub

Sub GisCreateNorthPoint (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal shape As String, ByVal s As Double)
    ExecuteGis ("GISCREATENORTHPOINT " + Str(x) + "" + Str(y) + "" + Str(z) + "" + shape + "" + Str(s))
End Sub

Sub GisCreateOpenGisSqlOverlay (ByVal pos As Short, ByVal connect As String, ByVal ftable As String, ByVal gtable As String)
    ExecuteGis ("GISCREATEOPENGISSQLOVERLAY " + Str(pos) + "" + connect + "" + ftable + "" + gtable)
End Sub

Sub GisCreatePhaseOverlay (ByVal oldPos As Short, ByVal newPos As Short)
    ExecuteGis ("GISCREATEPHASEOVERLAY " + Str(oldPos) + "" + Str(newPos))
End Sub

Sub GisCreatePhoto (ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATEPHOTO " + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreatePieTheme (ByVal nSlices As Short)
    ExecuteGis ("GISCREATEPIETHEME " + Str(nSlices))
End Sub

Sub GisCreatePoint (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal shape As String, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISCREATEPOINT " + Str(x) + "" + Str(y) + "" + Str(z) + "" + shape + "" + Str(a) + "" + Str(s))
End Sub

Sub GisCreatePropertyFilter (ByVal aFilter As String, ByVal formula As String)
    ExecuteGis ("GISCREATEPROPERTYFILTER " + aFilter + "" + formula)
End Sub

Sub GisCreateQZoneFromGrid (ByVal v1 As Double, ByVal v2 As Double)
    ExecuteGis ("GISCREATEQZONEFROMGRID " + Str(v1) + "" + Str(v2))
End Sub

Sub GisCreateRangeTheme (ByVal formula As String, ByVal nRanges As Short)
    ExecuteGis ("GISCREATERANGETHEME " + formula + "" + Str(nRanges))
End Sub

Sub GisCreateRectLocus (ByVal locus As String, ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATERECTLOCUS " + locus + "" + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreateRectangle (ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
    ExecuteGis ("GISCREATERECTANGLE " + Str(x1) + "" + Str(y1) + "" + Str(x2) + "" + Str(y2))
End Sub

Sub GisCreateReliefTheme (ByVal colset As String)
    ExecuteGis ("GISCREATERELIEFTHEME " + colset)
End Sub

Sub GisCreateRubberSheet (ByVal list As String)
    ExecuteGis ("GISCREATERUBBERSHEET " + list)
End Sub

Sub GisCreateScaleBar (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal shape As String, ByVal a As Double)
    ExecuteGis ("GISCREATESCALEBAR " + Str(x) + "" + Str(y) + "" + Str(z) + "" + shape + "" + Str(a))
End Sub

Sub GisCreateScatterGrid (ByVal list As String, ByVal formula As String, ByVal mode As Short, ByVal ox As Double, ByVal oy As Double, ByVal oz As Double, ByVal cx As Double, ByVal cy As Double)
    ExecuteGis ("GISCREATESCATTERGRID " + list + "" + formula + "" + Str(mode) + "" + Str(ox) + "" + Str(oy) + "" + Str(oz) + "" + Str(cx) + "" + Str(cy))
End Sub

Sub GisCreateSlopeGrid (ByVal list As String, ByVal resolution As Double)
    ExecuteGis ("GISCREATESLOPEGRID " + list + "" + Str(resolution))
End Sub

Sub GisCreateSprite (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal shape As String, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISCREATESPRITE " + Str(x) + "" + Str(y) + "" + Str(z) + "" + shape + "" + Str(a) + "" + Str(s))
End Sub

Sub GisCreateSurface ()
    ExecuteGis ("GISCREATESURFACE")
End Sub

Sub GisCreateText (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal text As String)
    ExecuteGis ("GISCREATETEXT " + Str(x) + "" + Str(y) + "" + Str(z) + "" + text)
End Sub

Sub GisCreateThiessen (ByVal listOutput As String, ByVal list As String, ByVal bClipToCurItem As Short)
    ExecuteGis ("GISCREATETHIESSEN " + listOutput + "" + list + "" + Str(bClipToCurItem))
End Sub

Sub GisCreateTin (ByVal list As String)
    ExecuteGis ("GISCREATETIN " + list)
End Sub

Sub GisCreateTopoTheme ()
    ExecuteGis ("GISCREATETOPOTHEME")
End Sub

Sub GisCreateValueListFilter (ByVal aFilter As String, ByVal propertyName As String)
    ExecuteGis ("GISCREATEVALUELISTFILTER " + aFilter + "" + propertyName)
End Sub

Sub GisCreateViewshed (ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal r As Double, ByVal bQZone As Integer)
    ExecuteGis ("GISCREATEVIEWSHED " + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(r) + "" + Str(bQZone))
End Sub

Sub GisDecomposeGeometry (ByVal list As String)
    ExecuteGis ("GISDECOMPOSEGEOMETRY " + list)
End Sub

Sub GisDefineNolDatum (ByVal datum As String, ByVal re As Double, ByVal rp As Double, ByVal dx As Double, ByVal dy As Double, ByVal dz As Double, ByVal ex As Double, ByVal ey As Double, ByVal ez As Double, ByVal m As Double, ByVal pm As Double)
    ExecuteGis ("GISDEFINENOLDATUM " + datum + "" + Str(re) + "" + Str(rp) + "" + Str(dx) + "" + Str(dy) + "" + Str(dz) + "" + Str(ex) + "" + Str(ey) + "" + Str(ez) + "" + Str(m) + "" + Str(pm))
End Sub

Sub GisDefineNolItem (ByVal item As String)
    ExecuteGis ("GISDEFINENOLITEM " + item)
End Sub

Sub GisDefineNolItemFromLocus (ByVal item As String, ByVal locus As String)
    ExecuteGis ("GISDEFINENOLITEMFROMLOCUS " + item + "" + locus)
End Sub

Sub GisDefineNolObject (ByVal aclass As String, ByVal aname As String, ByVal implicit As String)
    ExecuteGis ("GISDEFINENOLOBJECT " + aclass + "" + aname + "" + implicit)
End Sub

Sub GisDefineNolPrintTemplate (ByVal ptemplate As String)
    ExecuteGis ("GISDEFINENOLPRINTTEMPLATE " + ptemplate)
End Sub

Sub GisDefineNolPrj (ByVal projection As String, ByVal epsg As Integer)
    ExecuteGis ("GISDEFINENOLPRJ " + projection + "" + Str(epsg))
End Sub

Sub GisDefineNolPrjLatLon (ByVal prj As String, ByVal lat As Double, ByVal lon As Double, ByVal datum As String, ByVal bDeg As Short)
    ExecuteGis ("GISDEFINENOLPRJLATLON " + prj + "" + Str(lat) + "" + Str(lon) + "" + datum + "" + Str(bDeg))
End Sub

Sub GisDefineNolPrjTm (ByVal prj As String, ByVal lat As Double, ByVal lon As Double, ByVal datum As String, ByVal f0 As Double, ByVal cx As Double, ByVal cy As Double, ByVal cz As Double, ByVal tometre As Double)
    ExecuteGis ("GISDEFINENOLPRJTM " + prj + "" + Str(lat) + "" + Str(lon) + "" + datum + "" + Str(f0) + "" + Str(cx) + "" + Str(cy) + "" + Str(cz) + "" + Str(tometre))
End Sub

Sub GisDefineNolShape (ByVal shape As String, ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal s As Double)
    ExecuteGis ("GISDEFINENOLSHAPE " + shape + "" + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(s))
End Sub

Sub GisDefineNolView (ByVal view As String)
    ExecuteGis ("GISDEFINENOLVIEW " + view)
End Sub

Sub GisDelete (ByVal list As String)
    ExecuteGis ("GISDELETE " + list)
End Sub

Sub GisDeleteItem ()
    ExecuteGis ("GISDELETEITEM")
End Sub

Sub GisDeleteNolObject (ByVal nPos As Short, ByVal aclass As String, ByVal name As String)
    ExecuteGis ("GISDELETENOLOBJECT " + Str(nPos) + "" + aclass + "" + name)
End Sub

Sub GisDeleteRecordset (ByVal rs As String)
    ExecuteGis ("GISDELETERECORDSET " + rs)
End Sub

Sub GisDescribeProperty (ByVal prop As String, ByVal desc As String)
    ExecuteGis ("GISDESCRIBEPROPERTY " + prop + "" + desc)
End Sub

Sub GisDisconnectGps ()
    ExecuteGis ("GISDISCONNECTGPS")
End Sub

Sub GisDissolveItems (ByVal list As String, ByVal formula As String)
    ExecuteGis ("GISDISSOLVEITEMS " + list + "" + formula)
End Sub

Sub GisEmptyGroup ()
    ExecuteGis ("GISEMPTYGROUP")
End Sub

Sub GisEmptyList (ByVal list As String)
    ExecuteGis ("GISEMPTYLIST " + list)
End Sub

Sub GisEnableOverlayTheme (ByVal pos As Short, ByVal nTheme As Short, ByVal bEnable As Short)
    ExecuteGis ("GISENABLEOVERLAYTHEME " + Str(pos) + "" + Str(nTheme) + "" + Str(bEnable))
End Sub

Sub GisEnsureOpenWithin (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal s As Double)
    ExecuteGis ("GISENSUREOPENWITHIN " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + Str(s))
End Sub

Sub GisExplodeOverlayTheme (ByVal pos As Short, ByVal nTheme As Short, ByVal s As Double)
    ExecuteGis ("GISEXPLODEOVERLAYTHEME " + Str(pos) + "" + Str(nTheme) + "" + Str(s))
End Sub

Sub GisExportFeatureTable (ByVal ftable As String, ByVal filename As String)
    ExecuteGis ("GISEXPORTFEATURETABLE " + ftable + "" + filename)
End Sub

Sub GisFacetGeometry (ByVal list As String, ByVal tolerance As Double)
    ExecuteGis ("GISFACETGEOMETRY " + list + "" + Str(tolerance))
End Sub

Sub GisGeneraliseDP (ByVal list As String, ByVal tolerance As Double)
    ExecuteGis ("GISGENERALISEDP " + list + "" + Str(tolerance))
End Sub

Sub GisGetAxesPrj (ByVal projection As String)
    ExecuteGis ("GISGETAXESPRJ " + projection)
End Sub

Sub GisGetDatasetPrj (ByVal nDataset As Integer, ByVal projection As String)
    ExecuteGis ("GISGETDATASETPRJ " + Str(nDataset) + "" + projection)
End Sub

Sub GisGetOverlayFilter (ByVal pos As Short, ByVal aFilter As String)
    ExecuteGis ("GISGETOVERLAYFILTER " + Str(pos) + "" + aFilter)
End Sub

Sub GisGetOverlayLocus (ByVal pos As Short, ByVal locus As String)
    ExecuteGis ("GISGETOVERLAYLOCUS " + Str(pos) + "" + locus)
End Sub

Sub GisGetOverlaySchema (ByVal pos As Short, ByVal schema As String)
    ExecuteGis ("GISGETOVERLAYSCHEMA " + Str(pos) + "" + schema)
End Sub

Sub GisGetOverlayTheme (ByVal pos As Short, ByVal theme As String, ByVal nTheme As Short)
    ExecuteGis ("GISGETOVERLAYTHEME " + Str(pos) + "" + theme + "" + Str(nTheme))
End Sub

Sub GisGetViewPrj (ByVal projection As String)
    ExecuteGis ("GISGETVIEWPRJ " + projection)
End Sub

Sub GisImportDataSourceOverlay (ByVal pos As Short, ByVal clsDataSource As String, ByVal parameters As String)
    ExecuteGis ("GISIMPORTDATASOURCEOVERLAY " + Str(pos) + "" + clsDataSource + "" + parameters)
End Sub

Sub GisImportDataset (ByVal dataset As String, ByVal pos As Short)
    ExecuteGis ("GISIMPORTDATASET " + dataset + "" + Str(pos))
End Sub

Sub GisImportFeatureTable (ByVal ftable As String, ByVal filename As String)
    ExecuteGis ("GISIMPORTFEATURETABLE " + ftable + "" + filename)
End Sub

Sub GisInsertDataset (ByVal dataset As String, ByVal pos As Short)
    ExecuteGis ("GISINSERTDATASET " + dataset + "" + Str(pos))
End Sub

Sub GisInsertFeatureCode (ByVal fcode As Integer)
    ExecuteGis ("GISINSERTFEATURECODE " + Str(fcode))
End Sub

Sub GisInsertGeomPt (ByVal nGeom As Integer, ByVal arclen As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISINSERTGEOMPT " + Str(nGeom) + "" + Str(arclen) + "" + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisInsertOverlayTheme (ByVal pos As Short, ByVal theme As String, ByVal nTheme As Short)
    ExecuteGis ("GISINSERTOVERLAYTHEME " + Str(pos) + "" + theme + "" + Str(nTheme))
End Sub

Sub GisInsertSchemaColumn (ByVal formula As String, ByVal nColumn As Short)
    ExecuteGis ("GISINSERTSCHEMACOLUMN " + formula + "" + Str(nColumn))
End Sub

Sub GisIsoRoute (ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal r As Double, ByVal isoVal As Double, ByVal formula As String, ByVal aFilter As String, ByVal locusNoGo As String)
    ExecuteGis ("GISISOROUTE " + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(r) + "" + Str(isoVal) + "" + formula + "" + aFilter + "" + locusNoGo)
End Sub

Sub GisJoinLines (ByVal list As String, ByVal tolerance As Double)
    ExecuteGis ("GISJOINLINES " + list + "" + Str(tolerance))
End Sub

Sub GisLineTo (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISLINETO " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisLoadFeatureTable (ByVal ftable As String)
    ExecuteGis ("GISLOADFEATURETABLE " + ftable)
End Sub

Sub GisLoadSchema (ByVal schema As String)
    ExecuteGis ("GISLOADSCHEMA " + schema)
End Sub

Sub GisLoadTheme (ByVal theme As String)
    ExecuteGis ("GISLOADTHEME " + theme)
End Sub

Sub GisLocusIntersect (ByVal locusOut As String, ByVal locus1 As String, ByVal locus2 As String)
    ExecuteGis ("GISLOCUSINTERSECT " + locusOut + "" + locus1 + "" + locus2)
End Sub

Sub GisMoveAxes (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISMOVEAXES " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisMoveCursorToBegin (ByVal cursor As String)
    ExecuteGis ("GISMOVECURSORTOBEGIN " + cursor)
End Sub

Sub GisMoveCursorToEnd (ByVal cursor As String)
    ExecuteGis ("GISMOVECURSORTOEND " + cursor)
End Sub

Sub GisMoveList (ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISMOVELIST " + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(a) + "" + Str(s))
End Sub

Sub GisMoveTo (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISMOVETO " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisNolClose (ByVal nPos As Short, ByVal bSave As Short)
    ExecuteGis ("GISNOLCLOSE " + Str(nPos) + "" + Str(bSave))
End Sub

Sub GisNolCompact (ByVal nPos As Short)
    ExecuteGis ("GISNOLCOMPACT " + Str(nPos))
End Sub

Sub GisNolCreate (ByVal filename As String)
    ExecuteGis ("GISNOLCREATE " + filename)
End Sub

Sub GisNolInsert (ByVal filename As String, ByVal nPos As Short, ByVal bReadOnly As Short)
    ExecuteGis ("GISNOLINSERT " + filename + "" + Str(nPos) + "" + Str(bReadOnly))
End Sub

Sub GisNolOwn (ByVal nPos As Short, ByVal bOwn As Short)
    ExecuteGis ("GISNOLOWN " + Str(nPos) + "" + Str(bOwn))
End Sub

Sub GisNolSave (ByVal nPos As Short)
    ExecuteGis ("GISNOLSAVE " + Str(nPos))
End Sub

Sub GisOpenClosestItem (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal r As Double, ByVal stat As String, ByVal aFilter As String)
    ExecuteGis ("GISOPENCLOSESTITEM " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(r) + "" + stat + "" + aFilter)
End Sub

Sub GisOpenCursorItem (ByVal cursor As String)
    ExecuteGis ("GISOPENCURSORITEM " + cursor)
End Sub

Sub GisOpenDatasetItem (ByVal dataset As String, ByVal id As Integer)
    ExecuteGis ("GISOPENDATASETITEM " + dataset + "" + Str(id))
End Sub

Sub GisOpenExistingDatasetItem (ByVal nDataset As Integer, ByVal id As Integer)
    ExecuteGis ("GISOPENEXISTINGDATASETITEM " + Str(nDataset) + "" + Str(id))
End Sub

Sub GisOpenFormulaItem (ByVal nDataset As Integer, ByVal formula As String)
    ExecuteGis ("GISOPENFORMULAITEM " + Str(nDataset) + "" + formula)
End Sub

Sub GisOpenItem (ByVal id As Integer)
    ExecuteGis ("GISOPENITEM " + Str(id))
End Sub

Sub GisOpenList (ByVal list As String, ByVal n As Integer)
    ExecuteGis ("GISOPENLIST " + list + "" + Str(n))
End Sub

Sub GisOpenListCursor (ByVal cursor As String, ByVal list As String, ByVal fields As String)
    ExecuteGis ("GISOPENLISTCURSOR " + cursor + "" + list + "" + fields)
End Sub

Sub GisOpenOverlayCursor (ByVal cursor As String, ByVal pos As Integer, ByVal fields As String, ByVal bForwardOnly As Integer)
    ExecuteGis ("GISOPENOVERLAYCURSOR " + cursor + "" + Str(pos) + "" + fields + "" + Str(bForwardOnly))
End Sub

Sub GisOpenOverlayItem (ByVal pos As Short, ByVal id As Integer)
    ExecuteGis ("GISOPENOVERLAYITEM " + Str(pos) + "" + Str(id))
End Sub

Sub GisOwnDataset (ByVal dataset As String, ByVal bOwn As Short)
    ExecuteGis ("GISOWNDATASET " + dataset + "" + Str(bOwn))
End Sub

Sub GisPauseGpsReplay ()
    ExecuteGis ("GISPAUSEGPSREPLAY")
End Sub

Sub GisPhotoGrid ()
    ExecuteGis ("GISPHOTOGRID")
End Sub

Sub GisPlaceGroup (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISPLACEGROUP " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisPlacePrintTemplate (ByVal ptemplate As String, ByVal a As Double, ByVal s As Double)
    ExecuteGis ("GISPLACEPRINTTEMPLATE " + ptemplate + "" + Str(a) + "" + Str(s))
End Sub

Sub GisRecallNolItem (ByVal item As String)
    ExecuteGis ("GISRECALLNOLITEM " + item)
End Sub

Sub GisRecallNolView (ByVal view As String)
    ExecuteGis ("GISRECALLNOLVIEW " + view)
End Sub

Sub GisRefreshDataset (ByVal nDataset As Integer)
    ExecuteGis ("GISREFRESHDATASET " + Str(nDataset))
End Sub

Sub GisRefreshDbTable (ByVal table As String)
    ExecuteGis ("GISREFRESHDBTABLE " + table)
End Sub

Sub GisRegisterGroupType (ByVal clsName As String)
    ExecuteGis ("GISREGISTERGROUPTYPE " + clsName)
End Sub

Sub GisRemoveAtt (ByVal mnem As String)
    ExecuteGis ("GISREMOVEATT " + mnem)
End Sub

Sub GisRemoveFeatureCode (ByVal fcode As Integer)
    ExecuteGis ("GISREMOVEFEATURECODE " + Str(fcode))
End Sub

Sub GisRemoveListAtt (ByVal list As String, ByVal mnem As String)
    ExecuteGis ("GISREMOVELISTATT " + list + "" + mnem)
End Sub

Sub GisRemoveOverlay (ByVal pos As Short)
    ExecuteGis ("GISREMOVEOVERLAY " + Str(pos))
End Sub

Sub GisRemoveOverlayTheme (ByVal pos As Short, ByVal nTheme As Short)
    ExecuteGis ("GISREMOVEOVERLAYTHEME " + Str(pos) + "" + Str(nTheme))
End Sub

Sub GisRemoveProperty (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String)
    ExecuteGis ("GISREMOVEPROPERTY " + Str(objectType) + "" + Str(nObject) + "" + propertyName)
End Sub

Sub GisRemoveSchemaColumn (ByVal nColumn As Short)
    ExecuteGis ("GISREMOVESCHEMACOLUMN " + Str(nColumn))
End Sub

Sub GisReorderOverlay (ByVal oldPos As Short, ByVal newPos As Short)
    ExecuteGis ("GISREORDEROVERLAY " + Str(oldPos) + "" + Str(newPos))
End Sub

Sub GisReplayGpsLog (ByVal filename As String, ByVal replayrate As Integer, ByVal flags As Integer)
    ExecuteGis ("GISREPLAYGPSLOG " + filename + "" + Str(replayrate) + "" + Str(flags))
End Sub

Sub GisRollbackDatasetTransaction (ByVal nDataset As Integer)
    ExecuteGis ("GISROLLBACKDATASETTRANSACTION " + Str(nDataset))
End Sub

Sub GisRubberSheetRaster ()
    ExecuteGis ("GISRUBBERSHEETRASTER")
End Sub

Sub GisRubberSheetVector (ByVal list As String)
    ExecuteGis ("GISRUBBERSHEETVECTOR " + list)
End Sub

Sub GisSaveBitmap (ByVal filename As String, ByVal typeBitmap As Short)
    ExecuteGis ("GISSAVEBITMAP " + filename + "" + Str(typeBitmap))
End Sub

Sub GisSaveDataset (ByVal dataset As String)
    ExecuteGis ("GISSAVEDATASET " + dataset)
End Sub

Sub GisSetAxesAngle (ByVal a As Double)
    ExecuteGis ("GISSETAXESANGLE " + Str(a))
End Sub

Sub GisSetAxesNormal ()
    ExecuteGis ("GISSETAXESNORMAL")
End Sub

Sub GisSetAxesPrj (ByVal projection As String)
    ExecuteGis ("GISSETAXESPRJ " + projection)
End Sub

Sub GisSetCombinedFilterClause (ByVal aFilter As String, ByVal aclass As String, ByVal flag As Short, ByVal clause As String)
    ExecuteGis ("GISSETCOMBINEDFILTERCLAUSE " + aFilter + "" + aclass + "" + Str(flag) + "" + clause)
End Sub

Sub GisSetCoordUnits (ByVal ndim As Short, ByVal units As Short, ByVal places As Short)
    ExecuteGis ("GISSETCOORDUNITS " + Str(ndim) + "" + Str(units) + "" + Str(places))
End Sub

Sub GisSetDatasetPrj (ByVal nDataset As Integer, ByVal projection As String)
    ExecuteGis ("GISSETDATASETPRJ " + Str(nDataset) + "" + projection)
End Sub

Sub GisSetFlt (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String, ByVal value As Double)
    ExecuteGis ("GISSETFLT " + Str(objectType) + "" + Str(nObject) + "" + propertyName + "" + Str(value))
End Sub

Sub GisSetGazetteerView (ByVal clsGazetteer As String, ByVal parameters As String)
    ExecuteGis ("GISSETGAZETTEERVIEW " + clsGazetteer + "" + parameters)
End Sub

Sub GisSetGeomPt (ByVal nGeom As Integer, ByVal nPt As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISSETGEOMPT " + Str(nGeom) + "" + Str(nPt) + "" + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisSetGeomSegBulge (ByVal nGeom As Integer, ByVal nSeg As Integer, ByVal bulge As Double)
    ExecuteGis ("GISSETGEOMSEGBULGE " + Str(nGeom) + "" + Str(nSeg) + "" + Str(bulge))
End Sub

Sub GisSetGridItemValue (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal v As Double)
    ExecuteGis ("GISSETGRIDITEMVALUE " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(v))
End Sub

Sub GisSetInt (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String, ByVal value As Integer)
    ExecuteGis ("GISSETINT " + Str(objectType) + "" + Str(nObject) + "" + propertyName + "" + Str(value))
End Sub

Sub GisSetListFlt (ByVal list As String, ByVal propertyName As String, ByVal value As Double)
    ExecuteGis ("GISSETLISTFLT " + list + "" + propertyName + "" + Str(value))
End Sub

Sub GisSetListFormula (ByVal list As String, ByVal propertyName As String, ByVal formula As String)
    ExecuteGis ("GISSETLISTFORMULA " + list + "" + propertyName + "" + formula)
End Sub

Sub GisSetListInt (ByVal list As String, ByVal propertyName As String, ByVal value As Integer)
    ExecuteGis ("GISSETLISTINT " + list + "" + propertyName + "" + Str(value))
End Sub

Sub GisSetListStr (ByVal list As String, ByVal propertyName As String, ByVal value As String)
    ExecuteGis ("GISSETLISTSTR " + list + "" + propertyName + "" + value)
End Sub

Sub GisSetOverlayFilter (ByVal pos As Short, ByVal aFilter As String)
    ExecuteGis ("GISSETOVERLAYFILTER " + Str(pos) + "" + aFilter)
End Sub

Sub GisSetOverlayLocus (ByVal pos As Short, ByVal locus As String)
    ExecuteGis ("GISSETOVERLAYLOCUS " + Str(pos) + "" + locus)
End Sub

Sub GisSetOverlaySchema (ByVal pos As Short, ByVal schema As String)
    ExecuteGis ("GISSETOVERLAYSCHEMA " + Str(pos) + "" + schema)
End Sub

Sub GisSetPhotoWorldCentre (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISSETPHOTOWORLDCENTRE " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisSetRubberTransform (ByVal method As Short)
    ExecuteGis ("GISSETRUBBERTRANSFORM " + Str(method))
End Sub

Sub GisSetStr (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String, ByVal value As String)
    ExecuteGis ("GISSETSTR " + Str(objectType) + "" + Str(nObject) + "" + propertyName + "" + value)
End Sub

Sub GisSetUnits (ByVal units As String, ByVal places As Short)
    ExecuteGis ("GISSETUNITS " + units + "" + Str(places))
End Sub

Sub GisSetViewExtent (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double)
    ExecuteGis ("GISSETVIEWEXTENT " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2))
End Sub

Sub GisSetViewPrj (ByVal projection As String)
    ExecuteGis ("GISSETVIEWPRJ " + projection)
End Sub

Sub GisSimplifyGeom ()
    ExecuteGis ("GISSIMPLIFYGEOM")
End Sub

Sub GisSliceGeometry (ByVal list As String)
    ExecuteGis ("GISSLICEGEOMETRY " + list)
End Sub

Sub GisSnipGeometry (ByVal list As String, ByVal bInside As Short)
    ExecuteGis ("GISSNIPGEOMETRY " + list + "" + Str(bInside))
End Sub

Sub GisStartGpsLog (ByVal filename As String)
    ExecuteGis ("GISSTARTGPSLOG " + filename)
End Sub

Sub GisStopGpsLog ()
    ExecuteGis ("GISSTOPGPSLOG")
End Sub

Sub GisStopGpsReplay ()
    ExecuteGis ("GISSTOPGPSREPLAY")
End Sub

Sub GisStoreAsArea ()
    ExecuteGis ("GISSTOREASAREA")
End Sub

Sub GisStoreAsLine ()
    ExecuteGis ("GISSTOREASLINE")
End Sub

Sub GisStoreFeatureTable (ByVal ftable As String)
    ExecuteGis ("GISSTOREFEATURETABLE " + ftable)
End Sub

Sub GisStoreSchema (ByVal schema As String)
    ExecuteGis ("GISSTORESCHEMA " + schema)
End Sub

Sub GisStoreTheme (ByVal theme As String)
    ExecuteGis ("GISSTORETHEME " + theme)
End Sub

Sub GisTopoClean (ByVal list As String, ByVal tolerance As Double, ByVal options As Short)
    ExecuteGis ("GISTOPOCLEAN " + list + "" + Str(tolerance) + "" + Str(options))
End Sub

Sub GisTopoCombineNamedSeeds (ByVal seedOutput As String, ByVal seed1 As String, ByVal seed2 As String, ByVal boolop As Short)
    ExecuteGis ("GISTOPOCOMBINENAMEDSEEDS " + seedOutput + "" + seed1 + "" + seed2 + "" + Str(boolop))
End Sub

Sub GisTopoConvertToArea (ByVal bDeleteUnusedLinks As Short)
    ExecuteGis ("GISTOPOCONVERTTOAREA " + Str(bDeleteUnusedLinks))
End Sub

Sub GisTopoConvertToChain (ByVal category As String)
    ExecuteGis ("GISTOPOCONVERTTOCHAIN " + category)
End Sub

Sub GisTopoConvertToLine (ByVal bDeleteUnusedLinks As Short)
    ExecuteGis ("GISTOPOCONVERTTOLINE " + Str(bDeleteUnusedLinks))
End Sub

Sub GisTopoConvertToPolygon (ByVal category As String)
    ExecuteGis ("GISTOPOCONVERTTOPOLYGON " + category)
End Sub

Sub GisTopoCreateArea ()
    ExecuteGis ("GISTOPOCREATEAREA")
End Sub

Sub GisTopoCreateBoolean (ByVal seed As String, ByVal list As String, ByVal boolop As Short)
    ExecuteGis ("GISTOPOCREATEBOOLEAN " + seed + "" + list + "" + Str(boolop))
End Sub

Sub GisTopoCreateChain (ByVal seed As String, ByVal category As String)
    ExecuteGis ("GISTOPOCREATECHAIN " + seed + "" + category)
End Sub

Sub GisTopoCreateEmptyNamedSeed (ByVal seed As String, ByVal nDataset As Integer)
    ExecuteGis ("GISTOPOCREATEEMPTYNAMEDSEED " + seed + "" + Str(nDataset))
End Sub

Sub GisTopoCreateLine ()
    ExecuteGis ("GISTOPOCREATELINE")
End Sub

Sub GisTopoCreateLink ()
    ExecuteGis ("GISTOPOCREATELINK")
End Sub

Sub GisTopoCreateNamedSeed (ByVal seed As String)
    ExecuteGis ("GISTOPOCREATENAMEDSEED " + seed)
End Sub

Sub GisTopoCreateNode (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISTOPOCREATENODE " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisTopoCreatePolygon (ByVal seed As String, ByVal category As String)
    ExecuteGis ("GISTOPOCREATEPOLYGON " + seed + "" + category)
End Sub

Sub GisTopoDeleteLink ()
    ExecuteGis ("GISTOPODELETELINK")
End Sub

Sub GisTopoDeleteNamedSeed (ByVal seed As String)
    ExecuteGis ("GISTOPODELETENAMEDSEED " + seed)
End Sub

Sub GisTopoDeleteNode ()
    ExecuteGis ("GISTOPODELETENODE")
End Sub

Sub GisTopoDeleteSeed (ByVal bDeleteUnusedLinks As Short)
    ExecuteGis ("GISTOPODELETESEED " + Str(bDeleteUnusedLinks))
End Sub

Sub GisTopoGrowNamedSeed (ByVal seed As String, ByVal bStart As Short, ByVal idLink As Integer)
    ExecuteGis ("GISTOPOGROWNAMEDSEED " + seed + "" + Str(bStart) + "" + Str(idLink))
End Sub

Sub GisTopoMoveNode (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISTOPOMOVENODE " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisTopoPolygonsFromLinks (ByVal list As String)
    ExecuteGis ("GISTOPOPOLYGONSFROMLINKS " + list)
End Sub

Sub GisTopoReverseSeed ()
    ExecuteGis ("GISTOPOREVERSESEED")
End Sub

Sub GisTopoSetChainSeedPt (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISTOPOSETCHAINSEEDPT " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisTopoSetLinkPt (ByVal nPt As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISTOPOSETLINKPT " + Str(nPt) + "" + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisTopoSetPolygonSeedPt (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISTOPOSETPOLYGONSEEDPT " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisTraceGeom (ByVal nGeom As Integer, ByVal arclenStart As Double, ByVal arclenEnd As Double, ByVal offset As Double, ByVal bAllowSelfIntersections As Short)
    ExecuteGis ("GISTRACEGEOM " + Str(nGeom) + "" + Str(arclenStart) + "" + Str(arclenEnd) + "" + Str(offset) + "" + Str(bAllowSelfIntersections))
End Sub

Sub GisUpdateCursorItem (ByVal cursor As String)
    ExecuteGis ("GISUPDATECURSORITEM " + cursor)
End Sub

Sub GisUpdateItem ()
    ExecuteGis ("GISUPDATEITEM")
End Sub

Sub GisZoomExtent ()
    ExecuteGis ("GISZOOMEXTENT")
End Sub

Sub GisZoomView (ByVal f As Double)
    ExecuteGis ("GISZOOMVIEW " + Str(f))
End Sub

Sub GisActivateWnd (ByVal number As Short)
    ExecuteGis ("GISACTIVATEWND " + Str(number))
End Sub

Sub GisExit (ByVal savecode As Short)
    ExecuteGis ("GISEXIT " + Str(savecode))
End Sub

Sub GisRegisterTrigger (ByVal triggerEvent As String, ByVal caption As String)
    ExecuteGis ("GISREGISTERTRIGGER " + triggerEvent + "" + caption)
End Sub

Sub GisShowMenu (ByVal bShow As Integer)
    ExecuteGis ("GISSHOWMENU " + Str(bShow))
End Sub

Sub GisSwdClose (ByVal savecode As Short)
    ExecuteGis ("GISSWDCLOSE " + Str(savecode))
End Sub

Sub GisSwdNew ()
    ExecuteGis ("GISSWDNEW")
End Sub

Sub GisSwdNewFromSwt (ByVal template As String)
    ExecuteGis ("GISSWDNEWFROMSWT " + template)
End Sub

Sub GisSwdNewWindow (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double)
    ExecuteGis ("GISSWDNEWWINDOW " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2))
End Sub

Sub GisSwdNewWindow3D (ByVal xEye As Double, ByVal yEye As Double, ByVal zEye As Double, ByVal xLook As Double, ByVal yLook As Double, ByVal zLook As Double)
    ExecuteGis ("GISSWDNEWWINDOW3D " + Str(xEye) + "" + Str(yEye) + "" + Str(zEye) + "" + Str(xLook) + "" + Str(yLook) + "" + Str(zLook))
End Sub

Sub GisSwdNewWindowTable ()
    ExecuteGis ("GISSWDNEWWINDOWTABLE")
End Sub

Sub GisSwdOpen (ByVal filename As String, ByVal unused As Short)
    ExecuteGis ("GISSWDOPEN " + filename + "" + Str(unused))
End Sub

Sub GisSwdSave ()
    ExecuteGis ("GISSWDSAVE")
End Sub

Sub GisSwdSaveAs (ByVal filename As String)
    ExecuteGis ("GISSWDSAVEAS " + filename)
End Sub

Sub GisSwdSaveAsPwd (ByVal filename As String)
    ExecuteGis ("GISSWDSAVEASPWD " + filename)
End Sub

Sub GisSwdSaveAsSwt (ByVal filename As String)
    ExecuteGis ("GISSWDSAVEASSWT " + filename)
End Sub

Sub GisSwtClose (ByVal savecode As Short)
    ExecuteGis ("GISSWTCLOSE " + Str(savecode))
End Sub

Sub GisSwtNew ()
    ExecuteGis ("GISSWTNEW")
End Sub

Sub GisSwtOpen (ByVal filename As String)
    ExecuteGis ("GISSWTOPEN " + filename)
End Sub

Sub GisSwtSave ()
    ExecuteGis ("GISSWTSAVE")
End Sub

Sub GisSwtSaveAs (ByVal filename As String)
    ExecuteGis ("GISSWTSAVEAS " + filename)
End Sub

Sub GisTableNewWindow (ByVal table As String)
    ExecuteGis ("GISTABLENEWWINDOW " + table)
End Sub

Sub GisUpdateWorkspaceWindow ()
    ExecuteGis ("GISUPDATEWORKSPACEWINDOW")
End Sub

Sub GisWndArrangeIcons ()
    ExecuteGis ("GISWNDARRANGEICONS")
End Sub

Sub GisWndCascade ()
    ExecuteGis ("GISWNDCASCADE")
End Sub

Sub GisWndTile ()
    ExecuteGis ("GISWNDTILE")
End Sub

Sub GisWndTileHorizontal ()
    ExecuteGis ("GISWNDTILEHORIZONTAL")
End Sub

Sub GisWorkspaceClose (ByVal savecode As Short)
    ExecuteGis ("GISWORKSPACECLOSE " + Str(savecode))
End Sub

Sub GisWorkspaceNew (ByVal filename As String, ByVal savecode As Short)
    ExecuteGis ("GISWORKSPACENEW " + filename + "" + Str(savecode))
End Sub

Sub GisWorkspaceOpen (ByVal filename As String, ByVal savecode As Short)
    ExecuteGis ("GISWORKSPACEOPEN " + filename + "" + Str(savecode))
End Sub

Sub GisWorkspaceSave ()
    ExecuteGis ("GISWORKSPACESAVE")
End Sub

Sub GisAddCommand (ByVal menu As String, ByVal help As String, ByVal clsName As String, ByVal min As Short, ByVal max As Short, ByVal aFilter As String, ByVal locus As String)
    ExecuteGis ("GISADDCOMMAND " + menu + "" + help + "" + clsName + "" + Str(min) + "" + Str(max) + "" + aFilter + "" + locus)
End Sub

Sub GisAllowCommands (ByVal flag As Short, ByVal listcom As String)
    ExecuteGis ("GISALLOWCOMMANDS " + Str(flag) + "" + listcom)
End Sub

Sub GisCallCommand (ByVal comname As String)
    ExecuteGis ("GISCALLCOMMAND " + comname)
End Sub

Sub GisCopy (ByVal list As String, ByVal bDelete As Short)
    ExecuteGis ("GISCOPY " + list + "" + Str(bDelete))
End Sub

Sub GisCreateListFromSelection (ByVal list As String)
    ExecuteGis ("GISCREATELISTFROMSELECTION " + list)
End Sub

Sub GisDeselectAll ()
    ExecuteGis ("GISDESELECTALL")
End Sub

Sub GisDigitiserSnap (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal nButton As Short)
    ExecuteGis ("GISDIGITISERSNAP " + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(nButton))
End Sub

Sub GisDoCommand (ByVal comname As String)
    ExecuteGis ("GISDOCOMMAND " + comname)
End Sub

Sub GisDrapeBitmap (ByVal name As String)
    ExecuteGis ("GISDRAPEBITMAP " + name)
End Sub

Sub GisDrawList (ByVal drawcode As Short, ByVal list As String, ByVal pen As String, ByVal brush As String, ByVal shape As String, ByVal font As String)
    ExecuteGis ("GISDRAWLIST " + Str(drawcode) + "" + list + "" + pen + "" + brush + "" + shape + "" + font)
End Sub

Sub GisExport (ByVal clsExport As String, ByVal filename As String, ByVal parameters As String)
    ExecuteGis ("GISEXPORT " + clsExport + "" + filename + "" + parameters)
End Sub

Sub GisExportBds (ByVal filename As String, ByVal precision As Short)
    ExecuteGis ("GISEXPORTBDS " + filename + "" + Str(precision))
End Sub

Sub GisExportBmp (ByVal filename As String, ByVal bMono As Short, ByVal w As Integer, ByVal h As Integer)
    ExecuteGis ("GISEXPORTBMP " + filename + "" + Str(bMono) + "" + Str(w) + "" + Str(h))
End Sub

Sub GisExportCursorDataset (ByVal filename As String, ByVal pos As Short)
    ExecuteGis ("GISEXPORTCURSORDATASET " + filename + "" + Str(pos))
End Sub

Sub GisExportEcw (ByVal filename As String, ByVal w As Integer, ByVal h As Integer, ByVal compression As Integer)
    ExecuteGis ("GISEXPORTECW " + filename + "" + Str(w) + "" + Str(h) + "" + Str(compression))
End Sub

Sub GisExportGif (ByVal filename As String, ByVal w As Integer, ByVal h As Integer)
    ExecuteGis ("GISEXPORTGIF " + filename + "" + Str(w) + "" + Str(h))
End Sub

Sub GisExportJpeg (ByVal filename As String, ByVal w As Integer, ByVal h As Integer)
    ExecuteGis ("GISEXPORTJPEG " + filename + "" + Str(w) + "" + Str(h))
End Sub

Sub GisExportPdf (ByVal filename As String, ByVal paperFormat As String, ByVal parameters As String)
    ExecuteGis ("GISEXPORTPDF " + filename + "" + paperFormat + "" + parameters)
End Sub

Sub GisExportPng (ByVal filename As String, ByVal w As Integer, ByVal h As Integer)
    ExecuteGis ("GISEXPORTPNG " + filename + "" + Str(w) + "" + Str(h))
End Sub

Sub GisExportTiff (ByVal filename As String, ByVal w As Integer, ByVal h As Integer, ByVal tiffType As Integer, ByVal bNormalised As Short)
    ExecuteGis ("GISEXPORTTIFF " + filename + "" + Str(w) + "" + Str(h) + "" + Str(tiffType) + "" + Str(bNormalised))
End Sub

Sub GisExportVrml (ByVal filename As String)
    ExecuteGis ("GISEXPORTVRML " + filename)
End Sub

Sub GisExportWmf (ByVal filename As String)
    ExecuteGis ("GISEXPORTWMF " + filename)
End Sub

Sub GisMessage (ByVal message As String)
    ExecuteGis ("GISMESSAGE " + message)
End Sub

Sub GisOpenSel (ByVal nsel As Short)
    ExecuteGis ("GISOPENSEL " + Str(nsel))
End Sub

Sub GisPaste ()
    ExecuteGis ("GISPASTE")
End Sub

Sub GisPasteFrom (ByVal filename As String, ByVal bLinked As Short)
    ExecuteGis ("GISPASTEFROM " + filename + "" + Str(bLinked))
End Sub

Sub GisPrompt (ByVal prompt As String)
    ExecuteGis ("GISPROMPT " + prompt)
End Sub

Sub GisRedraw (ByVal redrawcode As Short)
    ExecuteGis ("GISREDRAW " + Str(redrawcode))
End Sub

Sub GisRedrawExtent (ByVal redrawcode As Short, ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double)
    ExecuteGis ("GISREDRAWEXTENT " + Str(redrawcode) + "" + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2))
End Sub

Sub GisRemoveCommand (ByVal menu As String)
    ExecuteGis ("GISREMOVECOMMAND " + menu)
End Sub

Sub GisScrollView (ByVal dx As Short, ByVal dy As Short)
    ExecuteGis ("GISSCROLLVIEW " + Str(dx) + "" + Str(dy))
End Sub

Sub GisSelectAll ()
    ExecuteGis ("GISSELECTALL")
End Sub

Sub GisSelectItem ()
    ExecuteGis ("GISSELECTITEM")
End Sub

Sub GisSelectList (ByVal list As String)
    ExecuteGis ("GISSELECTLIST " + list)
End Sub

Sub GisSendPrint (ByVal driver As String, ByVal device As String, ByVal outputName As String, ByVal forceColour As Short, ByVal fStretch As Double)
    ExecuteGis ("GISSENDPRINT " + driver + "" + device + "" + outputName + "" + Str(forceColour) + "" + Str(fStretch))
End Sub

Sub GisSet3DView (ByVal bSetView0 As Short, ByVal xEye As Double, ByVal yEye As Double, ByVal zEye As Double, ByVal xLook As Double, ByVal yLook As Double, ByVal zLook As Double)
    ExecuteGis ("GISSET3DVIEW " + Str(bSetView0) + "" + Str(xEye) + "" + Str(yEye) + "" + Str(zEye) + "" + Str(xLook) + "" + Str(yLook) + "" + Str(zLook))
End Sub

Sub GisSetAxesGrid (ByVal x As Double, ByVal y As Double, ByVal bShowGrid As Short, ByVal bShowPoints As Short, ByVal bAllowSnaps As Short)
    ExecuteGis ("GISSETAXESGRID " + Str(x) + "" + Str(y) + "" + Str(bShowGrid) + "" + Str(bShowPoints) + "" + Str(bAllowSnaps))
End Sub

Sub GisSetCommandBitmap (ByVal comname As String, ByVal bitmap As String)
    ExecuteGis ("GISSETCOMMANDBITMAP " + comname + "" + bitmap)
End Sub

Sub GisSetDefaultPrj (ByVal projection As String)
    ExecuteGis ("GISSETDEFAULTPRJ " + projection)
End Sub

Sub GisSetViewHome (ByVal view As String)
    ExecuteGis ("GISSETVIEWHOME " + view)
End Sub

Sub GisSnap (ByVal x As Double, ByVal y As Double, ByVal z As Double)
    ExecuteGis ("GISSNAP " + Str(x) + "" + Str(y) + "" + Str(z))
End Sub

Sub GisSwitchCommand (ByVal comname As String)
    ExecuteGis ("GISSWITCHCOMMAND " + comname)
End Sub

Sub GisTickCommand (ByVal comname As String, ByVal tick As Short)
    ExecuteGis ("GISTICKCOMMAND " + comname + "" + Str(tick))
End Sub

Function GisDefineRecordset (ByVal rs As String, ByVal connect As String, ByVal tables As String, ByVal columns As String, ByVal aliases As String, ByVal sqlwhere As String) As String
    GisDefineRecordset = RequestGis("GISDEFINERECORDSET$ " + rs + "" + connect + "" + tables + "" + columns + "" + aliases + "" + sqlwhere)
End Function

Function GisEvaluateFlt (ByVal objectType As Short, ByVal nObject As Integer, ByVal formula As String) As Double
    GisEvaluateFlt = Val(RequestGis("GISEVALUATEFLT# " + Str(objectType) + "" + Str(nObject) + "" + formula))
End Function

Function GisEvaluateInt (ByVal objectType As Short, ByVal nObject As Integer, ByVal formula As String) As Integer
    GisEvaluateInt = Val(RequestGis("GISEVALUATEINT& " + Str(objectType) + "" + Str(nObject) + "" + formula))
End Function

Function GisEvaluateStr (ByVal objectType As Short, ByVal nObject As Integer, ByVal formula As String) As String
    GisEvaluateStr = RequestGis("GISEVALUATESTR$ " + Str(objectType) + "" + Str(nObject) + "" + formula)
End Function

Function GisFindDatasetOverlay (ByVal nDataset As Integer, ByVal pos As Short, ByVal bForwards As Short) As Short
    GisFindDatasetOverlay = Val(RequestGis("GISFINDDATASETOVERLAY% " + Str(nDataset) + "" + Str(pos) + "" + Str(bForwards)))
End Function

Function GisFindExternalDataset (ByVal dataset As String) As Integer
    GisFindExternalDataset = Val(RequestGis("GISFINDEXTERNALDATASET& " + dataset))
End Function

Function GisGetAxesAngle () As Double
    GisGetAxesAngle = Val(RequestGis("GISGETAXESANGLE# "))
End Function

Function GisGetAxesFromLatLonHgt (ByVal lat As Double, ByVal lon As Double, ByVal hgt As Double, ByVal datum As String) As String
    GisGetAxesFromLatLonHgt = RequestGis("GISGETAXESFROMLATLONHGT$ " + Str(lat) + "" + Str(lon) + "" + Str(hgt) + "" + datum)
End Function

Function GisGetAxesType () As Short
    GisGetAxesType = Val(RequestGis("GISGETAXESTYPE% "))
End Function

Function GisGetBlob (ByVal projection As String, ByVal fmt As Short, ByVal precision As Short) As String
    GisGetBlob = RequestGis("GISGETBLOB$ " + projection + "" + Str(fmt) + "" + Str(precision))
End Function

Function GisGetBlobExtent (ByVal blob As String, ByVal prj As String, ByVal fmt As Short) As String
    GisGetBlobExtent = RequestGis("GISGETBLOBEXTENT$ " + blob + "" + prj + "" + Str(fmt))
End Function

Function GisGetClassTreeFilterValues (ByVal aFilter As String) As String
    GisGetClassTreeFilterValues = RequestGis("GISGETCLASSTREEFILTERVALUES$ " + aFilter)
End Function

Function GisGetClosestPt (ByVal x As Double, ByVal y As Double, ByVal r As Double) As String
    GisGetClosestPt = RequestGis("GISGETCLOSESTPT$ " + Str(x) + "" + Str(y) + "" + Str(r))
End Function

Function GisGetClosestVertex (ByVal x As Double, ByVal y As Double, ByVal r As Double) As String
    GisGetClosestVertex = RequestGis("GISGETCLOSESTVERTEX$ " + Str(x) + "" + Str(y) + "" + Str(r))
End Function

Function GisGetCoordExtent (ByVal coordClass As String, ByVal coord As String) As String
    GisGetCoordExtent = RequestGis("GISGETCOORDEXTENT$ " + coordClass + "" + coord)
End Function

Function GisGetCoordString (ByVal coordClass As String, ByVal x As Double, ByVal y As Double, ByVal z As Double) As String
    GisGetCoordString = RequestGis("GISGETCOORDSTRING$ " + coordClass + "" + Str(x) + "" + Str(y) + "" + Str(z))
End Function

Function GisGetCursorFieldDescription (ByVal cursor As String, ByVal nField As Integer) As String
    GisGetCursorFieldDescription = RequestGis("GISGETCURSORFIELDDESCRIPTION$ " + cursor + "" + Str(nField))
End Function

Function GisGetCursorFieldFlt (ByVal cursor As String, ByVal nField As Integer) As Double
    GisGetCursorFieldFlt = Val(RequestGis("GISGETCURSORFIELDFLT# " + cursor + "" + Str(nField)))
End Function

Function GisGetCursorFieldFormula (ByVal cursor As String, ByVal nField As Integer) As String
    GisGetCursorFieldFormula = RequestGis("GISGETCURSORFIELDFORMULA$ " + cursor + "" + Str(nField))
End Function

Function GisGetCursorFieldInt (ByVal cursor As String, ByVal nField As Integer) As Integer
    GisGetCursorFieldInt = Val(RequestGis("GISGETCURSORFIELDINT& " + cursor + "" + Str(nField)))
End Function

Function GisGetCursorFieldStatistics (ByVal cursor As String, ByVal nField As Integer) As String
    GisGetCursorFieldStatistics = RequestGis("GISGETCURSORFIELDSTATISTICS$ " + cursor + "" + Str(nField))
End Function

Function GisGetCursorFieldStr (ByVal cursor As String, ByVal nField As Integer) As String
    GisGetCursorFieldStr = RequestGis("GISGETCURSORFIELDSTR$ " + cursor + "" + Str(nField))
End Function

Function GisGetCursorFieldValues (ByVal cursor As String, ByVal separator As String, ByVal nullValue As String) As String
    GisGetCursorFieldValues = RequestGis("GISGETCURSORFIELDVALUES$ " + cursor + "" + separator + "" + nullValue)
End Function

Function GisGetCursorValues (ByVal cursor As String, ByVal nField As Integer, ByVal nDelta As Integer, ByVal separator As String, ByVal nullValue As String) As String
    GisGetCursorValues = RequestGis("GISGETCURSORVALUES$ " + cursor + "" + Str(nField) + "" + Str(nDelta) + "" + separator + "" + nullValue)
End Function

Function GisGetDataset () As Integer
    GisGetDataset = Val(RequestGis("GISGETDATASET& "))
End Function

Function GisGetDatasetContainer (ByVal nDataset As Integer, ByVal nContainer As Short) As Integer
    GisGetDatasetContainer = Val(RequestGis("GISGETDATASETCONTAINER& " + Str(nDataset) + "" + Str(nContainer)))
End Function

Function GisGetDatasetExtent (ByVal nDataset As Integer) As String
    GisGetDatasetExtent = RequestGis("GISGETDATASETEXTENT$ " + Str(nDataset))
End Function

Function GisGetExtent () As String
    GisGetExtent = RequestGis("GISGETEXTENT$ ")
End Function

Function GisGetFeatureFilterBranches (ByVal aFilter As String, ByVal fcode As Integer) As String
    GisGetFeatureFilterBranches = RequestGis("GISGETFEATUREFILTERBRANCHES$ " + aFilter + "" + Str(fcode))
End Function

Function GisGetFeatureFilterCodes (ByVal aFilter As String) As String
    GisGetFeatureFilterCodes = RequestGis("GISGETFEATUREFILTERCODES$ " + aFilter)
End Function

Function GisGetFeatureFilterTable (ByVal aFilter As String) As String
    GisGetFeatureFilterTable = RequestGis("GISGETFEATUREFILTERTABLE$ " + aFilter)
End Function

Function GisGetFeatureTableBranches (ByVal fcode As Integer, ByVal bCascade As Short) As String
    GisGetFeatureTableBranches = RequestGis("GISGETFEATURETABLEBRANCHES$ " + Str(fcode) + "" + Str(bCascade))
End Function

Function GisGetFilterClass (ByVal aFilter As String) As String
    GisGetFilterClass = RequestGis("GISGETFILTERCLASS$ " + aFilter)
End Function

Function GisGetFlt (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String) As Double
    GisGetFlt = Val(RequestGis("GISGETFLT# " + Str(objectType) + "" + Str(nObject) + "" + propertyName))
End Function

Function GisGetGeomAngleFromLength (ByVal nGeom As Integer, ByVal arclen As Double) As Double
    GisGetGeomAngleFromLength = Val(RequestGis("GISGETGEOMANGLEFROMLENGTH# " + Str(nGeom) + "" + Str(arclen)))
End Function

Function GisGetGeomDim (ByVal nGeom As Integer) As Integer
    GisGetGeomDim = Val(RequestGis("GISGETGEOMDIM& " + Str(nGeom)))
End Function

Function GisGetGeomIntersections (ByVal nGeom As Integer, ByVal list As String) As String
    GisGetGeomIntersections = RequestGis("GISGETGEOMINTERSECTIONS$ " + Str(nGeom) + "" + list)
End Function

Function GisGetGeomLength (ByVal nGeom As Integer) As Double
    GisGetGeomLength = Val(RequestGis("GISGETGEOMLENGTH# " + Str(nGeom)))
End Function

Function GisGetGeomLengthUpto (ByVal nGeom As Integer, ByVal arclenStart As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double) As Double
    GisGetGeomLengthUpto = Val(RequestGis("GISGETGEOMLENGTHUPTO# " + Str(nGeom) + "" + Str(arclenStart) + "" + Str(x) + "" + Str(y) + "" + Str(z)))
End Function

Function GisGetGeomNumPt (ByVal nGeom As Integer) As Integer
    GisGetGeomNumPt = Val(RequestGis("GISGETGEOMNUMPT& " + Str(nGeom)))
End Function

Function GisGetGeomNumSeg (ByVal nGeom As Integer) As Integer
    GisGetGeomNumSeg = Val(RequestGis("GISGETGEOMNUMSEG& " + Str(nGeom)))
End Function

Function GisGetGeomPosFromLength (ByVal nGeom As Integer, ByVal arclen As Double) As String
    GisGetGeomPosFromLength = RequestGis("GISGETGEOMPOSFROMLENGTH$ " + Str(nGeom) + "" + Str(arclen))
End Function

Function GisGetGeomPt (ByVal nGeom As Integer, ByVal nPt As Integer) As String
    GisGetGeomPt = RequestGis("GISGETGEOMPT$ " + Str(nGeom) + "" + Str(nPt))
End Function

Function GisGetGeomSegAxis (ByVal nGeom As Integer, ByVal nSeg As Integer) As String
    GisGetGeomSegAxis = RequestGis("GISGETGEOMSEGAXIS$ " + Str(nGeom) + "" + Str(nSeg))
End Function

Function GisGetGeomSegBulge (ByVal nGeom As Integer, ByVal nSeg As Integer) As Double
    GisGetGeomSegBulge = Val(RequestGis("GISGETGEOMSEGBULGE# " + Str(nGeom) + "" + Str(nSeg)))
End Function

Function GisGetGeomSegShape (ByVal nGeom As Integer, ByVal nSeg As Integer) As Short
    GisGetGeomSegShape = Val(RequestGis("GISGETGEOMSEGSHAPE% " + Str(nGeom) + "" + Str(nSeg)))
End Function

Function GisGetGeomSelfIntersection (ByVal nGeom As Integer, ByVal arclenStart As Double) As Double
    GisGetGeomSelfIntersection = Val(RequestGis("GISGETGEOMSELFINTERSECTION# " + Str(nGeom) + "" + Str(arclenStart)))
End Function

Function GisGetGeomTgtFromLength (ByVal nGeom As Integer, ByVal arclen As Double) As String
    GisGetGeomTgtFromLength = RequestGis("GISGETGEOMTGTFROMLENGTH$ " + Str(nGeom) + "" + Str(arclen))
End Function

Function GisGetGpsPosition () As String
    GisGetGpsPosition = RequestGis("GISGETGPSPOSITION$ ")
End Function

Function GisGetGridItemValue (ByVal x As Double, ByVal y As Double, ByVal z As Double) As Double
    GisGetGridItemValue = Val(RequestGis("GISGETGRIDITEMVALUE# " + Str(x) + "" + Str(y) + "" + Str(z)))
End Function

Function GisGetHook () As String
    GisGetHook = RequestGis("GISGETHOOK$ ")
End Function

Function GisGetImplicitNolObject (ByVal aclass As String, ByVal aname As String) As String
    GisGetImplicitNolObject = RequestGis("GISGETIMPLICITNOLOBJECT$ " + aclass + "" + aname)
End Function

Function GisGetInt (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String) As Integer
    GisGetInt = Val(RequestGis("GISGETINT& " + Str(objectType) + "" + Str(nObject) + "" + propertyName))
End Function

Function GisGetLatLonHgtFromAxes (ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal datum As String) As String
    GisGetLatLonHgtFromAxes = RequestGis("GISGETLATLONHGTFROMAXES$ " + Str(x) + "" + Str(y) + "" + Str(z) + "" + datum)
End Function

Function GisGetLayerFilterValues (ByVal aFilter As String) As String
    GisGetLayerFilterValues = RequestGis("GISGETLAYERFILTERVALUES$ " + aFilter)
End Function

Function GisGetLinkFilterIds (ByVal aFilter As String) As String
    GisGetLinkFilterIds = RequestGis("GISGETLINKFILTERIDS$ " + aFilter)
End Function

Function GisGetListDetails (ByVal list As String) As String
    GisGetListDetails = RequestGis("GISGETLISTDETAILS$ " + list)
End Function

Function GisGetListExtent (ByVal list As String) As String
    GisGetListExtent = RequestGis("GISGETLISTEXTENT$ " + list)
End Function

Function GisGetListItemFlt (ByVal list As String, ByVal n As Integer, ByVal propertyName As String) As Double
    GisGetListItemFlt = Val(RequestGis("GISGETLISTITEMFLT# " + list + "" + Str(n) + "" + propertyName))
End Function

Function GisGetListItemInt (ByVal list As String, ByVal n As Integer, ByVal propertyName As String) As Integer
    GisGetListItemInt = Val(RequestGis("GISGETLISTITEMINT& " + list + "" + Str(n) + "" + propertyName))
End Function

Function GisGetListItemStr (ByVal list As String, ByVal n As Integer, ByVal propertyName As String) As String
    GisGetListItemStr = RequestGis("GISGETLISTITEMSTR$ " + list + "" + Str(n) + "" + propertyName)
End Function

Function GisGetListSize (ByVal list As String) As Integer
    GisGetListSize = Val(RequestGis("GISGETLISTSIZE& " + list))
End Function

Function GisGetNumCursorFields (ByVal cursor As String) As Integer
    GisGetNumCursorFields = Val(RequestGis("GISGETNUMCURSORFIELDS& " + cursor))
End Function

Function GisGetNumGeom () As Integer
    GisGetNumGeom = Val(RequestGis("GISGETNUMGEOM& "))
End Function

Function GisGetNumNol () As Short
    GisGetNumNol = Val(RequestGis("GISGETNUMNOL% "))
End Function

Function GisGetOverlayThemeLegend (ByVal pos As Short, ByVal nTheme As Short, ByVal projection As String, ByVal fmt As Short, ByVal precision As Short) As String
    GisGetOverlayThemeLegend = RequestGis("GISGETOVERLAYTHEMELEGEND$ " + Str(pos) + "" + Str(nTheme) + "" + projection + "" + Str(fmt) + "" + Str(precision))
End Function

Function GisGetPhotoWorldPos (ByVal paperX As Double, ByVal paperY As Double) As String
    GisGetPhotoWorldPos = RequestGis("GISGETPHOTOWORLDPOS$ " + Str(paperX) + "" + Str(paperY))
End Function

Function GisGetPrjCode (ByVal prj As String) As Integer
    GisGetPrjCode = Val(RequestGis("GISGETPRJCODE& " + prj))
End Function

Function GisGetPropertyDescription (ByVal prop As String) As String
    GisGetPropertyDescription = RequestGis("GISGETPROPERTYDESCRIPTION$ " + prop)
End Function

Function GisGetPropertyFilterFormula (ByVal aFilter As String) As String
    GisGetPropertyFilterFormula = RequestGis("GISGETPROPERTYFILTERFORMULA$ " + aFilter)
End Function

Function GisGetSpatialReference (ByVal projection As String, ByVal span As Double) As String
    GisGetSpatialReference = RequestGis("GISGETSPATIALREFERENCE$ " + projection + "" + Str(span))
End Function

Function GisGetSpatialReferenceFromExtent (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal projection As String, ByVal span As Double) As String
    GisGetSpatialReferenceFromExtent = RequestGis("GISGETSPATIALREFERENCEFROMEXTENT$ " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + projection + "" + Str(span))
End Function

Function GisGetStr (ByVal objectType As Short, ByVal nObject As Integer, ByVal propertyName As String) As String
    GisGetStr = RequestGis("GISGETSTR$ " + Str(objectType) + "" + Str(nObject) + "" + propertyName)
End Function

Function GisGetValueListFilterProperty (ByVal aFilter As String) As String
    GisGetValueListFilterProperty = RequestGis("GISGETVALUELISTFILTERPROPERTY$ " + aFilter)
End Function

Function GisGetValueListFilterValues (ByVal aFilter As String) As String
    GisGetValueListFilterValues = RequestGis("GISGETVALUELISTFILTERVALUES$ " + aFilter)
End Function

Function GisGetViewExtent () As String
    GisGetViewExtent = RequestGis("GISGETVIEWEXTENT$ ")
End Function

Function GisIsOverlayThemeEnabled (ByVal pos As Short, ByVal nTheme As Short) As Short
    GisIsOverlayThemeEnabled = Val(RequestGis("GISISOVERLAYTHEMEENABLED% " + Str(pos) + "" + Str(nTheme)))
End Function

Function GisMeasureAzimuth (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal datum As String) As Double
    GisMeasureAzimuth = Val(RequestGis("GISMEASUREAZIMUTH# " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + datum))
End Function

Function GisMeasureGreatCircle (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal datum As String) As Double
    GisMeasureGreatCircle = Val(RequestGis("GISMEASUREGREATCIRCLE# " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + datum))
End Function

Function GisMeasureRoute (ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByVal formula As String, ByVal aFilter As String, ByVal locusNoGo As String, ByVal bCreateLine As Short) As Double
    GisMeasureRoute = Val(RequestGis("GISMEASUREROUTE# " + Str(x1) + "" + Str(y1) + "" + Str(z1) + "" + Str(x2) + "" + Str(y2) + "" + Str(z2) + "" + formula + "" + aFilter + "" + locusNoGo + "" + Str(bCreateLine)))
End Function

Function GisMetreFromStr (ByVal s As String) As Double
    GisMetreFromStr = Val(RequestGis("GISMETREFROMSTR# " + s))
End Function

Function GisMoveCursor (ByVal cursor As String, ByVal nDelta As Integer) As Integer
    GisMoveCursor = Val(RequestGis("GISMOVECURSOR& " + cursor + "" + Str(nDelta)))
End Function

Function GisMultiRoute (ByVal list As String, ByVal nStart As Integer, ByVal maxNum As Integer, ByVal maxVal As Double, ByVal rSnap As Double, ByVal formula As String, ByVal aFilter As String, ByVal locusNoGo As String) As String
    GisMultiRoute = RequestGis("GISMULTIROUTE$ " + list + "" + Str(nStart) + "" + Str(maxNum) + "" + Str(maxVal) + "" + Str(rSnap) + "" + formula + "" + aFilter + "" + locusNoGo)
End Function

Function GisNolCatalog (ByVal aclass As String, ByVal bCurOnly As Short) As String
    GisNolCatalog = RequestGis("GISNOLCATALOG$ " + aclass + "" + Str(bCurOnly))
End Function

Function GisScan (ByVal list As String, ByVal stat As String, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScan = Val(RequestGis("GISSCAN& " + list + "" + stat + "" + aFilter + "" + locus))
End Function

Function GisScanDataset (ByVal list As String, ByVal nDataset As Integer, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScanDataset = Val(RequestGis("GISSCANDATASET& " + list + "" + Str(nDataset) + "" + aFilter + "" + locus))
End Function

Function GisScanGeometry (ByVal list As String, ByVal geomTest As Short, ByVal geomMode As Short, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScanGeometry = Val(RequestGis("GISSCANGEOMETRY& " + list + "" + Str(geomTest) + "" + Str(geomMode) + "" + aFilter + "" + locus))
End Function

Function GisScanList (ByVal listOut As String, ByVal listIn As String, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScanList = Val(RequestGis("GISSCANLIST& " + listOut + "" + listIn + "" + aFilter + "" + locus))
End Function

Function GisScanOverlay (ByVal list As String, ByVal pos As Short, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScanOverlay = Val(RequestGis("GISSCANOVERLAY& " + list + "" + Str(pos) + "" + aFilter + "" + locus))
End Function

Function GisScanPointContainers (ByVal list As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal aFilter As String, ByVal locus As String) As Integer
    GisScanPointContainers = Val(RequestGis("GISSCANPOINTCONTAINERS& " + list + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + aFilter + "" + locus))
End Function

Function GisSnap2D (ByVal x As Double, ByVal y As Double, ByVal r As Double, ByVal bEditOnly As Integer, ByVal codes As String, ByVal aFilter As String, ByVal locus As String) As String
    GisSnap2D = RequestGis("GISSNAP2D$ " + Str(x) + "" + Str(y) + "" + Str(r) + "" + Str(bEditOnly) + "" + codes + "" + aFilter + "" + locus)
End Function

Function GisSplitCombinedFilter (ByVal aFilter As String, ByVal filter1 As String, ByVal filter2 As String) As Integer
    GisSplitCombinedFilter = Val(RequestGis("GISSPLITCOMBINEDFILTER& " + aFilter + "" + filter1 + "" + filter2))
End Function

Function GisStrFromMetre (ByVal metre As Double, ByVal ndim As Short, ByVal showunits As Short) As String
    GisStrFromMetre = RequestGis("GISSTRFROMMETRE$ " + Str(metre) + "" + Str(ndim) + "" + Str(showunits))
End Function

Function GisTopoEdgeFill (ByVal seed As String, ByVal bForwards As Short, ByVal aFilter As String) As Short
    GisTopoEdgeFill = Val(RequestGis("GISTOPOEDGEFILL% " + seed + "" + Str(bForwards) + "" + aFilter))
End Function

Function GisTopoFindRoute (ByVal seed As String, ByVal idNode1 As Integer, ByVal idNode2 As Integer, ByVal nDataset As Integer, ByVal formula As String, ByVal aFilter As String, ByVal locusNoGo As String) As Short
    GisTopoFindRoute = Val(RequestGis("GISTOPOFINDROUTE% " + seed + "" + Str(idNode1) + "" + Str(idNode2) + "" + Str(nDataset) + "" + formula + "" + aFilter + "" + locusNoGo))
End Function

Function GisTopoFloodFill (ByVal seed As String, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal nDataset As Integer, ByVal aFilter As String) As Short
    GisTopoFloodFill = Val(RequestGis("GISTOPOFLOODFILL% " + seed + "" + Str(x) + "" + Str(y) + "" + Str(z) + "" + Str(nDataset) + "" + aFilter))
End Function

Function GisTopoGetLinkNode (ByVal bStart As Short) As Integer
    GisTopoGetLinkNode = Val(RequestGis("GISTOPOGETLINKNODE& " + Str(bStart)))
End Function

Function GisTopoGetLinkNumSeed () As Short
    GisTopoGetLinkNumSeed = Val(RequestGis("GISTOPOGETLINKNUMSEED% "))
End Function

Function GisTopoGetLinkSeed (ByVal n As Short) As Integer
    GisTopoGetLinkSeed = Val(RequestGis("GISTOPOGETLINKSEED& " + Str(n)))
End Function

Function GisTopoGetNamedSeedDataset (ByVal seed As String) As Integer
    GisTopoGetNamedSeedDataset = Val(RequestGis("GISTOPOGETNAMEDSEEDDATASET& " + seed))
End Function

Function GisTopoGetNamedSeedLoopLink (ByVal seed As String, ByVal nLoop As Short, ByVal n As Short) As Integer
    GisTopoGetNamedSeedLoopLink = Val(RequestGis("GISTOPOGETNAMEDSEEDLOOPLINK& " + seed + "" + Str(nLoop) + "" + Str(n)))
End Function

Function GisTopoGetNamedSeedLoopSize (ByVal seed As String, ByVal nLoop As Short) As Short
    GisTopoGetNamedSeedLoopSize = Val(RequestGis("GISTOPOGETNAMEDSEEDLOOPSIZE% " + seed + "" + Str(nLoop)))
End Function

Function GisTopoGetNamedSeedNumLoop (ByVal seed As String) As Short
    GisTopoGetNamedSeedNumLoop = Val(RequestGis("GISTOPOGETNAMEDSEEDNUMLOOP% " + seed))
End Function

Function GisTopoGetNodeLink (ByVal n As Short) As Integer
    GisTopoGetNodeLink = Val(RequestGis("GISTOPOGETNODELINK& " + Str(n)))
End Function

Function GisTopoGetNodeNumLink () As Short
    GisTopoGetNodeNumLink = Val(RequestGis("GISTOPOGETNODENUMLINK% "))
End Function

Function GisTopoIsChain (ByVal seed As String) As Short
    GisTopoIsChain = Val(RequestGis("GISTOPOISCHAIN% " + seed))
End Function

Function GisTopoIsPolygon (ByVal seed As String) As Short
    GisTopoIsPolygon = Val(RequestGis("GISTOPOISPOLYGON% " + seed))
End Function

Function GisTopoShrinkNamedSeed (ByVal seed As String, ByVal bStart As Short) As Integer
    GisTopoShrinkNamedSeed = Val(RequestGis("GISTOPOSHRINKNAMEDSEED& " + seed + "" + Str(bStart)))
End Function

Function GisGetNumSwd () As Short
    GisGetNumSwd = Val(RequestGis("GISGETNUMSWD% "))
End Function

Function GisGetNumWnd () As Short
    GisGetNumWnd = Val(RequestGis("GISGETNUMWND% "))
End Function

Function GisCanDoCommand (ByVal comname As String) As Short
    GisCanDoCommand = Val(RequestGis("GISCANDOCOMMAND% " + comname))
End Function

Function GisGet3DEye () As String
    GisGet3DEye = RequestGis("GISGET3DEYE$ ")
End Function

Function GisGet3DLook () As String
    GisGet3DLook = RequestGis("GISGET3DLOOK$ ")
End Function

Function GisGetCommandTick (ByVal comname As String) As Short
    GisGetCommandTick = Val(RequestGis("GISGETCOMMANDTICK% " + comname))
End Function

Function GisGetDisplayExtent () As String
    GisGetDisplayExtent = RequestGis("GISGETDISPLAYEXTENT$ ")
End Function

Function GisGetNumSel () As Short
    GisGetNumSel = Val(RequestGis("GISGETNUMSEL% "))
End Function

Function GisGetNumSelEx () As Integer
    GisGetNumSelEx = Val(RequestGis("GISGETNUMSELEX& "))
End Function


End Module
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           