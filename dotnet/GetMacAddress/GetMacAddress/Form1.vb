﻿Imports System.Net.NetworkInformation

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim nics As NetworkInterface() =  tworkInterface.GetAllNetworkInterfaces()
        Dim strMacAddress As String = nics(0).GetPhysicalAddress.ToString

        tb1.Text = strMacAddress

    End Sub
End Class
