using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml;
using temp_iaw.Properties;

namespace temp_iaw;

public partial class Form1 : Form
{
	private const string SrcDocPath = "word/document.xml";
	private const string SrcRelationsPath = "word/_rels/document.xml.rels";

	private const string TempDir = "temp";
	private const string TempDocPath = TempDir + "/document.xml";
	private const string TempRelationsPath = TempDir + "/relations.xml";

	private readonly Dictionary<string, string> relations = [];

	private string FileMatchPatternString
	{
		get
		{
			string ret = @"(?:\.";
			if(cbxMediaTypePNG.Checked) {
				ret += "png";
				if(cbxMediaTypeJPG.Checked) {
					ret += "|";
				}
			}
			if(cbxMediaTypeJPG.Checked) {
				ret += "j(?:pe?g|fif)";
			}
			ret += ")$";

			return ret;
		}
	}

	public Form1()
	{
		InitializeComponent();
		ApplySettings();
	}

	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		SaveSettings();
	}

	private void ApplySettings()
	{
		diaOpenSrcDoc.FileName = tbxSrcDocName.Text = Settings.Default.SourceDocument;
		tbxOutputNamePrefix.Text = Settings.Default.OutputFilePrefix;
		cbxRenameOutput.Checked = Settings.Default.RenameOutputFiles;
		cbxMediaTypePNG.Checked = Settings.Default.ExtractMedia_PNG;
		cbxMediaTypeJPG.Checked = Settings.Default.ExtractMedia_JPG;
		cbxSkipFirst.Checked = Settings.Default.SkipFirstSourceFile;
		cbxSaveDuplicates.Checked = Settings.Default.SaveDuplicates;
	}

	private void SaveSettings()
	{
		Settings.Default.SourceDocument = tbxSrcDocName.Text;
		Settings.Default.OutputFilePrefix = tbxOutputNamePrefix.Text;
		Settings.Default.RenameOutputFiles = cbxRenameOutput.Checked;
		Settings.Default.ExtractMedia_PNG = cbxMediaTypePNG.Checked;
		Settings.Default.ExtractMedia_JPG = cbxMediaTypeJPG.Checked;
		Settings.Default.SkipFirstSourceFile = cbxSkipFirst.Checked;
		Settings.Default.SaveDuplicates = cbxSaveDuplicates.Checked;

		Settings.Default.Save();
	}

	private void btnBrowseSrcDoc_Click(object sender, EventArgs e)
	{
		try {
			if(diaOpenSrcDoc.ShowDialog() == DialogResult.OK) {
				tbxSrcDocName.Text = diaOpenSrcDoc.FileName;
			}
		}
		catch(Exception ex) {
			ShowErrorPopup(ex.Message);
		}
	}

	private void btnExtractMedia_Click(object sender, EventArgs e)
	{
		if(!File.Exists(tbxSrcDocName.Text)) {
			ShowErrorPopup($"Source document '{tbxSrcDocName.Text}' does not exist.");
			return;
		}

		bool extractPNG = cbxMediaTypePNG.Checked;
		bool extractJPG = cbxMediaTypeJPG.Checked;
		if(!extractPNG && !extractJPG) {
			ShowErrorPopup("No media types selected.");
			return;
		}

		try {
			using(ZipArchive srcDoc = ZipFile.OpenRead(tbxSrcDocName.Text)) {
				CreateTempFiles(srcDoc);
				PopulateRelations();
				ExtractMedia(srcDoc);
			}
		}
		catch(Exception ex) {
			ShowErrorPopup(ex.Message);
		}
		finally {
			DeleteTempFiles();
			ClearCollections();
		}
	}

	private static void CreateTempFiles(ZipArchive srcDoc)
	{
		if(!Directory.Exists(TempDir)) { Directory.CreateDirectory(TempDir); }
		srcDoc.GetEntry(SrcDocPath).ExtractToFile(TempDocPath, overwrite: true);
		srcDoc.GetEntry(SrcRelationsPath).ExtractToFile(TempRelationsPath, overwrite: true);
	}

	private static void DeleteTempFiles()
	{
		if(File.Exists(TempDocPath)) { File.Delete(TempDocPath); }
		if(File.Exists(TempRelationsPath)) { File.Delete(TempRelationsPath); }
		if(Directory.Exists(TempDir)) { Directory.Delete(TempDir); }
	}

	private void PopulateRelations()
	{
		using(XmlReader reader = XmlReader.Create(TempRelationsPath)) {
			while(reader.Read()) {
				if(reader.IsEmptyElement && reader.Name == "Relationship") {
					string? id = reader.GetAttribute("Id");
					string? target = reader.GetAttribute("Target");
					if(id != null && target != null) {
						if(target.StartsWith('/')) {
							target = target[1..];
						}
						relations[id] = target;
					}
				}
			}
		}
	}

	private void ExtractMedia(ZipArchive srcDoc)
	{
		int dotIndex = tbxSrcDocName.Text.LastIndexOf('.');
		string outputDir = $"{Path.GetFullPath(tbxSrcDocName.Text)[..dotIndex]} Media/";
		if(!Directory.Exists(outputDir)) {
			Directory.CreateDirectory(outputDir);
		}
		else {
			string[] existingFileNames = Directory.GetFiles(outputDir);
			for(int i = 0; i < existingFileNames.Length; i++) {
				File.Delete(existingFileNames[i]);
			}
		}

		//System.Diagnostics.Debug.WriteLine($"Output dir = '{outputDir}'.");

		Regex fileMatchPattern = new(FileMatchPatternString, RegexOptions.IgnoreCase);
		int mediaNum = 1;
		bool mediaAlreadyFound = false;

		using(XmlReader reader = XmlReader.Create(TempDocPath)) {
			while(reader.Read()) {
				if(reader.IsStartElement() && reader.Name == "a:blip") {
					if(!mediaAlreadyFound && cbxSkipFirst.Checked) {
						mediaAlreadyFound = true;
						continue;
					}
					mediaAlreadyFound = true;
					string? id = reader.GetAttribute("r:embed");
					if(id != null && relations.TryGetValue(id, out string target)) {
						if(fileMatchPattern.IsMatch(target)) {
							string outputFileName = cbxRenameOutput.Checked
								? tbxOutputNamePrefix.Text + mediaNum + Path.GetExtension(target)
								: Path.GetFileName(target);
							//System.Diagnostics.Debug.WriteLine($"Copying '{target}' to '{outputDir + outputFileName}'.");
							srcDoc.GetEntry(target).ExtractToFile(outputDir + outputFileName, overwrite: true);
							mediaNum++;

							if(!cbxSaveDuplicates.Checked) {
								relations.Remove(id);
							}
						}
					}
				}
			}
		}

		int totalFiles = mediaNum - 1;
		MessageBox.Show($"{totalFiles} media files extracted to '{outputDir}'.", Text);
	}

	private void cbxRenameOutput_CheckedChanged(object sender, EventArgs e)
	{
		tbxOutputNamePrefix.Enabled = lblOutputNamePrefix.Enabled = cbxRenameOutput.Checked;
	}

	private void ClearCollections()
	{
		relations.Clear();
	}

	private void ShowErrorPopup(string msg) => MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

	private void ShowErrorPopup(string msg, string stackTrace) => ShowErrorPopup(msg + Environment.NewLine + Environment.NewLine + stackTrace);
}
