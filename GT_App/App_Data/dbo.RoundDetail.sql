CREATE TABLE [dbo].[RoundDetail] (
    [RoundId]          INT             IDENTITY (1, 1) NOT NULL,
    [GolferId]         INT             NOT NULL,
    [TeeTypeId]        INT             NOT NULL,
    [HoleId]           INT             NOT NULL,
    [Differential]     DECIMAL (18, 1) NOT NULL,
    [Score]            TINYINT         NOT NULL,
    [Putts]            TINYINT         NULL,
    [GIR]              BIT             NULL,
    [FIR]              BIT             NULL,
    [Up_And_Down]      BIT             NULL,
    [Par_Save]         BIT             NULL,
    [Sand_Save]        BIT             NULL,
    [Driving_Distince] SMALLINT        NULL,
    [Proximity]        INT             NULL,
    [Green_Fee]        DECIMAL (18, 2) NULL,
    [RoundDetailId] INT NOT NULL 
);

