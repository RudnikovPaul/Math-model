using Randoms_analyze;
using System;
using Gtk;
using Gdk;

public partial class MainWindow: Gtk.Window
{
	public int[] realData = new int[10];
	public double[] numbers = new double[1];
	double scale = 0, mathW = 0, disp = 0;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		entry1.Text = "5";
		entry2.Text = "15";
		entry3.Text = "1000";
		setColor();
	}

	protected void generateButtonClicked (object sender, EventArgs e)
	{
		numbers = Generate.equalGenerator(Convert.ToInt32(entry3.Text), Convert.ToDouble(entry1.Text), Convert.ToDouble(entry2.Text));
		Array.Resize(ref numbers, numbers.Length);
		Test.Frequency (Convert.ToDouble(entry1.Text), Convert.ToDouble(entry2.Text), numbers, out realData, out scale);
		Test.MathAndDisp (numbers, out mathW, out disp);
		label12.Text = Convert.ToString(mathW);
		label18.Text = Convert.ToString(disp);
		setColor();
		drawingarea1.ExposeEvent += OnExposed; 
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

		double St = Convert.ToDouble(entry1.Text);
		double En = Convert.ToDouble(entry2.Text);
		label23.Text = (St).ToString("00.0");
		label29.Text = (En - (En - St)/10 * 9).ToString("00.0");
		label24.Text = (En - (En - St)/10 * 8).ToString("00.0");
		label30.Text = (En - (En - St)/10 * 7).ToString("00.0");
		label25.Text = (En - (En - St)/10 * 6).ToString("00.0");
		label31.Text = (En - (En - St)/10 * 5).ToString("00.0");
		label26.Text = (En - (En - St)/10 * 4).ToString("00.0");
		label32.Text = (En - (En - St)/10 * 3).ToString("00.0");
		label27.Text = (En - (En - St)/10 * 2).ToString("00.0");
		label33.Text = (En - (En - St)/10).ToString("00.0");
		label28.Text = (En).ToString("00.0");

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
}