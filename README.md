UserManagement based on .NET 5 CORE
#Author: Kumar Abhishek
Note: This has been created only for learning purpose

Follow the following steps to play around:
1.	Update the database connection to point your database in the UserManagement.Dal->AppDbContext.cs and SignUpPageChallenge->appsetting.json files.
2.	Apply the Database migration file by running the command update-database 
3.	Check for table creation (you can add some data to Cities and Countries table and even if you don't there is static list option present to handle an empty database).
4.	Set the statup project as the UI project and run to see it working.
5. As, of now the application only creates the User for read,update and delete the functionality will be added later.
