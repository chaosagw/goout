nectedContext" Flags="stop1" />
		<Exception Name="DllMainReturnsFalse" />
		<Exception Name="ExceptionSwallowedOnCallFromCom" />
		<Exception Name="FailedQI" />
		<Exception Name="FatalExecutionEngineError" Flags="stop1" />
		<Exception Name="GcManagedToUnmanaged" />
		<Exception Name="GcUnmanagedToManaged" />
		<Exception Name="IllegalPrepareConstrainedRegion" />
		<Exception Name="InvalidApartmentStateChange" />
		<Exception Name="InvalidCERCall" />
		<Exception Name="InvalidConfigFile" />
		<Exception Name="InvalidFunctionPointerInDelegate" Flags="stop1" />
		<Exception Name="InvalidGCHandleCookie" />
		<Exception Name="InvalidIUnknown" />
		<Exception Name="InvalidMemberDeclaration" Flags="stop1" />
		<Exception Name="InvalidOverlappedToPinvoke" />
		<Exception Name="InvalidVariant" Flags="stop1" />
		<Exception Name="JitCompilationStart" />
		<Exception Name="LoaderLock" Flags="stop1" />
		<Exception Name="LoadFromContext" />
		<Exception Name="MarshalCleanupError" />
		<Exception Name="Marshaling" />
		<Exception Name="MemberInfoCacheCreation" />
		<Exception Name="ModuloObjectHashcode" />
		<Exception Name="NonComVisibleBaseClass" Flags="stop1" />
		<Exception Name="NotMarshalable" />
		<Exception Name="OpenGenericCERCall" />
		<Exception Name="OverlappedFreeError" />
		<Exception Name="PInvokeLog" />
		<Exception Name="PInvokeStackImbalance" Flags="stop1" />
		<Exception Name="RaceOnRCWCleanup" Flags="stop1" />
		<Exception Name="Reentrancy" Flags="stop1" />
		<Exception Name="ReleaseHandleFailed" />
		<Exception Name="ReportAvOnComRelease" />
		<Exception Name="StreamWriterBufferedDataLost" />
		<Exception Name="VirtualCERCall" />
		<Exception Name="XmlValidationError" />
	</ExceptionDefs>
</Exceptions>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    oleCon = Nothing
            End Try

        Next

        'val = "values(" & no & year & "," & month & "," & Day() & "," & "'" & today & "'" & "," & "'" & name & "'" & "," & "'" & bukken & "'" & "," & kado & ")"
        'MessageBox.Show(val)

        'strSQL = "insert into 集計(no,年,月,日,日付,名前,物件,時間) " & val
        'strSQL = "insert into 集計(年,月,日付,名前,物件,時間) " & "values('1234567890',9,'2007-03-04 05:06:07')"

        'db.Connect(MDB, -1)

        'db.BeginTransaction()

        'db.ExecuteSql(strSQL)

        'db.CommitTransaction()

        'db.Disconnect()



    End Sub

End Module
