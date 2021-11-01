# JSChat
Job Site Chat Challenge

#CREATE JSChatDB
Please exec the script named /DBScripts/JSChatDB_CREATE.sql ir order to create a JSChatDb database

#UPDATING CONNECTIONS STRINGS
After you download the project the connection strings in the web.config should be changed with right values for SERVER, USER and PASSWORD
 
<add name="DefaultConnection" connectionString="Data Source=YOURSERVERNAME;initial catalog=JSChatDB;persist security info=True;user id=YOURUSER;password=YOURPASSWORD;multipleactiveresultsets=True;" providerName="System.Data.SqlClient"/>
  
<add name="JSChatDBEntities" connectionString="metadata=res://*/JSCModel.csdl|res://*/JSCModel.ssdl|res://*/JSCModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=YOURSERVERNAME;initial catalog=JSChatDB;persist security info=True;user id=YOURUSER;password=YOURPASSWORD;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient"/>
