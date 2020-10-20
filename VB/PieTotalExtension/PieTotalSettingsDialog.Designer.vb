Namespace PieTotalExtension
	Partial Public Class PieTotalSettingsDialog
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
			Me.textEdit2 = New DevExpress.XtraEditors.TextEdit()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.lookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
			Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.emptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.memoEdit1)
			Me.layoutControl1.Controls.Add(Me.textEdit2)
			Me.layoutControl1.Controls.Add(Me.textEdit1)
			Me.layoutControl1.Controls.Add(Me.simpleButton2)
			Me.layoutControl1.Controls.Add(Me.simpleButton1)
			Me.layoutControl1.Controls.Add(Me.lookUpEdit1)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(476, 235, 650, 400)
			Me.layoutControl1.Root = Me.Root
			Me.layoutControl1.Size = New System.Drawing.Size(399, 296)
			Me.layoutControl1.TabIndex = 0
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' memoEdit1
			' 
			Me.memoEdit1.Location = New System.Drawing.Point(24, 116)
			Me.memoEdit1.Name = "memoEdit1"
			Me.memoEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.memoEdit1.Properties.Appearance.Options.UseFont = True
			Me.memoEdit1.Properties.Appearance.Options.UseTextOptions = True
			Me.memoEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
			Me.memoEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
			Me.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
			Me.memoEdit1.Size = New System.Drawing.Size(351, 130)
			Me.memoEdit1.StyleController = Me.layoutControl1
			Me.memoEdit1.TabIndex = 11
			' 
			' textEdit2
			' 
			Me.textEdit2.Location = New System.Drawing.Point(117, 72)
			Me.textEdit2.Name = "textEdit2"
			Me.textEdit2.Size = New System.Drawing.Size(258, 20)
			Me.textEdit2.StyleController = Me.layoutControl1
			Me.textEdit2.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
			' 
			' textEdit1
			' 
			Me.textEdit1.Location = New System.Drawing.Point(117, 48)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(258, 20)
			Me.textEdit1.StyleController = Me.layoutControl1
			Me.textEdit1.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
			' 
			' simpleButton2
			' 
			Me.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.simpleButton2.Location = New System.Drawing.Point(337, 262)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(50, 22)
			Me.simpleButton2.StyleController = Me.layoutControl1
			Me.simpleButton2.TabIndex = 6
			Me.simpleButton2.Text = "Cancel"
			' 
			' simpleButton1
			' 
			Me.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.simpleButton1.Location = New System.Drawing.Point(284, 262)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(49, 22)
			Me.simpleButton1.StyleController = Me.layoutControl1
			Me.simpleButton1.TabIndex = 5
			Me.simpleButton1.Text = "Ok"
			' 
			' lookUpEdit1
			' 
			Me.lookUpEdit1.Location = New System.Drawing.Point(117, 24)
			Me.lookUpEdit1.Name = "lookUpEdit1"
			Me.lookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.lookUpEdit1.Size = New System.Drawing.Size(258, 20)
			Me.lookUpEdit1.StyleController = Me.layoutControl1
			Me.lookUpEdit1.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
			' 
			' Root
			' 
			Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.Root.GroupBordersVisible = False
			Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem2, Me.layoutControlItem3, Me.emptySpaceItem1, Me.layoutControlGroup1})
			Me.Root.Name = "Root"
			Me.Root.Size = New System.Drawing.Size(399, 296)
			Me.Root.TextVisible = False
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.simpleButton1
			Me.layoutControlItem2.Location = New System.Drawing.Point(272, 250)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(53, 26)
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextVisible = False
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.simpleButton2
			Me.layoutControlItem3.Location = New System.Drawing.Point(325, 250)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(54, 26)
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextVisible = False
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 250)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(272, 26)
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem6, Me.emptySpaceItem4, Me.layoutControlItem1, Me.layoutControlItem5, Me.layoutControlItem4})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(379, 250)
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem6
			' 
			Me.layoutControlItem6.Control = Me.memoEdit1
			Me.layoutControlItem6.Enabled = False
			Me.layoutControlItem6.Location = New System.Drawing.Point(0, 92)
			Me.layoutControlItem6.Name = "layoutControlItem6"
			Me.layoutControlItem6.Size = New System.Drawing.Size(355, 134)
			Me.layoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem6.TextVisible = False
			' 
			' emptySpaceItem4
			' 
			Me.emptySpaceItem4.AllowHotTrack = False
			Me.emptySpaceItem4.Location = New System.Drawing.Point(0, 72)
			Me.emptySpaceItem4.MaxSize = New System.Drawing.Size(0, 20)
			Me.emptySpaceItem4.MinSize = New System.Drawing.Size(10, 20)
			Me.emptySpaceItem4.Name = "emptySpaceItem4"
			Me.emptySpaceItem4.Size = New System.Drawing.Size(355, 20)
			Me.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
			Me.emptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.lookUpEdit1
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(355, 24)
			Me.layoutControlItem1.Text = "Displayed Measure"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(90, 13)
			' 
			' layoutControlItem5
			' 
			Me.layoutControlItem5.Control = Me.textEdit2
			Me.layoutControlItem5.Location = New System.Drawing.Point(0, 48)
			Me.layoutControlItem5.Name = "layoutControlItem5"
			Me.layoutControlItem5.Size = New System.Drawing.Size(355, 24)
			Me.layoutControlItem5.Text = "Postfix"
			Me.layoutControlItem5.TextSize = New System.Drawing.Size(90, 13)
			' 
			' layoutControlItem4
			' 
			Me.layoutControlItem4.Control = Me.textEdit1
			Me.layoutControlItem4.Location = New System.Drawing.Point(0, 24)
			Me.layoutControlItem4.Name = "layoutControlItem4"
			Me.layoutControlItem4.Size = New System.Drawing.Size(355, 24)
			Me.layoutControlItem4.Text = "Prefix"
			Me.layoutControlItem4.TextSize = New System.Drawing.Size(90, 13)
			' 
			' PieTotalSettingsDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(399, 296)
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "PieTotalSettingsDialog"
			Me.Text = "Edit Total Settings"
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private Root As DevExpress.XtraLayout.LayoutControlGroup
		Private simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
		Private WithEvents textEdit2 As DevExpress.XtraEditors.TextEdit
		Private WithEvents textEdit1 As DevExpress.XtraEditors.TextEdit
		Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private memoEdit1 As DevExpress.XtraEditors.MemoEdit
		Private layoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
		Private WithEvents lookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private emptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
	End Class
End Namespace