// ********************************************************************************************************************
//************************************SSDQopenECA Analytic********************************
//Code for Streaming Synchrophasor Data Quality and Conditioning application
//Company- Electric Power Research Institute (EPRI)
//Manager- Dr. Evangelos Farantatos
//Developer-Tapas Kumar Barik, Virginia Polytechnic & State University, EPRI Summer Intern 2019
//File:Helpwindow.cs
//Description: This code segment depicts the Help window provinding details about the current version of the product.
//*********************************************************************************************************************
using System;
using System.Windows.Forms;

namespace SSDQopenECA
{
    public partial class Helpwindow : Form
    {
        public Helpwindow()
        {
            InitializeComponent();
        }

        private void Helpwindow_Load(object sender, EventArgs e)
        {
            //Load the form with the text as shown below
            label2.Text = " Streaming Synchrophasor Data Quality (SSDQ) openECA Version 1.0";
            label4.Text = " Electric Power Research Institute (EPRI) \n 3420 Hillview Ave. \n Palo Alto,CA 94304";
            label6.Text = " EPRI Customer Assistance Center \n Phone: 800-313-3774 \n Email: askepri@epri.com";
            label8.Text = " Copyright © 2019 Electric Power Research Institute, Inc.";
            label9.Text = " EPRI reserves all rights in the Program as delivered. The Program or any option thereof may not be reproduced in any form whatsoever except \n " +
                "as provided by license without the writeen consent of EPRI. A license under EPRI's rights in the Program may be available directly from EPRI";
            label11.Text = " The embodiments of this Program and supporting materials amy be ordered from: \n" +
                " Electric Power Software Center (EPSC) \n 1300 W. W.T.Harris Blvd. \n Charlotte,NC 28262 \n Phone:1-800-313-3774 \n Email: askepri@epri.com";
            label14.Text = " THIS NOTICE MAY NOT BE REMOVED FROM THE PROGRAM BY ANY USER THEREOF.";
            label15.Text = " NEITHER EPRI, ANY MEMBER OF EPRI, NOR ANY PERSON OR ORGANIZATION ACTING ON BEHALF OF THEM: \n " +
                "1. MAKES ANY WARRANTY OR REPRESENTATION WHATSOEVER, EXPRESS OR IMPLIED, INCLUDING ANY WARRANTY OF \n   MERCHANTABILITY OR FITNESS OF ANY PURPOSE WITH RESPECT TO THE PROGRAM.";
            label16.Text = "2. ASSUMES ANY LIABILITY WHATSOEVER WITH RESPECT TO ANY USE OF THE PROGRAM OR ANY PORTION THEREOF OR \n   WITH RESPECT TO ANY DAMAGES WHICH MAY RESULT FROM SUCH USE.";
            label18.Text = " RESTRICTED RIGHTS LEGEND: USE, DUPLICATION, OR DISCLOSURE BY THE UNITED STATES FEDERAL GOVERNMENT IS \n SUBJECT TO RESTRICTION AS SET FORTH IN PARAGRAPH (g)(3)(i)," +
                " WITH THE EXCEPTION OF PARAGRAPH (g)(3)(i)(b)(5), \n OF THE RIGHTS IN TECHNICAL DATA AND COMPUTER SOFTWARE CLAUSE IN FAR 52.227-14, ALTERNATE III.";

        }
    }
}
