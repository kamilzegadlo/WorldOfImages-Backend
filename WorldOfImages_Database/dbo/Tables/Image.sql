CREATE TABLE [dbo].[Image] (
    [Id]        UNIQUEIDENTIFIER   CONSTRAINT [DV_Image_ID] DEFAULT (newid()) NOT NULL,
    [X]         INT                NOT NULL,
    [Y]         INT                NOT NULL,
    [CreatedOn] DATETIMEOFFSET (7) CONSTRAINT [DV_Image_CreatedOn] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [Path] NVARCHAR(128) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Image_Place] FOREIGN KEY ([X], [Y]) REFERENCES [Place]([X], [Y])
);


GO

CREATE INDEX [IX_Image_XY_Path] ON [dbo].[Image] ([X], [Y]) INCLUDE ([Path])
