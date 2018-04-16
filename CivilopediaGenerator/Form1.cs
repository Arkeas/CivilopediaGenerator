using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CivilopediaGenerator
{
	public partial class Form1 : Form
	{
		// Eras.
		//string strLanguage = "en_US";
		//string strLanguage = "DE_DE";
		//string strLanguage = "ES_ES";
		//string strLanguage = "FR_FR";
		//string strLanguage = "IT_IT";
		//string strLanguage = "JA_JP";
		//string strLanguage = "KO_KR";
		//string strLanguage = "PL_PL";
		//string strLanguage = "RU_RU";
		string _strLanguage = "";
		private const string ERAS_XML = "D:\\Games\\Steam\\steamapps\\common\\sid meier's civilization v\\Assets\\DLC\\Expansion\\Gameplay\\XML\\GameInfo\\CIV5Eras.xml";
		//private const string ERAS_XML = "C:\\temp\\stuff\\xml\\Gameplay\\XML\\GameInfo\\CIV5Eras.xml";
		//private const string ERAS_TITLES = "C:\\temp\\stuff\\xml\\Gameplay\\XML\\NewText\\EN_US\\CIV5GameTextInfos_Objects.xml";

		private const string FILE_PATH = "D:\\Games\\Steam\\steamapps\\common\\sid meier's civilization v\\Assets";
		private const string FILE_PATH_EXP = "D:\\Games\\Steam\\steamapps\\common\\sid meier's civilization v\\Assets\\DLC\\Expansion";
		private const string FILE_PATH_EXP2 = "D:\\Games\\Steam\\steamapps\\common\\sid meier's civilization v\\Assets\\DLC\\Expansion2";
		private const string FILE_PATH_IMAGES = "D:\\temp\\unpack";
		//private const string FILE_PATH = "C:\\temp\\stuff\\xml";

		private string _strHtmlPath = "";
		private string _strXml = "";

		// All files of a given type begin with the same string, so define them here.
		private const string CONCEPT_PREFIX = "CIV5Concepts";
		private const string TECHNOLOGY_PREFIX = "CIV5Technologies";
		private const string UNIT_PREFIX = "CIV5Units";
		private const string UNIT_CLASS_PREFIX = "CIV5UnitClasses";
		private const string COMBAT_INFO_PREFIX = "CIV5UnitCombatInfos";
		private const string PROMOTION_PREFIX = "CIV5UnitPromotions";
		private const string BUILDING_PREFIX = "CIV5Buildings";
		private const string BUILDING_CLASS_PREFIX = "CIV5BuildingClasses";
		private const string PROJECT_PREFIX = "CIV5Projects";
		private const string POLICY_PREFIX = "CIV5Policies";
		private const string POLICY_BRANCH_TYPE_PREFIX = "CIV5PolicyBranchTypes";
		private const string SPECIALIST_PREFIX = "CIV5Specialists";
		private const string CIVILIZATION_PREFIX = "CIV5Civilization";
		private const string LEADER_PREFIX = "CIV5Leader";
		private const string CITY_STATE_PREFIX = "CIV5MinorCivilizations";
		private const string TERRAIN_PREFIX = "CIV5Terrains";
		private const string FEATURE_PREFIX = "CIV5Features";
		private const string RESOURCE_PREFIX = "CIV5Resources";
		private const string RESOURCE_CLASS_PREFIX = "CIV5ResourceClasses";
		private const string IMPROVEMENT_PREFIX = "CIV5Improvements";
		private const string TRAIT_PREFIX = "CIV5Traits";
		private const string BUILDS_PREFIX = "CIV5Builds";
		private const string ROUTES_PREFIX = "CIV5Routes";
		private const string TEXT_PREFIX = "CIV5GameTextInfos";
		private const string TEXT_PREFIX2 = "Civ5Civlopedia";
		private const string RELIGION_PREFIX = "Civ5Religions";
		private const string BELIEFS_PREFIX = "CIV5Beliefs";
		private const string RESOLUTIONS_PREFIX = "CIV5Resolutions";
		private const string ATLAS_PREFIX = "";

		private readonly List<string> _lstImprovementsFiles = new List<string>();

		// Lists to hold all of the paths for the files we'll find.
		private readonly List<string> _lstConcepts = new List<string>();
		private readonly List<string> _lstTechnologies = new List<string>();
		private readonly List<string> _lstUnits = new List<string>();
		private readonly List<string> _lstUnitClasses = new List<string>();
		private readonly List<string> _lstCombatInfos = new List<string>();
		private readonly List<string> _lstPromotions = new List<string>();
		private readonly List<string> _lstBuildings = new List<string>();
		private readonly List<string> _lstBuildingClasses = new List<string>();
		private readonly List<string> _lstProjects = new List<string>();
		private readonly List<string> _lstPolicies = new List<string>();
		private readonly List<string> _lstPolicyBranchTypes = new List<string>();
		private readonly List<string> _lstSpecialists = new List<string>();
		private readonly List<string> _lstCivilizations = new List<string>();
		private readonly List<string> _lstLeaders = new List<string>();
		private readonly List<string> _lstCityStates = new List<string>();
		private readonly List<string> _lstTerrains = new List<string>();
		private readonly List<string> _lstFeatures = new List<string>();
		private readonly List<string> _lstResources = new List<string>();
		private readonly List<string> _lstResourceClasses = new List<string>();
		private readonly List<string> _lstImprovements = new List<string>();
		private readonly List<string> _lstBuilds = new List<string>();
		private readonly List<string> _lstRoutes = new List<string>();
		private readonly List<string> _lstTraits = new List<string>();
		private readonly List<string> _lstTexts = new List<string>();
		private readonly List<string> _lstReligions = new List<string>();
		private readonly List<string> _lstBeliefs = new List<string>();
		private readonly List<string> _lstResolutions = new List<string>();
		private readonly List<XmlDocument> _lstTextDocs = new List<XmlDocument>();

		private readonly List<string> _lstLanguages = new List<String>();

		private readonly List<string> _lstAtlasFiles = new List<string>();
		private readonly List<Atlas> _lstAtlas256 = new List<Atlas>();
		private readonly List<Atlas> _lstAtlas64 = new List<Atlas>();

		// Commonly-used Labels.
		string TXT_KEY_PEDIA_PREREQ_TECH_LABEL = "";
		string TXT_KEY_PEDIA_LEADS_TO_TECH_LABEL = "";
		string TXT_KEY_PEDIA_UNIT_UNLOCK_LABEL = "";
		string TXT_KEY_PEDIA_BLDG_UNLOCK_LABEL = "";
		string TXT_KEY_PEDIA_PROJ_UNLOCK_LABEL = "";
		string TXT_KEY_PEDIA_RESRC_RVL_LABEL = "";
		string TXT_KEY_PEDIA_WORKER_ACTION_LABEL = "";
		string TXT_KEY_PEDIA_GAME_INFO_LABEL = "";
		string TXT_KEY_PEDIA_COMBAT_LABEL = "";
		string TXT_KEY_PEDIA_RANGEDCOMBAT_LABEL = "";
		string TXT_KEY_PEDIA_RANGE_LABEL = "";
		string TXT_KEY_PEDIA_OBSOLETE_TECH_LABEL = "";
		string TXT_KEY_COMMAND_UPGRADE = "";
		string TXT_KEY_PEDIA_CIVILIZATIONS_LABEL = "";
		string TXT_KEY_PEDIA_REPLACES_LABEL = "";
		string TXT_KEY_PEDIA_COMBATTYPE_LABEL = "";
		string TXT_KEY_PEDIA_FREEPROMOTIONS_LABEL = "";
		string TXT_KEY_PEDIA_REQ_PROMOTIONS_LABEL = "";
		string TXT_KEY_PEDIA_MAINT_LABEL = "";
		string TXT_KEY_PEDIA_REQ_BLDG_LABEL = "";
		string TXT_KEY_PEDIA_REQ_RESRC_LABEL = "";
		string TXT_KEY_PEDIA_LOCAL_RESRC_LABEL = "";
		string TXT_KEY_PEDIA_DEFENSE_LABEL = "";
		string TXT_KEY_PEDIA_HAPPINESS_LABEL = "";
		string TXT_KEY_PEDIA_CULTURE_LABEL = "";
		string TXT_KEY_PEDIA_GOLD_LABEL = "";
		string TXT_KEY_PEDIA_PRODUCTION_LABEL = "";
		string TXT_KEY_PEDIA_FOOD_LABEL = "";
		string TXT_KEY_PEDIA_SCIENCE_LABEL = "";
		string TXT_KEY_PEDIA_SPEC_LABEL = "";
		string TXT_KEY_PEDIA_QUOTE_LABEL = "";
		string TXT_KEY_PEDIA_COST_LABEL = "";
		string TXT_KEY_PEDIA_POLICYBRANCH_LABEL = "";
		string TXT_KEY_PEDIA_TENET_LEVEL = "";
		string TXT_KEY_PEDIA_PREREQ_POLICY_LABEL = "";
		string TXT_KEY_PEDIA_PREREQ_ERA_LABEL = "";
		string TXT_KEY_PEDIA_UNIQUEBLDG_LABEL = "";
		string TXT_KEY_PEDIA_UNIQUEIMPRV_LABEL = "";
		string TXT_KEY_PEDIA_FEATURES_LABEL = "";
		string TXT_KEY_PEDIA_RESOURCESFOUND_LABEL = "";
		string TXT_KEY_PEDIA_REVEAL_TECH_LABEL = "";
		string TXT_KEY_PEDIA_IMPROVES_RESRC_LABEL = "";
		string TXT_KEY_PEDIA_STRATEGY_LABEL = "";
		string TXT_KEY_PEDIA_HISTORICAL_LABEL = "";
		string TXT_KEY_PEDIA_YIELD_LABEL = "";
		string TXT_KEY_PEDIA_FOUNDON_LABEL = "";
		string TXT_KEY_PEDIA_MOUNTAINADJYIELD_LABEL = "";
		string TXT_KEY_PEDIA_SUMMARY_LABEL = "";
		string TXT_KEY_PEDIA_LIVED_LABEL = "";
		string TXT_KEY_PEDIA_TITLES_LABEL = "";
		string TXT_KEY_PEDIA_LEADERS_LABEL = "";
		string TXT_KEY_PEDIA_UNIQUEUNIT_LABEL = "";
		string TXT_KEY_PEDIA_MOVECOST_LABEL = "";
		string TXT_KEY_PEDIA_COMBATMOD_LABEL = "";
		string TXT_KEY_PEDIA_TERRAINS_LABEL = "";
		string TXT_KEY_PEDIA_IMPROVEMENTS_LABEL = "";
		string TXT_KEY_PEDIA_MOVEMENT_LABEL = "";
		string TXT_KEY_PEDIA_FAITH_LABEL = "";
		string TXT_KEY_PEDIA_GREAT_WORKS_LABEL = "";
		string TXT_KEY_GREAT_WORK_SLOT_ART_ARTIFACT_EMPTY_TOOLTIP = "";
		string TXT_KEY_GREAT_WORK_SLOT_LITERATURE_EMPTY_TOOLTIP = "";
		string TXT_KEY_GREAT_WORK_SLOT_MUSIC_EMPTY_TOOLTIP = "";
		string TXT_KEY_PEDIA_ABILITIES_LABEL = "";
		string TXT_KEY_ABLTY_FRESH_WATER_STRING = "";
		string TXT_KEY_ABLTY_NO_FRESH_WATER_STRING = "";
		string TXT_KEY_ALLOWS_OPEN_BORDERS = "";
		string TXT_KEY_ABLTY_YIELD_IMPRVD_STRING = "";
		string TXT_KEY_YIELD_SCIENCE = "";

		// MasterPage Titles.
		string TXT_KEY_PEDIA_CATEGORY_1_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_2_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_3_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_4_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_5_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_6_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_7_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_8_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_9_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_10_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_11_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_12_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_13_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_14_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_15_LABEL = "";
		string TXT_KEY_PEDIA_CATEGORY_16_LABEL = "";

		#region Control events
		public Form1()
		{
			InitializeComponent();
		}

		private void cmdGenerate_Click(object sender, EventArgs e)
		{
			if (chkEnglish.Checked)
				_lstLanguages.Add("en_US");
			if (chkGerman.Checked)
				_lstLanguages.Add("DE_DE");
			if (chkSpanish.Checked)
				_lstLanguages.Add("ES_ES");
			if (chkFrench.Checked)
				_lstLanguages.Add("FR_FR");
			if (chkItalian.Checked)
				_lstLanguages.Add("IT_IT");
			if (chkJapanese.Checked)
				_lstLanguages.Add("JA_JP");
			if (chkKorean.Checked)
				_lstLanguages.Add("KO_KR");
			if (chkPolish.Checked)
				_lstLanguages.Add("PL_PL");
			if (chkRussian.Checked)
				_lstLanguages.Add("RU_RU");
			if (chkChinese.Checked)
				_lstLanguages.Add("ZH_Hant_HK");

			txtDebug.Text += "\r\nBuilding Atlas information";
			FindFiles(FILE_PATH, ATLAS_PREFIX, _lstAtlasFiles, true, 64);
			_lstAtlasFiles.Clear();
			FindFiles(FILE_PATH, ATLAS_PREFIX, _lstAtlasFiles, true, 256);

			foreach (string strCurrentLanguage in _lstLanguages)
			{
				_strLanguage = strCurrentLanguage;
				txtDebug.Text += "\r\nProcessing Language " + _strLanguage;
				txtDebug.SelectionStart = txtDebug.TextLength;
				txtDebug.ScrollToCaret();
				Application.DoEvents();

				string strStart = DateTime.Now.ToString();
				BuildLists();
				if (_strLanguage == "en_US")
					_strHtmlPath = "html";
				else
					_strHtmlPath = "html\\" + _strLanguage.ToLower().Replace("_", "-");

				_strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
				_strXml += "<pages>";

				// Game Concepts.
				if (chkGameConcepts.Checked)
					GenerateConcepts();
				// Technologies.
				if (chkTechnologies.Checked)
					GenerateTechnologies();
				// Units.
				if (chkUnits.Checked)
					GenerateUnits();
				// Promotions.
				if (chkPromotions.Checked)
					GeneratePromotions();
				// Buildings.
				if (chkBuildings.Checked)
					GenerateBuildings();
				// Wonders.
				if (chkWonders.Checked)
					GenerateWonders();
				// Policies.
				if (chkPolicies.Checked)
					GeneratePolicies();
				// Great People.
				if (chkGreatPeople.Checked)
					GeneratePeople();
				// Civilizations.
				if (chkCivilizations.Checked)
					GenerateCivilizations();
				// City-States.
				if (chkCityStates.Checked)
					GenerateCityStates();
				// Terrains and Features.
				if (chkTerrains.Checked)
					GenerateTerrains();
				// Resources.
				if (chkResources.Checked)
					GenerateResources();
				// Improvements.
				if (chkImprovements.Checked)
					GenerateImprovements();
				// Religions.
				if (chkReligions.Checked)
					GenerateReligions();
				// Resolutions.
				if (chkResolutions.Checked)
					GenerateResolutions();
				// Home Page.
				if (chkHome.Checked)
					GenerateHome();

				_strXml += "</pages>";

				File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "pages.xml"), _strXml);

				txtDebug.Text += "\r\nDONE!";
				txtDebug.SelectionStart = txtDebug.TextLength;
				txtDebug.ScrollToCaret();

				txtDebug.Text += "\r\nStarted " + strStart;
				txtDebug.Text += "\r\nEnded " + DateTime.Now.ToString();
				txtDebug.SelectionStart = txtDebug.TextLength;
				txtDebug.ScrollToCaret();
			}
		}

		private void cmdSelectAll_Click(object sender, EventArgs e)
		{
			chkGameConcepts.Checked = true;
			chkTechnologies.Checked = true;
			chkUnits.Checked = true;
			chkPromotions.Checked = true;
			chkBuildings.Checked = true;
			chkWonders.Checked = true;
			chkPolicies.Checked = true;
			chkGreatPeople.Checked = true;
			chkCivilizations.Checked = true;
			chkCityStates.Checked = true;
			chkTerrains.Checked = true;
			chkResources.Checked = true;
			chkImprovements.Checked = true;
			chkReligions.Checked = true;
			chkHome.Checked = true;
			chkResolutions.Checked = true;
		}
		#endregion

		#region Helper methods
		private XmlDocument MergeXml(List<string> lstFiles)
		{
			XmlDocument objReturnDocument = new XmlDocument();

			int intCount = 0;
			foreach (string strXmlFile in lstFiles)
			{
				intCount++;
				XmlDocument objNewDocument = new XmlDocument();
				objNewDocument.Load(strXmlFile);

				if (intCount > 1)
				{
					foreach (XmlNode objXmlType in objNewDocument.SelectNodes("/GameData"))
					{
						foreach (XmlNode objXmlChild in objXmlType.ChildNodes)
						{
							if (objXmlChild.NodeType != XmlNodeType.Comment)
							{
								XmlNode objAttachNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name);
								if (objAttachNode == null)
								{
									XmlNode objImportParent = objReturnDocument.ImportNode(objXmlChild, true);
									objReturnDocument.SelectSingleNode("/GameData").AppendChild(objImportParent);
									objAttachNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name);
								}

								foreach (XmlNode objXmlNode in objXmlChild.SelectNodes("Delete"))
								{
									string strField = ""; 
									string strValue = "";

									if (objXmlNode.Attributes.Count != 0)
									{
										strField = objXmlNode.Attributes[0].Name;
										strValue = objXmlNode.Attributes[0].InnerText;
									}
									else
									{
									}

									List<XmlNode> lstDeleteNodes = new List<XmlNode>();

									if (strField != "")
									{
										foreach (XmlNode objTemp in objAttachNode.ChildNodes)
										{
											if (objTemp.NodeType != XmlNodeType.Comment)
											{
												if (objTemp.Name == "Row")
												{
													if (objTemp[strField].InnerText == strValue)
														lstDeleteNodes.Add(objTemp);
												}
											}
										}

										foreach (XmlNode objDelete in lstDeleteNodes)
											objAttachNode.RemoveChild(objDelete);
									}
								}

								foreach (XmlNode objXmlNode in objXmlChild.SelectNodes("Row"))
								{
									XmlNode objImport = objReturnDocument.ImportNode(objXmlNode, true);
									//objBuildingDocument.DocumentElement.AppendChild(objImport);
									objAttachNode.AppendChild(objImport);
								}
							}
						}
					}
				}
				else
				{
					objReturnDocument.LoadXml(objNewDocument.OuterXml);
				}
			}

			// Replace.
			foreach (string strXmlFile in lstFiles)
			{
				XmlDocument objNewDocument = new XmlDocument();
				objNewDocument.Load(strXmlFile);

				foreach (XmlNode objXmlType in objNewDocument.SelectNodes("/GameData"))
				{
					foreach (XmlNode objXmlChild in objXmlType.ChildNodes)
					{
						foreach (XmlNode objXmlNode in objXmlChild.SelectNodes("Replace"))
						{
							try
							{
								XmlNode objFindNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name + "/Row[Type = \"" + objXmlNode["Type"].InnerText + "\"]");
								objFindNode.InnerXml = objXmlNode.InnerXml;
							}
							catch
							{
								XmlNode objFindNode = RenameNode(objXmlNode, objXmlNode.NamespaceURI, "Row");
								XmlNode objImport = objReturnDocument.ImportNode(objXmlNode, true);
								XmlNode objAppendNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name);
								objAppendNode.AppendChild(objImport);
								// An exception will happen if we're trying to replace something that was deleted previously.
							}
						}
					}
				}
			}

			// Update.
			foreach (string strXmlFile in lstFiles)
			{
				XmlDocument objNewDocument = new XmlDocument();
				objNewDocument.Load(strXmlFile);

				foreach (XmlNode objXmlType in objNewDocument.SelectNodes("/GameData"))
				{
					foreach (XmlNode objXmlChild in objXmlType.ChildNodes)
					{
						if (objXmlChild.NodeType != XmlNodeType.Comment)
						{
							XmlNode objAttachNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name);

							foreach (XmlNode objXmlNode in objXmlChild.SelectNodes("Update"))
							{
								XmlNode objWhere = objXmlNode["Where"];
								string strField = objWhere.Attributes[0].Name;
								string strValue = objWhere.Attributes[0].InnerText;

								XmlNode objSet = objXmlNode["Set"];

								if (strField != "")
								{
									foreach (XmlNode objTemp in objAttachNode.ChildNodes)
									{
										if (objTemp.NodeType != XmlNodeType.Comment)
										{
											if (objTemp.Name == "Row")
											{
												if (objTemp[strField].InnerText == strValue)
												{
													foreach (XmlNode objUpdateItem in objSet.ChildNodes)
													{
														if (objTemp[objUpdateItem.Name] != null)
															objTemp[objUpdateItem.Name].InnerText = objUpdateItem.InnerText;
														else
														{
															XmlNode objImport = objReturnDocument.ImportNode(objUpdateItem, true);
															objTemp.AppendChild(objImport);
														}
													}
												}
											}
										}
									}

									//foreach (XmlNode objDelete in lstDeleteNodes)
										//objAttachNode.RemoveChild(objDelete);
								}

								try
								{
									XmlNode objFindNode = objReturnDocument.SelectSingleNode("/GameData/" + objXmlChild.Name + "/Row[Type = \"" + objXmlNode["Type"].InnerText + "\"]");
									objFindNode.InnerXml = objXmlNode.InnerXml;
								}
								catch
								{
								}
							}
						}
					}
				}
			}

			return objReturnDocument;
		}

		public XmlNode RenameNode(XmlNode node, string namespaceURI, string qualifiedName)
		{
			if (node.NodeType == XmlNodeType.Element)
			{
				XmlElement oldElement = (XmlElement)node;
				XmlElement newElement =
				node.OwnerDocument.CreateElement(qualifiedName, namespaceURI);
				while (oldElement.HasAttributes)
				{
					newElement.SetAttributeNode(oldElement.RemoveAttributeNode(oldElement.Attributes[0]));
				}
				while (oldElement.HasChildNodes)
				{
					newElement.AppendChild(oldElement.FirstChild);
				}
				if (oldElement.ParentNode != null)
				{
					oldElement.ParentNode.ReplaceChild(newElement, oldElement);
				}
				return newElement;
			}
			else
			{
				return null;
			}
		}

		private string GetName(string strTag)
		{
			string strReturn = "";
			strReturn = GetName(strTag, _lstImprovements);
			if (strReturn == "")
				strReturn = GetName(strTag, _lstBuildings);
			if (strReturn == "")
				strReturn = GetName(strTag, _lstRoutes);

			return strReturn;
		}

		private string GetName(string strTag, List<string> lstList)
		{
			XmlDocument objXmlDocument = MergeXml(lstList);
			XmlNode objGameData = objXmlDocument.SelectSingleNode("/GameData");
			foreach (XmlNode objXmlTop in objGameData.ChildNodes)
			{
				if (objXmlTop.NodeType != XmlNodeType.Comment)
				{
					foreach (XmlNode objXmlNode in objXmlTop)
					{
						if (objXmlNode["Type"] != null)
						{
							if (objXmlNode["Type"].InnerText == strTag)
								return GetString(objXmlNode["Description"].InnerText);
						}
					}
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// Search all text files and return the string for the specified Tag.
		/// </summary>
		/// <param name="strTag">Tag to search for.</param>
		private string GetString(string strTag, bool blnParse = true)
		{
			string strReturn = "";

			//foreach (String strXmlFile in _lstTexts)
			//{
			//    XmlDocument objDocument = new XmlDocument();
			//    objDocument.Load(strXmlFile);
			//    XmlNode objNode;
			//    try
			//    {
			//        objNode = objDocument.SelectSingleNode("/GameData/Language_" + strLanguage + "/Row[@Tag = \"" + strTag + "\"]");
			//        strReturn = ParseString(objNode["Text"].InnerText);
			//        break;
			//    }
			//    catch
			//    {
			//    }
			//}

			if (strTag == "UNIT_PROPHET")
			{
			}

			foreach (XmlDocument objDocument in _lstTextDocs)
			{
				if (objDocument.BaseURI.Contains("Expansion2"))
					strReturn = ReturnString(objDocument, strTag, blnParse);
				if (strReturn != "")
					break;
			}

			if (strReturn == "")
			{
				foreach (XmlDocument objDocument in _lstTextDocs)
				{
					if (objDocument.BaseURI.Contains("Expansion") && !objDocument.NamespaceURI.Contains("Expansion2"))
						strReturn = ReturnString(objDocument, strTag, blnParse);
					if (strReturn != "")
						break;
				}
			}

			if (strReturn == "")
			{
				foreach (XmlDocument objDocument in _lstTextDocs)
				{
					if (!objDocument.BaseURI.Contains("Expansion"))
						strReturn = ReturnString(objDocument, strTag, blnParse);
					if (strReturn != "")
						break;
				}
			}

			return strReturn;
		}

		private string ReturnString(XmlDocument objDocument, string strTag, bool blnParse)
		{
			string strReturn = "";
			XmlNode objNode;
			try
			{
				objNode = objDocument.SelectSingleNode("/GameData/Language_" + _strLanguage + "/Row[@Tag = \"" + strTag + "\"]");
				if (blnParse)
					strReturn = ParseString(objNode["Text"].InnerText);
				else
					strReturn = objNode["Text"].InnerText;

				// Check for "|" which means we need to check the Plurality field as well.
				if (strReturn.Contains("|"))
				{
					int intPlurality = 0;
					if (objNode["Plurality"] != null)
					{
						string[] strPluarality = objNode["Plurality"].InnerText.Split('|');
						intPlurality = Convert.ToInt32(strPluarality[0]) - 1;
					}
					string[] strStrings = strReturn.Split('|');
					strReturn = strStrings[intPlurality];
				}
			}
			catch
			{
			}

			if (strReturn.StartsWith("{") && blnParse)
			{
				strReturn = GetString(strReturn.Replace("{", string.Empty).Replace("}", string.Empty));
			}

			while (strReturn.Contains("{") && blnParse)
			{
				int intStart = strReturn.IndexOf("{");
				int intEnd = strReturn.IndexOf("}");
				string strReplace = strReturn.Substring(intStart, intEnd - intStart + 1);
				string strReplacement = GetString(strReplace.Replace("{", string.Empty).Replace("}", string.Empty), true);
				strReturn = strReturn.Replace(strReplace, strReplacement);
			}


			return strReturn;
		}

		/// <summary>
		/// Search all files in a List and return the string for the specified Key.
		/// </summary>
		/// <param name="lstList">List to search.</param>
		/// <param name="strTable">Table to search.</param>
		/// <param name="strKey">Key string to return.</param>
		private string FindDescription(List<string> lstList, string strTable, string strKey)
		{
			string strReturn = "";
			foreach (string strFile in lstList)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strFile);

				XmlNode objNode = objDocument.SelectSingleNode("/GameData/" + strTable + "/Row[Type = \"" + strKey + "\"]");
				if (objNode != null)
				{
					strReturn = GetString(objNode["Description"].InnerText).Replace("'", "\\'");
					break;
				}
			}

			return strReturn;
		}

		/// <summary>
		/// Create a List of Groups for the Eras.
		/// <param name="blnAddReligious">Whether or not the Religious pseudo-Era should be added.</param>
		/// </summary>
		private List<Group> CreateEraGroups(bool blnAddReligious = false)
		{
			List<Group> lstReturn = new List<Group>();

			if (blnAddReligious)
			{
				// Manually add the Religious "Era".
				Group objReligious = new Group();
				objReligious.Key = "TXT_KEY_PEDIA_RELIGIOUS";
				objReligious.Name = GetString("TXT_KEY_PEDIA_RELIGIOUS");
				lstReturn.Add(objReligious);
			}

			XmlDocument objDocument = new XmlDocument();
			objDocument.Load(ERAS_XML);

			foreach (XmlNode objEra in objDocument.SelectNodes("/GameData/Eras/Row"))
			{
				Group objGroup = new Group();
				objGroup.Key = objEra["Type"].InnerText;
				objGroup.Name = GetEra(objEra["Type"].InnerText);
				lstReturn.Add(objGroup);
			}

			return lstReturn;
		}

		/// <summary>
		/// Get the name of the Era from the Era Tag.
		/// </summary>
		/// <param name="strEra">Era tag to lookup.</param>
		private string GetEra(string strEra)
		{
			XmlDocument objDocument = new XmlDocument();
			objDocument.Load(ERAS_XML);
			XmlNode objNode = objDocument.SelectSingleNode("/GameData/Eras/Row[Type = \"" + strEra + "\"]");
			string strReturn = GetString(objNode["Description"].InnerText);
			return strReturn;
		}

		/// <summary>
		/// Parse out special tags and return the modified string.
		/// </summary>
		/// <param name="strString">String to modify.</param>
		private string ParseString(string strString)
		{
			string strReturn = strString;

			// String Formatting.
			strReturn = strReturn.Replace("[ENDCOLOR]", "</span>");
			strReturn = strReturn.Replace("[TAB]", string.Empty);
			strReturn = strReturn.Replace("[NEWLINE]", "<br />");
			strReturn = strReturn.Replace("[COLOR_POSITIVE_TEXT]", "<span class=\"color_positive_text\">");
			strReturn = strReturn.Replace("[COLOR_WARNING_TEXT]", "<span class=\"color_warning_text\">");
			strReturn = strReturn.Replace("[COLOR_CYAN]", "<span class=\"color_cyan_text\">");
			// Correct the single instance of "[NEWLINE " in the Robotics Technology text.
			strReturn = strReturn.Replace("[NEWLINE ", "<br />");
			// Replace "[...]" with nothing as this doesn't get rendered in the game's Civilopedia.
			strReturn = strReturn.Replace("[...]", string.Empty);

			// Images.
			strReturn = strReturn.Replace("[ICON_CAPITAL]", "<img src=\"/civilopedia/images/capital.png\" alt=\"capital\" />");
			strReturn = strReturn.Replace("[ICON_CITIZEN]", "<img src=\"/civilopedia/images/citizen.png\" alt=\"citizen\" />");
			strReturn = strReturn.Replace("[ICON_CONNECTED]", "<img src=\"/civilopedia/images/connected.png\" alt=\"connected\" />");
			strReturn = strReturn.Replace("[ICON_CULTURE]", "<img src=\"/civilopedia/images/culture.png\" alt=\"culture\" />");
			strReturn = strReturn.Replace("[ICON_FOOD]", "<img src=\"/civilopedia/images/food.png\" alt=\"food\" />");
			strReturn = strReturn.Replace("[ICON_GOLD]", "<img src=\"/civilopedia/images/gold.png\" alt=\"gold\" />");
			strReturn = strReturn.Replace("[ICON_GOLDEN_AGE]", "<img src=\"/civilopedia/images/golden_age.png\" alt=\"golden age\" />");
			strReturn = strReturn.Replace("[ICON_GREAT_PEOPLE]", "<img src=\"/civilopedia/images/great_people.png\" alt=\"great people\" />");
			strReturn = strReturn.Replace("[ICON_HAPPINESS_1]", "<img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />");
			strReturn = strReturn.Replace("[ICON_HAPPINESS_4]", "<img src=\"/civilopedia/images/happiness_4.png\" alt=\"unhappiness\" />");
			strReturn = strReturn.Replace("[ICON_INFLUENCE]", "<img src=\"/civilopedia/images/influence.png\" alt=\"influence\" />");
			strReturn = strReturn.Replace("[ICON_MOVES]", "<img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />");
			strReturn = strReturn.Replace("[ICON_OCCUPIED]", "<img src=\"/civilopedia/images/occupied.png\" alt=\"occupied\" />");
			strReturn = strReturn.Replace("[ICON_PRODUCTION]", "<img src=\"/civilopedia/images/production.png\" alt=\"production\" />");
			strReturn = strReturn.Replace("[ICON_RANGE_STRENGTH]", "<img src=\"/civilopedia/images/range_strength.png\" alt=\"range strength\" />");
			strReturn = strReturn.Replace("[ICON_RESEARCH]", "<img src=\"/civilopedia/images/research.png\" alt=\"research\" />");
			strReturn = strReturn.Replace("[ICON_STRENGTH]", "<img src=\"/civilopedia/images/strength.png\" alt=\"strength\" />");
			strReturn = strReturn.Replace("[ICON_PEACE]", "<img src=\"/civilopedia/images/peace.png\" alt=\"peace\" />");
			strReturn = strReturn.Replace("[ICON_RELIGION]", "<img src=\"/civilopedia/images/religion.png\" alt=\"religion\" />");
			strReturn = strReturn.Replace("[ICON_INTERNATIONAL_TRADE]", "<img src=\"/civilopedia/images/internationaltrade.png\" alt=\"international trade\" />");
			strReturn = strReturn.Replace("[ICON_TROPHY_GOLD]", "<img src=\"/civilopedia/images/trophygold.png\" alt=\"gold trophy\" />");
			strReturn = strReturn.Replace("[ICON_TROPHY_SILVER]", "<img src=\"/civilopedia/images/trophysilver.png\" alt=\"silver trophy\" />");
			strReturn = strReturn.Replace("[ICON_TROPHY_BRONZE]", "<img src=\"/civilopedia/images/trophybronze.png\" alt=\"bronze trophy\" />");
			strReturn = strReturn.Replace("[ICON_TOURISM]", "<img src=\"/civilopedia/images/tourism.png\" alt=\"tourism\" />");
			strReturn = strReturn.Replace("[ICON_DIPLOMAT]", "<img src=\"/civilopedia/images/diplomat.png\" alt=\"diplomat\" />");

			// Resource Images.
			strReturn = strReturn.Replace("[ICON_RES_ALUMINUM]", "<img src=\"/civilopedia/images/res_aluminum.png\" alt=\"aluminum\" />");
			strReturn = strReturn.Replace("[ICON_RES_BANANA]", "<img src=\"/civilopedia/images/res_bananas.png\" alt=\"bananas\" />");
			strReturn = strReturn.Replace("[ICON_RES_BANANAS]", "<img src=\"/civilopedia/images/res_bananas.png\" alt=\"bananas\" />");
			strReturn = strReturn.Replace("[ICON_RES_CITRUS]", "<img src=\"/civilopedia/images/res_citrus.png\" alt=\"citrus\" />");
			strReturn = strReturn.Replace("[ICON_RES_COAL]", "<img src=\"/civilopedia/images/res_coal.png\" alt=\"coal\" />");
			strReturn = strReturn.Replace("[ICON_RES_COPPER]", "<img src=\"/civilopedia/images/res_copper.png\" alt=\"copper\" />");
			strReturn = strReturn.Replace("[ICON_RES_COTTON]", "<img src=\"/civilopedia/images/res_cotton.png\" alt=\"cotton\" />");
			strReturn = strReturn.Replace("[ICON_RES_COW]", "<img src=\"/civilopedia/images/res_cow.png\" alt=\"cow\" />");
			strReturn = strReturn.Replace("[ICON_RES_CRAB]", "<img src=\"/civilopedia/images/res_crab.png\" alt=\"cow\" />");
			strReturn = strReturn.Replace("[ICON_RES_DEER]", "<img src=\"/civilopedia/images/res_deer.png\" alt=\"deer\" />");
			strReturn = strReturn.Replace("[ICON_RES_DYES]", "<img src=\"/civilopedia/images/res_dyes.png\" alt=\"dyes\" />");
			strReturn = strReturn.Replace("[ICON_RES_FISH]", "<img src=\"/civilopedia/images/res_fish.png\" alt=\"fish\" />");
			strReturn = strReturn.Replace("[ICON_RES_FUR]", "<img src=\"/civilopedia/images/res_fur.png\" alt=\"fur\" />");
			strReturn = strReturn.Replace("[ICON_RES_GEMS]", "<img src=\"/civilopedia/images/res_gems.png\" alt=\"gems\" />");
			strReturn = strReturn.Replace("[ICON_RES_GOLD]", "<img src=\"/civilopedia/images/res_gold.png\" alt=\"gold\" />");
			strReturn = strReturn.Replace("[ICON_RES_HORSE]", "<img src=\"/civilopedia/images/res_horses.png\" alt=\"horses\" />");
			strReturn = strReturn.Replace("[ICON_RES_HORSES]", "<img src=\"/civilopedia/images/res_horses.png\" alt=\"horses\" />");
			strReturn = strReturn.Replace("[ICON_RES_INCENSE]", "<img src=\"/civilopedia/images/res_incense.png\" alt=\"incense\" />");
			strReturn = strReturn.Replace("[ICON_RES_IRON]", "<img src=\"/civilopedia/images/res_iron.png\" alt=\"iron\" />");
			strReturn = strReturn.Replace("[ICON_RES_IVORY]", "<img src=\"/civilopedia/images/res_ivory.png\" alt=\"ivory\" />");
			strReturn = strReturn.Replace("[ICON_RES_JEWELRY]", "<img src=\"/civilopedia/images/res_jewelry.png\" alt=\"jewelry\" />");
			strReturn = strReturn.Replace("[ICON_RES_MARBLE]", "<img src=\"/civilopedia/images/res_marble.png\" alt=\"marble\" />");
			strReturn = strReturn.Replace("[ICON_RES_OIL]", "<img src=\"/civilopedia/images/res_oil.png\" alt=\"oil\" />");
			strReturn = strReturn.Replace("[ICON_OIL]", "<img src=\"/civilopedia/images/res_oil.png\" alt=\"oil\" />");
			strReturn = strReturn.Replace("[ICON_RES_PEARLS]", "<img src=\"/civilopedia/images/res_pearls.png\" alt=\"pearls\" />");
			strReturn = strReturn.Replace("[ICON_RES_PORCELAIN]", "<img src=\"/civilopedia/images/res_porcelain.png\" alt=\"porcelain\" />");
			strReturn = strReturn.Replace("[ICON_RES_SALT]", "<img src=\"/civilopedia/images/res_salt.png\" alt=\"salt\" />");
			strReturn = strReturn.Replace("[ICON_RES_SHEEP]", "<img src=\"/civilopedia/images/res_sheep.png\" alt=\"sheep\" />");
			strReturn = strReturn.Replace("[ICON_RES_SILK]", "<img src=\"/civilopedia/images/res_silk.png\" alt=\"silk\" />");
			strReturn = strReturn.Replace("[ICON_RES_SILVER]", "<img src=\"/civilopedia/images/res_silver.png\" alt=\"silver\" />");
			strReturn = strReturn.Replace("[ICON_RES_SPICES]", "<img src=\"/civilopedia/images/res_spices.png\" alt=\"spices\" />");
			strReturn = strReturn.Replace("[ICON_RES_STONE]", "<img src=\"/civilopedia/images/res_stone.png\" alt=\"stone\" />");
			strReturn = strReturn.Replace("[ICON_RES_SUGAR]", "<img src=\"/civilopedia/images/res_sugar.png\" alt=\"sugar\" />");
			strReturn = strReturn.Replace("[ICON_RES_TRUFFLES]", "<img src=\"/civilopedia/images/res_truffles.png\" alt=\"silk\" />");
			strReturn = strReturn.Replace("[ICON_RES_URANIUM]", "<img src=\"/civilopedia/images/res_uranium.png\" alt=\"uranium\" />");
			strReturn = strReturn.Replace("[ICON_RES_WHALE]", "<img src=\"/civilopedia/images/res_whales.png\" alt=\"whales\" />");
			strReturn = strReturn.Replace("[ICON_RES_WHALES]", "<img src=\"/civilopedia/images/res_whales.png\" alt=\"whales\" />");
			strReturn = strReturn.Replace("[ICON_RES_WHEAT]", "<img src=\"/civilopedia/images/res_wheat.png\" alt=\"wheat\" />");
			strReturn = strReturn.Replace("[ICON_RES_WINE]", "<img src=\"/civilopedia/images/res_wine.png\" alt=\"wine\" />");

			// Yield Images.
			strReturn = strReturn.Replace("YIELD_FOOD", "<img src=\"/civilopedia/images/food.png\" alt=\"food\" />");
			strReturn = strReturn.Replace("YIELD_PRODUCTION", "<img src=\"/civilopedia/images/production.png\" alt=\"production\" />");
			strReturn = strReturn.Replace("YIELD_GOLD", "<img src=\"/civilopedia/images/gold.png\" alt=\"gold\" />");
			strReturn = strReturn.Replace("YIELD_SCIENCE", "<img src=\"/civilopedia/images/research.png\" alt=\"research\" />");
			strReturn = strReturn.Replace("YIELD_FAITH", "<img src=\"/civilopedia/images/peace.png\" alt=\"research\" />");
			strReturn = strReturn.Replace("YIELD_CULTURE", "<img src=\"/civilopedia/images/culture.png\" alt=\"culture\" />");

			// Special/Accented Characters.
			// French and Spanish special characters.
			strReturn = strReturn.Replace("[…]", string.Empty);
			strReturn = strReturn.Replace("Á", "&Aacute;");
			strReturn = strReturn.Replace("À", "&Agrave;");
			strReturn = strReturn.Replace("Â", "&Acirc;");
			strReturn = strReturn.Replace("Ä", "&Auml;");
			strReturn = strReturn.Replace("É", "&Eacute;");
			strReturn = strReturn.Replace("È", "&Egrave;");
			strReturn = strReturn.Replace("Ê", "&Ecirc;");
			strReturn = strReturn.Replace("Ë", "&Euml;");
			strReturn = strReturn.Replace("Í", "&Iacute;");
			strReturn = strReturn.Replace("Î", "&Icirc;");
			strReturn = strReturn.Replace("Ï", "&Iuml;");
			strReturn = strReturn.Replace("Ó", "&Oacute;");
			strReturn = strReturn.Replace("Ô", "&Ocirc;");
			strReturn = strReturn.Replace("Œ", "&OElig;");
			strReturn = strReturn.Replace("Ú", "&Uacute;");
			strReturn = strReturn.Replace("Ù", "&Ugrave;");
			strReturn = strReturn.Replace("Û", "&Ucirc;");
			strReturn = strReturn.Replace("Ü", "&Uuml;");
			strReturn = strReturn.Replace("Ÿ", "&Yuml;");
			strReturn = strReturn.Replace("Ç", "&Ccedil;");
			strReturn = strReturn.Replace("Ñ", "&Ntilde;");
			strReturn = strReturn.Replace("á", "&aacute;");
			strReturn = strReturn.Replace("à", "&agrave;");
			strReturn = strReturn.Replace("â", "&acirc;");
			strReturn = strReturn.Replace("ä", "&auml;");
			strReturn = strReturn.Replace("é", "&eacute;");
			strReturn = strReturn.Replace("è", "&egrave;");
			strReturn = strReturn.Replace("ê", "&ecirc;");
			strReturn = strReturn.Replace("ë", "&euml;");
			strReturn = strReturn.Replace("í", "&iacute;");
			strReturn = strReturn.Replace("î", "&icirc;");
			strReturn = strReturn.Replace("ï", "&iuml;");
			strReturn = strReturn.Replace("ó", "&oacute;");
			strReturn = strReturn.Replace("ô", "&ocirc;");
			strReturn = strReturn.Replace("œ", "&oelig;");
			strReturn = strReturn.Replace("ú", "&uacute;");
			strReturn = strReturn.Replace("ü", "&uuml;");
			strReturn = strReturn.Replace("ù", "&ugrave;");
			strReturn = strReturn.Replace("û", "&ucirc;");
			strReturn = strReturn.Replace("ÿ", "&yuml;");
			strReturn = strReturn.Replace("ç", "&ccedil;");
			strReturn = strReturn.Replace("ñ", "&ntilde;");

			// German (1st line) and Polish special characters.
			strReturn = strReturn.Replace("ß", "&szlig;");
			strReturn = strReturn.Replace("Ą", "&#260;");
			strReturn = strReturn.Replace("ą", "&#261;");
			strReturn = strReturn.Replace("Ę", "&#280;");
			strReturn = strReturn.Replace("ę", "&#281;");
			strReturn = strReturn.Replace("Ć", "&#262;");
			strReturn = strReturn.Replace("ć", "&#263;");
			strReturn = strReturn.Replace("Ł", "&#321;");
			strReturn = strReturn.Replace("ł", "&#322;");
			strReturn = strReturn.Replace("Ń", "&#323;");
			strReturn = strReturn.Replace("ń", "&#324;");
			strReturn = strReturn.Replace("Ś", "&#346;");
			strReturn = strReturn.Replace("ś", "&#347;");
			strReturn = strReturn.Replace("Ź", "&#377;");
			strReturn = strReturn.Replace("ź", "&#378;");
			strReturn = strReturn.Replace("Ż", "&#379;");
			strReturn = strReturn.Replace("ż", "&#380;");

			// Italian special characters.
			strReturn = strReturn.Replace("º", "&ordm;");
			strReturn = strReturn.Replace("ª", "&ordf;");

			strReturn = StripLinks(strReturn);

			return strReturn;
		}

		/// <summary>
		/// Remove any [LINK] tags from the string.
		/// </summary>
		/// <param name="strString">String to parse.</param>
		private string StripLinks(string strString)
		{
			// [link] and [end link] only appear in the Greece Civ text once.
			strString = strString.Replace("[\\LINK]", string.Empty);
			strString = strString.Replace("[end link]", string.Empty);
			strString = strString.Replace("[link]", string.Empty);
			while (strString.Contains("[LINK"))
			{
				int intStart = strString.IndexOf("[LINK");
				int intEnd = strString.IndexOf("]");
				if (intStart > -1 && intEnd != intStart)
				{
					intEnd += 1;
					string strChop = strString.Substring(intStart, intEnd - intStart);
					strString = strString.Replace(strChop, string.Empty);
				}
			}

			return strString;
		}

		/// <summary>
		/// Find files with a given prefix and add them to a List.
		/// </summary>
		/// <param name="strPath">Directory to search.</param>
		/// <param name="strPrefix">File prefix to search for.</param>
		/// <param name="lstFiles">List to add paths of found files to.</param>
		/// <param name="blnAtlas">Whether or not we're attempting to fill an Atlas.</param>
		/// <param name="intAtlasSize">Size of Atlas images that we're looking for.</param>
		private void FindFiles(string strPath, string strPrefix, List<string> lstFiles, bool blnAtlas = false, int intAtlasSize = 0)
		{
			foreach (string strFile in Directory.GetFiles(strPath, strPrefix + "*.xml"))
			{
				// Look through the list and see if the file is already in there.
				bool blnIncludeFile = true;

				string strFileName = strFile.Split('\\')[strFile.Split('\\').Length - 1];
				foreach (string strExisting in lstFiles)
				{
					if (strExisting.EndsWith(strFileName))
					{
						// If this is from the Expansion directory, keep it and disregard this new item.
						if (strExisting.Contains("\\Expansion") && !strFile.Contains("\\Expansion2"))
						{
							blnIncludeFile = false;
							break;
						}
						// If this is not from the expansion directory and the new one is, use the expansion one instead.
						if (strFile.Contains("\\Expansion2"))
						{
							lstFiles.Remove(strExisting);
							break;
						}
						else
						{
							if (!strExisting.Contains("\\Expansion") && strFile.Contains("\\Expansion"))
							{
								lstFiles.Remove(strExisting);
								break;
							}
						}
					}
				}

				if (blnIncludeFile)
				{
					if (blnAtlas)
					{
						XmlDocument objXmlDocument = new XmlDocument();
						try
						{
							objXmlDocument.Load(strFile);
							XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GameData/IconTextureAtlases/Row[IconSize = \"" + intAtlasSize.ToString() + "\"]");
							if (objXmlNodeList.Count > 0)
							{
								foreach (XmlNode objXmlNode in objXmlNodeList)
								{
									Atlas objAtlas = new Atlas();
									objAtlas.Name = objXmlNode["Atlas"].InnerText;
									objAtlas.IconSize = intAtlasSize;
									objAtlas.Filename = objXmlNode["Filename"].InnerText;
									objAtlas.IconsPerRow = Convert.ToInt32(objXmlNode["IconsPerRow"].InnerText);
									objAtlas.IconsPerColumn = Convert.ToInt32(objXmlNode["IconsPerColumn"].InnerText);

									// See if the Atlas already exists in the list.
									{
										if (intAtlasSize == 64)
										{
											foreach (Atlas objFind in _lstAtlas64)
											{
												if (objFind.Name == objAtlas.Name)
												{
													if (objFind.IconsPerRow < objAtlas.IconsPerRow || objFind.IconsPerColumn < objAtlas.IconsPerColumn)
													{
														_lstAtlas64.Remove(objFind);
														break;
													}
												}
											}
										}
										else
										{
											foreach (Atlas objFind in _lstAtlas256)
											{
												if (objFind.Name == objAtlas.Name)
												{
													if (objFind.IconsPerRow < objAtlas.IconsPerRow || objFind.IconsPerColumn < objAtlas.IconsPerColumn)
													{
														_lstAtlas256.Remove(objFind);
														break;
													}
												}
											}
										}
									}

									if (intAtlasSize == 64)
										_lstAtlas64.Add(objAtlas);
									else
										_lstAtlas256.Add(objAtlas);
								}
							}
						}
						catch
						{
						}
					}
					else
					{
						// Do not include Scenario files.
						if (!strFile.EndsWith("Scenario.xml"))
						{
							// ***** TODO: IF A FILE EXISTS IN THE EXPANSION DIRECTORY AND THE BASE DIRECTORY, ONLY USE THE EXPANSION COPY TO AVOID DUPLICATE ENTRIES
							lstFiles.Add(strFile);
							//txtDebug.Text += "\r\nFound " + strFile;
							//txtDebug.SelectionStart = txtDebug.TextLength;
							//txtDebug.ScrollToCaret();

							if (strPrefix == TEXT_PREFIX || strPrefix == TEXT_PREFIX2)
							{
								XmlDocument objDocument = new XmlDocument();
								objDocument.Load(strFile);
								_lstTextDocs.Add(objDocument);
							}

							//Application.DoEvents();
						}
					}
				}
			}
			foreach (string strDirectory in Directory.GetDirectories(strPath))
			{
				// Exclude language-specific files that are not EN_US.
				bool blnAcceptFile = true;
				if (strDirectory.ToUpper().Contains("\\DE_DE") && _strLanguage != "DE_DE")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\EN_US") && _strLanguage != "en_US")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\ES_ES") && _strLanguage != "ES_ES")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\FR_FR") && _strLanguage != "FR_FR")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\IT_IT") && _strLanguage != "IT_IT")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\JA_JP") && _strLanguage != "JA_JP")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\KO_KR") && _strLanguage != "KO_KR")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\PL_PL") && _strLanguage != "PL_PL")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\RU_RU") && _strLanguage != "s")
					blnAcceptFile = false;
				if (strDirectory.ToUpper().Contains("\\ZH_Hant_HK") && _strLanguage != "ZH_Hant_HK")
					blnAcceptFile = false;
				if (blnAcceptFile)
					FindFiles(strDirectory, strPrefix, lstFiles, blnAtlas, intAtlasSize);
			}
		}

		/// <summary>
		/// Build the Lists for all of the XML files we'll be using.
		/// </summary>
		private void BuildLists()
		{
			// Clear the lists so we can regenerate them.
			_lstConcepts.Clear();
			_lstTechnologies.Clear();
			_lstUnits.Clear();
			_lstUnitClasses.Clear();
			_lstCombatInfos.Clear();
			_lstPromotions.Clear();
			_lstBuildings.Clear();
			_lstBuildingClasses.Clear();
			_lstProjects.Clear();
			_lstPolicies.Clear();
			_lstPolicyBranchTypes.Clear();
			_lstSpecialists.Clear();
			_lstCivilizations.Clear();
			_lstLeaders.Clear();
			_lstCityStates.Clear();
			_lstTerrains.Clear();
			_lstFeatures.Clear();
			_lstResources.Clear();
			_lstResourceClasses.Clear();
			_lstImprovements.Clear();
			_lstBuilds.Clear();
			_lstRoutes.Clear();
			_lstTraits.Clear();
			_lstTexts.Clear();
			_lstTextDocs.Clear();

			txtDebug.Text += "\r\nFinding Concepts...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, CONCEPT_PREFIX, _lstConcepts);
			txtDebug.Text += "\r\nFinding Technologies...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, TECHNOLOGY_PREFIX, _lstTechnologies);
			txtDebug.Text += "\r\nFinding Units...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, UNIT_PREFIX, _lstUnits);
			txtDebug.Text += "\r\nFinding Unit Classes...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, UNIT_CLASS_PREFIX, _lstUnitClasses);
			txtDebug.Text += "\r\nFinding Combat Infos...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, COMBAT_INFO_PREFIX, _lstCombatInfos);
			txtDebug.Text += "\r\nFinding Promotions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, PROMOTION_PREFIX, _lstPromotions);
			txtDebug.Text += "\r\nFinding Buildings...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, BUILDING_PREFIX, _lstBuildings);
			txtDebug.Text += "\r\nFinding Building Classes...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, BUILDING_CLASS_PREFIX, _lstBuildingClasses);
			txtDebug.Text += "\r\nFinding Projects...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, PROJECT_PREFIX, _lstProjects);
			txtDebug.Text += "\r\nFinding Policies...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, POLICY_PREFIX, _lstPolicies);
			txtDebug.Text += "\r\nFinding Policy Branches...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, POLICY_BRANCH_TYPE_PREFIX, _lstPolicyBranchTypes);
			txtDebug.Text += "\r\nFinding Specialists...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, SPECIALIST_PREFIX, _lstSpecialists);
			txtDebug.Text += "\r\nFinding Civilizations...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, CIVILIZATION_PREFIX, _lstCivilizations);
			txtDebug.Text += "\r\nFinding Leaders...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, LEADER_PREFIX, _lstLeaders);
			txtDebug.Text += "\r\nFinding Traits...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, TRAIT_PREFIX, _lstTraits);
			txtDebug.Text += "\r\nFinding City-States...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, CITY_STATE_PREFIX, _lstCityStates);
			txtDebug.Text += "\r\nFinding Terrains...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, TERRAIN_PREFIX, _lstTerrains);
			txtDebug.Text += "\r\nFinding Features...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, FEATURE_PREFIX, _lstFeatures);
			txtDebug.Text += "\r\nFinding Resources...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, RESOURCE_PREFIX, _lstResources);
			txtDebug.Text += "\r\nFinding Resource Classes...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, RESOURCE_CLASS_PREFIX, _lstResourceClasses);
			txtDebug.Text += "\r\nFinding Improvements...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, IMPROVEMENT_PREFIX, _lstImprovements);
			txtDebug.Text += "\r\nFinding Religions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, RELIGION_PREFIX, _lstReligions);
			txtDebug.Text += "\r\nFinding Beliefs...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, BELIEFS_PREFIX, _lstBeliefs);
			txtDebug.Text += "\r\nFinding Resolutions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, RESOLUTIONS_PREFIX, _lstResolutions);
			txtDebug.Text += "\r\nFinding Builds...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, BUILDS_PREFIX, _lstBuilds);
			txtDebug.Text += "\r\nFinding Routes...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, ROUTES_PREFIX, _lstRoutes);
			txtDebug.Text += "\r\nFinding Text...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			FindFiles(FILE_PATH, TEXT_PREFIX, _lstTexts);
			FindFiles(FILE_PATH, TEXT_PREFIX2, _lstTexts);

			txtDebug.Text += "\r\nBuilding Labels...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			TXT_KEY_PEDIA_PREREQ_TECH_LABEL = GetString("TXT_KEY_PEDIA_PREREQ_TECH_LABEL");
			TXT_KEY_PEDIA_LEADS_TO_TECH_LABEL = GetString("TXT_KEY_PEDIA_LEADS_TO_TECH_LABEL");
			TXT_KEY_PEDIA_UNIT_UNLOCK_LABEL = GetString("TXT_KEY_PEDIA_UNIT_UNLOCK_LABEL");
			TXT_KEY_PEDIA_BLDG_UNLOCK_LABEL = GetString("TXT_KEY_PEDIA_BLDG_UNLOCK_LABEL");
			TXT_KEY_PEDIA_PROJ_UNLOCK_LABEL = GetString("TXT_KEY_PEDIA_PROJ_UNLOCK_LABEL");
			TXT_KEY_PEDIA_RESRC_RVL_LABEL = GetString("TXT_KEY_PEDIA_RESRC_RVL_LABEL");
			TXT_KEY_PEDIA_WORKER_ACTION_LABEL = GetString("TXT_KEY_PEDIA_WORKER_ACTION_LABEL");
			TXT_KEY_PEDIA_GAME_INFO_LABEL = GetString("TXT_KEY_PEDIA_GAME_INFO_LABEL");
			TXT_KEY_PEDIA_COMBAT_LABEL = GetString("TXT_KEY_PEDIA_COMBAT_LABEL");
			TXT_KEY_PEDIA_RANGEDCOMBAT_LABEL = GetString("TXT_KEY_PEDIA_RANGEDCOMBAT_LABEL");
			TXT_KEY_PEDIA_RANGE_LABEL = GetString("TXT_KEY_PEDIA_RANGE_LABEL");
			TXT_KEY_PEDIA_OBSOLETE_TECH_LABEL = GetString("TXT_KEY_PEDIA_OBSOLETE_TECH_LABEL");
			TXT_KEY_COMMAND_UPGRADE = GetString("TXT_KEY_COMMAND_UPGRADE");
			TXT_KEY_PEDIA_CIVILIZATIONS_LABEL = GetString("TXT_KEY_PEDIA_CIVILIZATIONS_LABEL");
			TXT_KEY_PEDIA_REPLACES_LABEL = GetString("TXT_KEY_PEDIA_REPLACES_LABEL");
			TXT_KEY_PEDIA_COMBATTYPE_LABEL = GetString("TXT_KEY_PEDIA_COMBATTYPE_LABEL");
			TXT_KEY_PEDIA_FREEPROMOTIONS_LABEL = GetString("TXT_KEY_PEDIA_FREEPROMOTIONS_LABEL");
			TXT_KEY_PEDIA_REQ_PROMOTIONS_LABEL = GetString("TXT_KEY_PEDIA_REQ_PROMOTIONS_LABEL");
			TXT_KEY_PEDIA_MAINT_LABEL = GetString("TXT_KEY_PEDIA_MAINT_LABEL");
			TXT_KEY_PEDIA_REQ_BLDG_LABEL = GetString("TXT_KEY_PEDIA_REQ_BLDG_LABEL");
			TXT_KEY_PEDIA_REQ_RESRC_LABEL = GetString("TXT_KEY_PEDIA_REQ_RESRC_LABEL");
			TXT_KEY_PEDIA_LOCAL_RESRC_LABEL = GetString("TXT_KEY_PEDIA_LOCAL_RESRC_LABEL");
			TXT_KEY_PEDIA_DEFENSE_LABEL = GetString("TXT_KEY_PEDIA_DEFENSE_LABEL");
			TXT_KEY_PEDIA_HAPPINESS_LABEL = GetString("TXT_KEY_PEDIA_HAPPINESS_LABEL");
			TXT_KEY_PEDIA_CULTURE_LABEL = GetString("TXT_KEY_PEDIA_CULTURE_LABEL");
			TXT_KEY_PEDIA_GOLD_LABEL = GetString("TXT_KEY_PEDIA_GOLD_LABEL");
			TXT_KEY_PEDIA_PRODUCTION_LABEL = GetString("TXT_KEY_PEDIA_PRODUCTION_LABEL");
			TXT_KEY_PEDIA_FOOD_LABEL = GetString("TXT_KEY_PEDIA_FOOD_LABEL");
			TXT_KEY_PEDIA_SCIENCE_LABEL = GetString("TXT_KEY_PEDIA_SCIENCE_LABEL");
			TXT_KEY_PEDIA_SPEC_LABEL = GetString("TXT_KEY_PEDIA_SPEC_LABEL");
			TXT_KEY_PEDIA_QUOTE_LABEL = GetString("TXT_KEY_PEDIA_QUOTE_LABEL");
			TXT_KEY_PEDIA_COST_LABEL = GetString("TXT_KEY_PEDIA_COST_LABEL");
			TXT_KEY_PEDIA_POLICYBRANCH_LABEL = GetString("TXT_KEY_PEDIA_POLICYBRANCH_LABEL");
			TXT_KEY_PEDIA_TENET_LEVEL = GetString("TXT_KEY_PEDIA_TENET_LEVEL");
			TXT_KEY_PEDIA_PREREQ_POLICY_LABEL = GetString("TXT_KEY_PEDIA_PREREQ_POLICY_LABEL");
			TXT_KEY_PEDIA_PREREQ_ERA_LABEL = GetString("TXT_KEY_PEDIA_PREREQ_ERA_LABEL");
			TXT_KEY_PEDIA_UNIQUEBLDG_LABEL = GetString("TXT_KEY_PEDIA_UNIQUEBLDG_LABEL");
			TXT_KEY_PEDIA_UNIQUEIMPRV_LABEL = GetString("TXT_KEY_PEDIA_UNIQUEIMPRV_LABEL");
			TXT_KEY_PEDIA_FEATURES_LABEL = GetString("TXT_KEY_PEDIA_FEATURES_LABEL");
			TXT_KEY_PEDIA_RESOURCESFOUND_LABEL = GetString("TXT_KEY_PEDIA_RESOURCESFOUND_LABEL");
			TXT_KEY_PEDIA_REVEAL_TECH_LABEL = GetString("TXT_KEY_PEDIA_REVEAL_TECH_LABEL");
			TXT_KEY_PEDIA_IMPROVES_RESRC_LABEL = GetString("TXT_KEY_PEDIA_IMPROVES_RESRC_LABEL");
			TXT_KEY_PEDIA_STRATEGY_LABEL = GetString("TXT_KEY_PEDIA_STRATEGY_LABEL");
			TXT_KEY_PEDIA_HISTORICAL_LABEL = GetString("TXT_KEY_PEDIA_HISTORICAL_LABEL");
			TXT_KEY_PEDIA_YIELD_LABEL = GetString("TXT_KEY_PEDIA_YIELD_LABEL");
			TXT_KEY_PEDIA_FOUNDON_LABEL = GetString("TXT_KEY_PEDIA_FOUNDON_LABEL");
			TXT_KEY_PEDIA_MOUNTAINADJYIELD_LABEL = GetString("TXT_KEY_PEDIA_MOUNTAINADJYIELD_LABEL");
			TXT_KEY_PEDIA_SUMMARY_LABEL = GetString("TXT_KEY_PEDIA_SUMMARY_LABEL");
			TXT_KEY_PEDIA_LIVED_LABEL = GetString("TXT_KEY_PEDIA_LIVED_LABEL");
			TXT_KEY_PEDIA_TITLES_LABEL = GetString("TXT_KEY_PEDIA_TITLES_LABEL");
			TXT_KEY_PEDIA_LEADERS_LABEL = GetString("TXT_KEY_PEDIA_LEADERS_LABEL");
			TXT_KEY_PEDIA_UNIQUEUNIT_LABEL = GetString("TXT_KEY_PEDIA_UNIQUEUNIT_LABEL");
			TXT_KEY_PEDIA_MOVECOST_LABEL = GetString("TXT_KEY_PEDIA_MOVECOST_LABEL");
			TXT_KEY_PEDIA_COMBATMOD_LABEL = GetString("TXT_KEY_PEDIA_COMBATMOD_LABEL");
			TXT_KEY_PEDIA_TERRAINS_LABEL = GetString("TXT_KEY_PEDIA_TERRAINS_LABEL");
			TXT_KEY_PEDIA_IMPROVEMENTS_LABEL = GetString("TXT_KEY_PEDIA_IMPROVEMENTS_LABEL");
			TXT_KEY_PEDIA_MOVEMENT_LABEL = GetString("TXT_KEY_PEDIA_MOVEMENT_LABEL");
			TXT_KEY_PEDIA_FAITH_LABEL = GetString("TXT_KEY_PEDIA_FAITH_LABEL");
			TXT_KEY_PEDIA_GREAT_WORKS_LABEL = GetString("TXT_KEY_PEDIA_GREAT_WORKS_LABEL");
			TXT_KEY_GREAT_WORK_SLOT_ART_ARTIFACT_EMPTY_TOOLTIP = GetString("TXT_KEY_GREAT_WORK_SLOT_ART_ARTIFACT_EMPTY_TOOLTIP");
			TXT_KEY_GREAT_WORK_SLOT_LITERATURE_EMPTY_TOOLTIP = GetString("TXT_KEY_GREAT_WORK_SLOT_LITERATURE_EMPTY_TOOLTIP");
			TXT_KEY_GREAT_WORK_SLOT_MUSIC_EMPTY_TOOLTIP = GetString("TXT_KEY_GREAT_WORK_SLOT_MUSIC_EMPTY_TOOLTIP");
			TXT_KEY_ABLTY_YIELD_IMPRVD_STRING = GetString("TXT_KEY_ABLTY_YIELD_IMPRVD_STRING");
			TXT_KEY_PEDIA_ABILITIES_LABEL = GetString("TXT_KEY_PEDIA_ABILITIES_LABEL");
			TXT_KEY_ABLTY_FRESH_WATER_STRING = GetString("TXT_KEY_ABLTY_FRESH_WATER_STRING");
			TXT_KEY_ABLTY_NO_FRESH_WATER_STRING = GetString("TXT_KEY_ABLTY_NO_FRESH_WATER_STRING");
			TXT_KEY_ALLOWS_OPEN_BORDERS = GetString("TXT_KEY_ALLOWS_OPEN_BORDERS");
			TXT_KEY_YIELD_SCIENCE = GetString("TXT_KEY_YIELD_SCIENCE");

			TXT_KEY_PEDIA_CATEGORY_1_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_1_LABEL");
			TXT_KEY_PEDIA_CATEGORY_2_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_2_LABEL");
			TXT_KEY_PEDIA_CATEGORY_3_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_3_LABEL");
			TXT_KEY_PEDIA_CATEGORY_4_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_4_LABEL");
			TXT_KEY_PEDIA_CATEGORY_5_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_5_LABEL");
			TXT_KEY_PEDIA_CATEGORY_6_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_6_LABEL");
			TXT_KEY_PEDIA_CATEGORY_7_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_7_LABEL");
			TXT_KEY_PEDIA_CATEGORY_8_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_8_LABEL");
			TXT_KEY_PEDIA_CATEGORY_9_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_9_LABEL");
			TXT_KEY_PEDIA_CATEGORY_10_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_10_LABEL");
			TXT_KEY_PEDIA_CATEGORY_11_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_11_LABEL");
			TXT_KEY_PEDIA_CATEGORY_12_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_12_LABEL");
			TXT_KEY_PEDIA_CATEGORY_13_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_13_LABEL");
			TXT_KEY_PEDIA_CATEGORY_14_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_14_LABEL");
			TXT_KEY_PEDIA_CATEGORY_15_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_15_LABEL");
			TXT_KEY_PEDIA_CATEGORY_16_LABEL = GetString("TXT_KEY_PEDIA_CATEGORY_16_LABEL");
		}

		/// <summary>
		/// Create the image for a technology.
		/// </summary>
		/// <param name="strFilename">Filename to save the created image to.</param>
		/// <param name="strAtlasName">Name of the Atlas that contains the image information.</param>
		/// <param name="strIndex">PortraitIndex of the image within the Atlas.</param>
		/// <param name="intAtlasSize">Size of the images within the Atlas.</param>
		private void CreateImage(string strFilename, string strAtlasName, string strIndex, int intAtlasSize)
		{
			int intIndex = Convert.ToInt32(strIndex);
			string strDirectory = "";

			//Find the specified Atlas.
			Atlas objAtlas = new Atlas();
			if (intAtlasSize == 64)
			{
				foreach (Atlas objFind in _lstAtlas64)
				{
					if (objFind.Name == strAtlasName)
					{
						objAtlas = objFind;
						break;
					}
				}
				strDirectory = "small";
			}
			else
			{
				foreach (Atlas objFind in _lstAtlas256)
				{
					if (objFind.Name == strAtlasName)
					{
						objAtlas = objFind;
						break;
					}
				}
				strDirectory = "large";
			}

			// Don't attempt to do anything if there is no Atlas name. Some of the items do not have large images.
			if (objAtlas.Filename == string.Empty)
				return;

			strFilename = Path.Combine(Application.StartupPath, _strHtmlPath, "images", strDirectory, strFilename + ".png");
			//strFilename = Path.Combine(FILE_PATH_IMAGES, strDirectory, strFilename + ".png");

			int intRow = 0;
			int intCol = 0;

			int intCounter = 0;
			while (intCounter != intIndex)
			{
				intCounter++;
				intCol++;
				if (intCol > objAtlas.IconsPerRow - 1)
				{
					intCol = 0;
					intRow++;
				}
			}

			Rectangle objRectangle = new Rectangle(intCol * objAtlas.IconSize, intRow * objAtlas.IconSize, objAtlas.IconSize, objAtlas.IconSize);
			Bitmap bmpImage = null;
			try
			{
				bmpImage = new Bitmap(Path.Combine(FILE_PATH_IMAGES, objAtlas.Filename));
			}
			catch
			{
				MessageBox.Show("Could not find file " + Path.Combine(FILE_PATH_IMAGES, objAtlas.Filename) + ". Should be found in Resources\\DX9 directory as DDS file.");
			}
			Bitmap bmpCrop = bmpImage.Clone(objRectangle, bmpImage.PixelFormat);

			Image imgFrame = Image.FromFile(Path.Combine(FILE_PATH_IMAGES, "frame" + strDirectory + ".png"));

			Bitmap objImage = new Bitmap(bmpCrop.Width, bmpCrop.Height);
			Graphics objGraphics = Graphics.FromImage(objImage);
			objGraphics.DrawImage(imgFrame, new Point(0, 0));
			objGraphics.DrawImage((Image)bmpCrop, new Point(0, 0));
			objGraphics.Dispose();
			objImage.Save(strFilename);
		}
		#endregion

		#region Page generation methods
		/// <summary>
		/// Generate Concept pages.
		/// </summary>
		private void GenerateConcepts()
		{
			txtDebug.Text += "\r\nGenerating Concepts...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_GAME_CONCEPT_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_GCONCEPTS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_GAME_CONCEPT_HELP_TEXT");
			string strHomeOutput = strHomeTeplate;
			const string strHomeImage = "GAME_CONCEPTS";
			const string strMaster = "Concepts";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "CONCEPT_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Setup the groups manually since there's apparently no way of discovering this through XML.
			for (int i = 1; i <= 25; i++)
			{
				Group objNewGroup = new Group();
				objNewGroup.Name = GetString("TXT_KEY_GAME_CONCEPT_SECTION_" + i.ToString());
				switch (i)
				{
					case 1:
						objNewGroup.Key = "HEADER_CITIES";
						break;
					case 2:
						objNewGroup.Key = "HEADER_COMBAT";
						break;
					case 3:
						objNewGroup.Key = "HEADER_TERRAIN";
						break;
					case 4:
						objNewGroup.Key = "HEADER_RESOURCES";
						break;
					case 5:
						objNewGroup.Key = "HEADER_IMPROVEMENTS";
						break;
					case 6:
						objNewGroup.Key = "HEADER_CITYGROWTH";
						break;
					case 7:
						objNewGroup.Key = "HEADER_TECHNOLOGY";
						break;
					case 8:
						objNewGroup.Key = "HEADER_CULTURE";
						break;
					case 9:
						objNewGroup.Key = "HEADER_DIPLOMACY";
						break;
					case 10:
						objNewGroup.Key = "HEADER_HAPPINESS";
						break;
					case 11:
						objNewGroup.Key = "HEADER_FOW";
						break;
					case 12:
						objNewGroup.Key = "HEADER_POLICIES";
						break;
					case 13:
						objNewGroup.Key = "HEADER_GOLD";
						break;
					case 14:
						objNewGroup.Key = "HEADER_ADVISORS";
						break;
					case 15:
						objNewGroup.Key = "HEADER_PEOPLE";
						break;
					case 16:
						objNewGroup.Key = "HEADER_CITYSTATE";
						break;
					case 17:
						objNewGroup.Key = "HEADER_MOVEMENT";
						break;
					case 18:
						objNewGroup.Key = "HEADER_AIRCOMBAT";
						break;
					case 19:
						objNewGroup.Key = "HEADER_RUBARB";
						break;
					case 20:
						objNewGroup.Key = "HEADER_UNITS";
						break;
					case 21:
						objNewGroup.Key = "HEADER_VICTORY";
						break;
					case 22:
						objNewGroup.Key = "HEADER_ESPIONAGE";
						break;
					case 23:
						objNewGroup.Key = "HEADER_RELIGION";
						break;
					case 24:
						objNewGroup.Key = "HEADER_TRADE";
						break;
					case 25:
						objNewGroup.Key = "HEADER_WORLDCONGRESS";
						break;
				}
				lstGroups.Add(objNewGroup);
			}

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CONCEPTS.aspx"));
			// Flip the order of the files so that the base file comes first.
			_lstConcepts.Reverse();
			int intCategoryCount = 0;
			foreach (string strXmlFile in _lstConcepts)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Concepts/Row"))
				{
					if (objTechnology["Summary"].InnerText != "CONCEPT_SPECIALISTS_AND_GREAT_PEOPLE_GREAT_PEOPLE_GOLDEN_AGE")
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strDesc = "";

						switch (objTechnology["Summary"].InnerText)
						{
							case "CONCEPT_VICTORY_DIPLOMATIC_VOTING":
								strDesc = GetString("TXT_KEY_VICTORY_WHOVOTES_HEADING4_BODY_ALT");
								break;
							case "CONCEPT_VICTORY_MINOR_CIV_LIBERATION":
								strDesc = GetString("TXT_KEY_VICTORY_LIBERATION_HEADING4_BODY_ALT");
								break;
							default:
								strDesc = GetString(objTechnology["Summary"].InnerText);
								break;
						}

						string strMyDesc = strDesc;
						strDesc = "<h2>" + TXT_KEY_PEDIA_SUMMARY_LABEL + "</h2>";
						strDesc += "<div class=\"t\">";
						strDesc += "<div class=\"b\">";
						strDesc += "<div class=\"l\">";
						strDesc += "<div class=\"r\">";
						strDesc += "<div class=\"bl\">";
						strDesc += "<div class=\"br\">";
						strDesc += "<div class=\"tl\">";
						strDesc += "<div class=\"tr\">";
						strDesc += strMyDesc;
						strDesc += "</div></div></div></div></div></div></div></div>";

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##DESC##", strDesc);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Topic already exists in the Group List, add this item to it, otherwise, create the new Group.
						bool blnFound = false;
						Group objGroup = new Group();
						if (objTechnology["CivilopediaHeaderType"] != null)
						{
							foreach (Group objCurrentGroup in lstGroups)
							{
								if (objCurrentGroup.Key == objTechnology["CivilopediaHeaderType"].InnerText)
								{
									objGroup = objCurrentGroup;
									blnFound = true;
									break;
								}
							}

							if (!blnFound)
							{
								intCategoryCount++;
								objGroup.Key = objTechnology["CivilopediaHeaderType"].InnerText;
								objGroup.Name = GetString("TXT_KEY_GAME_CONCEPT_SECTION_" + intCategoryCount.ToString());
								lstGroups.Add(objGroup);
							}
							objGroup.GroupItems.Add(objItem);

							_strXml += "\t\t<page>";
							_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
							_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
							_strXml += "\t\t</page>";

							File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
						}
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CONCEPTS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"CONCEPT_HOME.aspx\"><div id=\"CONCEPT_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Concepts.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Technology pages.
		/// </summary>
		private void GenerateTechnologies()
		{
			txtDebug.Text += "\r\nGenerating Technologies...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = CreateEraGroups();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_TECH_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_TECHS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_TECHNOLOGIES_HELP_TEXT");
			const string strHomeImage = "TECH_AGRICULTURE";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Technologies";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "TECH_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_TECHNOLOGIES.aspx"));

			XmlDocument objDocument = MergeXml(_lstTechnologies);

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Technologies/Row"))
			{
				//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
				//txtDebug.SelectionStart = txtDebug.TextLength;
				//txtDebug.ScrollToCaret();
				//Application.DoEvents();
				string strTitle = GetString(objTechnology["Description"].InnerText);
				string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
				string strHelp = GetString(objTechnology["Help"].InnerText);
				string strMyHelp = strHelp;
				strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
				strHelp += "<div class=\"t\">";
				strHelp += "<div class=\"b\">";
				strHelp += "<div class=\"l\">";
				strHelp += "<div class=\"r\">";
				strHelp += "<div class=\"bl\">";
				strHelp += "<div class=\"br\">";
				strHelp += "<div class=\"tl\">";
				strHelp += "<div class=\"tr\">";
				strHelp += strMyHelp;
				strHelp += "</div></div></div></div></div></div></div></div>";

				string strQuote = GetString(objTechnology["Quote"].InnerText);
				string strMyQuote = strQuote;
				strQuote = "<h2>" + TXT_KEY_PEDIA_QUOTE_LABEL + "</h2>";
				strQuote += "<div class=\"t\">";
				strQuote += "<div class=\"b\">";
				strQuote += "<div class=\"l\">";
				strQuote += "<div class=\"r\">";
				strQuote += "<div class=\"bl\">";
				strQuote += "<div class=\"br\">";
				strQuote += "<div class=\"tl\">";
				strQuote += "<div class=\"tr\">";
				strQuote += strMyQuote;
				strQuote += "</div></div></div></div></div></div></div></div>";

				string strDesc = GetString(objTechnology["Civilopedia"].InnerText);
				string strMyDesc = strDesc;
				strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
				strDesc += "<div class=\"t\">";
				strDesc += "<div class=\"b\">";
				strDesc += "<div class=\"l\">";
				strDesc += "<div class=\"r\">";
				strDesc += "<div class=\"bl\">";
				strDesc += "<div class=\"br\">";
				strDesc += "<div class=\"tl\">";
				strDesc += "<div class=\"tr\">";
				strDesc += strMyDesc;
				strDesc += "</div></div></div></div></div></div></div></div>";

				string strCost = objTechnology["Cost"].InnerText + " <img src=\"/civilopedia/images/research.png\" alt=\"research\" />";
				string strMyCost = strCost;
				strCost = "<h2>" + TXT_KEY_PEDIA_COST_LABEL + "</h2>";
				strCost += "<div class=\"t\">";
				strCost += "<div class=\"b\">";
				strCost += "<div class=\"l\">";
				strCost += "<div class=\"r\">";
				strCost += "<div class=\"bl\">";
				strCost += "<div class=\"br\">";
				strCost += "<div class=\"tl\">";
				strCost += "<div class=\"tr\">";
				strCost += strMyCost;
				strCost += "</div></div></div></div></div></div></div></div>";

				// Look for Prereq Tech.
				string strPrereq = "";
				foreach (XmlNode objPrereq in objDocument.SelectNodes("/GameData/Technology_PrereqTechs/Row[TechType = \"" + objTechnology["Type"].InnerText + "\"]"))
				{
					if (strPrereq == "")
					{
						strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
						strPrereq += "<div class=\"t\">";
						strPrereq += "<div class=\"b\">";
						strPrereq += "<div class=\"l\">";
						strPrereq += "<div class=\"r\">";
						strPrereq += "<div class=\"bl\">";
						strPrereq += "<div class=\"br\">";
						strPrereq += "<div class=\"tl\">";
						strPrereq += "<div class=\"tr\">";
					}
					string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["PrereqTech"].InnerText);
					strPrereq += "<a href=\"" + objPrereq["PrereqTech"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["PrereqTech"].InnerText + ".png\" /></a>";
				}
				if (strPrereq != "")
					strPrereq += "</div></div></div></div></div></div></div></div>";

				// Look for Techs this one leads to.
				string strLeads = "";
				foreach (XmlNode objPrereq in objDocument.SelectNodes("/GameData/Technology_PrereqTechs/Row[PrereqTech = \"" + objTechnology["Type"].InnerText + "\"]"))
				{
					if (strLeads == "")
					{
						strLeads += "<h2>" + TXT_KEY_PEDIA_LEADS_TO_TECH_LABEL + "</h2>";
						strLeads += "<div class=\"t\">";
						strLeads += "<div class=\"b\">";
						strLeads += "<div class=\"l\">";
						strLeads += "<div class=\"r\">";
						strLeads += "<div class=\"bl\">";
						strLeads += "<div class=\"br\">";
						strLeads += "<div class=\"tl\">";
						strLeads += "<div class=\"tr\">";
					}
					string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["TechType"].InnerText);
					strLeads += "<a href=\"" + objPrereq["TechType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["TechType"].InnerText + ".png\" /></a>";
				}
				if (strLeads != "")
					strLeads += "</div></div></div></div></div></div></div></div>";

				// Look for Units this unlocks.
				string strUnits = "";
				foreach (string strUnitXmlFile in _lstUnits)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strUnitXmlFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Units/Row[PrereqTech = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						// Do not include Barbarian units.
						if (!objPrereq["Type"].InnerText.StartsWith("UNIT_BARBARIAN"))
						{
							if (strUnits == "")
							{
								strUnits += "<h2>" + TXT_KEY_PEDIA_UNIT_UNLOCK_LABEL + "</h2>";
								strUnits += "<div class=\"t\">";
								strUnits += "<div class=\"b\">";
								strUnits += "<div class=\"l\">";
								strUnits += "<div class=\"r\">";
								strUnits += "<div class=\"bl\">";
								strUnits += "<div class=\"br\">";
								strUnits += "<div class=\"tl\">";
								strUnits += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstUnits, "Units", objPrereq["Type"].InnerText);
							strUnits += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
						}
					}
				}
				if (strUnits != "")
					strUnits += "</div></div></div></div></div></div></div></div>";

				// Look for Buildings this unlocks.
				string strBuildings = "";
				foreach (string strBuildingXmlFile in _lstBuildings)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strBuildingXmlFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Buildings/Row[PrereqTech = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						if (objPrereq["Type"].InnerText != "BUILDING_UNITED_NATIONS")
						{
							if (strBuildings == "")
							{
								strBuildings += "<h2>" + TXT_KEY_PEDIA_BLDG_UNLOCK_LABEL + "</h2>";
								strBuildings += "<div class=\"t\">";
								strBuildings += "<div class=\"b\">";
								strBuildings += "<div class=\"l\">";
								strBuildings += "<div class=\"r\">";
								strBuildings += "<div class=\"bl\">";
								strBuildings += "<div class=\"br\">";
								strBuildings += "<div class=\"tl\">";
								strBuildings += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstBuildings, "Buildings", objPrereq["Type"].InnerText);
							strBuildings += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
						}
					}
				}
				if (strBuildings != "")
					strBuildings += "</div></div></div></div></div></div></div></div>";

				// Look for Projects this unlocks.
				string strProjects = "";
				foreach (string strProjectXmlFile in _lstProjects)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strProjectXmlFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Projects/Row[TechPrereq = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						if (strProjects == "")
						{
							strProjects += "<h2>" + TXT_KEY_PEDIA_PROJ_UNLOCK_LABEL + "</h2>";
							strProjects += "<div class=\"t\">";
							strProjects += "<div class=\"b\">";
							strProjects += "<div class=\"l\">";
							strProjects += "<div class=\"r\">";
							strProjects += "<div class=\"bl\">";
							strProjects += "<div class=\"br\">";
							strProjects += "<div class=\"tl\">";
							strProjects += "<div class=\"tr\">";
						}
						string strMyTitle = FindDescription(_lstProjects, "Projects", objPrereq["Type"].InnerText);
						strProjects += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
					}
				}
				if (strProjects != "")
					strProjects += "</div></div></div></div></div></div></div></div>";

				// Look for Resources Revealed this unlocks.
				string strResources = "";
				foreach (string strResourcesFile in _lstResources)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strResourcesFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Resources/Row[TechReveal = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						if (strResources == "")
						{
							strResources += "<h2>" + TXT_KEY_PEDIA_RESRC_RVL_LABEL + "</h2>";
							strResources += "<div class=\"t\">";
							strResources += "<div class=\"b\">";
							strResources += "<div class=\"l\">";
							strResources += "<div class=\"r\">";
							strResources += "<div class=\"bl\">";
							strResources += "<div class=\"br\">";
							strResources += "<div class=\"tl\">";
							strResources += "<div class=\"tr\">";
						}
						string strMyTitle = FindDescription(_lstResources, "Resources", objPrereq["Type"].InnerText);
						strResources += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
					}
				}
				if (strResources != "")
					strResources += "</div></div></div></div></div></div></div></div>";

				// Look for Working Actions Allowed this unlocks.
				string strActions = "";
				foreach (string strBuildsFile in _lstBuilds)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strBuildsFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Builds/Row[PrereqTech = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						if (strActions == "")
						{
							strActions += "<h2>" + TXT_KEY_PEDIA_WORKER_ACTION_LABEL + "</h2>";
							strActions += "<div class=\"t\">";
							strActions += "<div class=\"b\">";
							strActions += "<div class=\"l\">";
							strActions += "<div class=\"r\">";
							strActions += "<div class=\"bl\">";
							strActions += "<div class=\"br\">";
							strActions += "<div class=\"tl\">";
							strActions += "<div class=\"tr\">";
						}
						if (objPrereq["Type"].InnerText == "BUILD_REMOVE_JUNGLE" || objPrereq["Type"].InnerText == "BUILD_REMOVE_MARSH" || objPrereq["Type"].InnerText == "BUILD_REMOVE_FOREST")
						{
							string strMyTitle = "";
							if (objPrereq["Type"].InnerText == "BUILD_REMOVE_JUNGLE")
								strMyTitle = GetString("TXT_KEY_BUILD_REMOVE_JUNGLE");
							else if (objPrereq["Type"].InnerText == "BUILD_REMOVE_FOREST")
								strMyTitle = GetString("TXT_KEY_BUILD_REMOVE_FOREST");
							else
								strMyTitle = GetString("TXT_KEY_BUILD_REMOVE_MARSH");
							strActions += "<a href=\"CONCEPT_WORKERS_CLEARINGLAND.aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText.Replace("BUILD_", "IMPROVEMENT_") + ".png\" /></a>";
						}
						else
						{
							// Pull out the [LINK] information from the "Construct a [X]" strings since they're useless here.
							string strMyTitle = FindDescription(_lstBuilds, "Builds", objPrereq["Type"].InnerText);
							strMyTitle = strMyTitle.Replace("[\\LINK]", string.Empty);
							int intStart = strMyTitle.IndexOf("[LINK");
							int intEnd = strMyTitle.IndexOf("]");
							if (intStart > 0 && intEnd != intStart)
							{
								intEnd += 1;
								string strChop = strMyTitle.Substring(intStart, intEnd - intStart);
								strMyTitle = strMyTitle.Replace(strChop, string.Empty);
							}
							strActions += "<a href=\"" + objPrereq["Type"].InnerText.Replace("BUILD_", "IMPROVEMENT_") + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText.Replace("BUILD_", "IMPROVEMENT_") + ".png\" /></a>";
						}
					}
				}
				if (strActions != "")
					strActions += "</div></div></div></div></div></div></div></div>";

				// Look for Special Abilities this unlocks.
				string strSpecial = "";

				// Look for Special Abilities in the Improvements files.
				foreach (string strBuildsFile in _lstImprovements)
				{
					XmlDocument objUnitsDocument = new XmlDocument();
					objUnitsDocument.Load(strBuildsFile);
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Improvement_TechFreshWaterYieldChanges/Row[TechType = \"" + objTechnology["Type"].InnerText + "\"]"))
						strSpecial += TXT_KEY_ABLTY_FRESH_WATER_STRING + " " + GetName(objPrereq["ImprovementType"].InnerText) + " " + TXT_KEY_ABLTY_YIELD_IMPRVD_STRING + " " + objPrereq["Yield"].InnerText + "<br />";
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Improvement_TechNoFreshWaterYieldChanges/Row[TechType = \"" + objTechnology["Type"].InnerText + "\"]"))
						strSpecial += TXT_KEY_ABLTY_NO_FRESH_WATER_STRING + " " + GetName(objPrereq["ImprovementType"].InnerText) + " " + TXT_KEY_ABLTY_YIELD_IMPRVD_STRING + " " + objPrereq["Yield"].InnerText + "<br />";
					foreach (XmlNode objPrereq in objUnitsDocument.SelectNodes("/GameData/Improvement_TechYieldChanges/Row[TechType = \"" + objTechnology["Type"].InnerText + "\"]"))
						strSpecial += GetName(objPrereq["ImprovementType"].InnerText) + " " + GetString("TXT_KEY_" + objPrereq["YieldType"].InnerText) + " " + TXT_KEY_ABLTY_YIELD_IMPRVD_STRING + " " + objPrereq["Yield"].InnerText + "<br />";
				}

				// BridgeBuilding.
				if (objTechnology["BridgeBuilding"] != null)
				{
					if (objTechnology["BridgeBuilding"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ABLTY_BRIDGE_STRING") + "<br />";
				}
				// AllowsEmbarking.
				if (objTechnology["AllowsEmbarking"] != null)
				{
					if (objTechnology["AllowsEmbarking"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ALLOWS_EMBARKING") + "<br />";
				}
				// DefensivePactTradingAllowed.
				if (objTechnology["DefensivePactTradingAllowed"] != null)
				{
					if (objTechnology["DefensivePactTradingAllowed"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ALLOWS_DEFENSIVE_PACTS") + "<br />";
				}
				// OpenBordersTradingAllowed.
				if (objTechnology["OpenBordersTradingAllowed"] != null)
				{
					if (objTechnology["OpenBordersTradingAllowed"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ABLTY_OPEN_BORDER_STRING") + "<br />";
				}
				//ResearchAgreementTradingAllowed.
				if (objTechnology["ResearchAgreementTradingAllowed"] != null)
				{
					if (objTechnology["ResearchAgreementTradingAllowed"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ABLTY_R_PACT_STRING") + "<br />";
				}
				// EmbarkedMoveChange.
				if (objTechnology["EmbarkedMoveChange"] != null)
					strSpecial += GetString("TXT_KEY_ABLTY_FAST_EMBARK_STRING") + "<br />";
				// EmbarkedAllWaterPassage.
				if (objTechnology["EmbarkedAllWaterPassage"] != null)
				{
					if (objTechnology["EmbarkedAllWaterPassage"].InnerText == "true")
						strSpecial += GetString("TXT_KEY_ABLTY_OCEAN_EMBARK_STRING") + "<br />";
				}
				
				// Check for Movement rate changes.
				XmlDocument objRoutesDocument = MergeXml(_lstRoutes);
				XmlNode objRouteNode = objRoutesDocument.SelectSingleNode("/GameData/Route_TechMovementChanges/Row[TechType = \"" + objTechnology["Type"].InnerText + "\"]");
				if (objRouteNode != null)
					strSpecial += GetString("TXT_KEY_ABLTY_FASTER_MOVEMENT_STRING") + " " + GetName(objRouteNode["RouteType"].InnerText);

				if (strSpecial != "")
				{
					string strMySpecial = strSpecial;
					strSpecial = "<h2>" + TXT_KEY_PEDIA_ABILITIES_LABEL + "</h2>";
					strSpecial += "<div class=\"t\">";
					strSpecial += "<div class=\"b\">";
					strSpecial += "<div class=\"l\">";
					strSpecial += "<div class=\"r\">";
					strSpecial += "<div class=\"bl\">";
					strSpecial += "<div class=\"br\">";
					strSpecial += "<div class=\"tl\">";
					strSpecial += "<div class=\"tr\">";
					strSpecial += strMySpecial;
					strSpecial += "</div></div></div></div></div></div></div></div>";
				}

				string strOutput = strTeplate;
				strOutput = strOutput.Replace("##TITLE##", strTitle);
				strOutput = strOutput.Replace("##HELP##", strHelp);
				strOutput = strOutput.Replace("##QUOTE##", strQuote);
				strOutput = strOutput.Replace("##DESC##", strDesc);
				strOutput = strOutput.Replace("##COST##", strCost);
				strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
				strOutput = strOutput.Replace("##PREREQ##", strPrereq);
				strOutput = strOutput.Replace("##LEADS##", strLeads);
				strOutput = strOutput.Replace("##UNITS##", strUnits);
				strOutput = strOutput.Replace("##BUILDINGS##", strBuildings);
				strOutput = strOutput.Replace("##RESOURCES##", strResources);
				strOutput = strOutput.Replace("##ACTIONS##", strActions);
				strOutput = strOutput.Replace("##PROJECTS##", strProjects);
				strOutput = strOutput.Replace("##SPECIAL##", strSpecial);

				// Create a GroupItem for this Tech.
				GroupItem objItem = new GroupItem();
				objItem.Key = objTechnology["Type"].InnerText;
				objItem.Name = strTitle;

				// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
				Group objGroup = new Group();
				foreach (Group objCurrentGroup in lstGroups)
				{
					if (objCurrentGroup.Key == objTechnology["Era"].InnerText)
					{
						objGroup = objCurrentGroup;
						break;
					}
				}
				objGroup.GroupItems.Add(objItem);

				_strXml += "\t\t<page>";
				_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
				_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
				_strXml += "\t\t</page>";

				// Create the Image.
				if (_strLanguage == "en_US")
				{
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
				}

				File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_TECHNOLOGIES_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"TECH_HOME.aspx\"><div id=\"TECH_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Technologies.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Units pages.
		/// </summary>
		private void GenerateUnits()
		{
			txtDebug.Text += "\r\nGenerating Units...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = CreateEraGroups(true);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_UNITS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_UNITS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_UNITS_HELP_TEXT");
			const string strHomeImage = "UNIT_ARCHER";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Units";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "UNIT_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_UNITS.aspx"));
			foreach (String strXmlFile in _lstUnits)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Units/Row"))
				{
					bool blnGreatPerson = false;
					if (objTechnology["Special"] != null)
					{
						blnGreatPerson = (objTechnology["Special"].InnerText == "SPECIALUNIT_PEOPLE");
					}

					// Ignore the Barbarians (except for Brute) and Great People.
					bool blnCreate = true;
					if (blnGreatPerson)
						blnCreate = false;
					if (objTechnology["Type"].InnerText.StartsWith("UNIT_BARBARIAN"))
					{
						blnCreate = false;
						if (objTechnology["Type"].InnerText.StartsWith("UNIT_BARBARIAN_WARRIOR"))
							blnCreate = true;
						if (objTechnology["Type"].InnerText.StartsWith("UNIT_BARBARIAN_AXMAN"))
							blnCreate = true;
					}

					if (blnCreate)
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strHelp = "";
						try
						{
							strHelp = GetString(objTechnology["Help"].InnerText);
							if (strHelp != "")
							{
								string strMyHelp = strHelp;
								strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
								strHelp += "<div class=\"t\">";
								strHelp += "<div class=\"b\">";
								strHelp += "<div class=\"l\">";
								strHelp += "<div class=\"r\">";
								strHelp += "<div class=\"bl\">";
								strHelp += "<div class=\"br\">";
								strHelp += "<div class=\"tl\">";
								strHelp += "<div class=\"tr\">";
								strHelp += strMyHelp;
								strHelp += "</div></div></div></div></div></div></div></div>";
							}
						}
						catch
						{
						}
						string strStrategy = "";
						try
						{
							strStrategy = GetString(objTechnology["Strategy"].InnerText);
							string strMyStrategy = strStrategy;
							strStrategy = "<h2>" + TXT_KEY_PEDIA_STRATEGY_LABEL + "</h2>";
							strStrategy += "<div class=\"t\">";
							strStrategy += "<div class=\"b\">";
							strStrategy += "<div class=\"l\">";
							strStrategy += "<div class=\"r\">";
							strStrategy += "<div class=\"bl\">";
							strStrategy += "<div class=\"br\">";
							strStrategy += "<div class=\"tl\">";
							strStrategy += "<div class=\"tr\">";
							strStrategy += strMyStrategy;
							strStrategy += "</div></div></div></div></div></div></div></div>";
						}
						catch
						{
						}
						string strDesc = "";
						try
						{
							strDesc = GetString(objTechnology["Civilopedia"].InnerText);
							string strMyDesc = strDesc;
							strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
							strDesc += "<div class=\"t\">";
							strDesc += "<div class=\"b\">";
							strDesc += "<div class=\"l\">";
							strDesc += "<div class=\"r\">";
							strDesc += "<div class=\"bl\">";
							strDesc += "<div class=\"br\">";
							strDesc += "<div class=\"tl\">";
							strDesc += "<div class=\"tr\">";
							strDesc += strMyDesc;
							strDesc += "</div></div></div></div></div></div></div></div>";
						}
						catch
						{
						}
						string strMoves = objTechnology["Moves"].InnerText + " <img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />";
						string strMyMoves = strMoves;
						strMoves = "<h2>" + TXT_KEY_PEDIA_MOVEMENT_LABEL + "</h2>";
						strMoves += "<div class=\"t\">";
						strMoves += "<div class=\"b\">";
						strMoves += "<div class=\"l\">";
						strMoves += "<div class=\"r\">";
						strMoves += "<div class=\"bl\">";
						strMoves += "<div class=\"br\">";
						strMoves += "<div class=\"tl\">";
						strMoves += "<div class=\"tr\">";
						strMoves += strMyMoves;
						strMoves += "</div></div></div></div></div></div></div></div>";

						string strCost = "";
						if (objTechnology["Cost"] != null)
						{
							if (objTechnology["Cost"].InnerText != "-1")
								strCost = objTechnology["Cost"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" />";
						}
						if (objTechnology["FaithCost"] != null)
						{
							if (strCost != string.Empty)
								strCost += " / ";
							strCost += objTechnology["FaithCost"].InnerText + " <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" />";
						}
						
						//if (strCost == string.Empty)
						//	strCost = "FREE";
						if (strCost != string.Empty)
						{
							string strMyCost = strCost;
							strCost = "<h2>" + TXT_KEY_PEDIA_COST_LABEL + "</h2>";
							strCost += "<div class=\"t\">";
							strCost += "<div class=\"b\">";
							strCost += "<div class=\"l\">";
							strCost += "<div class=\"r\">";
							strCost += "<div class=\"bl\">";
							strCost += "<div class=\"br\">";
							strCost += "<div class=\"tl\">";
							strCost += "<div class=\"tr\">";
							strCost += strMyCost;
							strCost += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Combat.
						string strCombat = "";
						if (objTechnology["Combat"] != null)
						{
							strCombat += "<h2>" + TXT_KEY_PEDIA_COMBAT_LABEL + "</h2>";
							strCombat += "<div class=\"t\">";
							strCombat += "<div class=\"b\">";
							strCombat += "<div class=\"l\">";
							strCombat += "<div class=\"r\">";
							strCombat += "<div class=\"bl\">";
							strCombat += "<div class=\"br\">";
							strCombat += "<div class=\"tl\">";
							strCombat += "<div class=\"tr\">";
							strCombat += objTechnology["Combat"].InnerText + " <img src=\"/civilopedia/images/strength.png\" alt=\"strength\" />";
							strCombat += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Ranged Combat.
						string strRangedCombat = "";
						if (objTechnology["RangedCombat"] != null)
						{
							strRangedCombat += "<h2>" + TXT_KEY_PEDIA_RANGEDCOMBAT_LABEL + "</h2>";
							strRangedCombat += "<div class=\"t\">";
							strRangedCombat += "<div class=\"b\">";
							strRangedCombat += "<div class=\"l\">";
							strRangedCombat += "<div class=\"r\">";
							strRangedCombat += "<div class=\"bl\">";
							strRangedCombat += "<div class=\"br\">";
							strRangedCombat += "<div class=\"tl\">";
							strRangedCombat += "<div class=\"tr\">";
							strRangedCombat += objTechnology["RangedCombat"].InnerText + " <img src=\"/civilopedia/images/range_strength.png\" alt=\"range strength\" />";
							strRangedCombat += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Range.
						string strRange = "";
						if (objTechnology["RangedCombat"] != null)
						{
							strRange += "<h2>" + TXT_KEY_PEDIA_RANGE_LABEL + "</h2>";
							strRange += "<div class=\"t\">";
							strRange += "<div class=\"b\">";
							strRange += "<div class=\"l\">";
							strRange += "<div class=\"r\">";
							strRange += "<div class=\"bl\">";
							strRange += "<div class=\"br\">";
							strRange += "<div class=\"tl\">";
							strRange += "<div class=\"tr\">";
							strRange += objTechnology["Range"].InnerText;
							strRange += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Prereq Tech.
						string strPrereq = "";
						string strEraKey = "ERA_ANCIENT";
						if (objTechnology["PrereqTech"] != null)
						{
							foreach (string strTechXmlFile in _lstTechnologies)
							{
								XmlDocument objTechDocument = new XmlDocument();
								objTechDocument.Load(strTechXmlFile);
								foreach (XmlNode objPrereq in objTechDocument.SelectNodes("/GameData/Technologies/Row[Type = \"" + objTechnology["PrereqTech"].InnerText + "\"]"))
								{
									if (strPrereq == "")
									{
										strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
										strPrereq += "<div class=\"t\">";
										strPrereq += "<div class=\"b\">";
										strPrereq += "<div class=\"l\">";
										strPrereq += "<div class=\"r\">";
										strPrereq += "<div class=\"bl\">";
										strPrereq += "<div class=\"br\">";
										strPrereq += "<div class=\"tl\">";
										strPrereq += "<div class=\"tr\">";
									}
									string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["Type"].InnerText);
									strPrereq += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
									// A Unit's Era matches the Era of the Technology that unlocks it.
									strEraKey = objPrereq["Era"].InnerText;
								}
							}
							if (strPrereq != "")
								strPrereq += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Obsolete Tech.
						string strObsolete = "";
						if (objTechnology["ObsoleteTech"] != null)
						{
							foreach (string strTechXmlFile in _lstTechnologies)
							{
								XmlDocument objTechDocument = new XmlDocument();
								objTechDocument.Load(strTechXmlFile);
								foreach (XmlNode objPrereq in objTechDocument.SelectNodes("/GameData/Technologies/Row[Type = \"" + objTechnology["ObsoleteTech"].InnerText + "\"]"))
								{
									if (strObsolete == "")
									{
										strObsolete += "<h2>" + TXT_KEY_PEDIA_OBSOLETE_TECH_LABEL + "</h2>";
										strObsolete += "<div class=\"t\">";
										strObsolete += "<div class=\"b\">";
										strObsolete += "<div class=\"l\">";
										strObsolete += "<div class=\"r\">";
										strObsolete += "<div class=\"bl\">";
										strObsolete += "<div class=\"br\">";
										strObsolete += "<div class=\"tl\">";
										strObsolete += "<div class=\"tr\">";
									}
									string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["Type"].InnerText);
									strObsolete += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
								}
							}
							if (strObsolete != "")
								strObsolete += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Upgrades.
						string strUpgrade = "";
						List<string> lstSeenUpgrades = new List<string>();
						foreach (string strUnitFile in _lstUnits)
						{
							XmlDocument objUnitDoc = new XmlDocument();
							objUnitDoc.Load(strUnitFile);

							XmlNode objUpgradeClass = objUnitDoc.SelectSingleNode("/GameData/Unit_ClassUpgrades/Row[UnitType = \"" + objTechnology["Type"].InnerText + "\"]");
							if (objUpgradeClass != null)
							{
								foreach (string strClassFile in _lstUnitClasses)
								{
									XmlDocument objClassDoc = new XmlDocument();
									objClassDoc.Load(strClassFile);

									XmlNode objClass = objClassDoc.SelectSingleNode("/GameData/UnitClasses/Row[Type = \"" + objUpgradeClass["UnitClassType"].InnerText + "\"]");
									if (objClass != null)
									{
										bool blnCreateUpgrade = true;
										foreach (string strUnit in lstSeenUpgrades)
										{
											if (strUnit == objClass["DefaultUnit"].InnerText)
												blnCreateUpgrade = false;
										}

										if (blnCreateUpgrade)
										{
											lstSeenUpgrades.Add(objClass["DefaultUnit"].InnerText);
											string strMyTitle = FindDescription(_lstUnits, "Units", objClass["DefaultUnit"].InnerText);
											strUpgrade += "<a href=\"" + objClass["DefaultUnit"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objClass["DefaultUnit"].InnerText + ".png\" /></a>";
										}
									}
								}
							}
						}
						if (strUpgrade != "")
						{
							string strMyUpgrade = strUpgrade;
							strUpgrade = "<h2>" + TXT_KEY_COMMAND_UPGRADE + "</h2>";
							strUpgrade += "<div class=\"t\">";
							strUpgrade += "<div class=\"b\">";
							strUpgrade += "<div class=\"l\">";
							strUpgrade += "<div class=\"r\">";
							strUpgrade += "<div class=\"bl\">";
							strUpgrade += "<div class=\"br\">";
							strUpgrade += "<div class=\"tl\">";
							strUpgrade += "<div class=\"tr\">";
							strUpgrade += strMyUpgrade;
							strUpgrade += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Civilization.
						string strCivilization = "";
						string strReplaces = "";
						foreach (string strCivXmlFile in _lstCivilizations)
						{
							XmlDocument objCivDocument = new XmlDocument();
							objCivDocument.Load(strCivXmlFile);
							foreach (XmlNode objPrereq in objCivDocument.SelectNodes("/GameData/Civilization_UnitClassOverrides/Row[UnitType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								if (objPrereq["CivilizationType"].InnerText != "CIVILIZATION_BARBARIAN")
								{
									strCivilization += "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
									strCivilization += "<div class=\"t\">";
									strCivilization += "<div class=\"b\">";
									strCivilization += "<div class=\"l\">";
									strCivilization += "<div class=\"r\">";
									strCivilization += "<div class=\"bl\">";
									strCivilization += "<div class=\"br\">";
									strCivilization += "<div class=\"tl\">";
									strCivilization += "<div class=\"tr\">";
									string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objPrereq["CivilizationType"].InnerText);
									strCivilization += "<a href=\"" + objPrereq["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["CivilizationType"].InnerText + ".png\" /></a>";

									// Locate the replaced Units.
									foreach (string strUnitXmlFile in _lstUnitClasses)
									{
										XmlDocument objBuildingDoc = new XmlDocument();
										objBuildingDoc.Load(strUnitXmlFile);
										XmlNode objReplace = objBuildingDoc.SelectSingleNode("/GameData/UnitClasses/Row[Type = \"" + objPrereq["UnitClassType"].InnerText + "\"]");
										if (objReplace != null)
										{
											strReplaces += "<h2>" + TXT_KEY_PEDIA_REPLACES_LABEL + "</h2>";
											strReplaces += "<div class=\"t\">";
											strReplaces += "<div class=\"b\">";
											strReplaces += "<div class=\"l\">";
											strReplaces += "<div class=\"r\">";
											strReplaces += "<div class=\"bl\">";
											strReplaces += "<div class=\"br\">";
											strReplaces += "<div class=\"tl\">";
											strReplaces += "<div class=\"tr\">";
											string strMyUnitTitle = FindDescription(_lstUnits, "Units", objReplace["DefaultUnit"].InnerText);
											strReplaces += "<a href=\"" + objReplace["DefaultUnit"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyUnitTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objReplace["DefaultUnit"].InnerText + ".png\" /></a>";
										}
									}
								}
							}
						}
						if (strCivilization != "")
							strCivilization += "</div></div></div></div></div></div></div></div>";
						if (strReplaces != "")
							strReplaces += "</div></div></div></div></div></div></div></div>";

						// Look for Combat Type.
						string strCombatType = "";
						if (objTechnology["CombatClass"] != null)
						{
							strCombatType += "<h2>" + TXT_KEY_PEDIA_COMBATTYPE_LABEL + "</h2>";
							strCombatType += "<div class=\"t\">";
							strCombatType += "<div class=\"b\">";
							strCombatType += "<div class=\"l\">";
							strCombatType += "<div class=\"r\">";
							strCombatType += "<div class=\"bl\">";
							strCombatType += "<div class=\"br\">";
							strCombatType += "<div class=\"tl\">";
							strCombatType += "<div class=\"tr\">";
							foreach (string strInfoFile in _lstCombatInfos)
							{
								XmlDocument objInfoDoc = new XmlDocument();
								objInfoDoc.Load(strInfoFile);
								XmlNode objInfo = objInfoDoc.SelectSingleNode("/GameData/UnitCombatInfos/Row[Type = \"" + objTechnology["CombatClass"].InnerText + "\"]");
								if (objInfo != null)
								{
									strCombatType += GetString(objInfo["Description"].InnerText);
									break;
								}
							}
						}
						if (strCombatType != "")
							strCombatType += "</div></div></div></div></div></div></div></div>";

						// Look for Abilities.
						string strAbilities = "";
						foreach (XmlNode objAbility in objDocument.SelectNodes("/GameData/Unit_FreePromotions/Row[UnitType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							foreach (string strPromotionFile in _lstPromotions)
							{
								XmlDocument objPromotionDoc = new XmlDocument();
								objPromotionDoc.Load(strPromotionFile);
								XmlNode objPromotion = objPromotionDoc.SelectSingleNode("/GameData/UnitPromotions/Row[Type = \"" + objAbility["PromotionType"].InnerText + "\"]");
								if (objPromotion != null)
								{
									string strMyTitle = FindDescription(_lstPromotions, "UnitPromotions", objAbility["PromotionType"].InnerText);
									string strImage = "";
									if (objPromotion["IconAtlas"].InnerText.StartsWith("EXPANSION"))
										strImage = "EXP_" + objPromotion["PortraitIndex"].InnerText;
									else
										strImage = objPromotion["PortraitIndex"].InnerText;
									strAbilities += "<a href=\"" + objAbility["PromotionType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/PROMOTION_" + strImage + ".png\" /></a>";
									break;
								}
							}
						}
						if (strAbilities != "")
						{
							string strMyAbilities = strAbilities;
							strAbilities = "<h2>" + TXT_KEY_PEDIA_FREEPROMOTIONS_LABEL + "</h2>";
							strAbilities += "<div class=\"t\">";
							strAbilities += "<div class=\"b\">";
							strAbilities += "<div class=\"l\">";
							strAbilities += "<div class=\"r\">";
							strAbilities += "<div class=\"bl\">";
							strAbilities += "<div class=\"br\">";
							strAbilities += "<div class=\"tl\">";
							strAbilities += "<div class=\"tr\">";
							strAbilities += strMyAbilities;
							strAbilities += "</div></div></div></div></div></div></div></div>";
						}

						// Look for Required Resources.
						string strResources = "";
						XmlNode objResources = objDocument.SelectSingleNode("/GameData/Unit_ResourceQuantityRequirements/Row[UnitType = \"" + objTechnology["Type"].InnerText + "\"]");
						if (objResources != null)
						{
							strResources += "<h2>" + TXT_KEY_PEDIA_REQ_RESRC_LABEL + "</h2>";
							strResources += "<div class=\"t\">";
							strResources += "<div class=\"b\">";
							strResources += "<div class=\"l\">";
							strResources += "<div class=\"r\">";
							strResources += "<div class=\"bl\">";
							strResources += "<div class=\"br\">";
							strResources += "<div class=\"tl\">";
							strResources += "<div class=\"tr\">";
							string strMyTitle = FindDescription(_lstResources, "Resources", objResources["ResourceType"].InnerText);
							strResources += "<a href=\"" + objResources["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objResources["ResourceType"].InnerText + ".png\" /></a>";
						}
						if (strResources != "")
							strResources += "</div></div></div></div></div></div></div></div>";

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##HELP##", strHelp);
						strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
						strOutput = strOutput.Replace("##DESC##", strDesc);
						strOutput = strOutput.Replace("##COST##", strCost);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
						strOutput = strOutput.Replace("##COMBAT##", strCombat);
						strOutput = strOutput.Replace("##RANGEDCOMBAT##", strRangedCombat);
						strOutput = strOutput.Replace("##RANGE##", strRange);
						strOutput = strOutput.Replace("##MOVES##", strMoves);
						strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);
						strOutput = strOutput.Replace("##PREREQ##", strPrereq);
						strOutput = strOutput.Replace("##RESOURCES##", strResources);
						strOutput = strOutput.Replace("##OBSOLETE##", strObsolete);
						strOutput = strOutput.Replace("##UPGRADE##", strUpgrade);
						strOutput = strOutput.Replace("##REPLACES##", strReplaces);
						strOutput = strOutput.Replace("##COMBATTYPE##", strCombatType);
						strOutput = strOutput.Replace("##ABILITIES##", strAbilities);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == strEraKey)
							{
								objGroup = objCurrentGroup;
								break;
							}
						}
						// Force Religious units into the Religious group.
						if (objTechnology["ReligiousStrength"] != null)
							objGroup = lstGroups[0];
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_UNITS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"UNIT_HOME.aspx\"><div id=\"UNIT_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Units.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Promotion pages.
		/// </summary>
		private void GeneratePromotions()
		{
			txtDebug.Text += "\r\nGenerating Promotions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objGroupMelee = new Group();
			objGroupMelee.Key = "PEDIA_MELEE";
			objGroupMelee.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_1");
			lstGroups.Add(objGroupMelee);

			Group objGroupRanged = new Group();
			objGroupRanged.Key = "PEDIA_RANGED";
			objGroupRanged.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_2");
			lstGroups.Add(objGroupRanged);

			Group objGroupNaval = new Group();
			objGroupNaval.Key = "PEDIA_NAVAL";
			objGroupNaval.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_3");
			lstGroups.Add(objGroupNaval);

			Group objGroupHealing = new Group();
			objGroupHealing.Key = "PEDIA_HEAL";
			objGroupHealing.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_4");
			lstGroups.Add(objGroupHealing);

			Group objGroupScouting = new Group();
			objGroupScouting.Key = "PEDIA_SCOUTING";
			objGroupScouting.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_5");
			lstGroups.Add(objGroupScouting);

			Group objGroupAir = new Group();
			objGroupAir.Key = "PEDIA_AIR";
			objGroupAir.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_6");
			lstGroups.Add(objGroupAir);

			Group objGroupShared = new Group();
			objGroupShared.Key = "PEDIA_SHARED";
			objGroupShared.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_7");
			lstGroups.Add(objGroupShared);

			Group objGroupAttributes = new Group();
			objGroupAttributes.Key = "PEDIA_ATTRIBUTES";
			objGroupAttributes.Name = GetString("TXT_KEY_PROMOTIONS_SECTION_8");
			lstGroups.Add(objGroupAttributes);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_PROMOTIONS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_PROMOTIONS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_PROMOTIONS_HELP_TEXT");
			const string strHomeImage = "PROMOTION_59";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Promotions";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "PROMOTION_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_PROMOTIONS.aspx"));
			foreach (string strXmlFile in _lstPromotions)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/UnitPromotions/Row"))
				{
					if (objTechnology["PediaType"] != null)
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strHelp = GetString(objTechnology["Help"].InnerText);
						string strMyHelp = strHelp;
						strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
						strHelp += "<div class=\"t\">";
						strHelp += "<div class=\"b\">";
						strHelp += "<div class=\"l\">";
						strHelp += "<div class=\"r\">";
						strHelp += "<div class=\"bl\">";
						strHelp += "<div class=\"br\">";
						strHelp += "<div class=\"tl\">";
						strHelp += "<div class=\"tr\">";
						strHelp += strMyHelp;
						strHelp += "</div></div></div></div></div></div></div></div>";

						// Determine Prerequisite Promotions.
						string strPrereq = "";
						for (int i = 1; i <= 10; i++)
						{
							if (objTechnology["PromotionPrereqOr" + i.ToString()] != null)
							{
								if (strPrereq == "")
								{
									strPrereq += "<h2>" + TXT_KEY_PEDIA_REQ_PROMOTIONS_LABEL + "</h2>";
									strPrereq += "<div class=\"t\">";
									strPrereq += "<div class=\"b\">";
									strPrereq += "<div class=\"l\">";
									strPrereq += "<div class=\"r\">";
									strPrereq += "<div class=\"bl\">";
									strPrereq += "<div class=\"br\">";
									strPrereq += "<div class=\"tl\">";
									strPrereq += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstPromotions, "UnitPromotions", objTechnology["PromotionPrereqOr" + i.ToString()].InnerText);
								string strImage = "";
								// Find the Node for the Prerequisite Promotion so we can grab its PortraitIndex number.
								XmlNode objPrereq = objDocument.SelectSingleNode("/GameData/UnitPromotions/Row[Type = \"" + objTechnology["PromotionPrereqOr" + i.ToString()].InnerText + "\"]");
								strImage = objTechnology["IconAtlas"].InnerText + objTechnology["PortraitIndex"].InnerText;
								strPrereq += "<a href=\"" + objTechnology["PromotionPrereqOr" + i.ToString()].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/PROMOTION_" + strImage + ".png\" /></a>";
							}
						}
						if (strPrereq != "")
							strPrereq += "</div></div></div></div></div></div></div></div>";

						string strThisImage = "";
						strThisImage = objTechnology["IconAtlas"].InnerText + objTechnology["PortraitIndex"].InnerText;
						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##HELP##", strHelp);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
						strOutput = strOutput.Replace("##PREREQ##", strPrereq);
						strOutput = strOutput.Replace("##IMAGE##", "PROMOTION_" + strThisImage);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;
						objItem.Image = "PROMOTION_" + strThisImage;

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == objTechnology["PediaType"].InnerText)
							{
								objGroup = objCurrentGroup;
								break;
							}
						}
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage("PROMOTION_" + strThisImage, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage("PROMOTION_" + strThisImage, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_PROMOTIONS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"PROMOTION_HOME.aspx\"><div id=\"PROMOTION_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Image + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Promotions.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Buildings pages.
		/// </summary>
		private void GenerateBuildings()
		{
			XmlDocument objBuildingDocument = MergeXml(_lstBuildings);
			XmlDocument objBuildingClassesDocument = MergeXml(_lstBuildingClasses);

			txtDebug.Text += "\r\nGenerating Buildings...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = CreateEraGroups(true);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_BUILDINGS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_BUILDINGS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_BUILDINGS_HELP_TEXT");
			const string strHomeImage = "BUILDING_BARRACKS";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Buildings";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "BUILDING_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_BUILDINGS.aspx"));
			XmlDocument objDocument = objBuildingDocument;

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Buildings/Row"))
			{
				string strBuildingClass = "";
				XmlDocument objClassDoc = objBuildingClassesDocument;
				XmlNode objClass = objClassDoc.SelectSingleNode("/GameData/BuildingClasses/Row[Type = \"" + objTechnology["BuildingClass"].InnerText + "\"]");
				// Determine the Building type (Building, National Wonder, or World Wonder) based on the existance of MaxPlayerInstances or MaxGlobalInstances.
				if (objClass != null)
				{
					if (objClass["MaxPlayerInstances"] != null)
						strBuildingClass = "NATIONAL_WONDER";
					else if (objClass["MaxGlobalInstances"] != null)
						strBuildingClass = "WORLD_WONDER";
					else
						strBuildingClass = "BUILDING";

					// Fix for the Recycling Center, Writers' Guild, Artists' Guild, and Musicians' Guild which all have a MaxPlayerInstances value but are actually buildings.
					if (objTechnology["Type"].InnerText == "BUILDING_RECYCLING_CENTER" || objTechnology["Type"].InnerText == "BUILDING_WRITERS_GUILD" || objTechnology["Type"].InnerText == "BUILDING_ARTISTS_GUILD" || objTechnology["Type"].InnerText == "BUILDING_MUSICIANS_GUILD")
						strBuildingClass = "BUILDING";
				}

				// Only write out Buildings.
				if (strBuildingClass == "BUILDING")
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					// If Help and Strategy are the same, discard Help.
					if (objTechnology["Help"] != null && objTechnology["Strategy"] != null)
					{
						if (objTechnology["Help"].InnerText == objTechnology["Strategy"].InnerText)
							strHelp = "";
					}
					string strDesc = "";
					try
					{
						strDesc = GetString(objTechnology["Civilopedia"].InnerText);
						string strMyDesc = strDesc;
						strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
						strDesc += "<div class=\"t\">";
						strDesc += "<div class=\"b\">";
						strDesc += "<div class=\"l\">";
						strDesc += "<div class=\"r\">";
						strDesc += "<div class=\"bl\">";
						strDesc += "<div class=\"br\">";
						strDesc += "<div class=\"tl\">";
						strDesc += "<div class=\"tr\">";
						strDesc += strMyDesc;
						strDesc += "</div></div></div></div></div></div></div></div>";
					}
					catch
					{
					}
					string strStrategy = "";
					try
					{
						strStrategy = GetString(objTechnology["Strategy"].InnerText);
						string strMyStrategy = strStrategy;
						strStrategy = "<h2>" + TXT_KEY_PEDIA_STRATEGY_LABEL + "</h2>";
						strStrategy += "<div class=\"t\">";
						strStrategy += "<div class=\"b\">";
						strStrategy += "<div class=\"l\">";
						strStrategy += "<div class=\"r\">";
						strStrategy += "<div class=\"bl\">";
						strStrategy += "<div class=\"br\">";
						strStrategy += "<div class=\"tl\">";
						strStrategy += "<div class=\"tr\">";
						strStrategy += strMyStrategy;
						strStrategy += "</div></div></div></div></div></div></div></div>";
					}
					catch
					{
					}

					string strCost = "";
					if (objTechnology["Cost"] != null)
					{
						if (objTechnology["Cost"].InnerText != "-1")
							strCost = objTechnology["Cost"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" />";
					}
					if (objTechnology["FaithCost"] != null)
					{
						if (strCost != string.Empty)
							strCost += " / ";
						strCost += objTechnology["FaithCost"].InnerText + " <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" />";
					}
					if (strCost != string.Empty)
					{
						string strMyCost = strCost;
						strCost = "<h2>" + TXT_KEY_PEDIA_COST_LABEL + "</h2>";
						strCost += "<div class=\"t\">";
						strCost += "<div class=\"b\">";
						strCost += "<div class=\"l\">";
						strCost += "<div class=\"r\">";
						strCost += "<div class=\"bl\">";
						strCost += "<div class=\"br\">";
						strCost += "<div class=\"tl\">";
						strCost += "<div class=\"tr\">";
						strCost += strMyCost;
						strCost += "</div></div></div></div></div></div></div></div>";
					}

					string strMaintenance = "";
					if (objTechnology["GoldMaintenance"] != null)
					{
						if (objTechnology["GoldMaintenance"].InnerText != "0")
						{
							strMaintenance += "<h2>" + TXT_KEY_PEDIA_MAINT_LABEL + "</h2>";
							strMaintenance += "<div class=\"t\">";
							strMaintenance += "<div class=\"b\">";
							strMaintenance += "<div class=\"l\">";
							strMaintenance += "<div class=\"r\">";
							strMaintenance += "<div class=\"bl\">";
							strMaintenance += "<div class=\"br\">";
							strMaintenance += "<div class=\"tl\">";
							strMaintenance += "<div class=\"tr\">";
							strMaintenance += objTechnology["GoldMaintenance"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" />";
							strMaintenance += "</div></div></div></div></div></div></div></div>";
						}
					}

					// Look for Prereq Tech.
					string strPrereq = "";
					string strEraKey = "ERA_ANCIENT";
					if (objTechnology["PrereqTech"] != null)
					{
						foreach (string strTechXmlFile in _lstTechnologies)
						{
							XmlDocument objTechDocument = new XmlDocument();
							objTechDocument.Load(strTechXmlFile);
							foreach (XmlNode objPrereq in objTechDocument.SelectNodes("/GameData/Technologies/Row[Type = \"" + objTechnology["PrereqTech"].InnerText + "\"]"))
							{
								if (strPrereq == "")
								{
									strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
									strPrereq += "<div class=\"t\">";
									strPrereq += "<div class=\"b\">";
									strPrereq += "<div class=\"l\">";
									strPrereq += "<div class=\"r\">";
									strPrereq += "<div class=\"bl\">";
									strPrereq += "<div class=\"br\">";
									strPrereq += "<div class=\"tl\">";
									strPrereq += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["Type"].InnerText);
								strPrereq += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
								// A Buildings's Era matches the Era of the Technology that unlocks it.
								strEraKey = objPrereq["Era"].InnerText;
							}
						}
						if (strPrereq != "")
							strPrereq += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Civilization.
					List<string> lstSeenCivs = new List<string>();
					string strCivilization = "";
					string strReplaces = "";
					foreach (string strCivXmlFile in _lstCivilizations)
					{
						XmlDocument objCivDocument = new XmlDocument();
						objCivDocument.Load(strCivXmlFile);
						foreach (XmlNode objPrereq in objCivDocument.SelectNodes("/GameData/Civilization_BuildingClassOverrides/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							// Make sure we have not already seen this Civ for the Building.
							bool blnContinue = true;
							foreach (string strSeenCiv in lstSeenCivs)
							{
								if (strSeenCiv == objPrereq["CivilizationType"].InnerText)
								{
									blnContinue = false;
									break;
								}
							}

							if (blnContinue)
							{
								lstSeenCivs.Add(objPrereq["CivilizationType"].InnerText);
								strCivilization += "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
								strCivilization += "<div class=\"t\">";
								strCivilization += "<div class=\"b\">";
								strCivilization += "<div class=\"l\">";
								strCivilization += "<div class=\"r\">";
								strCivilization += "<div class=\"bl\">";
								strCivilization += "<div class=\"br\">";
								strCivilization += "<div class=\"tl\">";
								strCivilization += "<div class=\"tr\">";
								string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objPrereq["CivilizationType"].InnerText);
								strCivilization += "<a href=\"" + objPrereq["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["CivilizationType"].InnerText + ".png\" /></a>";

								// Locate the replaced building.
								foreach (string strBuildingXmlFile in _lstBuildingClasses)
								{
									XmlDocument objBuildingDoc = new XmlDocument();
									objBuildingDoc.Load(strBuildingXmlFile);
									XmlNode objReplace = objBuildingDoc.SelectSingleNode("/GameData/BuildingClasses/Row[Type = \"" + objPrereq["BuildingClassType"].InnerText + "\"]");
									if (objReplace != null)
									{
										strReplaces += "<h2>" + TXT_KEY_PEDIA_REPLACES_LABEL + "</h2>";
										strReplaces += "<div class=\"t\">";
										strReplaces += "<div class=\"b\">";
										strReplaces += "<div class=\"l\">";
										strReplaces += "<div class=\"r\">";
										strReplaces += "<div class=\"bl\">";
										strReplaces += "<div class=\"br\">";
										strReplaces += "<div class=\"tl\">";
										strReplaces += "<div class=\"tr\">";
										string strMyBuildingTitle = FindDescription(_lstBuildings, "Buildings", objReplace["DefaultBuilding"].InnerText);
										strReplaces += "<a href=\"" + objReplace["DefaultBuilding"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyBuildingTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objReplace["DefaultBuilding"].InnerText + ".png\" /></a>";
									}
								}
							}
						}
					}
					if (strCivilization != "")
						strCivilization += "</div></div></div></div></div></div></div></div>";
					if (strReplaces != "")
						strReplaces += "</div></div></div></div></div></div></div></div>";

					// Look for Required Buildings.
					string strRequired = "";
					XmlNode objRequired = objDocument.SelectSingleNode("/GameData/Building_ClassesNeededInCity/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objRequired != null)
					{
						strRequired += "<h2>" + TXT_KEY_PEDIA_REQ_BLDG_LABEL + "</h2>";
						strRequired += "<div class=\"t\">";
						strRequired += "<div class=\"b\">";
						strRequired += "<div class=\"l\">";
						strRequired += "<div class=\"r\">";
						strRequired += "<div class=\"bl\">";
						strRequired += "<div class=\"br\">";
						strRequired += "<div class=\"tl\">";
						strRequired += "<div class=\"tr\">";
						foreach (string strBuildingXmlFile in _lstBuildings)
						{
							XmlDocument objBuildingDoc = new XmlDocument();
							objBuildingDoc.Load(strBuildingXmlFile);
							foreach (XmlNode objBuilding in objBuildingDoc.SelectNodes("/GameData/Buildings/Row[BuildingClass = \"" + objRequired["BuildingClassType"].InnerText + "\"]"))
							{
								string strMyTitle = FindDescription(_lstBuildings, "Buildings", objBuilding["Type"].InnerText);
								strRequired += "<a href=\"" + objBuilding["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objBuilding["Type"].InnerText + ".png\" /></a>";
							}
						}
					}
					if (strRequired != "")
						strRequired += "</div></div></div></div></div></div></div></div>";

					// Look for Required Resources.
					string strResources = "";
					XmlNode objResources = objDocument.SelectSingleNode("/GameData/Building_ResourceQuantityRequirements/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objResources != null)
					{
						strResources += "<h2>" + TXT_KEY_PEDIA_REQ_RESRC_LABEL + "</h2>";
						strResources += "<div class=\"t\">";
						strResources += "<div class=\"b\">";
						strResources += "<div class=\"l\">";
						strResources += "<div class=\"r\">";
						strResources += "<div class=\"bl\">";
						strResources += "<div class=\"br\">";
						strResources += "<div class=\"tl\">";
						strResources += "<div class=\"tr\">";
						string strMyTitle = FindDescription(_lstResources, "Resources", objResources["ResourceType"].InnerText);
						strResources += "<a href=\"" + objResources["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objResources["ResourceType"].InnerText + ".png\" /></a>";
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					// Look for Required Local Resources.
					string strLocal = "";
					XmlNode objLocal = objDocument.SelectSingleNode("/GameData/Building_LocalResourceAnds/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objLocal != null)
					{
						strLocal += "<h2>" + TXT_KEY_PEDIA_LOCAL_RESRC_LABEL + "</h2>";
						strLocal += "<div class=\"t\">";
						strLocal += "<div class=\"b\">";
						strLocal += "<div class=\"l\">";
						strLocal += "<div class=\"r\">";
						strLocal += "<div class=\"bl\">";
						strLocal += "<div class=\"br\">";
						strLocal += "<div class=\"tl\">";
						strLocal += "<div class=\"tr\">";
						string strMyTitle = FindDescription(_lstResources, "Resources", objLocal["ResourceType"].InnerText);
						strLocal += "<a href=\"" + objLocal["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objLocal["ResourceType"].InnerText + ".png\" /></a>";
					}
					if (strLocal != "")
						strLocal += "</div></div></div></div></div></div></div></div>";

					// Look for Defense.
					string strDefense = "";
					if (objTechnology["Defense"] != null)
					{
						double dblDefense = Convert.ToDouble(objTechnology["Defense"].InnerText);
						dblDefense /= 100;
						strDefense = dblDefense.ToString() + " <img src=\"/civilopedia/images/strength.png\" alt=\"strength\" />";
					}
					if (objTechnology["ExtraCityHitPoints"] != null)
					{
						if (strDefense != string.Empty)
							strDefense += ", ";
						strDefense += GetString("TXT_KEY_PEDIA_DEFENSE_HITPOINTS", false).Replace("{1_DefenseHP}", objTechnology["ExtraCityHitPoints"].InnerText);
					}
					if (strDefense != "")
					{
						string strMyDefense = strDefense;
						strDefense = "<h2>" + TXT_KEY_PEDIA_DEFENSE_LABEL + "</h2>";
						strDefense += "<div class=\"t\">";
						strDefense += "<div class=\"b\">";
						strDefense += "<div class=\"l\">";
						strDefense += "<div class=\"r\">";
						strDefense += "<div class=\"bl\">";
						strDefense += "<div class=\"br\">";
						strDefense += "<div class=\"tl\">";
						strDefense += "<div class=\"tr\">";
						strDefense += strMyDefense;
						strDefense += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Happiness.
					string strHappiness = "";
					if (objTechnology["Happiness"] != null)
					{
						strHappiness += "<h2>" + TXT_KEY_PEDIA_HAPPINESS_LABEL + "</h2>";
						strHappiness += "<div class=\"t\">";
						strHappiness += "<div class=\"b\">";
						strHappiness += "<div class=\"l\">";
						strHappiness += "<div class=\"r\">";
						strHappiness += "<div class=\"bl\">";
						strHappiness += "<div class=\"br\">";
						strHappiness += "<div class=\"tl\">";
						strHappiness += "<div class=\"tr\">";
						strHappiness += objTechnology["Happiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
					}
					if (strHappiness != "")
						strHappiness += "</div></div></div></div></div></div></div></div>";

					// Look for Culture.
					string strCulture = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_CULTURE\"]"))
					{
						strCulture += objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_CULTURE\"]"))
					{
						strCulture += objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" /> ";
					}
					if (strCulture != "")
					{
						string strMyCulture = strCulture;
						strCulture = "<h2>" + TXT_KEY_PEDIA_CULTURE_LABEL + "</h2>";
						strCulture += "<div class=\"t\">";
						strCulture += "<div class=\"b\">";
						strCulture += "<div class=\"l\">";
						strCulture += "<div class=\"r\">";
						strCulture += "<div class=\"bl\">";
						strCulture += "<div class=\"br\">";
						strCulture += "<div class=\"tl\">";
						strCulture += "<div class=\"tr\">";
						strCulture += strMyCulture;
						strCulture += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Faith.
					string strFaith = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FAITH\"]"))
					{
						strFaith += objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FAITH\"]"))
					{
						strFaith += objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" /> ";
					}
					if (strFaith != "")
					{
						string strMyFaith = strFaith;
						strFaith = "<h2>" + TXT_KEY_PEDIA_FAITH_LABEL + "</h2>";
						strFaith += "<div class=\"t\">";
						strFaith += "<div class=\"b\">";
						strFaith += "<div class=\"l\">";
						strFaith += "<div class=\"r\">";
						strFaith += "<div class=\"bl\">";
						strFaith += "<div class=\"br\">";
						strFaith += "<div class=\"tl\">";
						strFaith += "<div class=\"tr\">";
						strFaith += strMyFaith;
						strFaith += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Gold.
					string strGold = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					if (strGold != "")
					{
						string strMyGold = strGold;
						strGold = "<h2>" + TXT_KEY_PEDIA_GOLD_LABEL + "</h2>";
						strGold += "<div class=\"t\">";
						strGold += "<div class=\"b\">";
						strGold += "<div class=\"l\">";
						strGold += "<div class=\"r\">";
						strGold += "<div class=\"bl\">";
						strGold += "<div class=\"br\">";
						strGold += "<div class=\"tl\">";
						strGold += "<div class=\"tr\">";
						strGold += strMyGold;
						strGold += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Production.
					string strProduction = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					if (strProduction != "")
					{
						string strMyProduction = strProduction;
						strProduction = "<h2>" + TXT_KEY_PEDIA_PRODUCTION_LABEL + "</h2>";
						strProduction += "<div class=\"t\">";
						strProduction += "<div class=\"b\">";
						strProduction += "<div class=\"l\">";
						strProduction += "<div class=\"r\">";
						strProduction += "<div class=\"bl\">";
						strProduction += "<div class=\"br\">";
						strProduction += "<div class=\"tl\">";
						strProduction += "<div class=\"tr\">";
						strProduction += strMyProduction;
						strProduction += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Food.
					string strFood = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					if (strFood != "")
					{
						string strMyFood = strFood;
						strFood = "<h2>" + TXT_KEY_PEDIA_FOOD_LABEL + "</h2>";
						strFood += "<div class=\"t\">";
						strFood += "<div class=\"b\">";
						strFood += "<div class=\"l\">";
						strFood += "<div class=\"r\">";
						strFood += "<div class=\"bl\">";
						strFood += "<div class=\"br\">";
						strFood += "<div class=\"tl\">";
						strFood += "<div class=\"tr\">";
						strFood += strMyFood;
						strFood += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Science.
					string strScience = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						strScience += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/research.png\" alt=\"research\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						strScience += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/research.png\" alt=\"research\" /> ";
					}
					if (strScience != "")
					{
						string strMyScience = strScience;
						strScience = "<h2>" + TXT_KEY_PEDIA_SCIENCE_LABEL + "</h2>";
						strScience += "<div class=\"t\">";
						strScience += "<div class=\"b\">";
						strScience += "<div class=\"l\">";
						strScience += "<div class=\"r\">";
						strScience += "<div class=\"bl\">";
						strScience += "<div class=\"br\">";
						strScience += "<div class=\"tl\">";
						strScience += "<div class=\"tr\">";
						strScience += strMyScience;
						strScience += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Specialists.
					string strSpecialists = "";
					if (objTechnology["SpecialistType"] != null)
					{
						strSpecialists += "<h2>" + TXT_KEY_PEDIA_SPEC_LABEL + "</h2>";
						strSpecialists += "<div class=\"t\">";
						strSpecialists += "<div class=\"b\">";
						strSpecialists += "<div class=\"l\">";
						strSpecialists += "<div class=\"r\">";
						strSpecialists += "<div class=\"bl\">";
						strSpecialists += "<div class=\"br\">";
						strSpecialists += "<div class=\"tl\">";
						strSpecialists += "<div class=\"tr\">";
						for (int i = 1; i <= Convert.ToInt32(objTechnology["SpecialistCount"].InnerText); i++)
						{
							string strMyTitle = FindDescription(_lstSpecialists, "Specialists", objTechnology["SpecialistType"].InnerText);
							strSpecialists += "<a href=\"" + objTechnology["SpecialistType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTechnology["SpecialistType"].InnerText + ".png\" /></a>";
						}
					}
					if (strSpecialists != "")
						strSpecialists += "</div></div></div></div></div></div></div></div>";

					// Look for Great People Rate Change.
					string strGreatPeople = "";
					if (objTechnology["SpecialistType"] != null)
					{
						if (objTechnology["GreatPeopleRateChange"] != null)
						{
							strGreatPeople += "<h2>" + GetString("TXT_KEY_" + objTechnology["SpecialistType"].InnerText + "_TITLE") + "</h2>";
							strGreatPeople += "<div class=\"t\">";
							strGreatPeople += "<div class=\"b\">";
							strGreatPeople += "<div class=\"l\">";
							strGreatPeople += "<div class=\"r\">";
							strGreatPeople += "<div class=\"bl\">";
							strGreatPeople += "<div class=\"br\">";
							strGreatPeople += "<div class=\"tl\">";
							strGreatPeople += "<div class=\"tr\">";
							strGreatPeople += objTechnology["GreatPeopleRateChange"].InnerText + " <img src=\"/civilopedia/images/great_people.png\" alt=\"great people\" />";
						}
					}
					if (strGreatPeople != "")
						strGreatPeople += "</div></div></div></div></div></div></div></div>";

					// Look for Great Works.
					string strGreatWorks = "";
					if (objTechnology["GreatWorkSlotType"] != null)
					{
						if (objTechnology["GreatWorkCount"] != null)
						{
							strGreatWorks += "<h2>" + TXT_KEY_PEDIA_GREAT_WORKS_LABEL + "</h2>";
							strGreatWorks += "<div class=\"t\">";
							strGreatWorks += "<div class=\"b\">";
							strGreatWorks += "<div class=\"l\">";
							strGreatWorks += "<div class=\"r\">";
							strGreatWorks += "<div class=\"bl\">";
							strGreatWorks += "<div class=\"br\">";
							strGreatWorks += "<div class=\"tl\">";
							strGreatWorks += "<div class=\"tr\">";

							string strIcon = "";
							string strTooltip = "";

							switch (objTechnology["GreatWorkSlotType"].InnerText)
							{
								case "GREAT_WORK_SLOT_MUSIC":
									strIcon = "GREAT_WORK_SLOT_MUSIC.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_MUSIC_EMPTY_TOOLTIP;
									break;
								case "GREAT_WORK_SLOT_ART_ARTIFACT":
									strIcon = "GREAT_WORK_SLOT_ART_ARTIFACT.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_ART_ARTIFACT_EMPTY_TOOLTIP;
									break;
								case "GREAT_WORK_SLOT_LITERATURE":
								default:
									strIcon = "GREAT_WORK_SLOT_LITERATURE.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_LITERATURE_EMPTY_TOOLTIP;
									break;
							}

							for (int i = 0; i < Convert.ToInt32(objTechnology["GreatWorkCount"].InnerText); i++)
								strGreatWorks += "<img src=\"/civilopedia/images/" + strIcon + "\" onmouseover=\"return tooltip('" + strTooltip + "');\" onmouseout=\"return hideTip();\" />";

							// If Great Works exist, the building should not have Specialists shown, so clear that string.
							strSpecialists = "";
						}
					}
					if (strGreatWorks != "")
						strGreatWorks += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
					strOutput = strOutput.Replace("##COST##", strCost);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##PREREQ##", strPrereq);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);
					strOutput = strOutput.Replace("##LOCALRESOURCES##", strLocal);
					strOutput = strOutput.Replace("##MAINTENANCE##", strMaintenance);
					strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);
					strOutput = strOutput.Replace("##REPLACES##", strReplaces);
					strOutput = strOutput.Replace("##REQUIRED##", strRequired);
					strOutput = strOutput.Replace("##DEFENSE##", strDefense);
					strOutput = strOutput.Replace("##HAPPINESS##", strHappiness);
					strOutput = strOutput.Replace("##PRODUCTION##", strProduction);
					strOutput = strOutput.Replace("##FOOD##", strFood);
					strOutput = strOutput.Replace("##GOLD##", strGold);
					strOutput = strOutput.Replace("##SCIENCE##", strScience);
					strOutput = strOutput.Replace("##CULTURE##", strCulture);
					strOutput = strOutput.Replace("##FAITH##", strFaith);
					strOutput = strOutput.Replace("##SPECIALISTS##", strSpecialists);
					strOutput = strOutput.Replace("##GREATWORKS##", strGreatWorks);
					strOutput = strOutput.Replace("##GREATPEOPLE##", strGreatPeople);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == strEraKey)
						{
							objGroup = objCurrentGroup;
							break;
						}
					}
					// Buildings that have only a FaithCost should be placed in the Religious category.
					if (objTechnology["FaithCost"] != null)
					{
						if (objTechnology["Cost"].InnerText == "-1")
							objGroup = lstGroups[0];
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_BUILDINGS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"BUILDING_HOME.aspx\"><div id=\"BUILDING_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Buildings.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Wonders pages.
		/// </summary>
		private void GenerateWonders()
		{
			txtDebug.Text += "\r\nGenerating Wonders...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objWonders = new Group();
			objWonders.Key = "WORLD_WONDER";
			objWonders.Name = GetString("TXT_KEY_WONDER_SECTION_1");
			lstGroups.Add(objWonders);
	
			Group objNational = new Group();
			objNational.Key = "NATIONAL_WONDER";
			objNational.Name = GetString("TXT_KEY_WONDER_SECTION_2");
			lstGroups.Add(objNational);

			Group objProjects = new Group();
			objProjects.Key = "PROJECT_WONDER";
			objProjects.Name = GetString("TXT_KEY_WONDER_SECTION_3");
			lstGroups.Add(objProjects);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_WONDERS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_WONDERS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_WONDERS_HELP_TEXT");
			const string strHomeImage = "BUILDING_STONEHENGE";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Wonders";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "WONDER_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_WONDERS.aspx"));

			XmlDocument objDocument = MergeXml(_lstBuildings);

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Buildings/Row"))
			{
				string strBuildingClass = "";
				XmlDocument objClassDoc = MergeXml(_lstBuildingClasses);
				XmlNode objClass = objClassDoc.SelectSingleNode("/GameData/BuildingClasses/Row[Type = \"" + objTechnology["BuildingClass"].InnerText + "\"]");
				// Determine the Building type (Building, National Wonder, or World Wonder) based on the existance of MaxPlayerInstances or MaxGlobalInstances.
				if (objClass != null)
				{
					if (objClass["MaxPlayerInstances"] != null)
						strBuildingClass = "NATIONAL_WONDER";
					else if (objClass["MaxGlobalInstances"] != null)
						strBuildingClass = "WORLD_WONDER";
					else
						strBuildingClass = "BUILDING";

					// Fix for the Recycling Center, Writers' Guild, Artists' Guild, and Musicians' Guild which all have a MaxPlayerInstances value but are actually buildings.
					if (objTechnology["Type"].InnerText == "BUILDING_RECYCLING_CENTER" || objTechnology["Type"].InnerText == "BUILDING_WRITERS_GUILD" || objTechnology["Type"].InnerText == "BUILDING_ARTISTS_GUILD" || objTechnology["Type"].InnerText == "BUILDING_MUSICIANS_GUILD")
						strBuildingClass = "BUILDING";
				}

				// Look to see if the Wonder should be deleted (United Nations was removed in Brave New World expansion).
				if (objTechnology["Type"].InnerText == "BUILDING_UNITED_NATIONS")
					strBuildingClass = "BUILDING";

				// Do not write out Buildings, only National Wonders and World Wonders.
				if (strBuildingClass != "BUILDING")
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					string strDesc = "";
					try
					{
						strDesc = GetString(objTechnology["Civilopedia"].InnerText);
						string strMyDesc = strDesc;
						strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
						strDesc += "<div class=\"t\">";
						strDesc += "<div class=\"b\">";
						strDesc += "<div class=\"l\">";
						strDesc += "<div class=\"r\">";
						strDesc += "<div class=\"bl\">";
						strDesc += "<div class=\"br\">";
						strDesc += "<div class=\"tl\">";
						strDesc += "<div class=\"tr\">";
						strDesc += strMyDesc;
						strDesc += "</div></div></div></div></div></div></div></div>";
					}
					catch
					{
					}
					string strQuote = "";
					try
					{
						strQuote = GetString(objTechnology["Quote"].InnerText);
						if (strQuote != "")
						{
							string strMyQuote = strQuote;
							strQuote = "<h2>" + TXT_KEY_PEDIA_QUOTE_LABEL + "</h2>";
							strQuote += "<div class=\"t\">";
							strQuote += "<div class=\"b\">";
							strQuote += "<div class=\"l\">";
							strQuote += "<div class=\"r\">";
							strQuote += "<div class=\"bl\">";
							strQuote += "<div class=\"br\">";
							strQuote += "<div class=\"tl\">";
							strQuote += "<div class=\"tr\">";
							strQuote += strMyQuote;
							strQuote += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}

					string strStrategy = "";
					try
					{
						strStrategy = GetString(objTechnology["Strategy"].InnerText);
						if (strStrategy != "")
						{
							string strMyStrategy = strStrategy;
							strStrategy = "<h2>" + TXT_KEY_PEDIA_STRATEGY_LABEL + "</h2>";
							strStrategy += "<div class=\"t\">";
							strStrategy += "<div class=\"b\">";
							strStrategy += "<div class=\"l\">";
							strStrategy += "<div class=\"r\">";
							strStrategy += "<div class=\"bl\">";
							strStrategy += "<div class=\"br\">";
							strStrategy += "<div class=\"tl\">";
							strStrategy += "<div class=\"tr\">";
							strStrategy += strMyStrategy;
							strStrategy += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}

					string strCost = "";
					if (objTechnology["Cost"] != null)
					{
						if (objTechnology["Cost"].InnerText == "-1")
							strCost = "";
						else if (objTechnology["Cost"].InnerText == "0")
							strCost = "FREE";
						else
							strCost = objTechnology["Cost"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" />";
					}
					else
					{
						strCost = "FREE";
					}
					if (strCost != "")
					{
						string strMyCost = strCost;
						strCost = "<h2>" + TXT_KEY_PEDIA_COST_LABEL + "</h2>";
						strCost += "<div class=\"t\">";
						strCost += "<div class=\"b\">";
						strCost += "<div class=\"l\">";
						strCost += "<div class=\"r\">";
						strCost += "<div class=\"bl\">";
						strCost += "<div class=\"br\">";
						strCost += "<div class=\"tl\">";
						strCost += "<div class=\"tr\">";
						strCost += strMyCost;
						strCost += "</div></div></div></div></div></div></div></div>";
					}

					// Determine Maintenance.
					string strMaintenance = "";
					if (objTechnology["GoldMaintenance"] != null)
					{
						strMaintenance += "<h2>" + TXT_KEY_PEDIA_MAINT_LABEL + "</h2>";
						strMaintenance += "<div class=\"t\">";
						strMaintenance += "<div class=\"b\">";
						strMaintenance += "<div class=\"l\">";
						strMaintenance += "<div class=\"r\">";
						strMaintenance += "<div class=\"bl\">";
						strMaintenance += "<div class=\"br\">";
						strMaintenance += "<div class=\"tl\">";
						strMaintenance += "<div class=\"tr\">";
						strMaintenance += objTechnology["GoldMaintenance"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" />";
						strMaintenance += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Prereq Tech.
					string strPrereq = "";
					if (objTechnology["PrereqTech"] != null)
					{
						foreach (string strTechXmlFile in _lstTechnologies)
						{
							XmlDocument objTechDocument = new XmlDocument();
							objTechDocument.Load(strTechXmlFile);
							foreach (XmlNode objPrereq in objTechDocument.SelectNodes("/GameData/Technologies/Row[Type = \"" + objTechnology["PrereqTech"].InnerText + "\"]"))
							{
								if (strPrereq == "")
								{
									strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
									strPrereq += "<div class=\"t\">";
									strPrereq += "<div class=\"b\">";
									strPrereq += "<div class=\"l\">";
									strPrereq += "<div class=\"r\">";
									strPrereq += "<div class=\"bl\">";
									strPrereq += "<div class=\"br\">";
									strPrereq += "<div class=\"tl\">";
									strPrereq += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["Type"].InnerText);
								strPrereq += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
							}
						}
						if (strPrereq != "")
							strPrereq += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Civilization.
					string strCivilization = "";
					string strReplaces = "";
					if (objTechnology["PrereqTech"] != null)
					{
						foreach (string strCivXmlFile in _lstCivilizations)
						{
							XmlDocument objCivDocument = new XmlDocument();
							objCivDocument.Load(strCivXmlFile);
							foreach (XmlNode objPrereq in objCivDocument.SelectNodes("/GameData/Civilization_BuildingClassOverrides/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								strCivilization += "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
								strCivilization += "<div class=\"t\">";
								strCivilization += "<div class=\"b\">";
								strCivilization += "<div class=\"l\">";
								strCivilization += "<div class=\"r\">";
								strCivilization += "<div class=\"bl\">";
								strCivilization += "<div class=\"br\">";
								strCivilization += "<div class=\"tl\">";
								strCivilization += "<div class=\"tr\">";
								string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objPrereq["CivilizationType"].InnerText);
								strCivilization += "<a href=\"" + objPrereq["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["CivilizationType"].InnerText + ".png\" /></a>";

								// Locate the replaced building.
								foreach (string strBuildingXmlFile in _lstBuildingClasses)
								{
									XmlDocument objBuildingDoc = new XmlDocument();
									objBuildingDoc.Load(strBuildingXmlFile);
									XmlNode objReplace = objBuildingDoc.SelectSingleNode("/GameData/BuildingClasses/Row[Type = \"" + objPrereq["BuildingClassType"].InnerText + "\"]");
									if (objReplace != null)
									{
										strReplaces += "<h2>" + TXT_KEY_PEDIA_REPLACES_LABEL + "</h2>";
										strReplaces += "<div class=\"t\">";
										strReplaces += "<div class=\"b\">";
										strReplaces += "<div class=\"l\">";
										strReplaces += "<div class=\"r\">";
										strReplaces += "<div class=\"bl\">";
										strReplaces += "<div class=\"br\">";
										strReplaces += "<div class=\"tl\">";
										strReplaces += "<div class=\"tr\">";
										string strMyBuildingTitle = FindDescription(_lstBuildings, "Buildings", objReplace["DefaultBuilding"].InnerText);
										strReplaces += "<a href=\"" + objReplace["DefaultBuilding"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyBuildingTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objReplace["DefaultBuilding"].InnerText + ".png\" /></a>";
									}
								}
							}
						}
						if (strCivilization != "")
							strCivilization += "</div></div></div></div></div></div></div></div>";
						if (strReplaces != "")
							strReplaces += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Required Buildings.
					string strRequired = "";
					XmlNode objRequired = objDocument.SelectSingleNode("/GameData/Building_ClassesNeededInCity/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objRequired != null)
					{
						strRequired += "<h2>" + TXT_KEY_PEDIA_REQ_BLDG_LABEL + "</h2>";
						strRequired += "<div class=\"t\">";
						strRequired += "<div class=\"b\">";
						strRequired += "<div class=\"l\">";
						strRequired += "<div class=\"r\">";
						strRequired += "<div class=\"bl\">";
						strRequired += "<div class=\"br\">";
						strRequired += "<div class=\"tl\">";
						strRequired += "<div class=\"tr\">";
						foreach (string strBuildingXmlFile in _lstBuildings)
						{
							XmlDocument objBuildingDoc = new XmlDocument();
							objBuildingDoc.Load(strBuildingXmlFile);
							foreach (XmlNode objBuilding in objBuildingDoc.SelectNodes("/GameData/Buildings/Row[BuildingClass = \"" + objRequired["BuildingClassType"].InnerText + "\"]"))
							{
								string strMyTitle = FindDescription(_lstBuildings, "Buildings", objBuilding["Type"].InnerText);
								strRequired += "<a href=\"" + objBuilding["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objBuilding["Type"].InnerText + ".png\" /></a>";
							}
						}
					}
					if (strRequired != "")
						strRequired += "</div></div></div></div></div></div></div></div>";

					// Look for Required Buildings.
					string strResources = "";
					XmlNode objResources = objDocument.SelectSingleNode("/GameData/Building_ResourceQuantityRequirements/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objResources != null)
					{
						strResources += "<h2>" + TXT_KEY_PEDIA_REQ_RESRC_LABEL + "</h2>";
						strResources += "<div class=\"t\">";
						strResources += "<div class=\"b\">";
						strResources += "<div class=\"l\">";
						strResources += "<div class=\"r\">";
						strResources += "<div class=\"bl\">";
						strResources += "<div class=\"br\">";
						strResources += "<div class=\"tl\">";
						strResources += "<div class=\"tr\">";
						string strMyTitle = FindDescription(_lstResources, "Resources", objResources["ResourceType"].InnerText);
						strResources += "<a href=\"" + objResources["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objResources["ResourceType"].InnerText + ".png\" /></a>";
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					// Look for Defense.
					string strDefense = "";
					if (objTechnology["Defense"] != null)
					{
						double dblDefense = Convert.ToDouble(objTechnology["Defense"].InnerText);
						dblDefense /= 100;
						strDefense += "<h2>" + TXT_KEY_PEDIA_DEFENSE_LABEL + "</h2>";
						strDefense += "<div class=\"t\">";
						strDefense += "<div class=\"b\">";
						strDefense += "<div class=\"l\">";
						strDefense += "<div class=\"r\">";
						strDefense += "<div class=\"bl\">";
						strDefense += "<div class=\"br\">";
						strDefense += "<div class=\"tl\">";
						strDefense += "<div class=\"tr\">";
						strDefense += dblDefense.ToString() + " <img src=\"/civilopedia/images/strength.png\" alt=\"strength\" />";
					}
					if (strDefense != "")
						strDefense += "</div></div></div></div></div></div></div></div>";

					// Look for Happiness.
					string strHappiness = "";
					if (objTechnology["Happiness"] != null)
					{
						strHappiness += "<h2>" + TXT_KEY_PEDIA_HAPPINESS_LABEL + "</h2>";
						strHappiness += "<div class=\"t\">";
						strHappiness += "<div class=\"b\">";
						strHappiness += "<div class=\"l\">";
						strHappiness += "<div class=\"r\">";
						strHappiness += "<div class=\"bl\">";
						strHappiness += "<div class=\"br\">";
						strHappiness += "<div class=\"tl\">";
						strHappiness += "<div class=\"tr\">";
						strHappiness += objTechnology["Happiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
					}
					if (strHappiness != "")
						strHappiness += "</div></div></div></div></div></div></div></div>";

					// Look for Unmodified Happiness.
					if (objTechnology["UnmoddedHappiness"] != null)
					{
						strHappiness = "<h2>" + TXT_KEY_PEDIA_HAPPINESS_LABEL + "</h2>";
						strHappiness += "<div class=\"t\">";
						strHappiness += "<div class=\"b\">";
						strHappiness += "<div class=\"l\">";
						strHappiness += "<div class=\"r\">";
						strHappiness += "<div class=\"bl\">";
						strHappiness += "<div class=\"br\">";
						strHappiness += "<div class=\"tl\">";
						strHappiness += "<div class=\"tr\">";
						strHappiness += objTechnology["UnmoddedHappiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
						strHappiness += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Faith.
					string strFaith = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FAITH\"]"))
					{
						strFaith += objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FAITH\"]"))
					{
						strFaith += objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" /> ";
					}
					if (strFaith != "")
					{
						string strMyFaith = strFaith;
						strFaith = "<h2>" + TXT_KEY_PEDIA_FAITH_LABEL + "</h2>";
						strFaith += "<div class=\"t\">";
						strFaith += "<div class=\"b\">";
						strFaith += "<div class=\"l\">";
						strFaith += "<div class=\"r\">";
						strFaith += "<div class=\"bl\">";
						strFaith += "<div class=\"br\">";
						strFaith += "<div class=\"tl\">";
						strFaith += "<div class=\"tr\">";
						strFaith += strMyFaith;
						strFaith += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Culture.
					string strCulture = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_CULTURE\"]"))
					{
						strCulture += objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_CULTURE\"]"))
					{
						strCulture += objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" /> ";
					}
					if (strCulture != "")
					{
						string strMyCulture = strCulture;
						strCulture = "<h2>" + TXT_KEY_PEDIA_CULTURE_LABEL + "</h2>";
						strCulture += "<div class=\"t\">";
						strCulture += "<div class=\"b\">";
						strCulture += "<div class=\"l\">";
						strCulture += "<div class=\"r\">";
						strCulture += "<div class=\"bl\">";
						strCulture += "<div class=\"br\">";
						strCulture += "<div class=\"tl\">";
						strCulture += "<div class=\"tr\">";
						strCulture += strMyCulture;
						strCulture += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Gold.
					string strGold = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					if (strGold != "")
					{
						string strMyGold = strGold;
						strGold = "<h2>" + TXT_KEY_PEDIA_GOLD_LABEL + "</h2>";
						strGold += "<div class=\"t\">";
						strGold += "<div class=\"b\">";
						strGold += "<div class=\"l\">";
						strGold += "<div class=\"r\">";
						strGold += "<div class=\"bl\">";
						strGold += "<div class=\"br\">";
						strGold += "<div class=\"tl\">";
						strGold += "<div class=\"tr\">";
						strGold += strMyGold;
						strGold += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Production.
					string strProduction = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					if (strProduction != "")
					{
						string strMyProduction = strProduction;
						strProduction = "<h2>" + TXT_KEY_PEDIA_PRODUCTION_LABEL + "</h2>";
						strProduction += "<div class=\"t\">";
						strProduction += "<div class=\"b\">";
						strProduction += "<div class=\"l\">";
						strProduction += "<div class=\"r\">";
						strProduction += "<div class=\"bl\">";
						strProduction += "<div class=\"br\">";
						strProduction += "<div class=\"tl\">";
						strProduction += "<div class=\"tr\">";
						strProduction += strMyProduction;
						strProduction += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Food.
					string strFood = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					if (strFood != "")
					{
						string strMyFood = strFood;
						strFood = "<h2>" + TXT_KEY_PEDIA_FOOD_LABEL + "</h2>";
						strFood += "<div class=\"t\">";
						strFood += "<div class=\"b\">";
						strFood += "<div class=\"l\">";
						strFood += "<div class=\"r\">";
						strFood += "<div class=\"bl\">";
						strFood += "<div class=\"br\">";
						strFood += "<div class=\"tl\">";
						strFood += "<div class=\"tr\">";
						strFood += strMyFood;
						strFood += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Science.
					string strScience = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						strScience += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/research.png\" alt=\"research\" />";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						if (strScience != "")
							strScience += ", ";
						strScience += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/research.png\" alt=\"research\" />";
					}
					if (strScience != "")
					{
						string strMyScience = strScience;
						strScience = "<h2>" + TXT_KEY_PEDIA_SCIENCE_LABEL + "</h2>";
						strScience += "<div class=\"t\">";
						strScience += "<div class=\"b\">";
						strScience += "<div class=\"l\">";
						strScience += "<div class=\"r\">";
						strScience += "<div class=\"bl\">";
						strScience += "<div class=\"br\">";
						strScience += "<div class=\"tl\">";
						strScience += "<div class=\"tr\">";
						strScience += strMyScience;
						strScience += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Specialists.
					string strGreatPeople = "";
					if (objTechnology["SpecialistType"] != null)
					{
						if (objTechnology["GreatPeopleRateChange"] != null)
						{
							strGreatPeople += "<h2>" + GetString("TXT_KEY_" + objTechnology["SpecialistType"].InnerText + "_TITLE") + "</h2>";
							strGreatPeople += "<div class=\"t\">";
							strGreatPeople += "<div class=\"b\">";
							strGreatPeople += "<div class=\"l\">";
							strGreatPeople += "<div class=\"r\">";
							strGreatPeople += "<div class=\"bl\">";
							strGreatPeople += "<div class=\"br\">";
							strGreatPeople += "<div class=\"tl\">";
							strGreatPeople += "<div class=\"tr\">";
							strGreatPeople += objTechnology["GreatPeopleRateChange"].InnerText + " <img src=\"/civilopedia/images/great_people.png\" alt=\"great people\" />";
						}
					}
					if (strGreatPeople != "")
						strGreatPeople += "</div></div></div></div></div></div></div></div>";

					// Look for Great Works.
					string strGreatWorks = "";
					if (objTechnology["GreatWorkSlotType"] != null)
					{
						if (objTechnology["GreatWorkCount"] != null)
						{
							strGreatWorks += "<h2>" + TXT_KEY_PEDIA_GREAT_WORKS_LABEL + "</h2>";
							strGreatWorks += "<div class=\"t\">";
							strGreatWorks += "<div class=\"b\">";
							strGreatWorks += "<div class=\"l\">";
							strGreatWorks += "<div class=\"r\">";
							strGreatWorks += "<div class=\"bl\">";
							strGreatWorks += "<div class=\"br\">";
							strGreatWorks += "<div class=\"tl\">";
							strGreatWorks += "<div class=\"tr\">";

							string strIcon = "";
							string strTooltip = "";

							switch (objTechnology["GreatWorkSlotType"].InnerText)
							{
								case "GREAT_WORK_SLOT_MUSIC":
									strIcon = "GREAT_WORK_SLOT_MUSIC.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_MUSIC_EMPTY_TOOLTIP;
									break;
								case "GREAT_WORK_SLOT_ART_ARTIFACT":
									strIcon = "GREAT_WORK_SLOT_ART_ARTIFACT.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_ART_ARTIFACT_EMPTY_TOOLTIP;
									break;
								case "GREAT_WORK_SLOT_LITERATURE":
								default:
									strIcon = "GREAT_WORK_SLOT_LITERATURE.png";
									strTooltip = TXT_KEY_GREAT_WORK_SLOT_LITERATURE_EMPTY_TOOLTIP;
									break;
							}

							for (int i = 0; i < Convert.ToInt32(objTechnology["GreatWorkCount"].InnerText); i++)
								strGreatWorks += "<img src=\"/civilopedia/images/" + strIcon + "\" onmouseover=\"return tooltip('" + strTooltip + "');\" onmouseout=\"return hideTip();\" />";
						}
					}
					if (strGreatWorks != "")
						strGreatWorks += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##QUOTE##", strQuote);
					strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
					strOutput = strOutput.Replace("##COST##", strCost);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##PREREQ##", strPrereq);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);
					strOutput = strOutput.Replace("##MAINTENANCE##", strMaintenance);
					strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);
					strOutput = strOutput.Replace("##REPLACES##", strReplaces);
					strOutput = strOutput.Replace("##REQUIRED##", strRequired);
					strOutput = strOutput.Replace("##DEFENSE##", strDefense);
					strOutput = strOutput.Replace("##HAPPINESS##", strHappiness);
					strOutput = strOutput.Replace("##PRODUCTION##", strProduction);
					strOutput = strOutput.Replace("##FOOD##", strFood);
					strOutput = strOutput.Replace("##GOLD##", strGold);
					strOutput = strOutput.Replace("##SCIENCE##", strScience);
					strOutput = strOutput.Replace("##CULTURE##", strCulture);
					strOutput = strOutput.Replace("##FAITH##", strFaith);
					strOutput = strOutput.Replace("##GREATPEOPLE##", strGreatPeople);
					strOutput = strOutput.Replace("##GREATWORKS##", strGreatWorks);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == strBuildingClass)
						{
							objGroup = objCurrentGroup;
							break;
						}
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Project Pages.
			objDocument = MergeXml(_lstProjects);

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Projects/Row"))
			{
				// Do not include the SS components.
				if (!objTechnology["Type"].InnerText.Contains("_SS_"))
				{
					const string strBuildingClass = "PROJECT_WONDER";

					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					string strDesc = "";
					try
					{
						strDesc = GetString(objTechnology["Civilopedia"].InnerText);
						string strMyDesc = strDesc;
						strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
						strDesc += "<div class=\"t\">";
						strDesc += "<div class=\"b\">";
						strDesc += "<div class=\"l\">";
						strDesc += "<div class=\"r\">";
						strDesc += "<div class=\"bl\">";
						strDesc += "<div class=\"br\">";
						strDesc += "<div class=\"tl\">";
						strDesc += "<div class=\"tr\">";
						strDesc += strMyDesc;
						strDesc += "</div></div></div></div></div></div></div></div>";
					}
					catch
					{
					}
					string strStrategy = "";
					try
					{
						strStrategy = GetString(objTechnology["Strategy"].InnerText);
						if (strStrategy != "")
						{
							string strMyStrategy = strStrategy;
							strStrategy = "<h2>" + TXT_KEY_PEDIA_QUOTE_LABEL + "</h2>";
							strStrategy += "<div class=\"t\">";
							strStrategy += "<div class=\"b\">";
							strStrategy += "<div class=\"l\">";
							strStrategy += "<div class=\"r\">";
							strStrategy += "<div class=\"bl\">";
							strStrategy += "<div class=\"br\">";
							strStrategy += "<div class=\"tl\">";
							strStrategy += "<div class=\"tr\">";
							strStrategy += strMyStrategy;
							strStrategy += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}

					string strCost = "";
					if (objTechnology["Cost"] != null)
					{
						if (objTechnology["Cost"].InnerText == "-1")
							strCost = "";
						else if (objTechnology["Cost"].InnerText == "0")
							strCost = "FREE";
						else
							strCost = objTechnology["Cost"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" />";
					}
					else
					{
						strCost = "FREE";
					}
					if (strCost != "")
					{
						string strMyCost = strCost;
						strCost = "<h2>" + TXT_KEY_PEDIA_COST_LABEL + "</h2>";
						strCost += "<div class=\"t\">";
						strCost += "<div class=\"b\">";
						strCost += "<div class=\"l\">";
						strCost += "<div class=\"r\">";
						strCost += "<div class=\"bl\">";
						strCost += "<div class=\"br\">";
						strCost += "<div class=\"tl\">";
						strCost += "<div class=\"tr\">";
						strCost += strMyCost;
						strCost += "</div></div></div></div></div></div></div></div>";
					}

					// Determine Maintenance.
					string strMaintenance = "";
					if (objTechnology["GoldMaintenance"] != null)
					{
						strMaintenance += "<h2>" + TXT_KEY_PEDIA_MAINT_LABEL + "</h2>";
						strMaintenance += "<div class=\"t\">";
						strMaintenance += "<div class=\"b\">";
						strMaintenance += "<div class=\"l\">";
						strMaintenance += "<div class=\"r\">";
						strMaintenance += "<div class=\"bl\">";
						strMaintenance += "<div class=\"br\">";
						strMaintenance += "<div class=\"tl\">";
						strMaintenance += "<div class=\"tr\">";
						strMaintenance += objTechnology["GoldMaintenance"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" />";
						strMaintenance += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Prereq Tech.
					string strPrereq = "";
					if (objTechnology["TechPrereq"] != null)
					{
						foreach (string strTechXmlFile in _lstTechnologies)
						{
							XmlDocument objTechDocument = new XmlDocument();
							objTechDocument.Load(strTechXmlFile);
							foreach (XmlNode objPrereq in objTechDocument.SelectNodes("/GameData/Technologies/Row[Type = \"" + objTechnology["TechPrereq"].InnerText + "\"]"))
							{
								if (strPrereq == "")
								{
									strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
									strPrereq += "<div class=\"t\">";
									strPrereq += "<div class=\"b\">";
									strPrereq += "<div class=\"l\">";
									strPrereq += "<div class=\"r\">";
									strPrereq += "<div class=\"bl\">";
									strPrereq += "<div class=\"br\">";
									strPrereq += "<div class=\"tl\">";
									strPrereq += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objPrereq["Type"].InnerText);
								strPrereq += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
							}
						}
						if (strPrereq != "")
							strPrereq += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Civilization.
					string strCivilization = "";
					string strReplaces = "";
					if (objTechnology["PrereqTech"] != null)
					{
						foreach (string strCivXmlFile in _lstCivilizations)
						{
							XmlDocument objCivDocument = new XmlDocument();
							objCivDocument.Load(strCivXmlFile);
							foreach (XmlNode objPrereq in objCivDocument.SelectNodes("/GameData/Civilization_BuildingClassOverrides/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								strCivilization += "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
								strCivilization += "<div class=\"t\">";
								strCivilization += "<div class=\"b\">";
								strCivilization += "<div class=\"l\">";
								strCivilization += "<div class=\"r\">";
								strCivilization += "<div class=\"bl\">";
								strCivilization += "<div class=\"br\">";
								strCivilization += "<div class=\"tl\">";
								strCivilization += "<div class=\"tr\">";
								string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objPrereq["CivilizationType"].InnerText);
								strCivilization += "<a href=\"" + objPrereq["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["CivilizationType"].InnerText + ".png\" /></a>";

								// Locate the replaced building.
								foreach (string strBuildingXmlFile in _lstBuildingClasses)
								{
									XmlDocument objBuildingDoc = new XmlDocument();
									objBuildingDoc.Load(strBuildingXmlFile);
									XmlNode objReplace = objBuildingDoc.SelectSingleNode("/GameData/BuildingClasses/Row[Type = \"" + objPrereq["BuildingClassType"].InnerText + "\"]");
									if (objReplace != null)
									{
										strReplaces += "<h2>" + TXT_KEY_PEDIA_REPLACES_LABEL + "</h2>";
										strReplaces += "<div class=\"t\">";
										strReplaces += "<div class=\"b\">";
										strReplaces += "<div class=\"l\">";
										strReplaces += "<div class=\"r\">";
										strReplaces += "<div class=\"bl\">";
										strReplaces += "<div class=\"br\">";
										strReplaces += "<div class=\"tl\">";
										strReplaces += "<div class=\"tr\">";
										string strMyBuildingTitle = FindDescription(_lstBuildings, "Buildings", objReplace["DefaultBuilding"].InnerText);
										strReplaces += "<a href=\"" + objReplace["DefaultBuilding"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyBuildingTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objReplace["DefaultBuilding"].InnerText + ".png\" /></a>";
									}
								}
							}
						}
						if (strCivilization != "")
							strCivilization += "</div></div></div></div></div></div></div></div>";
						if (strReplaces != "")
							strReplaces += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Required Buildings.
					string strRequired = "";
					XmlNode objRequired = objDocument.SelectSingleNode("/GameData/Building_ClassesNeededInCity/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objRequired != null)
					{
						strRequired += "<h2>" + TXT_KEY_PEDIA_REQ_BLDG_LABEL + "</h2>";
						strRequired += "<div class=\"t\">";
						strRequired += "<div class=\"b\">";
						strRequired += "<div class=\"l\">";
						strRequired += "<div class=\"r\">";
						strRequired += "<div class=\"bl\">";
						strRequired += "<div class=\"br\">";
						strRequired += "<div class=\"tl\">";
						strRequired += "<div class=\"tr\">";
						foreach (string strBuildingXmlFile in _lstBuildings)
						{
							XmlDocument objBuildingDoc = new XmlDocument();
							objBuildingDoc.Load(strBuildingXmlFile);
							foreach (XmlNode objBuilding in objBuildingDoc.SelectNodes("/GameData/Buildings/Row[BuildingClass = \"" + objRequired["BuildingClassType"].InnerText + "\"]"))
							{
								string strMyTitle = FindDescription(_lstBuildings, "Buildings", objBuilding["Type"].InnerText);
								strRequired += "<a href=\"" + objBuilding["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objBuilding["Type"].InnerText + ".png\" /></a>";
							}
						}
					}
					if (strRequired != "")
						strRequired += "</div></div></div></div></div></div></div></div>";

					// Look for Required Buildings.
					string strResources = "";
					XmlNode objResources = objDocument.SelectSingleNode("/GameData/Building_ResourceQuantityRequirements/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objResources != null)
					{
						strResources += "<h2>" + TXT_KEY_PEDIA_REQ_RESRC_LABEL + "</h2>";
						strResources += "<div class=\"t\">";
						strResources += "<div class=\"b\">";
						strResources += "<div class=\"l\">";
						strResources += "<div class=\"r\">";
						strResources += "<div class=\"bl\">";
						strResources += "<div class=\"br\">";
						strResources += "<div class=\"tl\">";
						strResources += "<div class=\"tr\">";
						string strMyTitle = FindDescription(_lstResources, "Resources", objResources["ResourceType"].InnerText);
						strResources += "<a href=\"" + objResources["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objResources["ResourceType"].InnerText + ".png\" /></a>";
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					// Look for Defense.
					string strDefense = "";
					if (objTechnology["Defense"] != null)
					{
						double dblDefense = Convert.ToDouble(objTechnology["Defense"].InnerText);
						dblDefense /= 100;
						strDefense += "<h2>" + TXT_KEY_PEDIA_DEFENSE_LABEL + "</h2>";
						strDefense += "<div class=\"t\">";
						strDefense += "<div class=\"b\">";
						strDefense += "<div class=\"l\">";
						strDefense += "<div class=\"r\">";
						strDefense += "<div class=\"bl\">";
						strDefense += "<div class=\"br\">";
						strDefense += "<div class=\"tl\">";
						strDefense += "<div class=\"tr\">";
						strDefense += dblDefense.ToString() + " <img src=\"/civilopedia/images/strength.png\" alt=\"strength\" />";
					}
					if (strDefense != "")
						strDefense += "</div></div></div></div></div></div></div></div>";

					// Look for Happiness.
					string strHappiness = "";
					if (objTechnology["Happiness"] != null)
					{
						strHappiness += "<h2>" + TXT_KEY_PEDIA_HAPPINESS_LABEL + "</h2>";
						strHappiness += "<div class=\"t\">";
						strHappiness += "<div class=\"b\">";
						strHappiness += "<div class=\"l\">";
						strHappiness += "<div class=\"r\">";
						strHappiness += "<div class=\"bl\">";
						strHappiness += "<div class=\"br\">";
						strHappiness += "<div class=\"tl\">";
						strHappiness += "<div class=\"tr\">";
						strHappiness += objTechnology["Happiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
					}
					if (strHappiness != "")
						strHappiness += "</div></div></div></div></div></div></div></div>";

					// Look for Culture.
					string strCulture = "";
					if (objTechnology["Culture"] != null)
					{
						strCulture += "<h2>" + TXT_KEY_PEDIA_CULTURE_LABEL + "</h2>";
						strCulture += "<div class=\"t\">";
						strCulture += "<div class=\"b\">";
						strCulture += "<div class=\"l\">";
						strCulture += "<div class=\"r\">";
						strCulture += "<div class=\"bl\">";
						strCulture += "<div class=\"br\">";
						strCulture += "<div class=\"tl\">";
						strCulture += "<div class=\"tr\">";
						strCulture += objTechnology["Culture"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" />";
					}
					if (strCulture != "")
						strCulture += "</div></div></div></div></div></div></div></div>";

					// Look for Gold.
					string strGold = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
					{
						strGold += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
					}
					if (strGold != "")
					{
						string strMyGold = strGold;
						strGold = "<h2>" + TXT_KEY_PEDIA_GOLD_LABEL + "</h2>";
						strGold += "<div class=\"t\">";
						strGold += "<div class=\"b\">";
						strGold += "<div class=\"l\">";
						strGold += "<div class=\"r\">";
						strGold += "<div class=\"bl\">";
						strGold += "<div class=\"br\">";
						strGold += "<div class=\"tl\">";
						strGold += "<div class=\"tr\">";
						strGold += strMyGold;
						strGold += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Production.
					string strProduction = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
					{
						strProduction += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
					}
					if (strProduction != "")
					{
						string strMyProduction = strProduction;
						strProduction = "<h2>" + TXT_KEY_PEDIA_PRODUCTION_LABEL + "</h2>";
						strProduction += "<div class=\"t\">";
						strProduction += "<div class=\"b\">";
						strProduction += "<div class=\"l\">";
						strProduction += "<div class=\"r\">";
						strProduction += "<div class=\"bl\">";
						strProduction += "<div class=\"br\">";
						strProduction += "<div class=\"tl\">";
						strProduction += "<div class=\"tr\">";
						strProduction += strMyProduction;
						strProduction += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Food.
					string strFood = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
					{
						strFood += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					}
					if (strFood != "")
					{
						string strMyFood = strFood;
						strFood = "<h2>" + TXT_KEY_PEDIA_FOOD_LABEL + "</h2>";
						strFood += "<div class=\"t\">";
						strFood += "<div class=\"b\">";
						strFood += "<div class=\"l\">";
						strFood += "<div class=\"r\">";
						strFood += "<div class=\"bl\">";
						strFood += "<div class=\"br\">";
						strFood += "<div class=\"tl\">";
						strFood += "<div class=\"tr\">";
						strFood += strMyFood;
						strFood += "</div></div></div></div></div></div></div></div>";
					}

					// Look for Science.
					string strScience = "";
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldChanges/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						strScience += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/research.png\" alt=\"research\" /> ";
					}
					foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Building_YieldModifiers/Row[BuildingType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
					{
						strScience += "+" + objModifier["Yield"].InnerText + "% <img src=\"/civilopedia/images/research.png\" alt=\"research\" /> ";
					}
					if (strScience != "")
					{
						string strMyScience = strScience;
						strScience = "<h2>" + TXT_KEY_PEDIA_GOLD_LABEL + "</h2>";
						strScience += "<div class=\"t\">";
						strScience += "<div class=\"b\">";
						strScience += "<div class=\"l\">";
						strScience += "<div class=\"r\">";
						strScience += "<div class=\"bl\">";
						strScience += "<div class=\"br\">";
						strScience += "<div class=\"tl\">";
						strScience += "<div class=\"tr\">";
						strScience += strMyScience;
						strScience += "</div></div></div></div></div></div></div></div>";
					}

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
					strOutput = strOutput.Replace("##COST##", strCost);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##PREREQ##", strPrereq);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);
					strOutput = strOutput.Replace("##MAINTENANCE##", strMaintenance);
					strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);
					strOutput = strOutput.Replace("##REPLACES##", strReplaces);
					strOutput = strOutput.Replace("##REQUIRED##", strRequired);
					strOutput = strOutput.Replace("##DEFENSE##", strDefense);
					strOutput = strOutput.Replace("##HAPPINESS##", strHappiness);
					strOutput = strOutput.Replace("##PRODUCTION##", strProduction);
					strOutput = strOutput.Replace("##FOOD##", strFood);
					strOutput = strOutput.Replace("##GOLD##", strGold);
					strOutput = strOutput.Replace("##SCIENCE##", strScience);
					strOutput = strOutput.Replace("##CULTURE##", strCulture);
					strOutput = strOutput.Replace("##FAITH##", string.Empty);
					strOutput = strOutput.Replace("##GREATPEOPLE##", string.Empty);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == strBuildingClass)
						{
							objGroup = objCurrentGroup;
							break;
						}
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_WONDERS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"WONDER_HOME.aspx\"><div id=\"BUILDING_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Wonders.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Policy pages.
		/// </summary>
		private void GeneratePolicies()
		{
			txtDebug.Text += "\r\nGenerating Policies...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_POLICIES_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_POLICIES");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_SOCIAL_POL_HELP_TEXT");
			const string strHomeImage = "POLICY_GENERAL";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Policies";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "POLICY_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Policy Branches. This only creates the list of Groups.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_POLICIES.aspx"));
			foreach (string strXmlFile in _lstPolicyBranchTypes)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/PolicyBranchTypes/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = "";
					try
					{
						strTitle = GetString(objTechnology["Description"].InnerText);
					}
					catch
					{
						strTitle = GetString(objTechnology["Description"].InnerText);
					}
					if (strTitle != "Unused")
					{
						// Create a GroupItem for this Policy.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Policy Branch already exists in the Group List, add this item to it, otherwise, create the new Group.
						if (objTechnology["Type"] != null)
						{
							bool blnFound = false;
							Group objGroup = new Group();
							foreach (Group objCurrentGroup in lstGroups)
							{
								if (objCurrentGroup.Key == objTechnology["Type"].InnerText)
								{
									objGroup = objCurrentGroup;
									blnFound = true;
									break;
								}
							}
							if (!blnFound)
							{
								objGroup.Key = objTechnology["Type"].InnerText;
								objGroup.Name = strTitle;
								lstGroups.Add(objGroup);
							}
						}
					}
				}
			}

			// Policy Pages.
			foreach (string strXmlFile in _lstPolicies)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Policies/Row"))
				{
					if (!objTechnology["Type"].InnerText.EndsWith("_FINISHER"))
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = "";
						string strXmlTitle = "";
						try
						{
							strTitle = GetString(objTechnology["Description"].InnerText);
							strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						}
						catch
						{
						}

						// Do not write out Policies that have had their Title set to Unused.
						if (strTitle != "Unused")
						{
							string strHelp = "";
							try
							{
								strHelp = GetString(objTechnology["Help"].InnerText);
								string strMyHelp = strHelp;
								strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
								strHelp += "<div class=\"t\">";
								strHelp += "<div class=\"b\">";
								strHelp += "<div class=\"l\">";
								strHelp += "<div class=\"r\">";
								strHelp += "<div class=\"bl\">";
								strHelp += "<div class=\"br\">";
								strHelp += "<div class=\"tl\">";
								strHelp += "<div class=\"tr\">";
								strHelp += strMyHelp;
								strHelp += "</div></div></div></div></div></div></div></div>";
							}
							catch
							{
							}
							string strDesc = GetString(objTechnology["Civilopedia"].InnerText);
							string strMyDesc = strDesc;
							strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
							strDesc += "<div class=\"t\">";
							strDesc += "<div class=\"b\">";
							strDesc += "<div class=\"l\">";
							strDesc += "<div class=\"r\">";
							strDesc += "<div class=\"bl\">";
							strDesc += "<div class=\"br\">";
							strDesc += "<div class=\"tl\">";
							strDesc += "<div class=\"tr\">";
							strDesc += strMyDesc;
							strDesc += "</div></div></div></div></div></div></div></div>";
							
							string strBranch = "";

							// Determine Branch.
							strBranch = "";
							if (objTechnology["PolicyBranchType"] != null)
							{
								strBranch += "<h2>" + TXT_KEY_PEDIA_POLICYBRANCH_LABEL + "</h2>";
								strBranch += "<div class=\"t\">";
								strBranch += "<div class=\"b\">";
								strBranch += "<div class=\"l\">";
								strBranch += "<div class=\"r\">";
								strBranch += "<div class=\"bl\">";
								strBranch += "<div class=\"br\">";
								strBranch += "<div class=\"tl\">";
								strBranch += "<div class=\"tr\">";
								strBranch += GetString("TXT_KEY_" + objTechnology["PolicyBranchType"].InnerText);
								strBranch += "</div></div></div></div></div></div></div></div>";
							}

							string strTenet = "";

							// Determine Ideological Tenet Level.
							strTenet = "";
							if (objTechnology["Level"] != null)
							{
								strTenet += "<h2>" + TXT_KEY_PEDIA_TENET_LEVEL + ":</h2>";
								strTenet += "<div class=\"t\">";
								strTenet += "<div class=\"b\">";
								strTenet += "<div class=\"l\">";
								strTenet += "<div class=\"r\">";
								strTenet += "<div class=\"bl\">";
								strTenet += "<div class=\"br\">";
								strTenet += "<div class=\"tl\">";
								strTenet += "<div class=\"tr\">";
								strTenet += GetString("TXT_KEY_POLICYSCREEN_L" + objTechnology["Level"].InnerText + "_TENET");
								strTenet += "</div></div></div></div></div></div></div></div>";
							}

							// Look for Prereq Policies.
							string strPrereq = "";
							foreach (XmlNode objPrereq in objDocument.SelectNodes("/GameData/Policy_PrereqPolicies/Row[PolicyType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								if (strPrereq == "")
								{
									strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_POLICY_LABEL + "</h2>";
									strPrereq += "<div class=\"t\">";
									strPrereq += "<div class=\"b\">";
									strPrereq += "<div class=\"l\">";
									strPrereq += "<div class=\"r\">";
									strPrereq += "<div class=\"bl\">";
									strPrereq += "<div class=\"br\">";
									strPrereq += "<div class=\"tl\">";
									strPrereq += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstPolicies, "Policies", objPrereq["PrereqPolicy"].InnerText);
								strPrereq += "<a href=\"" + objPrereq["PrereqPolicy"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["PrereqPolicy"].InnerText + ".png\" /></a>";
							}
							if (strPrereq != "")
								strPrereq += "</div></div></div></div></div></div></div></div>";

							string strImage = "";
							if (objTechnology["PolicyBranchType"] != null)
								strImage = objTechnology["Type"].InnerText;
							else
								strImage = "POLICY_GENERAL";

							// Determine Era.
							string strEra = "";
							if (objTechnology["PolicyBranchType"] != null)
							{
								foreach (string strBranchFile in _lstPolicyBranchTypes)
								{
									XmlDocument objBranchDoc = new XmlDocument();
									objBranchDoc.Load(strBranchFile);

									XmlNode objEra = objBranchDoc.SelectSingleNode("/GameData/PolicyBranchTypes/Row[Type = \"" + objTechnology["PolicyBranchType"].InnerText + "\"]");
									if (objEra != null)
									{
										if (objEra["EraPrereq"] != null)
										{
											if (strEra == "")
											{
												strEra += "<h2>" + TXT_KEY_PEDIA_PREREQ_ERA_LABEL + "</h2>";
												strEra += "<div class=\"t\">";
												strEra += "<div class=\"b\">";
												strEra += "<div class=\"l\">";
												strEra += "<div class=\"r\">";
												strEra += "<div class=\"bl\">";
												strEra += "<div class=\"br\">";
												strEra += "<div class=\"tl\">";
												strEra += "<div class=\"tr\">";
											}
											strEra += GetEra(objEra["EraPrereq"].InnerText);
										}
									}
								}
							}
							if (strEra != "")
								strEra += "</div></div></div></div></div></div></div></div>";

							string strOutput = strTeplate;
							strOutput = strOutput.Replace("##TITLE##", strTitle);
							strOutput = strOutput.Replace("##IMAGE##", strImage);
							strOutput = strOutput.Replace("##HELP##", strHelp);
							strOutput = strOutput.Replace("##DESC##", strDesc);
							strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
							strOutput = strOutput.Replace("##PREREQ##", strPrereq);
							strOutput = strOutput.Replace("##BRANCH##", strBranch);
							strOutput = strOutput.Replace("##TENET##", strTenet);
							strOutput = strOutput.Replace("##ERA##", strEra);

							// Create a GroupItem for this Policy.
							GroupItem objItem = new GroupItem();
							objItem.Key = objTechnology["Type"].InnerText;
							objItem.Name = strTitle;

							// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
							string strBranchKey = "";
							if (objTechnology["PolicyBranchType"] != null)
							{
								strBranchKey = objTechnology["PolicyBranchType"].InnerText;
							}
							else
							{
								strBranchKey = objTechnology["Type"].InnerText.Replace("POLICY_", "POLICY_BRANCH_");
							}
							Group objGroup = new Group();
							foreach (Group objCurrentGroup in lstGroups)
							{
								if (objCurrentGroup.Key == strBranchKey)
								{
									objGroup = objCurrentGroup;
									break;
								}
							}
							objGroup.GroupItems.Add(objItem);

							_strXml += "\t\t<page>";
							_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
							_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
							_strXml += "\t\t</page>";

							// Create the Image.
							if (_strLanguage == "en_US")
							{
								CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
								CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
							}

							File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
						}
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_POLICIES_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"POLICY_HOME.aspx\"><div id=\"POLICY_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Policies.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Geart People pages.
		/// </summary>
		private void GeneratePeople()
		{
			txtDebug.Text += "\r\nGenerating Great People...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objSpecialists = new Group();
			objSpecialists.Key = "SPECIALISTS";
			objSpecialists.Name = GetString("TXT_KEY_PEOPLE_SECTION_1");
			lstGroups.Add(objSpecialists);

			Group objGreatPeople = new Group();
			objGreatPeople.Key = "GREAT_PEOPLE";
			objGreatPeople.Name = GetString("TXT_KEY_PEOPLE_SECTION_2");
			lstGroups.Add(objGreatPeople);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_PEOPLE_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_PEOPLE");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_SPEC_HELP_TEXT");
			const string strHomeImage = "UNIT_ENGINEER";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "People";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "GREAT_PERSON_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Specialist Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_PEOPLE.aspx"));
			foreach (String strXmlFile in _lstSpecialists)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Specialists/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					string strStrategy = "";
					try
					{
						strStrategy = GetString(objTechnology["Strategy"].InnerText);
						if (strStrategy != "")
						{
							string strMyStrategy = strStrategy;
							strStrategy = "<h2>" + TXT_KEY_PEDIA_STRATEGY_LABEL + "</h2>";
							strStrategy += "<div class=\"t\">";
							strStrategy += "<div class=\"b\">";
							strStrategy += "<div class=\"l\">";
							strStrategy += "<div class=\"r\">";
							strStrategy += "<div class=\"bl\">";
							strStrategy += "<div class=\"br\">";
							strStrategy += "<div class=\"tl\">";
							strStrategy += "<div class=\"tr\">";
							strStrategy += strMyStrategy;
							strStrategy += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					string strDesc = "";
					try
					{
						strDesc = GetString(objTechnology["Civilopedia"].InnerText);
						if (strDesc != "")
						{
							string strMyDesc = strDesc;
							strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
							strDesc += "<div class=\"t\">";
							strDesc += "<div class=\"b\">";
							strDesc += "<div class=\"l\">";
							strDesc += "<div class=\"r\">";
							strDesc += "<div class=\"bl\">";
							strDesc += "<div class=\"br\">";
							strDesc += "<div class=\"tl\">";
							strDesc += "<div class=\"tr\">";
							strDesc += strMyDesc;
							strDesc += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == "SPECIALISTS")
						{
							objGroup = objCurrentGroup;
							break;
						}
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Great People Pages.
			foreach (String strXmlFile in _lstUnits)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Units/Row"))
				{
					bool blnGreatPerson = false;
					if (objTechnology["Special"] != null)
					{
						blnGreatPerson = (objTechnology["Special"].InnerText == "SPECIALUNIT_PEOPLE");
					}

					if (blnGreatPerson)
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strHelp = "";
						try
						{
							strHelp = GetString(objTechnology["Help"].InnerText);
							if (strHelp != "")
							{
								string strMyHelp = strHelp;
								strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
								strHelp += "<div class=\"t\">";
								strHelp += "<div class=\"b\">";
								strHelp += "<div class=\"l\">";
								strHelp += "<div class=\"r\">";
								strHelp += "<div class=\"bl\">";
								strHelp += "<div class=\"br\">";
								strHelp += "<div class=\"tl\">";
								strHelp += "<div class=\"tr\">";
								strHelp += strMyHelp;
								strHelp += "</div></div></div></div></div></div></div></div>";
							}
						}
						catch
						{
						}
						string strStrategy = "";
						try
						{
							strStrategy = GetString(objTechnology["Strategy"].InnerText);
							if (strStrategy != "")
							{
								string strMyStrategy = strStrategy;
								strStrategy = "<h2>" + TXT_KEY_PEDIA_STRATEGY_LABEL + "</h2>";
								strStrategy += "<div class=\"t\">";
								strStrategy += "<div class=\"b\">";
								strStrategy += "<div class=\"l\">";
								strStrategy += "<div class=\"r\">";
								strStrategy += "<div class=\"bl\">";
								strStrategy += "<div class=\"br\">";
								strStrategy += "<div class=\"tl\">";
								strStrategy += "<div class=\"tr\">";
								strStrategy += strMyStrategy;
								strStrategy += "</div></div></div></div></div></div></div></div>";
							}
						}
						catch
						{
						}
						string strDesc = "";
						try
						{
							strDesc = GetString(objTechnology["Civilopedia"].InnerText);
							if (strDesc != "")
							{
								string strMyDesc = strDesc;
								strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
								strDesc += "<div class=\"t\">";
								strDesc += "<div class=\"b\">";
								strDesc += "<div class=\"l\">";
								strDesc += "<div class=\"r\">";
								strDesc += "<div class=\"bl\">";
								strDesc += "<div class=\"br\">";
								strDesc += "<div class=\"tl\">";
								strDesc += "<div class=\"tr\">";
								strDesc += strMyDesc;
								strDesc += "</div></div></div></div></div></div></div></div>";
							}
						}
						catch
						{
						}

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##HELP##", strHelp);
						strOutput = strOutput.Replace("##STRATEGY##", strStrategy);
						strOutput = strOutput.Replace("##DESC##", strDesc);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == "GREAT_PEOPLE")
							{
								objGroup = objCurrentGroup;
								break;
							}
						}
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_PEOPLE_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"GREAT_PERSON_HOME.aspx\"><div id=\"GREAT_PERSON_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "People.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Civilization pages.
		/// </summary>
		private void GenerateCivilizations()
		{
			txtDebug.Text += "\r\nGenerating Civilizations...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_CIVILIZATIONS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_CIVS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_CIVS_HELP_TEXT");
			const string strHomeImage = "LEADER_ALEXANDER";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Civilizations";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "CIVILIZATION_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Civilization Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CIVILIZATIONS.aspx"));
			foreach (string strXmlFile in _lstCivilizations)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Civilizations/Row"))
				{
					if (objTechnology["Type"].InnerText != "CIVILIZATION_MINOR" && objTechnology["Type"].InnerText != "CIVILIZATION_BARBARIAN")
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["ShortDescription"].InnerText);
						string strXmlTitle = GetString(objTechnology["ShortDescription"].InnerText, false);

						string strDesc = "";
						// Get all of the Headings and Text.
						for (int i = 1; i <= 30; i++)
						{
							string strItemTitle = GetString(objTechnology["CivilopediaTag"].InnerText + "_HEADING_" + i.ToString());
							string strItemText = GetString(objTechnology["CivilopediaTag"].InnerText + "_TEXT_" + i.ToString());

							if (strItemTitle != "")
							{
								strDesc += "\n<h2>" + strItemTitle + "</h2>";
								strDesc += "<div class=\"t\">";
								strDesc += "<div class=\"b\">";
								strDesc += "<div class=\"l\">";
								strDesc += "<div class=\"r\">";
								strDesc += "<div class=\"bl\">";
								strDesc += "<div class=\"br\">";
								strDesc += "<div class=\"tl\">";
								strDesc += "<div class=\"tr\">";
								strDesc += strItemText;
								strDesc += "</div></div></div></div></div></div></div></div>";
							}
							else
								break;
						}

						string strFactoidHeading = "\n<h2>" + GetString(objTechnology["CivilopediaTag"].InnerText + "_FACTOID_HEADING") + "</h2>";
						string strFactoidText = "<div class=\"t\">";
						strFactoidText += "<div class=\"b\">";
						strFactoidText += "<div class=\"l\">";
						strFactoidText += "<div class=\"r\">";
						strFactoidText += "<div class=\"bl\">";
						strFactoidText += "<div class=\"br\">";
						strFactoidText += "<div class=\"tl\">";
						strFactoidText += "<div class=\"tr\">";
						strFactoidText += GetString(objTechnology["CivilopediaTag"].InnerText + "_FACTOID_TEXT");
						strFactoidText += "</div></div></div></div></div></div></div></div>";

						// Determine Leaders.
						string strLeaders = "";
						foreach (XmlNode objLeader in objDocument.SelectNodes("/GameData/Civilization_Leaders/Row[CivilizationType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							string strMyTitle = FindDescription(_lstLeaders, "Leaders", objLeader["LeaderheadType"].InnerText);
							strLeaders += "<a href=\"" + objLeader["LeaderheadType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objLeader["LeaderheadType"].InnerText + ".png\" /></a>";
						}
						if (strLeaders != "")
						{
							string strMyLeaders = strLeaders;
							strLeaders = "<h2>" + TXT_KEY_PEDIA_LEADERS_LABEL + "</h2>";
							strLeaders += "<div class=\"t\">";
							strLeaders += "<div class=\"b\">";
							strLeaders += "<div class=\"l\">";
							strLeaders += "<div class=\"r\">";
							strLeaders += "<div class=\"bl\">";
							strLeaders += "<div class=\"br\">";
							strLeaders += "<div class=\"tl\">";
							strLeaders += "<div class=\"tr\">";
							strLeaders += strMyLeaders;
							strLeaders += "</div></div></div></div></div></div></div></div>";
						}

						// Determine Unique Units.
						string strUnits = "";
						foreach (XmlNode objUnit in objDocument.SelectNodes("/GameData/Civilization_UnitClassOverrides/Row[CivilizationType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							string strMyTitle = FindDescription(_lstUnits, "Units", objUnit["UnitType"].InnerText);
							strUnits += "<a href=\"" + objUnit["UnitType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objUnit["UnitType"].InnerText + ".png\" /></a>";
						}
						if (strUnits != "")
						{
							string strMyUnits = strUnits;
							strUnits = "<h2>" + TXT_KEY_PEDIA_UNIQUEUNIT_LABEL + "</h2>";
							strUnits += "<div class=\"t\">";
							strUnits += "<div class=\"b\">";
							strUnits += "<div class=\"l\">";
							strUnits += "<div class=\"r\">";
							strUnits += "<div class=\"bl\">";
							strUnits += "<div class=\"br\">";
							strUnits += "<div class=\"tl\">";
							strUnits += "<div class=\"tr\">";
							strUnits += strMyUnits;
							strUnits += "</div></div></div></div></div></div></div></div>";
						}

						// Determine Unique Buildings.
						string strBuildings = "";
						foreach (XmlNode objPrereq in objDocument.SelectNodes("/GameData/Civilization_BuildingClassOverrides/Row[CivilizationType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							if (strBuildings == "")
							{
								strBuildings += "<h2>" + TXT_KEY_PEDIA_UNIQUEBLDG_LABEL + "</h2>";
								strBuildings += "<div class=\"t\">";
								strBuildings += "<div class=\"b\">";
								strBuildings += "<div class=\"l\">";
								strBuildings += "<div class=\"r\">";
								strBuildings += "<div class=\"bl\">";
								strBuildings += "<div class=\"br\">";
								strBuildings += "<div class=\"tl\">";
								strBuildings += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstBuildings, "Buildings", objPrereq["BuildingType"].InnerText);
							strBuildings += "<a href=\"" + objPrereq["BuildingType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["BuildingType"].InnerText + ".png\" /></a>";
						}
						if (strBuildings != "")
							strBuildings += "</div></div></div></div></div></div></div></div>";

						// Determine Unique Improvements.
						string strImprovements = "";
						foreach (string strImprovementFile in _lstImprovements)
						{
							XmlDocument objImprovementDoc = new XmlDocument();
							objImprovementDoc.Load(strImprovementFile);
							foreach (XmlNode objPrereq in objImprovementDoc.SelectNodes("/GameData/Improvements/Row[CivilizationType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								if (strImprovements == "")
								{
									strImprovements += "<h2>" + TXT_KEY_PEDIA_UNIQUEIMPRV_LABEL + "</h2>";
									strImprovements += "<div class=\"t\">";
									strImprovements += "<div class=\"b\">";
									strImprovements += "<div class=\"l\">";
									strImprovements += "<div class=\"r\">";
									strImprovements += "<div class=\"bl\">";
									strImprovements += "<div class=\"br\">";
									strImprovements += "<div class=\"tl\">";
									strImprovements += "<div class=\"tr\">";
								}
								string strMyTitle = FindDescription(_lstImprovements, "Improvements", objPrereq["Type"].InnerText);
								strImprovements += "<a href=\"" + objPrereq["Type"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objPrereq["Type"].InnerText + ".png\" /></a>";
							}
						}
						if (strImprovements != "")
							strImprovements += "</div></div></div></div></div></div></div></div>";

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
						strOutput = strOutput.Replace("##DESC##", strDesc);
						strOutput = strOutput.Replace("##LEADERS##", strLeaders);
						strOutput = strOutput.Replace("##UNIQUEUNITS##", strUnits);
						strOutput = strOutput.Replace("##UNIQUEBUILDINGS##", strBuildings);
						strOutput = strOutput.Replace("##UNIQUEIMPROVEMENTS##", strImprovements);
						strOutput = strOutput.Replace("##FACTOIDHEADING##", strFactoidHeading);
						strOutput = strOutput.Replace("##FACTOIDTEXT##", strFactoidText);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						bool blnFound = false;
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == "CIVILIZATIONS")
							{
								objGroup = objCurrentGroup;
								blnFound = true;
								break;
							}
						}
						if (!blnFound)
						{
							objGroup.Key = "CIVILIZATIONS";
							objGroup.Name = GetString("TXT_KEY_CIVILIZATIONS_SECTION_1");
							lstGroups.Add(objGroup);
						}
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Leader Pages.
			strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_LEADERS.aspx"));
			foreach (string strXmlFile in _lstLeaders)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Leaders/Row"))
				{
					if (!objTechnology["Description"].InnerText.EndsWith("BARBARIAN"))
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strSubtitle = GetString(objTechnology["CivilopediaTag"].InnerText + "_SUBTITLE");
						string strLived = GetString(objTechnology["CivilopediaTag"].InnerText + "_LIVED");

						string strMyLived = strLived;
						strLived = "<h2>" + TXT_KEY_PEDIA_LIVED_LABEL + "</h2>";
						strLived += "<div class=\"t\">";
						strLived += "<div class=\"b\">";
						strLived += "<div class=\"l\">";
						strLived += "<div class=\"r\">";
						strLived += "<div class=\"bl\">";
						strLived += "<div class=\"br\">";
						strLived += "<div class=\"tl\">";
						strLived += "<div class=\"tr\">";
						strLived += strMyLived;
						strLived += "</div></div></div></div></div></div></div></div>";

						string strTitles = "";
						// Get all of the Titles.
						for (int i = 1; i <= 10; i++)
						{
							string strItemText = GetString(objTechnology["CivilopediaTag"].InnerText + "_TITLES_" + i.ToString());

							if (strItemText != "")
							{
								strTitles += strItemText + "<br /><br />";
							}
							else
								break;
						}
						// Remove the two trailing <br /> tags.
						if (strTitles != "")
						{
							strTitles = strTitles.Substring(0, strTitles.Length - 12);
							string strMyTitles = strTitles;
							strTitles = "<h2>" + TXT_KEY_PEDIA_TITLES_LABEL + "</h2>";
							strTitles += "<div class=\"t\">";
							strTitles += "<div class=\"b\">";
							strTitles += "<div class=\"l\">";
							strTitles += "<div class=\"r\">";
							strTitles += "<div class=\"bl\">";
							strTitles += "<div class=\"br\">";
							strTitles += "<div class=\"tl\">";
							strTitles += "<div class=\"tr\">";
							strTitles += strMyTitles;
							strTitles += "</div></div></div></div></div></div></div></div>";
						}

						string strDesc = "";
						// Get all of the Headings and Text.
						for (int i = 1; i <= 30; i++)
						{
							string strItemTitle = GetString(objTechnology["CivilopediaTag"].InnerText + "_HEADING_" + i.ToString());
							string strItemText = GetString(objTechnology["CivilopediaTag"].InnerText + "_TEXT_" + i.ToString());

							if (strItemTitle != "")
							{
								strDesc += "\n<h2>" + strItemTitle + "</h2>";
								strDesc += "<div class=\"t\">";
								strDesc += "<div class=\"b\">";
								strDesc += "<div class=\"l\">";
								strDesc += "<div class=\"r\">";
								strDesc += "<div class=\"bl\">";
								strDesc += "<div class=\"br\">";
								strDesc += "<div class=\"tl\">";
								strDesc += "<div class=\"tr\">";
								strDesc += strItemText;
								strDesc += "</div></div></div></div></div></div></div></div>";
							}
							else
								break;
						}

						string strCivilization = "";
						// Determine Civilization.
						foreach (string strCivilizationFile in _lstCivilizations)
						{
							XmlDocument objCivilizationDoc = new XmlDocument();
							objCivilizationDoc.Load(strCivilizationFile);
							XmlNode objCivilization = objCivilizationDoc.SelectSingleNode("/GameData/Civilization_Leaders/Row[LeaderheadType = \"" + objTechnology["Type"].InnerText + "\"]");
							if (objCivilization != null)
							{
								string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objCivilization["CivilizationType"].InnerText);
								strCivilization += "<a href=\"" + objCivilization["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objCivilization["CivilizationType"].InnerText + ".png\" /></a>";
								string strMyCivilization = strCivilization;
								strCivilization = "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
								strCivilization += "<div class=\"t\">";
								strCivilization += "<div class=\"b\">";
								strCivilization += "<div class=\"l\">";
								strCivilization += "<div class=\"r\">";
								strCivilization += "<div class=\"bl\">";
								strCivilization += "<div class=\"br\">";
								strCivilization += "<div class=\"tl\">";
								strCivilization += "<div class=\"tr\">";
								strCivilization += strMyCivilization;
								strCivilization += "</div></div></div></div></div></div></div></div>";
								break;
							}
						}

						string strTrait = "";
						// Determine Trait.
						XmlNode objLeaderTrait = objDocument.SelectSingleNode("/GameData/Leader_Traits/Row[LeaderType = \"" + objTechnology["Type"].InnerText + "\"]");
						string strTraitName = objLeaderTrait["TraitType"].InnerText;
						foreach (string strTraitFile in _lstTraits)
						{
							XmlDocument objTraitDoc = new XmlDocument();
							objTraitDoc.Load(strTraitFile);
							XmlNode objTrait = objTraitDoc.SelectSingleNode("/GameData/Traits/Row[Type = \"" + strTraitName + "\"]");
							if (objTrait != null)
							{
								string strTraitTitle = GetString(objTrait["ShortDescription"].InnerText);
								string strTraitText = GetString(objTrait["Description"].InnerText);

								strTrait = strTraitTitle + "<br /><br />" + strTraitText;
								string strMyTrait = strTrait;
								strTrait = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
								strTrait += "<div class=\"t\">";
								strTrait += "<div class=\"b\">";
								strTrait += "<div class=\"l\">";
								strTrait += "<div class=\"r\">";
								strTrait += "<div class=\"bl\">";
								strTrait += "<div class=\"br\">";
								strTrait += "<div class=\"tl\">";
								strTrait += "<div class=\"tr\">";
								strTrait += strMyTrait;
								strTrait += "</div></div></div></div></div></div></div></div>";
								break;
							}
						}

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##SUBTITLE##", strSubtitle);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
						strOutput = strOutput.Replace("##TRAIT##", strTrait);
						strOutput = strOutput.Replace("##DESC##", strDesc);
						strOutput = strOutput.Replace("##LIVED##", strLived);
						strOutput = strOutput.Replace("##TITLES##", strTitles);
						strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						bool blnFound = false;
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == "LEADERS")
							{
								objGroup = objCurrentGroup;
								blnFound = true;
								break;
							}
						}
						if (!blnFound)
						{
							objGroup.Key = "LEADERS";
							objGroup.Name = GetString("TXT_KEY_CIVILIZATIONS_SECTION_2");
							lstGroups.Add(objGroup);
						}
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CIVILIZATIONS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"CIVILIZATION_HOME.aspx\"><div id=\"CIVILIZATION_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Civilizations.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate City-State pages.
		/// </summary>
		private void GenerateCityStates()
		{
			txtDebug.Text += "\r\nGenerating City-States...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_CITY_STATES_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_CITYSTATES");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_CSTATES_HELP_TEXT");
			const string strHomeImage = "UNIT_ARTIST";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Citystates";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "CITY_STATE_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CITY_STATES.aspx"));
			foreach (string strXmlFile in _lstCityStates)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/MinorCivilizations/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);

					string strHelp = GetString(objTechnology["Civilopedia"].InnerText);
					string strMyHelp = strHelp;
					strHelp = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
					strHelp += "<div class=\"t\">";
					strHelp += "<div class=\"b\">";
					strHelp += "<div class=\"l\">";
					strHelp += "<div class=\"r\">";
					strHelp += "<div class=\"bl\">";
					strHelp += "<div class=\"br\">";
					strHelp += "<div class=\"tl\">";
					strHelp += "<div class=\"tr\">";
					strHelp += strMyHelp;
					strHelp += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##HELP##", strHelp);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					bool blnFound = false;
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == objTechnology["MinorCivTrait"].InnerText)
						{
							objGroup = objCurrentGroup;
							blnFound = true;
							break;
						}
					}
					if (!blnFound)
					{
						objGroup.Key = objTechnology["MinorCivTrait"].InnerText;
						objGroup.Name = GetString("TXT_KEY_" + objTechnology["MinorCivTrait"].InnerText);
						lstGroups.Add(objGroup);
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Put the groups into alphabetical order.
			SortByName objSort = new SortByName();
			lstGroups.Sort(objSort.Compare);

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_CITY_STATES_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"CITY_STATE_HOME.aspx\"><div id=\"CITY_STATE_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "CityStates.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Terrains and Features pages.
		/// </summary>
		private void GenerateTerrains()
		{
			txtDebug.Text += "\r\nGenerating Terrains and Features...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_TERRAIN_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_TERRAIN");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_TERRAIN_HELP_TEXT");
			strHomeDesc += "</div></div></div></div></div></div></div></div>";
			strHomeDesc += "<h2>" + GetString("TXT_KEY_PEDIA_TERRAIN_FEATURES_LABEL") + "</h2>";
			strHomeDesc += "<div class=\"t\"><div class=\"b\"><div class=\"l\"><div class=\"r\"><div class=\"bl\"><div class=\"br\"><div class=\"tl\"><div class=\"tr\">";
			strHomeDesc += GetString("TXT_KEY_PEDIA_TERRAIN_FEATURES_HELP_TEXT");
			const string strHomeImage = "TERRAIN_HILL";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Terrains";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "TERRAIN_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Terrain Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_TERRAINS.aspx"));
			foreach (string strXmlFile in _lstTerrains)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Terrains/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strDesc = GetString(objTechnology["Civilopedia"].InnerText);
					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					// Determine Yields.
					string strYields = "";
					foreach (XmlNode objYield in objDocument.SelectNodes("/GameData/Terrain_Yields/Row[TerrainType = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						strYields += objYield["Yield"].InnerText + " " + ParseString(objYield["YieldType"].InnerText) + " ";
					}
					if (strYields == "")
						strYields = GetString("TXT_KEY_PEDIA_NO_YIELD");
					if (objTechnology["Type"].InnerText == "TERRAIN_HILL")
						strYields = "2 <img src=\"/civilopedia/images/production.png\" alt=\"production\" />";
					string strMyYields = strYields;
					strYields = "<h2>" + TXT_KEY_PEDIA_YIELD_LABEL + "</h2>";
					strYields += "<div class=\"t\">";
					strYields += "<div class=\"b\">";
					strYields += "<div class=\"l\">";
					strYields += "<div class=\"r\">";
					strYields += "<div class=\"bl\">";
					strYields += "<div class=\"br\">";
					strYields += "<div class=\"tl\">";
					strYields += "<div class=\"tr\">";
					strYields += strMyYields;
					strYields += "</div></div></div></div></div></div></div></div>";

					// Determine Features.
					string strFeatures = "";
					foreach (string strFeatureFile in _lstFeatures)
					{
						XmlDocument objFeatureDoc = new XmlDocument();
						objFeatureDoc.Load(strFeatureFile);

						foreach (XmlNode objFeature in objFeatureDoc.SelectNodes("/GameData/Feature_TerrainBooleans/Row[TerrainType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							if (strFeatures == "")
							{
								strFeatures += "\n<h2>" + TXT_KEY_PEDIA_FEATURES_LABEL + "</h2>";
								strFeatures += "<div class=\"t\">";
								strFeatures += "<div class=\"b\">";
								strFeatures += "<div class=\"l\">";
								strFeatures += "<div class=\"r\">";
								strFeatures += "<div class=\"bl\">";
								strFeatures += "<div class=\"br\">";
								strFeatures += "<div class=\"tl\">";
								strFeatures += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstFeatures, "Features", objFeature["FeatureType"].InnerText);
							strFeatures += "<a href=\"" + objFeature["FeatureType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objFeature["FeatureType"].InnerText + ".png\" /></a>";
						}
					}
					if (strFeatures != "")
						strFeatures += "</div></div></div></div></div></div></div></div>";

					// Determine Resources.
					string strResources = "";
					foreach (string strResourceFile in _lstResources)
					{
						XmlDocument objResourceDoc = new XmlDocument();
						objResourceDoc.Load(strResourceFile);
						string strXPath = "";
						string strElement = "";
						if (objTechnology["Type"].InnerText == "TERRAIN_HILL")
						{
							strXPath = "/GameData/Resources/Row[Hills = \"true\"]";
							strElement = "Type";
						}
						else
						{
							strXPath = "/GameData/Resource_TerrainBooleans/Row[TerrainType = \"" + objTechnology["Type"].InnerText + "\"]";
							strElement = "ResourceType";
						}
						foreach (XmlNode objRecource in objResourceDoc.SelectNodes(strXPath))
						{
							if (strResources == "")
							{
								strResources += "\n<h2>" + TXT_KEY_PEDIA_RESOURCESFOUND_LABEL + "</h2>";
								strResources += "<div class=\"t\">";
								strResources += "<div class=\"b\">";
								strResources += "<div class=\"l\">";
								strResources += "<div class=\"r\">";
								strResources += "<div class=\"bl\">";
								strResources += "<div class=\"br\">";
								strResources += "<div class=\"tl\">";
								strResources += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstResources, "Resources", objRecource[strElement].InnerText);
							strResources += "<a href=\"" + objRecource[strElement].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objRecource[strElement].InnerText + ".png\" /></a>";
						}
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					// Define Moves.
					string strMoves = "";
					switch (objTechnology["Type"].InnerText)
					{
						case "TERRAIN_HILL":
							strMoves = "2 <img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />";
							break;
						case "TERRAIN_MOUNTAIN":
							strMoves = "Impassable";
							break;
						default:
							strMoves = "1 <img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />";
							break;
					}
					string strMyMoves = strMoves;
					strMoves = "<h2>" + TXT_KEY_PEDIA_MOVECOST_LABEL + "</h2>";
					strMoves += "<div class=\"t\">";
					strMoves += "<div class=\"b\">";
					strMoves += "<div class=\"l\">";
					strMoves += "<div class=\"r\">";
					strMoves += "<div class=\"bl\">";
					strMoves += "<div class=\"br\">";
					strMoves += "<div class=\"tl\">";
					strMoves += "<div class=\"tr\">";
					strMoves += strMyMoves;
					strMoves += "</div></div></div></div></div></div></div></div>";

					// Define Combat.
					string strCombat = "";
					switch (objTechnology["Type"].InnerText)
					{
						case "TERRAIN_DESERT":
						case "TERRRAIN_GRASS":
						case "TERRAIN_PLAINS":
						case "TERRAIN_SNOW":
						case "TERRAIN_TUNDRA":
							strCombat = "-10%";
							break;
						case "TERRAIN_HILL":
						case "TERRAIN_MOUNTAIN":
							strCombat = "+25%";
							break;
						default:
							strCombat = "0%";
							break;
					}
					string strMyCombat = strCombat;
					strCombat = "<h2>" + TXT_KEY_PEDIA_COMBATMOD_LABEL + "</h2>";
					strCombat += "<div class=\"t\">";
					strCombat += "<div class=\"b\">";
					strCombat += "<div class=\"l\">";
					strCombat += "<div class=\"r\">";
					strCombat += "<div class=\"bl\">";
					strCombat += "<div class=\"br\">";
					strCombat += "<div class=\"tl\">";
					strCombat += "<div class=\"tr\">";
					strCombat += strMyCombat;
					strCombat += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", string.Empty);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##YIELDS##", strYields);
					strOutput = strOutput.Replace("##FEATURES##", strFeatures);
					strOutput = strOutput.Replace("##MOVES##", strMoves);
					strOutput = strOutput.Replace("##COMBAT##", strCombat);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					bool blnFound = false;
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == "TERRAINS")
						{
							objGroup = objCurrentGroup;
							blnFound = true;
							break;
						}
					}
					if (!blnFound)
					{
						objGroup.Key = "TERRAINS";
						objGroup.Name = GetString("TXT_KEY_TERRAIN_SECTION_1");
						lstGroups.Add(objGroup);
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Features Pages.
			foreach (string strXmlFile in _lstFeatures)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Features/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);

					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					
					string strDesc = GetString(objTechnology["Civilopedia"].InnerText);
					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					// Determine Yields.
					string strYields = "";
					foreach (XmlNode objYield in objDocument.SelectNodes("/GameData/Feature_YieldChanges/Row[FeatureType = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						strYields += objYield["Yield"].InnerText + " " + ParseString(objYield["YieldType"].InnerText) + " ";
					}
					if (objTechnology["Culture"] != null)
						strYields += objTechnology["Culture"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" />";
					if (objTechnology["InBorderHappiness"] != null)
						strYields += objTechnology["InBorderHappiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
					if (strYields == "")
						strYields = GetString("TXT_KEY_PEDIA_NO_YIELD");
					string strMyYields = strYields;
					strYields = "<h2>" + TXT_KEY_PEDIA_YIELD_LABEL + "</h2>";
					strYields += "<div class=\"t\">";
					strYields += "<div class=\"b\">";
					strYields += "<div class=\"l\">";
					strYields += "<div class=\"r\">";
					strYields += "<div class=\"bl\">";
					strYields += "<div class=\"br\">";
					strYields += "<div class=\"tl\">";
					strYields += "<div class=\"tr\">";
					strYields += strMyYields;
					strYields += "</div></div></div></div></div></div></div></div>";

					// Determine Moves.
					string strMoves = "";
					if (objTechnology["Movement"] != null)
						strMoves = objTechnology["Movement"].InnerText + " <img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />";
					if (objTechnology["Impassable"] != null)
					{
						if (objTechnology["Impassable"].InnerText == "true")
							strMoves = "Impassable";
					}
					string strMyMoves = strMoves;
					strMoves = "<h2>" + TXT_KEY_PEDIA_MOVECOST_LABEL + "</h2>";
					strMoves += "<div class=\"t\">";
					strMoves += "<div class=\"b\">";
					strMoves += "<div class=\"l\">";
					strMoves += "<div class=\"r\">";
					strMoves += "<div class=\"bl\">";
					strMoves += "<div class=\"br\">";
					strMoves += "<div class=\"tl\">";
					strMoves += "<div class=\"tr\">";
					strMoves += strMyMoves;
					strMoves += "</div></div></div></div></div></div></div></div>";

					// Determine Combat Modifer.
					string strCombat = "";
					if (objTechnology["Defense"] != null)
					{
						int intCombat = Convert.ToInt32(objTechnology["Defense"].InnerText);
						strCombat = intCombat.ToString() + "%";
						if (intCombat > 0)
							strCombat = "+" + strCombat;
					}
					if (strCombat == "")
						strCombat = "0%";
					string strMyCombat = strCombat;
					strCombat = "<h2>" + TXT_KEY_PEDIA_COMBATMOD_LABEL + "</h2>";
					strCombat += "<div class=\"t\">";
					strCombat += "<div class=\"b\">";
					strCombat += "<div class=\"l\">";
					strCombat += "<div class=\"r\">";
					strCombat += "<div class=\"bl\">";
					strCombat += "<div class=\"br\">";
					strCombat += "<div class=\"tl\">";
					strCombat += "<div class=\"tr\">";
					strCombat += strMyCombat;
					strCombat += "</div></div></div></div></div></div></div></div>";

					// Determine Resources.
					string strResources = "";
					foreach (string strResourceFile in _lstResources)
					{
						XmlDocument objResourceDoc = new XmlDocument();
						objResourceDoc.Load(strResourceFile);

						foreach (XmlNode objFeature in objResourceDoc.SelectNodes("/GameData/Resource_FeatureBooleans/Row[FeatureType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							if (strResources == "")
							{
								strResources += "\n<h2>" + TXT_KEY_PEDIA_RESOURCESFOUND_LABEL + "</h2>";
								strResources += "<div class=\"t\">";
								strResources += "<div class=\"b\">";
								strResources += "<div class=\"l\">";
								strResources += "<div class=\"r\">";
								strResources += "<div class=\"bl\">";
								strResources += "<div class=\"br\">";
								strResources += "<div class=\"tl\">";
								strResources += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstResources, "Resources", objFeature["ResourceType"].InnerText);
							strResources += "<a href=\"" + objFeature["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objFeature["ResourceType"].InnerText + ".png\" /></a>";
						}
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##YIELDS##", strYields);
					strOutput = strOutput.Replace("##MOVES##", strMoves);
					strOutput = strOutput.Replace("##COMBAT##", strCombat);
					strOutput = strOutput.Replace("##FEATURES##", string.Empty);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					bool blnFound = false;
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == "FEATURES")
						{
							objGroup = objCurrentGroup;
							blnFound = true;
							break;
						}
					}
					if (!blnFound)
					{
						objGroup.Key = "FEATURES";
						objGroup.Name = GetString("TXT_KEY_TERRAIN_SECTION_2");
						lstGroups.Add(objGroup);
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Fake Features Pages.
			foreach (string strXmlFile in _lstFeatures)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/FakeFeatures/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);

					string strHelp = "";
					try
					{
						strHelp = GetString(objTechnology["Help"].InnerText);
						if (strHelp != "")
						{
							string strMyHelp = strHelp;
							strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strHelp += "<div class=\"t\">";
							strHelp += "<div class=\"b\">";
							strHelp += "<div class=\"l\">";
							strHelp += "<div class=\"r\">";
							strHelp += "<div class=\"bl\">";
							strHelp += "<div class=\"br\">";
							strHelp += "<div class=\"tl\">";
							strHelp += "<div class=\"tr\">";
							strHelp += strMyHelp;
							strHelp += "</div></div></div></div></div></div></div></div>";
						}
					}
					catch
					{
					}
					
					string strDesc = GetString(objTechnology["Civilopedia"].InnerText);
					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					// Determine Yields.
					string strYields = "";
					foreach (XmlNode objYield in objDocument.SelectNodes("/GameData/Feature_YieldChanges/Row[FeatureType = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						strYields += objYield["Yield"].InnerText + " " + ParseString(objYield["YieldType"].InnerText) + " ";
					}
					if (objTechnology["Culture"] != null)
						strYields += objTechnology["Culture"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" />";
					if (objTechnology["InBorderHappiness"] != null)
						strYields += objTechnology["InBorderHappiness"].InnerText + " <img src=\"/civilopedia/images/happiness_1.png\" alt=\"happiness\" />";
					if (strYields == "")
						strYields = GetString("TXT_KEY_PEDIA_NO_YIELD");
					string strMyYields = strYields;
					strYields = "<h2>" + TXT_KEY_PEDIA_YIELD_LABEL + "</h2>";
					strYields += "<div class=\"t\">";
					strYields += "<div class=\"b\">";
					strYields += "<div class=\"l\">";
					strYields += "<div class=\"r\">";
					strYields += "<div class=\"bl\">";
					strYields += "<div class=\"br\">";
					strYields += "<div class=\"tl\">";
					strYields += "<div class=\"tr\">";
					strYields += strMyYields;
					strYields += "</div></div></div></div></div></div></div></div>";

					// Determine Moves.
					string strMoves = "";
					if (objTechnology["Movement"] != null)
					{
						strMoves = objTechnology["Movement"].InnerText;
						if (strMoves.StartsWith("TXT_KEY_"))
							strMoves = GetString(strMoves);
						strMoves += " <img src=\"/civilopedia/images/moves.png\" alt=\"moves\" />";
					}
					if (objTechnology["Impassable"] != null)
					{
						if (objTechnology["Impassable"].InnerText == "true")
							strMoves = "Impassable";
					}
					string strMyMoves = strMoves;
					strMoves = "<h2>" + TXT_KEY_PEDIA_MOVECOST_LABEL + "</h2>";
					strMoves += "<div class=\"t\">";
					strMoves += "<div class=\"b\">";
					strMoves += "<div class=\"l\">";
					strMoves += "<div class=\"r\">";
					strMoves += "<div class=\"bl\">";
					strMoves += "<div class=\"br\">";
					strMoves += "<div class=\"tl\">";
					strMoves += "<div class=\"tr\">";
					strMoves += strMyMoves;
					strMoves += "</div></div></div></div></div></div></div></div>";

					// Determine Combat Modifer.
					string strCombat = "";
					if (objTechnology["Defense"] != null)
					{
						int intCombat = Convert.ToInt32(objTechnology["Defense"].InnerText);
						strCombat = intCombat.ToString() + "%";
						if (intCombat > 0)
							strCombat = "+" + strCombat;
					}
					if (strCombat == "")
						strCombat = "0%";
					string strMyCombat = strCombat;
					strCombat = "<h2>" + TXT_KEY_PEDIA_COMBATMOD_LABEL + "</h2>";
					strCombat += "<div class=\"t\">";
					strCombat += "<div class=\"b\">";
					strCombat += "<div class=\"l\">";
					strCombat += "<div class=\"r\">";
					strCombat += "<div class=\"bl\">";
					strCombat += "<div class=\"br\">";
					strCombat += "<div class=\"tl\">";
					strCombat += "<div class=\"tr\">";
					strCombat += strMyCombat;
					strCombat += "</div></div></div></div></div></div></div></div>";

					// Determine Resources.
					string strResources = "";
					foreach (string strResourceFile in _lstResources)
					{
						XmlDocument objResourceDoc = new XmlDocument();
						objResourceDoc.Load(strResourceFile);

						foreach (XmlNode objFeature in objResourceDoc.SelectNodes("/GameData/Resource_FeatureBooleans/Row[FeatureType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							if (strResources == "")
							{
								strResources += "\n<h2>" + TXT_KEY_PEDIA_RESOURCESFOUND_LABEL + "</h2>";
								strResources += "<div class=\"t\">";
								strResources += "<div class=\"b\">";
								strResources += "<div class=\"l\">";
								strResources += "<div class=\"r\">";
								strResources += "<div class=\"bl\">";
								strResources += "<div class=\"br\">";
								strResources += "<div class=\"tl\">";
								strResources += "<div class=\"tr\">";
							}
							string strMyTitle = FindDescription(_lstResources, "Resources", objFeature["ResourceType"].InnerText);
							strResources += "<a href=\"" + objFeature["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objFeature["ResourceType"].InnerText + ".png\" /></a>";
						}
					}
					if (strResources != "")
						strResources += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##HELP##", strHelp);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
					strOutput = strOutput.Replace("##YIELDS##", strYields);
					strOutput = strOutput.Replace("##MOVES##", strMoves);
					strOutput = strOutput.Replace("##COMBAT##", strCombat);
					strOutput = strOutput.Replace("##FEATURES##", string.Empty);
					strOutput = strOutput.Replace("##RESOURCES##", strResources);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
					bool blnFound = false;
					Group objGroup = new Group();
					foreach (Group objCurrentGroup in lstGroups)
					{
						if (objCurrentGroup.Key == "FEATURES")
						{
							objGroup = objCurrentGroup;
							blnFound = true;
							break;
						}
					}
					if (!blnFound)
					{
						objGroup.Key = "FEATURES";
						objGroup.Name = GetString("TXT_KEY_TERRAIN_SECTION_2");
						lstGroups.Add(objGroup);
					}
					objGroup.GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					// Create the Image.
					if (_strLanguage == "en_US")
					{
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
						CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
					}

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_TERRAINS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"TERRAIN_HOME.aspx\"><div id=\"TERRAIN_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Terrains.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Resources pages.
		/// </summary>
		private void GenerateResources()
		{
			txtDebug.Text += "\r\nGenerating Resources...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objBonus = new Group();
			objBonus.Key = "BONUS_RESOURCES";
			objBonus.Name = GetString("TXT_KEY_RESOURCES_SECTION_0");
			lstGroups.Add(objBonus);

			Group objStrategic = new Group();
			objStrategic.Key = "STRATEGIC_RESOURCES";
			objStrategic.Name = GetString("TXT_KEY_RESOURCES_SECTION_1");
			lstGroups.Add(objStrategic);

			Group objLuxury = new Group();
			objLuxury.Key = "LUXURY_RESOURCES";
			objLuxury.Name = GetString("TXT_KEY_RESOURCES_SECTION_2");
			lstGroups.Add(objLuxury);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_RESOURCES_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_RESOURCES");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_RESOURCES_HELP_TEXT");
			const string strHomeImage = "RESOURCE_HORSE";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Resources";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "RESOURCE_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RESOURCES.aspx"));
			foreach (string strXmlFile in _lstResources)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				string strXPath = "";

				for (int i = 0; i <= 1; i++)
				{
					if (i == 0)
						strXPath = "/GameData/Resources/Row";
					else
						strXPath = "/GameData/Resources/InsertOrAbort";
					foreach (XmlNode objTechnology in objDocument.SelectNodes(strXPath))
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strHelp = GetString(objTechnology["Civilopedia"].InnerText);
						string strMyHelp = strHelp;
						strHelp = "<h2>" + TXT_KEY_PEDIA_HISTORICAL_LABEL + "</h2>";
						strHelp += "<div class=\"t\">";
						strHelp += "<div class=\"b\">";
						strHelp += "<div class=\"l\">";
						strHelp += "<div class=\"r\">";
						strHelp += "<div class=\"bl\">";
						strHelp += "<div class=\"br\">";
						strHelp += "<div class=\"tl\">";
						strHelp += "<div class=\"tr\">";
						strHelp += strMyHelp;
						strHelp += "</div></div></div></div></div></div></div></div>";

						// Determine Game Info.
						string strInfo = "";
						if (objTechnology["Help"] != null)
						{
							strInfo += "\n<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
							strInfo += "<div class=\"t\">";
							strInfo += "<div class=\"b\">";
							strInfo += "<div class=\"l\">";
							strInfo += "<div class=\"r\">";
							strInfo += "<div class=\"bl\">";
							strInfo += "<div class=\"br\">";
							strInfo += "<div class=\"tl\">";
							strInfo += "<div class=\"tr\">";
							strInfo += GetString(objTechnology["Help"].InnerText);
							strInfo += "</div></div></div></div></div></div></div></div>";
						}

						// Determine Yields.
						string strYields = "";
						foreach (XmlNode objYield in objDocument.SelectNodes("/GameData/Resource_YieldChanges/Row[ResourceType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							strYields += "+" + objYield["Yield"].InnerText + " " + ParseString(objYield["YieldType"].InnerText) + " ";
						}
						if (strYields == "")
							strYields = GetString("TXT_KEY_PEDIA_NO_YIELD");
						string strMyYields = strYields;
						strYields = "<h2>" + TXT_KEY_PEDIA_YIELD_LABEL + "</h2>";
						strYields += "<div class=\"t\">";
						strYields += "<div class=\"b\">";
						strYields += "<div class=\"l\">";
						strYields += "<div class=\"r\">";
						strYields += "<div class=\"bl\">";
						strYields += "<div class=\"br\">";
						strYields += "<div class=\"tl\">";
						strYields += "<div class=\"tr\">";
						strYields += strMyYields;
						strYields += "</div></div></div></div></div></div></div></div>";

						// Determine Terrains.
						string strTerrains = "";
						foreach (XmlNode objTerrain in objDocument.SelectNodes("/GameData/Resource_FeatureBooleans/Row[ResourceType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							string strMyTitle = FindDescription(_lstFeatures, "Features", objTerrain["FeatureType"].InnerText);
							strTerrains += "<a href=\"" + objTerrain["FeatureType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTerrain["FeatureType"].InnerText + ".png\" /></a>";
						}
						if (objTechnology["Hills"] != null)
						{
							if (objTechnology["Hills"].InnerText == "true")
								strTerrains += "<a href=\"TERRAIN_HILL.aspx\" onmouseover=\"return tooltip('" + GetString("TXT_KEY_TERRAIN_HILL") + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/TERRAIN_HILL.png\" /></a>";
						}
						foreach (XmlNode objTerrain in objDocument.SelectNodes("/GameData/Resource_TerrainBooleans/Row[ResourceType = \"" + objTechnology["Type"].InnerText + "\"]"))
						{
							string strMyTitle = FindDescription(_lstTerrains, "Terrains", objTerrain["TerrainType"].InnerText);
							strTerrains += "<a href=\"" + objTerrain["TerrainType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTerrain["TerrainType"].InnerText + ".png\" /></a>";
						}
						if (strTerrains != "")
						{
							string strMyTerrains = strTerrains;
							strTerrains = "<h2>" + TXT_KEY_PEDIA_TERRAINS_LABEL + "</h2>";
							strTerrains += "<div class=\"t\">";
							strTerrains += "<div class=\"b\">";
							strTerrains += "<div class=\"l\">";
							strTerrains += "<div class=\"r\">";
							strTerrains += "<div class=\"bl\">";
							strTerrains += "<div class=\"br\">";
							strTerrains += "<div class=\"tl\">";
							strTerrains += "<div class=\"tr\">";
							strTerrains += strMyTerrains;
							strTerrains += "</div></div></div></div></div></div></div></div>";
						}

						// Determine Revealing Tech.
						string strRevealed = "";
						if (objTechnology["TechReveal"] != null)
						{
							strRevealed += "\n<h2>" + TXT_KEY_PEDIA_REVEAL_TECH_LABEL + "</h2>";
							strRevealed += "<div class=\"t\">";
							strRevealed += "<div class=\"b\">";
							strRevealed += "<div class=\"l\">";
							strRevealed += "<div class=\"r\">";
							strRevealed += "<div class=\"bl\">";
							strRevealed += "<div class=\"br\">";
							strRevealed += "<div class=\"tl\">";
							strRevealed += "<div class=\"tr\">";
							string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objTechnology["TechReveal"].InnerText);
							strRevealed += "<a href=\"" + objTechnology["TechReveal"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTechnology["TechReveal"].InnerText + ".png\" /></a>";
							strRevealed += "</div></div></div></div></div></div></div></div>";
						}

						// Determine Improved By.
						string strImproved = "";
						List<string> lstSeenImprovements = new List<string>();
						foreach (string strImprovementFile in _lstImprovements)
						{
							XmlDocument objImprovementDoc = new XmlDocument();
							objImprovementDoc.Load(strImprovementFile);

							foreach (XmlNode objImprovement in objImprovementDoc.SelectNodes("/GameData/Improvement_ResourceTypes/Row[ResourceType = \"" + objTechnology["Type"].InnerText + "\"]"))
							{
								bool blnAddItem = true;
								foreach (string strImprovedBy in lstSeenImprovements)
								{
									if (strImprovedBy == objImprovement["ImprovementType"].InnerText)
									{
										blnAddItem = false;
										break;
									}
								}
								if (blnAddItem)
								{
									lstSeenImprovements.Add(objImprovement["ImprovementType"].InnerText);
									string strMyTitle = FindDescription(_lstImprovements, "Improvements", objImprovement["ImprovementType"].InnerText);
									strImproved += "<a href=\"" + objImprovement["ImprovementType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objImprovement["ImprovementType"].InnerText + ".png\" /></a>";
								}
							}
						}
						if (strImproved != "")
						{
							string strMyImproved = strImproved;
							strImproved = "<h2>" + TXT_KEY_PEDIA_IMPROVEMENTS_LABEL + "</h2>";
							strImproved += "<div class=\"t\">";
							strImproved += "<div class=\"b\">";
							strImproved += "<div class=\"l\">";
							strImproved += "<div class=\"r\">";
							strImproved += "<div class=\"bl\">";
							strImproved += "<div class=\"br\">";
							strImproved += "<div class=\"tl\">";
							strImproved += "<div class=\"tr\">";
							strImproved += strMyImproved;
							strImproved += "</div></div></div></div></div></div></div></div>";
						}

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##INFO##", strInfo);
						strOutput = strOutput.Replace("##HELP##", strHelp);
						strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
						strOutput = strOutput.Replace("##YIELDS##", strYields);
						strOutput = strOutput.Replace("##TERRAINS##", strTerrains);
						strOutput = strOutput.Replace("##REVEALED##", strRevealed);
						strOutput = strOutput.Replace("##IMPROVED##", strImproved);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// Determine which Group the Resource belongs to based on its Type since this doesn't seem to be defined anywhere in the XML files.
						string strGroupKey = "";
						switch (objTechnology["Type"].InnerText)
						{
							case "RESOURCE_BANANA":
							case "RESOURCE_BISON":
							case "RESOURCE_COW":
							case "RESOURCE_DEER":
							case "RESOURCE_FISH":
							case "RESOURCE_SHEEP":
							case "RESOURCE_STONE":
							case "RESOURCE_WHEAT":
							case "RESOURCE_ARTIFACTS":
							case "RESOURCE_HIDDEN_ARTIFACTS":
								strGroupKey = "BONUS_RESOURCES";
								break;
							case "RESOURCE_ALUMINUM":
							case "RESOURCE_COAL":
							case "RESOURCE_HORSE":
							case "RESOURCE_IRON":
							case "RESOURCE_OIL":
							case "RESOURCE_URANIUM":
								strGroupKey = "STRATEGIC_RESOURCES";
								break;
							default:
								strGroupKey = "LUXURY_RESOURCES";
								break;
						}

						// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
						Group objGroup = new Group();
						foreach (Group objCurrentGroup in lstGroups)
						{
							if (objCurrentGroup.Key == strGroupKey)
							{
								objGroup = objCurrentGroup;
								break;
							}
						}
						objGroup.GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RESOURCES_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"RESOURCE_HOME.aspx\"><div id=\"TERRAIN_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Resources.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Improvement pages.
		/// </summary>
		private void GenerateImprovements()
		{
			txtDebug.Text += "\r\nGenerating Improvements...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_IMPROVEMENTS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_QUOTE_BLOCK_IMPROVEMENTS");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_IMPROVEMENT_HELP_TEXT");
			const string strHomeImage = "IMPROVEMENT_FARM";
			string strHomeOutput = strHomeTeplate;
			const string strMaster = "Improvements";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "IMPROVEMENT_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_IMPROVEMENTS.aspx"));
			XmlDocument objDocument = MergeXml(_lstImprovements);

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Improvements/Row"))
			{
				//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
				//txtDebug.SelectionStart = txtDebug.TextLength;
				//txtDebug.ScrollToCaret();
				//Application.DoEvents();
				string strTitle = GetString(objTechnology["Description"].InnerText);
				string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
				string strHelp = GetString(objTechnology["Civilopedia"].InnerText);
				string strMyHelp = strHelp;
				strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
				strHelp += "<div class=\"t\">";
				strHelp += "<div class=\"b\">";
				strHelp += "<div class=\"l\">";
				strHelp += "<div class=\"r\">";
				strHelp += "<div class=\"bl\">";
				strHelp += "<div class=\"br\">";
				strHelp += "<div class=\"tl\">";
				strHelp += "<div class=\"tr\">";
				strHelp += strMyHelp;
				strHelp += "</div></div></div></div></div></div></div></div>";

				string strResources = "";
				// Determine Resources.
				foreach (string strImprovementFile in _lstImprovements)
				{
					XmlDocument objImprovementDocument = new XmlDocument();
					objImprovementDocument.Load(strImprovementFile);
					foreach (XmlNode objResource in objImprovementDocument.SelectNodes("/GameData/Improvement_ResourceTypes/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\"]"))
					{
						if (strResources == "")
						{
							strResources += "<h2>" + TXT_KEY_PEDIA_IMPROVES_RESRC_LABEL + "</h2>";
							strResources += "<div class=\"t\">";
							strResources += "<div class=\"b\">";
							strResources += "<div class=\"l\">";
							strResources += "<div class=\"r\">";
							strResources += "<div class=\"bl\">";
							strResources += "<div class=\"br\">";
							strResources += "<div class=\"tl\">";
							strResources += "<div class=\"tr\">";
						}
						string strMyTitle = FindDescription(_lstResources, "Resources", objResource["ResourceType"].InnerText);
						strResources += "<a href=\"" + objResource["ResourceType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objResource["ResourceType"].InnerText + ".png\" /></a>";
					}
				}
				if (strResources != "")
					strResources += "</div></div></div></div></div></div></div></div>";

				// Determine Prereq Tech.
				string strPrereq = "";
				foreach (string strBuildsFile in _lstBuilds)
				{
					XmlDocument objBuildsDoc = new XmlDocument();
					objBuildsDoc.Load(strBuildsFile);
					XmlNode objBuild = objBuildsDoc.SelectSingleNode("/GameData/Builds/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objBuild != null)
					{
						if (objBuild["PrereqTech"] != null)
						{
							strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
							strPrereq += "<div class=\"t\">";
							strPrereq += "<div class=\"b\">";
							strPrereq += "<div class=\"l\">";
							strPrereq += "<div class=\"r\">";
							strPrereq += "<div class=\"bl\">";
							strPrereq += "<div class=\"br\">";
							strPrereq += "<div class=\"tl\">";
							strPrereq += "<div class=\"tr\">";
							string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objBuild["PrereqTech"].InnerText);
							strPrereq += "<a href=\"" + objBuild["PrereqTech"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objBuild["PrereqTech"].InnerText + ".png\" /></a>";
							strPrereq += "</div></div></div></div></div></div></div></div>";
						}
					}
				}

				// Determine Yields.
				string strYields = "";
				// Faith.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FAITH\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/peace.png\" alt=\"faith\" /> ";
				}
				// Science.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_SCIENCE\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/research.png\" alt=\"research\" /> ";
				}
				// Food.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_FOOD\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
				}
				// Production.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_PRODUCTION\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/production.png\" alt=\"production\" /> ";
				}
				// Gold.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_GOLD\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/gold.png\" alt=\"gold\" /> ";
				}
				// Culture.
				foreach (XmlNode objModifier in objDocument.SelectNodes("/GameData/Improvement_Yields/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\" and YieldType = \"YIELD_CULTURE\"]"))
				{
					strYields += "+" + objModifier["Yield"].InnerText + " <img src=\"/civilopedia/images/culture.png\" alt=\"culture\" /> ";
				}

				if (strYields != "")
				{
					string strMyYield = strYields;
					strYields = "<h2>" + TXT_KEY_PEDIA_YIELD_LABEL + "</h2>";
					strYields += "<div class=\"t\">";
					strYields += "<div class=\"b\">";
					strYields += "<div class=\"l\">";
					strYields += "<div class=\"r\">";
					strYields += "<div class=\"bl\">";
					strYields += "<div class=\"br\">";
					strYields += "<div class=\"tl\">";
					strYields += "<div class=\"tr\">";
					strYields += strMyYield;
					strYields += "</div></div></div></div></div></div></div></div>";
				}

				// Look for Civilization.
				string strCivilization = "";
				if (objTechnology["CivilizationType"] != null)
				{
					strCivilization += "<h2>" + TXT_KEY_PEDIA_CIVILIZATIONS_LABEL + "</h2>";
					strCivilization += "<div class=\"t\">";
					strCivilization += "<div class=\"b\">";
					strCivilization += "<div class=\"l\">";
					strCivilization += "<div class=\"r\">";
					strCivilization += "<div class=\"bl\">";
					strCivilization += "<div class=\"br\">";
					strCivilization += "<div class=\"tl\">";
					strCivilization += "<div class=\"tr\">";
					string strMyTitle = FindDescription(_lstCivilizations, "Civilizations", objTechnology["CivilizationType"].InnerText);
					strCivilization += "<a href=\"" + objTechnology["CivilizationType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTechnology["CivilizationType"].InnerText + ".png\" /></a>";
					strCivilization += "</div></div></div></div></div></div></div></div>";
				}

				// Look for Features.
				string strBuildOn = "";
				foreach (XmlNode objTerrain in objDocument.SelectNodes("/GameData/Improvement_ValidFeatures/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\"]"))
				{
					if (strBuildOn == "")
					{
						strBuildOn += "<h2>" + TXT_KEY_PEDIA_FOUNDON_LABEL + "</h2>";
						strBuildOn += "<div class=\"t\">";
						strBuildOn += "<div class=\"b\">";
						strBuildOn += "<div class=\"l\">";
						strBuildOn += "<div class=\"r\">";
						strBuildOn += "<div class=\"bl\">";
						strBuildOn += "<div class=\"br\">";
						strBuildOn += "<div class=\"tl\">";
						strBuildOn += "<div class=\"tr\">";
					}
					string strMyTitle = FindDescription(_lstFeatures, "Features", objTerrain["FeatureType"].InnerText);
					strBuildOn += "<a href=\"" + objTerrain["FeatureType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTerrain["FeatureType"].InnerText + ".png\" /></a>";
				}
				// Look for Terrains.
				foreach (XmlNode objTerrain in objDocument.SelectNodes("/GameData/Improvement_ValidTerrains/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\"]"))
				{
					if (strBuildOn == "")
					{
						strBuildOn += "<h2>" + TXT_KEY_PEDIA_FOUNDON_LABEL + "</h2>";
						strBuildOn += "<div class=\"t\">";
						strBuildOn += "<div class=\"b\">";
						strBuildOn += "<div class=\"l\">";
						strBuildOn += "<div class=\"r\">";
						strBuildOn += "<div class=\"bl\">";
						strBuildOn += "<div class=\"br\">";
						strBuildOn += "<div class=\"tl\">";
						strBuildOn += "<div class=\"tr\">";
					}
					string strMyTitle = FindDescription(_lstTerrains, "Terrains", objTerrain["TerrainType"].InnerText);
					strBuildOn += "<a href=\"" + objTerrain["TerrainType"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objTerrain["TerrainType"].InnerText + ".png\" /></a>";
				}
				if (strBuildOn != "")
					strBuildOn += "</div></div></div></div></div></div></div></div>";

				// Look for Misc.
				string strMisc = "";
				XmlNode objMisc = objDocument.SelectSingleNode("/GameData/Improvement_AdjacentMountainYieldChanges/Row[ImprovementType = \"" + objTechnology["Type"].InnerText + "\"]");
				if (objMisc != null)
				{
					strMisc += "<h2>" + TXT_KEY_PEDIA_MOUNTAINADJYIELD_LABEL + "</h2>";
					strMisc += "<div class=\"t\">";
					strMisc += "<div class=\"b\">";
					strMisc += "<div class=\"l\">";
					strMisc += "<div class=\"r\">";
					strMisc += "<div class=\"bl\">";
					strMisc += "<div class=\"br\">";
					strMisc += "<div class=\"tl\">";
					strMisc += "<div class=\"tr\">";
					strMisc += "+" + objMisc["Yield"].InnerText + " <img src=\"/civilopedia/images/food.png\" alt=\"food\" /> ";
					strMisc += "</div></div></div></div></div></div></div></div>";
				}

				string strOutput = strTeplate;
				strOutput = strOutput.Replace("##TITLE##", strTitle);
				strOutput = strOutput.Replace("##HELP##", strHelp);
				strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
				strOutput = strOutput.Replace("##IMPROVES##", strResources);
				strOutput = strOutput.Replace("##PREREQ##", strPrereq);
				strOutput = strOutput.Replace("##YIELDS##", strYields);
				strOutput = strOutput.Replace("##CIVILIZATION##", strCivilization);
				strOutput = strOutput.Replace("##BUILDON##", strBuildOn);
				strOutput = strOutput.Replace("##MISC##", strMisc);

				// Create a GroupItem for this Tech.
				GroupItem objItem = new GroupItem();
				objItem.Key = objTechnology["Type"].InnerText;
				objItem.Name = strTitle;

				// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
				bool blnFound = false;
				Group objGroup = new Group();
				foreach (Group objCurrentGroup in lstGroups)
				{
					if (objCurrentGroup.Key == "IMPROVEMENTS")
					{
						objGroup = objCurrentGroup;
						blnFound = true;
						break;
					}
				}
				if (!blnFound)
				{
					objGroup.Key = "IMPROVEMENTS";
					objGroup.Name = GetString("TXT_KEY_PEDIA_CATEGORY_14_LABEL");
					lstGroups.Add(objGroup);
				}
				objGroup.GroupItems.Add(objItem);

				_strXml += "\t\t<page>";
				_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
				_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
				_strXml += "\t\t</page>";

				// Create the Image.
				if (_strLanguage == "en_US")
				{
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
				}

				File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
			}

			// Routes.
			objDocument = MergeXml(_lstRoutes);

			foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Routes/Row"))
			{
				//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
				//txtDebug.SelectionStart = txtDebug.TextLength;
				//txtDebug.ScrollToCaret();
				//Application.DoEvents();
				string strTitle = GetString(objTechnology["Description"].InnerText);
				string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
				string strHelp = GetString(objTechnology["Civilopedia"].InnerText);
				string strMyHelp = strHelp;
				strHelp = "<h2>" + TXT_KEY_PEDIA_GAME_INFO_LABEL + "</h2>";
				strHelp += "<div class=\"t\">";
				strHelp += "<div class=\"b\">";
				strHelp += "<div class=\"l\">";
				strHelp += "<div class=\"r\">";
				strHelp += "<div class=\"bl\">";
				strHelp += "<div class=\"br\">";
				strHelp += "<div class=\"tl\">";
				strHelp += "<div class=\"tr\">";
				strHelp += strMyHelp;
				strHelp += "</div></div></div></div></div></div></div></div>";

				// Determine Prereq Tech.
				string strPrereq = "";
				foreach (string strBuildsFile in _lstBuilds)
				{
					XmlDocument objBuildsDoc = new XmlDocument();
					objBuildsDoc.Load(strBuildsFile);
					XmlNode objBuild = objBuildsDoc.SelectSingleNode("/GameData/Builds/Row[RouteType = \"" + objTechnology["Type"].InnerText + "\"]");
					if (objBuild != null)
					{
						strPrereq += "<h2>" + TXT_KEY_PEDIA_PREREQ_TECH_LABEL + "</h2>";
						strPrereq += "<div class=\"t\">";
						strPrereq += "<div class=\"b\">";
						strPrereq += "<div class=\"l\">";
						strPrereq += "<div class=\"r\">";
						strPrereq += "<div class=\"bl\">";
						strPrereq += "<div class=\"br\">";
						strPrereq += "<div class=\"tl\">";
						strPrereq += "<div class=\"tr\">";
						string strMyTitle = FindDescription(_lstTechnologies, "Technologies", objBuild["PrereqTech"].InnerText);
						strPrereq += "<a href=\"" + objBuild["PrereqTech"].InnerText + ".aspx\" onmouseover=\"return tooltip('" + strMyTitle + "');\" onmouseout=\"return hideTip();\"><img src=\"/civilopedia/images/small/" + objBuild["PrereqTech"].InnerText + ".png\" /></a>";
						strPrereq += "</div></div></div></div></div></div></div></div>";
					}
				}

				string strOutput = strTeplate;
				strOutput = strOutput.Replace("##TITLE##", strTitle);
				strOutput = strOutput.Replace("##HELP##", strHelp);
				strOutput = strOutput.Replace("##TYPE##", objTechnology["Type"].InnerText);
				strOutput = strOutput.Replace("##PREREQ##", strPrereq);
				strOutput = strOutput.Replace("##YIELDS##", string.Empty);
				strOutput = strOutput.Replace("##MISC##", string.Empty);
				strOutput = strOutput.Replace("##CIVILIZATION##", string.Empty);
				strOutput = strOutput.Replace("##IMPROVES##", string.Empty);
				strOutput = strOutput.Replace("##BUILDON##", string.Empty);

				// Create a GroupItem for this Tech.
				GroupItem objItem = new GroupItem();
				objItem.Key = objTechnology["Type"].InnerText;
				objItem.Name = strTitle;

				// If the Era already exists in the Group List, add this item to it, otherwise, create the new Group.
				bool blnFound = false;
				Group objGroup = new Group();
				foreach (Group objCurrentGroup in lstGroups)
				{
					if (objCurrentGroup.Key == "IMPROVEMENTS")
					{
						objGroup = objCurrentGroup;
						blnFound = true;
						break;
					}
				}
				if (!blnFound)
				{
					objGroup.Key = "IMPROVEMENTS";
					objGroup.Name = GetString("TXT_KEY_PEDIA_CATEGORY_14_LABEL");
					lstGroups.Add(objGroup);
				}
				objGroup.GroupItems.Add(objItem);

				_strXml += "\t\t<page>";
				_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
				_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
				_strXml += "\t\t</page>";

				// Create the Image.
				if (_strLanguage == "en_US")
				{
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
					CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
				}

				File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_IMPROVEMENTS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"IMPROVEMENT_HOME.aspx\"><div id=\"IMPROVEMENT_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				objGroup.Sort();
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\" onmouseover=\"return tooltip('<img src=\\'/civilopedia/images/small/" + objItem.Key + ".png\\' />', true);\" onmouseout=\"return hideTip();\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Improvements.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Religion pages.
		/// </summary>
		private void GenerateReligions()
		{
			txtDebug.Text += "\r\nGenerating Religions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objReligions = new Group();
			objReligions.Key = "RELIGION";
			objReligions.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_1");
			lstGroups.Add(objReligions);

			Group objPantheon = new Group();
			objPantheon.Key = "PANTHEON";
			objPantheon.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_2");
			lstGroups.Add(objPantheon);

			Group objFounder = new Group();
			objFounder.Key = "FOUNDER";
			objFounder.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_3");
			lstGroups.Add(objFounder);

			Group objFollower = new Group();
			objFollower.Key = "FOLLOWER";
			objFollower.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_4");
			lstGroups.Add(objFollower);

			Group objEnhancer = new Group();
			objEnhancer.Key = "ENHANCER";
			objEnhancer.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_5");
			lstGroups.Add(objEnhancer);

			Group objReformation = new Group();
			objReformation.Key = "REFORMATION";
			objReformation.Name = GetString("TXT_KEY_PEDIA_BELIEFS_CATEGORY_6");
			lstGroups.Add(objReformation);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_BELIEFS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_BELIEFS_HOMEPAGE_BLURB");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_BELIEFS_HOMEPAGE_TEXT1");
			string strHomeOutput = strHomeTeplate;
			const string strHomeImage = "RELIGION_HOME";
			const string strMaster = "Religions";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "RELIGION_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Religion Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RELIGIONS.aspx"));
			foreach (string strXmlFile in _lstReligions)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Religions/Row"))
				{
					// Do not generate anything for the phony Pantheon Religion.
					if (objTechnology["Type"].InnerText != "RELIGION_PANTHEON")
					{
						//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
						//txtDebug.SelectionStart = txtDebug.TextLength;
						//txtDebug.ScrollToCaret();
						//Application.DoEvents();
						string strTitle = GetString(objTechnology["Description"].InnerText);
						string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
						string strDesc = GetString(objTechnology["Civilopedia"].InnerText);

						string strMyDesc = strDesc;
						strDesc = "<h2>" + TXT_KEY_PEDIA_SUMMARY_LABEL + "</h2>";
						strDesc += "<div class=\"t\">";
						strDesc += "<div class=\"b\">";
						strDesc += "<div class=\"l\">";
						strDesc += "<div class=\"r\">";
						strDesc += "<div class=\"bl\">";
						strDesc += "<div class=\"br\">";
						strDesc += "<div class=\"tl\">";
						strDesc += "<div class=\"tr\">";
						strDesc += strMyDesc;
						strDesc += "</div></div></div></div></div></div></div></div>";

						string strOutput = strTeplate;
						strOutput = strOutput.Replace("##TITLE##", strTitle);
						strOutput = strOutput.Replace("##DESC##", strDesc);

						// Create a GroupItem for this Tech.
						GroupItem objItem = new GroupItem();
						objItem.Key = objTechnology["Type"].InnerText;
						objItem.Name = strTitle;

						// Add this item to the Religions group.
						lstGroups[0].GroupItems.Add(objItem);

						_strXml += "\t\t<page>";
						_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
						_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
						_strXml += "\t\t</page>";

						// Create the Image.
						if (_strLanguage == "en_US")
						{
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 256);
							CreateImage(objTechnology["Type"].InnerText, objTechnology["IconAtlas"].InnerText, objTechnology["PortraitIndex"].InnerText, 64);
						}

						File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
					}
				}
			}

			// Beliefs Pages.
			//string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RELIGIONS.aspx"));
			foreach (string strXmlFile in _lstBeliefs)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Beliefs/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["ShortDescription"].InnerText);
					string strXmlTitle = GetString(objTechnology["ShortDescription"].InnerText, false);
					string strDesc = GetString(objTechnology["Description"].InnerText);

					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_SUMMARY_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##DESC##", strDesc);

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// Determine which group to add this to.
					if (objTechnology["Pantheon"] != null)
						lstGroups[1].GroupItems.Add(objItem);
					if (objTechnology["Founder"] != null)
						lstGroups[2].GroupItems.Add(objItem);
					if (objTechnology["Follower"] != null)
						lstGroups[3].GroupItems.Add(objItem);
					if (objTechnology["Enhancer"] != null)
						lstGroups[4].GroupItems.Add(objItem);
					if (objTechnology["Reformation"] != null)
						lstGroups[5].GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RELIGIONS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"RELIGION_HOME.aspx\"><div id=\"RELIGION_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				objGroup.Sort();
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Religions.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Resolution pages.
		/// </summary>
		public void GenerateResolutions()
		{
			txtDebug.Text += "\r\nGenerating Resolutions...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();
			List<Group> lstGroups = new List<Group>();

			Group objResolutions = new Group();
			objResolutions.Key = "RESOLUTIONS";
			objResolutions.Name = GetString("TXT_KEY_PEDIA_WORLD_CONGRESS_CATEGORY_1");
			lstGroups.Add(objResolutions);

			Group objProjects = new Group();
			objProjects.Key = "PROJECTS";
			objProjects.Name = GetString("TXT_KEY_PEDIA_WORLD_CONGRESS_CATEGORY_2");
			lstGroups.Add(objProjects);

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_HOME.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_WORLD_CONGRESS_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_WORLD_CONGRESS_HOMEPAGE_BLURB");
			string strHomeDesc = GetString("TXT_KEY_PEDIA_WORLD_CONGRESS_HOMEPAGE_TEXT1");
			string strHomeOutput = strHomeTeplate;
			const string strHomeImage = "RESOLUTION_HOME";
			const string strMaster = "Resolutions";
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##DESC##", strHomeDesc);
			strHomeOutput = strHomeOutput.Replace("##IMAGE##", strHomeImage);
			strHomeOutput = strHomeOutput.Replace("##MASTER##", strMaster);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "RESOLUTION_HOME.aspx"), strHomeOutput, Encoding.UTF8);

			// Resolutions Pages.
			string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RESOLUTIONS.aspx"));
			foreach (string strXmlFile in _lstResolutions)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/Resolutions/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strDesc = GetString(objTechnology["Help"].InnerText);

					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_SUMMARY_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##COST##", string.Empty);
					strOutput = strOutput.Replace("##TYPE##", "RESOLUTION_HOME");

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					// Add this item to the Religions group.
					lstGroups[0].GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// International Projects Pages.
			//string strTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RESOLUTIONS.aspx"));
			foreach (string strXmlFile in _lstResolutions)
			{
				XmlDocument objDocument = new XmlDocument();
				objDocument.Load(strXmlFile);

				foreach (XmlNode objTechnology in objDocument.SelectNodes("/GameData/LeagueProjects/Row"))
				{
					//txtDebug.Text += "\r\nGenerating " + objTechnology["Description"].InnerText;
					//txtDebug.SelectionStart = txtDebug.TextLength;
					//txtDebug.ScrollToCaret();
					//Application.DoEvents();
					string strTitle = GetString(objTechnology["Description"].InnerText);
					string strXmlTitle = GetString(objTechnology["Description"].InnerText, false);
					string strDesc = GetString(objTechnology["Help"].InnerText);

					string strMyDesc = strDesc;
					strDesc = "<h2>" + TXT_KEY_PEDIA_SUMMARY_LABEL + "</h2>";
					strDesc += "<div class=\"t\">";
					strDesc += "<div class=\"b\">";
					strDesc += "<div class=\"l\">";
					strDesc += "<div class=\"r\">";
					strDesc += "<div class=\"bl\">";
					strDesc += "<div class=\"br\">";
					strDesc += "<div class=\"tl\">";
					strDesc += "<div class=\"tr\">";
					strDesc += strMyDesc;
					strDesc += "</div></div></div></div></div></div></div></div>";

					string strOutput = strTeplate;
					strOutput = strOutput.Replace("##TITLE##", strTitle);
					strOutput = strOutput.Replace("##DESC##", strDesc);
					strOutput = strOutput.Replace("##COST##", string.Empty);
					strOutput = strOutput.Replace("##TYPE##", "LEAGUEPROJECTS_HOME");

					// Create a GroupItem for this Tech.
					GroupItem objItem = new GroupItem();
					objItem.Key = objTechnology["Type"].InnerText;
					objItem.Name = strTitle;

					lstGroups[1].GroupItems.Add(objItem);

					_strXml += "\t\t<page>";
					_strXml += "\t\t\t<name>" + strXmlTitle.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") + "</name>";
					_strXml += "\t\t\t<url>" + objTechnology["Type"].InnerText + "</url>";
					_strXml += "\t\t</page>";

					File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, objTechnology["Type"].InnerText + ".aspx"), strOutput, Encoding.UTF8);
				}
			}

			// Write the Era information to the menu.
			string strMenu = "";
			string strMasterTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_RESOLUTIONS_MASTER.master"));
			strMenu += "\n\t\t\t\t<a href=\"RESOLUTION_HOME.aspx\"><div id=\"RESOLUTION_HOME\" class=\"menuitem\">" + strHomeTitle + "</div></a>";
			foreach (Group objGroup in lstGroups)
			{
				objGroup.Sort();
				strMenu += "\n\t\t\t<div id=\"GROUP_" + objGroup.Key + "\" class=\"menugroupcontainer\"><a href=\"javascript:togglediv('" + objGroup.Key + "_CONTENT');\"><div id=\"" + objGroup.Key + "\" class=\"menugroup\">" + objGroup.Name + "</div></a><div id=\"" + objGroup.Key + "_CONTENT\">";
				foreach (GroupItem objItem in objGroup.GroupItems)
				{
					strMenu += "\n\t\t\t\t<a href=\"" + objItem.Key + ".aspx\"><div id=\"" + objItem.Key + "\" class=\"menuitem\">" + objItem.Name + "</div></a>";
				}
				strMenu += "\n\t\t\t</div></div>";
			}

			string strMasterOutput = strMasterTeplate;
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);
			strMasterOutput = strMasterOutput.Replace("##MENU##", strMenu);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Resolutions.master"), strMasterOutput, Encoding.UTF8);
		}

		/// <summary>
		/// Generate Home page.
		/// </summary>
		private void GenerateHome()
		{
			txtDebug.Text += "\r\nGenerating Home...";
			txtDebug.SelectionStart = txtDebug.TextLength;
			txtDebug.ScrollToCaret();
			Application.DoEvents();

			// Home Page.
			string strHomeTeplate = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_DEFAULT.aspx"));
			string strHomeTitle = GetString("TXT_KEY_PEDIA_HOME_PAGE_LABEL");
			string strHomeQuote = GetString("TXT_KEY_PEDIA_HOME_PAGE_BLURB_TEXT");
			string strHomeTitle2 = GetString("TXT_KEY_PEDIA_HOME_PAGE_HELP_LABEL");
			string strHomeOutput = strHomeTeplate;
			string strChanges = File.ReadAllText(Path.Combine(Application.StartupPath, "civchanges.txt"));
			strHomeOutput = strHomeOutput.Replace("##TITLE##", strHomeTitle);
			strHomeOutput = strHomeOutput.Replace("##QUOTE##", strHomeQuote);
			strHomeOutput = strHomeOutput.Replace("##TITLE2##", strHomeTitle2);
			strHomeOutput = strHomeOutput.Replace("##CHANGES##", strChanges);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "default.aspx"), strHomeOutput, Encoding.UTF8);

			string strMasterOutput = File.ReadAllText(Path.Combine(Application.StartupPath, "html", "TEMPLATE_DEFAULT_MASTER.master"));
			strMasterOutput = strMasterOutput.Replace("##TITLE##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##LANGUAGE##", _strLanguage.ToLower().Replace("_", "-"));
			strMasterOutput = strMasterOutput.Replace("##CATEGORY1##", TXT_KEY_PEDIA_CATEGORY_1_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY2##", TXT_KEY_PEDIA_CATEGORY_2_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY3##", TXT_KEY_PEDIA_CATEGORY_3_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY4##", TXT_KEY_PEDIA_CATEGORY_4_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY5##", TXT_KEY_PEDIA_CATEGORY_5_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY6##", TXT_KEY_PEDIA_CATEGORY_6_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY7##", TXT_KEY_PEDIA_CATEGORY_7_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY8##", TXT_KEY_PEDIA_CATEGORY_8_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY9##", TXT_KEY_PEDIA_CATEGORY_9_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY10##", TXT_KEY_PEDIA_CATEGORY_10_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY11##", TXT_KEY_PEDIA_CATEGORY_11_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY12##", TXT_KEY_PEDIA_CATEGORY_12_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY13##", TXT_KEY_PEDIA_CATEGORY_13_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY14##", TXT_KEY_PEDIA_CATEGORY_14_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY15##", TXT_KEY_PEDIA_CATEGORY_15_LABEL);
			strMasterOutput = strMasterOutput.Replace("##CATEGORY16##", TXT_KEY_PEDIA_CATEGORY_16_LABEL);

			File.WriteAllText(Path.Combine(Application.StartupPath, _strHtmlPath, "Home.master"), strMasterOutput, Encoding.UTF8);
		}
		#endregion
	}
}