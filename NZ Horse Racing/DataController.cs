using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NZ_Horse_Racing
{
    public partial class DataController : Form
    {
        public DataTable dtCustomer;
        public DataTable dtOwner;
        public DataTable dtHorse;
        public DataTable dtJockey;
        public DataTable dtMeeting;
        public DataTable dtCourse;
        public DataTable dtBooking;
        public DataTable dtRace;
        public DataTable dtEntry;

        public DataView customerView;
        public DataView ownerView;
        public DataView horseView;
        public DataView jockeyView;
        public DataView meetingView;
        public DataView courseView;
        public DataView bookingView;
        public DataView raceView;
        public DataView entryView;

        public DataController()
        {
            // only data adapters needed are customer, owner, horse, booking

            InitializeComponent();
            dsNZHorseRacing.EnforceConstraints = false;
            daCustomers.Fill(dsNZHorseRacing);
            daOwners.Fill(dsNZHorseRacing);
            daHorses.Fill(dsNZHorseRacing);
            daJockeys.Fill(dsNZHorseRacing);
            daMeetings.Fill(dsNZHorseRacing);
            daCourses.Fill(dsNZHorseRacing);
            daBookings.Fill(dsNZHorseRacing);
            daRaces.Fill(dsNZHorseRacing);
            daRaceEntries.Fill(dsNZHorseRacing);
            dtBooking = dsNZHorseRacing.Tables["Bookings"];
            dtCourse = dsNZHorseRacing.Tables["RaceCourses"];
            dtCustomer = dsNZHorseRacing.Tables["Customers"];
            dtEntry = dsNZHorseRacing.Tables["RaceEntry"];
            dtHorse = dsNZHorseRacing.Tables["Horses"];
            dtJockey = dsNZHorseRacing.Tables["Jockeys"];
            dtMeeting = dsNZHorseRacing.Tables["Meetings"];
            dtOwner = dsNZHorseRacing.Tables["Owners"];
            dtRace = dsNZHorseRacing.Tables["Races"];
            bookingView = new DataView(dtBooking);
            bookingView.Sort = "BookingID";
            courseView = new DataView(dtCourse);
            courseView.Sort = "CourseID";
            customerView = new DataView(dtCustomer);
            customerView.Sort = "CustomerID";
            entryView = new DataView(dtEntry);
            entryView.Sort = "EntryID";
            horseView = new DataView(dtHorse);
            horseView.Sort = "HorseID";
            jockeyView = new DataView(dtJockey);
            jockeyView.Sort = "JockeyID";
            meetingView = new DataView(dtMeeting);
            meetingView.Sort = "MeetingID";
            ownerView = new DataView(dtOwner);
            ownerView.Sort = "OwnerID";
            raceView = new DataView(dtRace);
            raceView.Sort = "RaceID";
            dsNZHorseRacing.EnforceConstraints = true;
            
        }

        public void UpdateCustomer()
        {
            daCustomers.Update(dsNZHorseRacing, "Customers");
        }

        public void UpdateOwner()
        {
            daOwners.Update(dsNZHorseRacing, "Owners");
        }

        private void daBookings_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }

      

        private void daCustomers_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 50000;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZHorseRacing);
            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["CustomerID"] = newID;
            }
        }

        private void daOwners_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 0;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZHorseRacing);
            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["OwnerID"] = newID;
            }
        }
    }
}
