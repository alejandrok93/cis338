<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CATALOG_IDLabel As System.Windows.Forms.Label
        Dim YEARLabel As System.Windows.Forms.Label
        Dim QUARTERLabel As System.Windows.Forms.Label
        Dim COURSE_IDLabel As System.Windows.Forms.Label
        Dim PROF_IDLabel As System.Windows.Forms.Label
        Me.gbCatalogDetail = New System.Windows.Forms.GroupBox()
        Me.CATALOG_IDTextBox = New System.Windows.Forms.TextBox()
        Me.YEARTextBox = New System.Windows.Forms.TextBox()
        Me.QUARTERComboBox = New System.Windows.Forms.ComboBox()
        Me.COURSE_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.PROF_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbCatalogList = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CPP_CATALOGDataGridView = New System.Windows.Forms.DataGridView()
        CATALOG_IDLabel = New System.Windows.Forms.Label()
        YEARLabel = New System.Windows.Forms.Label()
        QUARTERLabel = New System.Windows.Forms.Label()
        COURSE_IDLabel = New System.Windows.Forms.Label()
        PROF_IDLabel = New System.Windows.Forms.Label()
        Me.gbCatalogDetail.SuspendLayout
        Me.gbCatalogList.SuspendLayout
        CType(Me.CPP_CATALOGDataGridView,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CATALOG_IDLabel
        '
        CATALOG_IDLabel.AutoSize = true
        CATALOG_IDLabel.Location = New System.Drawing.Point(61, 38)
        CATALOG_IDLabel.Name = "CATALOG_IDLabel"
        CATALOG_IDLabel.Size = New System.Drawing.Size(74, 13)
        CATALOG_IDLabel.TabIndex = 24
        CATALOG_IDLabel.Text = "CATALOG ID:"
        '
        'YEARLabel
        '
        YEARLabel.AutoSize = true
        YEARLabel.Location = New System.Drawing.Point(61, 64)
        YEARLabel.Name = "YEARLabel"
        YEARLabel.Size = New System.Drawing.Size(39, 13)
        YEARLabel.TabIndex = 26
        YEARLabel.Text = "YEAR:"
        '
        'QUARTERLabel
        '
        QUARTERLabel.AutoSize = true
        QUARTERLabel.Location = New System.Drawing.Point(61, 90)
        QUARTERLabel.Name = "QUARTERLabel"
        QUARTERLabel.Size = New System.Drawing.Size(63, 13)
        QUARTERLabel.TabIndex = 28
        QUARTERLabel.Text = "QUARTER:"
        '
        'COURSE_IDLabel
        '
        COURSE_IDLabel.AutoSize = true
        COURSE_IDLabel.Location = New System.Drawing.Point(61, 117)
        COURSE_IDLabel.Name = "COURSE_IDLabel"
        COURSE_IDLabel.Size = New System.Drawing.Size(69, 13)
        COURSE_IDLabel.TabIndex = 30
        COURSE_IDLabel.Text = "COURSE ID:"
        '
        'PROF_IDLabel
        '
        PROF_IDLabel.AutoSize = true
        PROF_IDLabel.Location = New System.Drawing.Point(61, 144)
        PROF_IDLabel.Name = "PROF_IDLabel"
        PROF_IDLabel.Size = New System.Drawing.Size(53, 13)
        PROF_IDLabel.TabIndex = 32
        PROF_IDLabel.Text = "PROF ID:"
        '
        'gbCatalogDetail
        '
        Me.gbCatalogDetail.Controls.Add(CATALOG_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.CATALOG_IDTextBox)
        Me.gbCatalogDetail.Controls.Add(YEARLabel)
        Me.gbCatalogDetail.Controls.Add(Me.YEARTextBox)
        Me.gbCatalogDetail.Controls.Add(QUARTERLabel)
        Me.gbCatalogDetail.Controls.Add(Me.QUARTERComboBox)
        Me.gbCatalogDetail.Controls.Add(COURSE_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.COURSE_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(PROF_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.PROF_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(Me.Button2)
        Me.gbCatalogDetail.Controls.Add(Me.Button1)
        Me.gbCatalogDetail.Location = New System.Drawing.Point(12, 12)
        Me.gbCatalogDetail.Name = "gbCatalogDetail"
        Me.gbCatalogDetail.Size = New System.Drawing.Size(641, 252)
        Me.gbCatalogDetail.TabIndex = 14
        Me.gbCatalogDetail.TabStop = false
        Me.gbCatalogDetail.Text = "Course Catalog Information"
        Me.gbCatalogDetail.Visible = false
        '
        'CATALOG_IDTextBox
        '
        Me.CATALOG_IDTextBox.Location = New System.Drawing.Point(141, 35)
        Me.CATALOG_IDTextBox.Name = "CATALOG_IDTextBox"
        Me.CATALOG_IDTextBox.Size = New System.Drawing.Size(75, 20)
        Me.CATALOG_IDTextBox.TabIndex = 25
        '
        'YEARTextBox
        '
        Me.YEARTextBox.Location = New System.Drawing.Point(141, 61)
        Me.YEARTextBox.Name = "YEARTextBox"
        Me.YEARTextBox.Size = New System.Drawing.Size(121, 20)
        Me.YEARTextBox.TabIndex = 27
        '
        'QUARTERComboBox
        '
        Me.QUARTERComboBox.FormattingEnabled = true
        Me.QUARTERComboBox.Items.AddRange(New Object() {"FALL", "WINTER", "SPRING", "SUMMER"})
        Me.QUARTERComboBox.Location = New System.Drawing.Point(141, 87)
        Me.QUARTERComboBox.Name = "QUARTERComboBox"
        Me.QUARTERComboBox.Size = New System.Drawing.Size(121, 21)
        Me.QUARTERComboBox.TabIndex = 29
        '
        'COURSE_IDComboBox
        '
        Me.COURSE_IDComboBox.FormattingEnabled = true
        Me.COURSE_IDComboBox.Items.AddRange(New Object() {"CIS234 - (INTRO TO JAVA)", "CIS304 - (INTERMEDIATE JAVA)", "CIS305 - (DATABASE MANAGEMENT)", "CIS338 - (BUSINESS OOP USING VB)", "COM200 - (COMMUNICATION AND MARKETING)", "FRL100 - (INTRODUCTION TO FINANCE)", "TOM100 - (BEGINNER OPERATIONS MANAGEMENT)"})
        Me.COURSE_IDComboBox.Location = New System.Drawing.Point(141, 114)
        Me.COURSE_IDComboBox.Name = "COURSE_IDComboBox"
        Me.COURSE_IDComboBox.Size = New System.Drawing.Size(291, 21)
        Me.COURSE_IDComboBox.TabIndex = 31
        '
        'PROF_IDComboBox
        '
        Me.PROF_IDComboBox.FormattingEnabled = True
        Me.PROF_IDComboBox.Items.AddRange(New Object() {"P100 - (HANK, HILL)", "P200 - (SEAN, CONNERY)", "P300 - (TOM, HANKS)", "P400 - (MARY, POPPINS)", "P500 - (DONALD, DUCK)"})
        Me.PROF_IDComboBox.Location = New System.Drawing.Point(141, 141)
        Me.PROF_IDComboBox.Name = "PROF_IDComboBox"
        Me.PROF_IDComboBox.Size = New System.Drawing.Size(291, 21)
        Me.PROF_IDComboBox.TabIndex = 33
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(165, 191)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'gbCatalogList
        '
        Me.gbCatalogList.Controls.Add(Me.Button6)
        Me.gbCatalogList.Controls.Add(Me.Button5)
        Me.gbCatalogList.Controls.Add(Me.Button4)
        Me.gbCatalogList.Controls.Add(Me.Button3)
        Me.gbCatalogList.Controls.Add(Me.CPP_CATALOGDataGridView)
        Me.gbCatalogList.Location = New System.Drawing.Point(12, 270)
        Me.gbCatalogList.Name = "gbCatalogList"
        Me.gbCatalogList.Size = New System.Drawing.Size(641, 382)
        Me.gbCatalogList.TabIndex = 15
        Me.gbCatalogList.TabStop = false
        Me.gbCatalogList.Text = "Course Catalog List"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(295, 327)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Find"
        Me.Button6.UseVisualStyleBackColor = true
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(199, 327)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Delete"
        Me.Button5.UseVisualStyleBackColor = true
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(107, 327)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "Update"
        Me.Button4.UseVisualStyleBackColor = true
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(17, 327)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'CPP_CATALOGDataGridView
        '
        Me.CPP_CATALOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CPP_CATALOGDataGridView.Location = New System.Drawing.Point(17, 24)
        Me.CPP_CATALOGDataGridView.Name = "CPP_CATALOGDataGridView"
        Me.CPP_CATALOGDataGridView.Size = New System.Drawing.Size(607, 272)
        Me.CPP_CATALOGDataGridView.TabIndex = 14
        '
        'frmCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 662)
        Me.Controls.Add(Me.gbCatalogList)
        Me.Controls.Add(Me.gbCatalogDetail)
        Me.Name = "frmCatalog"
        Me.Text = "CPP COURSE CATALOG INFORMATION"
        Me.gbCatalogDetail.ResumeLayout(false)
        Me.gbCatalogDetail.PerformLayout
        Me.gbCatalogList.ResumeLayout(false)
        CType(Me.CPP_CATALOGDataGridView,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents gbCatalogDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gbCatalogList As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CPP_CATALOGDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CATALOG_IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YEARTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QUARTERComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents COURSE_IDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PROF_IDComboBox As System.Windows.Forms.ComboBox
End Class
