CREATE TABLE [dbo].[Round]
(
	[RoundId] INT NOT NULL PRIMARY KEY, 
    [FacilityId] INT NOT NULL, 
    [CourseId] INT NOT NULL, 
    [TeeTypeId] INT NOT NULL, 
    [Date] DATE NOT NULL, 
    [NumberOfHoles] BIT NOT NULL DEFAULT 0
)
