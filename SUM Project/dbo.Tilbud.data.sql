CREATE TABLE [dbo].[TilbudHåndværkstimer] (
    [tilbud_id] INT        NOT NULL,
    [med_id]    INT        NOT NULL,
    [antal]     INT        NOT NULL,
    [brugt]     INT        NOT NULL,
    [rabat]     FLOAT (53) NOT NULL,
    CONSTRAINT [PK_TilbudHåndværkstimer] PRIMARY KEY CLUSTERED ([tilbud_id] ASC, [med_id] ASC)
);

