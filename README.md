﻿# asp.net-db-practice

 # appsettings.json file needs to be added and updated to include password

 {
  "ConnectionStrings": {
    "todoDBConnection": "Server=tcp:todoserver1.database.windows.net,1433;Initial Catalog=TodoDB;Persist Security Info=False;User ID=todoadmin;Password={PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
