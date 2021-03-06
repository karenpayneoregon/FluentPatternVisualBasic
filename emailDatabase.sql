USE [EmailTesting]
GO
/****** Object:  Table [dbo].[EmailAddresses]    Script Date: 1/1/2019 5:17:27 PM ******/
DROP TABLE [dbo].[EmailAddresses]
GO
/****** Object:  Table [dbo].[CannedMessages]    Script Date: 1/1/2019 5:17:27 PM ******/
DROP TABLE [dbo].[CannedMessages]
GO
USE [master]
GO
/****** Object:  Database [EmailTesting]    Script Date: 1/1/2019 5:17:27 PM ******/
DROP DATABASE [EmailTesting]
GO
/****** Object:  Database [EmailTesting]    Script Date: 1/1/2019 5:17:27 PM ******/
CREATE DATABASE [EmailTesting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmailTesting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EmailTesting.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmailTesting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EmailTesting_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmailTesting] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmailTesting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmailTesting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmailTesting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmailTesting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmailTesting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmailTesting] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmailTesting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmailTesting] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EmailTesting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmailTesting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmailTesting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmailTesting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmailTesting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmailTesting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmailTesting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmailTesting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmailTesting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmailTesting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmailTesting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmailTesting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmailTesting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmailTesting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmailTesting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmailTesting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmailTesting] SET RECOVERY FULL 
GO
ALTER DATABASE [EmailTesting] SET  MULTI_USER 
GO
ALTER DATABASE [EmailTesting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmailTesting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmailTesting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmailTesting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [EmailTesting]
GO
/****** Object:  Table [dbo].[CannedMessages]    Script Date: 1/1/2019 5:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CannedMessages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MailSubject] [nvarchar](max) NULL,
	[HtmlMessage] [nvarchar](max) NULL,
	[TextMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_CannedMessages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailAddresses]    Script Date: 1/1/2019 5:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAddresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmailAddresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CannedMessages] ON 

INSERT [dbo].[CannedMessages] ([id], [Description], [MailSubject], [HtmlMessage], [TextMessage]) VALUES (1, N'Very simple HTML', N'Subject 1', N'This email was sent from a <span style="font-weight: bold;color: brown"> unit test</span> as rich text.', N'This email was sent from a unit test as plain text.')
INSERT [dbo].[CannedMessages] ([id], [Description], [MailSubject], [HtmlMessage], [TextMessage]) VALUES (2, N'Has unordered list', N'Subject 2', N'This email was sent from a <span style="font-weight: bold;color: brown"> unit test</span> as hrml.<ul><li>Apples</li><li>Oranges</li><li>Grapes</li></ul>', N'So sorry you missed seeing this great looking message.')
INSERT [dbo].[CannedMessages] ([id], [Description], [MailSubject], [HtmlMessage], [TextMessage]) VALUES (3, N'With table', N'Subject 3', N'<span style="font-weight: bold;color: green">Unit test</span>.<table style="border: 1px solid black; border-collapse: collapse;" rules="groups"><thead style="border: 2px solid black;"><tr><td>First</td><td>Last</td></tr></thead><tr><td>Karen</td><td>Payne</td></tr><tr><td>Jill</td><td>Jones</td></tr></table>', N'Missing table demo')
INSERT [dbo].[CannedMessages] ([id], [Description], [MailSubject], [HtmlMessage], [TextMessage]) VALUES (4, N'Bad host', N'Subject 4', N'Will never see this', N'Not to be seen')
INSERT [dbo].[CannedMessages] ([id], [Description], [MailSubject], [HtmlMessage], [TextMessage]) VALUES (5, N'SQL-Server tib but', N'Subject 5', N'<h1>Microsoft SQL Server</h1><p style="font-style: italic">From Wikipedia, the free encyclopedia</p>Microsoft SQL Server is a <a href="https://en.wikipedia.org/wiki/Relational_database_management_system">relational database management system</a><a href="https://en.wikipedia.org/wiki/Relational_database_management_system">relational database management system</a> developed by Microsoft. As a database server, it is a software product with the primary function of storing and retrieving data as requested by other software applications—which may run either on the same computer or on another computer across a network (including the Internet).
', N'About SQL-Server')
SET IDENTITY_INSERT [dbo].[CannedMessages] OFF
SET IDENTITY_INSERT [dbo].[EmailAddresses] ON 

INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (1, N'ofizher.lshtlesml@ifceufuro.llrndb.net', N'Angie', N'Fuller')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (2, N'ykmo40@rmrnhk.net', N'Keisha', N'Palmer')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (3, N'deecjaf.fpeg@qmunt.ussrmz.org', N'Carey', N'Cline')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (4, N'xegr.trva@qifmiaq.abmxcj.org', N'Shari', N'Nielsen')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (5, N'mlwadt354@yqubkilmg.mijvvq.com', N'Faith', N'Stuart')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (6, N'lqgfkd821@pnpdl.wtawze.org', N'Terence', N'Collins')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (7, N'rtxhkza.vsfqpem@cnxvusjy.tjtg-h.net', N'Anne', N'Cook')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (8, N'mzyue.bulgbh@qrcnlv.net', N'Mickey', N'Dyer')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (9, N'xlmgpsos.vrmh@shu-gc.net', N'Deanna', N'King')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (10, N'eudpwth.ubirozj@jelxc.cevdax.net', N'Anne', N'Vang')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (11, N'ohcvo.dqxds@geiluout.frtkry.org', N'Carlos', N'Dickson')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (12, N'qwhu17@gnou.dyyqvp.org', N'Hector', N'Chen')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (13, N'avnvdvn504@kvsdqn.net', N'Keri', N'Marks')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (14, N'ffmhpn.hgmmgzwq@ssba.hnemcx.com', N'Arturo', N'Buckley')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (15, N'qrmq82@wfuzjrm.bcsuzm.org', N'Molly', N'Finley')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (16, N'dukap3@uipges.net', N'Kristie', N'Walton')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (17, N'fvsidna@vszlne.org', N'Alfred', N'Franco')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (18, N'awlo581@xzcsh.zvpwzk.com', N'Ruth', N'Bartlett')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (19, N'cacvwbbe.jthgep@u-ofsz.net', N'Luz', N'Moody')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (20, N'okkyalwj402@tbkjo.sq-faq.com', N'Roderick', N'Riddle')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (21, N'vhddtm.yryxx@corlgv.org', N'Donnell', N'Brewer')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (22, N'qdcvtks.huoui@va-csj.com', N'Edwin', N'Mc Millan')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (23, N'voxqkeht.maqr@fsdpbi.org', N'Erich', N'Flowers')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (24, N'rfqf.pgmzzembop@xvvxvd.org', N'Irma', N'Ayers')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (25, N'xzfba09@bypjgn.rtwddo.com', N'Sophia', N'Erickson')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (26, N'llatjmcd0@mxlc.aycgmo.com', N'Kisha', N'Wood')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (27, N'mjvtvqmz@vayumsgc.dwkavm.com', N'Quentin', N'Beltran')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (28, N'eylj733@yzlaix.com', N'Timmy', N'Clark')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (29, N'zivtihlh69@bwxqv.-ekaxw.org', N'Rebekah', N'Matthews')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (30, N'svbei5@cctshysv.cyodsa.net', N'Joseph', N'Dunn')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (31, N'uxtwldsp.nrrdlnsn@hxmibq.org', N'Candy', N'Benson')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (32, N'dricm@iry-cp.com', N'Ana', N'Braun')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (33, N'eoanblfi.wkktud@z-keef.net', N'Judy', N'Banks')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (34, N'jvuw81@zgaebt.com', N'Dana', N'Buck')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (35, N'ahfox.rqptzjutdc@dnonfw.drjtyq.net', N'Kristy', N'Oliver')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (36, N'flsuyz.rhlxten@sfiglu.org', N'Ericka', N'May')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (37, N'fqjhw.hxpikhlpiz@tyyzel.com', N'Billy', N'Herman')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (38, N'kjetrsc.lfvrhqvp@whqago.ftgrdv.org', N'Shannon', N'Santos')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (39, N'sytwrre.xubolhcja@ythxdb.com', N'Clarence', N'Chapman')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (40, N'mqgkpgp.snwrpkdmna@dhdxlk.net', N'Shad', N'Powell')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (41, N'vsofw6@hwoaqmb.ijekqb.net', N'Jesus', N'Irwin')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (42, N'hicm@f-zquj.net', N'Randolph', N'Hill')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (43, N'cbsyxe.vjbokk@nayhoxi.eltpmk.org', N'Donnell', N'Leach')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (44, N'qtip@rjqutb.net', N'James', N'Lloyd')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (45, N'zmdt91@slk-ej.org', N'Clint', N'Acosta')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (46, N'yrcmdtcv.gnscsxrah@cvcwb-.com', N'Brandy', N'Carpenter')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (47, N'rfgsr753@qwtyf.qsmjdb.com', N'Roy', N'Rocha')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (48, N'uwypbt.yyzuaxrddr@xgaeqn.com', N'Philip', N'Wilcox')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (49, N'ehaee28@pamyvy.com', N'Joseph', N'Gibbs')
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress], [FirstName], [LastName]) VALUES (50, N'tbjfnd.nutznk@qxvpvm.com', N'Erik', N'Travis')
SET IDENTITY_INSERT [dbo].[EmailAddresses] OFF
USE [master]
GO
ALTER DATABASE [EmailTesting] SET  READ_WRITE 
GO
