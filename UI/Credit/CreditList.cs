using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class CreditList : Node
{
	private static CreditList _instance;
	public static CreditList GetInstance()
	{
		if (_instance == null)
			_instance = new CreditList();
		return _instance;
	}
	private CreditList()
	{
		SetupDirectorList();
		SetupDesignerList();
		SetupArtistList();
		SetupProgrammerList();
		SetupQAList();
		SetupSpecialThanks();
	}
	public record CreditLine
	{
		public string Role { get; set; }
		public string Name { get; set; }
	}
	public List<CreditLine> DesignerList { get; private set; } = new();
	private void SetupDesignerList()
	{
		DesignerList.Add(new CreditLine
		{
			Role = "Lead Game Designer",
			Name = "Nguyen Thanh Thien An"
		});
		DesignerList.Add(new CreditLine
		{
			Role = "Game Designer",
			Name = "Nguyen Thanh Thien An"
		});
		DesignerList.Add(new CreditLine
		{
			Role = "Level Designer",
			Name = "Nguyen Thanh Thien An"
		});
		DesignerList.Add(new CreditLine
		{
			Role = "System Designer",
			Name = "Nguyen Thanh Thien An"
		});
		DesignerList.Add(new CreditLine
		{
			Role = "UI/UX Designer",
			Name = "Nguyen Thanh Thien An"
		});
	}
	public List<CreditLine> ArtistList { get; private set; } = new();
	private void SetupArtistList()
	{
		ArtistList.Add(new CreditLine
		{
			Role = "Lead Artist",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Concept Artist",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Environment Artist",
			Name = "Nguyen Thanh Thien An"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Technical Artist",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Lighting Artist",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "VFX Artist",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Animator",
			Name = "Pham Tuan Anh"
		});
		ArtistList.Add(new CreditLine
		{
			Role = "Rigging Artist",
			Name = "Pham Tuan Anh"
		});
	}
	public List<CreditLine> ProgrammerList { get; private set; } = new();
	private void SetupProgrammerList()
	{
		ProgrammerList.Add(new CreditLine
		{
			Role = "Lead Programmer",
			Name = "Pham Tuan Anh"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "Gameplay Programmer",
			Name = "Nguyen Thanh Thien An"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "AI Programmer",
			Name = "Nguyen Thanh Thien An"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "",
			Name = "Pham Tuan Anh"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "UI Programmer",
			Name = "Nguyen Thanh Thien An"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "Tool Programmer",
			Name = "Pham Tuan Anh"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "Physics Programmer",
			Name = "Nguyen Thanh Thien An"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "",
			Name = "Pham Tuan Anh"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "Graphics Programmer",
			Name = "Pham Tuan Anh"
		});
		ProgrammerList.Add(new CreditLine
		{
			Role = "",
			Name = "Nguyen Thanh Thien An"
		});
	}
	public List<CreditLine> DirectorList { get; private set; } = new();
	private void SetupDirectorList()
	{
		DirectorList.Add(new CreditLine
		{
			Role = "Game Director",
			Name = "Nguyen Thanh Thien An"
		});
		DirectorList.Add(new CreditLine
		{
			Role = "Art Director",
			Name = "Pham Tuan Anh"
		});
	}
	public List<CreditLine> QAList { get; private set; } = new();
	private void SetupQAList()
	{
		QAList.Add(new CreditLine
		{
			Role = "Tester",
			Name = "Nguyen Thanh Thien An"
		});
		QAList.Add(new CreditLine
		{
			Role = "",
			Name = "Pham Tuan Anh"
		});
	}
	public List<CreditLine> SpecialThanksList { get; private set; } = new();
	private void SetupSpecialThanks()
	{
		SpecialThanksList.Add(new CreditLine
		{
			Role = "Advisor",
			Name = "Huynh Ho Thi Mong Trinh"
		});
		SpecialThanksList.Add(new CreditLine
		{
			Role = "Supportive friends",
			Name = "Nguyen Thai Binh"
		});
		SpecialThanksList.Add(new CreditLine
		{
			Role = "",
			Name = "Nguyen Phuoc Hung"
		});
	}
}
