# Dashbox (Feb 2016)

A Web App (Asp.Net WebApi/ JQuery / Dyanmics CRM SDK) for building beautiful dashboards with charts coming from multiple data sources (initialy Dynamics CRM 2011 to 365 but also SBO, SAGE 100...). The App is based on the awesome Gentelella Bootstrap template (https://github.com/ColorlibHQ/gentelella).  
Labels are in french language :-).


# Installation

1- Clone the repository

2- Create the database by execution the DashBox.sql script on a SQL server 2008+ instance

3- Adjust the connection string in the web.config as needed

4- Open and Run the solution DashBox.sln in Visual Studio 2010+

5- Log-in with the admin account (admin / 12345678)


# Usage

1- Create Connections to data source in the Admin > Connections (Only connections to Dyamics CRM are working)

2- Create Charts in Admin > Graphiques (just like in the Dynamics CRM chart editor)

3- Create a Dashboard in Admin > Tableaux de bord by selecting the layout and the chart to put in every placeholder

4- The visualisation of the Dashboards is not finnished

# To be done...

1- Update/Delete of the connections/charts/Dashboard (only adding and preview work)

2- The main page (Dashboard.aspx) is meant to display the available dashboards (It display the default Gentelella dashboard instead)

3- Users management / Roles management

4- Other connections type (SBO, SAGE 100 ...)

# Licence

You can use this source for personal use

No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF
ANY KIND, EITHER EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED
TO, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL CONFORM TO SPECIFICATIONS,
ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE,
OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE
ERROR FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO
THE SUBJECT SOFTWARE. THIS AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN
ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT OF ANY RESULTS,
RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
RESULTING FROM USE OF THE SUBJECT SOFTWARE.  FURTHER, GOVERNMENT AGENCY
DISCLAIMS ALL WARRANTIES AND LIABILITIES REGARDING THIRD-PARTY SOFTWARE,
IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT "AS IS."
