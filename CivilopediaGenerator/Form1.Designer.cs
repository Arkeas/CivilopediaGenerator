namespace CivilopediaGenerator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdGenerate = new System.Windows.Forms.Button();
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.chkGameConcepts = new System.Windows.Forms.CheckBox();
			this.chkTechnologies = new System.Windows.Forms.CheckBox();
			this.chkUnits = new System.Windows.Forms.CheckBox();
			this.chkPromotions = new System.Windows.Forms.CheckBox();
			this.chkBuildings = new System.Windows.Forms.CheckBox();
			this.chkWonders = new System.Windows.Forms.CheckBox();
			this.chkPolicies = new System.Windows.Forms.CheckBox();
			this.chkGreatPeople = new System.Windows.Forms.CheckBox();
			this.chkCivilizations = new System.Windows.Forms.CheckBox();
			this.chkCityStates = new System.Windows.Forms.CheckBox();
			this.chkTerrains = new System.Windows.Forms.CheckBox();
			this.chkResources = new System.Windows.Forms.CheckBox();
			this.chkImprovements = new System.Windows.Forms.CheckBox();
			this.cmdSelectAll = new System.Windows.Forms.Button();
			this.chkHome = new System.Windows.Forms.CheckBox();
			this.chkEnglish = new System.Windows.Forms.CheckBox();
			this.chkGerman = new System.Windows.Forms.CheckBox();
			this.chkFrench = new System.Windows.Forms.CheckBox();
			this.chkItalian = new System.Windows.Forms.CheckBox();
			this.chkKorean = new System.Windows.Forms.CheckBox();
			this.chkPolish = new System.Windows.Forms.CheckBox();
			this.chkSpanish = new System.Windows.Forms.CheckBox();
			this.chkJapanese = new System.Windows.Forms.CheckBox();
			this.chkRussian = new System.Windows.Forms.CheckBox();
			this.chkReligions = new System.Windows.Forms.CheckBox();
			this.chkResolutions = new System.Windows.Forms.CheckBox();
			this.chkChinese = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cmdGenerate
			// 
			this.cmdGenerate.Location = new System.Drawing.Point(12, 12);
			this.cmdGenerate.Name = "cmdGenerate";
			this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
			this.cmdGenerate.TabIndex = 0;
			this.cmdGenerate.Text = "Generate!";
			this.cmdGenerate.UseVisualStyleBackColor = true;
			this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			// 
			// txtDebug
			// 
			this.txtDebug.Location = new System.Drawing.Point(12, 122);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.ReadOnly = true;
			this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDebug.Size = new System.Drawing.Size(980, 493);
			this.txtDebug.TabIndex = 1;
			// 
			// chkGameConcepts
			// 
			this.chkGameConcepts.AutoSize = true;
			this.chkGameConcepts.Location = new System.Drawing.Point(12, 76);
			this.chkGameConcepts.Name = "chkGameConcepts";
			this.chkGameConcepts.Size = new System.Drawing.Size(102, 17);
			this.chkGameConcepts.TabIndex = 2;
			this.chkGameConcepts.Text = "Game Concepts";
			this.chkGameConcepts.UseVisualStyleBackColor = true;
			// 
			// chkTechnologies
			// 
			this.chkTechnologies.AutoSize = true;
			this.chkTechnologies.Location = new System.Drawing.Point(12, 99);
			this.chkTechnologies.Name = "chkTechnologies";
			this.chkTechnologies.Size = new System.Drawing.Size(90, 17);
			this.chkTechnologies.TabIndex = 3;
			this.chkTechnologies.Text = "Technologies";
			this.chkTechnologies.UseVisualStyleBackColor = true;
			// 
			// chkUnits
			// 
			this.chkUnits.AutoSize = true;
			this.chkUnits.Location = new System.Drawing.Point(120, 53);
			this.chkUnits.Name = "chkUnits";
			this.chkUnits.Size = new System.Drawing.Size(50, 17);
			this.chkUnits.TabIndex = 4;
			this.chkUnits.Text = "Units";
			this.chkUnits.UseVisualStyleBackColor = true;
			// 
			// chkPromotions
			// 
			this.chkPromotions.AutoSize = true;
			this.chkPromotions.Location = new System.Drawing.Point(120, 76);
			this.chkPromotions.Name = "chkPromotions";
			this.chkPromotions.Size = new System.Drawing.Size(78, 17);
			this.chkPromotions.TabIndex = 5;
			this.chkPromotions.Text = "Promotions";
			this.chkPromotions.UseVisualStyleBackColor = true;
			// 
			// chkBuildings
			// 
			this.chkBuildings.AutoSize = true;
			this.chkBuildings.Location = new System.Drawing.Point(120, 99);
			this.chkBuildings.Name = "chkBuildings";
			this.chkBuildings.Size = new System.Drawing.Size(68, 17);
			this.chkBuildings.TabIndex = 6;
			this.chkBuildings.Text = "Buildings";
			this.chkBuildings.UseVisualStyleBackColor = true;
			// 
			// chkWonders
			// 
			this.chkWonders.AutoSize = true;
			this.chkWonders.Location = new System.Drawing.Point(204, 53);
			this.chkWonders.Name = "chkWonders";
			this.chkWonders.Size = new System.Drawing.Size(69, 17);
			this.chkWonders.TabIndex = 7;
			this.chkWonders.Text = "Wonders";
			this.chkWonders.UseVisualStyleBackColor = true;
			// 
			// chkPolicies
			// 
			this.chkPolicies.AutoSize = true;
			this.chkPolicies.Location = new System.Drawing.Point(204, 76);
			this.chkPolicies.Name = "chkPolicies";
			this.chkPolicies.Size = new System.Drawing.Size(62, 17);
			this.chkPolicies.TabIndex = 8;
			this.chkPolicies.Text = "Policies";
			this.chkPolicies.UseVisualStyleBackColor = true;
			// 
			// chkGreatPeople
			// 
			this.chkGreatPeople.AutoSize = true;
			this.chkGreatPeople.Location = new System.Drawing.Point(204, 99);
			this.chkGreatPeople.Name = "chkGreatPeople";
			this.chkGreatPeople.Size = new System.Drawing.Size(88, 17);
			this.chkGreatPeople.TabIndex = 9;
			this.chkGreatPeople.Text = "Great People";
			this.chkGreatPeople.UseVisualStyleBackColor = true;
			// 
			// chkCivilizations
			// 
			this.chkCivilizations.AutoSize = true;
			this.chkCivilizations.Location = new System.Drawing.Point(298, 53);
			this.chkCivilizations.Name = "chkCivilizations";
			this.chkCivilizations.Size = new System.Drawing.Size(89, 17);
			this.chkCivilizations.TabIndex = 10;
			this.chkCivilizations.Text = "Civs/Leaders";
			this.chkCivilizations.UseVisualStyleBackColor = true;
			// 
			// chkCityStates
			// 
			this.chkCityStates.AutoSize = true;
			this.chkCityStates.Location = new System.Drawing.Point(298, 76);
			this.chkCityStates.Name = "chkCityStates";
			this.chkCityStates.Size = new System.Drawing.Size(76, 17);
			this.chkCityStates.TabIndex = 11;
			this.chkCityStates.Text = "City-States";
			this.chkCityStates.UseVisualStyleBackColor = true;
			// 
			// chkTerrains
			// 
			this.chkTerrains.AutoSize = true;
			this.chkTerrains.Location = new System.Drawing.Point(298, 99);
			this.chkTerrains.Name = "chkTerrains";
			this.chkTerrains.Size = new System.Drawing.Size(105, 17);
			this.chkTerrains.TabIndex = 12;
			this.chkTerrains.Text = "Terrain/Features";
			this.chkTerrains.UseVisualStyleBackColor = true;
			// 
			// chkResources
			// 
			this.chkResources.AutoSize = true;
			this.chkResources.Location = new System.Drawing.Point(409, 53);
			this.chkResources.Name = "chkResources";
			this.chkResources.Size = new System.Drawing.Size(77, 17);
			this.chkResources.TabIndex = 13;
			this.chkResources.Text = "Resources";
			this.chkResources.UseVisualStyleBackColor = true;
			// 
			// chkImprovements
			// 
			this.chkImprovements.AutoSize = true;
			this.chkImprovements.Location = new System.Drawing.Point(409, 76);
			this.chkImprovements.Name = "chkImprovements";
			this.chkImprovements.Size = new System.Drawing.Size(92, 17);
			this.chkImprovements.TabIndex = 14;
			this.chkImprovements.Text = "Improvements";
			this.chkImprovements.UseVisualStyleBackColor = true;
			// 
			// cmdSelectAll
			// 
			this.cmdSelectAll.Location = new System.Drawing.Point(641, 53);
			this.cmdSelectAll.Name = "cmdSelectAll";
			this.cmdSelectAll.Size = new System.Drawing.Size(75, 23);
			this.cmdSelectAll.TabIndex = 15;
			this.cmdSelectAll.Text = "Select All";
			this.cmdSelectAll.UseVisualStyleBackColor = true;
			this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
			// 
			// chkHome
			// 
			this.chkHome.AutoSize = true;
			this.chkHome.Location = new System.Drawing.Point(12, 53);
			this.chkHome.Name = "chkHome";
			this.chkHome.Size = new System.Drawing.Size(82, 17);
			this.chkHome.TabIndex = 16;
			this.chkHome.Text = "Home Page";
			this.chkHome.UseVisualStyleBackColor = true;
			// 
			// chkEnglish
			// 
			this.chkEnglish.AutoSize = true;
			this.chkEnglish.Checked = true;
			this.chkEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnglish.Location = new System.Drawing.Point(766, 53);
			this.chkEnglish.Name = "chkEnglish";
			this.chkEnglish.Size = new System.Drawing.Size(60, 17);
			this.chkEnglish.TabIndex = 17;
			this.chkEnglish.Text = "English";
			this.chkEnglish.UseVisualStyleBackColor = true;
			// 
			// chkGerman
			// 
			this.chkGerman.AutoSize = true;
			this.chkGerman.Location = new System.Drawing.Point(766, 76);
			this.chkGerman.Name = "chkGerman";
			this.chkGerman.Size = new System.Drawing.Size(63, 17);
			this.chkGerman.TabIndex = 18;
			this.chkGerman.Text = "German";
			this.chkGerman.UseVisualStyleBackColor = true;
			// 
			// chkFrench
			// 
			this.chkFrench.AutoSize = true;
			this.chkFrench.Location = new System.Drawing.Point(836, 53);
			this.chkFrench.Name = "chkFrench";
			this.chkFrench.Size = new System.Drawing.Size(59, 17);
			this.chkFrench.TabIndex = 19;
			this.chkFrench.Text = "French";
			this.chkFrench.UseVisualStyleBackColor = true;
			// 
			// chkItalian
			// 
			this.chkItalian.AutoSize = true;
			this.chkItalian.Location = new System.Drawing.Point(836, 76);
			this.chkItalian.Name = "chkItalian";
			this.chkItalian.Size = new System.Drawing.Size(54, 17);
			this.chkItalian.TabIndex = 20;
			this.chkItalian.Text = "Italian";
			this.chkItalian.UseVisualStyleBackColor = true;
			// 
			// chkKorean
			// 
			this.chkKorean.AutoSize = true;
			this.chkKorean.Location = new System.Drawing.Point(914, 53);
			this.chkKorean.Name = "chkKorean";
			this.chkKorean.Size = new System.Drawing.Size(60, 17);
			this.chkKorean.TabIndex = 21;
			this.chkKorean.Text = "Korean";
			this.chkKorean.UseVisualStyleBackColor = true;
			// 
			// chkPolish
			// 
			this.chkPolish.AutoSize = true;
			this.chkPolish.Location = new System.Drawing.Point(914, 76);
			this.chkPolish.Name = "chkPolish";
			this.chkPolish.Size = new System.Drawing.Size(54, 17);
			this.chkPolish.TabIndex = 22;
			this.chkPolish.Text = "Polish";
			this.chkPolish.UseVisualStyleBackColor = true;
			// 
			// chkSpanish
			// 
			this.chkSpanish.AutoSize = true;
			this.chkSpanish.Location = new System.Drawing.Point(766, 99);
			this.chkSpanish.Name = "chkSpanish";
			this.chkSpanish.Size = new System.Drawing.Size(64, 17);
			this.chkSpanish.TabIndex = 23;
			this.chkSpanish.Text = "Spanish";
			this.chkSpanish.UseVisualStyleBackColor = true;
			// 
			// chkJapanese
			// 
			this.chkJapanese.AutoSize = true;
			this.chkJapanese.Location = new System.Drawing.Point(836, 99);
			this.chkJapanese.Name = "chkJapanese";
			this.chkJapanese.Size = new System.Drawing.Size(72, 17);
			this.chkJapanese.TabIndex = 24;
			this.chkJapanese.Text = "Japanese";
			this.chkJapanese.UseVisualStyleBackColor = true;
			// 
			// chkRussian
			// 
			this.chkRussian.AutoSize = true;
			this.chkRussian.Location = new System.Drawing.Point(914, 99);
			this.chkRussian.Name = "chkRussian";
			this.chkRussian.Size = new System.Drawing.Size(64, 17);
			this.chkRussian.TabIndex = 25;
			this.chkRussian.Text = "Russian";
			this.chkRussian.UseVisualStyleBackColor = true;
			// 
			// chkReligions
			// 
			this.chkReligions.AutoSize = true;
			this.chkReligions.Location = new System.Drawing.Point(409, 99);
			this.chkReligions.Name = "chkReligions";
			this.chkReligions.Size = new System.Drawing.Size(69, 17);
			this.chkReligions.TabIndex = 26;
			this.chkReligions.Text = "Religions";
			this.chkReligions.UseVisualStyleBackColor = true;
			// 
			// chkResolutions
			// 
			this.chkResolutions.AutoSize = true;
			this.chkResolutions.Location = new System.Drawing.Point(507, 53);
			this.chkResolutions.Name = "chkResolutions";
			this.chkResolutions.Size = new System.Drawing.Size(81, 17);
			this.chkResolutions.TabIndex = 27;
			this.chkResolutions.Text = "Resolutions";
			this.chkResolutions.UseVisualStyleBackColor = true;
			// 
			// chkChinese
			// 
			this.chkChinese.AutoSize = true;
			this.chkChinese.Location = new System.Drawing.Point(696, 99);
			this.chkChinese.Name = "chkChinese";
			this.chkChinese.Size = new System.Drawing.Size(64, 17);
			this.chkChinese.TabIndex = 28;
			this.chkChinese.Text = "Chinese";
			this.chkChinese.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1003, 627);
			this.Controls.Add(this.chkChinese);
			this.Controls.Add(this.chkResolutions);
			this.Controls.Add(this.chkReligions);
			this.Controls.Add(this.chkRussian);
			this.Controls.Add(this.chkJapanese);
			this.Controls.Add(this.chkSpanish);
			this.Controls.Add(this.chkPolish);
			this.Controls.Add(this.chkKorean);
			this.Controls.Add(this.chkItalian);
			this.Controls.Add(this.chkFrench);
			this.Controls.Add(this.chkGerman);
			this.Controls.Add(this.chkEnglish);
			this.Controls.Add(this.chkHome);
			this.Controls.Add(this.cmdSelectAll);
			this.Controls.Add(this.chkImprovements);
			this.Controls.Add(this.chkResources);
			this.Controls.Add(this.chkTerrains);
			this.Controls.Add(this.chkCityStates);
			this.Controls.Add(this.chkCivilizations);
			this.Controls.Add(this.chkGreatPeople);
			this.Controls.Add(this.chkPolicies);
			this.Controls.Add(this.chkWonders);
			this.Controls.Add(this.chkBuildings);
			this.Controls.Add(this.chkPromotions);
			this.Controls.Add(this.chkUnits);
			this.Controls.Add(this.chkTechnologies);
			this.Controls.Add(this.chkGameConcepts);
			this.Controls.Add(this.txtDebug);
			this.Controls.Add(this.cmdGenerate);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdGenerate;
		private System.Windows.Forms.TextBox txtDebug;
		private System.Windows.Forms.CheckBox chkGameConcepts;
		private System.Windows.Forms.CheckBox chkTechnologies;
		private System.Windows.Forms.CheckBox chkUnits;
		private System.Windows.Forms.CheckBox chkPromotions;
		private System.Windows.Forms.CheckBox chkBuildings;
		private System.Windows.Forms.CheckBox chkWonders;
		private System.Windows.Forms.CheckBox chkPolicies;
		private System.Windows.Forms.CheckBox chkGreatPeople;
		private System.Windows.Forms.CheckBox chkCivilizations;
		private System.Windows.Forms.CheckBox chkCityStates;
		private System.Windows.Forms.CheckBox chkTerrains;
		private System.Windows.Forms.CheckBox chkResources;
		private System.Windows.Forms.CheckBox chkImprovements;
		private System.Windows.Forms.Button cmdSelectAll;
		private System.Windows.Forms.CheckBox chkHome;
		private System.Windows.Forms.CheckBox chkEnglish;
		private System.Windows.Forms.CheckBox chkGerman;
		private System.Windows.Forms.CheckBox chkFrench;
		private System.Windows.Forms.CheckBox chkItalian;
		private System.Windows.Forms.CheckBox chkKorean;
		private System.Windows.Forms.CheckBox chkPolish;
		private System.Windows.Forms.CheckBox chkSpanish;
		private System.Windows.Forms.CheckBox chkJapanese;
		private System.Windows.Forms.CheckBox chkRussian;
		private System.Windows.Forms.CheckBox chkReligions;
		private System.Windows.Forms.CheckBox chkResolutions;
		private System.Windows.Forms.CheckBox chkChinese;
	}
}

