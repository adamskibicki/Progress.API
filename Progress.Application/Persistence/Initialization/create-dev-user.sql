IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'dev_user')
BEGIN
    CREATE LOGIN [dev_user] WITH PASSWORD = N'<dev_PASS12345!>'
           
    ALTER SERVER ROLE [dbcreator] ADD MEMBER [dev_user]
END