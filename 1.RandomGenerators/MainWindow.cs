using Randoms_analyze;
using System;
using Gtk;
using Gdk;

public partial class MainWindow: Gtk.Window
{
	public int[] realData = new int[10];
	public double[] numbers = new double[1];
	double scale = 0;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		entry3.Text = "100";
		entry4.Text = "10";
		entry1.Text = "98";
		entry2.Text = "76";
		setColor();
	}

	public void setColor()
	{
		Gdk.Color col = new Gdk.Color();
		Gdk.Color.Parse("pink", ref col);
		drawingarea1.ModifyBg(StateType.Normal, col);
	}

	public void OnExposed (object o, ExposeEventArgs args)
	{
		double bp = scale;

		label7.Text = Convert.ToString(bp);
		label13.Text = Convert.ToString(bp-(bp/5));
		label14.Text = Convert.ToString(bp-(bp/5)*2);
		label15.Text = Convert.ToString(bp-(bp/5)*3);
		label16.Text = Convert.ToString(bp-(bp/5)*4);

		for (int x = 40; x < 170; x+=40) drawingarea1.GdkWindow.DrawLine (drawingarea1.Style.BaseGC(StateType.Normal), 0, x, 200, x);
					
		int xx = 3;
		for (int y = 0; y < 10; y++) {
			drawingarea1.GdkWindow.DrawRectangle (drawingarea1.Style.BaseGC(StateType.Normal), true, xx, 200 - realData[y]+2, 16, 200);
			xx += 19;
		}
	}
		
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void methodSquareCenter (object sender, EventArgs e)
	{		
		numbers = Generate.squareMethod(Convert.ToInt32(entry3.Text));
		Array.Resize(ref numbers, numbers.Length);
		textview3.Buffer.Text = "";
		if (numbers.Length < 2000) foreach (double item in numbers) textview3.Buffer.Text = textview3.Buffer.Text + Convert.ToString(item) + "  ";
        incommonMethod ();
	}

	protected void multipleMethod (object sender, EventArgs e)
	{
		numbers = Generate.multiplyMethod(Convert.ToInt32(entry1.Text), Convert.ToInt32(entry2.Text));		
		Array.Resize(ref numbers, numbers.Length);
		string text = "";
		if (numbers.Length < 2000) foreach (double item in numbers) text += Convert.ToString(item) + "  ";      
		textview5.Buffer.Text = text;
        incommonMethod (); 
	}

	private void incommonMethod ()
	{
        double MathW, Disp;
        Test.MathAndDisp(numbers, out MathW, out Disp);
        label9.Text = "M(z) = " + MathW;
        label10.Text = "D(z) = " + Disp;
		
		Test.Frequency (numbers, out realData, out scale);
		label18.Text = Test.Independency(numbers, Convert.ToInt32(entry4.Text));

		setColor();
		drawingarea1.ExposeEvent += OnExposed;
	}

}