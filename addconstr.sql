﻿ALTER TABLE dbo.Orders ADD FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID);
