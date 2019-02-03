-- Note you may need to change the path for location of the database dependent on where 
-- you installed SQL-Server

USE [master]
GO
/****** Object:  Database [EmailTesting]    Script Date: 12/31/2018 5:26:16 PM ******/
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
/****** Object:  Table [dbo].[CannedMessages]    Script Date: 12/31/2018 5:26:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CannedMessages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[HtmlMessage] [nvarchar](max) NULL,
	[TextMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_CannedMessages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailAddresses]    Script Date: 12/31/2018 5:26:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAddresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmailAddresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CannedMessages] ON 

GO
INSERT [dbo].[CannedMessages] ([id], [Description], [HtmlMessage], [TextMessage]) VALUES (1, N'Very simple HTML', N'This email was sent from a <span style="font-weight: bold;color: brown"> unit test</span> as rich text.', N'This email was sent from a unit test as plain text.')
GO
INSERT [dbo].[CannedMessages] ([id], [Description], [HtmlMessage], [TextMessage]) VALUES (2, N'Has unordered list', N'This email was sent from a <span style="font-weight: bold;color: brown"> unit test</span> as hrml.<ul><li>Apples</li><li>Oranges</li><li>Grapes</li></ul>', N'So sorry you missed seeing this great looking message.')
GO
INSERT [dbo].[CannedMessages] ([id], [Description], [HtmlMessage], [TextMessage]) VALUES (3, N'With table', N'<span style="font-weight: bold;color: green">Unit test</span>.<table style="border: 1px solid black; border-collapse: collapse;" rules="groups"><thead style="border: 2px solid black;"><tr><td>First</td><td>Last</td></tr></thead><tr><td>Karen</td><td>Payne</td></tr><tr><td>Jill</td><td>Jones</td></tr></table>', N'Missing table demo')
GO
INSERT [dbo].[CannedMessages] ([id], [Description], [HtmlMessage], [TextMessage]) VALUES (4, N'Bad host', N'Will never see this', N'Not to be seen')
GO
INSERT [dbo].[CannedMessages] ([id], [Description], [HtmlMessage], [TextMessage]) VALUES (5, N'SQL-Server tib but', N'<h1>Microsoft SQL Server</h1><p style="font-style: italic">From Wikipedia, the free encyclopedia</p>Microsoft SQL Server is a <a href="https://en.wikipedia.org/wiki/Relational_database_management_system">relational database management system</a><a href="https://en.wikipedia.org/wiki/Relational_database_management_system">relational database management system</a> developed by Microsoft. As a database server, it is a software product with the primary function of storing and retrieving data as requested by other software applications—which may run either on the same computer or on another computer across a network (including the Internet).
', N'About SQL-Server')
GO
SET IDENTITY_INSERT [dbo].[CannedMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailAddresses] ON 

GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (1, N'ofizher.lshtlesml@ifceufuro.llrndb.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (2, N'ykmo40@rmrnhk.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (3, N'deecjaf.fpeg@qmunt.ussrmz.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (4, N'xegr.trva@qifmiaq.abmxcj.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (5, N'mlwadt354@yqubkilmg.mijvvq.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (6, N'lqgfkd821@pnpdl.wtawze.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (7, N'rtxhkza.vsfqpem@cnxvusjy.tjtg-h.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (8, N'mzyue.bulgbh@qrcnlv.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (9, N'xlmgpsos.vrmh@shu-gc.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (10, N'eudpwth.ubirozj@jelxc.cevdax.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (11, N'ohcvo.dqxds@geiluout.frtkry.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (12, N'qwhu17@gnou.dyyqvp.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (13, N'avnvdvn504@kvsdqn.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (14, N'ffmhpn.hgmmgzwq@ssba.hnemcx.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (15, N'qrmq82@wfuzjrm.bcsuzm.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (16, N'dukap3@uipges.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (17, N'fvsidna@vszlne.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (18, N'awlo581@xzcsh.zvpwzk.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (19, N'cacvwbbe.jthgep@u-ofsz.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (20, N'okkyalwj402@tbkjo.sq-faq.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (21, N'vhddtm.yryxx@corlgv.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (22, N'qdcvtks.huoui@va-csj.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (23, N'voxqkeht.maqr@fsdpbi.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (24, N'rfqf.pgmzzembop@xvvxvd.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (25, N'xzfba09@bypjgn.rtwddo.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (26, N'llatjmcd0@mxlc.aycgmo.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (27, N'mjvtvqmz@vayumsgc.dwkavm.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (28, N'eylj733@yzlaix.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (29, N'zivtihlh69@bwxqv.-ekaxw.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (30, N'svbei5@cctshysv.cyodsa.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (31, N'uxtwldsp.nrrdlnsn@hxmibq.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (32, N'dricm@iry-cp.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (33, N'eoanblfi.wkktud@z-keef.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (34, N'jvuw81@zgaebt.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (35, N'ahfox.rqptzjutdc@dnonfw.drjtyq.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (36, N'flsuyz.rhlxten@sfiglu.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (37, N'fqjhw.hxpikhlpiz@tyyzel.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (38, N'kjetrsc.lfvrhqvp@whqago.ftgrdv.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (39, N'sytwrre.xubolhcja@ythxdb.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (40, N'mqgkpgp.snwrpkdmna@dhdxlk.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (41, N'vsofw6@hwoaqmb.ijekqb.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (42, N'hicm@f-zquj.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (43, N'cbsyxe.vjbokk@nayhoxi.eltpmk.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (44, N'qtip@rjqutb.net')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (45, N'zmdt91@slk-ej.org')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (46, N'yrcmdtcv.gnscsxrah@cvcwb-.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (47, N'rfgsr753@qwtyf.qsmjdb.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (48, N'uwypbt.yyzuaxrddr@xgaeqn.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (49, N'ehaee28@pamyvy.com')
GO
INSERT [dbo].[EmailAddresses] ([id], [EmailAddress]) VALUES (50, N'tbjfnd.nutznk@qxvpvm.com')
GO
SET IDENTITY_INSERT [dbo].[EmailAddresses] OFF
GO
USE [master]
GO
ALTER DATABASE [EmailTesting] SET  READ_WRITE 
GO
