Public Class Form1
    Dim score As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PaceY(Enemy, PictureBox41, 15)

    End Sub

    Sub follow(e As PictureBox, a As PictureBox, Xspeed As Integer, Yspeed As Integer)
        If e.Location.Y < a.Location.Y Then
            move(e, 0, Yspeed)
        Else
            move(e, 0, -Yspeed)
        End If
        If e.Location.X < a.Location.X Then
            move(e, Xspeed, 0)
        Else
            move(e, -Xspeed, 0)
        End If
    End Sub


    Sub PaceX(e As PictureBox, p As PictureBox, speed As Integer)
        Dim dir As Integer
        dir = e.Tag

        move(e, dir * speed, 0)

        If e.Location.X > p.Location.X + p.Width / 1.2 Then
            e.Tag = dir * -1
        End If
        If e.Location.X < p.Location.X Then
            e.Tag = dir * -1
        End If
    End Sub

    Sub PaceY(e As PictureBox, p As PictureBox, speed As Integer)
        Dim dir As Integer
        dir = e.Tag

        move(e, 0, dir * speed)

        If e.Location.Y < p.Location.Y Then
            e.Tag = dir * -1
        End If
        If e.Location.Y > p.Location.Y + p.Height Then
            e.Tag = dir * -1
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            move(Avatar, 30, 0)
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            move(Avatar, -30, 0)
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            move(Avatar, 0, 30)
        End If
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            move(Avatar, 0, -30)
        End If
        If e.KeyCode = Keys.Space Then
            Avatar.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        End If
        Avatar.Refresh()


    End Sub

    Dim movements As New Dictionary(Of String, Collection)
    Dim tracks As New Dictionary(Of String, Integer)
    Sub move(p As PictureBox, xdir As Integer, ydir As Integer)
        p.Location += New Point(xdir, ydir)

        If IntersectsWith(p, "wall") Then
            p.Location -= New Point(xdir, ydir)
        End If
        Dim c As PictureBox
        If IntersectsWith(p, "coin", c) Then
            c.Visible = False
            score += 2
            ScoreLabel.Text = score
        End If

        Dim g As PictureBox
        If IntersectsWith(p, "gem", g) Then
            g.Visible = False
            score += 5
            ScoreLabel.Text = score
        End If

        Dim b As PictureBox
        If IntersectsWith(Avatar, "enemy", b) Then
            Avatar.Location = New Point(895, 558)
        End If

        If IntersectsWith(Avatar, "end") Then
            Label2.Visible = True
            Button1.Visible = True
        End If

        If Not movements.ContainsKey(p.Name) Then
            movements.Add(p.Name, New Collection)
        End If
        movements(p.Name).Add(p.Location)

    End Sub


    'Add this code
    Sub Track(e As PictureBox, a As PictureBox)
        If Not tracks.ContainsKey(e.Name & a.Name) Then
            tracks.Add(e.Name & a.Name, 1)
        Else
            Dim idx As Integer
            idx = tracks(e.Name & a.Name)
            If movements.ContainsKey(a.Name) AndAlso idx < movements(a.Name).Count Then
                e.Location = movements(a.Name).Item(idx)
                tracks(e.Name & a.Name) = idx + 1
            End If

        End If
    End Sub

    Function endingWith(s As String) As Collection
        Dim coll As New Collection
        For Each o In Controls
            Dim obj As PictureBox
            obj = TryCast(o, PictureBox)
            If Not obj Is Nothing Then
                If UCase(obj.Name).EndsWith(UCase(s)) Then
                    coll.Add(obj)
                End If
            End If
        Next
        Return coll
    End Function

    Function IntersectsWith(p As PictureBox, tag As String) As Boolean
        Return IntersectsWith(p, tag, Nothing)
    End Function
    Function IntersectsWith(p As PictureBox, tag As String, Optional ByRef other As PictureBox = Nothing) As Boolean
        For Each o In Controls
            Dim obj As PictureBox
            obj = TryCast(o, PictureBox)
            If Not obj Is Nothing AndAlso obj.Visible Then
                If p.Bounds.IntersectsWith(obj.Bounds) And (UCase(obj.Tag) = UCase(tag) Or
                    UCase(obj.Name).EndsWith(UCase(tag))) Then
                    other = obj
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Timer2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Avatar.Location = New Point(895, 558)
        Enemy.Location = New Point(936, 73)
        twoEnemy.Location = New Point(38, 411)
        threeEnemy.Location = New Point(271, 538)
        coin1.Visible = True
        coin2.Visible = True
        coin3.Visible = True
        coin4.Visible = True
        coin5.Visible = True
        coin6.Visible = True
        coin7.Visible = True
        gem1.Visible = True
        gem2.Visible = True
        gem3.Visible = True
        Button1.Visible = False
        Label2.Visible = False
        ScoreLabel.Text = 0
    End Sub
End Class
