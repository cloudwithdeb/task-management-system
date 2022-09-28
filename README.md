## Task Management System

A task Management System Built Using:
* Asp .Net Core 6 webapi
* Entity Framework core 6:
    * Data Annotation
* PostgresQL

### Note:
* Postgres version 12 and above is installed.
* .Net core 6 is installed.
* .Net ef core cli installed
* Change the values in `${}` with the appropraite values in apps/appsettings.json file.

`{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DB_CON_STR": "Server=${HOST};Database=msk;Port=${PORT};User Id=${USER};Password=${PASSWORD};",
    "EMAIL": ${EMAIL},
    "EMAIL_PASSWORD": ${EMAIL_PASSWORD}
  }
}`
* HOST=Database host or url
* PORT=Database port number
* USER=Database admin name
* PASSWORD=Database password
* EMAIL=Email address to use to send remainders
* EMAIL_PASSWORD=The email address to use to send remainders PASSWORD

### To run the application
* Navigate to `app/`
* Run the following command
  * `dotnet ef migrations add taskManager`
  * `dotnet ef database update`
  * `dotnet watch run`

### References
* Cron job scheduling: https://blog.devart.com/scheduling-cron-jobs-in-asp-net-6-and-c.html
* Entity Framework Core: https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx
* Webapi 6 docs: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio