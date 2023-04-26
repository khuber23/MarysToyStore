﻿using System.Xml.Serialization;

namespace MarysToyStore.Models;

public class UspsAddress
{
	public string Address1 { get; set; }

	public string Address2 { get; set; }

	public string City { get; set; }

	[XmlElement("DPVConfirmation")]
	public string DpvConfirmation { get; set; }

	public string State { get; set; }

	public string Zip4 { get; set; }

	public string Zip5 { get; set; }
}