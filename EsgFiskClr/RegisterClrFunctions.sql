/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--in case of conflicts with GAC use this alter script for the specific dll
--ALTER ASSEMBLY [System.Runtime.Serialization] FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Runtime.Serialization.dll'

--To avoid having to guess which folder to import from, run this query:
--select * from sys.dm_clr_properties

USE MEGATEK
GO
--SP_CONFIGURE 'CLR_ENABLED',1
--GO
--RECONFIGURE
--GO
--ALTER DATABASE MEGATEK SET TRUSTWORTHY ON
--GO
--ALTER AUTHORIZATION ON DATABASE::MEGATEK TO [sa]
--GO 

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'RegisterCashDesk')
   DROP function RegisterCashDesk
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'RegisterCashDeposit')
   DROP function RegisterCashDeposit
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GenerateIICType')
   DROP function GenerateIICType
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GenerateIICQR')
   DROP function GenerateIICQR
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'RegisterInvoice')
   DROP function RegisterInvoice
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GetTaxpayers')
   DROP function GetTaxpayers
go
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GenerateQrCode')
   DROP function GenerateQrCode
go
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'EsgFiskClr')
   DROP ASSEMBLY EsgFiskClr
GO


IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'System.Runtime.Serialization')
   DROP ASSEMBLY [System.Runtime.Serialization]
GO
CREATE ASSEMBLY [System.Runtime.Serialization]
FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Runtime.Serialization.dll'
WITH PERMISSION_SET = UNSAFE
GO
CREATE ASSEMBLY [System.Runtime.Serialization]
FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Runtime.Serialization.dll'
WITH PERMISSION_SET = UNSAFE
GO
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'system.web')
   DROP ASSEMBLY [system.web]
GO
CREATE ASSEMBLY [system.web]
FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\system.web.dll'
WITH PERMISSION_SET = UNSAFE
GO

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'system.servicemodel.internals')
   DROP ASSEMBLY [system.servicemodel.internals]
GO
create assembly [system.servicemodel.internals]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.ServiceModel.Internals.dll'
with permission_set = UNSAFE;
go


IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'system.componentmodel.dataannotations')
   DROP ASSEMBLY [system.componentmodel.dataannotations]
GO
create assembly [system.componentmodel.dataannotations]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\system.componentmodel.dataannotations.dll'
with permission_set = UNSAFE;
go



IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'microsoft.csharp')
   DROP ASSEMBLY [microsoft.csharp]
GO
create assembly [microsoft.csharp]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\microsoft.csharp.dll'
with permission_set = UNSAFE;

GO

GO
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'presentationcore')
   DROP ASSEMBLY [presentationcore]
GO
create assembly [presentationcore]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\wpf\presentationcore.dll'
with permission_set = UNSAFE;
GO
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'presentationframework')
   DROP ASSEMBLY [presentationframework]
GO
create assembly [presentationframework]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\wpf\presentationframework.dll'
with permission_set = UNSAFE;
GO
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'windowsbase')
   DROP ASSEMBLY [windowsbase]
GO
create assembly [windowsbase]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\wpf\windowsbase.dll'
with permission_set = UNSAFE;

go

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'uiautomationprovider')
   DROP ASSEMBLY uiautomationprovider
GO
create assembly uiautomationprovider
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\wpf\uiautomationprovider.dll'
with permission_set = UNSAFE;

go

IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'system.windows.input.manipulations')
   DROP ASSEMBLY [system.windows.input.manipulations]
GO
create assembly [system.windows.input.manipulations]
from 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\wpf\system.windows.input.manipulations.dll'
with permission_set = UNSAFE;

go

--IF EXISTS (SELECT name FROM sysobjects WHERE name = 'RegisterCashDesk')
--   DROP function RegisterCashDesk
--go

--IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'EsgFiskClr')
--   DROP ASSEMBLY EsgFiskClr
--GO

CREATE ASSEMBLY EsgFiskClr FROM 'C:\Users\KlodianMaloku\source\repos\EsgFisk\EsgFiskClr\bin\Debug\EsgFiskClr.dll'
WITH PERMISSION_SET = UNSAFE


PRINT N'Duke krijuar [dbo].[RegisterCashDesk]...';
go

CREATE FUNCTION [dbo].RegisterCashDesk
(
@CashDeskId NVARCHAR (4000), 
@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].RegisterCashDesk

go 

PRINT N'Perfunduar me sukses [dbo].[testDbConnection]...';
go



PRINT N'Duke krijuar [dbo].[RegisterCashDeposit]...';
go

CREATE FUNCTION [dbo].RegisterCashDeposit
(
@CashDepositId NVARCHAR (4000), 
@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].RegisterCashDeposit

go 

PRINT N'Perfunduar me sukses [dbo].[RegisterCashDeposit]...';
go 


PRINT N'Duke krijuar [dbo].[GenerateIICType]...';
go
CREATE FUNCTION [dbo].GenerateIICType
(
	@InvoicePkid NVARCHAR (4000), 
	@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].GenerateIICType

go 

PRINT N'Perfunduar me sukses [dbo].[GenerateIICType]...';

go 


PRINT N'Duke krijuar [dbo].[GenereateIICQR]...';
go
CREATE FUNCTION [dbo].GenerateIICQR
(
	@InvoicePkid NVARCHAR (4000), 
	@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].GenerateIICQR

go 

PRINT N'Perfunduar me sukses [dbo].[GenereateIICQR]...';

go 



PRINT N'Duke Krijuar [dbo].[GetTaxpayers]...';
go 
CREATE FUNCTION [dbo].GetTaxpayers
(
	@TaxPayerNUIS NVARCHAR (4000), 
	@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].GetTaxpayers

go 

PRINT N'Perfunduar me sukses [dbo].[GetTaxpayers]...';

go 



PRINT N'Duke Krijuar [dbo].[RegisterInvoice]...';
go 
CREATE FUNCTION [dbo].RegisterInvoice
(
	@InvoicePkid NVARCHAR (4000), 
	@UserId NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgFisk].RegisterInvoice

go 

PRINT N'Perfunduar me sukses [dbo].[RegisterInvoice]...';

go

PRINT N'Duke Krijuar [dbo].[RegisterInvoice]...';
go 
CREATE FUNCTION [dbo].GenerateQrCode
(
	@QrContent NVARCHAR (4000)
)
RETURNS NVARCHAR (4000)
AS
 EXTERNAL NAME [EsgFiskClr].[EsgTools].GenerateQrCode

go 

PRINT N'Perfunduar me sukses [dbo].[GenerateQrCode]...';