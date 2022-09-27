## Task Management System

A task Management System Built Using:
* Asp .Net Core 6 webapi
* Entity Framework core 6:
    * Data Annotation
* PostgresQL

## Entity Diagram
![Stock Manager](https://user-images.githubusercontent.com/74520811/192605597-e4fc5afa-0826-4965-a404-f826ea780376.png)

### System Functionality
* Signup
* Login (Basic Auth)
* Task Functionality
    * Add Task
    * Get Task
    * Delete Task
    * Update Task

* Add Remainder
    * Add Remainder
    * Delete Remainder
    * Get Remainder
    * Update Remainder

* Automatic Email Alert For Tasks

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

### Improvement
* Authentication:
    * JWT Tokens can be used to improve higher security.
    * 2 Factor can be also be implemented.
    * When deployed unto azure, API manager can be used to protect endpoint.

* Job Scheduling:
    Azure Function Time Schedular can be used for better scalling instead of manually implemeting it.

### References
* Cron job scheduling: https://blog.devart.com/scheduling-cron-jobs-in-asp-net-6-and-c.html
* Entity Framework Core: https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx
* Webapi 6 docs: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
