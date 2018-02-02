# Applicanty

### Create Database
To  create database you must follow this steps:
1. Open the console using the Tools > NuGet Package Manager > Package Manager Console command
2. Set default project to Applicancy.Data (check if it has been set because VS doesn't work properly)
3. In console enter comand `add-migration [Migration_Name]` to create migration
4. Enter `update-database` to create database

### Problem with Migration
If during database generation this error occurred:
``` sh
A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify
that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 50 - Local 
Database Runtime error occurred.
```
try to replace  SQL server name in appsettings.json file to  
```
(localdb)\mssqllocaldb
```
even if it's the same

### Test Users
To create test users you have to run a Applicanty.API project in debugging mode

| Email             | Password |
| ------            | ------ |
|victor@mail.com    |Rerehelpf1@|
|pashka@mail.com    |Rerehelpf1@|
|batman@mail.com    |Rerehelpf1@|
|stepanchik@mail.com|Rerehelpf1@|
|dudka27@mail.com   |Rerehelpf1@|

### Email Sender
To set up sending emails you need specify, the email from which the letters will be sent and password from it, in `appsettings.json`.
Also you neet specify Smtp Server and Smtp Port postal service you use. Now Smtp Server and Smtp Port setted for gmail.

`UsernameEmail` - email from which the letters will be sent  <br/>
`UsernamePassword` - password for this email  <br/>
`PrimaryPort` - The port, which the server will use to send SMTP transactions (emails)  <br/>