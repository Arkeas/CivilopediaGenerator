using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string strPath = Request.QueryString["url"];
		string strSearch = Request.QueryString["search"];
		Response.Clear();
		Response.ContentType = "text/xml";

		if (strSearch.Trim() == string.Empty)
			Response.End();

		strSearch = strSearch.TrimEnd().TrimStart();
		if (strSearch.Length < 4)
			Response.End();

		XmlDocument objDocument = new XmlDocument();
		objDocument.Load(Server.MapPath("/civilopedia" + strPath + "/pages.xml"));

		XmlNodeList objList = objDocument.SelectNodes("/pages/page[contains(translate(name,\"abcdefghijklmnopqrstuvwxyzàáâãäåçèéêëìíîïñòóôõöùúûüýß\",\"ABCDEFGHIJKLMNOPQRSTUVWXYZÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÑÒÓÔÕÖÙÚÛÜÝß\"), \"" + strSearch.ToUpper() + "\")]");

		Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
		Response.Write("\n<pages>");
		foreach (XmlNode objNode in objList)
		{
			Response.Write("\n\t<page>");
			Response.Write("\n\t\t<name>" + objNode["name"].InnerText + "</name>");
			Response.Write("\n\t\t<url>" + objNode["url"].InnerText + "</url>");
			Response.Write("\n\t</page>");
		}
		Response.Write("\n</pages>");
    }
}