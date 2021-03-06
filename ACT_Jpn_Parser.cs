using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;

[assembly: AssemblyTitle("Japanese Parsing Engine")]
[assembly: AssemblyDescription("Plugin based parsing Japanese EQ2 Sebillis server running the Japanese client")]
[assembly: AssemblyCompany("Gardin of Sebillis and Tzalik of Sebiris")]
[assembly: AssemblyVersion("1.0.1.3")]

// TODO
// ・未対応のオプション対応（複数属性攻撃とマークコマンド）
// ・ペットのダメージ
// ・説明文の日本語化
///////////////////////////////////////////////////////////
// $Date: 2012-12-12 00:08:36 +0900 (水, 12 12 2012) $
// $Rev: 12 $
///////////////////////////////////////////////////////////
namespace ACT_Plugin
{
	public class ACT_Jpn_Parser : UserControl, IActPluginV1
	{
		#region Designer generated code (Avoid editing)
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbMultiDamageIsOne = new System.Windows.Forms.CheckBox();
			this.cbRecalcWardedHits = new System.Windows.Forms.CheckBox();
			this.cbKatakana = new System.Windows.Forms.CheckBox();
			this.cbSParseConsider = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbMultiDamageIsOne
			// 
			this.cbMultiDamageIsOne.AutoSize = true;
			this.cbMultiDamageIsOne.Checked = true;
			this.cbMultiDamageIsOne.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMultiDamageIsOne.Location = new System.Drawing.Point(13, 14);
			this.cbMultiDamageIsOne.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbMultiDamageIsOne.Name = "cbMultiDamageIsOne";
			this.cbMultiDamageIsOne.Size = new System.Drawing.Size(362, 17);
			this.cbMultiDamageIsOne.TabIndex = 5;
			this.cbMultiDamageIsOne.Text = "（※未対応です）複数属性ダメージを1回攻撃として記録する。(既に読み込んだデータには反映しません)";
			this.cbMultiDamageIsOne.MouseHover += new System.EventHandler(this.cbMultiDamageIsOne_MouseHover);
			// 
			// cbRecalcWardedHits
			// 
			this.cbRecalcWardedHits.AutoSize = true;
			this.cbRecalcWardedHits.Checked = true;
			this.cbRecalcWardedHits.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRecalcWardedHits.Location = new System.Drawing.Point(13, 52);
			this.cbRecalcWardedHits.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbRecalcWardedHits.Name = "cbRecalcWardedHits";
			this.cbRecalcWardedHits.Size = new System.Drawing.Size(310, 17);
			this.cbRecalcWardedHits.TabIndex = 7;
			this.cbRecalcWardedHits.Text = "Ward で受けた値を本来の値で再計算する。(既に読み込んだデータには反映しません)";
			this.cbRecalcWardedHits.MouseHover += new System.EventHandler(this.cbRecalcWardedHits_MouseHover);
			// 
			// cbKatakana
			// 
			this.cbKatakana.AutoSize = true;
			this.cbKatakana.Checked = true;
			this.cbKatakana.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbKatakana.Location = new System.Drawing.Point(13, 33);
			this.cbKatakana.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbKatakana.Name = "cbKatakana";
			this.cbKatakana.Size = new System.Drawing.Size(403, 17);
			this.cbKatakana.TabIndex = 9;
			this.cbKatakana.Text = "表記を日本語にする。(既に読み込んだデータには反映しません)";
			this.cbKatakana.MouseHover += new System.EventHandler(this.cbKatakana_MouseHover);
			// 
			// cbSParseConsider
			// 
			this.cbSParseConsider.AutoSize = true;
			this.cbSParseConsider.Checked = true;
			this.cbSParseConsider.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSParseConsider.Location = new System.Drawing.Point(13, 71);
			this.cbSParseConsider.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.cbSParseConsider.Name = "cbSParseConsider";
			this.cbSParseConsider.Size = new System.Drawing.Size(479, 17);
			this.cbSParseConsider.TabIndex = 7;
			this.cbSParseConsider.Text = "（※未対応です）選択した一覧に /con, /whogroup, /whoraid コマンドでマークしたキャラクタを追加する。";
			this.cbSParseConsider.MouseHover += new System.EventHandler(this.cbSParseConsider_MouseHover);
			// 
			// ACT_EnJp_Parser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.cbKatakana);
			this.Controls.Add(this.cbMultiDamageIsOne);
			this.Controls.Add(this.cbSParseConsider);
			this.Controls.Add(this.cbRecalcWardedHits);
			this.Name = "ACT_Jpn_Parser";
			this.Size = new System.Drawing.Size(495, 89);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		#endregion
		public ACT_Jpn_Parser()
		{
			InitializeComponent();
		}

		Label lblStatus;	// The status label that appears in ACT's Plugin tab
		string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_Jpn_Parser.config.xml");
		private CheckBox cbMultiDamageIsOne;
		private CheckBox cbRecalcWardedHits;
		private CheckBox cbKatakana;
		SettingsSerializer xmlSettings;
		private CheckBox cbSParseConsider;
		TreeNode optionsNode = null;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;	// Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);
            this.Dock = DockStyle.Fill;

			int dcIndex = -1;   // Find the Data Correction node in the Options tab
			for (int i = 0; i < ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count; i++)
			{
				if (ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Text == "Data Correction")
					dcIndex = i;
			}
			if (dcIndex != -1)
			{
				// Add our own node to the Data Correction node
				optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add("EQ2 English Settings");
				// Register our user control(this) to our newly create node path.  All controls added to the list will be laid out left to right, top to bottom
				ActGlobals.oFormActMain.OptionsControlSets.Add(@"Data Correction\EQ2 English Settings", new List<Control> { this });
				Label lblConfig = new Label();
				lblConfig.AutoSize = true;
				lblConfig.Text = "Option タブの Data Correction セクションの EQ2 English Settings にてオプション設定ができます。";
				pluginScreenSpace.Controls.Add(lblConfig);
			}

            xmlSettings = new SettingsSerializer(this);	// Create a new settings serializer and pass it this instance
			LoadSettings();

			PopulateRegexArray();
			ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(oFormActMain_BeforeLogLineRead);
			ActGlobals.oFormActMain.BeforeCombatAction += new CombatActionDelegate(oFormActMain_BeforeCombatAction);
			ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(oFormActMain_AfterCombatAction);
			ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(oFormActMain_OnLogLineRead);
			lblStatus.Text = "Plugin は有効です。";
		}

		public void DeInitPlugin()
		{
			ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
			ActGlobals.oFormActMain.BeforeCombatAction -= oFormActMain_BeforeCombatAction;
			ActGlobals.oFormActMain.AfterCombatAction -= oFormActMain_AfterCombatAction;
			ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;

			if (optionsNode != null)    // If we added our user control to the Options tab, remove it
			{
				optionsNode.Remove();
				ActGlobals.oFormActMain.OptionsControlSets.Remove(@"Data Correction\EQ2 English Settings");
			}

			SaveSettings();
			lblStatus.Text = "Plugin は無効です。";	
		}
		/*
		void oFormActMain_UpdateCheckClicked()
		{
			int pluginId = 55;
			try
			{
				DateTime localDate = ActGlobals.oFormActMain.PluginGetSelfDateUtc(this);
				DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc(pluginId);
				if (localDate.AddHours(2) < remoteDate)
				{
					DialogResult result = MessageBox.Show("There is an updated version of the EQ2 Japanese Parsing Plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)", "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
					{
						FileInfo updatedFile = ActGlobals.oFormActMain.PluginDownload(pluginId);
						ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);
						pluginData.pluginFile.Delete();
						updatedFile.MoveTo(pluginData.pluginFile.FullName);
						ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, false);
						Application.DoEvents();
						ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, true);
					}
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Plugin Update Check");
			}
		}
		*/

		#region Parsing
		Regex[] regexArray;
		const string logTimeStampRegexStr = @"\(\d{10}\)\[.{24}\] ";
		DateTime lastWardTime = DateTime.MinValue;
		int lastWardAmount = 0;
		string lastWardedTarget = string.Empty;
		Regex petSplit = new Regex(@"(?<petName>\w* ?)<(?<attacker>\w+)['의の](?<s>s?) (?<petClass>.+)>", RegexOptions.Compiled);
		Regex engKillSplit = new Regex("(?<mob>.+?) in .+", RegexOptions.Compiled);
		Regex romanjiSplit = new Regex(@"\\r[iapsm]:(?<katakana>.+?)\\:(?<romanji>.+)\\/r", RegexOptions.Compiled);
		Regex regexConsider = new Regex(logTimeStampRegexStr + @".+?You consider (?<player>.+?)\.\.\. .+", RegexOptions.Compiled);
		Regex regexWhogroup = new Regex(logTimeStampRegexStr + @"(?<name>[^ ]+) Lvl \d+ .+", RegexOptions.Compiled);
		Regex regexWhoraid = new Regex(logTimeStampRegexStr + @"\[\d+ [^\]]+\] (?<name>[^ ]+) \([^\)]+\)", RegexOptions.Compiled);
		CombatActionEventArgs lastDamage = null;

		private void PopulateRegexArray()
		{
			regexArray = new Regex[20];
			regexArray[0]  = new Regex(logTimeStampRegexStr + @"(?<victim>.+?)が(?<skillType>.+?)による攻撃を受け、(?<damageAndType>\d+ポイントの.+?)ダメージを負った。(?:\((?<special>.+?)\))?", RegexOptions.Compiled);
			regexArray[1]  = new Regex(logTimeStampRegexStr + @"(?<attacker>あなた)は(?<victim>.+?)に(?<damageAndType>.+?)ダメージを負わせた。(?:\((?<special>.+?)\))?", RegexOptions.Compiled);
			regexArray[2]  = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)の{1,2}(?<skill>.+?)により、(?<victim>.+?)(?:が|は)(?<damageAndType>\d+(?:ポイントの|\s+).+?)ダメージを受け(?:た|ました)。(?:\((?<special>.+)\))?", RegexOptions.Compiled);
            regexArray[3]  = new Regex(logTimeStampRegexStr + @"(?<healer>.+?)\s*(?:が|は)\s*、?(?:自分を)?(?<skill>.+?)\s*によって(?<victim>.+?)(?:\s*を)?\s*(?<damage>\d+) ヒットポイント 回復させ(?:まし)?た。", RegexOptions.Compiled);
			regexArray[4]  = new Regex(logTimeStampRegexStr + @"(?:(?<healer>.+?|あなた))(?:の|が|は){1}(?<skill>.+?)によって、(?<victim>.+?)を(?<damage>\d+)ヒットポイントクリティカル・ヒールさせました。", RegexOptions.Compiled);
            regexArray[5]  = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)(?:が|は\s)(?<victim>.+?)を(?<skill>.+?で攻撃|攻撃)(?:。はずした|(?:しましたが|しようとしましたが)、失敗しました)。(?:\((?<special>.+?)\))?", RegexOptions.Compiled);
            regexArray[6]  = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)(?:が|は)(?<victim>.+?)を攻撃(?:。|しましたが、)(?<why>.+?)(?:がうまく妨害|によって妨げられま|はうまくかわしま)した。(?:（.*(?<special>ブロック|反撃|回避|受け流し|レジスト|反射).*）)?", RegexOptions.Compiled);
            regexArray[7]  = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)(?:が|は){1}(?<victim>.+?)を(?<skill>.+?)で攻撃(?:しましたが、|。)(?<why>.+?)(?:がうまく妨害|によって妨げられま|はうまくかわしま)した。(?:（.*(?<special>ブロック|反撃|回避|受け流し|レジスト|反射).*）)?", RegexOptions.Compiled);
			regexArray[8]  = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)は(?<zone>.+?) \((?<xpos>.+?),(?<zpos>.+?),(?<ypos>.+?)\) で(?<victim>.+?)を倒した。", RegexOptions.Compiled);
			regexArray[9]  = new Regex(logTimeStampRegexStr + @"(?<victim>.+?)が(?<attacker>.+?)に殺された……。", RegexOptions.Compiled);
			regexArray[10] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)に殺された……。", RegexOptions.Compiled);
			regexArray[11] = new Regex(logTimeStampRegexStr + @"Unknown command: 'act (.+)'", RegexOptions.Compiled);
			regexArray[12] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?)の{1,2}(?<skill>.+?)が(?<victim>.+?)を攻撃し、(?<damage>\d+)ポイントパワーを消耗(?:させ|し)た。(?:\((?<special>.+?)\))?", RegexOptions.Compiled);
			regexArray[13] = new Regex(logTimeStampRegexStr + @"(?<victim>.+)に対する(?<damage>\d+) ポイントダメージを(?<attacker>あなた|.+?)の ?(?<skillType>.+?)が吸収した。", RegexOptions.Compiled);
			regexArray[14] = new Regex(logTimeStampRegexStr + @"(?<skill>.+)は(?<damage>\d+) ポイントのダメージを吸収し、(?<victim>.+?)へのダメージを防いだ(?:。)?", RegexOptions.Compiled);
			regexArray[15] = new Regex(logTimeStampRegexStr + @"You have entered (?<zone>.+?)\.", RegexOptions.Compiled);
            regexArray[16] = new Regex(logTimeStampRegexStr + @"(?<healer>.+?)\s*が\s*(?<skill>.+?)\s*によって(?: |、)(?<victim>.+?)を\s*(?<damage>\d+)\s*マナポイント(?<special>クリティカル)?・?\s*リフレッシュ(?:させ|しまし)た。", RegexOptions.Compiled);
            regexArray[17] = new Regex(logTimeStampRegexStr + @"(?<healer>あなた)は(?<skill>.+?)\s*で(?:、自分を)?\s*(?<damage>\d+)\s*マナポイント(?<special>クリティカル・)?\s*リフレッシュ(?:させました|しました)。", RegexOptions.Compiled);
            regexArray[18] = new Regex(logTimeStampRegexStr + @"(?<owner>.+?|あなた)の\s*(?<skillType>.+?)(?:が、|は)(?<victim>.+?)に対する(?<target>.*)のヘイト(?:順位)?を (?<damage>\d+)\s(?<dirType>ヘイト|脅威レベル|position)\s+(?<crit>大幅に)?(?<direction>増加|減少)。", RegexOptions.Compiled);
			regexArray[19] = new Regex(logTimeStampRegexStr + @"(?<attacker>.+?|あなた)の(?<skillType>.+?)が (?:(?<victim>.+?|あなた))の(?<affliction>.+?)を(?<action>ディスペル|治療)しました。", RegexOptions.Compiled);
		}
		void oFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			for (int i = 0; i < regexArray.Length; i++)
			{
				if (regexArray[i].IsMatch(logInfo.logLine))
				{
					switch (i)
					{
						case 0:
						case 1:
						case 2:
							logInfo.detectedType = Color.Red.ToArgb();
							break;
						case 3:
						case 4:
							logInfo.detectedType = Color.Blue.ToArgb();
							break;
						case 5:
						case 6:
						case 7:
							logInfo.detectedType = Color.DarkRed.ToArgb();
							break;
						case 12:
							logInfo.detectedType = Color.DarkOrchid.ToArgb();
							break;
						case 13:
						case 14:
							logInfo.detectedType = Color.DodgerBlue.ToArgb();
							break;
						default:
							logInfo.detectedType = Color.Black.ToArgb();
							break;
					}
					LogExeJpn(i + 1, logInfo.logLine, isImport);
					break;
				}
			}
		}
		void oFormActMain_BeforeCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			// Riposte/kontert/
			if (lastDamage != null && lastDamage.time == actionInfo.time)
			{
				if ((int)lastDamage.damage == (int)Dnum.Unknown && lastDamage.damage.DamageString.Contains("反撃"))
				{
					if (actionInfo.swingType == (int)SwingTypeEnum.Melee && actionInfo.victim == lastDamage.attacker)
					{
						actionInfo.special = "反撃";
						lastDamage.damage.DamageString2 = String.Format("({0} returned)", actionInfo.damage.ToString());
					}
				}
				if ((int)actionInfo.damage == (int)Dnum.Unknown && actionInfo.damage.DamageString.Contains("reflect"))
				{
					if (actionInfo.theAttackType == lastDamage.theAttackType && actionInfo.victim == lastDamage.attacker)
					{
						//lastDamage.special = "reflect";  // Too late to take effect
						actionInfo.damage.DamageString2 = String.Format(" ({0} returned)", lastDamage.damage.ToString());
					}
				}
			}
		}
		void oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
		{
			if (actionInfo.swingType == (int)SwingTypeEnum.Melee || actionInfo.swingType == (int)SwingTypeEnum.NonMelee)
				lastDamage = actionInfo;
		}
		bool captureWhoraid = false;
		void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			if (cbSParseConsider.Checked)
			{
				if (logInfo.logLine.Contains("/whoraid search results"))
					captureWhoraid = true;
				if (logInfo.logLine.EndsWith("players found"))
					captureWhoraid = false;
				if (captureWhoraid && regexWhoraid.IsMatch(logInfo.logLine))
				{
					string outputName = regexWhoraid.Replace(logInfo.logLine, "$1");
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
				}
				if (regexWhogroup.IsMatch(logInfo.logLine))
				{
					string outputName = regexWhogroup.Replace(logInfo.logLine, "$1");
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
				}
				if (regexConsider.IsMatch(logInfo.logLine))
				{
					string outputName = regexConsider.Replace(logInfo.logLine, "$1");
					if (outputName.StartsWith("{f}"))
						outputName = outputName.Substring(3);
					ActGlobals.oFormActMain.SelectiveListAdd(outputName);
					if (!isImport)
						System.Media.SystemSounds.Beep.Play();
				}
			}
		}
		
		private void LogExeJpn(int logMatched, string logLine, bool isImport) {
			// 追加する処理の分岐フラグ
			int NONE_DAMAGE = 0;
			int ADD_DAMAGE = 1;
			int SKIP_DAMAGE = 2;
			
			bool isSelfAttack = false;
			
			int branchFlag = NONE_DAMAGE;
			
			string attacker, victim, damage, skillType, why, special, damageType, crit;
			Regex rE = regexArray[logMatched - 1];
			int swingType = 0;
			bool critical = false;
			List<DamageAndType> damageAndTypeArr = new List<DamageAndType>();

			DateTime time = ActGlobals.oFormActMain.LastKnownTime;
			
			Dnum addCombatInDamage = null;
			
			int gts = ActGlobals.oFormActMain.GlobalTimeSorter;
			
			// 初期化
			attacker = string.Empty;
			victim = string.Empty;
			damage = string.Empty;
			skillType = string.Empty;
			why = string.Empty;
			special = string.Empty;
			damageType = string.Empty;
			crit = string.Empty;

			switch (logMatched) {
			#region Case 1 [unsourced skill attacks]
			case 1:
				branchFlag = ADD_DAMAGE;
				attacker = "不明";
				victim = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				damage = rE.Replace(logLine, "$3");
				special = rE.Replace(logLine, "$4");
				special = String.IsNullOrEmpty(special) ? "None" : special;
				crit = special;
				swingType = (int)SwingTypeEnum.NonMelee;
				
				
				if (!ActGlobals.oFormActMain.InCombat && !isImport) {
					ActGlobals.oFormSpellTimers.NotifySpell(attacker.ToLower(), skillType, victim.Contains("あなた"), victim.ToLower(), true);
					branchFlag = NONE_DAMAGE;
					break;
				}
				
				break;
			#endregion
			#region Case 2 [melee attacks by yourself]
			case 2:
				attacker = rE.Replace(logLine, "$1");
				victim = rE.Replace(logLine, "$2");
				damage = rE.Replace(logLine, "$3");
				special = rE.Replace(logLine, "$4");
				crit = special;
				special = special.Replace("クリティカルヒット・", string.Empty).Trim();
				special = special.Replace("クリティカル・", string.Empty).Trim();
				special = special.Replace("クリティカルヒット", string.Empty).Trim();
				special = special.Replace("クリティカル", string.Empty).Trim();
				if(special.Trim() == ""){
					special = "None";
				}
				swingType = (int)SwingTypeEnum.Melee;
				isSelfAttack = true;
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					branchFlag = ADD_DAMAGE;
				}
				break;
			#endregion
			#region Case 3 [melee/non-melee attacks by expect yourself]
			case 3:
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				damage = rE.Replace(logLine, "$4");
				special = rE.Replace(logLine, "$5");
				crit = special;
				special = special.Replace("クリティカルヒット・", string.Empty).Trim();
				special = special.Replace("クリティカル・", string.Empty).Trim();
				special = special.Replace("クリティカルヒット", string.Empty).Trim();
				special = special.Replace("クリティカル", string.Empty).Trim();
				if(special.Trim() == ""){
					special = "None";
				}
				isSelfAttack = true;
				if (skillType == "攻撃") {
					swingType = (int)SwingTypeEnum.Melee;
				}else{
					swingType = (int)SwingTypeEnum.NonMelee;
				}
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					branchFlag = ADD_DAMAGE;
				}
				break;
			#endregion
			#region Case 4 [healing]
			case 4:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				damage = rE.Replace(logLine, "$4");
				damageType = "Hitpoints";
				swingType = (int)SwingTypeEnum.Healing;
                special = "None";
                if (attacker == "あなた" && logLine.Contains("自分を")) {
                    victim = attacker;
                }
				addCombatInDamage = Int32.Parse(damage);
				break;
			#endregion
			#region Case 5 [critical healing]
			case 5:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				damage = rE.Replace(logLine, "$4");
				damageType = "Hitpoints";
				swingType = (int)SwingTypeEnum.Healing;
				special = "None";
				addCombatInDamage = Int32.Parse(damage);
				critical = true;
				break;
			#endregion
			#region Case 6 [misses]
			case 6:
				attacker = rE.Replace(logLine, "$1");
				victim = rE.Replace(logLine, "$2");
                why = rE.Replace(logLine, "$3");
                special = rE.Replace(logLine, "$4");
                addCombatInDamage = Dnum.Miss;

				isSelfAttack = true;
                if (why == "攻撃" )
                {
                    swingType = (int)SwingTypeEnum.Melee;
                    skillType = why.Trim();
                }
                else { // スキルmiss
                    swingType = (int)SwingTypeEnum.NonMelee;
                    skillType = (Regex.Split( why , "で攻撃" ))[0].Trim();
                }
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					branchFlag = SKIP_DAMAGE;
				}
				break;
			#endregion
			#region Case 7 [melee misses by interfer]
			case 7:
				attacker = rE.Replace(logLine, "$1");
				victim = rE.Replace(logLine, "$2");
				why = rE.Replace(logLine, "$3");
				special = rE.Replace(logLine, "$4");
				crit = special;
				skillType = "攻撃";
				damageType = "melee";
				swingType = (int)SwingTypeEnum.Melee;
				
				why = why.Replace(victim, string.Empty);
				why = why.Trim() + " " + special;
				addCombatInDamage = new Dnum(Dnum.Unknown, why.Trim());
				isSelfAttack = true;
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					branchFlag = SKIP_DAMAGE;
				}
				break;
			#endregion
			#region Case 8 [non-melee misses by interfer]
			case 8:
				attacker = rE.Replace(logLine, "$1");
				victim = rE.Replace(logLine, "$2");
				skillType = rE.Replace(logLine, "$3");
				why = special = rE.Replace(logLine, "$4");
				special = rE.Replace(logLine, "$5");
				crit = special;
				damageType = "non-melee";
				swingType = (int)SwingTypeEnum.NonMelee;
				
				why = why.Replace(victim, string.Empty);
				why = why.Trim() + " " + special;
				addCombatInDamage = new Dnum(Dnum.Unknown, why.Trim());
				isSelfAttack = true;
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					branchFlag = SKIP_DAMAGE;
				}
				break;
			#endregion
			#region Case 9 [killing]
			case 9:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				string zone = rE.Replace(logLine, "$2");
				string xpos = rE.Replace(logLine, "$3");
				string zpos = rE.Replace(logLine, "$4");
				string ypos = rE.Replace(logLine, "$5");
				victim = rE.Replace(logLine, "$6");
				swingType = (int)SwingTypeEnum.NonMelee;
				ActGlobals.oFormSpellTimers.RemoveTimerMods(victim);
				ActGlobals.oFormSpellTimers.DispellTimerMods(victim);
				special = "None";
				skillType = "Killing";
				addCombatInDamage = Dnum.Death;
				damageType = "Death";
				break;
			#endregion
			#region Case 10 [killed]
			case 10:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				victim = rE.Replace(logLine, "$1");
				attacker = rE.Replace(logLine, "$2");
				swingType = (int)SwingTypeEnum.NonMelee;
				ActGlobals.oFormSpellTimers.RemoveTimerMods(victim);
				ActGlobals.oFormSpellTimers.DispellTimerMods(victim);
				special = "None";
				skillType = "Killing";
				addCombatInDamage = Dnum.Death;
				damageType = "Death";
				break;
			#endregion
			#region Case 11 [killing yourself]
			case 11:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				victim = "あなた";
				attacker = rE.Replace(logLine, "$1");
				swingType = (int)SwingTypeEnum.NonMelee;
				ActGlobals.oFormSpellTimers.RemoveTimerMods(victim);
				ActGlobals.oFormSpellTimers.DispellTimerMods(victim);
				special = "None";
				skillType = "Killing";
				addCombatInDamage = Dnum.Death;
				damageType = "Death";
				break;
			#endregion
			#region Case 12 [act commands]
			case 12:
				branchFlag = NONE_DAMAGE;
				ActGlobals.oFormActMain.ActCommands(rE.Replace(logLine, "$1"));
				break;
			#endregion
			#region Case 13 [power drain]
			case 13:
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				damage = rE.Replace(logLine, "$4");
				special = rE.Replace(logLine, "$5");
				crit = special;
				special = "None";
				swingType = (int)SwingTypeEnum.PowerDrain;
				isSelfAttack = true;
				
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim)) {
					if (CheckWardedHit(victim, time)) {
						addCombatInDamage = new Dnum(Int32.Parse(damage) + lastWardAmount, String.Format("{0}/{1}", lastWardAmount, damage));
						damageType = "warded/non-melee";
						lastWardAmount = 0;
					} else {
						addCombatInDamage = Int32.Parse(damage);
						damageType = "non-melee";
					}
				}
				break;
			#endregion
			#region Case 14 [ward absorbtion]
			case 14:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				victim = rE.Replace(logLine, "$1");
				damage = rE.Replace(logLine, "$2");
				attacker = rE.Replace(logLine, "$3");
				skillType = rE.Replace(logLine, "$4");
				swingType = (int)SwingTypeEnum.Healing;
				special = "None";
				damageType = "Absorption";
				addCombatInDamage = Int32.Parse(damage);
				
				if (CheckWardedHit(victim, time)) {
					lastWardAmount += Int32.Parse(damage);
				} else {
					lastWardAmount = Int32.Parse(damage);
				}
				lastWardedTarget = victim;
				lastWardTime = time;
				break;
			#endregion
			#region Case 15 [ward absorbtion your spell]
			case 15:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				skillType = rE.Replace(logLine, "$1");
				damage = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				
				attacker = "あなた";
				swingType = (int)SwingTypeEnum.Healing;
				special = "None";
				damageType = "Absorption";
				addCombatInDamage = Int32.Parse(damage);
				
				if (CheckWardedHit(victim, time)) {
					lastWardAmount += Int32.Parse(damage);
				} else {
					lastWardAmount = Int32.Parse(damage);
				}
				lastWardedTarget = victim;
				lastWardTime = time;
				break;
			#endregion
			#region Case 16 [zone change]
			case 16:
				branchFlag = NONE_DAMAGE;
				if (logLine.Contains(" combat by "))
					break;
				string zoneName = rE.Replace(logLine, "$1").Trim();
				if(romanjiSplit.IsMatch(zoneName)){
					zoneName = translateForMultiple(zoneName);
				}
				ActGlobals.oFormActMain.ChangeZone(zoneName);
				break;
			#endregion
			#region Case 17 [power healing]
			case 17:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				damage = rE.Replace(logLine, "$4");
                special = rE.Replace(logLine, "$5");
				swingType = (int)SwingTypeEnum.PowerHealing;
                damageType = "Power";
                // クリティカル
                if (special == "クリティカル")
                {
                    critical = true;
                }

                
                addCombatInDamage = Int32.Parse(damage);
				break;
            #endregion
            #region case 18 [self power healing]
            case 18:
				if (!ActGlobals.oFormActMain.InCombat) {
					branchFlag = NONE_DAMAGE;
					break;
				}
				branchFlag = SKIP_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
                victim = attacker;
				damage = rE.Replace(logLine, "$3");
                special = rE.Replace(logLine, "$4");
				swingType = (int)SwingTypeEnum.PowerHealing;
                damageType = "Power";
                // クリティカル
                if (special == "クリティカル")
                {
                    critical = true;
                }
                addCombatInDamage = Int32.Parse(damage);
				break;
            #endregion
            #region Case 19 [threat]
            case 19:
                branchFlag = NONE_DAMAGE;
                string owner = rE.Replace(logLine, "$1");
                skillType = rE.Replace(logLine, "$2");
                victim = rE.Replace(logLine, "$3");
                attacker = rE.Replace(logLine, "$4");
                damage = rE.Replace(logLine, "$5");
                string dtype = rE.Replace(logLine, "$6");
                special = rE.Replace(logLine, "$7");
                string direction = rE.Replace(logLine, "$8");
                swingType = (int)SwingTypeEnum.Threat;

				if (attacker.Contains("相手") || attacker.Contains("あなた")) {
					attacker = owner;
				}
				isSelfAttack = true;

				bool increase = direction == "増加";
                critical = special.StartsWith("大幅に");
				special = "None";

				Dnum dDamage;
                bool positionChange = dtype == "position";
                if (positionChange) {
                    dDamage = new Dnum(Dnum.ThreatPosition, String.Format("{0} Positions", Int32.Parse(damage)));
                }
                else {
                    dDamage = new Dnum(Int32.Parse(damage));
                }
	
				direction = increase ? "Increase" : "Decrease";
				
				if (ActGlobals.oFormActMain.SetEncounter(time, attacker, victim) || ActGlobals.oFormActMain.SetEncounter(time, owner, victim)) {
					branchFlag = SKIP_DAMAGE;
					damageType = direction;
					addCombatInDamage = dDamage;
				}
				break;
			#endregion
			#region Case 20 [dispell/cure]
			case 20:
				branchFlag = NONE_DAMAGE;
				attacker = rE.Replace(logLine, "$1");
				skillType = rE.Replace(logLine, "$2");
				victim = rE.Replace(logLine, "$3");
				string attackType = rE.Replace(logLine, "$4");
				direction = rE.Replace(logLine, "$5");
				swingType = (int)SwingTypeEnum.CureDispel;

				if (attackType.Contains("Traumatic Swipe") || attackType.Contains("トラウマティック・スワイプ")){
					ActGlobals.oFormSpellTimers.DispellTimerMods(victim);
				}

				bool cont = false;
				if (direction.Contains("治療")) {
					cont = ActGlobals.oFormActMain.InCombat;
				} else {
					cont = ActGlobals.oFormActMain.SetEncounter(time, attacker, victim);
				}
				if (cont) {
					branchFlag = SKIP_DAMAGE;
					special = attackType;
					addCombatInDamage = 1;
					damageType = direction;
				}
				break;
			#endregion
            default:
				branchFlag = NONE_DAMAGE;
				break;
			}
			
			
			if (attacker.Contains("あなた")){
				attacker = ActGlobals.charName;
			}
			if (victim.Contains("あなた") || victim.Contains("自分")){
				victim = ActGlobals.charName;
			}
			if(!critical){
				critical = crit.Contains("クリティカル");
			}
			
			if (isSelfAttack && (attacker == victim || attacker == petSplit.Replace(victim, "$2"))) {
				branchFlag = NONE_DAMAGE;
			}
			
			if(branchFlag == ADD_DAMAGE){
				damageAndTypeArr = EngGetDamageAndTypeArr(damage);
				AddDamageAttack(swingType, critical, special, attacker, skillType, damageAndTypeArr, time, gts, victim);
			}else if(branchFlag == SKIP_DAMAGE){
				AddCombatAction(swingType, critical, special, attacker, skillType, addCombatInDamage, time, gts, victim, damageType);
			}
		}
		private bool CheckWardedHit(string victim, DateTime time)
		{
			return cbRecalcWardedHits.Checked && lastWardTime == time && lastWardedTarget == victim && lastWardAmount > 0;
		}
		private void AddDamageAttack(int swingType, bool critical, string special, string attacker, string skillType, List<DamageAndType> damageAndTypeArr, DateTime time, int gts, string victim)
		{
			int damageTotal = 0;
			if (cbMultiDamageIsOne.Checked)
			{
				string damageStr = string.Empty;
				string typeStr = string.Empty;
				if (CheckWardedHit(victim, time))
				{
					damageTotal = lastWardAmount;
					damageStr += String.Format("{0}/", damageTotal);
					typeStr += String.Format("{0}/", "warded");
					lastWardAmount = 0;
				}
				for (int i = 0; i < damageAndTypeArr.Count; i++)
				{
					damageTotal += damageAndTypeArr[i].Damage;
					damageStr += String.Format("{0}/", damageAndTypeArr[i].Damage);
					typeStr += String.Format("{0}/", damageAndTypeArr[i].Type);
				}
				damageStr = damageStr.TrimEnd(new char[] { '/' });
				typeStr = typeStr.TrimEnd(new char[] { '/' });
				if (String.IsNullOrEmpty(skillType))
					skillType = typeStr;
				
				AddCombatAction(swingType, critical, special, attacker, skillType, new Dnum(damageTotal, damageStr), time, gts, victim, typeStr);
			}
			else
			{
				bool nullSkillType = false;
				if (String.IsNullOrEmpty(skillType))
					nullSkillType = true;
				for (int i = 0; i < damageAndTypeArr.Count; i++)
				{
					damageTotal += damageAndTypeArr[i].Damage;
					if (nullSkillType)
						skillType = damageAndTypeArr[i].Type;
					if (i == damageAndTypeArr.Count - 1 && CheckWardedHit(victim, time))
					{
						damageTotal += lastWardAmount;
						lastWardAmount = 0;
					}
					AddCombatAction(swingType, critical, special, attacker, skillType, damageTotal, time, gts, victim, damageAndTypeArr[i].Type);
				}
			}
		}
		public void AddCombatAction(int SwingType, bool Critical, string Special, string Attacker, string theAttackType, Dnum Damage, DateTime Time, int TimeSorter, string Victim, string theDamageType)
		{
			
			if(romanjiSplit.IsMatch(theDamageType)){
				theDamageType = translateForMultiple(theDamageType);
			}
			if(romanjiSplit.IsMatch(theAttackType)){
				theAttackType = translateForMultiple(theAttackType);
			}
			if(romanjiSplit.IsMatch(Attacker)){
				Attacker = translateForMultiple(Attacker);
			}
			if(romanjiSplit.IsMatch(Victim)){
				Victim = translateForMultiple(Victim);
			}
			
			
			ActGlobals.oFormActMain.AddCombatAction(SwingType, Critical, Special, Attacker, theAttackType, Damage, Time, TimeSorter, Victim, theDamageType);
		}
		private string translateForMultiple(string transTarget) {
			string returnValue = string.Empty;
			
			transTarget = transTarget.Replace("\\ri:","");
			transTarget = transTarget.Replace("\\ra:","");
			transTarget = transTarget.Replace("\\rp:","");
			transTarget = transTarget.Replace("\\rm:","");
			transTarget = transTarget.Replace("\\rs:","");
			transTarget = transTarget.Replace("\\:",":");
			transTarget = transTarget.Replace("\\/r",":");
			
			string[] arrTarget = transTarget.Split(':');
			
			StringBuilder jpn = new StringBuilder();
			StringBuilder eng = new StringBuilder();
			
			if(arrTarget.Length>1){
				for(int i=0;i<arrTarget.Length;i++){
					if(i%2==0){
						jpn.Append(arrTarget[i]);
					}else{
						eng.Append(arrTarget[i]);
					}
				}
				
				if (cbKatakana.Checked){
					returnValue = jpn.ToString();
				}else{
					returnValue = eng.ToString();
				}
			}else{
				returnValue = transTarget;
			}
			
			return returnValue;
		}
		private List<DamageAndType> EngGetDamageAndTypeArr(string damageAndType) {
			List<DamageAndType> outList = new List<DamageAndType>();
			damageAndType = damageAndType.Replace(" and ", ", ");
			damageAndType = damageAndType.Replace("ポイントの", " ");
			string[] entries = damageAndType.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			

			for (int i = 0; i < entries.Length; i++)
			{
				outList.Add(new DamageAndType(entries[i]));
			}
			return outList;
		}
		private class DamageAndType
		{
			int damage;
			string type;
			/// <summary>
			/// Data class for a single type of damage and the amount
			/// </summary>
			/// <param name="Damage">The positive integer amount of damage</param>
			/// <param name="Type">The type of damage to display it as</param>
			public DamageAndType(int Damage, string Type)
			{
				this.damage = Damage;
				this.type = Type;
			}
			/// <summary>
			/// Data class for a single type of damage and the amount
			/// </summary>
			/// <param name="UnsplitSource">An input string such as "123 crushing" to be split by the constructor</param>
			public DamageAndType(string UnsplitSource)
			{
				int spacePos = UnsplitSource.IndexOf(' ');
				if (spacePos == -1)
					throw new ArgumentException("The input string did not contain a space, thus cannot be split");
				damage = Int32.Parse(UnsplitSource.Substring(0, spacePos));
				type = UnsplitSource.Substring(spacePos + 1);
			}
			public int Damage
			{
				get { return damage; }
				set { damage = value; }
			}
			public string Type
			{
				get { return type; }
				set { type = value; }
			}
		}
		#endregion
		void LoadSettings()
		{
			// Add items to the xmlSettings object here...
			xmlSettings.AddControlSetting(cbMultiDamageIsOne.Name, cbMultiDamageIsOne);
			xmlSettings.AddControlSetting(cbRecalcWardedHits.Name, cbRecalcWardedHits);
			xmlSettings.AddControlSetting(cbKatakana.Name, cbKatakana);
			xmlSettings.AddControlSetting(cbSParseConsider.Name, cbSParseConsider);

			if (File.Exists(settingsFile))
			{
				FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlTextReader xReader = new XmlTextReader(fs);

				try
				{
					while (xReader.Read())
					{
						if (xReader.NodeType == XmlNodeType.Element)
						{
							if (xReader.LocalName == "SettingsSerializer")
							{
								xmlSettings.ImportFromXml(xReader);
							}
						}
					}
				}
				catch (Exception ex)
				{
					lblStatus.Text = "Error loading settings: " + ex.Message;
				}
				xReader.Close();
			}
		}
		void SaveSettings()
		{
			FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
			xWriter.Formatting = Formatting.Indented;
			xWriter.Indentation = 1;
			xWriter.IndentChar = '\t';
			xWriter.WriteStartDocument(true);
			xWriter.WriteStartElement("Config");	// <Config>
			xWriter.WriteStartElement("SettingsSerializer");	// <Config><SettingsSerializer>
			xmlSettings.ExportToXml(xWriter);	// Fill the SettingsSerializer XML
			xWriter.WriteEndElement();	// </SettingsSerializer>
			xWriter.WriteEndElement();	// </Config>
			xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
			xWriter.Flush();	// Flush the file buffer to disk
			xWriter.Close();
		}

		private void cbRecalcWardedHits_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("Ward で軽減したダメージ分を加算して、本来の値を出力します。ただし、Stoneskin によって防いだ値は再計算できません。");
		}
		private void cbMultiDamageIsOne_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("未対応です：複数属性攻撃(300 斬撃ダメージ、5 毒ダメージ、5 病気ダメージ)を合計ダメージ(「300/5/5 斬撃/毒/病気」を 「310」）で出力します。If disabled, each damage type will show up as an individual swing, IE three attacks: 300 crushing; 5 poison; 5 disease.  Having a single attack show up as multiple will have consequences when calculating ToHit%.");
		}
		private void cbKatakana_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("日本語と英語の表記があるものについて、日本語を有効にします。(例：ゾーンやアビリティ名など)");
		}
		private void cbSParseConsider_MouseHover(object sender, EventArgs e)
		{
			ActGlobals.oFormActMain.SetOptionsHelpText("未対応です：The /con command simply adds some text to the log about your target's con-level.  The /whogroup and /whoraid commands will list the members of your group/raid respectively.  Using this option will allow you to quickly add players to the Selective Parsing list.");
		}

	}
}

