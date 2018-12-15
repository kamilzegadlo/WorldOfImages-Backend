CREATE TABLE [dbo].[Place] (
    [X]         INT                NOT NULL,
    [Y]         INT                NOT NULL,
    [Name]      NVARCHAR (128)     NOT NULL,
    [CreatedOn] DATETIMEOFFSET (7) CONSTRAINT [DV_Place_CreatedOn] DEFAULT (sysdatetimeoffset()) NOT NULL,
    PRIMARY KEY CLUSTERED ([X] ASC, [Y] ASC)
);

