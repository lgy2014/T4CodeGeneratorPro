create procedure [dbo].[up_InsertSeatInfo]
	@CourtCode nvarchar(50),	--法院编号
	@CourtName nvarchar(50),	--法庭名称
	@Name varchar(50),			--席位名称
	@DevIp varchar(50),			--设备IP
	@ChannelNo varchar(10)		--通道编号
as
begin
    DECLARE @CourtId int
    SELECT @CourtId=0
    
    DECLARE @ChannelId int
    SELECT @ChannelId=0
    
    --判断法院是否存在
    IF NOT EXISTS(SELECT 1 FROM t_Court WHERE CourtCode=@CourtCode)
	BEGIN
		INSERT INTO t_Court(CourtCode,CourtName,SuperCourtCode)
		SELECT TOP 1 CourtCode,CourtName,SuperCourtCode FROM tb_Court 
		WHERE CourtCode=@CourtCode
    END
    
    --判断法庭是否存在
    IF NOT EXISTS(SELECT 1 FROM t_CourtInfo WHERE CourtName=@CourtName AND CourtCode=@CourtCode)
	BEGIN
		INSERT INTO t_CourtInfo(CourtName,Flag_Court,CourtCode)
		VALUES(@CourtName,17,@CourtCode)
		
		SELECT @CourtId=@@IDENTITY
    END
    ELSE
    BEGIN
		SELECT TOP 1 @CourtId=CourtId FROM t_CourtInfo WHERE CourtName=@CourtName AND CourtCode=@CourtCode
    END
    
    SELECT TOP 1 @ChannelId=C.ChannelId FROM t_Channel AS C
    LEFT OUTER JOIN t_AudioComputer AS A ON A.ComputerId=C.ComputerId
    WHERE A.ComputerIp=@DevIp AND C.ChannelNo='CH'+@ChannelNo
    
	IF NOT EXISTS(SELECT 1 FROM t_Seat WHERE CourtId=@CourtId AND ChannelId=@ChannelId)
	BEGIN
		INSERT INTO t_Seat (CourtId,SeatName,ChannelId)
		VALUES(@CourtId,@Name,@ChannelId)
	END
END