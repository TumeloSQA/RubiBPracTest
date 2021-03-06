USE [master]
GO
/****** Object:  Database [TestDB_MaremaneTP]    Script Date: 11/22/2018 3:58:08 PM ******/
CREATE DATABASE [TestDB_MaremaneTP]
 
ALTER DATABASE [TestDB_MaremaneTP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDB_MaremaneTP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET RECOVERY FULL 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET  MULTI_USER 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDB_MaremaneTP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestDB_MaremaneTP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestDB_MaremaneTP', N'ON'
GO
ALTER DATABASE [TestDB_MaremaneTP] SET QUERY_STORE = OFF
GO
USE [TestDB_MaremaneTP]
GO
/****** Object:  UserDefinedFunction [dbo].[CourseNumber_fn]    Script Date: 11/22/2018 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create function [dbo].[CourseNumber_fn] (@courseName varchar(50))
 
returns char(8) 
as 
begin 
DECLARE @yearCode varchar(5) = '1501';
return SUBSTRING(@courseName,1,3) + '' + @yearCode
end
GO
/****** Object:  UserDefinedFunction [dbo].[StudentNumber_fn]    Script Date: 11/22/2018 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[StudentNumber_fn] (@id int)
 
returns char(9) 
as 
begin 
DECLARE @date datetime = getdate();
return format(@date, 'yyMMdd') + right('000' + convert(varchar(10), @id), 3) 
end
GO
/****** Object:  Table [dbo].[Course]    Script Date: 11/22/2018 3:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CourseNumber]  AS ([dbo].[CourseNumber_fn]([CourseName])),
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NULL,
	[IDNumber] [varchar](20) NULL,
	[StudentNumber]  AS ([dbo].[StudentNumber_fn]([StudentId])),
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course](
	[StudentCourseID] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course__Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course__Course]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Student]
GO
/****** Object:  StoredProcedure [dbo].[nsp_getStudent_details]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[nsp_getStudent_details] 
@studentId int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT student.FirstName,student.Surname,
course.CourseName,format(course.StartDate,'yyyy/MM/dd') as "Start Date",format(course.EndDate, 'yyyy/MM/dd') as "End Date"
 from Student_Course sCourse
 inner join Course 
 on sCourse.CourseId = Course.CourseId
 inner join Student
 on sCourse.StudentId = Student.StudentId
	where
	sCourse.StudentId = @StudentId
END
GO
/****** Object:  StoredProcedure [dbo].[nsp_getStudents]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[nsp_getStudents] 
@studentName varchar(50)=''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Student
	select * from course
END
GO
/****** Object:  StoredProcedure [dbo].[nsp_insertCourse]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[nsp_insertCourse] 
@CourseName varchar(50),
@StartDate datetime=null,
@EndDate datetime = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	insert into Course(CourseName, StartDate, EndDate)
	VALUES
	(@CourseName,@StartDate,@EndDate)
END
GO
/****** Object:  StoredProcedure [dbo].[nsp_insertStudentCourse]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[nsp_insertStudentCourse] 
@studentID int,
@CourseID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Student_Course(StudentId, CourseId)
	VALUES
	(@studentID, @CourseID)
END
GO
/****** Object:  StoredProcedure [dbo].[nsp_insertStudents]    Script Date: 11/22/2018 3:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[nsp_insertStudents] 
@FirstName varchar(50),
@Surname varchar(50),
@EmailAddress varchar(50) = null,
@IDNumber varchar(20) = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	insert into Student(FirstName, Surname, EmailAddress, IDNumber)
	VALUES
	(@FirstName,@Surname,@EmailAddress,@IDNumber)
END
GO
USE [master]
GO
ALTER DATABASE [TestDB_MaremaneTP] SET  READ_WRITE 
GO
