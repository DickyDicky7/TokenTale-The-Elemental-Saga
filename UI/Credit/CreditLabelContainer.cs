using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class CreditLabelContainer : VBoxContainer
{
	private CreditList CreditList { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.CreditList = CreditList.GetInstance();
		SetupEmpty(5);
		SetupText("Token Tale: The Elemental Saga", 64);
		SetupEmpty(3);
		SetupList(CreditList.DirectorList, "Creative Directors");
		SetupList(CreditList.DesignerList, "Designers");
		SetupList(CreditList.ArtistList, "Artists");
		SetupList(CreditList.ProgrammerList, "Programmers");
		SetupList(CreditList.QAList, "QA Team");
		SetupList(CreditList.AudioList, "Audio Team");
		SetupList(CreditList.SpecialThanksList, "Special Thanks To: ");
		SetupEmpty(2);
		SetupText("Thank you for playing !", 32);
		SetupEmpty(10);
	}
	private Label SetupLabel(
		string text,
		HorizontalAlignment horizontalAlignment,
		int fontSize)
	{
		Label temp = new();
		temp.HorizontalAlignment = horizontalAlignment;
		temp.VerticalAlignment = VerticalAlignment.Center;
		temp.Text = text;
		temp.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		temp.Set("theme_override_font_sizes/font_size", fontSize);
		return temp;
	}
	private void SetupEmpty(int time)
	{
		foreach (int i in Enumerable.Range(0, time))
		{
			this.AddChild(SetupLabel("", HorizontalAlignment.Center, 48));
		}
	}
	private void SetupList(
		List<CreditList.CreditLine> list,
		string title)
	{
		this.AddChild(SetupLabel(title, HorizontalAlignment.Center, 48));
		foreach (CreditList.CreditLine creditLine in list)
		{
			HBoxContainer hBoxContainer = new();
			hBoxContainer.AddChild(SetupLabel(creditLine.Role, HorizontalAlignment.Left, 32));
			hBoxContainer.AddChild(SetupLabel(creditLine.Name, HorizontalAlignment.Right, 32));
			this.AddChild(hBoxContainer);
		}
	}
	private void SetupText(string title, int size)
	{
		this.AddChild(SetupLabel(title, HorizontalAlignment.Center, size));
	}
}
