using System.ComponentModel;

namespace TestApp;

public partial class HourCalculator : ContentPage
{
    public HourCalculator()
    {
        InitializeComponent();
    }

    private void CalculateHours(object sender, EventArgs e)
    {
        // Monday 1
        TimeSpan mondayStart1 = TPmondayStart1.Time;
        TimeSpan mondayEnd1 = TPmondayEnd1.Time;
        int mondayLunch1 = Convert.ToInt32(txtMondayLunch1.Text);
        TimeSpan mondayTime1 = mondayEnd1 - mondayStart1;

        mondayTime1 = mondayTime1.Subtract(TimeSpan.FromMinutes(mondayLunch1));

        // Monday 2
        TimeSpan mondayStart2 = TPMondayStart2.Time;
        TimeSpan mondayEnd2 = TPMondayEnd2.Time;
        int mondayLunch2 = Convert.ToInt32(txtMondayLunch2.Text);
        TimeSpan mondayTime2 = mondayEnd2 - mondayStart2;

        mondayTime2 = mondayTime2.Subtract(TimeSpan.FromMinutes(mondayLunch2));

        // Tuesday 1
        TimeSpan tuesdayStart1 = TPTuesdayStart1.Time;
        TimeSpan tuesdayEnd1 = TPTuesdayEnd1.Time;
        int tuesdayLunch1 = Convert.ToInt32(txtTuesdayLunch1.Text);
        TimeSpan tuesdayTime1 = tuesdayEnd1 - tuesdayStart1;

        tuesdayTime1 = tuesdayTime1.Subtract(TimeSpan.FromMinutes(tuesdayLunch1));

        // Tuesday 2
        TimeSpan tuesdayStart2 = TPTuesdayStart2.Time;
        TimeSpan tuesdayEnd2 = TPTuesdayEnd2.Time;
        int tuesdayLunch2 = Convert.ToInt32(txtTuesdayLunch2.Text);
        TimeSpan tuesdayTime2 = tuesdayEnd2 - tuesdayStart2;

        tuesdayTime2 = tuesdayTime2.Subtract(TimeSpan.FromMinutes(tuesdayLunch2));

        // Wednesday 1
        TimeSpan wednesdayStart1 = TPWednesdayStart1.Time;
        TimeSpan wednesdayEnd1 = TPWednesdayEnd1.Time;
        int wednesdayLunch1 = Convert.ToInt32(txtWednesdayLunch1.Text);
        TimeSpan wednesdayTime1 = wednesdayEnd1 - wednesdayStart1;

        wednesdayTime1 = wednesdayTime1.Subtract(TimeSpan.FromMinutes(wednesdayLunch1));

        // Wednesday 2
        TimeSpan wednesdayStart2 = TPWednesdayStart2.Time;
        TimeSpan wednesdayEnd2 = TPWednesdayEnd2.Time;
        int wednesdayLunch2 = Convert.ToInt32(txtWednesdayLunch2.Text);
        TimeSpan wednesdayTime2 = wednesdayEnd2 - wednesdayStart2;

        wednesdayTime2 = wednesdayTime2.Subtract(TimeSpan.FromMinutes(wednesdayLunch2));

        // Thursday 1
        TimeSpan thursdayStart1 = TPThursdayStart1.Time;
        TimeSpan thursdayEnd1 = TPThursdayEnd1.Time;
        int thursdayLunch1 = Convert.ToInt32(txtThursdayLunch1.Text);
        TimeSpan thursdayTime1 = thursdayEnd1 - thursdayStart1;

        thursdayTime1 = thursdayTime1.Subtract(TimeSpan.FromMinutes(thursdayLunch1));

        // Thursday 2
        TimeSpan thursdayStart2 = TPThursdayStart2.Time;
        TimeSpan thursdayEnd2 = TPThursdayEnd2.Time;
        int thursdayLunch2 = Convert.ToInt32(txtThursdayLunch2.Text);
        TimeSpan thursdayTime2 = thursdayEnd2 - thursdayStart2;

        thursdayTime2 = thursdayTime2.Subtract(TimeSpan.FromMinutes(thursdayLunch2));

        // Friday 1
        TimeSpan fridayStart1 = TPFridayStart1.Time;
        TimeSpan fridayEnd1 = TPFridayEnd1.Time;
        int fridayLunch1 = Convert.ToInt32(txtFridayLunch1.Text);
        TimeSpan fridayTime1 = fridayEnd1 - fridayStart1;

        fridayTime1 = fridayTime1.Subtract(TimeSpan.FromMinutes(fridayLunch1));

        // Friday 2
        TimeSpan fridayStart2 = TPFridayStart2.Time;
        TimeSpan fridayEnd2 = TPFridayEnd2.Time;
        int fridayLunch2 = Convert.ToInt32(txtFridayLunch2.Text);
        TimeSpan fridayTime2 = fridayEnd2 - fridayStart2;

        fridayTime2 = fridayTime2.Subtract(TimeSpan.FromMinutes(fridayLunch2));


        // Total
        int mondayHours1 = mondayTime1.Hours;
        int mondayHours2 = mondayTime2.Hours;
        int tuesdayHours1 = tuesdayTime1.Hours;
        int tuesdayHours2 = tuesdayTime2.Hours;
        int wednesdayHours1 = wednesdayTime1.Hours;
        int wednesdayHours2 = wednesdayTime2.Hours;
        int thursdayHours1 = thursdayTime1.Hours;
        int thursdayHours2 = thursdayTime2.Hours;
        int fridayHours1 = fridayTime1.Hours;
        int fridayHours2 = fridayTime2.Hours;

        int mondayMinutes1 = mondayTime1.Minutes;
        int mondayMinutes2 = mondayTime2.Minutes;
        int tuesdayMinutes1 = tuesdayTime1.Minutes;
        int tuesdayMinutes2 = tuesdayTime2.Minutes;
        int wednesdayMinutes1 = wednesdayTime1.Minutes;
        int wednesdayMinutes2 = wednesdayTime1.Minutes;
        int thursdayMinutes1 = thursdayTime1.Minutes;
        int thursdayMinutes2 = thursdayTime2.Minutes;
        int fridayMinutes1 = fridayTime1.Minutes;
        int fridayMinutes2 = fridayTime2.Minutes;

        // Calculations
        int totalHours = mondayHours1 + mondayHours2 + tuesdayHours1 + tuesdayHours2 + 
            wednesdayHours1 + wednesdayHours2 +
            thursdayHours1 + thursdayHours2 +
            fridayHours1 + fridayHours2;

        int totalMinutes = mondayMinutes1 + mondayMinutes2 +
            tuesdayMinutes1 + tuesdayMinutes2 +
            wednesdayMinutes1 + wednesdayMinutes2 + 
            thursdayMinutes1 + thursdayMinutes2 +
            fridayMinutes1 + fridayMinutes2;

        int addToTotalHours = totalMinutes / 60;

        totalHours += addToTotalHours;

        totalMinutes = totalMinutes % 60;

        decimal totalFormatted = Convert.ToDecimal(totalHours) +
            (Convert.ToDecimal(totalMinutes) / 60);

        txtHoursTotal.Text = totalHours.ToString();
        txtMinutesTotal.Text = totalMinutes.ToString();
        txtHoursDecimalTotal.Text = Math.Round(totalFormatted, 2).ToString();
    }
}