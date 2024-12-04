Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Security
Imports System.Security.Principal
Imports System.Security.RightsManagement
Imports System.Windows.Interop
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Media3D

Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Fact1.Text = "9 species of hammer head shark"
        Fact2.Text = "Give birth to live young"
        Fact3.Text = "Cannot see right in front of them"
        Fact4.Text = "They like traveling in groups"

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Fact1.Text = "one of the largest species of shark"
        Fact2.Text = "They see well in dim lighting"
        Fact3.Text = "They have distinct markings"
        Fact4.Text = "measure 10 - 14 ft average"
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Fact1.Text = "Can live up to 130 years"
        Fact2.Text = "They are filter feeders"
        Fact3.Text = "largest shark species"
        Fact4.Text = "slow swimmers"
    End Sub
End Class
