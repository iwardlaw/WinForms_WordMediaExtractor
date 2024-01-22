namespace temp_iaw;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if(disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		tbxSrcDocName = new TextBox();
		btnBrowseSrcDoc = new Button();
		lblSrcDoc = new Label();
		lblOutputNamePrefix = new Label();
		cbxRenameOutput = new CheckBox();
		tbxOutputNamePrefix = new TextBox();
		gbxOutputRenaming = new GroupBox();
		gbxMediaTypes = new GroupBox();
		cbxMediaTypeJPG = new CheckBox();
		cbxMediaTypePNG = new CheckBox();
		diaOpenSrcDoc = new OpenFileDialog();
		btnExtractMedia = new Button();
		cbxSkipFirst = new CheckBox();
		cbxSaveDuplicates = new CheckBox();
		gbxOutputRenaming.SuspendLayout();
		gbxMediaTypes.SuspendLayout();
		SuspendLayout();
		// 
		// tbxSrcDocName
		// 
		tbxSrcDocName.Location = new Point(122, 12);
		tbxSrcDocName.Name = "tbxSrcDocName";
		tbxSrcDocName.Size = new Size(443, 23);
		tbxSrcDocName.TabIndex = 0;
		// 
		// btnBrowseSrcDoc
		// 
		btnBrowseSrcDoc.Location = new Point(574, 11);
		btnBrowseSrcDoc.Name = "btnBrowseSrcDoc";
		btnBrowseSrcDoc.Size = new Size(75, 23);
		btnBrowseSrcDoc.TabIndex = 1;
		btnBrowseSrcDoc.Text = "Browse";
		btnBrowseSrcDoc.UseVisualStyleBackColor = true;
		btnBrowseSrcDoc.Click += btnBrowseSrcDoc_Click;
		// 
		// lblSrcDoc
		// 
		lblSrcDoc.AutoSize = true;
		lblSrcDoc.Location = new Point(12, 15);
		lblSrcDoc.Name = "lblSrcDoc";
		lblSrcDoc.Size = new Size(104, 15);
		lblSrcDoc.TabIndex = 2;
		lblSrcDoc.Text = "Source document:";
		// 
		// lblOutputNamePrefix
		// 
		lblOutputNamePrefix.AutoSize = true;
		lblOutputNamePrefix.Location = new Point(164, 23);
		lblOutputNamePrefix.Name = "lblOutputNamePrefix";
		lblOutputNamePrefix.Size = new Size(75, 15);
		lblOutputNamePrefix.TabIndex = 3;
		lblOutputNamePrefix.Text = "Name prefix:";
		// 
		// cbxRenameOutput
		// 
		cbxRenameOutput.AutoSize = true;
		cbxRenameOutput.Checked = true;
		cbxRenameOutput.CheckState = CheckState.Checked;
		cbxRenameOutput.Location = new Point(6, 22);
		cbxRenameOutput.Name = "cbxRenameOutput";
		cbxRenameOutput.Size = new Size(132, 19);
		cbxRenameOutput.TabIndex = 4;
		cbxRenameOutput.Text = "Rename output files";
		cbxRenameOutput.UseVisualStyleBackColor = true;
		cbxRenameOutput.CheckedChanged += cbxRenameOutput_CheckedChanged;
		// 
		// tbxOutputNamePrefix
		// 
		tbxOutputNamePrefix.Location = new Point(245, 20);
		tbxOutputNamePrefix.Name = "tbxOutputNamePrefix";
		tbxOutputNamePrefix.Size = new Size(383, 23);
		tbxOutputNamePrefix.TabIndex = 5;
		tbxOutputNamePrefix.Text = "Image-";
		// 
		// gbxOutputRenaming
		// 
		gbxOutputRenaming.Controls.Add(tbxOutputNamePrefix);
		gbxOutputRenaming.Controls.Add(lblOutputNamePrefix);
		gbxOutputRenaming.Controls.Add(cbxRenameOutput);
		gbxOutputRenaming.Location = new Point(12, 41);
		gbxOutputRenaming.Name = "gbxOutputRenaming";
		gbxOutputRenaming.Size = new Size(637, 55);
		gbxOutputRenaming.TabIndex = 6;
		gbxOutputRenaming.TabStop = false;
		// 
		// gbxMediaTypes
		// 
		gbxMediaTypes.Controls.Add(cbxMediaTypeJPG);
		gbxMediaTypes.Controls.Add(cbxMediaTypePNG);
		gbxMediaTypes.Location = new Point(12, 105);
		gbxMediaTypes.Name = "gbxMediaTypes";
		gbxMediaTypes.Size = new Size(637, 52);
		gbxMediaTypes.TabIndex = 7;
		gbxMediaTypes.TabStop = false;
		gbxMediaTypes.Text = "Media Types to Extract";
		// 
		// cbxMediaTypeJPG
		// 
		cbxMediaTypeJPG.AutoSize = true;
		cbxMediaTypeJPG.Checked = true;
		cbxMediaTypeJPG.CheckState = CheckState.Checked;
		cbxMediaTypeJPG.Location = new Point(117, 22);
		cbxMediaTypeJPG.Name = "cbxMediaTypeJPG";
		cbxMediaTypeJPG.Size = new Size(131, 19);
		cbxMediaTypeJPG.TabIndex = 1;
		cbxMediaTypeJPG.Text = "JPG (.jpg, .jpeg, .jfif)";
		cbxMediaTypeJPG.UseVisualStyleBackColor = true;
		// 
		// cbxMediaTypePNG
		// 
		cbxMediaTypePNG.AutoSize = true;
		cbxMediaTypePNG.Checked = true;
		cbxMediaTypePNG.CheckState = CheckState.Checked;
		cbxMediaTypePNG.Location = new Point(6, 22);
		cbxMediaTypePNG.Name = "cbxMediaTypePNG";
		cbxMediaTypePNG.Size = new Size(85, 19);
		cbxMediaTypePNG.TabIndex = 0;
		cbxMediaTypePNG.Text = "PNG (.png)";
		cbxMediaTypePNG.UseVisualStyleBackColor = true;
		// 
		// diaOpenSrcDoc
		// 
		diaOpenSrcDoc.Filter = "Word Documents (.docx)|*.docx";
		// 
		// btnExtractMedia
		// 
		btnExtractMedia.Location = new Point(290, 204);
		btnExtractMedia.Name = "btnExtractMedia";
		btnExtractMedia.Size = new Size(96, 23);
		btnExtractMedia.TabIndex = 12;
		btnExtractMedia.Text = "Extract Media";
		btnExtractMedia.UseVisualStyleBackColor = true;
		btnExtractMedia.Click += btnExtractMedia_Click;
		// 
		// cbxSkipFirst
		// 
		cbxSkipFirst.AutoSize = true;
		cbxSkipFirst.Checked = true;
		cbxSkipFirst.CheckState = CheckState.Checked;
		cbxSkipFirst.Location = new Point(18, 169);
		cbxSkipFirst.Name = "cbxSkipFirst";
		cbxSkipFirst.Size = new Size(164, 19);
		cbxSkipFirst.TabIndex = 13;
		cbxSkipFirst.Text = "Skip first source media file";
		cbxSkipFirst.UseVisualStyleBackColor = true;
		// 
		// cbxSaveDuplicates
		// 
		cbxSaveDuplicates.AutoSize = true;
		cbxSaveDuplicates.Location = new Point(208, 169);
		cbxSaveDuplicates.Name = "cbxSaveDuplicates";
		cbxSaveDuplicates.Size = new Size(107, 19);
		cbxSaveDuplicates.TabIndex = 14;
		cbxSaveDuplicates.Text = "Save duplicates";
		cbxSaveDuplicates.UseVisualStyleBackColor = true;
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(660, 240);
		Controls.Add(cbxSaveDuplicates);
		Controls.Add(cbxSkipFirst);
		Controls.Add(btnExtractMedia);
		Controls.Add(gbxMediaTypes);
		Controls.Add(gbxOutputRenaming);
		Controls.Add(lblSrcDoc);
		Controls.Add(btnBrowseSrcDoc);
		Controls.Add(tbxSrcDocName);
		Name = "Form1";
		Text = "Windows Media Extractor";
		FormClosed += Form1_FormClosed;
		gbxOutputRenaming.ResumeLayout(false);
		gbxOutputRenaming.PerformLayout();
		gbxMediaTypes.ResumeLayout(false);
		gbxMediaTypes.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private TextBox tbxSrcDocName;
	private Button btnBrowseSrcDoc;
	private Label lblSrcDoc;
	private Label lblOutputNamePrefix;
	private CheckBox cbxRenameOutput;
	private TextBox tbxOutputNamePrefix;
	private GroupBox gbxOutputRenaming;
	private GroupBox gbxMediaTypes;
	private OpenFileDialog diaOpenSrcDoc;
	private CheckBox cbxMediaTypePNG;
	private Button btnExtractMedia;
	private CheckBox cbxMediaTypeJPG;
	private CheckBox cbxSkipFirst;
	private CheckBox cbxSaveDuplicates;
}
